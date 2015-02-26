namespace MySolution.Module
{
    partial class FindBySubjectController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.FindBySubjectAction = new DevExpress.ExpressApp.Actions.ParametrizedAction(this.components);
            // 
            // FindBySubjectAction
            // 
            this.FindBySubjectAction.Caption = "Find Task By Subject";
            this.FindBySubjectAction.ConfirmationMessage = null;
            this.FindBySubjectAction.Id = "FindBySubjectAction";
            this.FindBySubjectAction.ImageName = null;
            this.FindBySubjectAction.ShortCaption = null;
            this.FindBySubjectAction.Shortcut = null;
            this.FindBySubjectAction.Tag = null;
            this.FindBySubjectAction.TargetObjectsCriteria = null;
            this.FindBySubjectAction.TargetViewId = null;
            this.FindBySubjectAction.ToolTip = null;
            this.FindBySubjectAction.TypeOfView = null;
            this.FindBySubjectAction.Execute += new DevExpress.ExpressApp.Actions.ParametrizedActionExecuteEventHandler(this.FindBySubjectAction_Execute);
            // 
            // FindBySubjectController
            // 
            this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.Activated += new System.EventHandler(this.FindBySubjectController_Activated);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.ParametrizedAction FindBySubjectAction;
    }
}
