Imports MySql.Data.MySqlClient
Public Class frmcalculomarco

    Dim valor, actividad As Integer
    'Public Variablemarco As Integer

    Function limpiar()
        Try

            stxtclave.Text = ""
            stxtnombre.Text = ""
            stxtcosto.Text = ""
            stxtcostofinal.Text = ""
            stxtmililitros.Text = ""
            stxtmililitrosusados.Text = ""
            stxtcostomililitros.Text = ""
            grilla2.Rows.Clear()

            grilla2.Visible = False
            grilla.Visible = True
            txtcostofinal.Text = ""
            'txtclavemarco.Text = ""
            grilla.Rows.Clear()

            txttemporal.Text = ""

        Catch ex As Exception

        End Try



    End Function
    Function limpiar2()
        Try

            stxtclave.Text = ""
            stxtnombre.Text = ""
            stxtcosto.Text = ""
            stxtcostofinal.Text = ""
            stxtmililitros.Text = ""
            stxtmililitrosusados.Text = ""
            stxtcostomililitros.Text = ""
            'grilla2.Rows.Clear()

            'grilla2.Visible = False
            'grilla.Visible = True
            'txtcostofinal.Text = ""
            'txtclavemarco.Text = ""
            'grilla.Rows.Clear()

            'txttemporal.Text = ""

        Catch ex As Exception

        End Try
    End Function

    Function limpiaralgunos()
        stxtcosto.Text = ""
        stxtcostofinal.Text = ""
        stxtmililitros.Text = ""
        stxtmililitrosusados.Text = ""
        stxtcostomililitros.Text = ""
    End Function
    Private Sub Stxtclave_TextChanged(sender As Object, e As EventArgs) Handles stxtclave.TextChanged
        If stxtclave.Text = "" Or stxtclave.Text = "0" Then
            If txttemporal.Text <> "" Then
                limpiar2()
            Else
                limpiar()
            End If

        Else

            Try
                Dim cantidad As Integer

                'respuesta = vbYes


                cerrarconexion()


                conexionMysql.Open()
                Dim Sql As String
                Sql = "select * from producto_serigrafia where idproducto_serigrafia='" & stxtclave.Text & "';"
                Dim cmd As New MySqlCommand(Sql, conexionMysql)
                reader = cmd.ExecuteReader()
                reader.Read()
                stxtcosto.Text = reader.GetString(2).ToString()
                stxtmililitros.Text = reader.GetString(6).ToString()
                stxtcostomililitros.Text = reader.GetString(7).ToString

                'NOTA: SE INTERCAMBIAN LOS VALORES PORQUE PRIMERO SE BUSCA EL PRECIO Y POSTERIOR EL NOMBRE, PARA QUE NO MARQUE ERROR



                cerrarconexion()
                Try


                    conexionMysql.Open()
                    Dim Sql3 As String
                    Sql3 = "select * from producto_serigrafia where idproducto_serigrafia='" & stxtclave.Text & "';"
                    Dim cmd3 As New MySqlCommand(Sql3, conexionMysql)
                    reader = cmd3.ExecuteReader()
                    reader.Read()
                    stxtnombre.Text = reader.GetString(1).ToString()
                    'txtpsprecio.Text = reader.GetString(3).ToString()
                    'txtpscantidad.Text = reader.GetString(4).ToString
                    'txtpstipomedida.Text = reader.GetString(5).ToString

                    ''si encuentra el valor, llamamos al focus del boton.
                    'Button17.Focus()
                Catch ex As Exception

                End Try

                listaservicios.Visible = False



                conexionMysql.Close()

            Catch ex As Exception
                cerrarconexion()
                ' MsgBox("se provoco un error")
                'limpiar()
                '                stxtclave.Text = ""
                stxtnombre.Text = ""
                stxtcosto.Text = ""
                stxtcostofinal.Text = ""
                stxtmililitros.Text = ""
                stxtmililitrosusados.Text = ""
                stxtcostomililitros.Text = ""

            End Try





        End If

    End Sub
    Function cerrarconexion()
        If conexionMysql.State = ConnectionState.Open Then
            conexionMysql.Close()
        End If
    End Function



    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub



    Function cargarservicio()
        Try

            conexionMysql.Open()
            Dim Sql As String
            Sql = "select * from producto_serigrafia where nombre='" & listaservicios.Text & "';"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            reader = cmd.ExecuteReader()
            reader.Read()
            stxtclave.Text = reader.GetString(0).ToString()

            'txtnombre.Text = reader.GetString(1).ToString()
            'txtprecio.Text = reader.GetString(4).ToString()
            ''si encuentra el valor, llamamos al focus del boton.
            reader.Close()
            conexionMysql.Close()
        Catch ex As Exception
            MsgBox("error de cargar servicio")
        End Try


    End Function


    Private Sub Stxtmililitrosusados_TextChanged(sender As Object, e As EventArgs) Handles stxtmililitrosusados.TextChanged
        calcularcostofinal()
    End Sub
    Function calcularcostofinal()
        Try

            stxtcostofinal.Text = CDbl(stxtmililitrosusados.Text) * CDbl(stxtcostomililitros.Text)
        Catch ex As Exception
            cerrarconexion()
        End Try

    End Function

    Private Sub Stxtcostomililitros_TextChanged(sender As Object, e As EventArgs) Handles stxtcostomililitros.TextChanged
        calcularcostofinal()
    End Sub

    Private Sub Button69_Click(sender As Object, e As EventArgs) Handles Button69.Click
        'comprobamos que no halla ningun dato en grilla2, que es la grilal de la busqueda del marco seleccionado


        Dim filas As Integer
        Dim respuesta As String
        filas = grilla2.RowCount
        If txttemporal.Text <> "" Then
            'respuesta = MsgBox("Estan realizando la edicion de un marco existente, ¿deseas cancelar la edicion y continuar con un nuevo marco?", MsgBoxStyle.YesNo, "CTRL+y")
            'If respuesta = vbYes Then
            'limpiar()
            'grilla2.Rows.Clear()
            'End If
            'MsgBox("mismo registro")
            reagregargrilla()




        Else
            agregargrilla()
        End If


    End Sub
    Function agregargrilla()
        grilla.DefaultCellStyle.Font = New Font("Arial", 20)
        grilla.RowHeadersVisible = False




        'grilla.Columns(0).Width = 0
        grilla.AlternatingRowsDefaultCellStyle.BackColor = Color.SkyBlue



        If stxtclave.Text = "" Or stxtnombre.Text = "" Or stxtcosto.Text = "" Or stxtcostofinal.Text = "" Or stxtcostomililitros.Text = "" Or stxtmililitros.Text = "" Or stxtmililitrosusados.Text = "" Then

            MsgBox("Falta información para agregar", MsgBoxStyle.Exclamation, "Sistema")

        Else




            Dim cantidad_total, cantidadbd As Integer

            'cantidad total es la cantidad que se va a vender
            'se le suma 1, porque es el producto que apenas se va anexar a la lista de venta
            Try
                anexar()
                sumatorio()

            Catch ex As Exception

                MsgBox("No podemos procesar esta solicitud, Desbordamiento", MsgBoxStyle.Exclamation, "Sistema")
            End Try

        End If

    End Function
    Function reagregargrilla()


        'grilla2.Rows.Clear()

        grilla2.DefaultCellStyle.Font = New Font("Arial", 20)
        grilla2.RowHeadersVisible = False




        'grilla.Columns(0).Width = 0
        grilla2.AlternatingRowsDefaultCellStyle.BackColor = Color.SkyBlue



        If stxtclave.Text = "" Or stxtnombre.Text = "" Or stxtcosto.Text = "" Or stxtcostofinal.Text = "" Or stxtcostomililitros.Text = "" Or stxtmililitros.Text = "" Or stxtmililitrosusados.Text = "" Then

            MsgBox("Falta información para agregar", MsgBoxStyle.Exclamation, "Sistema")

        Else




            Dim cantidad_total, cantidadbd As Integer

            'cantidad total es la cantidad que se va a vender
            'se le suma 1, porque es el producto que apenas se va anexar a la lista de venta
            '  Try

            reanexar()
            resumatorio()

            ' Catch ex As Exception

            'MsgBox("No podemos procesar esta solicitud, Desbordamiento", MsgBoxStyle.Exclamation, "Sistema")
            ' End Try

        End If

    End Function

    Public Sub reanexar()
        If stxtclave.Text = "" Or stxtnombre.Text = "" Or stxtcosto.Text = "" Or stxtcostofinal.Text = "" Or stxtcostomililitros.Text = "" Or stxtmililitros.Text = "" Or stxtmililitrosusados.Text = "" Then

            MsgBox("No hay productos que agregar", MsgBoxStyle.Information, "Sistema")

        Else

            Try

                'MsgBox("reanexar")
                Dim i As Integer = grilla2.RowCount

                grilla2.Rows.Add("3", stxtclave.Text, stxtnombre.Text, stxtcosto.Text, stxtmililitros.Text, stxtcostomililitros.Text, stxtmililitrosusados.Text, stxtcostofinal.Text)
                '            grilla.Columns(1).Width = 350




                'una vez agregado a la grilla, lo insertamos en la BD tambien

                cerrarconexion()
                conexionMysql.Open()

                'MsgBox("el producto es:" & actividad)

                Dim Sql2 As String
                Sql2 = "INSERT INTO cotizador_marco_ind(idcotizador_marco, idproducto_serigrafia, cantidad_ml_usada, total_ml_usada) VALUES ('" & txttemporal.Text & "'," & stxtclave.Text & "," & stxtmililitrosusados.Text & "," & stxtcostomililitros.Text & ");"
                Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
                cmd2.ExecuteNonQuery()
                conexionMysql.Close()





                'sumatorio()

                'borrar()

                'txtclave.Focus()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
    End Sub
    Public Sub anexar()
        If stxtclave.Text = "" Or stxtnombre.Text = "" Or stxtcosto.Text = "" Or stxtcostofinal.Text = "" Or stxtcostomililitros.Text = "" Or stxtmililitros.Text = "" Or stxtmililitrosusados.Text = "" Then

            MsgBox("No hay productos que agregar", MsgBoxStyle.Information, "Sistema")

        Else

            Dim i As Integer = grilla.RowCount

            grilla.Rows.Add(i, stxtclave.Text, stxtnombre.Text, stxtcosto.Text, stxtmililitros.Text, stxtcostomililitros.Text, stxtmililitrosusados.Text, stxtcostofinal.Text)
            '            grilla.Columns(1).Width = 350


            'sumatorio()

            'borrar()

            'txtclave.Focus()
        End If
    End Sub

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grilla.CellContentClick

    End Sub

    Private Sub grilla_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grilla.CellContentDoubleClick
        Try

            'eliminar datos al dar doble clic.
            'grilla.CurrentRow.Index
            grilla.Rows.RemoveAt(grilla.CurrentRow.Index)
            'eliminado el registro, sumamos el total de valores. 
            sumatorio()
        Catch ex As Exception

        End Try
    End Sub
    Function sumatorio()
        Dim i As Integer = grilla.RowCount

        Dim j As Integer
        Dim suma, cantidad_productos As Double
        Dim a, b As String
        'suma de valores
        For j = 0 To i - 2
            'MsgBox("valosr de j:" & j)
            'a = venta.grillaventa.Item(j, 3).Value.ToString()
            a = grilla.Rows(j).Cells(7).Value
            'b = grilla.Rows(j).Cells(2).Value
            'cantidad_productos = cantidad_productos + b
            suma = suma + a
            'MsgBox(a)
        Next
        txtcostofinal.Text = suma
        'txtunidades.Text = cantidad_productos
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        'MsgBox(valor)
        'cambiamos de color el boton
        ''y cambiamos el texto
        'Try

        '    If valor = 1 Then

        '        Button1.Text = "Quitar Costo de luz"
        '        Button1.BackColor = Color.Coral
        '        valor = 0
        '        txtcostofinal.Text = CDbl(txtcostofinal.Text) + CDbl(txtcosto.Text)


        '    Else
        '        Button1.Text = "Agregar Costo de luz"
        '        Button1.BackColor = Color.DimGray
        '        valor = 1
        '        txtcostofinal.Text = CDbl(txtcostofinal.Text) - CDbl(txtcosto.Text)

        '    End If

        'Catch ex As Exception

        'End Try



    End Sub

    Private Sub Frmcalculomarco_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        valor = 1
        listaservicios.Visible = False
        calcularid()
        mostrarmarcos()
        grilla2.Visible = False
        grilla.Visible = True
        lbmensaje.Visible = False

    End Sub

    Function mostrarmarcos()



        cerrarconexion()

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

    Function calcularid()

        cerrarconexion()
        Dim id, i As Integer
        Try


            conexionMysql.Open()
            Dim Sql2 As String
            Sql2 = "select max(idcotizador_marco) from cotizador_marco;"
            Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            reader = cmd2.ExecuteReader
            reader.Read()
            id = reader.GetString(0).ToString
            conexionMysql.Close()

        Catch ex As Exception
            id = 0
        End Try


        txtclavemarco.Text = CInt(id) + 1



    End Function

    Private Sub Stxtnombre_TextChanged_1(sender As Object, e As EventArgs) Handles stxtnombre.TextChanged
        ' grilla2.Visible = False

        listaservicios.Visible = True
        listaservicios.Items.Clear()

        If stxtnombre.Text = "" Then
            listaservicios.Visible = False
            'sborrar()
            'stxtclave.Text = ""


        Else

            Try

                'cerramos la conexion
                cerrarconexion()

                Dim cantidad, i As Integer
                cantidad = 0
                conexionMysql.Open()
                Dim Sql2 As String
                Sql2 = "select count(*) from producto_serigrafia where nombre like '%" & stxtnombre.Text & "%';"
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
                Sql = "select nombre from producto_serigrafia where nombre like '%" & stxtnombre.Text & "%';"
                Dim cmd As New MySqlCommand(Sql, conexionMysql)
                reader = cmd.ExecuteReader
                For i = 1 To cantidad
                    reader.Read()

                    listaservicios.Items.Add(reader.GetString(0).ToString)
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

    Private Sub stxtnombre_KeyDown(sender As Object, e As KeyEventArgs) Handles stxtnombre.KeyDown
        If e.KeyCode = Keys.Down Then
            listaservicios.Focus()


        End If
    End Sub


    Private Sub listaservicios_KeyPress(sender As Object, e As KeyPressEventArgs) Handles listaservicios.KeyPress
        If e.KeyChar = Chr(13) Then
            cargarservicio()
        End If
    End Sub

    Private Sub listaservicios_DoubleClick(sender As Object, e As EventArgs) Handles listaservicios.DoubleClick
        listaservicios.Visible = False
        cargarservicio()

    End Sub
    Function guardar()
        Dim i As Integer = grilla.RowCount
        Dim j As Integer
        Dim actividad As String
        Dim cantidad, costo, idventa As Double
        Dim idproducto As String


        If txtclavemarco.Text = "" Or txtnombremarco.Text = "" Then
            MsgBox("Existen valores vacios, verifica", MsgBoxStyle.Information, "CTRL+y")
        Else



            'primero se inserta el registro general
            conexionMysql.Open()
            Dim Sql As String
            Sql = "INSERT INTO cotizador_marco (idcotizador_marco, medida, gasto_marco_final) VALUES (" & txtclavemarco.Text & ",'" & txtnombremarco.Text & "', " & CDbl(txtcostofinal.Text) & ");"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            cmd.ExecuteNonQuery()
            conexionMysql.Close()
            'txtclavemarco.Text = ""
            txtnombremarco.Text = ""
            txtcostofinal.Text = "" 'txttotalpagar.Text = ""
            conexionMysql.Close()





            conexionMysql.Open()
            Dim mlusados, costoml As String
            'suma de valores
            For j = 0 To i - 2
                'MsgBox("valosr de j:" & j)
                'a = venta.grillaventa.Item(j, 3).Value.ToString()

                idproducto = grilla.Rows(j).Cells(1).Value 'descripcion
                mlusados = grilla.Rows(j).Cells(6).Value 'cantidad
                costoml = grilla.Rows(j).Cells(7).Value 'costo
                cerrarconexion()
                conexionMysql.Open()

                'MsgBox("el producto es:" & actividad)

                Dim Sql2 As String
                Sql2 = "INSERT INTO cotizador_marco_ind(idcotizador_marco, idproducto_serigrafia, cantidad_ml_usada, total_ml_usada) VALUES ('" & txtclavemarco.Text & "'," & idproducto & "," & mlusados & "," & costoml & ");"
                Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
                cmd2.ExecuteNonQuery()
                conexionMysql.Close()
                'MsgBox("registro guardado" & j)
            Next

            MsgBox("Registro almacenado", MsgBoxStyle.Information, "CTRL+y")

            limpiar()
            grilla.Rows.Clear()
            calcularid()
            valor = 1

            'Button1.Text = "Agregar Costo de luz"
            'Button1.BackColor = Color.DimGray
            'valor = 1

            mostrarmarcos()
        End If

    End Function
    Private Sub Button4_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Bgrilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles bgrilla.CellContentClick


        'actividad = 1



        'llenargrillamarco()

    End Sub

    Private Sub bgrilla_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles bgrilla.CellContentDoubleClick
        'llenargrillamarco()
    End Sub
    Function llenargrillamarco()
        Try

            'Dim Variable As String = bgrilla.Item(0, bgrilla.CurrentRow.Index).Value
            'MsgBox(Variable)
            'Variable
            'grilla2.Visible = False
            'grilla.Visible = True
            'rbclave.Checked = True
            '----------------------------------------------------------
            grilla2.Visible = True
            grilla.Visible = False
            limpiaralgunos()
            stxtclave.Text = ""
            stxtnombre.Text = ""

            grilla2.Rows.Clear()

            '----------------------------------------------------------

            Dim variablemarco As Integer

            variablemarco = bgrilla.Item(0, bgrilla.CurrentRow.Index).Value
            txttemporal.Text = variablemarco

            Dim tipoventa, idventaservicioextra As Integer
            ' Try
            cerrarconexion()
            conexionMysql.Open()
            Dim Sql2 As String
            Sql2 = "select * from cotizador_marco where idcotizador_marco=" & variablemarco & ";"
            Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            reader = cmd2.ExecuteReader()
            reader.Read()
            txtnombremarco.Text = reader.GetString(1).ToString()
            txtcostofinal.Text = reader.GetString(2).ToString()
            conexionMysql.Close()



            'llenadogrillaventafolio()
            '---------------------se llena la grilla..........................

            grilla2.DefaultCellStyle.Font = New Font("Arial", 20)
            grilla2.RowHeadersVisible = False



            'MsgBox(variablemarco)
            '------------------------------------------------------------------------
            '---------contamos cuantos registros existen
            'Try

            conexionMysql.Open()
            Dim Sql77 As String
            Dim totalregistros As Integer
            'consultamos cuantos registros se insertaros para posteriormente actualizarlos en su registro original
            Sql77 = "select count(*) from cotizador_marco_ind, producto_serigrafia where cotizador_marco_ind.idcotizador_marco=" & variablemarco & " and cotizador_marco_ind.idproducto_serigrafia=producto_serigrafia.idproducto_serigrafia;"
            Dim cmd77 As New MySqlCommand(Sql77, conexionMysql)
            reader = cmd77.ExecuteReader()
            reader.Read()
            totalregistros = reader.GetString(0).ToString()
            'MsgBox("hay una cantidad de registros de " & totalregistros)
            '        cgrilla.Columns(6).Width = 100

            conexionMysql.Close()
            '-------------------------------------------------------------------------
            'Catch ex As Exception
            'MsgBox("error 1")
            'MsgBox(Err.Description)
            'End Try


            'Try
            cerrarconexion()
            'grilla.Columns(0).Width = 0
            grilla2.AlternatingRowsDefaultCellStyle.BackColor = Color.SkyBlue
            conexionMysql.Open()
            Dim actividad, descripcion As String
            Dim idproducto As Integer
            Dim Sql7 As String
            'consultamos cuantos registros se insertaros para posteriormente actualizarlos en su registro original
            Sql7 = "select  cotizador_marco_ind.idcotizador_marco_ind,producto_serigrafia.idproducto_serigrafia, producto_serigrafia.nombre, producto_serigrafia.costo_unidad, producto_serigrafia.cantidad_contenido, producto_serigrafia.costo_unidad, cotizador_marco_ind.cantidad_ml_usada, cotizador_marco_ind.total_ml_usada from cotizador_marco_ind, producto_serigrafia where cotizador_marco_ind.idcotizador_marco=" & variablemarco & " and cotizador_marco_ind.idproducto_serigrafia=producto_serigrafia.idproducto_serigrafia;"
            Dim cmd7 As New MySqlCommand(Sql7, conexionMysql)
            reader = cmd7.ExecuteReader()


            For i = 0 To totalregistros - 1

                reader.Read()
                grilla2.Rows.Add(reader.GetString(0).ToString(), reader.GetString(1).ToString(), reader.GetString(2).ToString(), reader.GetString(3).ToString(), reader.GetString(4).ToString(), reader.GetString(5).ToString(), reader.GetString(6).ToString(), reader.GetString(7).ToString())

                'cbproveedorcompras.Items.Add(reader.GetString(1).ToString())
            Next


            conexionMysql.Close()


            'Catch ex As Exception
            'MsgBox("error 2")
            'ox(Err.Description)
            'End Try


            'grilla.Columns(1).Width = 350
            '----------------------------- --------------------------------------------
        Catch ex As Exception
            MsgBox("Folio de venta no encontrado", MsgBoxStyle.Information, "CTRL+y")
            'sborrartodo()
            'grilla2.DataSource = ""
            cerrarconexion()
        End Try


        ' Catch ex As Exception

        'End Try
    End Function
    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Dim formulario As New frmproductoserigrafia
        'FRagregaranticipo.ShowDialog()
        formulario.ShowDialog()
    End Sub

    Private Sub Btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        guardar()
    End Sub


    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        'MsgBox("cerrando")
        Me.Close()

    End Sub

    Private Sub Grilla2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grilla2.CellContentClick

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        limpiar()
        txtnombremarco.Text = ""
    End Sub

    Private Sub grilla2_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grilla2.CellContentDoubleClick


        'Dim Variable As Integer = grilla2.Item(0, grilla2.CurrentRow.Index).Value

        ''una vez obenido el id del registro individual, lo eliminamos



        'cerrarconexion()
        'conexionMysql.Open()
        'Dim Sql As String
        'Sql = "delete from cotizador_marco_ind where idcotizador_marco_ind=" & Variable & ";"
        'Dim cmd As New MySqlCommand(Sql, conexionMysql)
        'cmd.ExecuteNonQuery()
        'conexionMysql.Close()
        ''MsgBox("Registro Eliminado", MsgBoxStyle.Information, "CTRL+y")





        ''eliminamos el registro de la grilla,
        'grilla2.Rows.RemoveAt(grilla2.CurrentRow.Index)

        ''realizamos las operaciones nuevamente 
        'resumatorio()

        ''MsgBox("variablemarco" & txttemporal.Text)
        'conexionMysql.Open()
        'Dim Sql2 As String
        'Sql2 = "update cotizador_marco set gasto_marco_final='" & txtcostofinal.Text & "' where idcotizador_marco='" & txttemporal.Text & "';"
        'Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
        'cmd2.ExecuteNonQuery()
        'conexionMysql.Close()
        'MsgBox("Registro Actualizado", MsgBoxStyle.Information, "CTRL+y")

        'mostrarmarcos()







    End Sub

    Private Sub Btneliminar_Click(sender As Object, e As EventArgs) Handles btneliminar.Click
        'se elimina el folio del marco que se busca.
        Try


            If txttemporal.Text <> "" Then
                'si es diferente a nada, osea que tenga algo. lo eliminamos

                '-------------------------------------------------------------
                'eliminamos primero los productos que lleva el marco, ya despues el marco principal.


                cerrarconexion()
                conexionMysql.Open()
                Dim Sql1 As String
                Sql1 = "delete from cotizador_marco_ind where idcotizador_marco='" & txttemporal.Text & "';"
                Dim cmd1 As New MySqlCommand(Sql1, conexionMysql)
                cmd1.ExecuteNonQuery()
                conexionMysql.Close()
                '  MsgBox("Registro Eliminado", MsgBoxStyle.Information, "CTRL+y")


                'limpiar()
                conexionMysql.Close()


                '---------------------------------------------------------------------------

                'MsgBox(Err.Description)
                cerrarconexion()
                conexionMysql.Open()
                Dim Sql As String
                Sql = "delete from cotizador_marco where idcotizador_marco='" & txttemporal.Text & "';"
                Dim cmd As New MySqlCommand(Sql, conexionMysql)
                cmd.ExecuteNonQuery()
                conexionMysql.Close()
                MsgBox("Registro Eliminado", MsgBoxStyle.Information, "CTRL+y")


                limpiar()
                'se muestran los marcos nuevamente.
                mostrarmarcos()

                conexionMysql.Close()

                ' limpiar2()





            End If


        Catch ex As Exception
            'MsgBoxResult.Ok
            'ex.Message
            MsgBox("Error:" & ex.Message)

        End Try



    End Sub

    Private Sub Txttemporal_TextChanged(sender As Object, e As EventArgs) Handles txttemporal.TextChanged
        If txttemporal.Text <> "" Then
            lbmensaje.Visible = True
        Else
            lbmensaje.Visible = False

        End If
    End Sub

    Function resumatorio()
        Dim i As Integer = grilla2.RowCount

        Dim j As Integer
        Dim suma, cantidad_productos As Double
        Dim a, b As String
        'suma de valores
        MsgBox("resumatorio")
        For j = 0 To i - 2
            'MsgBox("valosr de j:" & j)
            'a = venta.grillaventa.Item(j, 3).Value.ToString()
            a = grilla2.Rows(j).Cells(7).Value
            'b = grilla.Rows(j).Cells(2).Value
            'cantidad_productos = cantidad_productos + b
            suma = suma + a
            'MsgBox(a)

        Next
        txtcostofinal.Text = suma
        'txtunidades.Text = cantidad_productos


        conexionMysql.Open()
        Dim Sql22 As String
        Sql22 = "update cotizador_marco set gasto_marco_final='" & txtcostofinal.Text & "' where idcotizador_marco='" & txttemporal.Text & "';"
        Dim cmd22 As New MySqlCommand(Sql22, conexionMysql)
        cmd22.ExecuteNonQuery()
        conexionMysql.Close()
        MsgBox("Registro Actualizado", MsgBoxStyle.Information, "CTRL+y")

        mostrarmarcos()




    End Function

    Private Sub bgrilla_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles bgrilla.CellClick
        actividad = 1



        llenargrillamarco()
    End Sub

    Private Sub grilla2_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grilla2.CellDoubleClick


        Dim Variable As Integer = grilla2.Item(0, grilla2.CurrentRow.Index).Value

        'una vez obenido el id del registro individual, lo eliminamos



        cerrarconexion()
        conexionMysql.Open()
        Dim Sql As String
        Sql = "delete from cotizador_marco_ind where idcotizador_marco_ind=" & Variable & ";"
        Dim cmd As New MySqlCommand(Sql, conexionMysql)
        cmd.ExecuteNonQuery()
        conexionMysql.Close()
        'MsgBox("Registro Eliminado", MsgBoxStyle.Information, "CTRL+y")





        'eliminamos el registro de la grilla,
        grilla2.Rows.RemoveAt(grilla2.CurrentRow.Index)

        'realizamos las operaciones nuevamente 
        resumatorio()

        'MsgBox("variablemarco" & txttemporal.Text)
        conexionMysql.Open()
        Dim Sql2 As String
        Sql2 = "update cotizador_marco set gasto_marco_final='" & txtcostofinal.Text & "' where idcotizador_marco='" & txttemporal.Text & "';"
        Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
        cmd2.ExecuteNonQuery()
        conexionMysql.Close()
        MsgBox("Registro Actualizado", MsgBoxStyle.Information, "CTRL+y")

        mostrarmarcos()




    End Sub
End Class