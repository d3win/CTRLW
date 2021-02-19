Imports MySql.Data.MySqlClient
Public Class frmnuevovinil
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub Vtxtlargo_TextChanged(sender As Object, e As EventArgs) Handles vtxt3largocm.TextChanged

        calcularcostoxcm()

        calculocostounitario()

        'calculocmdisponibles()


    End Sub
    Function calculocmdisponibles()

        Try

            '   vtxt5cmdisponibles.Text = CDbl(vtxt3largocm.Text) * CDbl(vtxt4anchocm.Text)
        Catch ex As Exception

        End Try



    End Function

    Private Sub Vtxtancho_TextChanged(sender As Object, e As EventArgs) Handles vtxt4anchocm.TextChanged


        calculocostounitario()
        calcularcostoxcm()




        ' calculocmdisponibles()
        'calculototalinvertido()
        'calculoprecioxcm()
        'calculotest()

    End Sub

    Private Sub Vtxtcostometro_TextChanged(sender As Object, e As EventArgs) Handles txtcostometro.TextChanged
        Try
            calculocostounitario()


        Catch ex As Exception

        End Try

    End Sub








    Private Sub Button78_Click(sender As Object, e As EventArgs) Handles Button78.Click

        If vtxt1claveproducto.Text = "" Or vtxt2nombreproducto.Text = "" Or vtxt3largocm.Text = "" Or vtxt4anchocm.Text = "" Or vtxt5cmdisponibles.Text = "" Or txtcostometro.Text = "" Or vtxt8costoxcm.Text = "" Or vtxt10precioxcm.Text = "" Then

            MsgBox("LLena todos los campos", MsgBoxStyle.Information, "CTRL+y")
        Else

            Try

                Dim clave As String
                'primero verificamos que exista el id, para poder actializarlos
                '---------------------------------------------------------------------------------------------
                Try

                    conexionMysql.Open()
                    Dim Sql2 As String
                    Sql2 = "select * from vinilproducto where idproductovinil='" & vtxt1claveproducto.Text & "';"
                    Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
                    reader = cmd2.ExecuteReader()
                    reader.Read()
                    clave = reader.GetString(0).ToString()
                    reader.Close()
                    conexionMysql.Close()
                Catch ex As Exception
                    clave = ""
                    cerrarconexion()
                End Try

                '-------------------------------------------------------------------------------------
                If clave <> "" Then
                    MsgBox("La clave ya existe", MsgBoxStyle.Information, "CTRL+y")

                Else




                    conexionMysql.Open()
                    Dim Sql As String
                    Sql = "INSERT INTO `dwin`.`vinilproducto` (`idproductovinil`, `nombre_producto`, `largo`, `ancho`, `cmdisponibles`, `costoxm`, `costoxcm`, `precioxm`, `precioxcm`, `cantidadvinil`, `iva`, `utilidad`, `transfer`, `mantenimiento`, `mobra`, `desperdicio`,`costounitario`,`flete`) VALUES ('" & vtxt1claveproducto.Text & "', '" & vtxt2nombreproducto.Text & "', '" & vtxt3largocm.Text & "', '" & vtxt4anchocm.Text & "', '" & vtxt5cmdisponibles.Text & "', '" & txtcostometro.Text & "', '" & vtxt8costoxcm.Text & "', '" & txtprecioxmetro.Text & "', '" & vtxt10precioxcm.Text & "', '" & txtcantidadtotalvinil.Text & "', '" & txtiva.Text & "', '" & txtutilidad.Text & "', '" & txttransfer.Text & "', '" & txtmantenimiento.Text & "', '" & txtmobra.Text & "', '" & txtdesperdicio.Text & "','" & txtcostounitario.Text & "','" & txtflete.Text & "');"
                    Dim cmd As New MySqlCommand(Sql, conexionMysql)
                    cmd.ExecuteNonQuery()
                    conexionMysql.Close()
                    MsgBox("Registro Guardado", MsgBoxStyle.Information, "CTRL+y")
                    llenadogrilla()

                    limpiarcajas()

                End If

            Catch ex As Exception
                cerrarconexion()

            End Try

        End If



    End Sub
    Function cargarproductovinil()

        conexionMysql.Open()


        Dim command As New MySqlCommand("select * from vinilproducto;", conexionMysql)

        Dim adapter As New MySqlDataAdapter
        Dim dt As New DataTable
        adapter.SelectCommand = command
        adapter.Fill(dt)
        grilla.DataSource = dt
        adapter.Dispose()
        command.Dispose()
        conexionMysql.Close()

    End Function
    Function limpiarcajas()
        vtxt1claveproducto.Text = ""
        vtxt2nombreproducto.Text = ""
        vtxt3largocm.Text = ""
        vtxt4anchocm.Text = ""
        vtxt5cmdisponibles.Text = ""
        txtcostometro.Text = ""
        ' vtxt7totalinvertido.Text = ""
        vtxt8costoxcm.Text = ""
        'vtxt9valoragregado.Text = ""
        vtxt10precioxcm.Text = ""
        vtxt1claveproducto.Text = ""
        vtxt2nombreproducto.Text = ""
        vtxt3largocm.Text = ""
        vtxt4anchocm.Text = ""
        vtxt5cmdisponibles.Text = ""
        txtcostometro.Text = ""
        vtxt8costoxcm.Text = ""
        txtprecioxmetro.Text = ""
        vtxt10precioxcm.Text = ""
        txtcantidadtotalvinil.Text = ""
        txtiva.Text = ""
        txtutilidad.Text = ""
        txttransfer.Text = ""
        txtmantenimiento.Text = ""
        txtmobra.Text = ""
        txtdesperdicio.Text = ""
        txtcostounitario.Text = ""
        txtflete.Text = ""

    End Function
    Function llenadogrilla()

        'grilla.Rows.Clear()


        cerrarconexion()


        conexionMysql.Open()
        Dim Sql As String
        Sql = "select * from vinilproducto;"
        Dim cmd As New MySqlCommand(Sql, conexionMysql)
        Dim dt As New DataTable
        Dim da As New MySqlDataAdapter(cmd)
        'cargamos el formulario  resumen
        da.Fill(dt)
        grilla.DataSource = dt
        grilla.Columns(0).Width = 50
        grilla.Columns(1).Width = 400

        conexionMysql.Close()

        'cambiamos los nombres de los encabezados
        '        grilla.Columns[3].HeaderText = "Cédula de identidad";
        grilla.Columns(0).HeaderText = "ID"
        grilla.Columns(1).HeaderText = "PRODUCTO"
        grilla.Columns(2).HeaderText = "LARGO(cm)"
        grilla.Columns(3).HeaderText = "ANCHO(cm)"
        grilla.Columns(4).HeaderText = "cm Disponible"
        grilla.Columns(5).HeaderText = "Costo x m."
        grilla.Columns(6).HeaderText = "Total Invertido"
        grilla.Columns(7).HeaderText = "Costo x cm"
        grilla.Columns(8).HeaderText = "Valor Agregado"
        grilla.Columns(9).HeaderText = "Precio x cm"



    End Function
    Private Sub Frmnuevovinil_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grilla.DefaultCellStyle.Font = New Font("Arial", 16)
        grilla.RowHeadersVisible = False
        grilla.AlternatingRowsDefaultCellStyle.BackColor = Color.SkyBlue

        llenadogrilla()
    End Sub
    Function cerrarconexion()
        If conexionMysql.State = ConnectionState.Open Then
            conexionMysql.Close()

        End If
    End Function

    Private Sub Vtxt1claveproducto_TextChanged(sender As Object, e As EventArgs) Handles vtxt1claveproducto.TextChanged

        Try


            If vtxt1claveproducto.Text = "" Then

                limpiarcajas()


            Else



                cerrarconexion()




                conexionMysql.Open()

                Dim Sql As String
                Sql = "select * from vinilproducto where idproductovinil='" & vtxt1claveproducto.Text & "';"
                Dim cmd As New MySqlCommand(Sql, conexionMysql)
                reader = cmd.ExecuteReader()
                reader.Read()
                vtxt2nombreproducto.Text = reader.GetString(1).ToString()

                reader.Close()




                conexionMysql.Close()

                conexionMysql.Open()

                Dim Sql2 As String
                Sql2 = "select * from vinilproducto where idproductovinil='" & vtxt1claveproducto.Text & "';"
                Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
                reader = cmd2.ExecuteReader()
                reader.Read()
                'vtxt2nombreproducto.Text = reader.GetString().ToString()


                vtxt3largocm.Text = reader.GetString(2).ToString()
                vtxt4anchocm.Text = reader.GetString(3).ToString()
                vtxt5cmdisponibles.Text = reader.GetString(4).ToString()
                txtcostometro.Text = reader.GetString(5).ToString()
                vtxt8costoxcm.Text = reader.GetString(6).ToString()
                txtprecioxmetro.Text = reader.GetString(7).ToString()
                vtxt10precioxcm.Text = reader.GetString(8).ToString()
                txtcantidadtotalvinil.Text = reader.GetString(9).ToString()
                txtiva.Text = reader.GetString(10).ToString()
                txtutilidad.Text = reader.GetString(11).ToString()
                txttransfer.Text = reader.GetString(12).ToString()
                txtmantenimiento.Text = reader.GetString(13).ToString()
                txtmobra.Text = reader.GetString(14).ToString()
                txtdesperdicio.Text = reader.GetString(15).ToString()
                txtcostounitario.Text = reader.GetString(16).ToString()
                txtflete.Text = reader.GetString(17).ToString()



                reader.Close()


                conexionMysql.Close()


            End If

        Catch ex As Exception
            cerrarconexion()
            '            vtxt1claveproducto.Text = ""



        End Try
    End Sub

    Private Sub Vtxt2nombreproducto_TextChanged(sender As Object, e As EventArgs) Handles vtxt2nombreproducto.TextChanged

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles btnactualizar.Click
        If vtxt1claveproducto.Text = "" Or vtxt2nombreproducto.Text = "" Or vtxt3largocm.Text = "" Or vtxt4anchocm.Text = "" Or vtxt5cmdisponibles.Text = "" Or txtcostometro.Text = "" Or vtxt8costoxcm.Text = "" Or vtxt10precioxcm.Text = "" Then

            MsgBox("LLena todos los campos", MsgBoxStyle.Information, "CTRL+y")
        Else

            Try
                Dim clave As String

                'primero verificamos que exista el id, para poder actializarlos
                '---------------------------------------------------------------------------------------------
                Try

                    conexionMysql.Open()
                    Dim Sql2 As String
                    Sql2 = "select * from vinilproducto where idproductovinil='" & vtxt1claveproducto.Text & "';"
                    Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
                    reader = cmd2.ExecuteReader()
                    reader.Read()
                    clave = reader.GetString(0).ToString()
                    reader.Close()
                    conexionMysql.Close()
                Catch ex As Exception
                    clave = ""
                    cerrarconexion()
                End Try

                '-------------------------------------------------------------------------------------
                If clave = "" Then
                    MsgBox("La clave no existe, verifica tu información", MsgBoxStyle.Information, "CTRL+y")

                Else



                    conexionMysql.Open()
                    Dim Sql As String
                    Sql = "UPDATE `dwin`.`vinilproducto` SET `nombre_producto` = '" & vtxt2nombreproducto.Text & "', `largo` = '" & vtxt3largocm.Text & "', `ancho` = '" & vtxt4anchocm.Text & "', `cmdisponibles` = '" & vtxt5cmdisponibles.Text & "', `costoxm` = '" & txtcostometro.Text & "', `costoxcm` = '" & vtxt8costoxcm.Text & "', `precioxm` = '" & txtprecioxmetro.Text & "', `precioxcm` = '" & vtxt10precioxcm.Text & "', `cantidadvinil` = '" & txtcantidadtotalvinil.Text & "', `iva` = '" & txtiva.Text & "', `utilidad` = '" & txtutilidad.Text & "', `transfer` = '" & txttransfer.Text & "', `mantenimiento` = '" & txtmantenimiento.Text & "', `mobra` = '" & txtmobra.Text & "', `desperdicio` = '" & txtdesperdicio.Text & "', `costounitario` = '" & txtcostounitario.Text & "', `flete`='" & txtflete.Text & "' WHERE (`idproductovinil` = '" & vtxt1claveproducto.Text & "');"
                    Dim cmd As New MySqlCommand(Sql, conexionMysql)
                    cmd.ExecuteNonQuery()
                    conexionMysql.Close()
                    MsgBox("Registro Actualizado", MsgBoxStyle.Information, "CTRL+y")
                    llenadogrilla()

                    limpiarcajas()
                End If

            Catch ex As Exception
                cerrarconexion()

            End Try


        End If

    End Sub

    Private Sub Btneliminar_Click(sender As Object, e As EventArgs) Handles btneliminar.Click
        cerrarconexion()

        If vtxt1claveproducto.Text = "" Or vtxt2nombreproducto.Text = "" Then

            MsgBox("LLena todos los campos", MsgBoxStyle.Information, "CTRL+y")
        Else

            Try

                Dim clave As String

                'primero verificamos que exista el id, para poder actializarlos
                '---------------------------------------------------------------------------------------------
                Try

                    conexionMysql.Open()
                    Dim Sql2 As String
                    Sql2 = "select * from vinilproducto where idproductovinil='" & vtxt1claveproducto.Text & "';"
                    Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
                    reader = cmd2.ExecuteReader()
                    reader.Read()
                    clave = reader.GetString(0).ToString()
                    reader.Close()
                    conexionMysql.Close()
                Catch ex As Exception
                    clave = ""
                    cerrarconexion()
                End Try

                '-------------------------------------------------------------------------------------
                If clave = "" Then
                    MsgBox("La clave no existe, verifica tu información", MsgBoxStyle.Information, "CTRL+y")
                    cerrarconexion()
                Else
                    cerrarconexion()
                    conexionMysql.Open()
                    Dim Sql As String
                    Sql = "delete from vinilproducto where idproductovinil='" & vtxt1claveproducto.Text & "';"
                    Dim cmd As New MySqlCommand(Sql, conexionMysql)
                    cmd.ExecuteNonQuery()
                    conexionMysql.Close()
                    MsgBox("Registro Eliminado", MsgBoxStyle.Information, "CTRL+y")
                    llenadogrilla()

                    limpiarcajas()
                End If

            Catch ex As Exception
                cerrarconexion()

                End Try


        End If


    End Sub

    Private Sub Vtxt10precioxcm_TextChanged(sender As Object, e As EventArgs) Handles vtxt10precioxcm.TextChanged

    End Sub

    Function calculocostounitario()

        Try

            Dim flete, iva, utilidad, transfer, costomlineal, re1 As Double

            flete = CDbl(txtflete.Text) / CDbl(txtcantidadtotalvinil.Text)
            iva = CDbl(txtcostometro.Text) * CDbl(txtiva.Text)
            'MsgBox("iva" & iva)
            utilidad = CDbl(iva) * CDbl(txtutilidad.Text)
            'MsgBox("utilidad" & utilidad)
            re1 = flete + utilidad
            txtcostounitario.Text = Math.Round(re1, 3)




            transfer = CDbl(txttransfer.Text) + CDbl(txtcostounitario.Text)

            costomlineal = CDbl(transfer) * CDbl(txtmantenimiento.Text) * CDbl(txtmobra.Text) * CDbl(txtdesperdicio.Text)

            txtprecioxmetro.Text = Math.Round(costomlineal, 3)




            'calculamos los cm2 disponibles
            vtxt5cmdisponibles.Text = (CDbl(vtxt3largocm.Text) * CDbl(vtxt4anchocm.Text)) * CDbl(txtcantidadtotalvinil.Text)

            Dim ancho, alto, totalcmxm, re2 As Double
            totalcmxm = CDbl(vtxt3largocm.Text) * CDbl(vtxt4anchocm.Text)


            re2 = CDbl(txtprecioxmetro.Text) / CDbl(totalcmxm)
            vtxt10precioxcm.Text = Math.Round(re2, 3)




        Catch ex As Exception

        End Try






    End Function

    Private Sub Txtcantidadtotalvinil_TextChanged(sender As Object, e As EventArgs) Handles txtcantidadtotalvinil.TextChanged
        calculocostounitario()

    End Sub

    Private Sub Txtflete_TextChanged(sender As Object, e As EventArgs) Handles txtflete.TextChanged
        calculocostounitario()

    End Sub

    Private Sub Txtiva_TextChanged(sender As Object, e As EventArgs) Handles txtiva.TextChanged
        calculocostounitario()

    End Sub

    Private Sub Txtutilidad_TextChanged(sender As Object, e As EventArgs) Handles txtutilidad.TextChanged
        calculocostounitario()

    End Sub

    Private Sub Txttransfer_TextChanged(sender As Object, e As EventArgs) Handles txttransfer.TextChanged
        calculocostounitario()

    End Sub

    Private Sub Txtmantenimiento_TextChanged(sender As Object, e As EventArgs) Handles txtmantenimiento.TextChanged
        calculocostounitario()

    End Sub

    Private Sub Txtmobra_TextChanged(sender As Object, e As EventArgs) Handles txtmobra.TextChanged
        calculocostounitario()

    End Sub

    Private Sub Txtdesperdicio_TextChanged(sender As Object, e As EventArgs) Handles txtdesperdicio.TextChanged
        calculocostounitario()

    End Sub

    Private Sub Vtxt5cmdisponibles_TextChanged(sender As Object, e As EventArgs) Handles vtxt5cmdisponibles.TextChanged
        calculocostounitario()

    End Sub

    Private Sub Txtprecioxmetro_TextChanged(sender As Object, e As EventArgs) Handles txtprecioxmetro.TextChanged
        Try

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Txtcostounitario_TextChanged(sender As Object, e As EventArgs) Handles txtcostounitario.TextChanged

        calcularcostoxcm()
    End Sub
    Function calcularcostoxcm()
        Try

            Dim ancho, alto, totalcmxm, re3, re4 As Double
            'totalcmxm = CDbl(vtxt3largocm.Text) * CDbl(vtxt4anchocm.Text)
            re3 = CDbl(vtxt3largocm.Text) * CDbl(vtxt4anchocm.Text)
            re4 = CDbl(txtcostounitario.Text) / CDbl(re3)
            vtxt8costoxcm.Text = Math.Round(re4, 3)

        Catch ex As Exception

        End Try
    End Function
End Class