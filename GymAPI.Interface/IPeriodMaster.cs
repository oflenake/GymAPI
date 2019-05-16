using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymAPI.Models;

namespace GymAPI.Interface
{
    public interface IPeriodMaster
    {
        List<PeriodTB> ListofPeriod();
    }
}
