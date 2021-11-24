using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_CRS.Models;

namespace TMS_CRS.DAL
{
    public interface ITrafficPolice
    {
        int  Addpenalty(OffenceDetail o);
        bool EditPenalty( OffenceDetail newval,string vno);
        OffenceDetail GenerateReport(string vno);
    }
}
//Traffic police has three funcationality that is add,edit and generate report