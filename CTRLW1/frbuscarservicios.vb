

Imports MySql.Data.MySqlClient
Public Class frbuscarservicios


    Private Sub ctxtdescripcion_TextChanged(sender As Object, e As EventArgs) Handles txtnombreproducto.TextChanged
        'Try

        Dim tipo_usuario As String

        cerrarconexion()

        conexionMysql.Open()
        Dim Sql As String
        Sql = "select idproducto, descripcion from producto where descripcion like '%" & txtnombreproducto.Text & "%';"
        Dim cmd As New MySqlCommand(Sql, conexionMysql)
        Dim dt As New DataTable
        Dim da As New MySqlDataAdapter(cmd)
        'cargamos el formulario  resumen
        da.Fill(dt)
        grilla.DataSource = dt
        'grilla.DataSource = dt
        grilla.Columns(1).Width = 260
        grilla.Columns(0).Width = 60
        conexionMysql.Close()
        'Catch ex As Exception
        'End Try
    End Sub
    Function cerrarconexion()
        If conexionMysql.State = ConnectionState.Open Then
            conexionMysql.Close()

        End If
    End Function
    Private Sub frbuscarprocompras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grilla.DefaultCellStyle.Font = New Font("Arial", 16)
        grilla.RowHeadersVisible = False


    End Sub


    Private Sub grilla_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grilla.CellContentDoubleClick
        Try
            Dim Variable As String = grilla.Item(0, grilla.CurrentRow.Index).Value
            MsgBox(Variable)
            'MsgBox(Variable)
            'al obtener el valor lo mandamos al id de la ventana.
            servicios.txtclave.Text = Variable
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frbuscarprocompras_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        servicios.txtnombre.Focus()


    End Sub

    Private Sub grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grilla.CellContentClick

    End Sub
End Class