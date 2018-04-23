Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports DevExpress.Xpo.Metadata
Imports MasterDetailWithXPO

''' <summary>
''' Summary description for XpoHelper
''' </summary>
Public NotInheritable Class XpoHelper
	Private Sub New()
	End Sub
	Shared Sub New()
		CreateDefaultObjects()
	End Sub

	Public Shared Function GetNewSession() As Session
		Return New Session(DataLayer)
	End Function

	Public Shared Function GetNewUnitOfWork() As UnitOfWork
		Return New UnitOfWork(DataLayer)
	End Function

	Private ReadOnly Shared lockObject As Object = New Object()

'INSTANT VB TODO TASK: There is no VB.NET equivalent to 'volatile':
'ORIGINAL LINE: static volatile IDataLayer fDataLayer;
	Private Shared fDataLayer As IDataLayer
	Private Shared ReadOnly Property DataLayer() As IDataLayer
		Get
			If fDataLayer Is Nothing Then
				SyncLock lockObject
					If fDataLayer Is Nothing Then
						fDataLayer = GetDataLayer()
					End If
				End SyncLock
			End If
			Return fDataLayer
		End Get
	End Property

	Private Shared Function GetDataLayer() As IDataLayer
		XpoDefault.Session = Nothing

		Dim provider As New InMemoryDataStore()
		' For demo purposes only! Create a ThreadSafeDataLayer in production!
		Dim dl As IDataLayer = New SimpleDataLayer(provider)

		Return dl
	End Function

	Private Shared Sub CreateDefaultObjects()
		Using uow As UnitOfWork = GetNewUnitOfWork()
			Dim c1 As New Customer(uow)
			c1.Name = "Ann"
			Dim o1 As New Order(uow)
			o1.Date = DateTime.Today
			o1.Totals = 10.25D
			c1.Orders.Add(o1)
			Dim o2 As New Order(uow)
			o2.Date = DateTime.Today.AddDays(-2)
			o2.Totals = 7.75D
			c1.Orders.Add(o2)

			Dim c2 As New Customer(uow)
			c2.Name = "Bill"
			Dim o3 As New Order(uow)
			o3.Date = DateTime.Today
			o3.Totals = 9.98D
			c2.Orders.Add(o3)

			uow.CommitChanges()
		End Using
	End Sub
End Class
