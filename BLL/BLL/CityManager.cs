using AutoMapper;
using Core;
using DAL;
using System.Collections.Generic;

namespace BLL
{
    public class CityManager : ICityManager
    {
        ICityAccess cityAccess;

        static CityManager()
        {
            Mapper.CreateMap<City, CityViewModel>();
        }


        public CityManager(ICityAccess cityAccess)
        {
            this.cityAccess = cityAccess;
        }


        public List<CityViewModel> GetAll()
        {
            List<City> cities = cityAccess.GetAll();

            List<CityViewModel> citiesVM = Mapper.Map<List<CityViewModel>>(cities);

            return citiesVM;
        }
    }
}