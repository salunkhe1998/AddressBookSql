use Addressbook
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE or ALTER PROCEDURE InsertContact 
	@FirstName varchar(50),
	@LastName varchar(50),
	@Address varchar(100),
	@City varchar(25),
	@State varchar(25),
	@ZipCode varchar(6),
	@PhoneNumber varchar(10),
	@Email varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	insert into Family(FirstName,LastName,Address,City,State,ZipCode,PhoneNumber,Email) values (@FirstName,@LastName,@Address,@City,@State,@ZipCode,@PhoneNumber,@Email)
END
GO
