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
        private static bool IsSecondLevel(string category, out string ParentCategory, out string name)
        {
            bool isSecondLevel = false;
            int index = category.IndexOf('.');
            if (index != -1)
            {
                isSecondLevel = true;
                ParentCategory = category.Substring(0, index);
                name = category.Substring(index + 1, category.Length - index - 1);
            }
            else
            {
                isSecondLevel = false;
                ParentCategory = null;
                name = category;
            }

            return isSecondLevel;
        }

        private static System.Windows.Forms.TreeView GetAlgorithm(IEnumerable<IGrouping<string, Type>> group)
        {
            System.Windows.Forms.TreeView result = new System.Windows.Forms.TreeView();

            Dictionary<string, int> FirstLevelNodeIndex = new Dictionary<string, int>();
            int index = 0;

            const string judgeTarget = "Algorithm";
            result.Nodes.Add(judgeTarget);
            foreach (IGrouping<string, Type> type in group)
            {
                int strAlgorithmLocation = type.Key.IndexOf(judgeTarget);
                bool isInAlgorithmNamespace = (strAlgorithmLocation != -1);
                if (isInAlgorithmNamespace)
                {
                    string key = type.Key.Substring(strAlgorithmLocation + judgeTarget.Length + 1);
                    string parentCategory, categoryName;
                    if (IsSecondLevel(key, out parentCategory, out categoryName))
                    {
                        if (!FirstLevelNodeIndex.ContainsKey(parentCategory))
                        {
                            result.Nodes[0].Nodes.Add(parentCategory);
                            FirstLevelNodeIndex.Add(parentCategory, index);
                            index++;
                        }

                        result.Nodes[0].Nodes[FirstLevelNodeIndex[parentCategory]].Nodes.Add(categoryName);
                        foreach (Type element in type)
                            result.Nodes[0].Nodes[FirstLevelNodeIndex[parentCategory]].LastNode.Nodes.Add(element.Name);
                    }
                    else
                    {
                        result.Nodes[0].Nodes.Add(key);
                        FirstLevelNodeIndex.Add(key, index);
                        foreach (Type element in type)
                            result.Nodes[0].Nodes[FirstLevelNodeIndex[key]].Nodes.Add(element.Name);

                        index++;
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
            System.Windows.Forms.TreeView arrangeResults = GetAlgorithm(group);
            arrangeResults.Dock = System.Windows.Forms.DockStyle.Fill;
            System.Windows.Forms.Form form = new System.Windows.Forms.Form();
            form.Controls.Add(arrangeResults);

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.Run(form);

            Console.ReadLine();
        }
    }
}
