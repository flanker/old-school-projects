using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Data.Filtering;

namespace MySolution.Module
{
    public partial class FilterListViewController : ViewController
    {
        public FilterListViewController()
        {
            InitializeComponent();
            RegisterActions(components);
        }

        private void FilterListViewController_Activated(object sender, EventArgs e)
        {
            //if ((View is ListView) & (View.ObjectTypeInfo.Type == typeof(Person)))
            //{
            //    ((ListView)View).CollectionSource.Criteria["Filter1"] = new BinaryOperator("Position.Title", "Developer", BinaryOperatorType.Equal);
            //}
        }
    }
}
