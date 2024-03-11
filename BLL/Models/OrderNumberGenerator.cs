using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class OrderNumberGenerator
    {

        private static Random random = new Random();
        private const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public string GenerateOrderNumber()
        {
            char[] result = new char[7];

            for (int i = 0; i < 7; i++)
            {
                result[i] = characters[random.Next(characters.Length)];
            }

            return new string(result);
        }

    }
}
