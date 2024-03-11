using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IFoodTypeDataAccess
    {
        public List<string> GetFoodTypes();
        public int GetFoodTypeId(string typeName);
        public string GetFoodTypeById(int typeId);
    }
}
