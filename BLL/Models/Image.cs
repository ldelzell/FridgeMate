using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Image
    {
        public int Id { get; private set; }
        public byte[] ImageValue { get; private set; }


        public Image(int id, byte[] imageValue)
        {
            Id = id;
            ImageValue = imageValue;
        }

    }
}
