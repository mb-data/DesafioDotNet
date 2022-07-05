USE [khipo]
GO
/****** Object:  StoredProcedure [dbo].[ExcluirProdutoPorId]    Script Date: 04/07/2022 09:20:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* PROCEDURE PARA EXCLUIR UM REGISTRO*/
ALTER PROCEDURE [dbo].[ExcluirProdutoPorId]
(
	@ProductId int
)

AS
BEGIN
	DELETE FROM [dbo].[Product]
      WHERE productId = @ProductId
END 