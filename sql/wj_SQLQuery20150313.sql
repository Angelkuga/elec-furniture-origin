 
--首页淘宝贝加后台控制首页置顶
ALTER proc [dbo].[proc_tbbinfo]
@did INT,--大类id
@xid INT--小类id
as
SELECT t_product.categoryid ,t_productcategory.id as xid,t_productcategory.title as xtitle,b.id as did ,b.title as dtitle
FROM t_product 
INNER JOIN t_productattribute ON t_productattribute.productid = t_product.id 
INNER JOIN t_promotionstype ON t_promotionstype.id =ProductAttributePromotion
INNER JOIN t_productcategory ON t_productcategory.id = t_product.categoryid 
INNER JOIN t_productcategory AS b ON b.id	 = t_productcategory.parentid 
WHERE t_promotionstype.title='淘宝贝'
 and t_product.auditstatus =1 and t_product.linestatus=1 
group by t_product.categoryid ,t_productcategory.title ,b.title ,b.id  ,t_productcategory.id ,b.sort,t_productcategory.sort
order by b.sort,t_productcategory.sort asc
 

--查询所有淘宝贝数据,给"换一批"使用 
--order by t_product.id desc
DECLARE @str VARCHAR(5000)
SET @str = '

SELECT  materialname, (ISNULL(t_brand.title,'''') +'' '' + t_productcategory.title +'' ''  +ISNULL(t_product.sku,'''') +'' '' +materialname) AS ptitle,t_brand.id as brandid,t_product.title as ptitle2,storage, t_brand.logo , buyprice,markprice,saleprice, t_product.thumb,t_product.id as proid,t_product.id ,
t_productcategory.title as xtitle,b.title as dtitle ,b.id as did,t_productcategory.id as xid  , ROW_NUMBER() over(partition by  b.title  order by NEWID() desc) as rowNum 
FROM t_product 
INNER JOIN t_productattribute ON t_productattribute.productid = t_product.id 
INNER JOIN t_promotionstype ON t_promotionstype.id =ProductAttributePromotion
INNER JOIN t_productcategory ON t_productcategory.id = t_product.categoryid 
INNER JOIN t_productcategory AS b ON b.id	 = t_productcategory.parentid 
inner join t_brand on t_brand.id = t_product.brandid
WHERE t_product.linestatus=1 and t_product.auditstatus=1 and  t_promotionstype.title=''淘宝贝'' and '',''+t_product.attribute+'','' like ''%,101,%'' ' 

IF(@did<>0)
  SET @str = @str + ' AND b.id = '+CONVERT(VARCHAR,@did) 
IF(@xid <> 0)
 SET @str = @str  +'  and t_productcategory.id = ' +CONVERT(VARCHAR,@xid) 

SET @str = ' SELECT * FROM ( ' + @str + ' ) a WHERE a.rowNum<=12 ORDER BY a.proid DESC  ' 

EXEC (@str)
go
 