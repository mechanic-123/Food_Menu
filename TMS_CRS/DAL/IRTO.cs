using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_CRS.Models;

namespace TMS_CRS.DAL
{
    public interface IRTO
    {
        int AddOwner(TmOwnerdetail o);
        bool Transferdetails(TmRegdetail r, int vehId);
        int AddVechile(TmVehicledetail v);
        int Registration(TmRegdetail r);
        List<TmRegdetail> GetAll();
        List<TmRegdetail> GenerateReport(int id);



    }
}
//Addowner
//Add vechiled etails
//transefer details
//regstaration
//generate report