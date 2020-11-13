using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGetClassWith_GetType
{
    /// <summary>
    /// This project test  how to get all classes in specific namespace. 
    /// And my goal is get class in three levels classes, 
    /// e.g. get class in three namespace Algorithm, Algorithm.Category1 and Algorithm.Category1.SubCategory.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Test GetExcutingAssembly().GetTypes()
            Type[] types = System.Reflection.Assembly.GetExecutingAssembly().GetTypes();
            foreach (Type _type in types)
            {
                Console.WriteLine($"{_type.Name}, in{_type.UnderlyingSystemType.Namespace}");
            }

            // Test 
            Console.WriteLine("\n");
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetAssembly(typeof(DateTime));
            foreach (var exportedType in assembly.GetExportedTypes())
            {
                Console.WriteLine($"{exportedType.Name}");
            }

            Console.ReadLine();
        }
    }
}
