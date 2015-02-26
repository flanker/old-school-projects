using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

using DevExpress.ExpressApp;

namespace TimeLimited.Module.Win
{
    [ToolboxItemFilter("Xaf.Platform.Win")]
    public sealed partial class TimeLimitedWindowsFormsModule : ModuleBase
    {
        public TimeLimitedWindowsFormsModule()
        {
            InitializeComponent();
        }
    }
}
