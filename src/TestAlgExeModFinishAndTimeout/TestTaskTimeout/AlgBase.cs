using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskTimeout
{
    abstract class AlgBase
    {
        protected string mName;
        public AlgBase(string name)
        {
            mName = name;
        }

        protected abstract bool GeneratorInspectMethod();
        public bool Inspect()
        {
            return GeneratorInspectMethod();
        }
    }
}
