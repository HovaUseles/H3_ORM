using H3_ORM_GUI.GUI.Interfaces;
using H3_ORM_GUI.GUI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3_ORM_GUI.GUI.Views.Home
{
    internal class HomeView : IViewable
    {
        public IViewable Show()
        {
            ViewComponents.DisplayViewHeader("Hello world");
            Console.ReadKey();

            return null;
        }
    }
}
