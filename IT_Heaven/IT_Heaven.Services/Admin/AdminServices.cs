using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using IT_Heaven.Data;

namespace IT_Heaven.Services.Admin
{
    public class AdminServices
    {
        public string GetUserRoles(string userId)
        {
            using (var context = new ApplicationDbContext())
            {

            }
                if (User.IsInRole("Admin"))
                {
                    return "Admin";
                }
                else if (User.IsInRole("Helper"))
                {
                    return "Helper";
                }
                else
                {
                    return "User";
                }
        }
    }
}
