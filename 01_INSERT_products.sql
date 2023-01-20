use TesteDiego_db
go

if not exists (select 1 from product)
begin
	insert into product (name, price, brand, createDate, updateDate)	
		values ('Incredible Plastic Pants'	,'827.00' ,'Hauck - Johnson'			,getdate() ,null),
			   ('Electronic Wooden Tuna'	,'765.00' ,'Johns - Farrell'			,getdate() ,null),
			   ('Awesome Steel Mouse'		,'143.00' ,'Paucek, Kuvalis and Zieme'	,getdate() ,null)

	print 'First insert in table product Done!'
end
else
begin
	print 'First insert already done!'
end
			