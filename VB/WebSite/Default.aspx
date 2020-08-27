<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Xpo.v15.1, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Xpo" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>ASPxGridView - How to load UserControl within EditFormTemplate at runtime </title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="XpoDataSource1"
			KeyFieldName="Oid">
			<Templates>
				<DetailRow>
					<dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" DataSourceID="XpoDataSource2"
						KeyFieldName="Oid" OnBeforePerformDataSelect="ASPxGridView2_BeforePerformDataSelect"
						OnRowInserting="ASPxGridView2_RowInserting" OnInit="ASPxGridView2_Init">
						<Columns>
                            <dx:GridViewCommandColumn VisibleIndex="0" ShowEditButton="True" ShowNewButton="True" ShowDeleteButton="True"/>
							<dx:GridViewDataTextColumn FieldName="Oid" ReadOnly="True" VisibleIndex="1">
							</dx:GridViewDataTextColumn>
							<dx:GridViewDataTextColumn FieldName="Customer!Key" VisibleIndex="2">
							</dx:GridViewDataTextColumn>
							<dx:GridViewDataDateColumn FieldName="Date" VisibleIndex="3">
							</dx:GridViewDataDateColumn>
							<dx:GridViewDataTextColumn FieldName="Totals" VisibleIndex="4">
							</dx:GridViewDataTextColumn>
						</Columns>
						<SettingsDetail IsDetailGrid="True" />
					</dx:ASPxGridView>
				</DetailRow>
			</Templates>
			<Columns>
                <dx:GridViewCommandColumn VisibleIndex="0" ShowEditButton="True" ShowNewButton="True" ShowDeleteButton="True"/>
				<dx:GridViewDataTextColumn FieldName="Oid" ReadOnly="True" VisibleIndex="1">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="2">
				</dx:GridViewDataTextColumn>
			</Columns>
			<SettingsDetail ShowDetailRow="True" />
		</dx:ASPxGridView>
		<dx:XpoDataSource ID="XpoDataSource1" runat="server" TypeName="MasterDetailWithXPO.Customer">
		</dx:XpoDataSource>
		<dx:XpoDataSource ID="XpoDataSource2" runat="server" TypeName="MasterDetailWithXPO.Order"
			Criteria="[Customer!Key] = ?">
			<CriteriaParameters>
				<asp:SessionParameter DefaultValue="-1" Name="unnamedParam0" SessionField="CustomerKey" />
			</CriteriaParameters>
		</dx:XpoDataSource>
	</div>
	</form>
</body>
</html>