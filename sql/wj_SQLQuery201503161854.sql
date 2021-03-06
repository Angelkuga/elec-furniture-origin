 ALTER PROC [dbo].[proc_RecommendProduct]
 @count int,
 @ProductAttributePromotion INT,
 @did INT,
 @xid INT
AS
DECLARE @str VARCHAR(8000)
	IF(@xid=-1)
		SET @xid = 8;

 SET @str=' SELECT top '+convert(varchar,@count)+' '',''+t_product.attribute+'','' as attribute ,t_product.title,dbo.t_product.id,t_product.sku,t_product.thumb,ProductAttributePromotion ,buyprice,markprice,saleprice 
  ,t_brand.title AS brandtitle 
  FROM dbo.t_product 
  INNER JOIN dbo.t_productattribute ON t_productattribute.productid = t_product.id 
  INNER JOIN dbo.t_brand ON t_brand.id = t_product.brandid 
  INNER JOIN dbo.t_productcategory pc ON pc.id = dbo.t_product.categoryid 
  WHERE dbo.t_product.linestatus =1 AND dbo.t_product.auditstatus =1 
  AND LEN(t_product.attribute)>0 '
  
  IF(@xid>0)
begin
	SET @str =@str + ' and t_product.categoryid  =' + CONVERT(varchar,@xid) 
end 
  IF(@did>0)
begin
	SET @str = @str + '  and t_product.categoryid in (SELECT id  FROM dbo.t_productcategory WHERE parentid = '+CONVERT(VARCHAR,@did)+' AND ptype<>2 ) '
end 
  EXEC (@str)
  PRINT(@str)
