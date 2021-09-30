Partial Class formcryReport
    Partial Public Class DataTable2DataTable
        Private Sub DataTable2DataTable_DataTable2RowChanging(sender As Object, e As DataTable2RowChangeEvent) Handles Me.DataTable2RowChanging

        End Sub

    End Class

    Partial Public Class DataTable1DataTable
        Private Sub DataTable1DataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            '    If (e.Column.ColumnName = Me.BDColumn.ColumnName) Then
            'Add user code here
            '     End If

        End Sub

        Private Sub DataTable1DataTable_DataTable1RowChanging(sender As Object, e As DataTable1RowChangeEvent) Handles Me.DataTable1RowChanging

        End Sub

    End Class
End Class
