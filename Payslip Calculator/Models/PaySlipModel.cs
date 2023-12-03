namespace Payslip_Calculator.Models
{
    public class PaySlipModel
    {
        public required string Name { get; set; }
        public required string PayPeriod { get; set; }
        public decimal GrossIncome { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal NetIncome { get; set; }
        public decimal Super { get; set; }
    }
}
