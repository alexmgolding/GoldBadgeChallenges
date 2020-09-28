using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsDept_ClaimsRepository
{
    public class KomodoClaimsRepository
    {
        private List<ClaimConent> _listOfClaims = new List<ClaimConent>() { };

        // See All Claims (Read)
        public List<ClaimConent> GetClaimConentList()
        {
            return _listOfClaims;
        }

        // Take Care of Next Claim


        // Enter a New Claim (Create)
        public void AddClaimToList(ClaimConent claim)
        {
            _listOfClaims.Add(claim);
        }

    }
}
