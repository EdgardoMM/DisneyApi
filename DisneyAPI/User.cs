using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisneyAPI
{
    public class User
    {
        public string Usuario { get; set; } = string.Empty;
        public byte[] ContraseñaHash { get; set; }
        public byte[] ContraseñaSalt { get; set; }
    }
}
