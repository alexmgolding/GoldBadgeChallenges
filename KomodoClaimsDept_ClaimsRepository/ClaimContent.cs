using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsDept_ClaimsRepository
{
    public enum ClaimType
    {
        Car = 1,
        Home,
        Theft
    }

    public class ClaimConent
    {
        public int ClaimID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public string DateOfIncident { get; set; }
        public string DateOfClaim { get; set; }
        public bool IsValid { get; set; }
       
        public ClaimConent() { }

        public ClaimConent(int claimID, ClaimType claim, string description, decimal claimAmount, string dateOfIncident, string dateOfClaim, bool isValid)
        {
            ClaimID = claimID;
            TypeOfClaim = claim;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }
    }


}
