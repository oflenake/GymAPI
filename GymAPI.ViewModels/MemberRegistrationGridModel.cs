using System;

namespace GymAPI.ViewModels
{
    public class MemberRegistrationGridModel
    {
        public long MemberId { get; set; }
        public string MemberNo { get; set; }
        public string MemberName { get; set; }
        public DateTime? Dob { get; set; }
        public string Contactno { get; set; }
        public string EmailId { get; set; }
        public string PlanName { get; set; }
        public string SchemeName { get; set; }
        public DateTime? JoiningDate { get; set; }
        public decimal? Amount { get; set; }
    }
}
