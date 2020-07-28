using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Models
{
    public class Game : Product
    {
        public int GameId { get; set; }
        public int Brand { get; set; }
        public bool condition { get; set; }
    }
}
