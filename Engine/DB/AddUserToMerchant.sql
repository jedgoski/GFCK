USE [GFCK]
GO
/****** Object:  StoredProcedure [dbo].[AddMerchant]    Script Date: 11/08/2011 22:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUserToMerchant]
@UserID UniqueIdentifier,
@MerchantID BigInt			
AS

Insert Into dbo.UsersInMerchant (UserID, MerchantID)
Values(@UserID, @MerchantID)