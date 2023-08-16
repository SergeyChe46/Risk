namespace Risk.Entities.ViewModels
{
    public class EmployeeDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        //public string Position { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public required Guid CompanyId { get; set; }
    }
}
