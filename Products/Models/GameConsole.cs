using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Models
{
    public class GameConsole : Product
    {
        public int ConsoleId { get; set; }
        public int Brand { get; set; }
        public string Model { get; set; }
        public bool Condition { get; set; }
    }
}
