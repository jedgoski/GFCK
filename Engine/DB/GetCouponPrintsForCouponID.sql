USE [GFCK]
GO
/****** Object:  StoredProcedure [dbo].[GetCouponPrintsForCouponID]    Script Date: 11/17/2011 21:07:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetCouponPrintsForCouponID]
@CouponID BigInt
			
AS

Select ID, CouponID, PrintedDate, IPAddress
From dbo.CouponPrint
Where CouponID = @CouponID
		
