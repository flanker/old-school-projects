using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace MySolution.Module.Win
{
    public partial class GridFormattingController : ViewController
    {
        public GridFormattingController()
        {
            InitializeComponent();
            RegisterActions(components);
        }

        private void GridFormattingController_Activated(object sender, EventArgs e)
        {
            View.ControlsCreated += new EventHandler(View_ControlsCreated);
        }

        private void View_ControlsCreated(object sender, EventArgs e)
        {
            GridListEditor listEditor = ((ListView)View).Editor as GridListEditor;
            GridControl gridControl = (GridControl)listEditor.Control;
            GridView gridView = (GridView)gridControl.FocusedView;

            // Specify the name of the field whose values will be displayed within the Preview sections
            gridView.PreviewFieldName = "Description";
            //Activate the grid view's ShowPreview option
            gridView.OptionsView.ShowPreview = true;
            //Specify whether the number of text lines within the Preview sections
            //will be calculated automatically
            gridView.OptionsView.AutoCalcPreviewLineCount = true;
        }
    }
}
