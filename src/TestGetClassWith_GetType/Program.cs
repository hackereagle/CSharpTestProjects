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
        private static bool IsSecondLevel(string category)
        {
            bool isSecondLevel = false;
            if (category.IndexOf('.') != -1)
                isSecondLevel = true;

            return isSecondLevel;
        }

        private static System.Windows.Forms.TreeView GetAlgorithm(IEnumerable<IGrouping<string, Type>> group)
        {
            System.Windows.Forms.TreeView result = new System.Windows.Forms.TreeView();

            Dictionary<string, int> FirstNodeIndex = new Dictionary<string, int>();
            int index = 0;

            const string judgeTarget = "Algorithm";
            result.Nodes.Add(judgeTarget);
            foreach (IGrouping<string, Type> type in group)
            {
                int strAlgorithmLocation = type.Key.IndexOf(judgeTarget);
                if (strAlgorithmLocation != -1)
                {
                    string key = type.Key.Substring(strAlgorithmLocation + judgeTarget.Length + 1);
                    if (IsSecondLevel(key))
                    {
                        //Dictionary<string, string> node = new Dictionary<string, string>();
                        //foreach (Type element in type)
                        //    node.Add(key, element.Name);
                        //result.Add(key.Substring(0, key.IndexOf(".")), node);
                    }
                    else
                    {
                        result.Nodes[0].Nodes.Add(key);
                        FirstNodeIndex.Add(key, index);
                        foreach (Type element in type)
                            result.Nodes[0].Nodes[FirstNodeIndex[key]].Nodes.Add(element.Name);
                    }
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            // Test GetExcutingAssembly().GetTypes()
            // 
            Type[] types = System.Reflection.Assembly.GetExecutingAssembly().GetTypes();
            foreach (Type _type in types)
            {
                // in UnderlyingSystemType, property "Namespace" is storing where is class namespace and 
                // property "Name" is storing class name.
                Console.WriteLine($"{_type.Name}, in {_type.UnderlyingSystemType.Namespace}");
            }

            // test get classes in specific namespace
            Console.WriteLine("\n");
            var group = System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                        .Where(t => t.IsClass)
                        .GroupBy(t => t.Namespace);
            foreach (var ele in group)
            {
                Console.WriteLine("Namespace: {0}", ele.Key);
                foreach (var type in ele)
                {
                    Console.WriteLine("\t{0}", type.Name);
                }
            }

            // Test saving to tree view
            Console.WriteLine("\n");
            var arrangeResults = GetAlgorithm(group);
            //System.Windows.Forms.TreeView

            Console.ReadLine();
        }
    }
}
