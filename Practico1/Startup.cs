using DAL;
using Microsoft.EntityFrameworkCore;


namespace Practico1
{
    public class Startup
    {
        public void UpdateDatabase()
        {
            using (var context = new DBContext())
            {
                context?.Database.Migrate();
            }
            Console.WriteLine("Base de datos actualizada.");
        }
    }
}
