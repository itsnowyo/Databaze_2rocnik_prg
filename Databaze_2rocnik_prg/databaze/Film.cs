using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databaze
{
    public class Film
    {
        public int Id { get; set; }
        public string Nazev { get; set; }
        public string Reziser { get; set; }
        public int RokVydani { get; set; }
        public string Zanr { get; set; }
        public int Hodnoceni { get; set; }
        public bool VidelaJsem { get; set; }
    }
}
