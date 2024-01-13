Public Class frmCOTIZARLONA
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim formulario As New frmnuevovinil
        'FRagregaranticipo.ShowDialog()
        formulario.ShowDialog()
    End Sub

    Private Sub Vtxtnombreproducto_TextChanged(sender As Object, e As EventArgs)
        'grilla2.Visible = False

        'lblistaproductos.Visible = True
        'lblistaproductos.Items.Clear()

        'If vtxtnombreproducto.Text = "" Then
        '    lblistaproductos.Visible = False
        '    'sborrar()
        '    'stxtclave.Text = ""


        'Else

        '    Try

        '        'cerramos la conexion
        '        cerrarconexion()

        '        Dim cantidad, i As Integer
        '        cantidad = 0
        '        conexionMysql.Open()
        '        Dim Sql2 As String
        '        Sql2 = "select count(*) from vinilproducto where nombre_producto like '%" & vtxtnombreproducto.Text & "%';"
        '        Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
        '        reader = cmd2.ExecuteReader
        '        reader.Read()
        '        cantidad = reader.GetString(0).ToString

        '        'cargamos el formulario  resumen
        '        conexionMysql.Close()

        '        'MsgBox("hay tantos resultados:" & cantidad)

        '        cerrarconexion()


        '        conexionMysql.Open()
        '        Dim Sql As String
        '        Sql = "select nombre_producto from vinilproducto where nombre_producto like '%" & vtxtnombreproducto.Text & "%';"
        '        Dim cmd As New MySqlCommand(Sql, conexionMysql)
        '        reader = cmd.ExecuteReader
        '        For i = 1 To cantidad
        '            reader.Read()

        '            lblistaproductos.Items.Add(reader.GetString(0).ToString)
        '        Next


        '        conexionMysql.Close()

        '    Catch ex As Exception
        '        cerrarconexion()
        '    End Try
        'End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class