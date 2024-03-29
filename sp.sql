CREATE OR ALTER Procedure [dbo].[CRUD_Student]
	@id int = 0,
	@name Varchar(100) = '',
	@emailId Varchar(100) = '',
	@password Varchar(max) = '',
	@mobile bigint = 0,
	@image varchar(500)= 'default.jpg',
	@query int
AS
	IF(@query = 1)
	BEGIN
		SELECT * FROM Student WHERE IsDeleted = 0 ORDER BY Id DESC;
	END

	ELSE IF(@query = 2)
	BEGIN
		UPDATE Student SET IsDeleted = 1, UpdatedAt = GETDATE() WHERE Id = @id AND IsDeleted = 0
	END

	ELSE IF(@query = 3)
	BEGIN
		INSERT INTO Student(Name, EmailId, Password, Mobile, image) VALUES(@name, @emailId, @password, @mobile, @image)

		RETURN SCOPE_IDENTITY()
	END

	ELSE IF(@query = 4)
	BEGIN
		SELECT * FROM Student WHERE id = @id AND IsDeleted = 0
	END

	ELSE IF(@query = 5)
	BEGIN
		UPDATE Student SET Name = @name, Password = @password, Mobile = @mobile, Image = @image, UpdatedAt = GETDATE() WHERE id = @id AND IsDeleted = 0
		
		RETURN SCOPE_IDENTITY()
	END

	