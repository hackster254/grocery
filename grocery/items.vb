Imports MySql.Data.MySqlClient

Public Class items
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub items_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        displayItems()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles txtQty.TextChanged

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles txtPrice.TextChanged

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txtItname.Text = "" Or txtQty.Text = "" Or cmbCat.SelectedIndex = -1 Or txtPrice.Text = "" Then
            MsgBox("missing infromation")

        Else

            Dim connStr As String = "Server=127.0.0.1;Database=grocery;Uid=root1;Pwd=;SslMode=none"
            Dim conn As New MySqlConnection(connStr)
            Try
                conn.Open()

                Dim Sql As String = "UPDATE item SET  ItName=@Name, ItQty=@qty, ItPrice=@Price, ItCat@Cat  WHERE ItId=" & key & ""

                'Dim Str As String = "UPDATE item SET ItName='" + txtItname.Text + "',ItQty='" + txtQty.Text + "',ItPrice='" + txtPrice.Text + "' " + "WHERE ItId='" & key & "'"

                Dim Str As String = "UPDATE item SET ItName='" + txtItname.Text + "',ItQty='" + txtQty.Text + "',ItPrice='" + txtPrice.Text + "',ItCat='" + cmbCat.SelectedItem.ToString + "' " + "WHERE ItId='" & key & "'"

                'Dim command As New MySqlCommand(Sql, conn)


                Dim command As New MySqlCommand(Str, conn)



                ' With conn
                'command.Parameters.AddWithValue("@Name", txtItname.Text)
                ' command.Parameters.AddWithValue("@qty", txtQty.Text)
                ' command.Parameters.AddWithValue("@Price", txtPrice.Text)
                ' command.Parameters.AddWithValue("@Cat", cmbCat.SelectedItem.ToString)

                ' End With

                If command.ExecuteNonQuery() = 1 Then
                    MessageBox.Show("New Data Record changed Successfully!!")
                End If
                conn.Close()
                displayItems()
                clear()
            Catch ex As Exception

                MsgBox("error could Not insert to database " + ex.Message, MsgBoxStyle.Exclamation)

            Finally
                conn.Close()
                'updateTable()
            End Try



        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
    Dim key = 0

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtItname.Text = "" Or txtQty.Text = "" Or cmbCat.SelectedIndex = -1 Or txtPrice.Text = "" Then
            MsgBox("missing details")

        Else

            Dim connStr As String = "Server=127.0.0.1;Database=grocery;Uid=root1;Pwd=;SslMode=none"
            Dim conn As New MySqlConnection(connStr)
            Try
                conn.Open()

                'Dim command As New MySqlCommand("INSERT INTO item ( ItName, ItPrice, ItQty) VALUES ( @Name, @Price, @Qty)", conn)

                Dim command As New MySqlCommand("INSERT INTO item ( ItName, ItPrice, ItQty, ItCat ) VALUES(@Name, @Price, @Qty, @Cat)", conn)




                command.Parameters.Add("@Name", MySqlDbType.VarChar).Value = txtItname.Text
                command.Parameters.Add("@Price", MySqlDbType.VarChar).Value = txtPrice.Text
                command.Parameters.Add("@Qty", MySqlDbType.VarChar).Value = txtQty.Text
                command.Parameters.Add("@Cat", MySqlDbType.VarChar).Value = cmbCat.SelectedItem.ToString





                'command.Parameters.Add("@unit_id", MySqlDbType.VarChar).Value = cmbxUnits.SelectedValue.ToString

                If command.ExecuteNonQuery() = 1 Then
                    MessageBox.Show("New Data Record Saved Successfully!!")
                End If
                conn.Close()
                displayItems()
                clear()
            Catch ex As Exception

                MsgBox("error could Not insert to database " + ex.Message, MsgBoxStyle.Exclamation)

            Finally
                conn.Close()
                'updateTable()
            End Try



        End If
    End Sub
    Private Sub clear()
        txtItname.Text = ""
        txtPrice.Text = ""
        txtQty.Text = ""
        cmbCat.SelectedIndex = 0
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        clear()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If key = 0 Then
            MsgBox("select item to deletee")

        Else

            Dim connStr As String = "Server=127.0.0.1;Database=grocery;Uid=root1;Pwd=;SslMode=none"
            Dim conn As New MySqlConnection(connStr)
            Try
                conn.Open()
                Dim q1 As String = "DELETE FROM item WHERE ItId =" & key & ""
                Dim command As New MySqlCommand(q1, conn)






                'command.Parameters.Add("@unit_id", MySqlDbType.VarChar).Value = cmbxUnits.SelectedValue.ToString

                If command.ExecuteNonQuery() = 1 Then
                    MessageBox.Show("New Data Record Deleted Successfully!!")
                End If
                conn.Close()
                displayItems()
                clear()
            Catch ex As Exception

                MsgBox("error could Not DELETE to database " + ex.Message, MsgBoxStyle.Exclamation)

            Finally
                conn.Close()
                'updateTable()
            End Try



        End If
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
        DataGridView1.DataSource = ds.Tables(0)

    End Sub
    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        txtPrice.Text = row.Cells(3).Value.ToString

        txtItname.Text = row.Cells(1).Value.ToString
        txtQty.Text = row.Cells(2).Value.ToString
        cmbCat.SelectedValue = row.Cells(4).Value.ToString

        If txtItname.Text = "" Then
            key = 0
        Else
            key = Convert.ToInt32(row.Cells(0).Value.ToString)
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim obj = New Login
        obj.Show()
        Me.Hide()

    End Sub
End Class