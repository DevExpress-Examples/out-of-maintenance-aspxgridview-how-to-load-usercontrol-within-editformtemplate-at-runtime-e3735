Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Xpo
Imports DevExpress.Web.ASPxGridView

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Private xpoSession As Session
	Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
		xpoSession = XpoHelper.GetNewSession()
		XpoDataSource1.Session = xpoSession
		XpoDataSource2.Session = xpoSession
	End Sub

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		ASPxGridView1.Templates.EditForm = New EdiFormTemplate()
	End Sub

	Protected Sub ASPxGridView2_Init(ByVal sender As Object, ByVal e As EventArgs)
		TryCast(sender, ASPxGridView).Templates.EditForm = New EdiFormTemplate()
	End Sub

	Protected Sub ASPxGridView2_BeforePerformDataSelect(ByVal sender As Object, ByVal e As EventArgs)
		Session("CustomerKey") = (CType(sender, ASPxGridView)).GetMasterRowKeyValue()
	End Sub

	Protected Sub ASPxGridView2_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
		e.NewValues("Customer!Key") = (CType(sender, ASPxGridView)).GetMasterRowKeyValue()
	End Sub

	Private Class EdiFormTemplate
		Implements ITemplate
		Public Sub InstantiateIn(ByVal container As Control) Implements ITemplate.InstantiateIn
			Dim control As Control = (TryCast(container, GridViewEditFormTemplateContainer)).Grid.Page.LoadControl("~/EditUserControl.ascx")
			control.ID = "EditUserControl" & container.ID
			container.Controls.Add(control)
		End Sub
	End Class
End Class
