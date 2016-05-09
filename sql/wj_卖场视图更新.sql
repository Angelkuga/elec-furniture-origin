USE [JiaJuKSN]
GO

/****** Object:  View [dbo].[v_marketlist]    Script Date: 02/15/2015 14:50:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[v_marketlist]
AS
SELECT     (SELECT     count(1)
                       FROM          t_marketstoreyshop
                       WHERE      marketid = m.id) AS shopcount,
                          (SELECT     isnull(id, 0) AS id, isnull(title, '') AS title, isnull(thumb, '') AS thumb, isnull(mapapi, '') AS map, isnull(linkman, '') AS linkman, isnull(phone, 
                                                   '') AS phone, isnull(areacode, '') AS areacode, isnull(address, '') AS address, isnull
                                                       ((SELECT     id
                                                           FROM         t_brand
                                                           WHERE     id =
                                                                                     (SELECT     TOP 1 brandid
                                                                                       FROM          t_shopbrand
                                                                                       WHERE      shopid = s.id)), 0) AS brandid, isnull
                                                       ((SELECT     letter
                                                           FROM         t_brand
                                                           WHERE     id =
                                                                                     (SELECT     TOP 1 brandid
                                                                                       FROM          t_shopbrand
                                                                                       WHERE      shopid = s.id)), '') AS brandletter, isnull
                                                       ((SELECT     descript
                                                           FROM         t_brand
                                                           WHERE     id =
                                                                                     (SELECT     TOP 1 brandid
                                                                                       FROM          t_shopbrand
                                                                                       WHERE      shopid = s.id)), '') AS branddescript, isnull
                                                       ((SELECT     t_brand.thumb
                                                           FROM         t_brand
                                                           WHERE     id =
                                                                                     (SELECT     TOP 1 brandid
                                                                                       FROM          t_shopbrand
                                                                                       WHERE      shopid = s.id)), '') AS brandthumb, isnull
                                                          ((SELECT     title
                                                           FROM         t_config
                                                           WHERE     module = 103 AND type = 4 AND value = 
                                                          (SELECT  top 1   material
                                                           FROM         t_brands
                                                           WHERE     id =
                                                                                     (SELECT     TOP 1 brandid
                                                                                       FROM          t_shopbrand
                                                                                       WHERE      shopid = s.id))), '') AS brandmaterial , isnull
                                                                                       ((SELECT     logo
                                                           FROM         t_brand
                                                           WHERE     id =
                                                                                     (SELECT     TOP 1 brandid
                                                                                       FROM          t_shopbrand
                                                                                       WHERE      shopid = s.id)), '') AS brandlogo, isnull
                                                       ((SELECT     title
                                                           FROM         t_brand
                                                           WHERE     id =
                                                                                     (SELECT     TOP 1 brandid
                                                                                       FROM          t_shopbrand
                                                                                       WHERE      shopid = s.id)), '') AS brandtitle, isnull
                                                       ((SELECT     title
                                                           FROM         t_config
                                                           WHERE     module = 103 AND type = 3 AND value =
                                                                                     (SELECT     style
                                                                                       FROM          t_brand
                                                                                       WHERE      id =
                                                                                                                  (SELECT     TOP 1 brandid
                                                                                                                    FROM          t_shopbrand
                                                                                                                    WHERE      shopid = s.id))), '') AS brandstylename, isnull
                                                       ((SELECT     storeytitle
                                                           FROM         t_marketstoreyshop
                                                           WHERE     shopid = s.id AND marketid = m.id), '') AS marketstorey, isnull
                                                       ((SELECT     position
                                                           FROM         t_marketstoreyshop
                                                           WHERE     shopid = s.id AND marketid = m.id), '') AS position
                            FROM          t_shop s
                            WHERE      id IN
                                                       (SELECT     shopid
                                                         FROM          t_marketstoreyshop
                                                         WHERE      marketid = m.id) FOR xml path('type')) AS shopxml,
                          (SELECT     TOP 12 t1.id, t1.title, t1.logo, t1.companyid,
                                                       (SELECT     TOP 1 storeytitle
                                                         FROM          t_marketstoreyshop ms2
                                                         WHERE      ms2.shopid =
                                                                                    (SELECT     TOP 1 s3.shopid
                                                                                      FROM          t_shopbrand s3
                                                                                      WHERE      brandid = t1.id)) AS storeytitle
                            FROM          t_brand t1
                            WHERE      t1.auditstatus = 1 AND t1.linestatus = 1 AND t1.id IN
                                                       (SELECT     brandid
                                                         FROM          t_shopbrand s2
                                                         WHERE      s2.shopid IN
                                                                                    (SELECT     shopid
                                                                                      FROM          t_marketstoreyshop ms1
                                                                                      WHERE      ms1.marketid = m.id AND isrecommend = 1)) FOR xml path('type')) AS brandxml, isnull
                          ((SELECT     id, title, number, surface, logo, thumb, bannel, desimage, descript
                              FROM         t_marketstorey
                              WHERE     marketid = m.id FOR xml path('type')), '') AS marketstoreyxml, m.*
FROM         t_market m
WHERE     m.linestatus = 1


GO


