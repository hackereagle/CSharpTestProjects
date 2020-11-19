using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOverloadLogicOperator
{
    public sealed class SelectedAlgorithmType
    {
        public SelectedAlgorithmType()
        { 
        }

        #region Properties
        public int Proiority { set; get; }
        public bool IsUsed { set; get; }
        public string Algorithm { set; get; }
        public string Name { set; get; }
        #endregion Properties

        public static bool operator ==(SelectedAlgorithmType left, SelectedAlgorithmType right)
        {
            return left.Algorithm.Equals(right); 
        }

        public static bool operator !=(SelectedAlgorithmType left, SelectedAlgorithmType right)
        {
            return !left.Algorithm.Equals(right); 
        }

        public override bool Equals(object obj)
        {
            bool isEqual = false;
            if (obj != null &&
                obj.GetType() == typeof(SelectedAlgorithmType))
            { 

            }
            return base.Equals(obj);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
