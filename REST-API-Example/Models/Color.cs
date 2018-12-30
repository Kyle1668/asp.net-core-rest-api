using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_Example.Models
{
    public class Color
    {
        private readonly string _hex;

        public Color(string inHex)
        {
            _hex = inHex;                        
        }

        public string GetHex()
        {
            return _hex;
        }
    }
}
