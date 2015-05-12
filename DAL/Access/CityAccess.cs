using System.Collections.Generic;
using System.Web;
using System.Linq;

namespace DAL
{
    public class CityAccess : ICityAccess
    {
        public List<City> GetAll()
        {
            List<City> cities;
            using (webShopModelContainer db = new webShopModelContainer())
            {
                cities = db.Cities.ToList();
            }
            return cities;
        }
    }
}
