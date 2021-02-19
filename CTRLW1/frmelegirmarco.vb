Imports System.ComponentModel
Imports MySql.Data.MySqlClient
Public Class frmelegirmarco
    Dim marco, costomarco As String
    Private Sub Frmelegirmarco_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrarmarcos()
    End Sub
    Function mostrarmarcos()



        '        cerrarconexion()

        conexionMysql.Open()
        Dim Sql As String
        Sql = "select * from cotizador_marco;"
        Dim cmd As New MySqlCommand(Sql, conexionMysql)
        Dim dt As New DataTable
        Dim da As New MySqlDataAdapter(cmd)
        'cargamos el formulario  resumen
        da.Fill(dt)
        bgrilla.DataSource = dt
        conexionMysql.Close()


    End Function

    Private Sub Bgrilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles bgrilla.CellContentClick

    End Sub

    Private Sub bgrilla_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles bgrilla.CellContentDoubleClick

    End Sub

    Private Sub bgrilla_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles bgrilla.CellMouseDoubleClick
        Try
            Dim id, valor As String
            Dim Variable As String = bgrilla.Item(0, bgrilla.CurrentRow.Index).Value
            Dim Variable2 As String = bgrilla.Item(1, bgrilla.CurrentRow.Index).Value
            Dim Variable3 As String = bgrilla.Item(2, bgrilla.CurrentRow.Index).Value
            MsgBox(Variable)
            'Variable
            'grilla2.Visible = False
            'grilla.Visible = True
            'rbclave.Checked = True

            id = MsgBox("¿Deseas elegir el marco numero " + Variable + "?", MsgBoxStyle.YesNoCancel, "CTR+y")
            If id = vbYes Then
                MsgBox(Variable2)
                frmgastosgralesserigrafia.txtmarco.Text = Variable2
                frmgastosgralesserigrafia.txtcostomarco.Text = Variable3
                marco = Variable2
                costomarco = Variable3
                Me.Close()



            End If





        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmelegirmarco_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        frmgastosgralesserigrafia.txtmarco.Text = marco
        frmgastosgralesserigrafia.txtcostomarco.Text = costomarco

    End Sub
End Class