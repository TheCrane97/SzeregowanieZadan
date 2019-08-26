using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hu
{
    class Maszyna
    {
        public int numerMaszyny;            
        public List<Zadanie> ustawienieZadan = new List<Zadanie>();



        public Maszyna(int numerMaszyny,List<Zadanie> ustawienieZadan)
        {
            this.numerMaszyny = numerMaszyny;
            this.ustawienieZadan = ustawienieZadan;
        }
    }
}
