using Core;
using System.Collections.Generic;

namespace BLL
{
    public interface ICityManager
    {
        List<CityViewModel> GetAll();
    }
}
