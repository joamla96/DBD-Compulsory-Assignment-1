USE Company;
GO
CREATE PROCEDURE usp_GetDepartment
	@DNumber varchar(50)
	AS BEGIN

	SET NOCOUNT ON;

	IF(NOT EXISTS (SELECT * FROM Department 
				WHERE DNumber = @DNumber))
		BEGIN
			RAISERROR('Department does not exists', 16, 1);
		END
		
		SELECT 
		Department.*,		
		count(Employee.Dno) as numberOfEmployee       
		from Department
		left join Employee
		on (Department.DNumber = Employee.Dno)
		where DNumber = @DNumber
		group by
			Department.DName,
			Department.DNumber,
			Department.MgrSSN,
			Department.MgrStartDate
		
END