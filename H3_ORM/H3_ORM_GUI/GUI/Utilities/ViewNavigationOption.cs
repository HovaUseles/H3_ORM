using H3_ORM_GUI.GUI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3_ORM_GUI.GUI.Utilities
{
    internal class ViewNavigationOption
    {
        public string DisplayName { get; set; }
        public IViewable GoToView { get; set; }

        public ViewNavigationOption(string displayName, IViewable goToView)
        {
            DisplayName = displayName;
            GoToView = goToView;
        }
    }
}
