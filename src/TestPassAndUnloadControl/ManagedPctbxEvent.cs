using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPassAndUnloadControl
{
    class ManagedPctbxEvent
    {
        #region Privates Field
        private System.Windows.Forms.PictureBox _picturebox;
        //private delegate void ClickTemp(object sender, EventArgs e);
        //private ClickTemp temp;
        private EventHandler ClickTemp;
        #endregion Privates Field
        
        public ManagedPctbxEvent()
        {
            _picturebox = null;
        }

        // 未來這邊要用反射(reflection)來自動找click事件
        // https://www.codeproject.com/Questions/72040/how-to-get-method-name-of-control-event-handler
        // 謝迅找到的，可以試試：
//private void Form1_Load(object sender, EventArgs e) { 
//    this.components = new System.ComponentModel.Container();
//     MainMenu mainMenu = new MainMenu(this.components);
//      var menuFile = new MenuItem("File"); 
//      MenuItem menu = new MenuItem("Test");
//       menuFile.MenuItems.Add(menu); mainMenu.MenuItems.Add(menuFile); 
//       this.Menu = mainMenu; menu.Click += new EventHandler(menu_Click); 
//       } 
//       void menu_Click(object sender, EventArgs e) 
//       {
//            MessageBox.Show("MenuClick");
//        } 
//        Button btn = new Button();
//        btn.Click += btnStart_Click;
//         btn.Click += btnStart_Click; 
//         EventInfo ei = btn.GetType().GetEvent("Click"); 
//         PropertyInfo propertyInfo = (typeof(Button)).GetProperty("Events", BindingFlags.Instance | BindingFlags.NonPublic);
//          EventHandlerList eventHandlerList = (EventHandlerList)propertyInfo.GetValue(btn, null); 
//          FieldInfo fieldInfo = (typeof(Control)).GetField("EventClick", BindingFlags.Static | BindingFlags.NonPublic);
//           Delegate d = eventHandlerList[fieldInfo.GetValue(null)]; 
//    if (d != null) { 
//            foreach (Delegate temp in d.GetInvocationList()) 
//        { btn.Click -= temp as EventHandler; } 
//    }
        public void ManagePbClickEvent(System.Windows.Forms.PictureBox pctbx, EventHandler click)
        {
            _picturebox = pctbx;
            ClickTemp = click;

            _picturebox.Click -= click;
            _picturebox.Click += pictureBox_Click;
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            Console.WriteLine("In ManagedPctbxEvent class trigger picturebox click event!");
        }

        public void UnmanagePbClickEvent()
        {
            _picturebox.Click -= pictureBox_Click;
            _picturebox.Click += ClickTemp;
            _picturebox = null;
        }
    }
}
