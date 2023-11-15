using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BollardVioEventGeneration
{
    class Program
    {
        static void Main(string[] args)
        {
            BollardVioEventGeneration bioEventGeneration = new BollardVioEventGeneration(8075);
            bioEventGeneration.GenerateBollardVioEvent();
            var stop = 1;
        }
    }
}
