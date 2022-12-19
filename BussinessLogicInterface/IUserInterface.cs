using DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicInterface
{
    public interface IUserInterface
    {
        public UserOverviewDto GetList();

        public UserOverviewDto SearchData(string value);
    }
}
