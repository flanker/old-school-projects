using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.DC;

namespace MySolution.Module
{
    public partial class ClearFieldsController : ViewController
    {
        public ClearFieldsController()
        {
            InitializeComponent();
            RegisterActions(components);
        }

        private void ClearFieldsAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            foreach (PropertyEditor item in ((DetailView)View).GetItems<PropertyEditor>())
            {
                if (item.AllowEdit)
                {
                    try
                    {
                        item.PropertyValue = null;
                    }
                    catch (IntermediateMemberIsNullException)
                    {
                        item.Refresh();
                    }
                }
            }
        }

        private void ClearFieldsController_Activated(object sender, EventArgs e)
        {
            // Makes the ClearFields Action enabled if the current Detail View's ViewEditMode property
            // is set to ViewEditMode.Edit
            ClearFieldsAction.Enabled.SetItemValue("EditMode", 
                ((DetailView)View).ViewEditMode == ViewEditMode.Edit);
            ((DetailView)View).ViewEditModeChanged += 
                new EventHandler<EventArgs>(ClearFieldsController_ViewEditModeChanged);
        }

        // Manages the ClearFields Action enabled state
        void ClearFieldsController_ViewEditModeChanged(object sender, EventArgs e)
        {
            ClearFieldsAction.Enabled.SetItemValue("EditMode",
                ((DetailView)View).ViewEditMode == ViewEditMode.Edit);
        }
    }
}
