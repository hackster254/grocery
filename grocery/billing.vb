Imports MySql.Data.MySqlClient

Public Class billing
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub billing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        displayItems()
    End Sub
    Private Sub addBill()


        Dim connStr As String = "Server=127.0.0.1;Database=grocery;Uid=root1;Pwd=;SslMode=none"
        Dim conn As New MySqlConnection(connStr)

        Try
            conn.Open()

            Dim command As New MySqlCommand("INSERT INTO bill ( BClientName, BAmt, BDate ) VALUE ( @Cname, @Amt, @Date)", conn)



            command.Parameters.Add("@Cname", MySqlDbType.VarChar).Value = txtClientName.Text
            command.Parameters.Add("@Amt", MySqlDbType.VarChar).Value = Grdtotal
            command.Parameters.Add("@Date", MySqlDbType.DateTime).Value = DateTime.Today.Date





            'command.Parameters.Add("@unit_id", MySqlDbType.VarChar).Value = cmbxUnits.SelectedValue.ToString

            If command.ExecuteNonQuery() = 1 Then
                MessageBox.Show(" new BILL DATA saved successfully!!!")
            End If
            conn.Close()
            '  displayItems()

        Catch ex As Exception

            MsgBox("error could Not insert to database " + ex.Message, MsgBoxStyle.Exclamation)

        Finally
            conn.Close()
            'updateTable()
            BillingGRD.Rows.Clear()
        End Try


    End Sub
    Private Sub updateItem()

        Dim newQty = stock - Convert.ToInt32(txtQty.Text)

        Dim connStr As String = "Server=127.0.0.1;Database=grocery;Uid=root1;Pwd=;SslMode=none"
        Dim conn As New MySqlConnection(connStr)
        Try
            conn.Open()

            Dim Sql As String = "UPDATE item SET  ItName=@Name, ItQty=@qty, ItPrice=@Price, ItCat@Cat  WHERE ItId=" & key & ""

            'Dim Str As String = "UPDATE item SET ItName='" + txtItName.Text + "',ItQty='" + txtQty.Text + "',ItPrice='" + txtPrice.Text + "' " + "WHERE ItId='" & key & "'"
            Dim Str As String = "UPDATE item SET ItQty='" & newQty & "',ItPrice='" + txtPrice.Text + "' " + "WHERE ItId='" & key & "'"


            'Dim command As New MySqlCommand(Sql, conn)

            'str is the one that is working
            Dim command As New MySqlCommand(Str, conn)




            If command.ExecuteNonQuery() = 1 Then
                MessageBox.Show("New Data Record changed Successfully!!")
            End If
            conn.Close()
            displayItems()

        Catch ex As Exception

            MsgBox("error could Not insert to database " + ex.Message, MsgBoxStyle.Exclamation)

        Finally
            conn.Close()
            'updateTable()
        End Try

    End Sub
    Private Sub displayItems()

        Dim connStr As String = "Server=127.0.0.1;Database=grocery;Uid=root1;Pwd=;SslMode=none"
        Dim conn As New MySqlConnection(connStr)

        'check in a few'
        'Dim adapter As New MySqlDataAdapter("Select * FROM item", conn)
        Dim da As New MySqlDataAdapter
        Dim dt As New MySqlDataAdapter

        Dim ds As New DataSet
        Dim tables As DataTableCollection


        'dt = New MySqlDataAdapter("select course_name from courses where course_id like '%" & cmbxCollege.SelectedValue.ToString & "%'", conn)
        dt = New MySqlDataAdapter("select * from item  ", conn)

        'adapter.Fill(table)

        'da.Fill(table)
        ' dt.Fill(table)
        dt.Fill(ds)

        tables = ds.Tables
        ' Dim view1 As New DataView(tables(0))
        DataGridView2.DataSource = ds.Tables(0)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles BillingGRD.CellContentClick

    End Sub
    Dim key = 0
    Dim stock = 0
    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView2.CellMouseClick, DataGridView2.CellContentClick
        Dim row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)
        txtPrice.Text = row.Cells(2).Value.ToString

        txtItName.Text = row.Cells(1).Value.ToString
        stock = Convert.ToInt32(row.Cells(2).Value.ToString)


        If txtItName.Text = "" Then
            key = 0
        Else
            key = Convert.ToInt32(row.Cells(0).Value.ToString)
            stock = Convert.ToInt32(row.Cells(3).Value.ToString)
        End If
    End Sub
    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub



    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub


    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles txtQty.TextChanged

    End Sub
    Dim i As Integer = 0
    Dim Grdtotal As Integer = 0
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtPrice.Text = "" Or txtQty.Text = "" Then
            MsgBox("enteer the quantity")
        ElseIf txtItName.Text = "" Then
            MsgBox("select the item")
        Else
            Dim rnum As Integer = BillingGRD.Rows.Add()

            i = i + 1
            Dim total = Convert.ToInt32(txtQty.Text) * Convert.ToInt32(txtPrice.Text)

            BillingGRD.Rows.Item(rnum).Cells("Column1").Value = i
            BillingGRD.Rows.Item(rnum).Cells("Column2").Value = txtItName.Text
            BillingGRD.Rows.Item(rnum).Cells("Column3").Value = txtPrice.Text
            BillingGRD.Rows.Item(rnum).Cells("Column4").Value = txtQty.Text
            BillingGRD.Rows.Item(rnum).Cells("Column5").Value = total

            Grdtotal = Grdtotal + total

            Dim tot As String
            tot = "Ksh" + Convert.ToString(Grdtotal)

            lblTotal.Text = tot


            updateItem()
            displayItems()
            'Reset()
        End If
    End Sub

    Private Sub lblTotal_Click(sender As Object, e As EventArgs) Handles lblTotal.Click

    End Sub
    Private Sub Reset()
        txtItName.Text = ""
        txtPrice.Text = ""
        txtQty.Text = ""
        Grdtotal = 0
        lblTotal.Text = "Total "

        key = 0
        stock = 0
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Reset()
    End Sub

    Private Sub txtItName_TextChanged(sender As Object, e As EventArgs) Handles txtItName.TextChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If txtClientName.Text = "" Then
            MsgBox("enter client name ")
        Else

            addBill()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim obj = New Login
        obj.Show()
        Me.Hide()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        formReportsDisplay.Show()
        formReportsDisplayItem.Show()
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub
End Class