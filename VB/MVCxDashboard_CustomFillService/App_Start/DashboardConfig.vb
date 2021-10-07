Imports System.Threading
Imports System.Web.Routing
Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWeb
Imports DevExpress.DashboardWeb.Mvc

Public Class DashboardConfig
    Public Shared Sub RegisterService(ByVal routes As RouteCollection)
        routes.MapDashboardRoute("dashboardControl", "DefaultDashboard")

        DashboardConfigurator.Default.SetDashboardStorage(New DashboardFileStorage("~/App_Data/"))
        Dim dataSourceStorage = New DataSourceInMemoryStorage()
        DashboardConfigurator.Default.SetDataSourceStorage(dataSourceStorage)
        Dim objDataSource As New DashboardObjectDataSource("Object Data Source", GetType(SalesPersonData))
        objDataSource.DataSource = GetType(SalesPersonData)
        dataSourceStorage.RegisterDataSource("objDataSource", objDataSource.SaveToXml())

        DashboardConfigurator.Default.SetObjectDataSourceCustomFillService(New CustomObjectDataSourceCustomFillService())
    End Sub
End Class

Public Class SalesPersonData
    Public Property SalesPerson() As String
    Public Property Quantity() As Integer
End Class

Public Class CustomObjectDataSourceCustomFillService
    Implements IObjectDataSourceCustomFillService

    Public Function GetData(ByVal dataSource As DashboardObjectDataSource, ByVal fillParameters As ObjectDataSourceFillParameters) As Object _
        Implements IObjectDataSourceCustomFillService.GetData
        If fillParameters.DataFields Is Nothing OrElse fillParameters.DataFields.Length = 0 Then
            Return Nothing
        End If

        Dim data As List(Of SalesPersonData) = DataGenerator.CreateSourceData()

        Dim table As New DataTable()
        For Each field As String In fillParameters.DataFields
            table.Columns.Add(field, GetType(SalesPersonData).GetProperty(field).PropertyType)
        Next field
        For i As Integer = 0 To data.Count - 1
            Dim row(fillParameters.DataFields.Length - 1) As Object
            For j As Integer = 0 To fillParameters.DataFields.Length - 1
                row(j) = GetPropertyValue(data(i), fillParameters.DataFields(j))
            Next j
            table.Rows.Add(row)
        Next i
        Return table.DefaultView
    End Function
    Private Function GetPropertyValue(ByVal obj As SalesPersonData, ByVal propName As String) As Object
        Return If(propName = "SalesPerson", DirectCast(obj.SalesPerson, Object), DirectCast(obj.Quantity, Object))
    End Function
End Class

Public NotInheritable Class DataGenerator

    Private Sub New()
    End Sub

    Public Shared Function CreateSourceData() As List(Of SalesPersonData)
        Dim data As New List(Of SalesPersonData)()
        Dim salesPersons() As String = {"Andrew Fuller", "Michael Suyama",
                                            "Robert King", "Nancy Davolio",
                                            "Margaret Peacock", "Laura Callahan",
                                            "Steven Buchanan", "Janet Leverling"}

        For i As Integer = 0 To 99
            Dim record As New SalesPersonData()
            Dim seed As Long = CLng(Date.Now.Ticks) And &HFFFF
            record.SalesPerson = salesPersons((New Random(seed)).Next(0, salesPersons.Length))
            record.Quantity = (New Random(seed)).Next(0, 100)
            data.Add(record)
            Thread.Sleep(3)
        Next i
        Return data
    End Function
End Class
