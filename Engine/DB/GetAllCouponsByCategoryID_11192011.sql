USE [GFCK]
GO
/****** Object:  StoredProcedure [dbo].[GetAllCouponsByCategoryID]    Script Date: 11/19/2011 14:59:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[GetAllCouponsByCategoryID]
@CategoryID int = null,
@caseinFree bit = null,
@soyFree bit = null,
@cornFree bit = null,
@eggFree bit = null,
@nutFree bit = null,
@yeastFree bit = null
			
AS

Select mc.ID, 
		mc.MerchantID, 
		mc.TemplateID, 
		mc.CategoryID,
		c.Name As CategoryName, 
		mc.Image, 
		mc.Value, 
		mc.Discount, 
		mc.Details, 
		mc.Terms, 
		mc.StartDate, 
		mc.ExpirationDate, 
		mc.GlutenFreeFacility, 
		mc.ContainGluten20PPM, 
		mc.LessThan5PPM, 
		mc.CaseinFree, 
		mc.SoyFree, 
		mc.NutFree, 
		mc.EggFree, 
		mc.CornFree, 
		mc.YeastFree, 
		mc.Barcode1Type,
		mc.Barcode1Value, 
		mc.Barcode2Type, 
		mc.Barcode2Value, 
		mc.NumberOfCoupons, 
		mc.BottomAdvertisement, 
		mc.CreatedDate, 
		mc.UpdatedDate, 
		mc.Enabled,
		mc.Name,
		(select COUNT(id) from CouponPrint where CouponID = mc.ID) as 'prints'
From dbo.MerchantCoupon mc
Join dbo.Category c on c.ID = mc.CategoryID
Where ((@CategoryID is null) or (mc.CategoryID = @CategoryID))
and mc.ExpirationDate >= GETDATE()
and mc.Enabled = 1
and ((@caseinFree is null) or (@caseinFree = mc.CaseinFree))
and ((@soyFree is null) or (@soyFree = mc.SoyFree))
and ((@cornFree is null) or (@cornFree = mc.CornFree))
and ((@eggFree is null) or (@eggFree = mc.EggFree))
and ((@nutFree is null) or (@nutFree = mc.NutFree))
and ((@yeastFree is null) or (@yeastFree = mc.YeastFree))