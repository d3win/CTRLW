Imports MySql.Data.MySqlClient


Public Class servicios

    Dim hora2, hora, minuto, segundo As String
    Dim txtpagar As Double
    Public folioventabusqueda As String
    Public folioventa As String



    Private Sub txtclave_TextChanged(sender As Object, e As EventArgs) Handles txtnombre.TextChanged
        listaservicios.Visible = True
        listaservicios.Items.Clear()

        If txtnombre.Text = "" Then
            listaservicios.Visible = False
            borrar()
            txtclave.Text = ""


        Else

            Try

                'cerramos la conexion
                cerrarconexion()

                Dim cantidad, i As Integer
                cantidad = 0
                conexionMysql.Open()
                Dim Sql2 As String
                Sql2 = "select count(*) from producto where descripcion like '%" & txtnombre.Text & "%';"
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
                Sql = "select descripcion from producto where descripcion like '%" & txtnombre.Text & "%';"
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
    'Function buscarproducto()
    '    If ctxtid.Text = "" Or txtnombre.Text = "0" Then
    '    Else

    '        Try
    '            Dim cantidad As Integer

    '            respuesta = vbYes


    '            cerrarconexion()


    '            conexionMysql.Open()
    '            Dim Sql As String
    '            Sql = "select * from producto where idproducto='" & txtnombre.Text & "';"
    '            Dim cmd As New MySqlCommand(Sql, conexionMysql)
    '            reader = cmd.ExecuteReader()
    '            reader.Read()
    '            txtactividad.Text = reader.GetString(1).ToString()
    '            cantidad = reader.GetString(2).ToString()
    '            txtcosto.Text = reader.GetString(4).ToString()
    '            txtstock.Text = reader.GetString(2).ToString
    '            ''si encuentra el valor, llamamos al focus del boton.
    '            'Button17.Focus()

    '            reader.Close()

    '            conexionMysql.Close()



    '            If cantidad = 1 Then
    '                MsgBox("Este es el ultimo producto existente, recuerda adquirir más", MsgBoxStyle.Information, "Sistema")
    '            ElseIf cantidad = 0 Then
    '                respuesta = MsgBox("Ya no hay productos por vender." & vbCrLf & "Para mantener la integridad de la información, primero agrega mas productos", MsgBoxStyle.Exclamation, "Sistema")
    '                borrar()

    '            End If

    '            'en caso de que quede 1, si se vende, pero si queda 0, depende de la respuesta.

    '            If respuesta = vbYes Then
    '                txtcantidad.Text = 1

    '            Else
    '                txtactividad.Text = ""
    '                txtcosto.Text = ""
    '                txtcantidad.Text = ""


    '            End If








    '            'realizar operacion para obtener el total 

    '            txttotal.Text = CDbl(txtcantidad.Text) * CDbl(txtcosto.Text)

    '            MsgBox("verificamo que esten activas las casillas")
    '            '--------------------IMPORTANTE------------------------------
    '            'verificamos si la casilla de anexar directo esta activada, entonces, automaticamente llammos a la funcion
    '            'de agregar a la grilla.

    '            If chanexar.Checked = True And chpermitircantidad.Checked = False Then
    '                MsgBox("solo esta activa la de anexar directo")
    '                Dim cantidad_total, cantidadbd As Integer

    '                'cantidad total es la cantidad que se va a vender
    '                'se le suma 1, porque es el producto que apenas se va anexar a la lista de venta
    '                cantidad_total = comprobacion() + txtcantidad.Text


    '                'cantidadbd, es la cantidad que existe en la BD del producto

    '                cantidadbd = conteoclave()


    '                If cantidad_total > cantidadbd Then
    '                    MsgBox("No hay productos suficientes, no se agregara este producto", MsgBoxStyle.Exclamation, "Sistema")
    '                    borrar()
    '                Else
    '                    agregargrilla()

    '                End If
    '                'en caso de que esten activadas las dos, de permitir cantidad y anexar director entonces, que no haga nada, hasta que se cierre 
    '                'la ventana de permitircantidad.
    '            ElseIf chanexar.Checked = True And chpermitircantidad.Checked = True Then
    '                MsgBox("estan activadas las dos casillas.")
    '                'no hace nada.
    '                'solo mandamos a llamar a la ventana de cantidad.
    '                '-----------------------NUEVO SISTEMA
    '                frcantidad.Show()

    '                MsgBox("anexando")


    '            End If



    '        Catch ex As Exception
    '            'MsgBox("El producto no existe o no se a podido procesar", MsgBoxStyle.Exclamation, "Sistema")

    '            ''If conexionMysql.State = ConnectionState.Open Then
    '            ''conexionMysql.Close()

    '            'End If

    '            Call limpiar()

    '        End Try
    '    End If

    'End Function
    'Public Sub borrar()
    '    txtactividad.Text = ""
    '    txtcantidad.Text = ""
    '    txtcosto.Text = ""
    '    txttotal.Text = ""
    '    txtnombre.Text = ""
    '    txtstock.Text = ""




    'End Sub

    'Function buscarid()
    '    If txtnombre.Text = "" Or txtnombre.Text = "0" Then
    '    Else

    '        Try
    '            Dim cantidad As Integer

    '            respuesta = vbYes


    '            cerrarconexion()


    '            conexionMysql.Open()
    '            Dim Sql As String
    '            Sql = "select * from producto where idproducto='" & txtnombre.Text & "';"
    '            Dim cmd As New MySqlCommand(Sql, conexionMysql)
    '            reader = cmd.ExecuteReader()
    '            reader.Read()
    '            txtnombre.Text = reader.GetString(1).ToString()
    '            txtprecio.Text = reader.GetString(4).ToString()
    '            ''si encuentra el valor, llamamos al focus del boton.
    '            'Button17.Focus()

    '            reader.Close()

    '            conexionMysql.Close()



    '            If cantidad = 1 Then
    '                MsgBox("Este es el ultimo producto existente, recuerda adquirir más", MsgBoxStyle.Information, "Sistema")
    '            ElseIf cantidad = 0 Then
    '                respuesta = MsgBox("Ya no hay productos por vender." & vbCrLf & "Para mantener la integridad de la información, primero agrega mas productos", MsgBoxStyle.Exclamation, "Sistema")
    '                borrar()

    '            End If

    '            'en caso de que quede 1, si se vende, pero si queda 0, depende de la respuesta.

    '            If respuesta = vbYes Then
    '                txtcantidad.Text = 1

    '            Else
    '                txtactividad.Text = ""
    '                txtcosto.Text = ""
    '                txtcantidad.Text = ""


    '            End If








    '            'realizar operacion para obtener el total 

    '            txttotal.Text = CDbl(txtcantidad.Text) * CDbl(txtcosto.Text)


    '            '--------------------IMPORTANTE------------------------------
    '            'verificamos si la casilla de anexar directo esta activada, entonces, automaticamente llammos a la funcion
    '            'de agregar a la grilla.

    '            If chanexar.Checked = True And chpermitircantidad.Checked = False Then

    '                Dim cantidad_total, cantidadbd As Integer

    '                'cantidad total es la cantidad que se va a vender
    '                'se le suma 1, porque es el producto que apenas se va anexar a la lista de venta
    '                cantidad_total = comprobacion() + txtcantidad.Text


    '                'cantidadbd, es la cantidad que existe en la BD del producto

    '                cantidadbd = conteoclave()


    '                If cantidad_total > cantidadbd Then
    '                    MsgBox("No hay productos suficientes, no se agregara este producto", MsgBoxStyle.Exclamation, "Sistema")
    '                    borrar()
    '                Else
    '                    agregargrilla()

    '                End If
    '                'en caso de que esten activadas las dos, de permitir cantidad y anexar director entonces, que no haga nada, hasta que se cierre 
    '                'la ventana de permitircantidad.
    '            ElseIf chanexar.Checked = True And chpermitircantidad.Checked = True Then

    '                'no hace nada.
    '                'solo mandamos a llamar a la ventana de cantidad.
    '                '-------------------NUEVO SISTEMA
    '                '-------------------------------------------- frcantidad.Show()



    '            End If



    '        Catch ex As Exception
    '            'MsgBox("El producto no existe o no se a podido procesar", MsgBoxStyle.Exclamation, "Sistema")

    '            ''If conexionMysql.State = ConnectionState.Open Then
    '            ''conexionMysql.Close()

    '            'End If

    '            Call limpiar()

    '        End Try
    '    End If

    'End Function

    Private Sub servicios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listaservicios.Visible = False
        listaclientes.Visible = False
        lbmensaje.Visible = False

        '------------------se obtiene el folio para la venta del servicio
        obtenerfolio()


    End Sub
    Function cargarfolioventa()
        '----------function para cargar el folio de la venta del servicio que se hizo, permitiendo modificar valores como de anexar servicios o productos
        '------------ esto traera la modificacion de las tablas y se tendra que actualizar la venta.
        Dim idcliente As Integer
        'Try

        cerrarconexion()
        conexionMysql.Open()
        Dim Sql2 As String
        Sql2 = "select * from venta where idventa=" & txtfoliobusquedaventa.Text & ";"
        Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
        reader = cmd2.ExecuteReader()
        reader.Read()
        txttotalproductos.Text = reader.GetString(1).ToString()
        txttotal.Text = reader.GetString(2).ToString()
        txtfecharegistroventa.Text = reader.GetString(3).ToString()
        txthoraregistroventa.Text = reader.GetString(4).ToString()
        idcliente = reader.GetString(5).ToString()
        txtfechaentregaventa.Text = reader.GetString(7).ToString()
        txtanticipo.Text = reader.GetString(8).ToString()
        txtresto.Text = reader.GetString(9).ToString()
        conexionMysql.Close()
        '----cargamos el folio a la ventana de servicios de la ventana de servicios

        'Catch ex As Exception
        'MsgBox("Folio de venta no encontrado", MsgBoxStyle.Information, "CTRL+y")
        cerrarconexion()
        'End Try
    End Function
    Function buscarfolioservicio()
        Dim tipoventa, idventaservicioextra As Integer
        Try
            cerrarconexion()
            conexionMysql.Open()
            Dim Sql2 As String
            Sql2 = "select * from venta where idventa=" & txtfoliobusquedaventa.Text & ";"
            Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            reader = cmd2.ExecuteReader()
            reader.Read()
            idventaservicioextra = reader.GetString(0).ToString()
            tipoventa = reader.GetString(10).ToString()
            conexionMysql.Close()

            If tipoventa = 1 Then
                MsgBox("El folio corresponde a una venta de productos no de servicios", MsgBoxStyle.Information, "CTRL+y")
                lbmensaje.Visible = True
                borrartodo()
                grilla2.Visible = False


            ElseIf tipoventa = 2 Then
                'en caso de que el tipo de venta sea de 2 entonces significa que si es un servicio y lo buscamos y cargamos
                '----cargamos el folio a la ventana de servicios de la ventana de servicios
                lbmensaje.Visible = False
                cargarfolioventa()
                'agregargrillaventa()
                grilla2.Visible = True

                llenadogrillaventafolio()

            End If


        Catch ex As Exception
            MsgBox("Folio de venta no encontrado", MsgBoxStyle.Information, "CTRL+y")
        borrartodo()
        cerrarconexion()
        End Try

    End Function
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
            Try

                'si es su primer venta, entonces vamos a agregar automaticamente a un usuario...
                cerrarconexion()
                conexionMysql.Open()
                Dim Sql2 As String
                Sql2 = "INSERT INTO `dwin`.`tipo_usuario` (`tipo_usuario`, `tipo`) VALUES (1, 'ADMINISTRADOR');"
                Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
                cmd2.ExecuteNonQuery()
                cerrarconexion()
                conexionMysql.Close()
                'llamar a la funcion limpiar, para limpiar las cajas cada vez que se agrege una nueva compra.
                MsgBox("Registro guardado correctamente", MsgBoxStyle.Information, "Sistema")
                conexionMysql.Close()
                cerrarconexion()

                cerrarconexion()
                conexionMysql.Open()
                Dim Sql3 As String
                Sql3 = "INSERT INTO `dwin`.`tipo_usuario` (`tipo_usuario`, `tipo`) VALUES (2, 'USUARIO');"
                Dim cmd3 As New MySqlCommand(Sql3, conexionMysql)
                cmd3.ExecuteNonQuery()




                'llamar a la funcion limpiar, para limpiar las cajas cada vez que se agrege una nueva compra.
                MsgBox("Registro guardado correctamente", MsgBoxStyle.Information, "Sistema")
                conexionMysql.Close()




            Catch ex3 As Exception

            End Try
            cerrarconexion()


            Dim claveroot As String
            conexionMysql.Open()
            Dim Sqlx As String
            Sqlx = "select usuario from usuario where usuario= 'root';"
            Dim cmdx As New MySqlCommand(Sqlx, conexionMysql)
            reader = cmdx.ExecuteReader()
            reader.Read()
            Try
                claveroot = reader.GetString(0).ToString
            Catch ex2 As Exception
                claveroot = ""
            End Try

            cerrarconexion()
            conexionMysql.Close()


            If claveroot = "" Then
                conexionMysql.Open()
                Dim Sql As String
                Sql = "INSERT INTO usuario (usuario, nombre, ap, am, telefono, correo, direccion, tipo_usuario) VALUES ('root', 'root', 'root', 'root', 'root', 'root', 'root', 1);"
                Dim cmd As New MySqlCommand(Sql, conexionMysql)
                cmd.ExecuteNonQuery()
                conexionMysql.Close()
                'llamar a la funcion limpiar, para limpiar las cajas cada vez que se agrege una nueva compra.
                MsgBox("Registro guardado correctamente", MsgBoxStyle.Information, "Sistema")
                conexionMysql.Close()


                cerrarconexion()
                conexionMysql.Open()
                Dim Sql4 As String
                Sql4 = "INSERT INTO `dwin`.`CLIENTE` (`idcliente`, `nombre`, `ap`, `am`, `edad`, `direccion`, `telefono`, `correo`) VALUES ('1', 'USUARIO', 'USUARIO', 'USUARIO', '000', '000', '000', '000');"
                Dim cmd4 As New MySqlCommand(Sql4, conexionMysql)
                cmd4.ExecuteNonQuery()
                conexionMysql.Close()
                MsgBox("Registro guardado correctamente", MsgBoxStyle.Information, "Sistema")

            End If


        End Try

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim formulario As New frbuscarservicios
        formulario.ShowDialog()

    End Sub
    Function borrar()
        txtnombre.Text = ""
        txtprecio.Text = ""
        txtcantidad.Text = ""
        txtdescripcion.Text = ""
        txttotalproducto.Text = ""

    End Function

    Private Sub txtclave_TextChanged_1(sender As Object, e As EventArgs) Handles txtclave.TextChanged


        Try

            listaservicios.Visible = False
            If txtclave.Text = "" Then

                borrar()



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
                Sql = "select * from producto where idproducto='" & txtclave.Text & "';"
                Dim cmd As New MySqlCommand(Sql, conexionMysql)
                reader = cmd.ExecuteReader()
                reader.Read()
                txtnombre.Text = reader.GetString(1).ToString()
                '            txtcantidad.Text = reader.GetString(4).ToString()


                'MsgBox("Se caego la clave")
                'Dim precio As String

                listaservicios.Visible = False



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
                Sql2 = "select * from producto where idproducto='" & txtclave.Text & "';"
                Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
                reader = cmd2.ExecuteReader()
                reader.Read()
                txtprecio.Text = reader.GetString(4).ToString()
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


                txtcantidad.Focus()

                'calculamos el precio de la cantidad que se va agregar





            End If

        Catch ex As Exception

        End Try

    End Sub
    Function cerrarconexion()
        If conexionMysql.State = ConnectionState.Open Then
            conexionMysql.Close()

        End If
    End Function

    Private Sub txtnombre_LostFocus(sender As Object, e As EventArgs) Handles txtnombre.LostFocus
        'listaservicios.Visible = False

    End Sub

    Private Sub listaservicios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listaservicios.SelectedIndexChanged

    End Sub

    Private Sub listaservicios_DoubleClick(sender As Object, e As EventArgs) Handles listaservicios.DoubleClick
        cargarservicio()
        listaservicios.Visible = False


    End Sub

    Private Sub txtnombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnombre.KeyPress
        If e.KeyChar = Chr(80) Then
            listaservicios.Focus()
            MsgBox("tecla presionada")
        End If

       

    End Sub

    Private Sub txtnombre_KeyDown(sender As Object, e As KeyEventArgs) Handles txtnombre.KeyDown
        If e.KeyCode = Keys.Down Then
            listaservicios.Focus()



        End If
    End Sub

    Private Sub listaservicios_KeyDown(sender As Object, e As KeyEventArgs) Handles listaservicios.KeyDown

        'al presionar enter, cargamos el nombre y el ide a las cajas de texto indicadas, para llamar al producto
        If e.KeyCode = Keys.Enter Then

            cargarservicio()
            listaservicios.Visible = False


        End If



    End Sub

    Function cargarservicio()
        'aqui lo que hacemos es cargar el servicio a la caja de texto de txtnombre y mandamos la clave al la caja de texto txtclave,
        Try

            conexionMysql.Open()
            Dim Sql As String
            Sql = "select * from producto where descripcion='" & listaservicios.Text & "';"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            reader = cmd.ExecuteReader()
            reader.Read()
            txtclave.Text = reader.GetString(0).ToString()

            'txtnombre.Text = reader.GetString(1).ToString()
            'txtprecio.Text = reader.GetString(4).ToString()
            ''si encuentra el valor, llamamos al focus del boton.
            reader.Close()
            conexionMysql.Close()
        Catch ex As Exception

        End Try


    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim formulario As New ADDclientes
        formulario.ShowDialog()
        listaclientes.Visible = False


    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtcliente.TextChanged
        listaclientes.Items.Clear()

        If txtnombre.Text = "" Then
            listaclientes.Visible = False


        Else
            listaclientes.Visible = True

            Try

                'cerramos la conexion
                cerrarconexion()

                Dim cantidad, i As Integer
                cantidad = 0
                conexionMysql.Open()
                Dim Sql2 As String
                Sql2 = "select count(*) from cliente where concat(nombre, ' ',ap, ' ', am) like '%" & txtcliente.Text & "%';"
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
                Sql = "select concat(nombre, ' ', ap, ' ', am) as nombre from cliente where concat(nombre, ' ',ap, ' ', am) like '%" & txtcliente.Text & "%';"
                Dim cmd As New MySqlCommand(Sql, conexionMysql)
                reader = cmd.ExecuteReader
                For i = 1 To cantidad
                    reader.Read()

                    listaclientes.Items.Add(reader.GetString(0).ToString)
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

    Private Sub listaclientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listaclientes.SelectedIndexChanged

    End Sub

    Private Sub txtcliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtcliente.KeyDown
        If e.KeyCode = Keys.Down Then
            listaclientes.Focus()


        End If
    End Sub

    Private Sub listaclientes_KeyDown(sender As Object, e As KeyEventArgs) Handles listaclientes.KeyDown
        If e.KeyCode = Keys.Enter Then

            'cargarservicio()

            txtcliente.Text = listaclientes.Text

            listaclientes.Visible = False

            txtdescripcion.Focus()



        End If

    End Sub
    Function cargarclientes()
        'aqui lo que hacemos es cargar el servicio a la caja de texto de txtnombre y mandamos la clave al la caja de texto txtclave,

        conexionMysql.Open()
        Dim Sql As String
        Sql = "select concat(nombre, ' ', ap, ' ', am) as nombre from cliente where concat(nombre, ' ',ap, ' ', am) like '%" & listaclientes.Text & "%';"
        Dim cmd As New MySqlCommand(Sql, conexionMysql)
        reader = cmd.ExecuteReader()
        reader.Read()
        txtcliente.Text = reader.GetString(0).ToString()

        'txtnombre.Text = reader.GetString(1).ToString()
        'txtprecio.Text = reader.GetString(4).ToString()
        ''si encuentra el valor, llamamos al focus del boton.
        reader.Close()
        conexionMysql.Close()


    End Function


    Public Sub agregargrilla()
        If txtcantidad.Text = "" Or txtprecio.Text = "" Or txtnombre.Text = "" Or txtclave.Text = "" Or txttotalproducto.Text = "" Then

            MsgBox("No hay servicios que agregar", MsgBoxStyle.Information, "Sistema")

        Else

            Dim i As Integer = grilla.RowCount

            grilla.Rows.Add(i, txtnombre.Text, txtcantidad.Text, txtprecio.Text, txttotalproducto.Text, txtclave.Text, txtdescripcion.Text)
            grilla.Columns(1).Width = 350


            'sumatorio()

            borrar()


            txtclave.Focus()
        End If

    End Sub
    Function agregarproductogrilla()
        grilla.DefaultCellStyle.Font = New Font("Arial", 20)
        grilla.RowHeadersVisible = False




        'grilla.Columns(0).Width = 0
        grilla.AlternatingRowsDefaultCellStyle.BackColor = Color.SkyBlue



        If txtclave.Text = "" Or txtnombre.Text = "" Or txtcantidad.Text = "" Or txtprecio.Text = "" Or txtcliente.Text = "" Then

            MsgBox("Falta información para agregar", MsgBoxStyle.Exclamation, "Sistema")

        Else




            Dim cantidad_total, cantidadbd As Integer

            'cantidad total es la cantidad que se va a vender
            'se le suma 1, porque es el producto que apenas se va anexar a la lista de venta
            Try
                cantidad_total = comprobacion() + txtcantidad.Text


                'cantidadbd, es la cantidad que existe en la BD del producto

                cantidadbd = conteoclave()


                If cantidad_total > cantidadbd Then
                    MsgBox("No hay productos suficientes, no se agregara este producto", MsgBoxStyle.Exclamation, "Sistema")
                    borrar()
                Else
                    agregargrilla()
                    sumatorio()

                End If

            Catch ex As Exception

                MsgBox("No podemos procesar esta solicitud, Verifica la información", MsgBoxStyle.Exclamation, "Sistema")
            End Try

        End If


        '------------------------------------------------------------------------------------------------------------------

        '------------------------------------------------------------------------------------------------------------------


    End Function
    Function conteoclave() As Integer
        If conexionMysql.State = ConnectionState.Open Then
            conexionMysql.Close()

        End If
        Dim cantidad As Integer

        cerrarconexion()
        If txtclave.Text <> "0" Then

            cerrarconexion()
            conexionMysql.Open()
            Dim Sql As String
            Sql = "select cantidad from producto where idproducto='" & txtclave.Text & "';"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            reader = cmd.ExecuteReader()
            reader.Read()
            cantidad = reader.GetString(0).ToString()

            conexionMysql.Close()
            Return cantidad
        Else
            Return 100000000
        End If

    End Function

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        agregarproductogrilla()


    End Sub
    Function comprobacion() As Integer
        'comprobar si hay la cantidad solicitada
        Dim j, suma, cantidad As Integer
        suma = 0
        cantidad = 0
        Dim i As Integer = grilla.RowCount
        Dim claveproducto As String



        For j = 0 To i - 2
            'MsgBox("valosr de j:" & j)
            'a = venta.grillaventa.Item(j, 3).Value.ToString()
            '    actividad = grilla.Rows(j).Cells(1).Value 'descripcion
            cantidad = grilla.Rows(j).Cells(2).Value 'cantidad
            claveproducto = grilla.Rows(j).Cells(5).Value 'clave


            ' MsgBox(claveproducto)



            If claveproducto = txtclave.Text Then
                suma = suma + cantidad
                'MsgBox("hay del producto:" & claveproducto & ":" & suma)
            End If


        Next
        Return suma
    End Function

    Private Sub txtcantidad_TextChanged(sender As Object, e As EventArgs) Handles txtcantidad.TextChanged
        Try

            txttotalproducto.Text = CDbl(txtcantidad.Text) * CDbl(txtprecio.Text)
        Catch ex As Exception

            txttotalproducto.Text = ""


        End Try

    End Sub

    Private Sub Button17_KeyDown(sender As Object, e As KeyEventArgs) Handles Button17.KeyDown
        If e.KeyCode = Keys.F2 Then

            'cargarservicio()
            agregarproductogrilla()


        End If
    End Sub

    Private Sub txtclave_KeyDown(sender As Object, e As KeyEventArgs) Handles txtclave.KeyDown
        If e.KeyCode = Keys.F2 Then

            'cargarservicio()
            agregarproductogrilla()


        End If
    End Sub

    Private Sub txtdescripcion_TextChanged(sender As Object, e As EventArgs) Handles txtdescripcion.TextChanged

    End Sub

    Private Sub txtdescripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtdescripcion.KeyDown
        If e.KeyCode = Keys.F2 Then

            'cargarservicio()
            agregarproductogrilla()


        End If
    End Sub

    Private Sub listaclientes_DoubleClick(sender As Object, e As EventArgs) Handles listaclientes.DoubleClick
        txtcliente.Text = listaclientes.Text

        listaclientes.Visible = False

        txtdescripcion.Focus()

    End Sub
    Public Sub sumatorio()
        Dim i As Integer = grilla.RowCount

        Dim j As Integer
        Dim suma, cantidad_productos As Double
        Dim a, b As String
        'suma de valores
        For j = 0 To i - 2
            'MsgBox("valosr de j:" & j)
            'a = venta.grillaventa.Item(j, 3).Value.ToString()
            a = grilla.Rows(j).Cells(4).Value
            b = grilla.Rows(j).Cells(2).Value
            cantidad_productos = cantidad_productos + b
            suma = suma + a
            'MsgBox(a)
        Next
        txttotal.Text = suma
        txttotalproductos.Text = cantidad_productos
    End Sub

    Private Sub grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grilla.CellContentClick

    End Sub

    Private Sub grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grilla.CellDoubleClick
        Try

            'eliminar datos al dar doble clic.
            'grilla.CurrentRow.Index
            grilla.Rows.RemoveAt(grilla.CurrentRow.Index)
            'eliminado el registro, sumamos el total de valores. 
            sumatorio()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub servicios_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        frmindex.obtenerfolio()

    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        '------------ se llama a la funcion venta, que hace el registro a las tablas
        venta()

    End Sub

    Private Sub txttotal_TextChanged(sender As Object, e As EventArgs) Handles txttotal.TextChanged

    End Sub

    Function venta()
        Try

            If txttotal.Text = "0" Or txttotal.Text = "" Or txtanticipo.Text = "" Or txtresto.Text = "" Then
                MsgBox("No hay ventas que realizar, revisa tu información", MsgBoxStyle.Information, "Sistema")
                'txttotal.Text = ""
            Else
                'obtener fecha y hora
                Dim dia, mes, año, fecha As String
                hora2 = Now.Hour()
                minuto = Now.Minute()
                segundo = Now.Second()

                hora = hora2 & ":" & minuto & ":" & segundo

                dia = Date.Now.Day
                mes = Date.Now.Month
                año = Date.Now.Year
                fecha = año & "-" & mes & "-" & dia



                '------------------ insertar reginstro en tabla venta ---------------------------------------

                cerrarconexion()
                Dim idcliente As Integer

                idcliente = 1

                Try
                    cerrarconexion()
                    conexionMysql.Open()
                    Dim Sql31 As String
                    'consultamos el id del cliente para obtener un registro de quien es al que se le esta vendiendo
                    Sql31 = "select idcliente from cliente where concat(nombre, ' ',ap, ' ', am) like '%" & txtcliente.Text & "%';"
                    Dim cmd31 As New MySqlCommand(Sql31, conexionMysql)
                    reader = cmd31.ExecuteReader()
                    reader.Read()
                    idcliente = reader.GetString(0).ToString()
                    conexionMysql.Close()
                    'MsgBox(idcliente)
                Catch ex As Exception
                    idcliente = 1
                    '-MsgBox(idcliente)
                End Try



                '----------------consultamos al usuario que esta realizando la venta ------------------
                Dim idusuario As Integer

                cerrarconexion()

                conexionMysql.Open()
                Dim Sql32 As String
                'consultamos el id del usuario para obtener un registro de quien es al que se le esta vendiendo
                Sql32 = "select idusuario from usuario where usuario= '" & frmindex.usuarioactual & "';"
                Dim cmd32 As New MySqlCommand(Sql32, conexionMysql)
                reader = cmd32.ExecuteReader()
                reader.Read()
                idusuario = reader.GetString(0).ToString()
                conexionMysql.Close()
                '--------------------------------------------------------------------------
                cerrarconexion()


                Dim fechaentrega As String
                fechaentrega = DateTimePicker1.Value.ToString("yyyy/MM/dd")

                'MsgBox(fechaentrega)
                conexionMysql.Open()
                Dim Sql As String
                Sql = "INSERT INTO venta (idventa, cantidad, total, fecha, hora, idcliente, idusuario, fechaentrega, anticipo, resto, tipoventa) VALUES (" & lbfolio.Text & "," & txttotalproductos.Text & ", " & CDbl(txttotal.Text) & ", '" & fecha & "','" & hora & "', " & idcliente & ", " & idusuario & ",'" & fechaentrega & "'," & txtanticipo.Text & "," & txtresto.Text & ",'2');"
                Dim cmd As New MySqlCommand(Sql, conexionMysql)
                cmd.ExecuteNonQuery()
                conexionMysql.Close()
                txtnombre.Text = ""
                txtprecio.Text = ""
                txtpagar = CDbl(txttotal.Text)
                txttotal.Text = ""
                txtanticipo.Text = ""
                txtresto.Text = ""
                txttotalproductos.Text = ""

                conexionMysql.Close()


                '------------------ FIN insertar reginstro en tabla venta ---------------------------------------


                '------------------ insertar reginstro en tabla ventaIND ---------------------------------------
                Dim i As Integer = grilla.RowCount
                Dim j As Integer
                Dim actividad, descripcion As String
                Dim cantidad, costo, idventa As Double
                Dim idproducto As String

                conexionMysql.Open()

                'suma de valores
                For j = 0 To i - 2
                    'MsgBox("valosr de j:" & j)
                    'a = venta.grillaventa.Item(j, 3).Value.ToString()
                    actividad = grilla.Rows(j).Cells(1).Value 'descripcion
                    cantidad = grilla.Rows(j).Cells(2).Value 'cantidad
                    costo = grilla.Rows(j).Cells(3).Value 'costo
                    idproducto = grilla.Rows(j).Cells(5).Value
                    descripcion = grilla.Rows(j).Cells(6).Value
                    cerrarconexion()
                    conexionMysql.Open()

                    'MsgBox("el producto es:" & actividad)

                    Dim Sql2 As String
                    Sql2 = "INSERT INTO ventaind (actividad, cantidad, costo, idventa,idproducto,descripcion) VALUES ('" & actividad & "'," & cantidad & "," & costo & "," & lbfolio.Text & ",'" & idproducto & "','" & descripcion & "');"
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
                    Sql6 = "select cantidad,idproducto from producto where idproducto='" & matriz(x, 0) & "';"
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
                    Sql5 = "UPDATE producto SET cantidad=" & matriz(n, 1) & " WHERE idproducto='" & matriz(n, 0) & "';"
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

                '    frcambio.ShowDialog()
                '    frcambio.txtpaga.Focus()


                'Else

                MsgBox("Venta realizada", MsgBoxStyle.Information, "Sistema")




                'End If


                'txtcliente.Text = "USUARIO"
                listaclientes.Visible = False
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
        Catch ex As Exception
            comprobartipoingreso()
            MsgBox(ex.Message)
        End Try

    End Function
    Function comprobartipoingreso()
        Dim tipo As Integer
        tipo = tipoingreso()
        'MsgBox(tipo)
        If tipo = 2 Then
            MsgBox("Eres un Trabajador sin permisor para realizar esta accion", MsgBoxStyle.Exclamation, "Ctrly")
        Else
            'MsgBox("Existe un problema al eliminar el registro", MsgBoxStyle.Exclamation, "Sistema")
        End If

    End Function
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles txtanticipo.TextChanged
        Try


            If CDbl(txtanticipo.Text) > CDbl(txttotal.Text) Then
                MsgBox("Valor fuera del total", MsgBoxStyle.Information, "CTRL+y")
                txtanticipo.Text = ""
                txtresto.Text = ""
            Else
                txtresto.Text = CDbl(txttotal.Text) - CDbl(txtanticipo.Text)

            End If
        Catch ex As Exception

        End Try


    End Sub
    Function borrartodo()
        txtfoliobusquedaventa.Text = ""
        txtclave.Text = ""
        txtcantidad.Text = ""
        txtnombre.Text = ""
        txtcliente.Text = ""
        txttotal.Text = ""
        txttotalproducto.Text = ""
        txttotalproductos.Text = ""
        txtanticipo.Text = ""
        txtresto.Text = ""
        txtfechaentregaventa.Text = ""
        txtfecharegistroventa.Text = ""
        txthoraregistroventa.Text = ""
        txtdescripcion.Text = ""

    End Function
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        buscarfolioservicio()



        'Dim formulario As New busquedafolio
        'formulario.ShowDialog()

    End Sub

    Private Sub txtfoliobusquedaventa_TextChanged(sender As Object, e As EventArgs) Handles txtfoliobusquedaventa.TextChanged


        'If txtfoliobusquedaventa.Text = "" Then
        '    'Try


        '    grilla2.Rows.RemoveAt(1)
        '    'Catch ex As Exception

        '    'End Try
        '    grilla2.Visible = False
        'Else



        '    grilla2.Visible = True

        'End If

    End Sub

    Private Sub txtanticipo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtanticipo.KeyDown
        If e.KeyCode = Keys.F1 Then
            venta()

        End If
    End Sub

    Private Sub grilla_KeyDown(sender As Object, e As KeyEventArgs) Handles grilla.KeyDown
        If e.KeyCode = Keys.F1 Then
            venta()

        End If
    End Sub

    Private Sub servicios_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then
            venta()

        End If
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click

        folioventa = txtfoliobusquedaventa.Text

        MsgBox(folioventa)
        '        Dim formulario As New FRagregaranticipo
        FRagregaranticipo.ShowDialog()
        '       formulario.ShowDialog()

    End Sub

    Private Sub txtfoliobusquedaventa_KeyDown(sender As Object, e As KeyEventArgs) Handles txtfoliobusquedaventa.KeyDown
        If e.KeyCode = Keys.Enter Then
            buscarfolioservicio()

        End If
    End Sub
    Function llenadogrillaventafolio()
        conexionMysql.Open()
        Dim actividad, descripcion As String
        Dim idproducto As Integer
        Dim Sql7 As String
        'consultamos cuantos registros se insertaros para posteriormente actualizarlos en su registro original
        Sql7 = "select * from ventaind where idventa=" & txtfoliobusquedaventa.Text & ";"
        Dim cmd7 As New MySqlCommand(Sql7, conexionMysql)
        Dim dt As New DataTable
        Dim da As New MySqlDataAdapter(cmd7)
        'cargamos el formulario  resumen
        da.Fill(dt)
        grilla2.DataSource = dt

        '        cgrilla.Columns(6).Width = 100

        conexionMysql.Close()
    End Function
    Function agregargrillaventa()


        'PRIMERO contamos cuantos registros existen de la venta del ID busccado para saber cuantas vueltas vamos a dar
        Dim i, x As Integer
        Dim precio As Double
        Dim cantidad As Double
        Dim total As Double
        'For x = 1 To totalactualizar
        cerrarconexion()

        conexionMysql.Open()
        '    xcantidad = 0

        'MsgBox("el producto es:" & matriz(x, 0))
        Dim Sql6 As String
        'consultamos cuantos registros se insertaros para posteriormente actualizarlos en su registro original
        Sql6 = "select count(*) from ventaind where idventa=" & txtfoliobusquedaventa.Text & ";"
        Dim cmd6 As New MySqlCommand(Sql6, conexionMysql)
        reader = cmd6.ExecuteReader()

        reader.Read()
        'guardamos los valores en una matriz
        cantidad = reader.GetString(0).ToString()

        conexionMysql.Close()

        conexionMysql.Open()
        Dim actividad, descripcion As String
        Dim idproducto As Integer
        Dim Sql7 As String
        'consultamos cuantos registros se insertaros para posteriormente actualizarlos en su registro original
        Sql7 = "select * from ventaind where idventa=" & txtfoliobusquedaventa.Text & ";"
        Dim cmd7 As New MySqlCommand(Sql7, conexionMysql)
        reader = cmd7.ExecuteReader()
        reader.Read()

        For i = 1 To cantidad

            'guardamos los valores en una matriz

            actividad = reader.GetString(1).ToString()

            cantidad = reader.GetString(2).ToString()
            precio = reader.GetString(3).ToString()
            idproducto = reader.GetString(5).ToString()
            Try

                descripcion = reader.GetString(6).ToString()

            Catch ex As Exception

            End Try

            total = CDbl(cantidad) * CDbl(precio)
            conexionMysql.Close()


            'consultamos la información y la agregamos a la grilla


            'Dim i As Integer = grilla.RowCount

            grilla.Rows.Add(i, actividad, cantidad, precio, total, idproducto, descripcion)
            grilla.Columns(1).Width = 350


            'sumatorio()

            'borrar()


            'txtclave.Focus()
            'reader.Read()

        Next
        cerrarconexion()

    End Function
End Class