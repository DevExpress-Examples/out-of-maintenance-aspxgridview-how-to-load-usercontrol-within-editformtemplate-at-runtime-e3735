using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Xpo;
using DevExpress.Web.ASPxGridView;

public partial class _Default : System.Web.UI.Page {
    Session xpoSession;
    protected void Page_Init (object sender, EventArgs e) {
        xpoSession = XpoHelper.GetNewSession();
        XpoDataSource1.Session = xpoSession;
        XpoDataSource2.Session = xpoSession;
    }

    protected void Page_Load (object sender, EventArgs e) {
        ASPxGridView1.Templates.EditForm = new EdiFormTemplate();
    }

    protected void ASPxGridView2_Init (object sender, EventArgs e) {
        (sender as ASPxGridView).Templates.EditForm = new EdiFormTemplate();
    }

    protected void ASPxGridView2_BeforePerformDataSelect (object sender, EventArgs e) {
        Session["CustomerKey"] = ((ASPxGridView)sender).GetMasterRowKeyValue();
    }

    protected void ASPxGridView2_RowInserting (object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e) {
        e.NewValues["Customer!Key"] = ((ASPxGridView)sender).GetMasterRowKeyValue();
    }

    class EdiFormTemplate : ITemplate {
        public void InstantiateIn (Control container) {
            Control control = (container as GridViewEditFormTemplateContainer).Grid.Page.LoadControl("~/EditUserControl.ascx");
            control.ID = "EditUserControl" + container.ID;
            container.Controls.Add(control);
        }
    }
}
