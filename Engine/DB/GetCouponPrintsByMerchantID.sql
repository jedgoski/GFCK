USE [GFCK]
GO
/****** Object:  StoredProcedure [dbo].[GetCouponPrintsByMerchantID]    Script Date: 11/08/2011 23:05:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].GetCouponPrintsByMerchantID
@MerchantID BigInt,
@StartDate Date = null,
@EndDate Date = null
			
AS

Select 
	CouponID, Name, COUNT(cp.ID) as 'total'
from 
	CouponPrint cp
	left join MerchantCoupon mc on cp.CouponID = mc.ID
where 
	mc.MerchantID = @MerchantID
	and ((@StartDate is null) or (@StartDate <= cp.PrintedDate))
	and ((@EndDate is null) or (@EndDate >= cp.PrintedDate))
group by
	CouponID, Name

