using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;

namespace kaogu.Module
{
    public partial class RemainMarkChangeController : ViewController
    {
        public RemainMarkChangeController()
        {
            InitializeComponent();
            RegisterActions(components);
        }

        private void RemainMarkChangeController_Activated(object sender, EventArgs e)
        {
            ShowRemainChangeAction.Active.SetItemValue("ObjectType", View.ObjectTypeInfo.Type == typeof(RemainMark));

        }

        private void ShowRemainChangeAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            var objectSpace = Application.CreateObjectSpace();
            e.View = Application.CreateListView(Application.FindListViewId(typeof(MarkChange)),
                new CollectionSource(objectSpace, typeof(MarkChange)), true);

        }
    }
}
