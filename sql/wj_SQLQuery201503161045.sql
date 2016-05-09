
 
-- 产品和淘宝贝分页存储过程
ALTER PROC [dbo].[proc_productsearch]
@brandid int,--品牌
@categoryid int, --小类
@brandsid int ,--系列
@stylevalue varchar(20),--风格
@colorvalue varchar(20),--color
@materialvalue varchar(20),--材质
@dlid VARCHAR(50),--大类id,对应configtype类型
@bid INT ,--大类id
@marketid int ,--卖场id
@pagesize INT,--每页大小
@pageindex int,--页码 
@Promotion int,--参加活动类型设置在属性上的
@key nvarchar(100) ,--关键词
@keytype INT --关键词类型
as
DECLARE @str VARCHAR(8000)
DECLARE @strB VARCHAR(8000)
DECLARE @tops VARCHAR(10)
SET @str=''
SET @strB=''
SET @tops=''

 
 
SET @str='  ProductAttributePromotion,isnull(t_shop.id,0) as shopid, isnull(t_shop.title,'''' ) as shoptitle ,tp.id AS tpid,tp.title AS tptitle,
tp.companyid,companyname,brandtitle,    tp.sku, tp.stylename, tp.materialname,tp.categorytitle  ,  tp.brandid,buyprice,markprice,saleprice,tp.thumb,tp.lastedittime  FROM 
dbo.t_product tp INNER JOIN  t_productattribute tpb ON tp.id = tpb.productid 
inner join t_brand on t_brand.id = tp.brandid  AND t_brand.auditstatus=1 AND t_brand.linestatus=1 
LEFT JOIN t_productshopprice ON t_productshopprice.productid =  tp.id 
LEFT JOIN dbo.t_shop ON dbo.t_shop.id = t_productshopprice.shopid  
WHERE tp.auditstatus =1 AND tp.linestatus =1 '

SET @strB='SELECT count(0) FROM 
dbo.t_product tp INNER JOIN  t_productattribute tpb ON tp.id = tpb.productid 
inner join t_brand on t_brand.id = tp.brandid  AND t_brand.auditstatus=1 AND t_brand.linestatus=1 
LEFT JOIN t_productshopprice ON t_productshopprice.productid =  tp.id 
LEFT JOIN dbo.t_shop ON dbo.t_shop.id = t_productshopprice.shopid  
WHERE tp.auditstatus =1 AND tp.linestatus =1 '

 


IF(@brandid>0)
begin
	SET @str =@str + ' and tp.brandid = ' + CONVERT(varchar,@brandid)
	SET @strB =@strB + ' and tp.brandid = ' + CONVERT(varchar,@brandid)
end 
IF(@Promotion>0)
begin
	SET @str =@str + ' and tpb.ProductAttributePromotion = ' + CONVERT(varchar,@Promotion)
	SET @strB =@strB + ' and tpb.ProductAttributePromotion = ' + CONVERT(varchar,@Promotion)
end 
IF(@categoryid>0)
begin
	SET @str =@str + ' and tp.categoryid  =' + CONVERT(varchar,@categoryid)
	SET @strB =@strB + ' and tp.categoryid  =' + CONVERT(varchar,@categoryid)
end 
IF(@brandsid>0)
begin
	SET @str =@str + ' and tp.brandsid  =' + CONVERT(varchar,@brandsid)
	SET @strB =@strB + ' and tp.brandsid  =' + CONVERT(varchar,@brandsid)
end 
IF(@brandsid>0)
begin
	SET @str =@str + ' and tp.brandsid  =' + CONVERT(varchar,@brandsid)
	SET @strB =@strB + ' and tp.brandsid  =' + CONVERT(varchar,@brandsid)
end 
IF(convert(INT, @stylevalue)>0)
begin
	SET @str =@str + ' and tp.stylevalue  = ''' +@stylevalue+ '''' 
	SET @strB =@strB + ' and tp.stylevalue  = ''' +@stylevalue+ ''''
end 
IF(convert(INT, @colorvalue)>0)
begin
	SET @str =@str + ' and tp.colorvalue  = ''' +@colorvalue+ ''''  
	SET @strB =@strB + ' and tp.colorvalue  = ''' +@colorvalue+ ''''
end 
IF(convert(INT, @materialvalue)>0)
begin
	SET @str =@str + ' and tp.materialvalue  = ''' +@materialvalue+ ''''  
	SET @strB =@strB + ' and tp.materialvalue  = ''' +@materialvalue+ ''''  
end 
IF(LEN(@dlid)>0) 
begin
	SET @str = @str +  ' and tpb.typevalue = ' + CONVERT(VARCHAR,@dlid)
	SET @strB = @strB +  ' and tpb.typevalue = ' + CONVERT(VARCHAR,@dlid)
end 
IF(@bid>0)
begin
	SET @str = @str + '  and tp.categoryid in (SELECT id  FROM dbo.t_productcategory WHERE parentid = '+CONVERT(VARCHAR,@bid)+' AND ptype<>2 ) '
	SET @strB = @strB + '  and tp.categoryid in (SELECT id  FROM dbo.t_productcategory WHERE parentid = '+CONVERT(VARCHAR,@bid)+' AND ptype<>2 ) '
end 
IF(LEN(@key)>0) 
begin
	SET @str = @str + '  and (tp.title  like ''%' +@key+ '%'' or tp.companyname   like ''%' +@key+ '%''  or tp.colorname   like ''%' +@key+ '%''   or tp.materialname   like ''%' +@key+ '%''  or tp.brandstitle   like ''%' +@key+ '%''  or tp.brandtitle   like ''%' +@key+ '%'' or tp.categorytitle   like ''%' +@key+ '%'' ) '
	SET @strB = @strB + '  and (tp.title  like ''%' +@key+ '%'' or tp.companyname   like ''%' +@key+ '%''  or tp.colorname   like ''%' +@key+ '%''   or tp.materialname   like ''%' +@key+ '%''  or tp.brandstitle   like ''%' +@key+ '%''  or tp.brandtitle   like ''%' +@key+ '%'' or tp.categorytitle   like ''%' +@key+ '%'' ) '
end 	
IF(@marketid >0 )
BEGIN
	SET @str= @str+ ' and tp.brandid in ( SELECT brandid FROM dbo.t_shopbrand WHERE shopid IN (SELECT shopid FROM dbo.t_marketstoreyshop where t_marketstoreyshop.marketid = '  +CONVERT(VARCHAR,@marketid)+  ' ) ) '
	SET @strB= @strB+ ' and tp.brandid in ( SELECT brandid FROM dbo.t_shopbrand WHERE shopid IN (SELECT shopid FROM dbo.t_marketstoreyshop where t_marketstoreyshop.marketid = '  +CONVERT(VARCHAR,@marketid)+  ' ) ) '
END

set @str= 'SELECT * FROM
(SELECT row_number() OVER (ORDER BY (tp.lastedittime) desc) AS rownum,
' +@str + ') AS T WHERE rownum BETWEEN ('
+ convert(varchar,@pageindex) +
' - 1) * '+convert(varchar(10),@pagesize)+' + 1 AND '+
convert(varchar,@pageindex)+' * '+convert(varchar,@pagesize)

--返回分页记录内容

EXEC (@str)
PRINT(@str)
--符合条件的总记录数
EXEC (@strB) 