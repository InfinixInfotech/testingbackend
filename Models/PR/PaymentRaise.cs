using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.PR
{
    public class PaymentRaise
    {
        public int Id {  get; set; }
        public string apiType { get; set; }
        public string accessType { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string PrId { get; set; }
        public ClientDetails ClientDetails { get; set; }
        public ProductDetails ProductDetails { get; set; }
        public PaymentDetails PaymentDetails { get; set; }
        public string TransactionReceipt { get; set; }
        public int PaymentStatus { get; set; }
    }
}
public class ClientDetails
{
    public string Name { get; set; }
    public string FatherName { get; set; }
    public string MotherName { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }
    public string Dob { get; set; }
    public string Remark { get; set; }
}

public class ProductDetails
{
    public string Segment { get; set; }
    public decimal NetAmount { get; set; }
    public decimal PaidAmount { get; set; }
}

public class PaymentDetails
{
    public string PaymentDate { get; set; }
    public string ModeOfPayment { get; set; }
    public string BankName { get; set; }
    public string TransactionInfo { get; set; }
    public string PanNo { get; set; }
    public string State { get; set; }
    public string City { get; set; }
}
