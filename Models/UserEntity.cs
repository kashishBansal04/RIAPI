using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevInfotech.Models
{
    public class UserEntity : IdentityUser<Guid>
    {
        public String AccountNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string FullName { get; set; }
        public DateTime? DBO { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public bool Active { get; set; }
        public string Sponsor { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? LastModifiedAt { get; set; }
        public bool LoginAlert { get; set; }
        public bool CodeCard { get; set; }
        public bool TwoFactorTrans { get; set; }
        public bool IsBlocked { get; set; }
        public long TicketUserId { get; set; }
        public bool ProfileCompleted { get; set; }
        public string FacebookUserId { get; set; }
        public string GoogleUserId { get; set; }
        public string TwitterUserId { get; set; }
        public string LinkedInUserId { get; set; }
        public string SocialProviderName { get; set; }
        public bool AutoPay { get; set; }
        public string PinCode { get; set; }
        public string KYCCountry { get; set; }
    }
}
