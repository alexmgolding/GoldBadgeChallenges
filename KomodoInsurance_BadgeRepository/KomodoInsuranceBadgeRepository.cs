using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_BadgeRepository
{
    public class KomodoInsuranceBadgeRepository
    {
        // Key = BadgeID             Value = Badge - doors/badgeName BadgeAccess[Key]
        Dictionary<int, BadgeAccess> badgeDictionary = new Dictionary<int, BadgeAccess>();
        

        // Create New Badge
        public void CreateNewBadgeAccess(int badgeID, BadgeAccess doorNumber)
        {
            badgeDictionary.Add(badgeID, doorNumber);
        }

        // Add Doors Access
        public bool AddDoorAccess(int badgeID, string doorNumber)
        {
            if (badgeDictionary.ContainsKey(badgeID))
            {
                
                badgeDictionary[badgeID].DoorNumber.Add(doorNumber);

                return true;
            }
            else
            {
                return false;
            }
        }

        // Remove Door Access
        public bool RemoveDoorAccess(int badgeID, string doorNumber)
        {
            if (badgeDictionary.ContainsKey(badgeID))
            {
                badgeDictionary[badgeID].DoorNumber.Remove(doorNumber);

                return true;
            }
            else
            {
                return false;
            }
        }
        
        // Show All Badges
        public Dictionary<int, BadgeAccess> DisplayBadgeAccess()
        {
            return badgeDictionary;
        }

        // Display Badge Access
        public BadgeAccess GetBadgeById(int badgeID)
        {
            if (badgeDictionary.ContainsKey(badgeID))
            {
                return badgeDictionary[badgeID];
            }
            else
            {
                return null;
            }
        }
    }
}
