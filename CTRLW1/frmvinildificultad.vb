Imports MySql.Data.MySqlClient
Public Class frmvinildificultad
    Function guardar()
        If vtxtdescripcion.Text = "" Or vtxtdescripcion.Text = "" Or vtxtprecio.Text = "" Then

            MsgBox("LLena todos los campos", MsgBoxStyle.Information, "CTRL+y")
        Else

            ' Try


            Dim descripcion As String
            Try

                conexionMysql.Open()

                Dim Sqlx As String
                Sqlx = "select * from vinildificultad where dificultad='" & vtxtdificultad.Text & "';"
                Dim cmdx As New MySqlCommand(Sqlx, conexionMysql)
                reader = cmdx.ExecuteReader()
                reader.Read()
                descripcion = reader.GetString(1).ToString()
                reader.Close()
                conexionMysql.Close()

            Catch ex As Exception
                descripcion = ""
                cerrarconexion()
            End Try

            If descripcion = vtxtdificultad.Text Then

                MsgBox("El nombre ya esta utilizado por otra dificultad, usa uno diferente", MsgBoxStyle.Information, "CTRL+y")
            Else



                conexionMysql.Open()
                Dim Sql As String
                Sql = "INSERT INTO `dwin`.`vinildificultad` (`dificultad`, `descripcion`, `precio`) VALUES ('" & vtxtdificultad.Text & "', '" & vtxtdescripcion.Text & "', '" & vtxtprecio.Text & "');"
                Dim cmd As New MySqlCommand(Sql, conexionMysql)
                cmd.ExecuteNonQuery()
                conexionMysql.Close()
                MsgBox("Registro Guardado", MsgBoxStyle.Information, "CTRL+y")
                ' frmcotizadorvinil.cargardatosdificultad()

                llenadogrilla()

                limpiarcajas()
            End If


            '  Catch ex As Exception
            cerrarconexion()

            ' End Try





        End If

    End Function
    Private Sub Button78_Click(sender As Object, e As EventArgs) Handles Button78.Click

        guardar()

    End Sub
    Function limpiarcajas()

        vtxtdescripcion.Text = ""
        vtxtdificultad.Text = ""
        vtxtprecio.Text = ""

    End Function
    Function llenadogrilla()

        'grilla.Rows.Clear()


        cerrarconexion()


        conexionMysql.Open()
        Dim Sql As String
        Sql = "select * from vinildificultad;"
        Dim cmd As New MySqlCommand(Sql, conexionMysql)
        Dim dt As New DataTable
        Dim da As New MySqlDataAdapter(cmd)
        'cargamos el formulario  resumen
        da.Fill(dt)
        grilla.DataSource = dt


        'sgrilla.Columns(0).Width = 350
        conexionMysql.Close()
    End Function
    Function cerrarconexion()
        If conexionMysql.State = ConnectionState.Open Then
            conexionMysql.Close()

        End If
    End Function
    Function actualizar()
        'Try
        conexionMysql.Open()
        Dim Sql5 As String
        Sql5 = "UPDATE vinildificultad SET descripcion='" & vtxtdescripcion.Text & "', precio='" & vtxtprecio.Text & "' WHERE dificultad='" & vtxtdificultad.Text & "';"
        Dim cmd5 As New MySqlCommand(Sql5, conexionMysql)
        cmd5.ExecuteNonQuery()
        MsgBox("Registro actualizado", MsgBoxStyle.Information, "CTRL+y")
        conexionMysql.Close()
        llenadogrilla()
        limpiarcajas()

        'Catch ex As Exception
        cerrarconexion()
        'End Try

    End Function
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        actualizar()
    End Sub

    Private Sub Frmvinildificultad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grilla.DefaultCellStyle.Font = New Font("Arial", 16)
        grilla.RowHeadersVisible = False
        grilla.AlternatingRowsDefaultCellStyle.BackColor = Color.SkyBlue

        llenadogrilla()
    End Sub
    Function cancelar()
        Me.Close()
        frmcotizadorvinil.cargardificultad()

    End Function
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        cancelar()

    End Sub

    Private Sub Vtxtdificultad_TextChanged(sender As Object, e As EventArgs) Handles vtxtdificultad.TextChanged

    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grilla.CellContentClick
        Try

            Dim Variable As String = grilla.Item(1, grilla.CurrentRow.Index).Value
            'MsgBox(Variable)


            conexionMysql.Open()

            Dim Sqlx As String
            Sqlx = "select * from vinildificultad where dificultad='" & Variable & "';"
            Dim cmdx As New MySqlCommand(Sqlx, conexionMysql)
            reader = cmdx.ExecuteReader()
            reader.Read()
            vtxtdificultad.Text = reader.GetString(1).ToString()
            vtxtdescripcion.Text = reader.GetString(2).ToString()
            vtxtprecio.Text = reader.GetString(3).ToString()

            reader.Close()
            conexionMysql.Close()



        Catch ex As Exception
            cerrarconexion()
        End Try
    End Sub

    Private Sub grilla_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grilla.CellContentDoubleClick
        Try

            Dim Variable As String = grilla.Item(1, grilla.CurrentRow.Index).Value
            'MsgBox(Variable)


            conexionMysql.Open()

            Dim Sqlx As String
            Sqlx = "select * from vinildificultad where dificultad='" & Variable & "';"
            Dim cmdx As New MySqlCommand(Sqlx, conexionMysql)
            reader = cmdx.ExecuteReader()
            reader.Read()
            vtxtdificultad.Text = reader.GetString(1).ToString()
            vtxtdescripcion.Text = reader.GetString(2).ToString()
            vtxtprecio.Text = reader.GetString(3).ToString()

            reader.Close()
            conexionMysql.Close()



        Catch ex As Exception
            cerrarconexion()
        End Try
    End Sub
    Function eliminar()
        Try
            conexionMysql.Open()
            Dim Sql5 As String
            Sql5 = "delete from vinildificultad WHERE dificultad='" & vtxtdificultad.Text & "';"
            Dim cmd5 As New MySqlCommand(Sql5, conexionMysql)
            cmd5.ExecuteNonQuery()
            MsgBox("Registro eliminado", MsgBoxStyle.Information, "CTRL+y")
            conexionMysql.Close()
            llenadogrilla()
            limpiarcajas()

        Catch ex As Exception
            cerrarconexion()
        End Try
    End Function
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        eliminar()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        limpiarcajas()


    End Sub

    Private Sub Vtxtprecio_TextChanged(sender As Object, e As EventArgs) Handles vtxtprecio.TextChanged

    End Sub

    Private Sub vtxtprecio_KeyDown(sender As Object, e As KeyEventArgs) Handles vtxtprecio.KeyDown
        If e.KeyCode = Keys.F1 Then
            guardar()
        ElseIf e.KeyCode = Keys.F2 Then
            actualizar()
        ElseIf e.KeyCode = Keys.F3 Then
            eliminar()
        ElseIf e.KeyCode = Keys.Escape Then
            cancelar()
        ElseIf e.KeyCode = Keys.F4 Then
            limpiarcajas()
        End If
    End Sub

    Private Sub Vtxtdescripcion_TextChanged(sender As Object, e As EventArgs) Handles vtxtdescripcion.TextChanged

    End Sub

    Private Sub vtxtdescripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles vtxtdescripcion.KeyDown
        If e.KeyCode = Keys.F1 Then
            guardar()
        ElseIf e.KeyCode = Keys.F2 Then
            actualizar()
        ElseIf e.KeyCode = Keys.F3 Then
            eliminar()
        ElseIf e.KeyCode = Keys.Escape Then
            cancelar()
        ElseIf e.KeyCode = Keys.F4 Then
            limpiarcajas()
        End If
    End Sub

    Private Sub vtxtdificultad_KeyDown(sender As Object, e As KeyEventArgs) Handles vtxtdificultad.KeyDown
        If e.KeyCode = Keys.F1 Then
            guardar()
        ElseIf e.KeyCode = Keys.F2 Then
            actualizar()
        ElseIf e.KeyCode = Keys.F3 Then
            eliminar()
        ElseIf e.KeyCode = Keys.Escape Then
            cancelar()
        ElseIf e.KeyCode = Keys.F4 Then
            limpiarcajas()
        End If
    End Sub
End Class