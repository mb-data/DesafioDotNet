use TesteDiego_db
go

create or alter procedure pr_Product_sel  
					@productId   int = null    
as    
begin
set nocount on  
/****************************************************************
By: Diego Garcia
Date: 19/02/2023
Desc: proc de sel na tabela product

exec pr_product_sel @productId = 2

*****************************************************************
Alter 
Date:
Desc: 

*****************************************************************/	
	select productId	,	
		   name			,
		   price		,	
		   brand		,	
		   createDate	,	
		   updateDate		
	from product
	where productId = isnull(@productId, productId)     

end
go
sp_recompile [pr_Product_sel]
go
