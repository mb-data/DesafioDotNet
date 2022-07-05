USE [khipo]
GO
/****** Object:  StoredProcedure [dbo].[AtualizarProdutoPorId]    Script Date: 04/07/2022 09:20:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* PROCEDURE PARA ATUALIZAR UM REGISTRO*/
ALTER PROCEDURE [dbo].[AtualizarProdutoPorId]
(
	@ProductId int,
	@Name nvarchar(100),
	@Price FLOAT, 
	@Brand nvarchar(50)
)
AS

BEGIN
	UPDATE [dbo].[Product]
   SET [Name] = @Name
      ,[Price] = @price
      ,[Brand] = @Brand
      ,[UpdatedAt] = GETDATE()
 WHERE productid = @ProductId
END