USE [khipo]
GO
/****** Object:  StoredProcedure [dbo].[ObterProdutoPorId]    Script Date: 04/07/2022 09:20:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* PROCEDURE PARA OBTER UM REGISTRO POR ID*/
ALTER PROCEDURE [dbo].[ObterProdutoPorId]
(
	@ProductId int
)
AS
BEGIN
	SELECT [productId]
      ,[Name]
      ,[Price]
      ,[Brand]
      ,[CreatedAt]
      ,[UpdatedAt]
  FROM [dbo].[Product]
  WHERE productId = @ProductId
END