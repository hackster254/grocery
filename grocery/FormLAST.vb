﻿Imports MySql.Data.MySqlClient
Public Class FormLAST
    Private Sub FormLAST_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class