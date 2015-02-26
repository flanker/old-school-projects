using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base.General;
using System.Collections;
using DevExpress.ExpressApp.Editors;

namespace MySolution.Module
{
    public partial class TaskActionsController : ViewController
    {
        private ChoiceActionItem setPriorityItem;
        private ChoiceActionItem setStatusItem;
        public TaskActionsController()
        {
            InitializeComponent();
            RegisterActions(components);

            SetTaskAction.Items.Clear();
            setPriorityItem = new ChoiceActionItem(CaptionHelper.GetMemberCaption(typeof(DemoTask), "Priority"), null);
            //setPriorityItem.Enabled.SetItemValue(
            SetTaskAction.Items.Add(setPriorityItem);
            FillItemWithEnumValues(setPriorityItem, typeof(Priority));
            setStatusItem = new ChoiceActionItem(CaptionHelper.GetMemberCaption(typeof(DemoTask), "Status"), null);
            SetTaskAction.Items.Add(setStatusItem);
            FillItemWithEnumValues(setStatusItem, typeof(TaskStatus));
        }

        private void FillItemWithEnumValues(ChoiceActionItem parentItem, Type enumType)
        {
            foreach (object current in Enum.GetValues(enumType))
            {
                EnumDescriptor ed = new EnumDescriptor(enumType);
                ChoiceActionItem item = new ChoiceActionItem(ed.GetCaption(current), current);
                item.ImageName = enumType.FullName + '\\' + current.ToString();
                parentItem.Items.Add(item);
            }
        }

        private void TaskActionsController_Activated(object sender, EventArgs e)
        {
            SetTaskAction.Active.SetItemValue("ObjectType", View.ObjectTypeInfo.Type == typeof(DemoTask));
        }

        private void SetTaskAction_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            ArrayList objectsToProcess = new ArrayList(e.SelectedObjects);
            if (e.SelectedChoiceActionItem.ParentItem == setPriorityItem)
            {
                foreach (Object obj in objectsToProcess)
                {
                    ((DemoTask)obj).Priority = (Priority)e.SelectedChoiceActionItem.Data;
                }
            }
            else if (e.SelectedChoiceActionItem.ParentItem == setStatusItem)
            {
                foreach (Object obj in objectsToProcess)
                {
                    ((DemoTask)obj).Status = (TaskStatus)e.SelectedChoiceActionItem.Data;
                }
            }
            // Save changes to the database if the current View is a List View or
            // Detail View displayed in the View mode
            if ((View is ListView || (View is DetailView && ((DetailView)View).ViewEditMode == ViewEditMode.View)))
            {
                View.ObjectSpace.CommitChanges();
            }
        }
    }
}
