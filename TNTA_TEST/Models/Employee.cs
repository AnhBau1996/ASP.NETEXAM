namespace TNTA_TEST.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public string Rank { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
