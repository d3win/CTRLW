Imports MySql.Data.MySqlClient
Public Class frmgastosgralesserigrafia
    Dim marco, costomarco As String

    Function cerrarconexion()
        If conexionMysql.State = ConnectionState.Open Then
            conexionMysql.Close()

        End If
    End Function

    Private Sub txtbuscartinta_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Down Then
            listacolores.Focus()
        End If
    End Sub

    Private Sub Listacolores_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub listacolores_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Try

                conexionMysql.Open()
                Dim Sql As String
                Sql = "select * from producto_serigrafia where nombre='" & listacolores.Text & "';"
                Dim cmd As New MySqlCommand(Sql, conexionMysql)
                reader = cmd.ExecuteReader()
                reader.Read()
                txtfoliotinta.Text = reader.GetString(0).ToString()

                'txtnombre.Text = reader.GetString(1).ToString()
                'txtprecio.Text = reader.GetString(4).ToString()
                ''si encuentra el valor, llamamos al focus del boton.
                reader.Close()
                conexionMysql.Close()
            Catch ex As Exception
                MsgBox("error de cargar servicio")
            End Try
            txttintausada.Focus()


        End If

    End Sub

    Private Sub Grillacolores_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub grillacolores_DoubleClick(sender As Object, e As EventArgs)
        Try

            'eliminar datos al dar doble clic.
            'grilla.CurrentRow.Index
            grillacolores.Rows.RemoveAt(grillacolores.CurrentRow.Index)
            'eliminado el registro, sumamos el total de valores. 
            sumatoriatinta()
        Catch ex As Exception

        End Try
    End Sub


    Function calcularcostohorastrabajo()
        Try

            txtcostohtrabajo.Text = CDbl(txthorastrabajo.Text) * CDbl(txtcostoporhora.Text)
        Catch ex As Exception

        End Try

    End Function




    Function sumatoriatinta()
        Dim i As Integer = grillacolores.RowCount

        Dim j As Integer
        Dim suma, cantidad_productos As Double
        Dim a, b As String
        'suma de valores
        For j = 0 To i - 2
            'MsgBox("valosr de j:" & j)
            'a = venta.grillaventa.Item(j, 3).Value.ToString()
            a = grillacolores.Rows(j).Cells(3).Value
            '   b = grillacolores.Rows(j).Cells(2).Value
            '  cantidad_productos = cantidad_productos + b
            suma = suma + a
            'MsgBox(a)
        Next
        Try
            lbsumatintas.Text = suma

            txttotaltintas.Text = suma * CDbl(setxtcantidadproducto.Text)
            'stxttotalproductos.Text = cantidad_productos

        Catch ex As Exception

        End Try
    End Function







    Function llenadoluz()
        Try

            cerrarconexion()
            conexionMysql.Open()
            Dim contador As String

            Dim Sql2 As String
            Sql2 = "select * from luzserigrafia;"
            Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            reader = cmd2.ExecuteReader()
            reader.Read()
            contador = reader.GetString(5).ToString()

            txttotalluz.Text = contador
            '      MsgBox(txttotalluz.Text)

            conexionMysql.Close()
            'MsgBox(contador)
        Catch ex As Exception
            txttotalluz.Text = 0

        End Try
    End Function
    Private Sub Frmgastosgralesserigrafia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listacolores.Visible = False
        bgrilla.Visible = False
        bgrilla.RowHeadersVisible = False
        bgrilla.DefaultCellStyle.Font = New Font("Arial", 14)
        bgrilla.AlternatingRowsDefaultCellStyle.BackColor = Color.SkyBlue

        setxtclaveproducto.Text = frmindex.stxtclave.Text
        setxtnombreproducto.Text = frmindex.stxtnombre.Text
        setxtcantidadproducto.Text = frmindex.stxttotalproductos.Text
        setxtprecioproducto.Text = frmindex.stxtprecio.Text
        setxtcostoproducto.Text = frmindex.txtcostoproductoserigrafia.Text
        setxtgananciaproducto.Text = frmindex.stxtgananciatotalproductos.Text



        calcularcostoganancia()
        obtenerfolio()


    End Sub
    Function obtenerfolio()
        Dim folio As Integer
        folio = 0
        cerrarconexion()
        Try


            'grilla.Rows.Clear()
            conexionMysql.Open()
            Dim sql2 As String
            sql2 = "select max(idsecotizacion) from secotizacion;"
            Dim cmd2 As New MySqlCommand(sql2, conexionMysql)
            reader = cmd2.ExecuteReader()
            reader.Read()
            folio = reader.GetString(0).ToString
            lbfolio.Text = folio + 1
            conexionMysql.Close()
        Catch ex As Exception
            lbfolio.Text = folio + 1
            cerrarconexion()
        End Try


        'MsgBox("si hay folio")
    End Function
    Function calcularcostoganancia()
        Try

            setxtgananciaproducto.Text = CDbl(setxtprecioproducto.Text) - CDbl(setxtcostoproducto.Text)
            setxtgananciaproducto.Text = setxtgananciaproducto.Text

        Catch ex As Exception

        End Try

    End Function
    Function borrartinta()
        txtcostotinta.Text = ""
        txtcostounidadtinta.Text = ""
        txttintausada.Text = ""
        txtfoliotinta.Text = ""
        txtbuscartinta.Text = ""

    End Function





    Private Sub Button78_Click(sender As Object, e As EventArgs) Handles Button78.Click

        'primero se guarda la cotizacion, y despues se usa.

        guardarcotizacion()


        txtfoliobusqueda.Text = lbfolio.Text

        obtenerfolio()
        'una vez guardada la cotización, la comenzamos a usar

        If txttotalimpresion.Text = "" Or txtcostohtrabajo.Text = "" Or txttotaltintas.Text = "" Then
            MsgBox("Al parecer hay Totales vacios, para una mejor cotización, utilizalos", MsgBoxStyle.Information, "CTRL+y")
        Else

            If txtfoliobusqueda.Text = "" Then


                MsgBox("Primero debes guardar el registro del cotizador y buscarlo posteriormente", MsgBoxStyle.Information, "CTRL+y")
            Else
                frmindex.setxtgastosgenerales.Text = txttotalfinalcotizador.Text
                frmindex.setxtgananciaserigrafia.Text = txtgananciaserigrafia.Text
                frmindex.setxtgananciaproducto.Text = txtgananciaproducto.Text
                frmindex.setxtganancianeta.Text = txtganancianeta.Text
                frmindex.setxtprecioestampado.Text = txtcostoestampado.Text
                frmindex.setxtprecioconproducto.Text = txtcostoconproducto.Text
                frmindex.setxtfoliocotizador.Text = txtfoliobusqueda.Text
            End If

            Me.Close()



        End If
    End Sub
    Function calculototal()
        Try
            'se calcula los gastos generales 

            txttotalfinalcotizador.Text = CDbl(setxtcantidadproducto.Text) * CDbl(Label20.Text) + CDbl(txttotaltintas.Text) + CDbl(txttotalluzusado.Text)
        Catch ex As Exception

        End Try

    End Function


    Private Sub Button81_Click(sender As Object, e As EventArgs)
        Dim formulario As New frmelegirmarco
        'FRagregaranticipo.ShowDialog()
        formulario.ShowDialog()
    End Sub


    Function mostrarmarcos()



        cerrarconexion()

        conexionMysql.Open()
        Dim Sql As String
        Sql = "select * from cotizador_marco where medida like '%" & txtmarco.Text & "%';"
        Dim cmd As New MySqlCommand(Sql, conexionMysql)
        Dim dt As New DataTable
        Dim da As New MySqlDataAdapter(cmd)
        'cargamos el formulario  resumen
        da.Fill(dt)
        bgrilla.DataSource = dt
        conexionMysql.Close()


    End Function


    Private Sub Button80_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub bgrilla_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs)

    End Sub
    Function seleccionardegrilla()
        Try
            Dim id, valor As String
            Dim Variable As String = bgrilla.Item(0, bgrilla.CurrentRow.Index).Value
            Dim Variable2 As String = bgrilla.Item(1, bgrilla.CurrentRow.Index).Value
            Dim Variable3 As String = bgrilla.Item(2, bgrilla.CurrentRow.Index).Value

            'MsgBox(Variable)
            'Variable
            'grilla2.Visible = False
            'grilla.Visible = True
            'rbclave.Checked = True

            'id = MsgBox("¿Deseas elegir el marco numero " + Variable + "?", MsgBoxStyle.YesNoCancel, "CTR+y")
            'If id = vbYes Then
            ' MsgBox(Variable2)
            txtfoliomarco.Text = Variable
                txtmarco.Text = Variable2
                txtcostomarco.Text = Variable3
                bgrilla.Visible = False

            'Me.Close()
            txtcantidadmarcos.Focus()



            'End If





        Catch ex As Exception

        End Try
    End Function


    Private Sub txtmarco_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Down Then
            bgrilla.Focus()
        End If
    End Sub

    Private Sub bgrilla_KeyPress(sender As Object, e As KeyPressEventArgs)


    End Sub



    Private Sub Txttotalluz_TextChanged(sender As Object, e As EventArgs)


    End Sub




    Function totaldemarcos()
        Try

            txttotaldemarcos.Text = CDbl(txtcantidadmarcos.Text) * CDbl(txtcostomarco.Text) + CDbl(txttotalimpresion.Text)
        Catch ex As Exception

        End Try

    End Function

    Private Sub Txtcostomarco_TextChanged(sender As Object, e As EventArgs)
        totaldemarcos()
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        llenadoluz()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Setxtcostoproducto_TextChanged(sender As Object, e As EventArgs)

    End Sub
    Function gananciaproducto()
        Try

            txtgananciaproducto.Text = CDbl(setxtgananciaproducto.Text)
            '            txtgananciaproducto.Text = CDbl(setxtgananciaproducto.Text) * CDbl(setxtcantidadproducto.Text)

        Catch ex As Exception

        End Try

    End Function


    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
        'If chluz.Checked = True Then

        '    txttotalfinalcotizador.Text = CDbl(txttotalfinalcotizador.Text) + (CDbl(txttotalluz.Text) * CDbl(setxtcantidadproducto.Text))

        'Else


        '    txttotalfinalcotizador.Text = CDbl(txttotalfinalcotizador.Text) - (CDbl(txttotalluz.Text) * CDbl(setxtcantidadproducto.Text))

        'End If


    End Sub



    Private Sub Txtpreciofinaltinta_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Setxtcantidadproducto_TextChanged(sender As Object, e As EventArgs)
        gananciaproducto()
        calcularcostoganancia()
    End Sub

    Private Sub Txtgananciaproducto_TextChanged(sender As Object, e As EventArgs)
        llamarfunciones()

        'ganancianeta()
    End Sub
    Function llamarfunciones()
        ganancianeta()
        costoestampado()
        costoconproducto()
        calcularcostoganancia()
        calculototal()
        totaldemarcos()
        gananciaproducto()
    End Function
    Function ganancianeta()
        Try

            txtganancianeta.Text = CDbl(txtgananciaproducto.Text) + CDbl(txtgananciaserigrafia.Text)
        Catch ex As Exception

        End Try

    End Function




    Function costoestampado()
        Try
            Dim x, y, gananciapro, cantidadpro As Double

            y = CDbl(setxtgananciaproducto.Text) / CDbl(setxtcantidadproducto.Text)

            gananciapro = Math.Round(y, 2)

            x = CDbl(Label20.Text) + CDbl(lbpreciotrabajo.Text) + CDbl(lbsumatintas.Text) + CDbl(txttotalluz.Text) + gananciapro

            txtcostoestampado.Text = Math.Round(x, 2)
        Catch ex As Exception

        End Try

    End Function


    Function costoconproducto()
        Try
            '            txtcostoconproducto.Text = CDbl(txtflete.Text) / CDbl(setxtcantidadproducto.Text) + CDbl(lbpreciotrabajo.Text) + CDbl(setxtprecioproducto.Text) + CDbl(lbsumatintas.Text) + CDbl(Label20.Text) + CDbl(txttotalluz.Text)
            'se esta omitiendo un dato, que es el del precio del producto, porque el precio no se tiene, hasta que se necesite aplicar se suma a la operacion
            Dim valor As Double
            valor = CDbl(txtflete.Text) / CDbl(setxtcantidadproducto.Text) + CDbl(lbpreciotrabajo.Text) + CDbl(lbsumatintas.Text) + CDbl(Label20.Text) + CDbl(txttotalluz.Text)
            '+ CDbl(setxtprecioproducto.Text)'este es el valor que se quito y ya en caso de aplicarse, se suma a cada producto 
            txtcostoconproducto.Text = Math.Round(valor, 2)


        Catch ex As Exception
        End Try
    End Function

    Private Sub Setxtprecioproducto_TextChanged(sender As Object, e As EventArgs)
        calcularcostoganancia()
    End Sub

    Private Sub bgrilla_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            seleccionardegrilla()
        End If

    End Sub

    Private Sub Btnalmacenarcotizador_Click(sender As Object, e As EventArgs)
        'se inserta el registro dentro de la bd
        guardarcotizacion()

    End Sub

    Function guardarcotizacion()

        conexionMysql.Open()
        Dim Sql2 As String
        Sql2 = "INSERT INTO `dwin`.`secotizacion` (`idsecotizacion`, `idproducto_serigrafia`, `cantidad_producto`, `ganancia_producto`, `costo_luz`, `total_luz`, `costo_hora_trabajo`, `costo_hora_trabajo_total`, `idfolio_marco`,`cantidad_marcos`, `totaldemarcos`, `costoimpresion`, `cantidadimpresion`, `totalimpresion`,`flete`, `lbpreciotrabajo`, `lbsumatintas`, `lb20`, `totaltintas`, `gastosgenerales`, `gananciaserigrafia`, `gananciaproducto`, `ganancianeta`, `costosoloestampado`, `costoconproducto`) VALUES ('" & lbfolio.Text & "', '" & setxtclaveproducto.Text & "', '" & setxtcantidadproducto.Text & "', '" & setxtgananciaproducto.Text & "', '" & txttotalluz.Text & "', '" & txttotalluzusado.Text & "', '" & txtcostoporhora.Text & "', '" & txthorastrabajo.Text & "', '" & txtfoliomarco.Text & "','" & txtcantidadmarcos.Text & "', '" & txttotaldemarcos.Text & "', '" & txtcostoimpresion.Text & "', '" & txtcantidadimpresiones.Text & "', '" & txttotalimpresion.Text & "','" & txtflete.Text & "', '" & lbpreciotrabajo.Text & "', '" & lbsumatintas.Text & "', '" & Label20.Text & "', '" & txttotaltintas.Text & "', '" & txttotalfinalcotizador.Text & "', '" & txtgananciaserigrafia.Text & "', '" & txtgananciaproducto.Text & "', '" & txtganancianeta.Text & "', '" & txtcostoestampado.Text & "', '" & txtcostoconproducto.Text & "');"
        Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
        cmd2.ExecuteNonQuery()
        conexionMysql.Close()



        Dim i As Integer = grillacolores.RowCount

        Dim j As Integer
        Dim suma, cantidad_productos As Double
        Dim a, b, c, d As String
        'suma de valores
        For j = 0 To i - 2
            'MsgBox("valosr de j:" & j)
            'a = venta.grillaventa.Item(j, 3).Value.ToString()
            a = grillacolores.Rows(j).Cells(0).Value
            d = grillacolores.Rows(j).Cells(1).Value

            b = grillacolores.Rows(j).Cells(2).Value

            c = grillacolores.Rows(j).Cells(3).Value
            '   b = grillacolores.Rows(j).Cells(2).Value
            '  cantidad_productos = cantidad_productos + b
            'suma = suma + a
            'MsgBox(a)

            conexionMysql.Open()
            Dim Sql3 As String
            Sql3 = "INSERT INTO `dwin`.`secotizaciontintas` (`foliotinta`,`descripcion`, `mlusados`, `precioporpieza`, `idsecotizacion`) VALUES ('" & a & "','" & d & "', '" & b & "', '" & c & "', '" & lbfolio.Text & "');"
            Dim cmd3 As New MySqlCommand(Sql3, conexionMysql)
            cmd3.ExecuteNonQuery()
            conexionMysql.Close()






        Next

        MsgBox("Registro Guardado", MsgBoxStyle.Information, "CTRL+y")




    End Function

    Function limpiartodo()
        ' setxtclaveproducto.Text = ""
        'setxtcantidadproducto.Text = ""
        'setxtgananciaproducto.Text = ""
        txttotalluz.Text = ""
        txttotalluzusado.Text = ""
        txtcostoporhora.Text = ""
        txthorastrabajo.Text = ""
        txtfoliomarco.Text = ""
        txttotaldemarcos.Text = ""
        txtcostoimpresion.Text = ""
        txtcantidadimpresiones.Text = ""
        txttotalimpresion.Text = ""
        lbpreciotrabajo.Text = ""
        lbsumatintas.Text = ""
        Label20.Text = ""
        txttotaltintas.Text = ""
        txttotalfinalcotizador.Text = ""
        txtgananciaserigrafia.Text = ""
        txtgananciaproducto.Text = ""
        txtganancianeta.Text = ""
        txtcostoestampado.Text = ""
        txtcostoconproducto.Text = ""
        txtcostohtrabajo.Text = ""
        txtmarco.Text = ""
        txtcostomarco.Text = ""
        txtcantidadmarcos.Text = ""
        txtflete.Text = ""
        txttintausada.Text = ""
        txtbuscartinta.Text = ""
        txtcostounidadtinta.Text = ""
        txtcostotinta.Text = ""
        txtpreciofinaltinta.Text = ""
        txtgananciaproducto.Text = ""
        txtfoliotinta.Text = ""




    End Function

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        limpiartodo()
        grillacolores.Rows.Clear()


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        ' If e.KeyCode = Keys.Enter Then

        Try

            'consultamos el id de la cotización y cargamos todos los datos
            cerrarconexion()

            Dim cantidad, i As Integer
            cantidad = 0
            conexionMysql.Open()
            Dim Sql2 As String
            Sql2 = "SELECT * FROM secotizacion where idsecotizacion=" & txtfoliobusqueda.Text & ";"
            Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            reader = cmd2.ExecuteReader
            reader.Read()
            txttotalluz.Text = reader.GetString(4).ToString
            txttotalluzusado.Text = reader.GetString(5).ToString
            txtcostoporhora.Text = reader.GetString(6).ToString
            txthorastrabajo.Text = reader.GetString(7).ToString

            txtcantidadmarcos.Text = reader.GetString(9).ToString

            txttotaldemarcos.Text = reader.GetString(10).ToString
            txtcostoimpresion.Text = reader.GetString(11).ToString
            txtcantidadimpresiones.Text = reader.GetString(12).ToString
            txttotalimpresion.Text = reader.GetString(13).ToString

            txtflete.Text = reader.GetString(14).ToString

            lbpreciotrabajo.Text = reader.GetString(15).ToString
            lbsumatintas.Text = reader.GetString(16).ToString
            Label20.Text = reader.GetString(17).ToString
            txttotaltintas.Text = reader.GetString(18).ToString
            'txtpsprecioml.Text = Math.Round(b, 2)
            Dim a, b, c, d, ee, f As Double
            a = reader.GetString(19).ToString
            txttotalfinalcotizador.Text = Math.Round(a, 2)

            b = reader.GetString(20).ToString
            txtgananciaserigrafia.Text = Math.Round(b, 2)

            c = reader.GetString(21).ToString
            txtgananciaproducto.Text = Math.Round(c, 2)

            d = reader.GetString(22).ToString
            txtganancianeta.Text = Math.Round(d, 2)

            ee = reader.GetString(23).ToString
            txtcostoestampado.Text = Math.Round(ee, 2)

            f = reader.GetString(24).ToString
            txtcostoconproducto.Text = Math.Round(f, 2)



            txtfoliomarco.Text = reader.GetString(8).ToString
            'cargamos el formulario  resumen
            conexionMysql.Close()

            'MsgBox("hay tantos resultados:" & cantidad)


            conexionMysql.Open()
            Dim Sql22 As String
            Sql22 = "select count(*) from secotizaciontintas where idsecotizacion=" & txtfoliobusqueda.Text & ";"
            Dim cmd22 As New MySqlCommand(Sql22, conexionMysql)
            reader = cmd22.ExecuteReader
            reader.Read()
            cantidad = reader.GetString(0).ToString
            conexionMysql.Close()




            cerrarconexion()
            conexionMysql.Open()
            Dim Sql As String
            Sql = "select * from secotizaciontintas where idsecotizacion=" & txtfoliobusqueda.Text & ""
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            reader = cmd.ExecuteReader
            For i = 1 To cantidad
                reader.Read()
                '           Dim i As Integer = grillacolores.RowCount

                grillacolores.Rows.Add(reader.GetString(1).ToString, reader.GetString(2).ToString, reader.GetString(3).ToString, reader.GetString(4).ToString)

            Next


            conexionMysql.Close()

            '------------------------------------------------------------------------------------
            'se recalcule todos los valores con los nuevos datos
            Try

                llamarfunciones()
            Catch ex As Exception

            End Try
            '------------------------------------------------------------------------------------
        Catch ex As Exception
            limpiartodo()
            grillacolores.Rows.Clear()

        End Try

        ' End If
    End Sub

    Private Sub Txtfoliobusqueda_TextChanged(sender As Object, e As EventArgs)




    End Sub

    Private Sub Txtfoliomarco_TextChanged(sender As Object, e As EventArgs)
        Try

            cerrarconexion()
            conexionMysql.Open()
            Dim Sql2 As String
            Sql2 = "select * from cotizador_marco where idcotizador_marco=" & txtfoliomarco.Text & ";"
            Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            reader = cmd2.ExecuteReader
            reader.Read()
            txtmarco.Text = reader.GetString(1).ToString
            ' txtcostomarco.Text = reader.GetString(2).ToString
            'cargamos el formulario  resumen
            conexionMysql.Close()
            bgrilla.Visible = False
            cerrarconexion()
            conexionMysql.Open()
            Dim Sql23 As String
            Sql23 = "select gasto_marco_final from cotizador_marco where medida='" & txtmarco.Text & "';"
            Dim cmd23 As New MySqlCommand(Sql23, conexionMysql)
            reader = cmd23.ExecuteReader
            reader.Read()
            txtcostomarco.Text = reader.GetString(0).ToString
            ' txtcostomarco.Text = reader.GetString(2).ToString
            'cargamos el formulario  resumen
            conexionMysql.Close()


        Catch ex As Exception

        End Try


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)

    End Sub



    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try

            llamarfunciones()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub bgrilla_CellDoubleClick_1(sender As Object, e As DataGridViewCellEventArgs)
        seleccionardegrilla()
    End Sub

    Private Sub txtfoliobusqueda_KeyPress(sender As Object, e As KeyPressEventArgs)

    End Sub

    Private Sub Txtfoliobusqueda_TextChanged_1(sender As Object, e As EventArgs) Handles txtfoliobusqueda.TextChanged

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Close()

    End Sub

    Function busquedafolio()
        Try


            grillacolores.Rows.Clear()


            'consultamos el id de la cotización y cargamos todos los datos
            cerrarconexion()

            Dim cantidad, i As Integer
            cantidad = 0
            conexionMysql.Open()
            Dim Sql2 As String
            Sql2 = "SELECT * FROM secotizacion where idsecotizacion=" & txtfoliobusqueda.Text & ";"
            Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            reader = cmd2.ExecuteReader
            reader.Read()
            txttotalluz.Text = reader.GetString(4).ToString
            txttotalluzusado.Text = reader.GetString(5).ToString
            txtcostoporhora.Text = reader.GetString(6).ToString
            txthorastrabajo.Text = reader.GetString(7).ToString

            txtcantidadmarcos.Text = reader.GetString(9).ToString

            txttotaldemarcos.Text = reader.GetString(10).ToString
            txtcostoimpresion.Text = reader.GetString(11).ToString
            txtcantidadimpresiones.Text = reader.GetString(12).ToString
            txttotalimpresion.Text = reader.GetString(13).ToString

            txtflete.Text = reader.GetString(14).ToString

            lbpreciotrabajo.Text = reader.GetString(15).ToString
            lbsumatintas.Text = reader.GetString(16).ToString
            Label20.Text = reader.GetString(17).ToString
            txttotaltintas.Text = reader.GetString(18).ToString
            'txtpsprecioml.Text = Math.Round(b, 2)
            Dim a, b, c, d, ee, f As Double
            a = reader.GetString(19).ToString
            txttotalfinalcotizador.Text = Math.Round(a, 2)

            b = reader.GetString(20).ToString
            txtgananciaserigrafia.Text = Math.Round(b, 2)

            c = reader.GetString(21).ToString
            txtgananciaproducto.Text = Math.Round(c, 2)

            d = reader.GetString(22).ToString
            txtganancianeta.Text = Math.Round(d, 2)

            ee = reader.GetString(23).ToString
            txtcostoestampado.Text = Math.Round(ee, 2)

            f = reader.GetString(24).ToString
            txtcostoconproducto.Text = Math.Round(f, 2)



            txtfoliomarco.Text = reader.GetString(8).ToString
            'cargamos el formulario  resumen
            conexionMysql.Close()

            'MsgBox("hay tantos resultados:" & cantidad)


            conexionMysql.Open()
            Dim Sql22 As String
            Sql22 = "select count(*) from secotizaciontintas where idsecotizacion=" & txtfoliobusqueda.Text & ";"
            Dim cmd22 As New MySqlCommand(Sql22, conexionMysql)
            reader = cmd22.ExecuteReader
            reader.Read()
            cantidad = reader.GetString(0).ToString
            conexionMysql.Close()




            cerrarconexion()
            conexionMysql.Open()
            Dim Sql As String
            Sql = "select * from secotizaciontintas where idsecotizacion=" & txtfoliobusqueda.Text & ""
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            reader = cmd.ExecuteReader
            For i = 1 To cantidad
                reader.Read()
                '           Dim i As Integer = grillacolores.RowCount

                grillacolores.Rows.Add(reader.GetString(1).ToString, reader.GetString(2).ToString, reader.GetString(3).ToString, reader.GetString(4).ToString)

            Next


            conexionMysql.Close()

            '------------------------------------------------------------------------------------
            'se recalcule todos los valores con los nuevos datos
            Try

                llamarfunciones()
            Catch ex As Exception

            End Try
            '------------------------------------------------------------------------------------
        Catch ex As Exception
            limpiartodo()
            grillacolores.Rows.Clear()

        End Try


    End Function

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        busquedafolio()

    End Sub

    Private Sub Txtcostoimpresion_TextChanged_1(sender As Object, e As EventArgs) Handles txtcostoimpresion.TextChanged

        Try

            txttotalimpresion.Text = CDbl(txtcostoimpresion.Text) * CDbl(txtcantidadimpresiones.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim formulario As New frmconfigurarluz
        'FRagregaranticipo.ShowDialog()
        formulario.ShowDialog()
    End Sub

    Private Sub Button80_Click_1(sender As Object, e As EventArgs) Handles Button80.Click
        Dim formulario As New frmcalculomarco
        'FRagregaranticipo.ShowDialog()
        formulario.ShowDialog()
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        Dim formulario As New frmproductoserigrafia
        'FRagregaranticipo.ShowDialog()
        formulario.ShowDialog()
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        llenadoluz()
    End Sub

    Private Sub Txtmarco_TextChanged(sender As Object, e As EventArgs) Handles txtmarco.TextChanged
        If txtmarco.Text = "" Then
            bgrilla.Visible = False
        Else

            bgrilla.Visible = True

            mostrarmarcos()
        End If
    End Sub

    Private Sub Bgrilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles bgrilla.CellContentClick
        seleccionardegrilla()

    End Sub

    Private Sub Listacolores_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles listacolores.SelectedIndexChanged

    End Sub

    Private Sub Txtbuscartinta_TextChanged_1(sender As Object, e As EventArgs) Handles txtbuscartinta.TextChanged
        ' grilla2.Visible = False

        listacolores.Visible = True
        listacolores.Items.Clear()

        If txtbuscartinta.Text = "" Then
            listacolores.Visible = False
            ' sborrar()
            'stxtclave.Text = ""


        Else

            Try

                'cerramos la conexion
                cerrarconexion()

                Dim cantidad, i As Integer
                cantidad = 0
                conexionMysql.Open()
                Dim Sql2 As String
                Sql2 = "select count(*) from producto_serigrafia where nombre like '%" & txtbuscartinta.Text & "%';"
                Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
                reader = cmd2.ExecuteReader
                reader.Read()
                cantidad = reader.GetString(0).ToString

                'cargamos el formulario  resumen
                conexionMysql.Close()

                'MsgBox("hay tantos resultados:" & cantidad)

                cerrarconexion()


                conexionMysql.Open()
                Dim Sql As String
                Sql = "select nombre from producto_serigrafia where nombre like '%" & txtbuscartinta.Text & "%';"
                Dim cmd As New MySqlCommand(Sql, conexionMysql)
                reader = cmd.ExecuteReader
                For i = 1 To cantidad
                    reader.Read()

                    listacolores.Items.Add(reader.GetString(0).ToString)
                Next


                conexionMysql.Close()

            Catch ex As Exception
                cerrarconexion()
            End Try
        End If


        'Catch ex As Exception

        'End Try


        'End Try
    End Sub

    Private Sub Grillacolores_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles grillacolores.CellContentClick

    End Sub

    Private Sub Button79_Click_1(sender As Object, e As EventArgs) Handles Button79.Click
        If txtfoliotinta.Text = "" Or txtbuscartinta.Text = "" Or txtcostotinta.Text = "" Or txttintausada.Text = "" Or txtpreciofinaltinta.Text = "" Or txtcostounidadtinta.Text = "" Then

            MsgBox("No hay tinta que agregar", MsgBoxStyle.Information, "Sistema")

        Else

            Dim i As Integer = grillacolores.RowCount

            grillacolores.Rows.Add(txtfoliotinta.Text, txtbuscartinta.Text, txttintausada.Text, txtpreciofinaltinta.Text)

            sumatoriatinta()
            llamarfunciones()

        End If
    End Sub

    Private Sub txtfoliobusqueda_KeyDown(sender As Object, e As KeyEventArgs) Handles txtfoliobusqueda.KeyDown
        If e.KeyCode = Keys.Enter Then
            busquedafolio()

        End If


    End Sub

    Private Sub GroupBox35_Enter(sender As Object, e As EventArgs) Handles GroupBox35.Enter

    End Sub

    Private Sub Txtfoliotinta_TextChanged_1(sender As Object, e As EventArgs) Handles txtfoliotinta.TextChanged
        'Try

        listacolores.Visible = False
        If txtfoliotinta.Text = "" Then
            borrartinta()




        Else



            cerrarconexion()


            'Try



            'Dim Sql As String
            'Sql = "select descripcion,precio from producto where idproducto='" & txtclave.Text & "';"
            'Dim cmd As New MySqlCommand(Sql, conexionMysql)
            'reader = cmd.ExecuteReader()
            'reader.Read()
            'txtnombre.Text = reader.GetString(0).ToString()
            'txtprecio.Text = reader.GetString(1).ToString()
            '''si encuentra el valor, llamamos al focus del boton.
            ''reader.Close()
            'conexionMysql.Close()


            'Catch ex As Exception
            'cerrarconexion()
            'MsgBox("el servicio no existe")
            'End Try

            conexionMysql.Open()

            Dim Sql As String
            Sql = "select * from producto_serigrafia where idproducto_serigrafia='" & txtfoliotinta.Text & "';"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            reader = cmd.ExecuteReader()
            reader.Read()
            txtbuscartinta.Text = reader.GetString(1).ToString()
            '            txtcantidad.Text = reader.GetString(4).ToString()


            'MsgBox("Se caego la clave")
            'Dim precio As String

            listacolores.Visible = False



            'precio = reader.GetString(1).ToString()
            'txtprecio.Text = precio

            reader.Close()


            'MsgBox("actividad:" & txtactividad.Text)

            'Catch ex As Exception
            'MsgBox("hay problemas", MsgBoxStyle.Exclamation)
            'End Try


            conexionMysql.Close()

            conexionMysql.Open()

            Dim Sql2 As String
            Sql2 = "select * from producto_serigrafia where idproducto_serigrafia='" & txtfoliotinta.Text & "';"
            Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            reader = cmd2.ExecuteReader()
            reader.Read()
            txtcostotinta.Text = reader.GetString(2).ToString()
            txtcostounidadtinta.Text = reader.GetString(7).ToString()

            '            txtcantidad.Text = reader.GetString(4).ToString()

            'Dim precio As String


            'precio = reader.GetString(1).ToString()
            'txtprecio.Text = precio

            reader.Close()


            'MsgBox("actividad:" & txtactividad.Text)

            'Catch ex As Exception
            'MsgBox("hay problemas", MsgBoxStyle.Exclamation)
            'End Try


            conexionMysql.Close()


            'stxtcantidad.Focus()

            'calculamos el precio de la cantidad que se va agregar





        End If
    End Sub

    Private Sub Txtcostoporhora_TextChanged_1(sender As Object, e As EventArgs) Handles txtcostoporhora.TextChanged
        calcularcostohorastrabajo()
    End Sub

    Private Sub Txtcantidadimpresiones_TextChanged_1(sender As Object, e As EventArgs) Handles txtcantidadimpresiones.TextChanged
        Try

            txttotalimpresion.Text = CDbl(txtcostoimpresion.Text) * CDbl(txtcantidadimpresiones.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtcantidadmarcos_TextChanged_1(sender As Object, e As EventArgs) Handles txtcantidadmarcos.TextChanged
        totaldemarcos()
    End Sub

    Private Sub Txttotaldemarcos_TextChanged_1(sender As Object, e As EventArgs) Handles txttotaldemarcos.TextChanged
        Try

            Label20.Text = CDbl(txttotaldemarcos.Text) / CDbl(setxtcantidadproducto.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txttotalimpresion_TextChanged_1(sender As Object, e As EventArgs) Handles txttotalimpresion.TextChanged
        calculototal()
        totaldemarcos()
    End Sub

    Private Sub Txtcostohtrabajo_TextChanged_1(sender As Object, e As EventArgs) Handles txtcostohtrabajo.TextChanged
        calculototal()
        Try
            'calcular el costo unico del trabajo por la cantidad de piezas por trabajo
            lbpreciotrabajo.Text = CDbl(txtcostohtrabajo.Text) / CDbl(setxtcantidadproducto.Text)
            'calcular la ganancia de la serigrafía.
            txtgananciaserigrafia.Text = CDbl(lbpreciotrabajo.Text) * CDbl(setxtcantidadproducto.Text)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txttotaltintas_TextChanged_1(sender As Object, e As EventArgs) Handles txttotaltintas.TextChanged
        calculototal()
    End Sub

    Private Sub Txttintausada_TextChanged_1(sender As Object, e As EventArgs) Handles txttintausada.TextChanged
        Try

            txtpreciofinaltinta.Text = CDbl(txtcostounidadtinta.Text) * CDbl(txttintausada.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txttotalfinalcotizador_TextChanged_1(sender As Object, e As EventArgs) Handles txttotalfinalcotizador.TextChanged
        llamarfunciones()
    End Sub

    Private Sub Txtgananciaserigrafia_TextChanged_1(sender As Object, e As EventArgs) Handles txtgananciaserigrafia.TextChanged
        llamarfunciones()
    End Sub

    Private Sub Txtgananciaproducto_TextChanged_1(sender As Object, e As EventArgs) Handles txtgananciaproducto.TextChanged
        gananciaproducto()
    End Sub

    Private Sub Txtganancianeta_TextChanged_1(sender As Object, e As EventArgs) Handles txtganancianeta.TextChanged
        llamarfunciones()
    End Sub

    Private Sub Txtcostoestampado_TextChanged_1(sender As Object, e As EventArgs) Handles txtcostoestampado.TextChanged
        llamarfunciones()
    End Sub

    Private Sub Txtcostoconproducto_TextChanged(sender As Object, e As EventArgs) Handles txtcostoconproducto.TextChanged

    End Sub

    Private Sub Txtflete_TextChanged_1(sender As Object, e As EventArgs) Handles txtflete.TextChanged
        Try

            llamarfunciones()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txthorastrabajo_TextChanged_1(sender As Object, e As EventArgs) Handles txthorastrabajo.TextChanged
        calcularcostohorastrabajo()
    End Sub

    Private Sub Txttotalluz_TextChanged_1(sender As Object, e As EventArgs) Handles txttotalluz.TextChanged
        calculototal()
        Try

            txttotalluzusado.Text = CDbl(setxtcantidadproducto.Text) * CDbl(txttotalluz.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txttotalluzusado_TextChanged(sender As Object, e As EventArgs) Handles txttotalluzusado.TextChanged

    End Sub

    Private Sub GroupBox5_Enter(sender As Object, e As EventArgs) Handles GroupBox5.Enter

    End Sub

    Private Sub listacolores_DoubleClick(sender As Object, e As EventArgs) Handles listacolores.DoubleClick
        'Try
        conexionMysql.Close()


        conexionMysql.Open()
        Dim Sql As String
        Sql = "select * from producto_serigrafia where nombre='" & listacolores.Text & "';"
        Dim cmd As New MySqlCommand(Sql, conexionMysql)
        reader = cmd.ExecuteReader()
        reader.Read()
        txtfoliotinta.Text = reader.GetString(0).ToString()

        'txtnombre.Text = reader.GetString(1).ToString()
        'txtprecio.Text = reader.GetString(4).ToString()
        ''si encuentra el valor, llamamos al focus del boton.
        reader.Close()
        conexionMysql.Close()
        ' Catch ex As Exception
        ' MsgBox("error de cargar servicio")
        ' End Try
    End Sub
End Class