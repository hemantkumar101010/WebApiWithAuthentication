namespace AuthProvider.ApiModel
{
    public class EmployeeApiModel
    {
        public int EmpId { get; set; }
        public string? EmpName { get; set; }
        public string? EmpPhone { get; set; }
        public string? EmpAddress { get; set; }
        public string EmpEmail { get; set; }
        public string Password { get; set; }
        public  RoleType Role { get; set; }


    }

     public enum RoleType
    {
        Admin = 1,
        Viewer,
        SalesMan
    }
}
