using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Editors;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;

namespace MySolution.Module.Win
{
    public partial class EMailHighlightingController : ViewController
    {
        public EMailHighlightingController()
        {
            InitializeComponent();
            RegisterActions(components);
        }

        private void EMailHighlightingController_Activated(object sender, EventArgs e)
        {
            View.ControlsCreated += new EventHandler(View_ControlsCreated);
        }

        private void View_ControlsCreated(object sender, EventArgs e)
        {
            foreach (PropertyEditor editor in ((DetailView)View).GetItems<PropertyEditor>())
            {
                editor.ValueRead += new EventHandler(editor_ValueRead);
                editor.ControlValueChanged += new EventHandler(editor_ControlValueChanged);
            }
        }

        void editor_ControlValueChanged(object sender, EventArgs e)
        {
            HighlightEditorValue((PropertyEditor)sender);
        }

        void editor_ValueRead(object sender, EventArgs e)
        {
            HighlightEditorValue((PropertyEditor)sender);
        }

        void HighlightEditorValue(PropertyEditor editor)
        {
            if (!(editor is ListPropertyEditor) && (editor.ControlValue != null))
            {
                Control editorControl = (Control)editor.Control;
                string editorValue =
                editor.ControlValue.ToString();
                if (Regex.IsMatch(editorValue,
                @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|" + @"(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
                {
                    // 译者注: 原代码行中没有首字符 @, 但在编译时会引发异常,因此作出调整
                    if (editorControl.Font.Style != FontStyle.Underline)
                    {
                        editorControl.Font = new Font(FontFamily.GenericSerif, 8.25F, FontStyle.Underline);
                        editorControl.ForeColor = Color.Blue;
                    }
                }
                else if (editorControl.Font.Style == FontStyle.Underline)
                {
                    editorControl.Font = new Font(FontFamily.GenericSerif, 8.25F, FontStyle.Regular);
                    editorControl.ForeColor = Color.Black;
                }
            }
        }
    }
}
