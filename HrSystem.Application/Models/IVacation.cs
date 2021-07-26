using HrSystem.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrSystem.Application.Models
{
   public  interface IVacation
    {
        public List<VacationDto> ViewVacations(int id);
        public int RequestVacation(VacationDto vacation,int id);
        public int DeleteVacation(int id);
        public int UpdateVacation(VacationDto vacation);
        void ViewVacation(int id);
    }
}
