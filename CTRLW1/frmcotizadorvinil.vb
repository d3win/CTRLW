Imports MySql.Data.MySqlClient
Public Class frmcotizadorvinil
    Public indexidusuario As Integer
    Public folioventa As String
    Public foliobusqueda As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim formulario As New frmnuevovinil
        'FRagregaranticipo.ShowDialog()
        formulario.ShowDialog()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub Button79_Click(sender As Object, e As EventArgs) Handles Button79.Click
        Dim formulario As New frmvinildificultad
        'FRagregaranticipo.ShowDialog()
        formulario.ShowDialog()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter





    End Sub
    Function cargardificultad()
        'cargamos los valores en dificultad



        cbdificultad.Items.Clear()

        Try

            'cerramos la conexion
            cerrarconexion()

            Dim cantidad, i As Integer
            cantidad = 0
            conexionMysql.Open()
            Dim Sql2 As String
            Sql2 = "select count(*) from vinildificultad;"
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
            Sql = "select * from vinildificultad;"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            reader = cmd.ExecuteReader
            For i = 1 To cantidad
                reader.Read()

                cbdificultad.Items.Add(reader.GetString(1).ToString)
            Next


            conexionMysql.Close()

        Catch ex As Exception
            cerrarconexion()

        End Try


    End Function
    Function cerrarconexion()
        If conexionMysql.State = ConnectionState.Open Then
            conexionMysql.Close()

        End If
    End Function
    Private Sub Vtxtnombreproducto_TextChanged(sender As Object, e As EventArgs) Handles vtxtnombreproducto.TextChanged
        'grilla2.Visible = False

        lblistaproductos.Visible = True
        lblistaproductos.Items.Clear()

        If vtxtnombreproducto.Text = "" Then
            lblistaproductos.Visible = False
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
                Sql2 = "select count(*) from vinilproducto where nombre_producto like '%" & vtxtnombreproducto.Text & "%';"
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
                Sql = "select nombre_producto from vinilproducto where nombre_producto like '%" & vtxtnombreproducto.Text & "%';"
                Dim cmd As New MySqlCommand(Sql, conexionMysql)
                reader = cmd.ExecuteReader
                For i = 1 To cantidad
                    reader.Read()

                    lblistaproductos.Items.Add(reader.GetString(0).ToString)
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
    Function cargarproducto()
        'aqui lo que hacemos es cargar el servicio a la caja de texto de txtnombre y mandamos la clave al la caja de texto txtclave,
        Try

            conexionMysql.Open()
            Dim Sql As String
            Sql = "select * from vinilproducto where nombre_producto='" & lblistaproductos.Text & "';"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            reader = cmd.ExecuteReader()
            reader.Read()
            vtxtclaveproducto.Text = reader.GetString(0).ToString()

            'vtxtnombreproducto.Text = reader.GetString(1).ToString()

            ' vtxtcmexistentes.Text = reader.GetString(4).ToString()
            ' vtxtcostocm.Text = reader.GetString(9).ToString()
            ''si encuentra el valor, llamamos al focus del boton.
            reader.Close()
            conexionMysql.Close()
        Catch ex As Exception
            '    MsgBox("error de cargar servicio")
            cerrarconexion()
        End Try


    End Function

    Private Sub Lblistaproductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lblistaproductos.SelectedIndexChanged
        ' cargarproducto()
    End Sub

    Private Sub lblistaproductos_DoubleClick(sender As Object, e As EventArgs) Handles lblistaproductos.DoubleClick
        cargarproducto()
        lblistaproductos.Visible = False

    End Sub
    Function comprobartipoingreso()
        Dim tipo As Integer
        tipo = tipoingreso()
        'MsgBox(tipo)
        If tipo = 2 Then
            MsgBox("Eres un Trabajador sin permiso para realizar esta accion", MsgBoxStyle.Exclamation, "Ctrly")
        Else
            'MsgBox("Existe un problema al eliminar el registro", MsgBoxStyle.Exclamation, "Sistema")
        End If

    End Function
    Function cargarformadepago()


        'limpiar el combo para que no se duplique
        'cbformadepago.Items.Clear()
        cbformadepagoservicios.Items.Clear()

        Try


            Dim cantidadproveedor, i As Integer
            cerrarconexion()

            conexionMysql.Open()
            Dim Sql As String
            Sql = "select count(*)as contador from tipo_pago;"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            reader = cmd.ExecuteReader()
            reader.Read()
            cantidadproveedor = reader.GetString(0).ToString()

            conexionMysql.Close()


            cerrarconexion()

            conexionMysql.Open()
            Dim Sql2 As String
            Sql2 = "select * from tipo_pago;"
            Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            reader = cmd2.ExecuteReader()

            For i = 1 To cantidadproveedor

                reader.Read()

                '       cbformadepago.Items.Add(reader.GetString(1).ToString())
                cbformadepagoservicios.Items.Add(reader.GetString(1).ToString())
            Next



            '  cbformadepago.SelectedIndex = 0
            cbformadepagoservicios.SelectedIndex = 0

            reader.Close()

            conexionMysql.Close()


        Catch ex As Exception

        End Try



    End Function
    Private Sub Frmcotizadorvinil_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarformadepago()

        cargardificultad()
        lblistaproductos.Visible = False
        grilla.DefaultCellStyle.Font = New Font("Arial", 12)
        grilla.RowHeadersVisible = False
        grilla.AlternatingRowsDefaultCellStyle.BackColor = Color.SkyBlue

        '        stxtlistaclientes.Visible = False
        stxtcliente.Text = "usuario usuario usuario"
        stxtlistaclientes.Visible = False
        obtenerfolio()
        picturepagado.Visible = False
        grilla2.Visible = False

    End Sub
    Public Sub obtenerfolio()
        Dim folio As Integer

        Try

            cerrarconexion()


            'grilla.Rows.Clear()
            conexionMysql.Open()
            Dim sql2 As String
            sql2 = "select max(idventa) from venta;"
            Dim cmd2 As New MySqlCommand(sql2, conexionMysql)
            reader = cmd2.ExecuteReader()
            reader.Read()
            folio = reader.GetString(0).ToString
            lbfolio.Text = folio + 1



            conexionMysql.Close()
            'MsgBox("si hay folio")

        Catch ex As Exception
            lbfolio.Text = folio + 1
            MsgBox("Al parecer será tu primer venta, Esperemos todo marche bien", MsgBoxStyle.Information, "Sistema")
            'se insertan los datos iniciales para que comienze a trabajar el sistema
            ' inserciondedatosiniciales()

            cerrarconexion()


            'Dim claveroot As String
            'conexionMysql.Open()
            'Dim Sqlx As String
            'Sqlx = "select usuario from usuario where usuario= 'root';"
            'Dim cmdx As New MySqlCommand(Sqlx, conexionMysql)
            'reader = cmdx.ExecuteReader()
            'reader.Read()
            'Try
            '    claveroot = reader.GetString(0).ToString
            'Catch ex2 As Exception
            '    claveroot = ""
            'End Try

            'cerrarconexion()
            'conexionMysql.Close()


            'If claveroot = "" Then
            '    conexionMysql.Open()
            '    Dim Sql As String
            '    Sql = "INSERT INTO usuario (usuario, nombre, ap, am, telefono, correo, direccion, tipo_usuario) VALUES ('root', 'root', 'root', 'root', 'root', 'root', 'root', 1);"
            '    Dim cmd As New MySqlCommand(Sql, conexionMysql)
            '    cmd.ExecuteNonQuery()
            '    conexionMysql.Close()
            '    'llamar a la funcion limpiar, para limpiar las cajas cada vez que se agrege una nueva compra.
            '    MsgBox("Registro guardado correctamente", MsgBoxStyle.Information, "Sistema")
            '    conexionMysql.Close()


            '    cerrarconexion()
            '    conexionMysql.Open()
            '    Dim Sql4 As String
            '    Sql4 = "INSERT INTO `dwin`.`CLIENTE` (`idcliente`, `nombre`, `ap`, `am`, `edad`, `direccion`, `telefono`, `correo`) VALUES ('1', 'USUARIO', 'USUARIO', 'USUARIO', '000', '000', '000', '000');"
            '    Dim cmd4 As New MySqlCommand(Sql4, conexionMysql)
            '    cmd4.ExecuteNonQuery()
            '    conexionMysql.Close()
            '    MsgBox("Registro guardado correctamente", MsgBoxStyle.Information, "Sistema")

            'End If


        End Try

    End Sub


    Private Sub Cbdificultad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbdificultad.SelectedIndexChanged

        ' cargardificultad()

        calculocm2()
        precioindividual()
        cargardatosdificultad()




    End Sub
    Function cargardatosdificultad()
        Try
            conexionMysql.Open()
            Dim Sql As String
            Sql = "select precio from vinildificultad where dificultad='" & cbdificultad.Text & "';"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            reader = cmd.ExecuteReader()
            reader.Read()
            vtxtvalordificultad.Text = reader.GetString(0).ToString()
            reader.Close()
            conexionMysql.Close()
        Catch ex As Exception
            '    MsgBox("error de cargar servicio")
            cerrarconexion()
        End Try
    End Function

    Private Sub vtxtnombreproducto_KeyDown(sender As Object, e As KeyEventArgs) Handles vtxtnombreproducto.KeyDown
        If e.KeyCode = Keys.Down Then
            lblistaproductos.Focus()
        End If
    End Sub

    Private Sub Vtxtalto_TextChanged(sender As Object, e As EventArgs) Handles vtxtalto.TextChanged
        calculocm2()
        precioindividual()

    End Sub
    Function calculocm2()
        Try

            vtxtcm2.Text = CDbl(vtxtalto.Text) * CDbl(vtxtancho.Text)

        Catch ex As Exception

        End Try

    End Function

    Private Sub Vtxtancho_TextChanged(sender As Object, e As EventArgs) Handles vtxtancho.TextChanged
        calculocm2()
        precioindividual()

    End Sub
    Function precioindividual()
        Try
            Dim re1, re2 As Double

            re1 = CDbl(vtxtcm2.Text) * (CDbl(vtxtcostocm.Text) / 10000) * CDbl(vtxtvalordificultad.Text)
            vtxtprecioindividual.Text = Math.Round(re1, 2)
            re2 = CDbl(vtxtprecioindividual.Text) * CDbl(vtxtpiezas.Text)
            vtxtpreciototal.Text = Math.Round(re2, 2)
        Catch ex As Exception

        End Try



    End Function

    Private Sub Vtxtpiezas_TextChanged(sender As Object, e As EventArgs) Handles vtxtpiezas.TextChanged
        precioindividual()

    End Sub

    Private Sub Vtxtvalordificultad_TextChanged(sender As Object, e As EventArgs) Handles vtxtvalordificultad.TextChanged

        precioindividual()

    End Sub

    Private Sub Vtxtclaveproducto_TextChanged(sender As Object, e As EventArgs) Handles vtxtclaveproducto.TextChanged
        'obtenerfolio()
        cargarclave()

    End Sub
    Function cargarclave()
        Try
            lblistaproductos.Visible = False


            If vtxtclaveproducto.Text = "" Then
                limpiarcajas()
            Else



                conexionMysql.Open()
                Dim Sql As String
                Sql = "select * from vinilproducto where idproductovinil='" & vtxtclaveproducto.Text & "';"
                Dim cmd As New MySqlCommand(Sql, conexionMysql)
                reader = cmd.ExecuteReader()
                reader.Read()
                'vtxtclaveproducto.Text = reader.GetString(0).ToString()

                vtxtnombreproducto.Text = reader.GetString(1).ToString()
                lblistaproductos.Visible = False

                ''si encuentra el valor, llamamos al focus del boton.
                reader.Close()
                conexionMysql.Close()


                conexionMysql.Open()

                Dim Sql2 As String
                Sql2 = "select * from vinilproducto where idproductovinil='" & vtxtclaveproducto.Text & "';"
                Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
                reader = cmd2.ExecuteReader()
                reader.Read()
                vtxtcmexistentes.Text = reader.GetString(4).ToString()
                vtxtcostocm.Text = reader.GetString(7).ToString()

                conexionMysql.Close()
                vtxtdescripcion.Focus()

            End If


        Catch ex As Exception
            cerrarconexion()

            limpiarcajas()
            lblistaproductos.Visible = False
        End Try
    End Function
    Function limpiartotales()
        'stxttotal1.Text = ""
        stxtresto1.Text = ""
        stxtanticipo1.Text = ""

    End Function
    Function limpiarcajas()

        ' vtxtclaveproducto.Text = ""
        vtxtnombreproducto.Text = ""
        vtxtcmexistentes.Text = ""
        vtxtcostocm.Text = ""



    End Function

    Private Sub Vtxtcostocm_TextChanged(sender As Object, e As EventArgs) Handles vtxtcostocm.TextChanged
        precioindividual()

    End Sub

    Private Sub lblistaproductos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lblistaproductos.KeyPress


    End Sub

    Private Sub lblistaproductos_KeyDown(sender As Object, e As KeyEventArgs) Handles lblistaproductos.KeyDown
        If e.KeyCode = Keys.Enter Then

            cargarproducto()
            cargarclave()



        End If
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        If vtxtprecioindividual.Text = "0" Or vtxtpreciototal.Text = "0" Or vtxtalto.Text = "0" Or vtxtancho.Text = "" Or vtxtvalordificultad.Text = "" Or vtxtpiezas.Text = "" Then

            MsgBox("No hay servicios que agregar", MsgBoxStyle.Information, "Sistema")

        Else
            'habilito la caja de anticipo para que pueda agregar un valor 
            stxtanticipo1.Enabled = True

            'borrar()
            limpiartotales()
            picturepagado.Visible = False


            'limpio la caja de busqueda para evitar conflictos
            stxtfoliobusquedaventa.Text = ""
            Dim cm2 As Double
            Dim i As Integer = grilla.RowCount
            Dim gananciatotal As Double


            grilla2.Visible = False
            grilla.Visible = True
            'txtcostoconproducto.Text = Math.Round(f, 2)
            'gananciatotal = CDbl(stxtgananciaproducto.Text) * CDbl(stxtcantidad.Text)
            'gananciatotal = Math.Round(gananciatotal, 2)
            cm2 = CDbl(vtxtpiezas.Text) * CDbl(vtxtcm2.Text)


            grilla.Rows.Add(i, vtxtclaveproducto.Text, vtxtnombreproducto.Text, vtxtdescripcion.Text, vtxtpiezas.Text, vtxtalto.Text, vtxtancho.Text, cm2, vtxtprecioindividual.Text, vtxtpreciototal.Text, cbdificultad.Text, vtxtvalordificultad.Text)
            ' sgrilla.Columns(1).Width = 350


            sumatorio()

            borrar()

            vtxtclaveproducto.Focus()
        End If
    End Sub

    Function sumatorio()
        Dim i As Integer = grilla.RowCount

        Dim j As Integer
        Dim sumatotal, totalpiezas, sumasin, cantidad_productos, sumagananciatotal As Double
        Dim a, b As String
        'suma de valores
        For j = 0 To i - 2
            'MsgBox("valosr de j:" & j)
            'a = venta.grillaventa.Item(j, 3).Value.ToString()
            a = grilla.Rows(j).Cells(9).Value 'totalultimo
            b = grilla.Rows(j).Cells(4).Value 'cantidad piezas
            'd = grilla.Rows(j).Cells(7).Value 'totalganancia

            'b = grilla.Rows(j).Cells(3).Value
            'cantidad_productos = cantidad_productos + b
            'sumacon = sumacon + a
            'sumasin = sumasin + c
            sumatotal = sumatotal + a
            totalpiezas = totalpiezas + b
            'MsgBox(a)
        Next
        '        stxtpagarcon.Text = sumacon
        '       stxtpagarsin.Text = sumasin
        stxttotal1.Text = Math.Round(sumatotal, 2)
        vtxtpiezastotales.Text = totalpiezas


        '      stxtgananciatotalproductos.Text = sumagananciatotal

        'el valor siguiente es como funcionaba anteriormente
        '        stxttotal.Text = suma
        'stxttotalproductos.Text = cantidad_productos
    End Function
    Function borrar()
        vtxtclaveproducto.Text = ""
        vtxtnombreproducto.Text = ""
        vtxtpiezas.Text = ""
        vtxtalto.Text = ""
        vtxtancho.Text = ""
        vtxtcm2.Text = ""
        'vtxtpreciototal.Text = ""
        'vtxtprecioindividual.Text = ""
        'vtxtvalordificultad.Text = ""
        vtxtcmexistentes.Text = ""
        vtxtcostocm.Text = ""
        vtxtdescripcion.Text = ""

    End Function

    Private Sub Grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grilla.CellContentClick

    End Sub
    Function comprobarcaja()
        Dim registrar As Boolean
        Dim idestado, idmaximo, cantidad As Integer

        '---------------------------
        'PRIMERO COMPROBAMOS QUE EXISTE UNA CAJA, PRIMER REGISTRO
        '------------------------------
        Try

            conexionMysql.Open()
            Dim sql22 As String
            sql22 = "select count(idcaja) from caja;"
            Dim cmd22 As New MySqlCommand(sql22, conexionMysql)
            reader = cmd22.ExecuteReader
            reader.Read()
            cantidad = reader.GetString(0).ToString()
            conexionMysql.Close()

            '---------------------------
        Catch ex As Exception
            'cantidad = 0
        End Try


        If cantidad <= 0 Then
            registrar = False
            idestado = 1
            Return idestado
        Else

            Try
                'todos los datos son obtenidos con la fecha actual para evitar conflictos
                Dim dia, mes, año, fecha, fechacaja, horacaja As String
                Dim hora2, minuto, segundo, hora As String
                hora2 = Now.Hour()
                minuto = Now.Minute()
                segundo = Now.Second()

                hora = hora2 & ":" & minuto & ":" & segundo

                dia = Date.Now.Day
                mes = Date.Now.Month
                año = Date.Now.Year
                fecha = año & "-" & mes & "-" & dia
                Dim fechahoy As String

                '---------------------------
                'PRIMERO OBTENERMOS EL MAYOR ID
                '------------------------------
                conexionMysql.Open()
                Dim sql2 As String
                sql2 = "select max(idcaja)as maximo from caja;"
                Dim cmd2 As New MySqlCommand(sql2, conexionMysql)
                reader = cmd2.ExecuteReader
                reader.Read()
                idmaximo = reader.GetString(0).ToString()
                conexionMysql.Close()
                '---------------------------

                conexionMysql.Open()
                Dim sql25 As String
                sql25 = "select estado from caja where idcaja=" & idmaximo & ";"
                Dim cmd25 As New MySqlCommand(sql25, conexionMysql)
                reader = cmd25.ExecuteReader
                reader.Read()
                idestado = reader.GetString(0).ToString()
                conexionMysql.Close()
                registrar = False
                'MsgBox("No existe caja abierta", MsgBoxStyle.Exclamation, "CTRL+y")


                Return idestado

            Catch ex As Exception
                registrar = True
                ' MsgBox("error")
            End Try


        End If

        'If idestado = 0 Then
        '    'en caso de que exista una caja abierta, entonces abrimos la ventana para cerrar la caja
        '    Dim formulario As New FRcerrarcaja
        '    formulario.ShowDialog()

        'End If




    End Function
    Private Sub Button78_Click(sender As Object, e As EventArgs) Handles Button78.Click

        Dim estadocaja As Integer


        estadocaja = comprobarcaja()

        If estadocaja = 0 Then






            obtenerfolio()
            Dim respuesta As String

            'comprobar cuantas filas tiene la grilla donde se almacenan los valores para agregar a la venta

            'Dim respuesta As String

            'comprobar cuantas filas tiene la grilla donde se almacenan los valores para agregar a la venta

            'If lbfolio.Text <> "" Then


            If stxtfoliobusquedaventa.Text = "" Then


                sventa()
                'borrar()
                vtxtpreciototal.Text = ""
                vtxtprecioindividual.Text = ""
                'vtxtvalordificultad.Text = ""
            Else
                MsgBox("Existe una busqueda actual, vamos a cancelarla y podras continuar", MsgBoxStyle.Information, "CTRL+y")
                stxtfoliobusquedaventa.Text = ""
                stxttotal1.Text = ""
                stxtanticipo1.Text = ""
                stxtresto1.Text = ""
                '            grilla.Rows.Clear()

                'una vez que se borre todo, buscamos el folio del servicio para que solito limpie todo
                buscarfolioservicio()

                'limpiarcajas()
            End If


            'Else
            'respuesta = MsgBox("Estas consultado un folio, ¿quieres realizar una nueva venta?", MsgBoxStyle.YesNo, "CTRL+y")

            'If respuesta = vbYes Then
            'nuevoservicio()
            'stxtfoliobusquedaventa.Text = ""
            'stxtclave.Focus()

            'End If

            'End If

            'COMPROBAMOS QUE LA CAJA DE TEXTO DE BUSQUEDA DE FOLIO ESTE VACIA PARA PODER REALIZAR UNA VENTA



            'sventa()




        Else
            MsgBox("No existe ninguna caja abierta", MsgBoxStyle.Information, "CTRL+y")
        End If

    End Sub
    Function sventa()
        'Try
        Dim idtipopago As Integer
        ' MsgBox("intento 1")

        If stxttotal1.Text = "" Or stxtanticipo1.Text = "" Or stxtresto1.Text = "" Then
            MsgBox("No hay ventas que realizar, revisa tu información", MsgBoxStyle.Information, "Sistema")
            stxtanticipo1.BackColor = Color.DarkSalmon
            stxtanticipo1.Focus()
            stxtanticipo1.Enabled = True






            'txttotal.Text = ""
        Else
            'obtener fecha y hora

            Dim dia, mes, año, fecha, fechanueva, hora, minuto, segundo, hora2 As String
            hora2 = Now.Hour()
            minuto = Now.Minute()
            segundo = Now.Second()

            hora = hora2 & ":" & minuto & ":" & segundo

            dia = Date.Now.Day
            mes = Date.Now.Month
            año = Date.Now.Year
            fecha = año & "-" & mes & "-" & dia
            fecha = fecha + " " + hora

            'Dim dia, mes, año, fecha As String
            'Dim hora2, minutos, segundo, hora, minuto As String
            'hora2 = Now.Hour()
            'minuto = Now.Minute()
            'segundo = Now.Second()

            'hora = hora2 & ":" & minuto & ":" & segundo

            'dia = Date.Now.Day
            'mes = Date.Now.Month
            'año = Date.Now.Year
            'fecha = año & "-" & mes & "-" & dia



            '------------------ insertar reginstro en tabla venta ---------------------------------------

            cerrarconexion()
            Dim idcliente As Integer

            idcliente = 1

            Try
                cerrarconexion()
                conexionMysql.Open()
                Dim Sql31 As String
                'consultamos el id del cliente para obtener un registro de quien es al que se le esta vendiendo
                Sql31 = "select idcliente from cliente where concat(nombre, ' ',ap, ' ', am) like '%" & stxtcliente.Text & "%';"
                Dim cmd31 As New MySqlCommand(Sql31, conexionMysql)
                reader = cmd31.ExecuteReader()
                reader.Read()
                idcliente = reader.GetString(0).ToString()
                idvinilusuario = idcliente
                conexionMysql.Close()
                'MsgBox(idcliente)
            Catch ex As Exception
                idcliente = 1
                '-MsgBox(idcliente)
            End Try



            '----------------consultamos al usuario que esta realizando la venta ------------------
            Dim idusuario As Integer

            cerrarconexion()


            Dim usuario As String
            usuario = frmindex.usuarioactual



            conexionMysql.Open()
            Dim Sql32 As String
            'consultamos el id del usuario para obtener un registro de quien es al que se le esta vendiendo
            Sql32 = "select idusuario from usuario where usuario= '" & usuario & "';"
            Dim cmd32 As New MySqlCommand(Sql32, conexionMysql)
            reader = cmd32.ExecuteReader()
            reader.Read()
            idusuario = reader.GetString(0).ToString()
            conexionMysql.Close()
            '--------------------------------------------------------------------------
            cerrarconexion()

            '-------------------------------------
            Try

                '---------------------------------
                '--------OBTENEMOS EL ID DEL TIPO DE PAGO
                conexionMysql.Open()
                Dim Sql322 As String
                'consultamos el id del cliente para obtener un registro de quien es al que se le esta vendiendo
                Sql322 = "SELECT idtipo_pago from tipo_pago where tipo='" & cbformadepagoservicios.Text & "';"
                Dim cmd322 As New MySqlCommand(Sql322, conexionMysql)
                reader = cmd322.ExecuteReader()
                reader.Read()
                idtipopago = reader.GetString(0).ToString()
                '-------------------------------------------------
                '----------datos que se van al reporte

                conexionMysql.Close()


            Catch ex As Exception

            End Try
            '-------------------------------------


            '------------------------------------ insertamos el anticipo o el total que debe ..
            '-------------------------------------EN LA TABLA DE SERVICIOS_ANTICIPO

            Dim fechaentrega As String

            fechaentrega = DateTimePicker1.Value.ToString("yyyy/MM/dd")

            'MsgBox(fechaentrega)
            conexionMysql.Open()
            Dim Sql As String
            Sql = "INSERT INTO venta (idventa, cantidad, total, fecha, hora, idcliente, idusuario, fechaentrega, anticipo, resto, tipoventa,idtipo_pago) VALUES (" & lbfolio.Text & "," & vtxtpiezastotales.Text & ", " & CDbl(stxttotal1.Text) & ", '" & fecha & "','" & hora & "', " & idcliente & ", " & idusuario & ",'" & fechaentrega & "'," & stxtanticipo1.Text & "," & stxtresto1.Text & ",'3'," & idtipopago & ");"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            cmd.ExecuteNonQuery()
            conexionMysql.Close()






            '---------------------------------------------------------
            'MsgBox(fechaentrega)
            conexionMysql.Open()
            Dim Sql33 As String
            ' Sql33 = "INSERT INTO venta (idventa, cantidad, total, fecha, hora, idcliente, idusuario, fechaentrega, anticipo, resto, tipoventa) VALUES (" & slbfolio.Text & "," & stxttotalproductos.Text & ", " & CDbl(stxttotal.Text) & ", '" & fecha & "','" & hora & "', " & idcliente & ", " & idusuario & ",'" & fechaentrega & "'," & stxtanticipo.Text & "," & stxtresto.Text & ",'2');"
            Sql33 = "INSERT INTO `SERVICIOS_vENTAS` (`idventa`, `fecha`, `hora`, `idcliente`, `anticipo`, `total`) VALUES (" & lbfolio.Text & ", '" & fecha & "', '" & hora & "', " & idcliente & ", " & stxtanticipo1.Text & ", " & CDbl(stxttotal1.Text) & ");"
            Dim cmd33 As New MySqlCommand(Sql33, conexionMysql)
            cmd33.ExecuteNonQuery()
            conexionMysql.Close()

            '---------------------------------------------------------------
            'ANTES DE BORRAR TODA LA INFORMACIÓN, MANDO A IMPRIMIR EL REPORTE (NOTA)




            borrar()


            '           stxtnombre.Text = ""
            '          stxtprecio.Text = ""
            'stxtpagar = CDbl(stxttotal.Text)
            stxttotal1.Text = ""
            stxtanticipo1.Text = ""
            stxtresto1.Text = ""
            vtxtpiezastotales.Text = ""

            '        stxtclave.Text = ""


            conexionMysql.Close()


            'stxtnombre.Text = ""
            'stxtprecio.Text = ""
            'stxtpagar = CDbl(stxttotal.Text)
            stxttotal1.Text = ""
            stxtanticipo1.Text = ""
            stxtresto1.Text = ""
            'stxttotalproductos.Text = ""
            'stxtclave.Text = ""






            '------------------ FIN insertar reginstro en tabla venta ---------------------------------------


            '------------------ insertar reginstro en tabla ventaIND ---------------------------------------
            Dim i As Integer = grilla.RowCount
            Dim j, valor As Integer
            Dim actividad, dificultad, descripcion As String
            Dim cantidad, costo, idventa, cm2 As Double
            Dim idproducto, id, alto, ancho As String

            conexionMysql.Open()

            'suma de valores
            For j = 0 To i - 2
                'MsgBox("valosr de j:" & j)
                'id = venta.grillaventa.Item(j, 3).Value.ToString()
                id = grilla.Rows(j).Cells(1).Value 'descripcion

                actividad = grilla.Rows(j).Cells(2).Value 'descripcion
                'cantidad = grilla.Rows(j).Cells(3).Value 'cantidad
                cantidad = grilla.Rows(j).Cells(4).Value 'cantidad
                descripcion = grilla.Rows(j).Cells(3).Value 'cantidad




                costo = grilla.Rows(j).Cells(8).Value 'precio
                idproducto = grilla.Rows(j).Cells(1).Value
                alto = grilla.Rows(j).Cells(5).Value
                ancho = grilla.Rows(j).Cells(6).Value
                cm2 = grilla.Rows(j).Cells(7).Value
                dificultad = grilla.Rows(j).Cells(10).Value
                valor = grilla.Rows(j).Cells(11).Value

                cerrarconexion()

                conexionMysql.Open()

                'MsgBox("el producto es:" & actividad)

                Dim Sql2 As String
                Sql2 = "INSERT INTO ventaind (actividad, cantidad, costo, idventa,idproducto,descripcion,ancho,alto,cm2,iddificultad,valor) VALUES ('" & actividad & "'," & cantidad & "," & costo & "," & lbfolio.Text & ",'" & idproducto & "','" & descripcion & "','" & ancho & "', '" & alto & "','" & cm2 & "', '" & dificultad & "','" & valor & "');"
                Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
                cmd2.ExecuteNonQuery()
                conexionMysql.Close()
            Next

            '----------------------------- se hace actualización a la tabla de productos--------------
            Dim totalactualizar, m, n As Integer
            cerrarconexion()

            conexionMysql.Open()
            Dim Sql3 As String
            'consultamos cuantos registros se insertaros para posteriormente actualizarlos en su registro original
            Sql3 = "select count(distinct idproducto) from ventaind where idventa=" & lbfolio.Text & " and idproducto <> '';"
            Dim cmd3 As New MySqlCommand(Sql3, conexionMysql)
            reader = cmd3.ExecuteReader()
            reader.Read()
            totalactualizar = reader.GetString(0).ToString()


            'MsgBox(totalactualizar)

            conexionMysql.Close()

            'for para dar las vueltas necesarias para poder actualizar
            '---------------DECLARACION DE VARIABLES------------------
            Dim claveproducto, cantidadpro As Integer
            Dim matriz(totalactualizar, 3) As String
            '-------------------------------------------
            cantidadpro = 0
            '----------------------------- se hace actualización a la tabla de productos--------------
            cerrarconexion()
            conexionMysql.Open()
            Dim Sql4 As String
            'consultamos cuantos registros se insertaros para posteriormente actualizarlos en su registro original
            Sql4 = "select idproducto, sum(cantidad) from ventaind where idventa=" & lbfolio.Text & "  group by idproducto;"
            Dim cmd4 As New MySqlCommand(Sql4, conexionMysql)
            reader = cmd4.ExecuteReader()




            For m = 1 To totalactualizar
                reader.Read()


                'guardamos los valores en una matriz
                matriz(m, 0) = reader.GetString(0).ToString()
                matriz(m, 1) = reader.GetString(1).ToString()
                'MsgBox("el registro de la matriz(idproducto):" & matriz(m, 0))
                'MsgBox("el registro de la matriz(cantidad):" & matriz(m, 1))
                'MsgBox(matriz(m, 0))
                'MsgBox(matriz(m, 1))

            Next
            conexionMysql.Close()

            '-----------------------consultamos cuantos valores existes de tal idproducto

            Dim x, xcantidad As Integer

            For x = 1 To totalactualizar
                cerrarconexion()

                conexionMysql.Open()
                xcantidad = 0

                'MsgBox("el producto es:" & matriz(x, 0))
                Dim Sql6 As String
                'consultamos cuantos registros se insertaros para posteriormente actualizarlos en su registro original
                Sql6 = "select cmdisponibles,idproductovinil from vinilproducto where idproductovinil='" & matriz(x, 0) & "';"
                Dim cmd6 As New MySqlCommand(Sql6, conexionMysql)
                reader = cmd6.ExecuteReader()

                reader.Read()
                'guardamos los valores en una matriz
                xcantidad = reader.GetString(0).ToString()
                matriz(x, 1) = xcantidad - matriz(x, 1)
                conexionMysql.Close()
            Next
            '---------------------------------------------------------------------------------------
            For n = 1 To totalactualizar
                '-----------------------ahora sacamos los valores de la matriz para poder actualizarlos
                '--------------------------------------------------------------------------------------------
                cerrarconexion()

                conexionMysql.Open()
                'actualizo el dato
                Dim Sql5 As String
                Sql5 = "UPDATE vinilproducto SET cmdisponibles=" & matriz(n, 1) & " WHERE idproductovinil='" & matriz(n, 0) & "';"
                Dim cmd5 As New MySqlCommand(Sql5, conexionMysql)
                cmd5.ExecuteNonQuery()
                conexionMysql.Close()
                ' MsgBox("registro actualizado")
                '-------------------------------------------------------------------------------------------------
            Next
            '-------------------------------------------------------------------------------------------
            '--------------------------------------- se manda a imprimir el reporte



            'If chcalcularcambio.Checked = True Then

            '    '-------------------NUEVO SISTEMA
            MsgBox("Venta realizada", MsgBoxStyle.Information, "CTRL+y")
            Dim formulario As New FRNOTASERVICIOVINIL

            formulario.ShowDialog()
            '    frcambio.txtpaga.Focus()


            'Else


            '---------------------------------------2020, va la impresion de la nota
            'FRNOTASERVICIO.ShowDialog()



            'End If


            'txtcliente.Text = "USUARIO"
            stxtlistaclientes.Visible = False
            'If chimpresionticket.Checked = True Then
            '    'impresionticket()

            'End If
            'If chimpresion.Checked = True Then
            '    '//////////////////////////////////////////////////////
            '    ' frx.Show()
            '    'cargamos el formulario 2, temporalmente para ver si funcionan los reportes.
            '    ''    Form2.TextBox1.Text = lbfolio.Text
            '    'Dim newformulario As New frnotaventa
            '    'aqui le cambien por el formulario de prueba, para coregir
            '    'el problema de los reportes.
            '    'newformulario.Show()
            '    'cagamos los datos a la nota de venta primeroa

            '    cargardatosnotaventa()
            '    imprimirnotaventa()

            'End If

            'una vez guardada la venta, se obtiene un nuevo folio para la proxima venta
            obtenerfolio()





            '------------------------------------------------------------------------
            'al finalizar se limpia la grilla y las cajas de texto
            'txttotalpagar.Text = ""
            'txtunidades.Text = ""
            grilla.Rows.Clear()
            'llamamos para obtener un nuevo folio


        End If

        '------------------ FIN insertar reginstro en tabla ventaIND ---------------------------------------
        'Catch ex As Exception
        comprobartipoingreso()
        '    MsgBox(ex.Message)
        ' End Try

    End Function

    Private Sub Button68_Click(sender As Object, e As EventArgs) Handles Button68.Click
        Dim formulario As New ADDclientes
        formulario.ShowDialog()
        stxtlistaclientes.Visible = False
    End Sub

    Private Sub Stxtlistaclientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles stxtlistaclientes.SelectedIndexChanged

    End Sub

    Private Sub stxtlistaclientes_DoubleClick(sender As Object, e As EventArgs) Handles stxtlistaclientes.DoubleClick
        stxtcliente.Text = stxtlistaclientes.Text
        stxtlistaclientes.Visible = False
        vtxtpiezas.Focus()
    End Sub

    Private Sub Stxtcliente_TextChanged(sender As Object, e As EventArgs) Handles stxtcliente.TextChanged
        stxtlistaclientes.Items.Clear()

        If stxtcliente.Text = "" Then
            stxtlistaclientes.Visible = False


        Else
            stxtlistaclientes.Visible = True

            'MsgBox("verdadero")

            Try

                'cerramos la conexion
                cerrarconexion()

                Dim cantidad, i As Integer
                cantidad = 0
                conexionMysql.Open()
                Dim Sql2 As String
                Sql2 = "select count(*) from cliente where concat(nombre, ' ',ap, ' ', am) like '%" & stxtcliente.Text & "%';"
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
                Sql = "select concat(nombre, ' ', ap, ' ', am) as nombre from cliente where concat(nombre, ' ',ap, ' ', am) like '%" & stxtcliente.Text & "%';"
                Dim cmd As New MySqlCommand(Sql, conexionMysql)
                reader = cmd.ExecuteReader
                For i = 1 To cantidad
                    reader.Read()

                    stxtlistaclientes.Items.Add(reader.GetString(0).ToString)
                Next


                conexionMysql.Close()

            Catch ex As Exception
                cerrarconexion()

            End Try
        End If


        'Catch ex As Exception

        'End Try


    End Sub

    Private Sub stxtlistaclientes_KeyDown(sender As Object, e As KeyEventArgs) Handles stxtlistaclientes.KeyDown

        If (e.KeyCode = Keys.Enter) Then
            stxtcliente.Text = stxtlistaclientes.Text
            stxtlistaclientes.Visible = False
            vtxtpiezas.Focus()

        End If


    End Sub

    Private Sub stxtcliente_KeyDown(sender As Object, e As KeyEventArgs) Handles stxtcliente.KeyDown
        If e.KeyCode = Keys.Down Then
            stxtlistaclientes.Focus()


        End If

    End Sub

    Private Sub Stxtanticipo_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub grilla_DoubleClick(sender As Object, e As EventArgs) Handles grilla.DoubleClick
        Try

            'eliminar datos al dar doble clic.
            'grilla.CurrentRow.Index
            grilla.Rows.RemoveAt(grilla.CurrentRow.Index)
            'eliminado el registro, sumamos el total de valores. 
            sumatorio()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub stxtanticipo_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            buscarfolioservicio()
            grilla2.Visible = True
            grilla.Visible = False
        End If
    End Sub
    Function rebuscarfolioservicio()
        Dim tipoventa, idventaservicioextra As Integer
        'Try
        cerrarconexion()
        conexionMysql.Open()
        Dim Sql2 As String
        Sql2 = "select * from venta where idventa=" & idvinil & ";"
        Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
        reader = cmd2.ExecuteReader()
        reader.Read()
        idventaservicioextra = reader.GetString(0).ToString()
        tipoventa = reader.GetString(10).ToString()
        conexionMysql.Close()

        If tipoventa = 1 Or tipoventa = 2 Then
            MsgBox("El folio corresponde a una venta de productos no de servicios", MsgBoxStyle.Exclamation, "CTRL+y")
            'lbmensaje.Visible = True
            'borrartodo()
            borrar()

            grilla2.Visible = False

        ElseIf tipoventa = 3 Then
            'en caso de que el tipo de venta sea de 2 entonces significa que si es un servicio y lo buscamos y cargamos
            '----cargamos el folio a la ventana de servicios de la ventana de servicios
            'lbmensaje.Visible = False
            recargarfolioventa()
            'agregargrillaventa()
            MsgBox("recargando folio")
            grilla2.Visible = True
            vtxtclaveproducto.Text = ""
            'ASIGNO EL FOLIO A SLBFOLIO PARA QUE LE INDIQUEMOS QUE ESTAMOS TRABAJANDO CON LA BUSQUEDA DE UN FOLIO



            llenadogrillaventafolio()


            'bloqueamos la caja de txtanticipo
            'stxtanticipo.Enabled = False



        End If


        ' Catch ex As Exception
        MsgBox("Folio de venta no encontrado", MsgBoxStyle.Information, "CTRL+y")
        '    borrar()
        grilla2.DataSource = ""
        cerrarconexion()
        'End Try

    End Function
    Function buscarfolioservicio()
        Dim tipoventa, idventaservicioextra As Integer
        Try
            cerrarconexion()
            conexionMysql.Open()
            Dim Sql2 As String
            Sql2 = "select * from venta where idventa=" & stxtfoliobusquedaventa.Text & ";"
            Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            reader = cmd2.ExecuteReader()
            reader.Read()
            idventaservicioextra = reader.GetString(0).ToString()
            tipoventa = reader.GetString(10).ToString()
            conexionMysql.Close()

            If tipoventa = 1 Or tipoventa = 2 Then
                MsgBox("El folio corresponde a una venta de productos no de servicios", MsgBoxStyle.Exclamation, "CTRL+y")
                'lbmensaje.Visible = True
                'borrartodo()
                borrar()
                grilla2.Rows.Clear()

                grilla2.Visible = False
                grilla.Visible = True

            ElseIf tipoventa = 3 Then
                'en caso de que el tipo de venta sea de 2 entonces significa que si es un servicio y lo buscamos y cargamos
                '----cargamos el folio a la ventana de servicios de la ventana de servicios
                'lbmensaje.Visible = False
                cargarfolioventa()
                'agregargrillaventa()
                grilla2.Visible = True
                vtxtclaveproducto.Text = ""
                'ASIGNO EL FOLIO A SLBFOLIO PARA QUE LE INDIQUEMOS QUE ESTAMOS TRABAJANDO CON LA BUSQUEDA DE UN FOLIO



                llenadogrillaventafolio()
                'en caso deque si encuentre el folio, deshabilito la caja para que no pueda alterar el valor
                stxtanticipo1.Enabled = False
                'bloqueamos la caja de txtanticipo
                'stxtanticipo.Enabled = False



            End If


        Catch ex As Exception
            MsgBox("Folio de venta no encontrado", MsgBoxStyle.Information, "CTRL+y")
            borrar()
            grilla2.DataSource = ""
            cerrarconexion()
        End Try

    End Function
    Function recargarfolioventa()
        '----------function para cargar el folio de la venta del servicio que se hizo, permitiendo modificar valores como de anexar servicios o productos
        '------------ esto traera la modificacion de las tablas y se tendra que actualizar la venta.
        Dim idcliente As Integer
        'Try
        'MsgBox("recargando folio")
        'MsgBox("clave es:" + idvinil)
        cerrarconexion()
        conexionMysql.Open()
        Dim Sql2 As String
        Sql2 = "select * from venta where idventa=" & idvinil & ";"
        Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
        reader = cmd2.ExecuteReader()
        reader.Read()
        vtxtpiezastotales.Text = reader.GetString(1).ToString()
        stxttotal1.Text = reader.GetString(2).ToString()
        DateTimePicker2.Text = reader.GetString(3).ToString()
        'stxthoraregistroventa.Text = reader.GetString(4).ToString()
        idcliente = reader.GetString(5).ToString()
        DateTimePicker1.Text = reader.GetString(7).ToString()
        stxtanticipo1.Enabled = True
        stxtresto1.Enabled = True

        stxtanticipo1.Text = reader.GetString(8).ToString()
        'MsgBox(reader.GetString(8).ToString())
        'MsgBox(reader.GetString(9).ToString())
        stxtresto1.Text = reader.GetString(9).ToString()

        'idcliente = reader.GetString(5).ToString() 'cliente

        'setxtfoliocotizador.Text = reader.GetString(13).ToString()

        If CInt(stxtresto1.Text) = 0 Then

            picturepagado.Visible = True
        Else
            picturepagado.Visible = False
        End If
        conexionMysql.Close()

        'cargamos el cliente, sus datos

        Try
            cerrarconexion()
            conexionMysql.Open()
            Dim Sql31 As String
            'consultamos el id del cliente para obtener un registro de quien es al que se le    1esta vendiendo
            Sql31 = "select concat(nombre, ' ',ap, ' ', am)as nombre from cliente where  idcliente=" & idcliente & ";"
            Dim cmd31 As New MySqlCommand(Sql31, conexionMysql)
            reader = cmd31.ExecuteReader()
            reader.Read()
            stxtcliente.Text = reader.GetString(0).ToString()
            'indexidusuario = idcliente
            conexionMysql.Close()
            stxtlistaclientes.Visible = False

            'MsgBox(idcliente)
        Catch ex As Exception
            'idcliente = 1
            '-MsgBox(idcliente)
        End Try

        '----cargamos el folio a la ventana de servicios de la ventana de servicios

        'Catch ex As Exception
        'MsgBox("Folio de venta no encontrado", MsgBoxStyle.Information, "CTRL+y")
        cerrarconexion()
        'End Try
    End Function
    Function cargarfolioventa()
        '----------function para cargar el folio de la venta del servicio que se hizo, permitiendo modificar valores como de anexar servicios o productos
        '------------ esto traera la modificacion de las tablas y se tendra que actualizar la venta.
        Dim idcliente, idtipo_pago As Integer
        'Try

        cerrarconexion()
        conexionMysql.Open()
        Dim Sql2 As String
        Sql2 = "select * from venta where idventa=" & stxtfoliobusquedaventa.Text & ";"
        Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
        reader = cmd2.ExecuteReader()
        reader.Read()
        vtxtpiezastotales.Text = reader.GetString(1).ToString()
        stxttotal1.Text = reader.GetString(2).ToString()
        DateTimePicker2.Text = reader.GetString(3).ToString()
        'stxthoraregistroventa.Text = reader.GetString(4).ToString()
        idcliente = reader.GetString(5).ToString()
        DateTimePicker1.Text = reader.GetString(7).ToString()
        stxtanticipo1.Text = reader.GetString(8).ToString()
        stxtresto1.Text = reader.GetString(9).ToString()

        idtipo_pago = reader.GetString(14).ToString()

        'idcliente = reader.GetString(5).ToString() 'cliente

        'setxtfoliocotizador.Text = reader.GetString(13).ToString()






        If CInt(stxtresto1.Text) = 0 Then

            picturepagado.Visible = True
        Else
            picturepagado.Visible = False
        End If
        conexionMysql.Close()

        '----------------------------
        cerrarconexion()
        conexionMysql.Open()
        Dim Sql23 As String
        Sql23 = "select tipo from tipo_pago where idtipo_pago=" & idtipo_pago & ";"
        Dim cmd23 As New MySqlCommand(Sql23, conexionMysql)
        reader = cmd23.ExecuteReader()
        reader.Read()


        cbformadepagoservicios.Text = reader.GetString(0).ToString()


        conexionMysql.Close()

        '----------------------------




        'cargamos el cliente, sus datos

        Try
            cerrarconexion()
            conexionMysql.Open()
            Dim Sql31 As String
            'consultamos el id del cliente para obtener un registro de quien es al que se le    1esta vendiendo
            Sql31 = "select concat(nombre, ' ',ap, ' ', am)as nombre from cliente where  idcliente=" & idcliente & ";"
            Dim cmd31 As New MySqlCommand(Sql31, conexionMysql)
            reader = cmd31.ExecuteReader()
            reader.Read()
            stxtcliente.Text = reader.GetString(0).ToString()
            'indexidusuario = idcliente
            conexionMysql.Close()
            stxtlistaclientes.Visible = False

            'MsgBox(idcliente)
        Catch ex As Exception
            'idcliente = 1
            '-MsgBox(idcliente)
        End Try

        '----cargamos el folio a la ventana de servicios de la ventana de servicios

        'Catch ex As Exception
        'MsgBox("Folio de venta no encontrado", MsgBoxStyle.Information, "CTRL+y")
        cerrarconexion()
        'End Try
    End Function
    Function llenadogrillaventafolio()


        grilla2.DefaultCellStyle.Font = New Font("Arial", 12)
        grilla2.RowHeadersVisible = False




        'grilla.Columns(0).Width = 0
        grilla2.AlternatingRowsDefaultCellStyle.BackColor = Color.SkyBlue

        conexionMysql.Open()
        Dim actividad, descripcion As String
        Dim idproducto As Integer
        Dim Sql7 As String
        'consultamos cuantos registros se insertaros para posteriormente actualizarlos en su registro original
        Sql7 = "select * from ventaind where idventa=" & stxtfoliobusquedaventa.Text & ";"
        Dim cmd7 As New MySqlCommand(Sql7, conexionMysql)
        Dim dt As New DataTable
        Dim da As New MySqlDataAdapter(cmd7)
        'cargamos el formulario  resumen
        da.Fill(dt)
        grilla2.DataSource = dt

        '        cgrilla.Columns(6).Width = 100

        conexionMysql.Close()
        grilla2.Columns(1).Width = 350

    End Function

    Private Sub Stxtfoliobusquedaventa_TextChanged(sender As Object, e As EventArgs) Handles stxtfoliobusquedaventa.TextChanged
        Try

            If stxtfoliobusquedaventa.Text = "" Then
                reiniciar()
                stxtfoliobusquedaventa.Focus()

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub stxtfoliobusquedaventa_KeyDown(sender As Object, e As KeyEventArgs) Handles stxtfoliobusquedaventa.KeyDown

        If e.KeyCode = Keys.Enter Then

            buscarfolioservicio()
            grilla2.Visible = True
            grilla.Visible = False
            'txtfoliobusqueda.Text = stxtfoliobusquedaventa.Text

        End If
    End Sub


    Function reiniciar()

        borrar()
        grilla2.Visible = False
        grilla.Rows.Clear()
        vtxtprecioindividual.Text = ""
        vtxtpreciototal.Text = ""



        grilla.Visible = True
        stxtfoliobusquedaventa.Text = ""
        picturepagado.Visible = False
        vtxtpiezastotales.Text = ""
        DateTimePicker1.Text = Date.Now
        DateTimePicker2.Text = Date.Now
        obtenerfolio()

        stxttotal1.Text = ""
        stxtresto1.Text = ""
        stxtanticipo1.Text = ""
        vtxtclaveproducto.Focus()



    End Function
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        reiniciar()

    End Sub

    Private Sub cbdificultad_Click(sender As Object, e As EventArgs) Handles cbdificultad.Click
        'cargardificultad()

    End Sub

    Private Sub cbdificultad_GotFocus(sender As Object, e As EventArgs) Handles cbdificultad.GotFocus

        ' cargardificultad()

    End Sub

    Private Sub cbdificultad_MouseHover(sender As Object, e As EventArgs) Handles cbdificultad.MouseHover

        'cargardificultad()

    End Sub


    Private Sub cbdificultad_MouseClick(sender As Object, e As MouseEventArgs) Handles cbdificultad.MouseClick
        cargardificultad()

    End Sub
    Function asignarusuario()
        Try
            cerrarconexion()
            conexionMysql.Open()
            Dim Sql31 As String
            'consultamos el id del cliente para obtener un registro de quien es al que se le esta vendiendo
            Sql31 = "select idcliente from cliente where concat(nombre, ' ',ap, ' ', am) like '%" & stxtcliente.Text & "%';"
            Dim cmd31 As New MySqlCommand(Sql31, conexionMysql)
            reader = cmd31.ExecuteReader()
            reader.Read()
            idvinilusuario = reader.GetString(0).ToString()
            conexionMysql.Close()
            'MsgBox(idvinilusuario)
        Catch ex As Exception
            'idcliente = 1
            '-MsgBox(idcliente)
        End Try

    End Function
    Private Sub Button70_Click(sender As Object, e As EventArgs) Handles Button70.Click

        idtimer = 0

        TextBox1.Text = idtimer

        Timer1.Enabled = True
        'MsgBox("idtimer" & idtimer)

        If stxtfoliobusquedaventa.Text = "" Then

            MsgBox("Accion no valida, no hay una busqueda en ejecución", MsgBoxStyle.Information, "Ctrl+y")

            'stxttotal.Text = ""
            'stxtanticipo.Text = ""
            'stxtresto.Text = ""


        Else




            'txtfoliobusqueda.Text = stxtfoliobusquedaventa.Text
            asignarusuario()
            idvinil = stxtfoliobusquedaventa.Text
            '  MsgBox(idvinil)
            '    MsgBox(idvinil)
            Dim formulario As New FRagregaranticipovinil
            'FRagregaranticipo.ShowDialog()

            formulario.ShowDialog()




        End If
    End Sub

    Private Sub Txtfoliobusqueda_TextChanged(sender As Object, e As EventArgs)
        'If e.KeyCode = Keys.Enter Then
        ' stxtfoliobusquedaventa.Text = txtfoliobusqueda.Text

        buscarfolioservicio()

        'End If
    End Sub

    Private Sub Vtxtprecioindividual_TextChanged(sender As Object, e As EventArgs) Handles vtxtprecioindividual.TextChanged

    End Sub

    Private Sub Picturepagado_Click(sender As Object, e As EventArgs) Handles picturepagado.Click
        picturepagado.Visible = False

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ' MsgBox("idtimer" & idtimer)
        TextBox1.Text = idtimer

        If idtimer = 1 Then
            borrar()
            limpiarcajas()

            Timer1.Enabled = False

            ' MsgBox("idtimer" & idtimer)

        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try

            If TextBox1.Text = 1 Then
                borrar()
                limpiarcajas()
                '        MsgBox("vamos a borrar todo a la chingada ya")
                Timer1.Enabled = False
                ' TextBox1.Text = 11
                'stxttotal1.Text = 12123

                stxttotal1.Text = ""
                stxtanticipo1.Text = ""
                stxtresto1.Text = ""
                'stxtfoliobusquedaventa.Text = ""

                recargarfolioventa()







            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Stxttotal_TextChanged(sender As Object, e As EventArgs) Handles stxttotal1.TextChanged

    End Sub

    Private Sub frmcotizadorvinil_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        'If TextBox1.Text = 1 Then
        '    MsgBox("borrando")
        '    borrar()
        '    limpiarcajas()
        'End If

    End Sub

    Private Sub Stxtanticipo1_TextChanged(sender As Object, e As EventArgs) Handles stxtanticipo1.TextChanged

        stxtanticipo1.BackColor = Color.White


        Try


            If CDbl(stxtanticipo1.Text) > CDbl(stxttotal1.Text) Then
                MsgBox("Valor fuera del total", MsgBoxStyle.Information, "CTRL+y")
                stxtanticipo1.Text = ""
                stxtresto1.Text = ""
            Else

                Dim re As Double


                re = CDbl(stxttotal1.Text) - CDbl(stxtanticipo1.Text)
                stxtresto1.Text = Math.Round(re, 2)
            End If
        Catch ex As Exception

            stxtresto1.Text = 0

        End Try
    End Sub

    Private Sub Button71_Click(sender As Object, e As EventArgs) Handles Button71.Click

        buscarfolioservicio()
        grilla2.Visible = True
        grilla.Visible = False
        'txtfoliobusqueda.Text = stxtfoliobusquedaventa.Text

    End Sub

    Private Sub Button44_Click(sender As Object, e As EventArgs) Handles Button44.Click
        Dim formulario As New FRventaporclientevinil
        'FRagregaranticipo.ShowDialog()
        formulario.ShowDialog()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        stxtfoliobusquedaventa.Text = foliobusqueda
        TextBox1.Text = foliobusqueda
        MsgBox(foliobusqueda)
        Timer2.Enabled = False


    End Sub
End Class