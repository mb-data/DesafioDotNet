USE [khipo]
GO
/****** Object:  StoredProcedure [dbo].[ObterTodosProduto]    Script Date: 04/07/2022 09:19:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* PROCEDURE PARA PESQUISAR TODOS REGISTRO*/
ALTER PROCEDURE [dbo].[ObterTodosProduto]
AS
BEGIN
	SELECT [productId]
      ,[Name]
      ,[Price]
      ,[Brand]
      ,[CreatedAt]
      ,[UpdatedAt]
  FROM [dbo].[Product]

END