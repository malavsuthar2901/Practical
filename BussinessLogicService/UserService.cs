using BussinessLogicInterface;
using Database;
using DomainEntities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicService
{
    public class UserService : IUserInterface
    {
        private readonly APPContext _context;
        private static readonly char[] SpecialChars = "/".ToCharArray();
        public UserService(APPContext context)
        {
            _context = context;
        }

        public UserOverviewDto GetList()
        {
            
            var result = _context.UserEntities.ToList();
            var list = new UserOverviewDto();
            if (result.Count > 0)
            {
                foreach (var item in result)
                {

                    var userOverView = new UserOverviewDto();
                    userOverView.UserId = item.UserId;
                    userOverView.FirstName = item.FirstName;
                    userOverView.LastName = item.LastName;
                    userOverView.EmailId = item.EmailId;
                    userOverView.Address = item.Address;
                    userOverView.DateOfBirth = item.DateOfBirth;
                    list.LSTUser.Add(userOverView);
                }
            }
            return list;
        }

        public UserOverviewDto SearchData(string value)
        {

            int indexof= value.IndexOfAny(SpecialChars);
            List<User> result;


            if (indexof==-1)
            {
                 result = _context.UserEntities.Where(x => x.FirstName.Contains(value)
            || x.LastName.Contains(value)
            || x.EmailId.Contains(value)
            || x.Address.Contains(value)).ToList();
            }
            else
            {
                if (value.Contains('/'))
                    value = value.Replace('/', '-');

                result = _context.UserEntities.Where(x => x.FirstName.Contains(value)
                || x.LastName.Contains(value)
                || x.EmailId.Contains(value)
                || x.Address.Contains(value)
                || x.DateOfBirth == Convert.ToDateTime(DateTime.ParseExact(value, "dd-MM-yyyy", CultureInfo.InvariantCulture))).ToList();
            }

            var list = new UserOverviewDto();
            if (result.Count > 0)
            {
                foreach (var item in result)
                {
                    var userOverView = new UserOverviewDto();
                    userOverView.UserId = item.UserId;
                    userOverView.FirstName = item.FirstName;
                    userOverView.LastName = item.LastName;
                    userOverView.EmailId = item.EmailId;
                    userOverView.Address = item.Address;
                    userOverView.DateOfBirth = item.DateOfBirth;
                    list.LSTUser.Add(userOverView);
                }
            }
            return list;

        }

    }
}
