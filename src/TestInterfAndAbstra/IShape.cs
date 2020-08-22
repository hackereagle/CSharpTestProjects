using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInterfAndAbstra
{
    public interface IShape
    {
        int Area { get; }
        Point Center { get; }
    }
}
