using System;
using System.Collections.Generic;
using System.Text;

namespace eSyaPayrollExpat.DO
{
    public class DO_CommonCodes
    {
    }

    public class DO_ApplicationCodes
    {
        public int ApplicationCode { get; set; }
        public int CodeType { get; set; }
        public string CodeDesc { get; set; }
        public string ShortCode { get; set; }
        public bool DefaultStatus { get; set; }
        public bool UsageStatus { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormID { get; set; }
        public int UserID { get; set; }
        public string TerminalID { get; set; }
    }

    public class DO_BusinessLocation
    {
        public int BusinessId { get; set; }
        public int SegmentId { get; set; }
        public int LocationId { get; set; }
        public string LocationCode { get; set; }
        public string LocationDescription { get; set; }
        public string BusinessName { get; set; }
        public int BusinessKey { get; set; }

        public int TaxIdentification { get; set; }

        public string LicenseType { get; set; }
        public int UserLicenses { get; set; }
        public bool? ToLocalCurrency { get; set; }
        public bool ToCurrCurrency { get; set; }
        public bool ToRealCurrency { get; set; }

        public bool ActiveStatus { get; set; }
        public int UserID { get; set; }
        public string FormID { get; set; }
        public string TerminalID { get; set; }
    }

    public class DO_CountryCodes
    {
        public int Isdcode { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string CountryFlag { get; set; }
        public string CurrencyCode { get; set; }
        public string MobileNumberPattern { get; set; }
        public string Uidlabel { get; set; }
        public string Uidpattern { get; set; }
        public string Nationality { get; set; }
        public bool IsPoboxApplicable { get; set; }
        public string PoboxPattern { get; set; }
        public bool IsPinapplicable { get; set; }
        public string PincodePattern { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; }
        public int UserID { get; set; }
        public string TerminalID { get; set; }
        public string CurrencyName { get; set; }
    }
}
