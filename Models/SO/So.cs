using Models.Common;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SO
{
    public class So
    {
        public int Id {  get; set; }
        //public string apiType { get; set; }
        //public string accessType { get; set; }
        public string? EmployeeCode { get; set; }
        public string? EmployeeName { get; set; }
        public string? SoId { get; set; }
        public string? LeadId { get; set; }
        public PersonalDetails? PersonalDetails { get; set; }
        public _PaymentDetails? PaymentDetails { get; set; }
        public BusinessDetails? BusinessDetails { get; set; }
        public List<_ProductDetails>? ProductDetails { get; set; }
    }
}
public class PersonalDetails
{
    public string? CreatedDate { get; set; }
    public string? ClientName { get; set; }
    public string? FatherName { get; set; }
    public string? MotherName { get; set; }
    public string? Mobile { get; set; }
    public string? Email { get; set; }
   
    public string? Dob { get; set; }
    public Address? Address { get; set; }
    public string? Aadhar { get; set; }
    public string? PanNo { get; set; }
    public string? Gstin { get; set; }
    public string? Sac { get; set; }
}

public class Address
{
    public string? City { get; set; }
    public string? State { get; set; }
    public string? PinCode { get; set; }
}

public class _PaymentDetails
{
    public string? PaymentDate { get; set; }
    public string? ModeOfPayment { get; set; }
    public string? BankName { get; set; }
    public string? PaymentGateway { get; set; }
    public string? ServiceMode { get; set; }
    public string? Terms { get; set; }
    public string? PaymentIdOrRefNo { get; set; }
    public string? ServiceStatus { get; set; }
}

public class BusinessDetails
{
    public string? BusinessType { get; set; }
    public string? Comment { get; set; }
}

public class _ProductDetails
{
    public string? Product { get; set; }
    public string? StartDate { get; set; }
    public string? EndDate { get; set; }
    public decimal? GrandTotal { get; set; }
    public decimal? Remaining { get; set; }
    public decimal? Discount { get; set; }
    public decimal? Adjustment { get; set; }

}
