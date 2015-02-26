using System;
using System.ComponentModel;

using DevExpress.ExpressApp;

namespace TimeLimited.Module.Web
{
    [ToolboxItemFilter("Xaf.Platform.Web")]
    public sealed partial class TimeLimitedAspNetModule : ModuleBase
    {
        public TimeLimitedAspNetModule()
        {
            InitializeComponent();
        }
    }
}
