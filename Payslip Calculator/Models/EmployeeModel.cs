namespace Payslip_Calculator.Models
{
    public class EmployeeModel
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required decimal AnnualSalary { get; set; }
        public required uint SuperRate { get; set; }
        public required string PayPeriod { get; set; }
    }
}
