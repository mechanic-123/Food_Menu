using System;
using TMS_CRS.DAL;
using TMS_CRS.Models;

namespace TestTMS
{
    class Program
    {
        static void Main(string[] args)
        {
            TmUsermaster user = new TmUsermaster
            {
                Username = "R",
                Rolename = "Police",
                Password = "oipi"
            };
            IUser u = new UserImpl();
            var res = u.AddUser(user);
            if(res)
                Console.WriteLine("User Added");

        }
    }
}
