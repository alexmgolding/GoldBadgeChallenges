using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsDept_ClaimsRepository
{
    public class KomodoClaimsRepository
    {
       private Queue<ClaimContent> _listOfClaims = new Queue<ClaimContent>() { };

        // See All Claims (Read)
        public Queue<ClaimContent> GetClaimConentList()
        {
            return _listOfClaims;
        }

        // Take Care of Next Claim
        public ClaimContent HandleNextClaim()
        {
            Console.Clear();

            return _listOfClaims.Peek();
        }

        // Dequeue
        public void DequeueClaim()
        {
            _listOfClaims.Dequeue();
        }

        // Enter a New Claim (Create)
        public void AddClaimToList(ClaimContent claim)
        {
            _listOfClaims.Enqueue(claim);
        }

        
    }
}
