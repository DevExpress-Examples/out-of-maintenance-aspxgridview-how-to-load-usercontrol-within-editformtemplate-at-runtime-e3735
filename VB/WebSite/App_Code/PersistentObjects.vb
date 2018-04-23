Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Xpo

Namespace MasterDetailWithXPO
	Public Class Customer
		Inherits XPObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		Private _Name As String
		Public Property Name() As String
			Get
				Return _Name
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Name", _Name, value)
			End Set
		End Property

		<Association("Customer-Orders")> _
		Public ReadOnly Property Orders() As XPCollection(Of Order)
			Get
				Return GetCollection(Of Order)("Orders")
			End Get
		End Property
	End Class
	Public Class Order
		Inherits XPObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		Private _Customer As Customer
		<Association("Customer-Orders")> _
		Public Property Customer() As Customer
			Get
				Return _Customer
			End Get
			Set(ByVal value As Customer)
				SetPropertyValue("Customer", _Customer, value)
			End Set
		End Property
		Private _Date As DateTime
		Public Property [Date]() As DateTime
			Get
				Return _Date
			End Get
			Set(ByVal value As DateTime)
				SetPropertyValue("Date", _Date, value)
			End Set
		End Property
		Private _Totals As Decimal
		Public Property Totals() As Decimal
			Get
				Return _Totals
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue("Totals", _Totals, value)
			End Set
		End Property

	End Class
End Namespace
