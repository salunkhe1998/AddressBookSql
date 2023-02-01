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
	
	if (@LastName!='N/C' and @LastName!='')
		begin
			update Family set LastName = @LastName where FirstName = @OriginalFirstName
		end
	if (@Address!='N/C' and @Address!='')
		begin
			update Family set Address = @Address where FirstName = @OriginalFirstName
		end
	if (@City!='N/C' and @City!='')
		begin
			update Family set City = @City where FirstName = @OriginalFirstName
		end
	if (@State!='N/C' and @State!='')
		begin
			update Family set State = @State where FirstName = @OriginalFirstName
		end
	if (@ZipCode!='N/C' and @ZipCode!='')
		begin
			update Family set ZipCode = @ZipCode where FirstName = @OriginalFirstName
		end
	if (@PhoneNumber!='N/C' and @PhoneNumber!='')
		begin
			update Family set PhoneNumber = @PhoneNumber where FirstName = @OriginalFirstName
		end
	if (@Email!='N/C' and @Email!='')
		begin
			update Family set Email = @Email where FirstName = @OriginalFirstName
		end
	if (@FirstName!='N/C')
		begin
			update Family set FirstName = @FirstName where FirstName = @OriginalFirstName
		end

END
GO
