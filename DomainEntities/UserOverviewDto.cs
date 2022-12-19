using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntities
{
    public class UserOverviewDto
    {
        public UserOverviewDto ()
        {
            LSTUser = new List<UserOverviewDto>();
        }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }

        public List<UserOverviewDto> LSTUser { get; set; }
    }
}
