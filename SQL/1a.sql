USE Company;
GO
CREATE PROCEDURE usp_CreateDepartment
	@Dname varchar(50),
	@MgrSSN numeric(9,0),
	@Dnum int OUTPUT
	AS BEGIN

	SET NOCOUNT ON;

	IF((SELECT Count(*) FROM Department WHERE DName = @Dname) > 0)
		BEGIN
			RAISERROR('Department with name already exists', 16, 1);
		END

	IF((SELECT Count(*) FROM Department WHERE MgrSSN = @MgrSSN) > 0)
		BEGIN
			RAISERROR('This Employee is already managing a department', 16, 1);
		END

		-- Because this is a stored procedure, we dont need to rollback, because raiserrror terminates

		INSERT INTO Department (DName, MgrSSN, MgrStartDate) VALUES(@DName, @MgrSSN, GETDATE());

		SELECT @Dnum = SCOPE_IDENTITY();
	END