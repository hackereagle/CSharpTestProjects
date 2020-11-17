using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReflection
{
    using System;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Reflection;
    //  
    //MyClass1 and MyClass2 are used to demonstrate the some other aspects of reflection  
    //such as creating an instace of object at run time based on class name and invoking a method of that object  
    //see cmdMoreReflection_Click() for these aspects  
    class MyClass1
    {
        public MyClass1()
        {
            //Console.WriteLine("In Constructor of MyClass1");  
            MessageBox.Show("In Constructor of MyClass1");
        }
        public void M1()
        {
            //Console.WriteLine("In M1");   
            MessageBox.Show("In M1");
        }
    }
    class MyClass2
    {
        public MyClass2()
        {
            //Console.WriteLine("In Constructor of MyClass2");  
            MessageBox.Show("In Constructor of MyClass2");
        }
        public void M2()
        {
            //Console.WriteLine("In M2");   
            MessageBox.Show("In M2");
        }
    }
    //  
    //  
    /// <summary>  
    /// Summary description for TestReflection.  
    /// </summary>  
    public class TestReflection : System.Windows.Forms.Form
    {
        /// <summary>  
        /// Required designer variable.  
        /// </summary>  
        private System.ComponentModel.Container components;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdReflect;
        private System.Windows.Forms.TreeView tvwObjectBrowser;
        public TestReflection()
        {
            //  
            // Required for Windows Form Designer support  
            //  
            InitializeComponent();
            //  
            // TODO: Add any constructor code after InitializeComponent call  
            //  
            //common prefix for the path of assemblies.  
            //If this is not same on your computers you need to change this  
            String strPrefixForPath = "D:\\WINNT\\Microsoft.NET\\Framework\\v1.0.2204\\";
            //Array for holding path names for all assemblies  
            //If you have a new assembly Increase the size of this array   
            //and add the path to the array  
            string[] arAssemblyPath = {
                strPrefixForPath + "System.Winforms.dll",
                strPrefixForPath + "System.dll"  
                /*strPrefixForPath + "mscorlib.dll", 
                strPrefixForPath + "Microsoft.ComServices.dll", 
                strPrefixForPath + "Microsoft.Win32.Interop.dll", 
                strPrefixForPath + "System.ComponentModel.Design.dll", 
                strPrefixForPath + "System.configuration.dll", 
                strPrefixForPath + "System.configuration.Design.dll", 
                strPrefixForPath + "System.configuration.Install.dll", 
                strPrefixForPath + "System.Data.dll", 
                strPrefixForPath + "System.Data.Design.dll", 
                strPrefixForPath + "System.Diagnostics.Design.dll", 
                strPrefixForPath + "System.Diagnostics.dll", 
                strPrefixForPath + "System.DirectoryServices.dll", 
                strPrefixForPath + "System.dll", 
                strPrefixForPath + "System.Drawing.dll", 
                strPrefixForPath + "System.Drawing.Design.dll", 
                strPrefixForPath + "System.Drawing.Printing.Design.dll", 
                strPrefixForPath + "System.IO.dll", 
                strPrefixForPath + "System.Management.dll", 
                strPrefixForPath + "System.Messaging.dll", 
                strPrefixForPath + "System.Net.dll", 
                strPrefixForPath + "System.Runtime.Remoting.dll", 
                strPrefixForPath + "System.Runtime.Serialization.Formatters.Soap.dll", 
                strPrefixForPath + "System.Security.dll", 
                strPrefixForPath + "System.ServiceProcess.dll", 
                strPrefixForPath + "System.Text.RegularExpressions.dll", 
                strPrefixForPath + "System.Timers.dll", 
                strPrefixForPath + "System.Web.dll", 
                strPrefixForPath + "System.Web.UI.Design.dll", 
                strPrefixForPath + "System.XMl.dll", 
                strPrefixForPath + "System.Xml.Serialization.dll" */  
            };
            //strPrefixForPath + "System.WebServices.Design.dll",  
            Type[] arOfTypes; //Array of Types.This array would hold all the types from each assembly  
            Assembly objAssembly; //An assembly object so that each assembly could be assinged to it  
            //Load each assembly  
            foreach (string str in arAssemblyPath)
            {
                try //In case we dont find the essembly,capture the exception  
                {
                    objAssembly = System.Reflection.Assembly.LoadFrom(str);
                    arOfTypes = objAssembly.GetTypes();
                    //For Each type in arOfTypes get Properties,Methods and Events  
                    foreach (Type t in arOfTypes)
                    {
                        //Add the class as one of the roots of the treeview  
                        TreeNode tn;
                        tn = tvwObjectBrowser.Nodes.Add(t.FullName);
                        //Get Constructors  
                        ConstructorInfo[] ctrInfo = t.GetConstructors();
                        TreeNode tn2;
                        tn2 = tn.Nodes.Add("Constructors");
                        foreach (ConstructorInfo c in ctrInfo)
                        {
                            tn2.Nodes.Add(c.ToString());
                        }
                        //Get Properties  
                        try
                        {
                            PropertyInfo[] pInfo = t.GetProperties();
                            tn2 = tn.Nodes.Add("Properties");
                            foreach (PropertyInfo p in pInfo)
                            {
                                tn2.Nodes.Add(p.ToString());
                            }
                        }
                        catch (Exception e)
                        {
                            tn2 = tn.Nodes.Add("Properties");
                            tn2.Nodes.Add(e.ToString());
                        }
                        //Get Methods  
                        try
                        {
                            MethodInfo[] mInfo = t.GetMethods();
                            tn2 = tn.Nodes.Add("Methods");
                            foreach (MethodInfo m in mInfo)
                            {
                                tn2.Nodes.Add(m.ToString());
                            }
                        }
                        catch (Exception e)
                        {
                            tn2 = tn.Nodes.Add("Methods");
                            tn2.Nodes.Add(e.ToString());
                        }
                        //Get Events  
                        try
                        {
                            EventInfo[] eInfo = t.GetEvents();
                            tn2 = tn.Nodes.Add("Events");
                            foreach (EventInfo e in eInfo)
                            {
                                tn2.Nodes.Add(e.ToString());
                            }
                        }
                        catch (Exception e)
                        {
                            tn2 = tn.Nodes.Add("Events");
                            tn2.Nodes.Add(e.ToString());
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
            arOfTypes = null;
            objAssembly = null;
        }
        /// <summary>  
        /// Clean up any resources being used.  
        /// </summary>  
        //public override void Dispose()
        //{
        //    base.Dispose();
        //    components.Dispose();
        //}
        /// <summary>  
        /// Required method for Designer support - do not modify  
        /// the contents of this method with the code editor.  
        /// </summary>  
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdReflect = new System.Windows.Forms.Button();
            this.tvwObjectBrowser = new System.Windows.Forms.TreeView();
            //@this.TrayHeight = 0;  
            //@this.TrayLargeIcon = false;  
            //@this.TrayAutoArrange = true;  
            label1.Location = new System.Drawing.Point(16, 264);
            label1.Text = "Click on this button Which Demonstartes some more aspects of reflection such as creating an object at run time based on class name and invoking a method of that object";
            label1.Size = new System.Drawing.Size(224, 48);
            label1.ForeColor = System.Drawing.Color.Blue;
            label1.TabIndex = 2;
            label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            cmdReflect.Location = new System.Drawing.Point(256, 272);
            cmdReflect.ForeColor = System.Drawing.Color.Blue;
            cmdReflect.Size = new System.Drawing.Size(96, 24);
            cmdReflect.TabIndex = 1;
            cmdReflect.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            cmdReflect.Text = "More Reflection";
            cmdReflect.Click += new System.EventHandler(this.cmdReflect_Click);
            tvwObjectBrowser.Location = new System.Drawing.Point(16, 16);
            tvwObjectBrowser.Size = new System.Drawing.Size(336, 240);
            tvwObjectBrowser.TabIndex = 0;
            //tvwObjectBrowser.Anchor = System.Windows.Forms.AnchorStyles.All;
            this.Text = "Reflection";
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(368, 317);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdReflect);
            this.Controls.Add(this.tvwObjectBrowser);
        }
        protected void cmdReflect_Click(object sender, System.EventArgs e)
        {
            Type t = Type.GetType("MyReflection.MyClass1");
            object obj1;
            obj1 = Activator.CreateInstance(t);
            obj1.GetType().InvokeMember("M1", BindingFlags.Default | BindingFlags.InvokeMethod, null, obj1, new object[] { });
            Type t2 = Type.GetType("MyReflection.MyClass2");
            object obj2;
            obj2 = Activator.CreateInstance(t2);
            obj2.GetType().InvokeMember("M2", BindingFlags.Default | BindingFlags.InvokeMethod, null, obj2, new object[] { });
        }
        /// <summary>  
        /// The main entry point for the application.  
        /// </summary>  
        public static void Main(string[] args)
        {
            Application.Run(new TestReflection());
        }
    }
}
