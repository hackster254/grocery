Imports MySql.Data.MySqlClient

Public Class formReportsDisplayItem
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'Dim report As New cryReportsSummary
        'Dim report As New CrystalReport1
        Dim report As New CrystalReport3
        'report.SetDatabaseLogon("root1", "")
        report.Load()


        'report.SetDataSource(ExecuteQuery("Select * from grocery.item"))

        report.SetDataSource(ExecuteQuery("Select * from grocery.item"))

        CrystalReportViewer1.ReportSource = report
        CrystalReportViewer1.Refresh()

    End Sub

    Public Function ExecuteQuery(ByVal query As String) As DataTable
        'Dim connStr As String = "Server=127.0.0.1;Database=mydb;Uid=root;Pwd=;SslMode=none"
        Dim connStr As String = "Server=127.0.0.1;Database=grocery;Uid=root1;Pwd=;SslMode=none"
        Dim conn As New MySqlConnection(connStr)

        'check in a few'


        Dim adapter As New MySqlDataAdapter("Select * FROM grocery.item", conn)
        Dim da As New MySqlDataAdapter
        Dim dt As New MySqlDataAdapter

        Dim ds As New DataSet
        Dim tables As DataTableCollection


        dt = New MySqlDataAdapter(query, conn)

        'adapter.Fill(table)

        'da.Fill(table)
        ' dt.Fill(table)
        dt.Fill(ds)


        tables = ds.Tables
        Return ds.Tables(0)

        Dim view1 As New DataView(tables(0))


    End Function
End Class