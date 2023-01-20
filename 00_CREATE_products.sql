if DB_ID ('TesteDiego_db') is null
begin
	create database [TesteDiego_db]
	print 'database TesteDiego_db create!'
end
else
begin
	print 'database TesteDiego_db already exists!'
end

go

----------------------------------------------------------
use TesteDiego_db
go

if not exists ( select 1
				from sys.objects
				where name = 'Product')
begin
	create table Product ( productId		int	identity(1,1)				,
						   name				varchar(100)		null		,
						   price			money				null		,
						   brand			varchar(100)		null		,
						   createDate		datetime			not null	,
						   updateDate		datetime 			null		,
							
							constraint [Product_PK] primary key (productId)	)	
							
	print 'table Product create!'
end
else
begin
	print 'table Product already exists!'
end

