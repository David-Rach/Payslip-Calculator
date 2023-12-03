using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Payslip_Calculator.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Payslip_Calculator.Pages
{
    public class PaySlipDetailsModel : PageModel
    {

        [BindProperty]
        public EmployeeModel FormValues { get; set; } = null!;
        public PaySlipModel? PayslipInfo { get; set; }


        public void OnGet()
        {

        }

        public IActionResult? OnPost()
        {
            if (ModelState.IsValid)
            {
                var taxRates = new decimal[] { 0.105M, 0.175M, 0.3M, 0.33M, 0.39M };

                var remaingUntaxedSalary = FormValues.AnnualSalary;
                var taxedSalary = 0M;
                foreach (var taxRate in taxRates)
                {
                    switch (taxRate)
                    {
                        case 0.105M:
                            {
                                var deduction = remaingUntaxedSalary >= 14000 ? 14000 : remaingUntaxedSalary;
                                remaingUntaxedSalary -= deduction;
                                taxedSalary += deduction * taxRate;
                                break;
                            }
                        case 0.175M:
                            {
                                var deduction = remaingUntaxedSalary >= 34000 ? 34000 : remaingUntaxedSalary;
                                remaingUntaxedSalary -= deduction;
                                taxedSalary += deduction * taxRate;
                                break;
                            }
                        case 0.3M:
                            {
                                var deduction = remaingUntaxedSalary >= 22000 ? 22000 : remaingUntaxedSalary;
                                remaingUntaxedSalary -= deduction;
                                taxedSalary += deduction * taxRate;
                                break;
                            }
                        case 0.33M:
                            {
                                var deduction = remaingUntaxedSalary >= 110000 ? 110000 : remaingUntaxedSalary;
                                remaingUntaxedSalary -= deduction;
                                taxedSalary += deduction * taxRate;
                                break;
                            }
                        default:
                            {
                                taxedSalary += remaingUntaxedSalary * taxRate;
                                taxedSalary /= 12;
                                remaingUntaxedSalary = 0;
                                break;
                            }
                    }
                }


                var grossIncome = FormValues.AnnualSalary / 12;
                PayslipInfo = new PaySlipModel()
                {
                    Name = $"{FormValues.FirstName} {FormValues.LastName}",
                    GrossIncome = Math.Round(grossIncome, 2),
                    IncomeTax = Math.Round(taxedSalary, 2),
                    NetIncome = Math.Round(grossIncome - taxedSalary, 2),
                    Super = Math.Round(grossIncome * ((decimal)FormValues.SuperRate / 100M), 2, MidpointRounding.ToPositiveInfinity),
                    PayPeriod = FormValues.PayPeriod
                };

                return Page();
            }

            //Errors
            return null;

        }
    }
}
