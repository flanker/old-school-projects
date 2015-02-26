using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

using DevExpress.ExpressApp;

namespace MySolution.Module.Win
{
    [ToolboxItemFilter("Xaf.Platform.Win")]
    public sealed partial class MySolutionWindowsFormsModule : ModuleBase
    {
        public MySolutionWindowsFormsModule()
        {
            InitializeComponent();
        }
    }
}
