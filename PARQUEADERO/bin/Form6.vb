Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration


Public Class Form6



    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try


            _dtvclientes.RowFilter = "placas like '%" & TextBox1.Text & "%'"

        Catch ex As Exception

        End Try


    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _dtsclientes.Reset()


        consulta_datos2()
        DataGridView1.DataSource = _dtvclientes
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick

    End Sub

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        Try

            Form1.TextBox1.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(1).Value
            Form1.TextBox2.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(2).Value
            Form1.TextBox4.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(3).Value
            Form1.TextBox5.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(4).Value
            Form1.TextBox11.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(7).Value
            Me.Close()
        Catch ex As NullReferenceException

        End Try
    End Sub
End Class