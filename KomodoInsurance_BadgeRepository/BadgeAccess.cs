using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_BadgeRepository
{
    public class BadgeAccess
    {
        public int BadgeID { get; set; }
        public List<string> DoorNumber { get; set; }
        public string BadgeName { get; set; }

        public BadgeAccess() { }

        public BadgeAccess(int badgeID, string badgeName)
        {
            BadgeID = badgeID;
            BadgeName = badgeName;
            DoorNumber = new List<string>();
        }
    }
}
