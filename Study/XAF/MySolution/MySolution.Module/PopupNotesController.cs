using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Editors;

namespace MySolution.Module
{
    public partial class PopupNotesController : ViewController
    {
        public PopupNotesController()
        {
            InitializeComponent();
            RegisterActions(components);
        }

        private void PopupNotesController_Activated(object sender, EventArgs e)
        {
            ShowNotesAction.Active.SetItemValue("ObjectType", View.ObjectTypeInfo.Type == typeof(DemoTask));
        }

        private void ShowNotesAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            ObjectSpace objectSpace = Application.CreateObjectSpace();
            string noteListViewId = Application.FindListViewId(typeof(Note));
            e.View = Application.CreateListView(noteListViewId, new CollectionSource(objectSpace, typeof(Note)), true);
        }

        private void ShowNotesAction_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            DemoTask task = (DemoTask)View.CurrentObject;
            ObjectSpace.SetModified(task);
            foreach (Note note in e.PopupWindow.View.SelectedObjects)
            {
                if (!string.IsNullOrEmpty(task.Description))
                {
                    task.Description += Environment.NewLine;
                }
                task.Description += note.Text;
            }
            DetailViewItem item = ((DetailView)View).FindItem("Description");
            ((PropertyEditor)item).ReadValue();
            //Save changes to the database if the current Detail View is displayed in the View mode
            if (View is DetailView && ((DetailView)View).ViewEditMode == ViewEditMode.View)
            {
                View.ObjectSpace.CommitChanges();
            }
        }
    }
}
