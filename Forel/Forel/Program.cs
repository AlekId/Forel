using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forel
{
    class Program
    {
        static void Main(string[] args)
        {
            ForelManager m = new ForelManager();
            m.GetData();
            m.Cluster();
        }
    }
}
