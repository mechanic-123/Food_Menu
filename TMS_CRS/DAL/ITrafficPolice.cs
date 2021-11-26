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
        bool EditPenalty( OffenceDetail newval,int ono);
        List<OffenceDetail> GenerateReport(string vno);
        List<OffenceDetail> Showalloffence();
        OffenceDetail GetoffencebyOffno(int ono);
    }
}
//Traffic police has three funcationality that is add,edit and generate report