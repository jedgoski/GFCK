USE [GFCK]
GO
/****** Object:  StoredProcedure [dbo].[GetAllCouponsByCategoryID]    Script Date: 11/09/2011 21:30:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[GetAllCouponsByCategoryID]
@CategoryID int
			
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
Where mc.CategoryID = @CategoryID
and mc.ExpirationDate >= GETDATE()
and mc.Enabled = 1