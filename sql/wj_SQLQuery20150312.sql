 --北欧至尊 补产品系列id
 update t_product 
 set brandsid = t_brands.id 
 -- select t_product.brandsid,t_brands.id ,t_product.brandstitle,t_brands.title
 from t_product,t_brands 
where t_product.companyid=204 and t_product.brandstitle=t_brands.title



--产品上首页图片 后台设置
alter table  dbo.t_product add homepageimg varchar(100)



 --制定公司 补产品系列id
 update t_product 
 set brandsid = t_brands.id  
 from t_product,t_brands 
where t_product.companyid=231 and t_product.brandstitle=t_brands.title

--补产品属性颜色数据
 update [dbo].[t_productattribute]
 set productcolorvalue=a.value  
 -- select   productcolorvalue,a.value , productcolortitle
 from [t_productattribute],
 ( select title,value from t_config where module=103 and type=12) as a
 where [t_productattribute].productcolortitle=a.title  and ( [t_productattribute].productcolorvalue is null
 or  [t_productattribute].productcolorvalue='')

 -- 从系列不材质风格到品牌
update t_brand
set t_brand.material=t_brands.material,t_brand.style=t_brands.style
--select t_brand.material,t_brand.style,t_brands.material,t_brands.style 
from t_brand,t_brands  
 where t_brand.id = t_brands.brandid and
   t_brand.material is null or t_brand.material=''
   
  --重复广告位 
 select title,MAX(id),MIN(id) from t_advertisingcategory 
group by title having COUNT(0)>1
  
 
 update t_product 
 set brandsid = t_brands.id  
 from t_product,t_brands 
where t_product.companyid=210 and t_product.brandstitle=t_brands.title


 update t_product 
 set brandsid = t_brands.id  
 from t_product,t_brands 
where t_product.companyid=196 and t_product.brandstitle=t_brands.title


 update t_product 
 set brandsid = t_brands.id  
 from t_product,t_brands 
where t_product.companyid=80 and t_product.brandstitle=t_brands.title



 update t_product 
 set brandsid = t_brands.id  
 from t_product,t_brands 
where t_product.companyid=162 and t_product.brandstitle=t_brands.title


 update t_product 
 set brandsid = t_brands.id  
 from t_product,t_brands 
where t_product.companyid=159   and t_product.brandstitle=t_brands.title


 update t_product 
 set brandsid = t_brands.id  
 from t_product,t_brands 
where t_product.companyid=174 and t_product.brandstitle=t_brands.title