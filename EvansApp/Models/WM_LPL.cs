//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EvansApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class WM_LPL
    {
        public int ID { get; set; }
        public string ClientName { get; set; }
        public string MailingAddressLine1 { get; set; }
        public string MailingAddressLine2 { get; set; }
        public string MailingCity { get; set; }
        public string MailingState { get; set; }
        public string ResidentsAddressLine1 { get; set; }
        public string ResidentsAddressLine2 { get; set; }
        public string ResidentsAddressLine3 { get; set; }
        public string ResidenceCity { get; set; }
        public string ResidenceState { get; set; }
        public string FirstName { get; set; }
        public string Industry { get; set; }
        public string Occupation { get; set; }
        public string EmployerName { get; set; }
        public string MailingZipCode { get; set; }
        public string ResidenceZipCode { get; set; }
        public string SSN_TaxID { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> Birthdate { get; set; }
        public Nullable<System.DateTime> ClientSinceDate { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string BusinessPhone { get; set; }
        public string Email { get; set; }
        public Nullable<decimal> AccountValue { get; set; }
        public string LinkedValue { get; set; }
        public Nullable<decimal> LPLValue { get; set; }
        public string LPLAccountsCount { get; set; }
        public Nullable<decimal> CashAndEquivalents { get; set; }
        public string CashAndEquivalentsPercentage { get; set; }
        public System.DateTime LoadedDate { get; set; }
    }
}
