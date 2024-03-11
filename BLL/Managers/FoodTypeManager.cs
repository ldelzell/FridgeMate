using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers
{
    public class FoodTypeManager
    {
        private IFoodTypeDataAccess foodtypeData;

        public FoodTypeManager(IFoodTypeDataAccess foodtypeData)
        {
            this.foodtypeData = foodtypeData;
        }
        public List<string> GetFoodTypes()
        {
            return foodtypeData.GetFoodTypes();
        }
        public int GetFoodTypeId(string engineName)
        {
            return foodtypeData.GetFoodTypeId(engineName);
        }
        public string GetFoodTypeById(int engineId)
        {
            return foodtypeData.GetFoodTypeById(engineId);
        }
    }
}
