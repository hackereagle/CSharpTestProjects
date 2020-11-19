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

        public SelectedAlgorithmType(int priority, bool isUse, string algorithm, string name)
        {
            Priority = priority;
            IsUsed = isUse;
            Algorithm = algorithm;
            Name = name;
        }

        #region Properties
        public int Priority { set; get; }
        public bool IsUsed { set; get; }
        public string Algorithm { set; get; }
        public string Name { set; get; }
        #endregion Properties

        public static bool operator ==(SelectedAlgorithmType left, SelectedAlgorithmType right)
        {
            return left.Equals(right); 
        }

        public static bool operator !=(SelectedAlgorithmType left, SelectedAlgorithmType right)
        {
            return !left.Equals(right); 
        }

        public override bool Equals(object obj)
        {
            bool isEqual = false;
            if (obj != null &&
                obj.GetType() == typeof(SelectedAlgorithmType))
            {
                isEqual = this.Algorithm.Equals(((SelectedAlgorithmType)obj).Algorithm);
            }
            else 
            {
                isEqual = false;
            }

            return isEqual;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SelectedAlgorithmType type1 = new SelectedAlgorithmType(1, true, "Algorithm1", "algo1");
            SelectedAlgorithmType type2 = new SelectedAlgorithmType(2, true, "Algorithm2", "algo2");
            SelectedAlgorithmType type3 = new SelectedAlgorithmType(3, true, "Algorithm1", "algo3");

            // test GetHash()
            Console.WriteLine($"type1 hash code = {type1.GetHashCode()}");
            Console.WriteLine($"type2 hash code = {type2.GetHashCode()}");
            Console.WriteLine($"type3 hash code = {type3.GetHashCode()}");

            Console.WriteLine("\nTest == operator");
            Console.WriteLine($"type1 == type2: {(type1 == type2).ToString()}");
            Console.WriteLine($"type1 == type3: {(type1 == type3).ToString()}");

            Console.WriteLine("\nTest != operator");
            Console.WriteLine($"type1 != type2: {(type1 != type2).ToString()}");
            Console.WriteLine($"type1 != type3: {(type1 != type3).ToString()}");

            Console.WriteLine("\nTest Equals method");
            Console.WriteLine($"type1.Equals(type2): {(type1.Equals(type2))}");
            Console.WriteLine($"type1.Equals(type3): {(type1.Equals(type3))}");

            Console.ReadLine();
        }
    }
}
