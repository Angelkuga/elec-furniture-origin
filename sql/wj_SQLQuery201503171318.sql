 
 ALTER PROC [dbo].[proc_brandsearch]
 @fg int,--风格
 @cz int,--材质
 @mc int,--卖场
 @key varchar(50),--关键词
 @pageindex int,--当前页
 @pagesize int,--每页数量
 @pagecount int--页数
 AS
 
 DECLARE @str VARCHAR (5000)
 DECLARE @strB VARCHAR(8000)
 SET @str = ''
 SET @strB=''
 SET @str =' dbo.t_brand.id , dbo.t_brand.companyid,dbo.t_brand.title, CONVERT(VARCHAR(max),isnull(dbo.t_brand.descript,'''')  )  AS descript,
 dbo.t_brand.thumb,dbo.t_brand.bannel ,
isnull( fg.title,'''' ) AS fgtitle,isnull(cz.title,'''') AS cztitle,dbo.t_brand.logo
 FROM t_Brand 
 LEFT JOIN t_config fg ON  fg.value =  dbo.t_brand.style AND fg.type=3 AND fg.module =103
 LEFT JOIN t_config cz ON  cz.value =  dbo.t_brand.material AND cz.type=4 AND cz.module =103 
 where dbo.t_brand.linestatus =1 AND dbo.t_brand.auditstatus=1  '
 
  SET @strB ='SELECT count(0)
 FROM t_Brand 
 LEFT JOIN t_config fg ON  fg.value =  dbo.t_brand.style AND fg.type=3 AND fg.module =103
 LEFT JOIN t_config cz ON  cz.value =  dbo.t_brand.material AND cz.type=4 AND cz.module =103 
 where dbo.t_brand.linestatus =1 AND dbo.t_brand.auditstatus=1  '
   
IF(@fg>0)
begin
	SET @str = @str + ' and t_brand.style ='  + CONVERT(VARCHAR, @fg )
	SET @strB = @strB + ' and t_brand.style ='  + CONVERT(VARCHAR, @fg )
end
IF(@cz>0)
begin
	SET @str = @str + ' and t_brand.material ='+ CONVERT(VARCHAR, @cz )
	SET @strB = @strB + ' and t_brand.material ='+ CONVERT(VARCHAR, @cz )
end
IF(@mc>0)
begin
	SET @str = @str + ' AND t_brand.id in (select brandid from t_shopbrand where shopid in (select shopid from t_marketstoreyshop where marketid='+ CONVERT(VARCHAR,@mc)+'))'
	SET @strB = @strB + ' AND t_brand.id in (select brandid from t_shopbrand where shopid in (select shopid from t_marketstoreyshop where marketid='+ CONVERT(VARCHAR,@mc)+'))'
end 
IF(LEN(@key) >0) 
begin
	SET @str = @str + ' AND t_brand.title like ''%' +@key+ '%''  '
	SET @strB = @strB + ' AND t_brand.title like ''%' +@key+ '%''  '
end

set @str= 'SELECT * FROM
(SELECT row_number() OVER (ORDER BY (t_brand.lastedittime) desc) AS rownum,
' +@str + ') AS T WHERE rownum BETWEEN ('
+ convert(varchar,@pageindex) +
' - 1) * '+convert(varchar(10),@pagesize)+' + 1 AND '+
convert(varchar,@pageindex)+' * '+convert(varchar,@pagesize)

EXEC (@str	)
PRINT (@str) 
EXEC (@strB) 
