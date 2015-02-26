using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

using DevExpress.ExpressApp;

namespace MainDemo.Module.Win
{
    [ToolboxItemFilter("Xaf.Platform.Win")]
    public sealed partial class MainDemoWindowsFormsModule : ModuleBase
    {
        public MainDemoWindowsFormsModule()
        {
            InitializeComponent();
        }
    }
}
