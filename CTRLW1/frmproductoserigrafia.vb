Imports MySql.Data.MySqlClient
Public Class frmproductoserigrafia
    Private Sub Button69_Click(sender As Object, e As EventArgs)



    End Sub

    Private Sub Txtpscantidad_contenido_TextChanged(sender As Object, e As EventArgs) Handles txtpscantidad_contenido.TextChanged
        calculo()
    End Sub

    Private Sub Txtpscosto_TextChanged(sender As Object, e As EventArgs) Handles txtpscosto.TextChanged
        calculo()
    End Sub
    Function limpiar()
        'txtpsclave.Text = ""
        txtpscantidad.Text = ""
        txtpscantidad_contenido.Text = ""
        txtpscosto.Text = ""
        txtpsdescripcion.Text = ""
        txtpsprecio.Text = ""
        txtpsprecioml.Text = ""
        txtpstipomedida.Text = ""

    End Function
    Function llenadogrilla()
        conexionMysql.Open()
        Dim Sql As String
        Sql = "select * from producto_serigrafia"
        Dim cmd As New MySqlCommand(Sql, conexionMysql)
        Dim dt As New DataTable
        Dim da As New MySqlDataAdapter(cmd)
        'cargamos el formulario  resumen
        da.Fill(dt)
        sgrilla.DataSource = dt
        sgrilla.Columns(1).Width = 350
        sgrilla.Columns(0).Width = 60
        conexionMysql.Close()
    End Function

    Private Sub Frmproductoserigrafia_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        sgrilla.DefaultCellStyle.Font = New Font("Arial", 20)
        sgrilla.RowHeadersVisible = False

        sgrilla.AlternatingRowsDefaultCellStyle.BackColor = Color.SkyBlue
        llenadogrilla()


    End Sub
    Function calculo()
        Try
            Dim a, b, c As Double
            a = CDbl(txtpscosto.Text) / CDbl(txtpscantidad_contenido.Text)



            b = CDbl(a)

            txtpsprecioml.Text = Math.Round(b, 2)
        Catch ex As Exception

        End Try

    End Function
    Function cerrarconexion()
        If conexionMysql.State = ConnectionState.Open Then
            conexionMysql.Close()


        End If
    End Function
    Private Sub Txtpsclave_TextChanged(sender As Object, e As EventArgs) Handles txtpsclave.TextChanged


        If txtpsclave.Text = "" Or txtpsclave.Text = "0" Then
            limpiar()
        Else

            Try
                Dim cantidad As Integer

                respuesta = vbYes


                cerrarconexion()


                conexionMysql.Open()
                Dim Sql As String
                Sql = "select * from producto_serigrafia where idproducto_serigrafia='" & txtpsclave.Text & "';"
                Dim cmd As New MySqlCommand(Sql, conexionMysql)
                reader = cmd.ExecuteReader()
                reader.Read()
                txtpsdescripcion.Text = reader.GetString(1).ToString()
                txtpscosto.Text = reader.GetString(2).ToString()
                txtpsprecio.Text = reader.GetString(3).ToString()
                txtpscantidad.Text = reader.GetString(4).ToString
                txtpstipomedida.Text = reader.GetString(5).ToString
                txtpscantidad_contenido.Text = reader.GetString(6).ToString
                txtpsprecioml.Text = reader.GetString(7).ToString

                ''si encuentra el valor, llamamos al focus del boton.
                'Button17.Focus()

                reader.Close()

                conexionMysql.Close()

            Catch ex As Exception
                cerrarconexion()
                limpiar()

            End Try





        End If

    End Sub

    Private Sub Button39_Click(sender As Object, e As EventArgs)



    End Sub

    Private Sub Button40_Click(sender As Object, e As EventArgs)

    End Sub
    Function guardar()

        conexionMysql.Close()


        'BTNINSERTAR



        If txtpsclave.Text = "" Or txtpsdescripcion.Text = "" Or txtpscantidad.Text = "" Or txtpscantidad_contenido.Text = "" Or txtpscosto.Text = "" Or txtpsprecio.Text = "" Or txtpsprecioml.Text = "" Or txtpstipomedida.Text = "" Then
            MsgBox("Falta información en tu registro, verifica", MsgBoxStyle.Information, "CTRL+y")
        Else

            Dim id As String
            Try

                conexionMysql.Open()
                Dim Sql2 As String
                Sql2 = "select * from producto_serigrafia where idproducto_serigrafia='" & txtpsclave.Text & "'"
                Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
                reader = cmd2.ExecuteReader
                reader.Read()
                id = reader.GetString(0).ToString            'cargamos el formulario  resumen
                conexionMysql.Close()
            Catch ex As Exception

                id = ""
                conexionMysql.Close()

            End Try



            If id = txtpsclave.Text Then
                MsgBox("La clave del producto ya existe, intenta otro", MsgBoxStyle.Information, "CTRL+y")


            Else



                Try

                    conexionMysql.Open()
                    Dim Sql As String
                    Sql = "INSERT INTO `dwin`.`producto_serigrafia` (`idproducto_serigrafia`, `nombre`, `costo`, `precio`, `cantidad`, `medida`, `cantidad_contenido`,`costo_unidad`) VALUES ('" & txtpsclave.Text & "', '" & txtpsdescripcion.Text & "', '" & txtpscosto.Text & "', '" & txtpsprecio.Text & "', '" & txtpscantidad.Text & "', '" & txtpstipomedida.Text & "','" & txtpscantidad_contenido.Text & "' ,'" & txtpsprecioml.Text & "');"
                    Dim cmd As New MySqlCommand(Sql, conexionMysql)
                    cmd.ExecuteNonQuery()
                    MsgBox("Registro Guardado", MsgBoxStyle.Information, "Sistema")
                    conexionMysql.Close()
                    limpiar()
                    llenadogrilla()

                Catch ex As Exception
                    conexionMysql.Close()
                    MsgBox("Se ha provoado un error", MsgBoxStyle.Exclamation, "CTRL+y")

                End Try
            End If

        End If
    End Function
    Private Sub Btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click

        guardar()

    End Sub
    Function actualizar()
        Try




            Dim id As String

            Try

                conexionMysql.Open()
                Dim Sql3 As String
                Sql3 = "select * from producto_serigrafia where idproducto_serigrafia='" & txtpsclave.Text & "';"
                Dim cmd3 As New MySqlCommand(Sql3, conexionMysql)
                reader = cmd3.ExecuteReader()
                reader.Read()
                id = reader.GetString(0).ToString()

                reader.Close()

                conexionMysql.Close()

            Catch ex As Exception
                id = ""
            End Try


            If id = "" Then
                MsgBox("La clave no existe para actualizar, verifica tu proceso", MsgBoxStyle.Information, "CTRL+y")
            Else

                conexionMysql.Open()
                Dim Sql As String
                Sql = "update producto_serigrafia set nombre='" & txtpsdescripcion.Text & "', costo='" & txtpscosto.Text & "', precio='" & txtpsprecio.Text & "',cantidad='" & txtpscantidad.Text & "',medida='" & txtpstipomedida.Text & "',cantidad_contenido='" & txtpscantidad_contenido.Text & "', costo_unidad='" & txtpsprecioml.Text & "' where idproducto_serigrafia='" & txtpsclave.Text & "';"
                Dim cmd As New MySqlCommand(Sql, conexionMysql)
                cmd.ExecuteNonQuery()
                MsgBox("Registro actualizado", MsgBoxStyle.Information, "Sistema")
                conexionMysql.Close()
                limpiar()
                txtpsclave.Text = ""
                llenadogrilla()
            End If

        Catch ex As Exception
            conexionMysql.Close()
            MsgBox("Se ha provocado un error", MsgBoxStyle.Exclamation, "CTRL+y")
        End Try

    End Function
    Private Sub Btnactualizar_Click(sender As Object, e As EventArgs) Handles btnactualizar.Click

        actualizar()
    End Sub
    Function eliminar()
        Try
            Dim id As String

            Try

                conexionMysql.Open()
                Dim Sql3 As String
                Sql3 = "select * from producto_serigrafia where idproducto_serigrafia='" & txtpsclave.Text & "';"
                Dim cmd3 As New MySqlCommand(Sql3, conexionMysql)
                reader = cmd3.ExecuteReader()
                reader.Read()
                id = reader.GetString(0).ToString()

                reader.Close()

                conexionMysql.Close()

            Catch ex As Exception
                id = ""
            End Try


            If id = "" Then
                MsgBox("La clave no existe para actualizar, verifica tu proceso", MsgBoxStyle.Information, "CTRL+y")
            Else



                conexionMysql.Open()
            Dim Sql As String
            Sql = "delete from producto_serigrafia where idproducto_serigrafia='" & txtpsclave.Text & "';"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            cmd.ExecuteNonQuery()
            MsgBox("Registro eliminado", MsgBoxStyle.Information, "Sistema")
            conexionMysql.Close()
            limpiar()
            txtpsclave.Text = ""
            llenadogrilla()

            End If

        Catch ex As Exception
            conexionMysql.Close()
            MsgBox("Se ha provocado un error", MsgBoxStyle.Exclamation, "CTRL+y")
        End Try

    End Function
    Private Sub Btneliminar_Click(sender As Object, e As EventArgs) Handles btneliminar.Click

        eliminar()


    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Close()
    End Sub
End Class