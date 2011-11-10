USE [GFCK]
GO
/****** Object:  StoredProcedure [dbo].[UpdateCoupon]    Script Date: 11/09/2011 23:02:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Procedure [dbo].[UpdateCoupon]
@CouponID BigInt,
@MerchantID BigInt,
@TemplateID BigInt,
@CategoryID int,
@Image nvarchar (100) = null,
@Value nVarChar (50),
@Discount nVarChar (50),
@Details ntext,
@Terms ntext,
@StartDate DateTime,
@ExpirationDate DateTime,
@GlutenFreeFacility Bit,
@ContainGluten20PPM Bit,
@LessThan5PPM Bit,
@CaseinFree Bit,
@SoyFree Bit,
@NutFree Bit,
@EggFree Bit,
@CornFree Bit,
@YeastFree Bit,
@Barcode1Type nvarchar(50),
@Barcode1Value nVarChar (50),
@Barcode2Type nvarchar(50),
@Barcode2Value VarChar (50),
@NumberOfCoupons Int,
@BottomAdvertisement nVarChar (255),
@Enabled Bit,
@Name nvarchar(100)

AS

Update dbo.MerchantCoupon
Set MerchantID = @MerchantID,
TemplateID = @TemplateID,
CategoryID = @CategoryID,
Value = @Value,
Discount = @Discount,
Details = @Details,
Terms = @Terms,
StartDate = @StartDate,
ExpirationDate = @ExpirationDate,
GlutenFreeFacility = @GlutenFreeFacility,
ContainGluten20PPM = @ContainGluten20PPM,
LessThan5PPM = @LessThan5PPM,
CaseinFree = @CaseinFree,
SoyFree = @SoyFree,
NutFree = @NutFree,
EggFree = @EggFree,
CornFree = @CornFree,
YeastFree = @YeastFree,
Barcode1Type = @Barcode1Type,
Barcode1Value = @Barcode1Value,
Barcode2Type = @Barcode2Type,
Barcode2Value = @Barcode2Value,
NumberOfCoupons = @NumberOfCoupons,
BottomAdvertisement = @BottomAdvertisement,
UpdatedDate = GetDate(),
Enabled = @Enabled,
Name = @Name
Where ID = @CouponID

if not @Image is null
begin
Update dbo.MerchantCoupon
set Image = @Image,
UpdatedDate = GetDate()
Where ID = @CouponID
end