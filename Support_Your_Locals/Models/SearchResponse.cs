using System;
using System.Collections.Generic;
using System.Linq;

namespace Support_Your_Locals.Models
{
    public class SearchResponse
    {

        public string OwnersSurname { get; set; }
        public string Header { get; set; }
        public bool SearchInDescription { get; set; }
        public bool[] WeekdaySelected { get; set; } = new bool[7];

        public IEnumerable<Business> filterBusinesses(IEnumerable<UserBusiness> usersBusinesses)
        {
            foreach (var ub in usersBusinesses)
            {
                if (SearchConditionsMet(ub)) yield return ub.Business;
            }
        }

        private bool SearchConditionsMet(UserBusiness userBusiness)
        {
            User user = userBusiness.User;
            Business business = userBusiness.Business;
            if (!String.IsNullOrEmpty(OwnersSurname) && !ChosenOwnersSurname(user)) return false;
            if (!String.IsNullOrEmpty(Header))
            {
                if (SearchInDescription)
                {
                    if (!ChosenDescription(business)) return false;
                }
                else if (!ChosenHeader(business)) return false;
            }
            return true;
        }


        private bool ChosenHeader(Business business)
        {
            return business.Header.ToLower().Equals(Header.ToLower());
        }

        private bool ChosenDescription(Business business)
        {
            return business.Description.ToLower().Equals(Header.ToLower()); // OK, Header is Description if search in description is ticked.
        }

        //TODO: Search by working hours.

        private bool ChosenWeekday(IEnumerable<TimeSheet> timeSheets)
        {
            return timeSheets.Count(t => WeekdaySelected[t.Weekday - 1]) == 1;
        }

        private bool ChosenOwnersSurname(User user)
        {
            return user.Surname.ToLower().Equals(OwnersSurname.ToLower());
        }

    }
}
