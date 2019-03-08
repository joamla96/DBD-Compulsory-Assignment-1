USE Company;
GO
CREATE PROCEDURE usp_GetAllDepartments 
	AS BEGIN

	SET NOCOUNT ON;

	SELECT 
		Department.*,		
		count(Employee.Dno) as numberOfEmployee       
	from Department
	left join Employee
	on (Department.DNumber = Employee.Dno)
	group by
		Department.DName,
		Department.DNumber,
		Department.MgrSSN,
		Department.MgrStartDate
	
END