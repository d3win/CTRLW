Imports MySql.Data.MySqlClient

'librerias para poder importar y exportar una BD de Mysql
Imports System.IO.StreamWriter
Imports System.IO

Public Class frmindex
    Dim p1, p2, p3, p4, p5, p6, p7, p8 As Integer

    Public respaldar As New SaveFileDialog
    Public carpeta As New FolderBrowserDialog
    Public abrir As New OpenFileDialog
    Public hora, hora2, minuto, segundo, usuarioactual As String
    Public idproveedorfiltro As Integer
    Dim respuesta As String
    Dim idsumado As Integer
    Dim existe As Boolean
    Public txtpagar, ventamaxima As Double
    Public fpagacon, fcambio As String
    Public indexidusuario, indexidventa As String


    'datos para el reporte
    'Dim parametros As New ParameterFields
    'Dim parametro1 As New ParameterField
    'Dim myDiscretevalue As New ParameterDiscreteValue




    Private Sub frmindex_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        End

    End Sub
    Function llenadogrilla2()
        Try



            cerrarconexion()


            conexionMysql.Open()
            Dim Sql As String
            Sql = "select * from producto where descripcion like '%" & txtnombre.Text & "%';"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            Dim dt As New DataTable
            Dim da As New MySqlDataAdapter(cmd)
            'cargamos el formulario  resumen
            da.Fill(dt)
            grilla2.DataSource = dt
            grilla2.Columns(1).Width = 700
            grilla2.Columns(0).Width = 100
            grilla2.Columns(2).Width = 70
            grilla2.Columns(3).Width = 70
            grilla2.Columns(4).Width = 70
            grilla2.Columns(5).Width = 70
            grilla2.Columns(6).Width = 70
            grilla2.Columns(7).Width = 70

            conexionMysql.Close()
        Catch ex As Exception

        End Try






    End Function
    Function llenadogrilla2p()
        Try

            grilla2p.DefaultCellStyle.Font = New Font("Arial", 20)
            grilla2p.RowHeadersVisible = False

            'formato para grilla 2


            cerrarconexion()
            'grilla.Columns(0).Width = 0
            grilla2p.AlternatingRowsDefaultCellStyle.BackColor = Color.SkyBlue
            conexionMysql.Open()
            Dim Sql As String
            Sql = "select * from producto where descripcion like '%" & txtnombrep.Text & "%';"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            Dim dt As New DataTable
            Dim da As New MySqlDataAdapter(cmd)
            'cargamos el formulario  resumen
            da.Fill(dt)
            grilla2p.DataSource = dt
            conexionMysql.Close()
        Catch ex As Exception

        End Try






    End Function
    Private Sub frmindex_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        chagenda.CheckState = False
        agendagrilla.Visible = False
        agendacalendario.Visible = False


        listaclientes.Visible = False
        'inicio la variable en 0, COMPRAS mercancia
        idsumado = 0

        Button1.BackColor = Color.DimGray

        btninconsistencia.Visible = False


        ccgrilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        cgrilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        grillap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        grilla2p.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        grilla2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        ugrilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        grillacliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        cgrillacorte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        protxtgrilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill



        grilla2.AlternatingRowsDefaultCellStyle.BackColor = Color.SkyBlue


        Timer1.Enabled = True


        'ocultamos la grilla2, donde se realizan las busquedas de nombres
        grilla2.Visible = False


        rbclave.Checked = True


        txtnombre.Visible = False
        lbnombre.Visible = False
        'btnbuscarnombre.Visible = False


        'cargamos la estadistica cada vez que se carge el formulario o en su caso, se de clic al botón inicio.

        'estadistica()

        'SE CARGAN LOS DATOS INICIALES DEL SISTEMA

        inserciondedatosiniciales()

        'COMPROBAR SI HAY CAJAS ABIERTAS


        comprobarcajaabierta()


        cargarlogoticket()



    End Sub
    Function cargarlogoticket()



        Dim ruta As String
        Try
            'verificamos que exista al menos 1 registro, en caso de que exista 0, indicamos que el valor es 0;

            Dim lineas As New ArrayList()
            Dim carpeta As String
            Dim rutaImagen As String

            carpeta = Environment.GetFolderPath(Environment.SpecialFolder.Personal)

            Dim freader As New StreamReader(carpeta & "\rutaImagenNoBorrar.txt")

            ruta = freader.ReadLine() 'leo primera linea


            ' conexionMysql.Open()
            'Dim sql22 As String
            'sql22 = "select ruta_logo from datos_empresa;"
            'Dim cmd22 As New MySqlCommand(sql22, conexionMysql)
            'reader = cmd22.ExecuteReader
            'reader.Read()
            'ruta = reader.GetString(0).ToString()
            'conexionMysql.Close()
            'asignamos la ruta a la imagen
            pblogoticket.Image = Image.FromFile(ruta)
            btventas.Image = Image.FromFile(ruta)
            'btventas.BackgroundImageLayout = ImageLayout.Stretch
            btventas.SizeMode = PictureBoxSizeMode.Zoom
            pblogo.Image = Image.FromFile(ruta)
            'btventas.BackgroundImageLayout = ImageLayout.Stretch
            pblogo.SizeMode = PictureBoxSizeMode.Zoom
        Catch ex As Exception

        End Try



    End Function
    Function comprobarcajaabierta()
        'primero comprobamos si existe caja abierta.
        '------------------------------------------------
        Dim cantidad As Integer

        Try
            'verificamos que exista al menos 1 registro, en caso de que exista 0, indicamos que el valor es 0;
            conexionMysql.Open()
            Dim sql22 As String
            sql22 = "select count(idcaja) from caja;"
            Dim cmd22 As New MySqlCommand(sql22, conexionMysql)
            reader = cmd22.ExecuteReader
            reader.Read()
            cantidad = reader.GetString(0).ToString()
            conexionMysql.Close()
        Catch ex As Exception
            cantidad = 0
        End Try

        'si la cantidad es cero, entonces, significa que si puede abrir una caja, porque no hay nada aun.
        If cantidad = 0 Then


        Else


            Try

                conexionMysql.Open()
                Dim sql2 As String
                sql2 = "select count(idcaja) from caja where estado=0;"
                Dim cmd2 As New MySqlCommand(sql2, conexionMysql)
                reader = cmd2.ExecuteReader
                reader.Read()
                cantidad = reader.GetString(0).ToString()
                conexionMysql.Close()
            Catch ex As Exception
                cantidad = 1
            End Try
        End If


        If cantidad = 0 Then

            btnabrircajamenu.Visible = True
            btncerrarcajamenu.Visible = False
        Else
            btnabrircajamenu.Visible = False
            btncerrarcajamenu.Visible = True
        End If

        'Dim formulario As New FRabrircaja

        'formulario.ShowDialog()
        'Else
        'Dim respuesta As String
        'respuesta = MsgBox("Existen cajas abiertas sin cerrar, ¿deseas forzas cierre?, todo se pondrá en Ceros", MsgBoxStyle.YesNo, "CTRL+y")


        'If respuesta = vbYes Then

        '    cerrarconexion()

        '    conexionMysql.Open()
        '    'actualizo el dato
        '    Dim Sql5 As String
        '    Sql5 = "UPDATE `dwin`.`caja` SET `estado` = '1';"
        '    Dim cmd5 As New MySqlCommand(Sql5, conexionMysql)
        '    cmd5.ExecuteNonQuery()
        '    conexionMysql.Close()
        '    MsgBox("Cajas cerradas", MsgBoxStyle.Information, "CTR+y")
        '    Dim formulario As New FRabrircaja
        '    formulario.ShowDialog()
        '    '---------------------------------
        ' End If




        '  End If
    End Function
    'Function estadistica()
    '    Dim dia, d2, d3, d4, d5, mes, año, total As Integer
    '    Dim fecha, fechaatras As String
    '    dia = Date.Now.Day
    '    mes = Date.Now.Month
    '    año = Date.Now.Year
    '    fecha = año & "-" & mes & "-" & dia

    '    'aqui me quede, voy a tener que cargar la fecha con ceros para que pueda restarle 1 valor y hacer la estadistica
    '    'fecha2 = año & mes & dia

    '    Try

    '        cerrarconexion()


    '        conexionMysql.Open()
    '        Dim Sql As String
    '        Sql = "   select count(*) from venta where fecha='" & fecha & "';"
    '        Dim cmd As New MySqlCommand(Sql, conexionMysql)
    '        reader = cmd.ExecuteReader()
    '        reader.Read()
    '        lbventas.Text = reader.GetString(0).ToString() & " Ventas realizadas el día de hoy"

    '        conexionMysql.Close()

    '        'cerrarconexion()
    '        'conexionMysql.Open()
    '        'Dim Sql2 As String
    '        'Sql2 = "   select sum(cantidad) from venta where fecha='" & fecha & "';"
    '        'Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
    '        'reader = cmd2.ExecuteReader()
    '        'reader.Read()
    '        'lbventastotal.Text = reader.GetString(0).ToString() & " Produdctos vendidos"

    '        'conexionMysql.Close()

    '        Dim v1, diarestar As Integer

    '        'cargamos la estadistica en barras.
    '        'MsgBox(fecha)
    '        'conocemos el valor mas actual

    '        If (dia - 4) <= 1 Then
    '            diarestar = 1
    '        Else
    '            diarestar = dia - 4
    '        End If
    '        'MsgBox("el dia del rango es:" & diarestar)
    '        'MsgBox(fecha + "fecha original")
    '        fechaatras = año & "-" & mes & "-" & diarestar
    '        'MsgBox(fechaatras)
    '        'cargarbarras(fecha)




    '        Dim fechamaxima As String
    '        'dia 2.................................
    '        '------------------- obtengo el valor maximo para poder hacer los calculos dentro de la estadistica entre 2 fechas
    '        cerrarconexion()
    '        conexionMysql.Open()
    '        Dim Sql2 As String
    '        Sql2 = "select max(total),fecha from totalesventas where fecha between '" & fechaatras & "' and  '" & fecha & "';"
    '        Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
    '        reader = cmd2.ExecuteReader()
    '        reader.Read()
    '        ventamaxima = reader.GetString(0).ToString()
    '        fechamaxima = reader.GetString(1).ToString()
    '        conexionMysql.Close()


    '        'MsgBox("la venta maxima fue en la semana de :" & ventamaxima)

    '        ' barra1.Value = ventamaxima

    '        'barra1.Value = cargarbarras(ventamaxima)

    '        Dim i As Integer

    '        '--------------------- cuento cuantos valores hay entre las dos fechas
    '        cerrarconexion()
    '        conexionMysql.Open()
    '        Dim Sql3 As String
    '        Sql3 = "select * from totalesventas order by fecha desc;"
    '        Dim cmd3 As New MySqlCommand(Sql3, conexionMysql)
    '        reader = cmd3.ExecuteReader()

    '        'conexionMysql.Close()

    '        For i = 1 To 5


    '            reader.Read()
    '            If i = 1 Then
    '                Dim a As Integer
    '                a = reader.GetString(0).ToString()
    '                barra1.Value = cargarbarras(a)
    '                '       MsgBox("dia 1")
    '            ElseIf i = 2 Then
    '                Dim a As Integer
    '                a = reader.GetString(0).ToString()
    '                barra2.Value = cargarbarras(a)
    '                '      MsgBox("dia 1")
    '                'barra2.Value = cargarbarras(reader.GetString(0).ToString())
    '                'MsgBox("dia 2")
    '            ElseIf i = 3 Then
    '                Dim a As Integer
    '                a = reader.GetString(0).ToString()
    '                barra3.Value = cargarbarras(a)
    '                '     MsgBox("dia 1")
    '                'barra3.Value = cargarbarras(reader.GetString(0).ToString())
    '                'MsgBox("dia 3")
    '            ElseIf i = 4 Then
    '                Dim a As Integer
    '                a = reader.GetString(0).ToString()
    '                barra4.Value = cargarbarras(a)
    '                '    MsgBox("dia 1")
    '                'barra4.Value = cargarbarras(reader.GetString(0).ToString())
    '                'MsgBox("dia 4")
    '            ElseIf i = 5 Then
    '                Dim a As Integer
    '                a = reader.GetString(0).ToString()
    '                barra5.Value = cargarbarras(a)
    '                '   MsgBox("dia 1")
    '                'barra5.Value = cargarbarras(reader.GetString(0).ToString())
    '                'MsgBox("dia 5")
    '            End If

    '        Next

    '        conexionMysql.Close()


    '    Catch ex As Exception
    '        'MsgBox("upssss")


    '    End Try

    'End Function
    Function cargarbarras(valor As Integer)


        Dim a, b As Integer

        a = 100 / ventamaxima
        'b corresponde al valor de la barra de progreso y valor, es el valor de cada uno de los dias.
        b = a * valor
        Return b
        'a es el valor por el cual todos los valores serán multiplicados para obtener un porcentaje



    End Function
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        End

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lbcalendario.Text = Date.Now
        'Dim diax, mesx, añox, fechax As String
        'Dim horax As String
        ''MsgBox("holaaaaaaaaaaaaaaaaaaaa")


        'hora2 = Now.Hour()
        'minuto = Now.Minute()
        'segundo = Now.Second()

        'horax = hora2 & ":" & minuto & ":" & segundo

        ''MsgBox(horax)


        'If horax = "0:1:0" Then

        '    '            MsgBox("ya es hora")

        '    'si son las 12:00 de la madrugada, entonces hacemos corte de caja en automatico, del usuario actual y lo guardamos





        '    '-------------------------------------consultamos las ventas realizadas hasta el momento
        '    Dim dia, mes, año, fecha As String
        '    Dim hora As String
        '    'MsgBox("holaaaaaaaaaaaaaaaaaaaa")


        '    hora2 = Now.Hour()
        '    minuto = Now.Minute()
        '    segundo = Now.Second()

        '    hora = hora2 & ":" & minuto & ":" & segundo





        '    dia = Date.Now.Day
        '    mes = Date.Now.Month
        '    año = Date.Now.Year
        '    fecha = año & "-" & mes & "-" & dia


        '    'Try

        '    'primero selecciono la hora maxima de corte de caja del día de hoy. para que desde esa hora empiece a obtener valores

        '    Dim horafin1 As String

        '    cerrarconexion()

        '    conexionMysql.Open()
        '    Try
        '        Dim Sql111 As String
        '        Sql111 = "select max(hora_registro) from corte where fecha_registro='" & fecha & "';"
        '        Dim cmd111 As New MySqlCommand(Sql111, conexionMysql)
        '        reader = cmd111.ExecuteReader()
        '        reader.Read()

        '        horafin1 = reader.GetString(0).ToString
        '    Catch ex As Exception
        '        horafin1 = "00:00:00"
        '        tipoingreso()
        '    End Try

        '    conexionMysql.Close()
        '    '  MsgBox("la hora de registro de corte es:" & horafin)
        '    ' MsgBox("la hora DELSISTEMA ES:" & hora)
        '    cerrarconexion()



        '    '-----------------CONSULTAMOS SI EN EL CORTE SE HACE DE MAS DE 1 USUARIO, YA QUE UNO DE ELLOS
        '    '-----------------PUDO NO HABER HECHO SU CORTE, ENTONCES LE INDICAMOS AL USUARIO QUE SE HACE DE DOS
        '    Dim cantidadusuarioscorte As Integer
        '    Dim observacion As String
        '    conexionMysql.Open()
        '    Dim Sql3 As String
        '    Sql3 = "select count(distinct idusuario) from venta where fecha='" & fecha & "' and hora between '" & horafin1 & "' and '" & hora & "';"

        '    Dim cmd3 As New MySqlCommand(Sql3, conexionMysql)
        '    reader = cmd3.ExecuteReader()
        '    reader.Read()
        '    cantidadusuarioscorte = reader.GetString(0).ToString
        '    'conexionMysql.Close()

        '    If cantidadusuarioscorte > 1 Then
        '        observacion = "EL CORTE SE HIZO CON MAS DE 1 USUARIO, ADVERTENCIA"
        '    End If
        '    '---------------------------------------------------------------------------------
        '    '---------------------------------------------------------------------------------
        '    '---------------------------------------------------------------------------------
        '    '---------------------------------------------------------------------------------



        '    cerrarconexion()

        '    conexionMysql.Open()




        '    Dim Sqla1 As String
        '    Dim totalcorteventa As String
        '    'Sql = "select sum(total), fecha from venta where fecha='" & fecha & "';"
        '    Sqla1 = "select sum(total) from venta where fecha='" & fecha & "' and hora between '" & horafin1 & "' and '" & hora & "';"
        '    Dim cmda1 As New MySqlCommand(Sqla1, conexionMysql)
        '    reader = cmda1.ExecuteReader()
        '    reader.Read()
        '    Try
        '        totalcorteventa = reader.GetString(0).ToString
        '    Catch ex As Exception
        '        ' MsgBox("Aun no hay ventas.", MsgBoxStyle.Information, "Sistema")
        '        totalcorteventa = 0

        '        'si aun no hay ventas, intentamos cargar los cortes de caja que se han hecho.

        '        '-----------------------------------------------------------------------------------
        '        'cargamos una funcion que manda a la grilla todos los cortes de caja que se han realizado.

        '        cerrarconexion()

        '        'conexionMysql.Open()
        '        'Dim Sqlx12 As String
        '        'Sqlx12 = "select corte.idcorte, corte.extras, corte.fecha_registro, corte.hora_registro, usuario.usuario from corte, usuario where corte.fecha_registro='" & fecha & "'  and corte.idusuario=usuario.idusuario;"
        '        'Dim cmdx12 As New MySqlCommand(Sqlx12, conexionMysql)
        '        'Dim dt As New DataTable
        '        'Dim da As New MySqlDataAdapter(cmdx12)
        '        ''cargamos el formulario  resumen
        '        'da.Fill(dt)
        '        'cgrillacorte.DataSource = dt
        '        'cgrillacorte.Columns(0).Width = 50
        '        ''cgrillacorte.Columns(1).Width = 20
        '        'cgrillacorte.Columns(2).Width = 100
        '        'cgrillacorte.Columns(3).Width = 100
        '        'cgrillacorte.Columns(4).Width = 190
        '        ''cgrillacorte.Columns(5).Width = 80
        '        ''cgrillacorte.Columns(5).Width = 180

        '        'conexionMysql.Close()




        '    End Try

        '    conexionMysql.Close()
        '    cerrarconexion()
        '    ' Catch ex As Exception

        '    'End Try

        '    'obtener totales






        '    '--------------------------------------------------------------------------------------------- '---------------------------------------------------------------------------------------------
        '    '---------------------------------------------------------------------------------------------
        '    'primero seleccionamos el corte que se va a realizar

        '    ' Dim dia, mes, año, fecha As String
        '    'Dim hora As String
        '    'MsgBox("holaaaaaaaaaaaaaaaaaaaa")


        '    hora2 = Now.Hour()
        '    minuto = Now.Minute()
        '    segundo = Now.Second()

        '    hora = hora2 & ":" & minuto & ":" & segundo



        '    dia = Date.Now.Day
        '    mes = Date.Now.Month
        '    año = Date.Now.Year
        '    fecha = año & "-" & mes & "-" & dia


        '    'Try

        '    'primero selecciono la hora maxima de corte de caja del día de hoy. para que desde esa hora empiece a obtener valores

        '    Dim horafin As String

        '    cerrarconexion()

        '    conexionMysql.Open()
        '    Try
        '        Dim Sql1 As String
        '        Sql1 = "select max(hora_registro) from corte where fecha_registro='" & fecha & "';"
        '        Dim cmd1 As New MySqlCommand(Sql1, conexionMysql)
        '        reader = cmd1.ExecuteReader()
        '        reader.Read()

        '        horafin = reader.GetString(0).ToString
        '    Catch ex As Exception
        '        horafin = "00:00:00"
        '        '    tipoingreso()

        '    End Try

        '    conexionMysql.Close()
        '    '  MsgBox("la hora de registro de corte es:" & horafin)
        '    ' MsgBox("la hora DELSISTEMA ES:" & hora)

        '    cerrarconexion()

        '    conexionMysql.Open()

        '    Dim Sqlx1 As String
        '    Dim totalcortecompra As String
        '    'Sql = "select sum(total), fecha from venta where fecha='" & fecha & "';"
        '    Sqlx1 = "select sum(total)  from compra where fecha='" & fecha & "' and hora between '" & horafin & "' and '" & hora & "';"
        '    Dim cmdx1 As New MySqlCommand(Sqlx1, conexionMysql)
        '    reader = cmdx1.ExecuteReader()
        '    reader.Read()
        '    Try
        '        totalcortecompra = reader.GetString(0).ToString
        '    Catch ex As Exception
        '        'MsgBox("Aun no hay compras", MsgBoxStyle.Information, "Sistema")
        '        totalcortecompra = 0

        '        'si aun no hay ventas, intentamos cargar los cortes de caja que se han hecho.

        '        '-----------------------------------------------------------------------------------
        '        'cargamos una funcion que manda a la grilla todos los cortes de caja que se han realizado.




        '    End Try

        '    '----------------------------------------------------------------------------------------------



        '    'obtener fecha y hora
        '    ' Dim dia, mes, año, fecha As String

        '    hora2 = Now.Hour()
        '    minuto = Now.Minute()
        '    segundo = Now.Second()

        '    hora = hora2 & ":" & minuto & ":" & segundo

        '    dia = Date.Now.Day
        '    mes = Date.Now.Month
        '    año = Date.Now.Year
        '    fecha = año & "-" & mes & "-" & dia


        '    'consultamos el usuario para saber sobre quien se hizo el corte
        '    ' el usuario se encuentra en la variable usuarioactual

        '    '--------------------------------------------------------------------
        '    Dim idusuario As Integer


        '    cerrarconexion()

        '    'MsgBox(usuarioactual)


        '    conexionMysql.Open()
        '    Dim Sql2 As String
        '    Sql2 = "select idusuario from usuario where usuario='" & usuarioactual & "';"
        '    Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
        '    reader = cmd2.ExecuteReader
        '    reader.Read()
        '    idusuario = reader.GetString(0).ToString()


        '    '------------------ insertar reginstro en tabla venta ---------------------------------------
        '    cerrarconexion()

        '    If conexionMysql.State = ConnectionState.Open Then
        '        conexionMysql.Close()
        '        ' MsgBox("Si estaba abierta")
        '    End If

        '    If totalcorteventa = "" Or totalcortecompra = "" Then
        '        MsgBox("Existen campos vacios", MsgBoxStyle.Information, "Sistema")

        '    Else




        '        cerrarconexion()


        '        'If ctxtextras.Text = 0 Or ctxtcompras.Text = 0 Or ctxttotalescorte.Text Then
        '        'MsgBox("No es posible hacer un corte con Cero ventas")
        '        'Else




        '        conexionMysql.Open()

        '        Dim Sql As String
        '        'Sql = "INSERT INTO corte (`extras`, `fecha_registro`, `hora_registro`,`idusuario`,`compra` ) VALUES ('" & totalcorteventa & "', '" & fecha & "', '" & hora & "'," & idusuario & "," & totalcortecompra & ");"
        '        Sql = "INSERT INTO corte (`extras`, `fecha_registro`, `hora_registro`,`idusuario`,`compra`,`horainicio`,`horafin`,`observacion` ) VALUES ('" & totalcorteventa & "', '" & fecha & "', '" & hora & "'," & idusuario & "," & totalcortecompra & ",'" & horafin1 & "', '" & hora & "', '" & observacion & "');"
        '        Dim cmd As New MySqlCommand(Sql, conexionMysql)
        '        cmd.ExecuteNonQuery()


        '        MsgBox("Registro Guardado", MsgBoxStyle.Information, "Sistema")
        '        MsgBox("Se ha generado automaticamente un corte siendo las 12:00 horas, para mantener la integridad del sistema, se iniciara con un nuevo registro de venta", MsgBoxStyle.Exclamation, "Sistema")

        '        'pass.Text = nombre
        '        ' desglosecorte()
        '        'consultarcortecalendario()
        '        conexionMysql.Close()

        '        'borrarcorte()
        '        ' consultarcorte()

        '        'Dim respuesta As String
        '        'respuesta = MsgBox("¿Desea realizar la impresion de su corte de caja del día?", MsgBoxStyle.YesNo & MsgBoxStyle.Information, "Sistema")

        '        'End If


        '    End If





        'Else

        '    ' MsgBox("aun no es hora")
        'End If

    End Sub
    Function cargarformadepago()


        'limpiar el combo para que no se duplique
        cbformadepago.Items.Clear()
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

                cbformadepago.Items.Add(reader.GetString(1).ToString())
                cbformadepagoservicios.Items.Add(reader.GetString(1).ToString())
            Next



            cbformadepago.SelectedIndex = 0
            cbformadepagoservicios.SelectedIndex = 0

            reader.Close()

            conexionMysql.Close()


        Catch ex As Exception

        End Try



    End Function
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        obtenerfolio()
        ' Button14.ForeColor = Color.White
        TabControl1.SelectedIndex = 1
        txtcliente.Text = "USUARIO"
        listaclientes.Visible = False
        grilla.DefaultCellStyle.Font = New Font("Arial", 20)
        grilla.RowHeadersVisible = False



        'Button2.BackColor = Color.FromArgb(239, 239, 239)
        'Button1.BackColor = Color.FromArgb(64, 64, 64)
        '    Button3.BackColor = Color.FromArgb(64, 64, 64)
        '    Button4.BackColor = Color.FromArgb(64, 64, 64)
        '    Button5.BackColor = Color.FromArgb(64, 64, 64)
        '    Button6.BackColor = Color.FromArgb(64, 64, 64)
        '    Button8.BackColor = Color.FromArgb(64, 64, 64)
        '    Button10.BackColor = Color.FromArgb(64, 64, 64)
        '    Button12.BackColor = Color.FromArgb(64, 64, 64)
        '    Button13.BackColor = Color.FromArgb(64, 64, 64)
        '    Button67.BackColor = Color.FromArgb(64, 64, 64)


        Button1.BackColor = Color.FromArgb(47, 56, 72)
        Button2.BackColor = Color.DimGray
        Button3.BackColor = Color.FromArgb(47, 56, 72)
        Button4.BackColor = Color.FromArgb(47, 56, 72)
        Button5.BackColor = Color.FromArgb(47, 56, 72)
        Button6.BackColor = Color.FromArgb(47, 56, 72)
        Button8.BackColor = Color.FromArgb(47, 56, 72)
        Button10.BackColor = Color.FromArgb(47, 56, 72)
        Button12.BackColor = Color.FromArgb(47, 56, 72)
        Button13.BackColor = Color.FromArgb(47, 56, 72)
        Button67.BackColor = Color.FromArgb(47, 56, 72)





        'se obtiene el folio cada vez que se agrege un producto. 
        obtenerfolio()
        obtener_chticket_Chcambio_venta()
        txtclave.Focus()
        cargarformadepago()

    End Sub


    Function obtener_chticket_Chcambio_venta()
        cerrarconexion()
        Try

            Dim valorticket, valorcambio As String
            conexionMysql.Open()
            Dim Sql111 As String
            Sql111 = "select obligarticket,obligarcambio from datos_empresa;"
            Dim cmd111 As New MySqlCommand(Sql111, conexionMysql)
            reader = cmd111.ExecuteReader()
            reader.Read()
            valorticket = reader.GetString(0).ToString
            valorcambio = reader.GetString(1).ToString
            conexionMysql.Close()

            If valorticket = 1 Then
                chimpresionticket.Checked = True
            Else
                chimpresionticket.Checked = False

            End If

            If valorcambio = 1 Then
                chcalcularcambio.Checked = True
            Else
                chcalcularcambio.Checked = False
            End If
        Catch ex As Exception
            ' MsgBox("fallo", MsgBoxStyle.Information)
        End Try

    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TabControl1.SelectedIndex = 0

        Button1.BackColor = Color.DimGray
        Button2.BackColor = Color.FromArgb(47, 56, 72)
        Button3.BackColor = Color.FromArgb(47, 56, 72)
        Button4.BackColor = Color.FromArgb(47, 56, 72)
        Button5.BackColor = Color.FromArgb(47, 56, 72)
        Button6.BackColor = Color.FromArgb(47, 56, 72)
        Button8.BackColor = Color.FromArgb(47, 56, 72)
        Button10.BackColor = Color.FromArgb(47, 56, 72)
        Button12.BackColor = Color.FromArgb(47, 56, 72)
        Button13.BackColor = Color.FromArgb(47, 56, 72)
        Button67.BackColor = Color.FromArgb(47, 56, 72)

        ' estadistica()

    End Sub
    Function cargarproveedorcompras()


        Try

            'limpiar el combo para que no se duplique
            cbproveedorcompras.Items.Clear()



            Dim cantidadproveedor, i As Integer
            cerrarconexion()

            conexionMysql.Open()
            Dim Sql As String
            Sql = "select count(*)as contador from proveedor;"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            reader = cmd.ExecuteReader()
            reader.Read()
            cantidadproveedor = reader.GetString(0).ToString()

            conexionMysql.Close()

            cerrarconexion()

            conexionMysql.Open()
            Dim Sql2 As String
            Sql2 = "select * from proveedor;"
            Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            reader = cmd2.ExecuteReader()

            For i = 1 To cantidadproveedor

                reader.Read()

                cbproveedorcompras.Items.Add(reader.GetString(1).ToString())
            Next

            reader.Close()

            conexionMysql.Close()
        Catch ex As Exception

        End Try

    End Function
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim tipo As Integer
        obtener_chticket_Chcambio_venta()
        'tipo = tipoingreso()



        tipo = tipoingreso()

        comprobarpermisoventana()
        tipo = p2
        'lbclientes.Visible = False

        'MsgBox("primer permiso")
        'MsgBox(p1)
        'comprobamos si tiene los permisos para entrar a esta ventana








        If tipo = 0 Then

            TabControl1.SelectedIndex = 1
            Button1.BackColor = Color.DimGray
            Button2.BackColor = Color.FromArgb(47, 56, 72)
            Button3.BackColor = Color.FromArgb(47, 56, 72)
            Button4.BackColor = Color.FromArgb(47, 56, 72)
            Button5.BackColor = Color.FromArgb(47, 56, 72)
            Button6.BackColor = Color.FromArgb(47, 56, 72)
            Button8.BackColor = Color.FromArgb(47, 56, 72)
            Button10.BackColor = Color.FromArgb(47, 56, 72)
            Button12.BackColor = Color.FromArgb(47, 56, 72)
            Button13.BackColor = Color.FromArgb(47, 56, 72)
            Button67.BackColor = Color.FromArgb(47, 56, 72)


            comprobartipoingreso()
        Else


            listaproductos.Visible = False


            'cargamos los proveedores de compras.
            cargarproveedorcompras()

            'rbgastosdiarios.Enabled = True
            rbgastosdiarios.Checked = True

            cccgrilla.DefaultCellStyle.Font = New Font("Arial", 20)
            cccgrilla.RowHeadersVisible = False

            ccgrilla.DefaultCellStyle.Font = New Font("Arial", 20)
            ccgrilla.RowHeadersVisible = False

            TabControl1.SelectedIndex = 2
            cgrilla.DefaultCellStyle.Font = New Font("Arial", 20)
            cgrilla.RowHeadersVisible = False
            'ampliar columna 
            'grillap.Columns(2).Width = 120
            cgrilla.Visible = True
            ccgrilla.Visible = False
            cccgrilla.Visible = False


            cgrilla.AlternatingRowsDefaultCellStyle.BackColor = Color.SkyBlue
            ccgrilla.AlternatingRowsDefaultCellStyle.BackColor = Color.SkyBlue
            cccgrilla.AlternatingRowsDefaultCellStyle.BackColor = Color.SkyBlue

            comprasdeldia()
            ctxtcomprado.Text = consultacompras()



            Button1.BackColor = Color.FromArgb(47, 56, 72)
            Button2.BackColor = Color.FromArgb(47, 56, 72)
            Button3.BackColor = Color.DimGray
            Button4.BackColor = Color.FromArgb(47, 56, 72)
            Button5.BackColor = Color.FromArgb(47, 56, 72)
            Button6.BackColor = Color.FromArgb(47, 56, 72)
            Button8.BackColor = Color.FromArgb(47, 56, 72)
            Button10.BackColor = Color.FromArgb(47, 56, 72)
            Button12.BackColor = Color.FromArgb(47, 56, 72)
            Button13.BackColor = Color.FromArgb(47, 56, 72)
            Button67.BackColor = Color.FromArgb(47, 56, 72)

        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        obtener_chticket_Chcambio_venta()
        Dim tipo As Integer

        tipo = tipoingreso()


        comprobarpermisoventana()
        tipo = p3



        If tipo = 0 Then

            TabControl1.SelectedIndex = 1
            Button1.BackColor = Color.DimGray
            Button2.BackColor = Color.FromArgb(47, 56, 72)
            Button3.BackColor = Color.FromArgb(47, 56, 72)
            Button4.BackColor = Color.FromArgb(47, 56, 72)
            Button5.BackColor = Color.FromArgb(47, 56, 72)
            Button6.BackColor = Color.FromArgb(47, 56, 72)
            Button8.BackColor = Color.FromArgb(47, 56, 72)
            Button10.BackColor = Color.FromArgb(47, 56, 72)
            Button12.BackColor = Color.FromArgb(47, 56, 72)
            Button13.BackColor = Color.FromArgb(47, 56, 72)
            Button67.BackColor = Color.FromArgb(47, 56, 72)


            comprobartipoingreso()
        Else

            TabControl1.SelectedIndex = 3
            txtnombrep.Visible = False
            'btnbuscarnombrep.Visible = False
            rbclavep.Checked = True
            cargarproveedor()
            cargartiposervicio()
            Button1.BackColor = Color.FromArgb(47, 56, 72)
            Button2.BackColor = Color.FromArgb(47, 56, 72)
            Button3.BackColor = Color.FromArgb(47, 56, 72)
            Button4.BackColor = Color.DimGray
            Button5.BackColor = Color.FromArgb(47, 56, 72)
            Button6.BackColor = Color.FromArgb(47, 56, 72)
            Button8.BackColor = Color.FromArgb(47, 56, 72)
            Button10.BackColor = Color.FromArgb(47, 56, 72)
            Button12.BackColor = Color.FromArgb(47, 56, 72)
            Button13.BackColor = Color.FromArgb(47, 56, 72)
            Button67.BackColor = Color.FromArgb(47, 56, 72)

            llenadogrilla()


            pgrillaproductosfaltantes.Visible = False


        End If

    End Sub
    Function cargargrillacaja()
        '-----------------------------------------------
        'CARGAMOS A LA GRILLA TODAS LAS VENTAS Y COMPRAS REALIZADAS EL DÍA ACTUAL.
        '--------------------------------------------------

        Try
            conexionMysql.Open()
            Dim sql1 As String
            sql1 = "select ventaind.idventa,ventaind.idventaind,ventaind.actividad, ventaind.cantidad, ventaind.costo,ventaind.descripcion,venta.idventa, venta.cantidad, venta.total, venta.fecha, venta.hora, venta.fechaentrega, venta.anticipo, venta.resto, venta.pagacon, venta.pagacon  from ventaind,venta where venta.idventa=ventaind.idventa;
"
            Dim cmd1 As New MySqlCommand(sql1, conexionMysql)
            reader = cmd1.ExecuteReader
            reader.Read()
            cbtncompras.Text = "$" & reader.GetString(0).ToString()
            conexionMysql.Close()
            cerrarconexion()
        Catch ex As Exception
            MsgBox("Aun no hay compras realizadas", MsgBoxStyle.Information, "Sistema")
            cbtncompras.Text = "$00.0"
            cerrarconexion()
        End Try




    End Function
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        obtener_chticket_Chcambio_venta()
        btncortes.Visible = False
        btnventasrapidas.Visible = True
        btncomprasdia.Visible = True
        btnanticiposventas.Visible = True
        pgrillaproductosfaltantes.Visible = False
        btnproductosfaltantes.Visible = False
        lbfiltrarfaltante.Visible = False
        corcbproveedores.Visible = False
        btnimprimirfiltro.Visible = False





        Dim tipo As Integer





        tipo = tipoingreso()

        comprobarpermisoventana()
        tipo = p4




        If tipo = 0 Then

            TabControl1.SelectedIndex = 1
            Button1.BackColor = Color.DimGray
            Button2.BackColor = Color.FromArgb(47, 56, 72)
            Button3.BackColor = Color.FromArgb(47, 56, 72)
            Button4.BackColor = Color.FromArgb(47, 56, 72)
            Button5.BackColor = Color.FromArgb(47, 56, 72)
            Button5.BackColor = Color.FromArgb(47, 56, 72)
            Button5.BackColor = Color.FromArgb(47, 56, 72)
            Button5.BackColor = Color.FromArgb(47, 56, 72)
            Button6.BackColor = Color.FromArgb(47, 56, 72)
            Button8.BackColor = Color.FromArgb(47, 56, 72)
            Button10.BackColor = Color.FromArgb(47, 56, 72)
            Button12.BackColor = Color.FromArgb(47, 56, 72)
            Button13.BackColor = Color.FromArgb(47, 56, 72)
            Button67.BackColor = Color.FromArgb(47, 56, 72)


            comprobartipoingreso()
        Else



            'cgrillacorte.Visible = False
            'cgrillaentrada.Visible = True
            cgrillacorte.Visible = True
            cgrillaentrada.Visible = False
            cgrillasalida.Visible = False
            clbentrada.Visible = False
            clbsalidas.Visible = False





            pgrillaproductosfaltantes.DefaultCellStyle.Font = New Font("Arial", 20)
            pgrillaproductosfaltantes.RowHeadersVisible = False

            cgrillacorte.DefaultCellStyle.Font = New Font("Arial", 20)
            cgrillacorte.RowHeadersVisible = False
            'ampliar columna 
            'grillap.Columns(2).Width = 120
            cgrillaentrada.DefaultCellStyle.Font = New Font("Arial", 20)
            cgrillaentrada.RowHeadersVisible = False


            cgrillasalida.DefaultCellStyle.Font = New Font("Arial", 20)
            cgrillasalida.RowHeadersVisible = False




            cgrillacorte.AlternatingRowsDefaultCellStyle.BackColor = Color.SkyBlue
            cgrillaentrada.AlternatingRowsDefaultCellStyle.BackColor = Color.SkyBlue
            cgrillasalida.AlternatingRowsDefaultCellStyle.BackColor = Color.SkyBlue


            'desglosecorte sirve para hacer un recuento de cuanto se ha vendido hasta el momento de extras, paleleria y servicios
            'desglosecorte()
            desgloseventas()
            'CONSULTACORTECALENDARIO: CONSULTA LAS VENTAS QUE SE HAN REALIZADO
            consultacortecalendario()
            'desglosecortecalendario()
            'cgrillaentrada.Visible = True
            'resumenventas()

            TabControl1.SelectedIndex = 4

            Button1.BackColor = Color.FromArgb(47, 56, 72)
            Button2.BackColor = Color.FromArgb(47, 56, 72)
            Button3.BackColor = Color.FromArgb(47, 56, 72)
            Button4.BackColor = Color.FromArgb(47, 56, 72)
            Button5.BackColor = Color.DimGray
            Button6.BackColor = Color.FromArgb(47, 56, 72)
            Button8.BackColor = Color.FromArgb(47, 56, 72)
            Button10.BackColor = Color.FromArgb(47, 56, 72)
            Button12.BackColor = Color.FromArgb(47, 56, 72)
            Button13.BackColor = Color.FromArgb(47, 56, 72)
            Button67.BackColor = Color.FromArgb(47, 56, 72)





            'se consulta cuanto se ha vendido...
            consultacomprascorte()
            cgrillacorte.RowHeadersVisible = False
            consultarcorte()
            ' desglosecorte()
            '  consultarcortecalendario()

            Try
                'ctxttotalescorte.Text = CDbl(ctxtextras.Text) - CDbl(ctxtcompras.Text)
            Catch ex As Exception

            End Try
        End If

    End Sub
    Function consultacortecalendario()
        Dim dia, mes, año, fecha As String

        hora2 = Now.Hour()
        minuto = Now.Minute()
        segundo = Now.Second()


        ' Try


        fecha = calendario.SelectionRange.Start.ToString("yyyy/MM/dd")
        'CONSULTA PARA TODOS LOS PRODUCTOS EXTRAS, PAPELERIA Y SERVICIOS
        cerrarconexion()

        'MsgBox(fecha)

        Try
            conexionMysql.Open()
            Dim sql1 As String
            sql1 = "select sum(total)  from compra where fecha='" & fecha & "';"
            Dim cmd1 As New MySqlCommand(sql1, conexionMysql)
            reader = cmd1.ExecuteReader
            reader.Read()
            cbtncompras.Text = "$" & reader.GetString(0).ToString()
            conexionMysql.Close()
            cerrarconexion()
        Catch ex As Exception
            'MsgBox("Aun no hay compras realizadas", MsgBoxStyle.Information, "Sistema")
            cbtncompras.Text = "$00.0"
            cerrarconexion()
        End Try


        'Try
        Dim sumaanticipo, sumatotalventa As Double

        Try

            conexionMysql.Open()
            Dim Sql2 As String
            '------PRIMERO SUMAMOS LAS VENTAS DE LOS SERVICIOS
            Sql2 = "select sum(anticipo) from servicios_ventas where fecha='" & fecha & "';"
            'Sql2 = "select sum(total)as total from venta where fecha='" & fecha & "';"
            Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            reader = cmd2.ExecuteReader
            reader.Read()
            sumaanticipo = reader.GetString(0).ToString()
            'MsgBox(reader.GetString(0).ToString())
            conexionMysql.Close()
            cerrarconexion()

        Catch ex As Exception
            'MsgBox("error 1")
            sumaanticipo = 0
            cerrarconexion()
        End Try

        Try
            conexionMysql.Open()

            Dim Sql3 As String
            '------PRIMERO SUMAMOS LAS VENTAS generales ventas rapidas
            Sql3 = "select sum(total) from venta where fecha='" & fecha & "' and tipoventa=1;"

            '           Sql2 = "select sum(total)as total from venta where fecha='" & fecha & "';"
            Dim cmd3 As New MySqlCommand(Sql3, conexionMysql)
            reader = cmd3.ExecuteReader
            reader.Read()
            sumatotalventa = reader.GetString(0).ToString()

            'MsgBox(reader.GetString(0).ToString())
            conexionMysql.Close()
            cerrarconexion()
        Catch ex As Exception
            'MsgBox("error 2")
            sumatotalventa = 0
            cerrarconexion()

        End Try
        'MsgBox(sumatotalventa)
        'MsgBox(sumaanticipo)

        cbtnventas.Text = CDbl(sumatotalventa) + CDbl(sumaanticipo)
        'conexionMysql.Open()
        'Dim Sql3 As String
        ' Sql3 = "select sum(recargas_venta)as suma1, sum(ciber) as suma from corte where fecha_registro='" & fecha & "';"
        'Dim cmd3 As New MySqlCommand(Sql3, conexionMysql)
        'reader = cmd3.ExecuteReader
        'reader.Read()

        'conexionMysql.Close()
        ' Catch ex As Exception
        ' MsgBox("Aun no hay ventas realizadas", MsgBoxStyle.Information, "Sistema")
        ' cbtnextras.Text = "$00.0"
        'cbtnventas.Text = "$00.0"
        'End Try


        Try

            'calculamos las operaciones para que de el final.
            cbttotales.Text = "$ " & CDbl(cbtnventas.Text) - CDbl(cbtncompras.Text)
        Catch ex As Exception
            MsgBox("La información es corrupta", MsgBoxStyle.Information, "Sistema")
            cbttotales.Text = "$00.0"
            cerrarconexion()
        End Try


        'Catch ex As Exception
        '        cerrarconexion()

        'End Try


    End Function
    Function consultarcortecalendario()
        Dim dia, mes, año, fecha As String
        Dim hora As String
        'MsgBox("holaaaaaaaaaaaaaaaaaaaa")


        hora2 = Now.Hour()
        minuto = Now.Minute()
        segundo = Now.Second()

        hora = hora2 & ":" & minuto & ":" & segundo



        fecha = calendario.SelectionRange.Start.ToString("yyyy/MM/dd")
        'fecha = calendario.SelectionRange.End.ToString("yyy/MM/dd")
        'Try

        'primero selecciono la hora maxima de corte de caja del día de hoy. para que desde esa hora empiece a obtener valores

        Dim horafin As String

        cerrarconexion()

        'conexionMysql.Open()

        'Dim Sql1 As String
        'Sql1 = "select max(hora_registro) from corte where fecha_registro='" & fecha & "';"
        'Dim cmd1 As New MySqlCommand(Sql1, conexionMysql)
        'reader = cmd1.ExecuteReader()
        'reader.Read()
        'Try
        '    horafin = reader.GetString(0).ToString
        'Catch ex As Exception
        '    horafin = "00:00:00"
        'End Try

        'conexionMysql.Close()
        '  MsgBox("la hora de registro de corte es:" & horafin)
        ' MsgBox("la hora DELSISTEMA ES:" & hora)


        'conexionMysql.Open()

        'Dim Sql As String
        ''Sql = "select sum(total), fecha from venta where fecha='" & fecha & "';"
        'Sql = "select sum(total) from venta where fecha='" & fecha & "' and hora between '" & horafin & "' and '" & hora & "';"
        'Dim cmd As New MySqlCommand(Sql, conexionMysql)
        'reader = cmd.ExecuteReader()
        'reader.Read()
        'Try
        '    ctxtextras.Text = reader.GetString(0).ToString
        'Catch ex As Exception
        '    ' MsgBox("Aun no hay ventas.", MsgBoxStyle.Information, "Sistema")
        '    ctxtextras.Text = 0

        'si aun no hay ventas, intentamos cargar los cortes de caja que se han hecho.

        '-----------------------------------------------------------------------------------
        'cargamos una funcion que manda a la grilla todos los cortes de caja que se han realizado.

        cerrarconexion()

        Try




            '            MsgBox("cargado cortes")
            conexionMysql.Open()
            Dim Sqlx1 As String
            Sqlx1 = "select * from caja where fecha='" & fecha & "';"
            Dim cmdx1 As New MySqlCommand(Sqlx1, conexionMysql)
            Dim dt As New DataTable
            Dim da As New MySqlDataAdapter(cmdx1)
            'cargamos el formulario  resumen
            da.Fill(dt)
            cgrillacorte.DataSource = dt
            'cgrillacorte.Columns(0).Width = 50
            'cgrillacorte.Columns(1).Width = 50
            'cgrillacorte.Columns(1).Width = 20
            'cgrillacorte.Columns(2).Width = 50
            'cgrillacorte.Columns(3).Width = 50
            'cgrillacorte.Columns(4).Width = 190
            'cgrillacorte.Columns(5).Width = 80
            'cgrillacorte.Columns(5).Width = 180

            conexionMysql.Close()


        Catch ex As Exception
            cerrarconexion()
            MsgBox("Upsss... encontramos un error en el sistema", MsgBoxStyle.Information, "Sistema")
        End Try


        'End Try

        'conexionMysql.Close()

        ' Catch ex As Exception

        'End Try

        'obtener totales
        'Try
        '    ctxttotalescorte.Text = CDbl(ctxtciber.Text) + CDbl(ctxtextras.Text) + CDbl(ctxtrecargas_venta.Text)
        '    MsgBox("hay un error")
        'Catch ex As Exception

        'End Try

    End Function
    Function consultarcorte()
        Dim dia, mes, año, fecha As String
        Dim hora As String
        'MsgBox("holaaaaaaaaaaaaaaaaaaaa")


        hora2 = Now.Hour()
        minuto = Now.Minute()
        segundo = Now.Second()

        hora = hora2 & ":" & minuto & ":" & segundo



        dia = Date.Now.Day
        mes = Date.Now.Month
        año = Date.Now.Year
        fecha = año & "-" & mes & "-" & dia


        'Try

        'primero selecciono la hora maxima de corte de caja del día de hoy. para que desde esa hora empiece a obtener valores

        Dim horafin As String

        cerrarconexion()

        conexionMysql.Open()
        Try
            Dim Sql1 As String
            Sql1 = "select max(hora_registro) from corte where fecha_registro='" & fecha & "';"
            Dim cmd1 As New MySqlCommand(Sql1, conexionMysql)
            reader = cmd1.ExecuteReader()
            reader.Read()

            horafin = reader.GetString(0).ToString
        Catch ex As Exception
            horafin = "00:00:00"
            tipoingreso()
        End Try

        conexionMysql.Close()
        '  MsgBox("la hora de registro de corte es:" & horafin)
        ' MsgBox("la hora DELSISTEMA ES:" & hora)
        cerrarconexion()


        conexionMysql.Open()

        Dim Sql As String
        'Sql = "select sum(total), fecha from venta where fecha='" & fecha & "';"
        Sql = "select sum(total) from venta where fecha='" & fecha & "' and hora between '" & horafin & "' and '" & hora & "';"
        Dim cmd As New MySqlCommand(Sql, conexionMysql)
        reader = cmd.ExecuteReader()
        reader.Read()
        Try
            'ctxtextras.Text = reader.GetString(0).ToString
        Catch ex As Exception
            MsgBox("Aun no hay ventas.", MsgBoxStyle.Information, "Sistema")
            'ctxtextras.Text = 0

            'si aun no hay ventas, intentamos cargar los cortes de caja que se han hecho.

            '-----------------------------------------------------------------------------------
            'cargamos una funcion que manda a la grilla todos los cortes de caja que se han realizado.

            cerrarconexion()

            conexionMysql.Open()
            Dim Sqlx1 As String
            Sqlx1 = "select corte.idcorte, corte.extras, corte.fecha_registro, corte.hora_registro, usuario.usuario from corte, usuario where corte.fecha_registro='" & fecha & "'  and corte.idusuario=usuario.idusuario;"
            Dim cmdx1 As New MySqlCommand(Sqlx1, conexionMysql)
            Dim dt As New DataTable
            Dim da As New MySqlDataAdapter(cmdx1)
            'cargamos el formulario  resumen
            da.Fill(dt)
            cgrillacorte.DataSource = dt
            cgrillacorte.Columns(0).Width = 50
            'cgrillacorte.Columns(1).Width = 20
            cgrillacorte.Columns(2).Width = 100
            cgrillacorte.Columns(3).Width = 100
            cgrillacorte.Columns(4).Width = 190
            'cgrillacorte.Columns(5).Width = 80
            'cgrillacorte.Columns(5).Width = 180

            conexionMysql.Close()




        End Try

        conexionMysql.Close()
        cerrarconexion()
        ' Catch ex As Exception

        'End Try

        'obtener totales


    End Function

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        obtener_chticket_Chcambio_venta()
        Dim tipo As Integer

        tipo = tipoingreso()


        comprobarpermisoventana()
        tipo = p5


        If tipo = 0 Then

            TabControl1.SelectedIndex = 1
            Button1.BackColor = Color.DimGray
            Button2.BackColor = Color.FromArgb(47, 56, 72)
            Button3.BackColor = Color.FromArgb(47, 56, 72)
            Button4.BackColor = Color.FromArgb(47, 56, 72)
            Button5.BackColor = Color.FromArgb(47, 56, 72)
            Button6.BackColor = Color.FromArgb(47, 56, 72)
            Button8.BackColor = Color.FromArgb(47, 56, 72)
            Button10.BackColor = Color.FromArgb(47, 56, 72)
            Button12.BackColor = Color.FromArgb(47, 56, 72)
            Button13.BackColor = Color.FromArgb(47, 56, 72)
            Button67.BackColor = Color.FromArgb(47, 56, 72)
            comprobartipoingreso()
        Else


            TabControl1.SelectedIndex = 5
            'cargamos los usuario.
            ucargartipousuario()

            Button1.BackColor = Color.FromArgb(47, 56, 72)
            Button2.BackColor = Color.FromArgb(47, 56, 72)
            Button3.BackColor = Color.FromArgb(47, 56, 72)
            Button4.BackColor = Color.FromArgb(47, 56, 72)
            Button5.BackColor = Color.FromArgb(47, 56, 72)
            Button6.BackColor = Color.DimGray
            Button8.BackColor = Color.FromArgb(47, 56, 72)
            Button10.BackColor = Color.FromArgb(47, 56, 72)
            Button12.BackColor = Color.FromArgb(47, 56, 72)
            Button13.BackColor = Color.FromArgb(47, 56, 72)
            Button67.BackColor = Color.FromArgb(47, 56, 72)


        End If

    End Sub
    Function comprobarpermisoventana()
        Try

            cerrarconexion()

            conexionMysql.Open()
            Dim Sqlx1 As String
            Sqlx1 = "select pclientes,pcompras,pproductos,pcorte,pusuarios,pproveedores,preportes,pconfiguracion from usuario where usuario='" & nombreusuario & "';"
            Dim cmdx1 As New MySqlCommand(Sqlx1, conexionMysql)

            reader = cmdx1.ExecuteReader()
            reader.Read()
            p1 = reader.GetString(0).ToString
            p2 = reader.GetString(1).ToString
            p3 = reader.GetString(2).ToString
            p4 = reader.GetString(3).ToString
            p5 = reader.GetString(4).ToString
            p6 = reader.GetString(5).ToString
            p7 = reader.GetString(6).ToString
            p8 = reader.GetString(7).ToString

            conexionMysql.Close()
        Catch ex As Exception

        End Try

    End Function
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        obtener_chticket_Chcambio_venta()
        'llenamos la grilla de los clientes existentes
        cllenadocliente()
        'ocultamos la grilla de servicios del cliente
        grillaclienteservicios.Visible = False
        grillacliente.Visible = True
        grupocontrolesclientes.Visible = False

        comprobarpermisoventana()

        Dim tipo As Integer

        tipo = tipoingreso()

        lbclientes.Visible = False

        '  MsgBox("primer permiso")
        'MsgBox(p1)
        'comprobamos si tiene los permisos para entrar a esta ventana

        tipo = p1

        'si el tipo de ingreso es 2, significa que es un trabajador, verificamos solamente si tiene permitido entrar a 
        If tipo = 0 Then


            'comprobamos si tiene



            TabControl1.SelectedIndex = 1
            Button1.BackColor = Color.DimGray
            Button2.BackColor = Color.FromArgb(47, 56, 72)
            Button3.BackColor = Color.FromArgb(47, 56, 72)
            Button4.BackColor = Color.FromArgb(47, 56, 72)
            Button5.BackColor = Color.FromArgb(47, 56, 72)
            Button6.BackColor = Color.FromArgb(47, 56, 72)
            Button8.BackColor = Color.FromArgb(47, 56, 72)
            Button10.BackColor = Color.FromArgb(47, 56, 72)
            Button12.BackColor = Color.FromArgb(47, 56, 72)
            Button13.BackColor = Color.FromArgb(47, 56, 72)
            Button67.BackColor = Color.FromArgb(47, 56, 72)


            comprobartipoingreso()
        Else


            TabControl1.SelectedIndex = 6

            Button1.BackColor = Color.FromArgb(47, 56, 72)
            Button2.BackColor = Color.FromArgb(47, 56, 72)
            Button3.BackColor = Color.FromArgb(47, 56, 72)
            Button4.BackColor = Color.FromArgb(47, 56, 72)
            Button5.BackColor = Color.FromArgb(47, 56, 72)
            Button6.BackColor = Color.FromArgb(47, 56, 72)
            Button8.BackColor = Color.DimGray
            Button10.BackColor = Color.FromArgb(47, 56, 72)
            Button12.BackColor = Color.FromArgb(47, 56, 72)
            Button13.BackColor = Color.FromArgb(47, 56, 72)
            Button67.BackColor = Color.FromArgb(47, 56, 72)


        End If

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        obtener_chticket_Chcambio_venta()

        Dim tipo As Integer

        tipo = tipoingreso()

        comprobarpermisoventana()
        tipo = p7


        If tipo = 0 Then


            TabControl1.SelectedIndex = 1
            Button1.BackColor = Color.DimGray
            Button2.BackColor = Color.FromArgb(47, 56, 72)
            Button3.BackColor = Color.FromArgb(47, 56, 72)
            Button4.BackColor = Color.FromArgb(47, 56, 72)
            Button5.BackColor = Color.FromArgb(47, 56, 72)
            Button6.BackColor = Color.FromArgb(47, 56, 72)
            Button8.BackColor = Color.FromArgb(47, 56, 72)
            Button10.BackColor = Color.FromArgb(47, 56, 72)
            Button12.BackColor = Color.FromArgb(47, 56, 72)
            Button13.BackColor = Color.FromArgb(47, 56, 72)
            Button67.BackColor = Color.FromArgb(47, 56, 72)


            comprobartipoingreso()
        Else
            TabControl1.SelectedIndex = 8
            Button1.BackColor = Color.FromArgb(47, 56, 72)
            Button2.BackColor = Color.FromArgb(47, 56, 72)
            Button3.BackColor = Color.FromArgb(47, 56, 72)
            Button4.BackColor = Color.FromArgb(47, 56, 72)
            Button5.BackColor = Color.FromArgb(47, 56, 72)
            Button6.BackColor = Color.FromArgb(47, 56, 72)
            Button8.BackColor = Color.FromArgb(47, 56, 72)
            Button10.BackColor = Color.DimGray
            Button12.BackColor = Color.FromArgb(47, 56, 72)
            Button13.BackColor = Color.FromArgb(47, 56, 72)
            Button67.BackColor = Color.FromArgb(47, 56, 72)


        End If


    End Sub


    Function cargarlogook()
        'Dim cmdx1 As New MySqlCommand(Sqlx1, conexionMysql)
        'Dim dt As New DataTable
        ' Try

        'pblogo.Visible = True


        ' Establecemos a Nothing el valor de la propiedad Image
        ' del control PictureBox.
        'pblogo.Image = Nothing
        pblogo.Image = Nothing
        ' Catch ex As Exception

        'End Try

        Try
            Dim sql As String
            Dim dt As New DataTable
            sql = "select * from logo_empresa;"
            Dim cmdx1 As New MySqlCommand(sql, conexionMysql)
            Dim da As New MySqlDataAdapter(cmdx1)

            '            da = New SqlDataAdapter(sql, conexionMysql)
            conexionMysql.Open()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Dim ms As New System.IO.MemoryStream() 'Creamos el MemoryStream y poder cargar la imagen.
                Dim imageBuffer() As Byte = CType(dt.Rows(0).Item("LOGO"), Byte()) 'Conbertimos la imagen cargada en el datatable a Bytes.
                ms = New System.IO.MemoryStream(imageBuffer) 'Cargamos el MemoryStream con la imagen ya convertida en Bytes.
                pblogo.BackgroundImage = Nothing 'Si existe una imagen cargada en el PictureBox la borramos.
                pblogo.BackgroundImage = (Image.FromStream(ms)) 'Cargamos la imagen al PictureBox, Nota: Lo hacemos como .BackgroundImage pero igual lo podemos hacer como .Image.
                pblogo.BackgroundImageLayout = ImageLayout.Stretch 'Ajustamos la imagen al todo el PictureBox.
                conexionMysql.Close()
                dt.Clear()
                dt.Reset()
                ms.Dispose()
                ms.Close()
                sql = ""
            End If
            conexionMysql.Close()


            comprobarexistenciadelogo()



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        obtener_chticket_Chcambio_venta()
        cerrarconexion()
        cargarlogoticket()
        'cargarlogook()
        ' comprobarexistenciadelogo()

        Dim tipo As Integer



        tipo = tipoingreso()
        comprobarpermisoventana()
        tipo = p8


        If tipo = 0 Then

            TabControl1.SelectedIndex = 1
            Button1.BackColor = Color.DimGray
            Button2.BackColor = Color.FromArgb(47, 56, 72)
            Button3.BackColor = Color.FromArgb(47, 56, 72)
            Button4.BackColor = Color.FromArgb(47, 56, 72)
            Button5.BackColor = Color.FromArgb(47, 56, 72)
            Button6.BackColor = Color.FromArgb(47, 56, 72)
            Button8.BackColor = Color.FromArgb(47, 56, 72)
            Button10.BackColor = Color.FromArgb(47, 56, 72)
            Button12.BackColor = Color.FromArgb(47, 56, 72)
            Button13.BackColor = Color.FromArgb(47, 56, 72)
            Button67.BackColor = Color.FromArgb(47, 56, 72)


            comprobartipoingreso()
        Else

            TabControl1.SelectedIndex = 9

            Button1.BackColor = Color.FromArgb(47, 56, 72)
            Button2.BackColor = Color.FromArgb(47, 56, 72)
            Button3.BackColor = Color.FromArgb(47, 56, 72)
            Button4.BackColor = Color.FromArgb(47, 56, 72)
            Button5.BackColor = Color.FromArgb(47, 56, 72)
            Button6.BackColor = Color.FromArgb(47, 56, 72)
            Button8.BackColor = Color.FromArgb(47, 56, 72)
            Button10.BackColor = Color.FromArgb(47, 56, 72)
            Button12.BackColor = Color.DimGray
            Button13.BackColor = Color.FromArgb(47, 56, 72)
            Button67.BackColor = Color.FromArgb(47, 56, 72)





        End If

        Try
            asignar_impresora()
            'cargamos los datos de la empresa para que se muestren, en caso de que exista un valor.
            cargardatos_empresa()
            'cargamos el tipo de corte que se ha seleccionado en su momento.
            'en caso de que no exista ningun corte lo insertamos, solo existen 2 tipo, por usuario y por tiempo
            tipo_corte_configuracion()

            cargardatos_ticket_cambio()



            'cargarlogook()
        Catch ex As Exception
            cerrarconexion()
        End Try


    End Sub



    Function cargardatos_ticket_cambio()

        cerrarconexion()
        Dim valorticket, valorcambio As String
        conexionMysql.Open()
        Dim Sql111 As String
        Sql111 = "select obligarticket,obligarcambio from datos_empresa;"
        Dim cmd111 As New MySqlCommand(Sql111, conexionMysql)
        reader = cmd111.ExecuteReader()
        reader.Read()
        valorticket = reader.GetString(0).ToString
        valorcambio = reader.GetString(1).ToString
        conexionMysql.Close()

        If valorticket = 1 Then
            chticket.Checked = True
        Else
            chticket.Checked = False

        End If

        If valorcambio = 1 Then
            chcambio.Checked = True
        Else
            chcambio.Checked = False
        End If


    End Function
    Function asignar_impresora()



        Dim respuesta_nombre_impresora As String


        respuesta_nombre_impresora = obtener_nombre_impresora()
        ' MsgBox(respuesta_nombre_impresora)

        If respuesta_nombre_impresora = "" Then
            'en caso de que no exista impresora almacenada, entonces buscamos la que esta por default y la guardamos



            Dim instance As New Printing.PrinterSettings
            Dim impresosaPredt As String = instance.PrinterName
            'MsgBox("LA IMPRESORA A GUARDAR ES:" & impresosaPredt)

            txtnombreimpresora.Text = impresosaPredt

            cerrarconexion()
            conexionMysql.Open()
            Dim Sql2 As String
            Sql2 = "INSERT INTO `dwin`.`impresora` (`idimpresora`, `nombre_impresora`) VALUES ('1', '" & impresosaPredt & "');"
            Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            cmd2.ExecuteNonQuery()
            conexionMysql.Close()
            MsgBox("Se ha asignado por default la impresora que esta predeterminada en el sistema", MsgBoxStyle.Information, "CTRL+y")

            '            MsgBox("Hola esto es una prueba" & Chr(13) &
            '" de un textbox multilinea" 



        Else
            'en caso contrario se supone que ya hay impresora, solo la asignamos al label de configuracion de impresora

            txtnombreimpresora.Text = respuesta_nombre_impresora


        End If





    End Function

    Function obtener_nombre_impresora()
        Try

            Dim nombre_impresora
            conexionMysql.Open()
            Dim Sql111 As String
            Sql111 = "select * from impresora;"
            Dim cmd111 As New MySqlCommand(Sql111, conexionMysql)
            reader = cmd111.ExecuteReader()
            reader.Read()

            nombre_impresora = reader.GetString(1).ToString
            conexionMysql.Close()

            If nombre_impresora = "" Then
                MsgBox("No hay ninguna impresora seleccionada")
            End If
            Return nombre_impresora
        Catch ex As Exception
            cerrarconexion()
        End Try


    End Function

    Function tipo_corte_configuracion()

        Dim conta, tipo_corte As Integer

        conexionMysql.Open()
        Dim Sql As String
        Sql = "select count(*) as contador from tipo_corte;"
        Dim cmd As New MySqlCommand(Sql, conexionMysql)
        reader = cmd.ExecuteReader()
        reader.Read()
        conta = reader.GetString(0).ToString()

        conexionMysql.Close()

        'en caso de que el contador sea igual a cero, lo que significa que no existe aun ningun registro, insertamos 
        'los dos registros que deben de existir, que son por usuario y por tiempo.

        If conta = 0 Then

            conexionMysql.Open()
            Dim Sql2 As String
            Sql2 = "INSERT INTO `dwin`.`tipo_corte` (`idtipo_corte`, `tipo`, `estado`) VALUES ('1', 'USUARIO', '1');"
            Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            cmd2.ExecuteNonQuery()
            conexionMysql.Close()
            conexionMysql.Open()
            Dim Sql22 As String
            Sql22 = "INSERT INTO `dwin`.`tipo_corte` (`idtipo_corte`, `tipo`, `estado`) VALUES ('2', 'TIEMPO', '0');"
            Dim cmd22 As New MySqlCommand(Sql22, conexionMysql)
            cmd22.ExecuteNonQuery()
            conexionMysql.Close()

            tipo_corte = seleccion_tipo_corte_configuracion()

        Else
            'en caso contrario, significa que ya existen los dos registros , eso supone que ya se tiene que seleccionar
            'Y activar el radiobutton que corresponde a la seleccion.
            tipo_corte = seleccion_tipo_corte_configuracion()
            'MsgBox("se selecciona el tipo de configuracion")
        End If



    End Function


    Function seleccion_tipo_corte_configuracion()
        cerrarconexion()

        Dim id As Integer
        conexionMysql.Open()
        Dim Sql As String
        Sql = "select * from tipo_corte where estado = 1;"
        Dim cmd As New MySqlCommand(Sql, conexionMysql)
        reader = cmd.ExecuteReader()
        reader.Read()
        id = reader.GetString(0).ToString()

        conexionMysql.Close()


        If id = 1 Then
            rbusuario.Checked = True
            rbtiempo.Checked = False

        ElseIf id = 3 Then
            rbtiempo.Checked = True
            rbusuario.Checked = False

        End If
        Return id
    End Function

    Private Sub Button15_Click(sender As Object, e As EventArgs)
        buscarid()

    End Sub
    Function ucargartipousuario()
        'limpiar el combo para que no se duplique
        utxttipousuario.Items.Clear()
        Try



            Dim cantidadproveedor, i As Integer

            cerrarconexion()

            conexionMysql.Open()
            Dim Sql As String
            Sql = "select count(*)as contador from tipo_usuario;"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            reader = cmd.ExecuteReader()
            reader.Read()
            cantidadproveedor = reader.GetString(0).ToString()

            conexionMysql.Close()


            cerrarconexion()
            conexionMysql.Open()
            Dim Sql2 As String
            Sql2 = "select * from tipo_usuario;"
            Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            reader = cmd2.ExecuteReader()

            For i = 1 To cantidadproveedor

                reader.Read()

                utxttipousuario.Items.Add(reader.GetString(1).ToString())
            Next

            reader.Close()

            conexionMysql.Close()

        Catch ex As Exception

        End Try

    End Function
    Function limpiar()
        txtactividad.Text = ""
        txtcantidad.Text = ""

        txtcosto.Text = ""
        txttotal.Text = ""


    End Function
    Function buscaridp()
        If txtclavep.Text = "" Then
            'MsgBox("aqui no paso nada")
        Else
            'MsgBox("comenzamos a buscar")
            Try
                Dim cantidad As Integer

                ' respuesta = vbYes

                cerrarconexion()

                If reader.HasRows Then
                    reader.Close()

                End If

                Dim claveproveedor, clavetipoproducto As Integer

                cerrarconexion()


                'MsgBox(txtclavep.Text)

                'Try
                'MsgBox(txtclavep.Text)
                conexionMysql.Open()
                Dim Sql As String
                Sql = "select * from producto where idproducto='" & txtclavep.Text & "';"
                Dim cmd As New MySqlCommand(Sql, conexionMysql)
                reader = cmd.ExecuteReader()
                reader.Read()
                txtactividadp.Text = reader.GetString(1).ToString()
                txtcantidadp.Text = reader.GetString(2).ToString()
                txtcostop.Text = reader.GetString(3).ToString()
                txtprecioindividualp.Text = reader.GetString(4).ToString()
                txtpreciomayoreop.Text = reader.GetString(5).ToString()
                Try
                    claveproveedor = reader.GetString(6).ToString()
                    clavetipoproducto = reader.GetString(7).ToString()

                    reader.Close()


                    'MsgBox("actividad:" & txtactividad.Text)

                Catch ex As Exception
                    'MsgBox("hay problemas", MsgBoxStyle.Exclamation)
                    btninconsistencia.Visible = True
                    cerrarconexion()
                End Try


                conexionMysql.Close()




                '   MsgBox(clavetipoproducto)

                If reader.HasRows Then
                    reader.Close()

                End If



                '-------------cargamos el proveedor del producto.
                Try

                    Dim valor As String
                    cerrarconexion()

                    conexionMysql.Open()
                    Dim Sql3 As String
                    Sql3 = "select * from proveedor where idproveedor=" & claveproveedor & ";"
                    Dim cmd3 As New MySqlCommand(Sql3, conexionMysql)
                    reader = cmd3.ExecuteReader()
                    reader.Read()
                    valor = reader.GetString(1).ToString()

                    conexionMysql.Close()

                    txtproveedor.Text = valor



                    '-------------cargamos el tipodeproducto del producto.



                    cerrarconexion()

                Catch ex As Exception
                    txtproveedor.Text = "INDEFINIDO"
                    cerrarconexion()
                    btninconsistencia.Visible = True
                End Try


                Dim valortipopro As String



                'MsgBox("hahahahaha" & clavetipoproducto)
                Try


                    conexionMysql.Open()
                    Dim Sql33 As String
                    Sql33 = "select tipo from tipoproducto where idtipoproducto=" & clavetipoproducto & ";"
                    Dim cmd33 As New MySqlCommand(Sql33, conexionMysql)
                    reader = cmd33.ExecuteReader()
                    reader.Read()
                    valortipopro = reader.GetString(0).ToString()

                    conexionMysql.Close()


                    'MsgBox("hoooooooooooooo" & valortipopro)


                    txttipoproducto.Text = valortipopro

                Catch ex As Exception
                    txttipoproducto.Text = "INDEFINIDO"
                    cerrarconexion()
                    btninconsistencia.Visible = True
                End Try


                '----------------------------------------------

                '  obtenemos los dos precios de venta
                'conexionMysql.Open()
                'Dim Sql2 As String
                'Sql2 = "select * from tipo_costo where idproducto=" & txtclavep.Text & ";"
                'Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
                'reader = cmd2.ExecuteReader()
                'reader.Read()
                'txtprecioindividualp.Text = reader.GetString(1).ToString()
                'txtpreciomayoreop.Text = reader.GetString(2).ToString()
                'reader.Close()

                'conexionMysql.Close()



                'If cantidad = 1 Then
                '    MsgBox("Este es el ultimo producto existente, recuerda adquirir más", MsgBoxStyle.Information, "Sistema")
                'ElseIf cantidad = 0 Then
                '    respuesta = MsgBox("Ya no hay productos por vender." & vbCrLf & "Para mantener la integridad de la información, primero agrega mas productos", MsgBoxStyle.Exclamation, "Sistema")
                '    borrar()

                'End If

                ''en caso de que quede 1, si se vende, pero si queda 0, depende de la respuesta.

                'If respuesta = vbYes Then
                '    txtcantidad.Text = 1

                'Else
                '    txtactividad.Text = ""
                '    txtcosto.Text = ""
                '    txtcantidad.Text = ""


                'End If



                ''realizar operacion para obtener el total 

                'txttotal.Text = CDbl(txtcantidad.Text) * CDbl(txtcosto.Text)






            Catch ex As Exception
                'MsgBox("El producto no existe o no se a podido procesar", MsgBoxStyle.Exclamation, "Sistema")

                tipoingreso()
                cerrarconexion()


                Call limpiarp()


                'MsgBox("Hay detalles con el proceso", MsgBoxStyle.Information, "CTRL+y")

            End Try
        End If

    End Function
    Function cargarproveedor()

        'limpiar el combo para que no se duplique
        txtproveedor.Items.Clear()

        Try


            Dim cantidadproveedor, i As Integer
            cerrarconexion()

            conexionMysql.Open()
            Dim Sql As String
            Sql = "select count(*)as contador from proveedor;"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            reader = cmd.ExecuteReader()
            reader.Read()
            cantidadproveedor = reader.GetString(0).ToString()

            conexionMysql.Close()


            cerrarconexion()

            conexionMysql.Open()
            Dim Sql2 As String
            Sql2 = "select * from proveedor;"
            Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            reader = cmd2.ExecuteReader()

            For i = 1 To cantidadproveedor

                reader.Read()

                txtproveedor.Items.Add(reader.GetString(1).ToString())
            Next

            reader.Close()

            conexionMysql.Close()


        Catch ex As Exception

        End Try


    End Function
    Function cargartiposervicio()

        'limpiar el combo para que no se duplique
        txttipoproducto.Items.Clear()

        Try


            Dim cantidadtiposervicio, i As Integer
            cerrarconexion()

            conexionMysql.Open()
            Dim Sql As String
            Sql = "select count(*)as contador from tipoproducto;"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            reader = cmd.ExecuteReader()
            reader.Read()
            cantidadtiposervicio = reader.GetString(0).ToString()

            conexionMysql.Close()


            cerrarconexion()

            conexionMysql.Open()
            Dim Sql2 As String
            Sql2 = "select * from tipoproducto;"
            Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            reader = cmd2.ExecuteReader()

            For i = 1 To cantidadtiposervicio

                reader.Read()

                txttipoproducto.Items.Add(reader.GetString(1).ToString())
            Next

            reader.Close()

            conexionMysql.Close()


        Catch ex As Exception

        End Try


    End Function
    Function buscarid()
        If txtclave.Text = "" Or txtclave.Text = "0" Then
        Else

            Try
                Dim cantidad As Integer

                respuesta = vbYes


                cerrarconexion()


                conexionMysql.Open()
                Dim Sql As String
                Sql = "select * from producto where idproducto='" & txtclave.Text & "';"
                Dim cmd As New MySqlCommand(Sql, conexionMysql)
                reader = cmd.ExecuteReader()
                reader.Read()
                txtactividad.Text = reader.GetString(1).ToString()
                cantidad = reader.GetString(2).ToString()
                txtcosto.Text = reader.GetString(4).ToString()
                txtstock.Text = reader.GetString(2).ToString
                ''si encuentra el valor, llamamos al focus del boton.
                'Button17.Focus()

                reader.Close()

                conexionMysql.Close()


                '------------------------
                '-------COMENTADO 20-09-2020
                If cantidad = 1 Then
                    'MsgBox("Este es el ultimo producto existente, recuerda adquirir más", MsgBoxStyle.Information, "Sistema")
                    btninconsistencia.Visible = True
                    btninconsistencia.Text = "Ultimo producto existente"
                ElseIf cantidad = 0 Then
                    btninconsistencia.Visible = True
                    btninconsistencia.Text = "No existen productos"
                    ' respuesta = MsgBox("Ya no hay productos por vender." & vbCrLf & "Para mantener la integridad de la información, primero agrega mas productos", MsgBoxStyle.Exclamation, "Sistema")
                    ' borrar()

                End If
                '-------------------------
                '-------------------------

                'en caso de que quede 1, si se vende, pero si queda 0, depende de la respuesta.

                '----------------------------
                '--------COMENTARIO 20-09-2020
                If respuesta = vbYes Then
                    txtcantidad.Text = 1

                Else
                    txtactividad.Text = ""
                    txtcosto.Text = ""
                    txtcantidad.Text = ""

                End If
                '-------------------------------
                '-------------------------------








                'realizar operacion para obtener el total 

                txttotal.Text = CDbl(txtcantidad.Text) * CDbl(txtcosto.Text)


                '--------------------IMPORTANTE------------------------------
                'verificamos si la casilla de anexar directo esta activada, entonces, automaticamente llammos a la funcion
                'de agregar a la grilla.

                If chanexar.Checked = True And chpermitircantidad.Checked = False Then

                    Dim cantidad_total, cantidadbd As Integer

                    'cantidad total es la cantidad que se va a vender
                    'se le suma 1, porque es el producto que apenas se va anexar a la lista de venta
                    cantidad_total = comprobacion() + txtcantidad.Text


                    'cantidadbd, es la cantidad que existe en la BD del producto

                    cantidadbd = conteoclave()


                    If cantidad_total > cantidadbd Then
                        MsgBox("No hay productos suficientes, no se agregara este producto", MsgBoxStyle.Exclamation, "Sistema")
                        borrar()
                    Else
                        agregargrilla()

                    End If
                    'en caso de que esten activadas las dos, de permitir cantidad y anexar director entonces, que no haga nada, hasta que se cierre 
                    'la ventana de permitircantidad.
                ElseIf chanexar.Checked = True And chpermitircantidad.Checked = True Then

                    'no hace nada.
                    'solo mandamos a llamar a la ventana de cantidad.
                    '-------------------NUEVO SISTEMA
                    '-------------------------------------------- frcantidad.Show()



                End If



            Catch ex As Exception
                'MsgBox("El producto no existe o no se a podido procesar", MsgBoxStyle.Exclamation, "Sistema")

                ''If conexionMysql.State = ConnectionState.Open Then
                ''conexionMysql.Close()

                'End If

                Call limpiar()

            End Try
        End If

    End Function
    Private Sub txtclave_KeyDown(sender As Object, e As KeyEventArgs) Handles txtclave.KeyDown
        If e.KeyCode = Keys.F1 Then
            venta()
        ElseIf e.KeyCode = Keys.F2 Or e.KeyCode = Keys.Enter Then
            agregarproductogrilla()
        End If
    End Sub

    Private Sub txtclave_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtclave.KeyPress
        If e.KeyChar = Chr(13) Then
            buscarid()


        End If
        If e.KeyChar = Chr(3) Then
            MsgBox("tecla presionada")
        End If


    End Sub


    Private Sub txtcantidad_TextChanged(sender As Object, e As EventArgs) Handles txtcantidad.TextChanged
        Try
            txttotal.Text = CDbl(txtcantidad.Text) * CDbl(txtcosto.Text)

        Catch ex As Exception
            txttotal.Text = ""
        End Try
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        agregarproductogrilla()
    End Sub
    Function agregarproductogrilla()
        grilla.DefaultCellStyle.Font = New Font("Arial", 20)
        grilla.RowHeadersVisible = False




        'grilla.Columns(0).Width = 0
        grilla.AlternatingRowsDefaultCellStyle.BackColor = Color.SkyBlue



        If txtclave.Text = "" Or txtactividad.Text = "" Or txtcantidad.Text = "" Or txtcosto.Text = "" Or txttotal.Text = "" Then

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

                End If

            Catch ex As Exception

                MsgBox("No podemos procesar esta solicitud, Desbordamiento", MsgBoxStyle.Exclamation, "Sistema")
            End Try

        End If

    End Function
    Public Sub sagregargrilla()
        If stxtcantidad.Text = "" Or stxtprecio.Text = "" Or stxtnombre.Text = "" Or stxtclave.Text = "" Or stxttotalproducto.Text = "" Then

            MsgBox("No hay servicios que agregar", MsgBoxStyle.Information, "Sistema")

        Else

            Dim i As Integer = sgrilla.RowCount
            Dim gananciatotal As Double
            'txtcostoconproducto.Text = Math.Round(f, 2)
            gananciatotal = CDbl(stxtgananciaproducto.Text) * CDbl(stxtcantidad.Text)
            gananciatotal = Math.Round(gananciatotal, 2)
            sgrilla.Rows.Add(i, stxtclave.Text, stxtnombre.Text, stxtcantidad.Text, stxtprecio.Text, txtcostoproductoserigrafia.Text, stxtgananciaproducto.Text, gananciatotal, stxtprecio.Text, stxttotalproducto.Text, stxtdescripcion.Text)
            ' sgrilla.Columns(1).Width = 350


            ssumatorio()

            sborrar()

            stxtclave.Focus()
        End If
    End Sub
    Public Sub agregargrilla()
        If txtcantidad.Text = "" Or txtcosto.Text = "" Or txtactividad.Text = "" Or txtclave.Text = "" Or txttotal.Text = "" Then

            MsgBox("No hay servicios que agregar", MsgBoxStyle.Information, "Sistema")

        Else

            Dim i As Integer = grilla.RowCount

            grilla.Rows.Add(i, txtactividad.Text, txtcantidad.Text, txtcosto.Text, txttotal.Text, txtclave.Text, rtobservaciones.Text)

            grilla.Columns(1).Width = 700
            grilla.Columns(0).Width = 50
            grilla.Columns(2).Width = 60
            grilla.Columns(3).Width = 60
            grilla.Columns(4).Width = 70
            grilla.Columns(5).Width = 140
            grilla.Columns(6).Width = 140


            sumatorio()

            borrar()

            txtclave.Focus()
        End If
    End Sub
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
    Function sconteoclave() As Integer
        If conexionMysql.State = ConnectionState.Open Then
            conexionMysql.Close()

        End If
        Dim cantidad As Integer

        cerrarconexion()
        If stxtclave.Text <> "0" Then

            cerrarconexion()
            conexionMysql.Open()
            Dim Sql As String
            Sql = "select cantidad from producto where idproducto='" & stxtclave.Text & "';"
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

    Function scomprobacion() As Integer
        'comprobar si hay la cantidad solicitada
        Dim j, suma, cantidad As Integer
        suma = 0
        cantidad = 0
        Dim i As Integer = sgrilla.RowCount
        Dim claveproducto As String



        For j = 0 To i - 2
            'MsgBox("valosr de j:" & j)
            'a = venta.grillaventa.Item(j, 3).Value.ToString()
            '    actividad = grilla.Rows(j).Cells(1).Value 'descripcion
            cantidad = sgrilla.Rows(j).Cells(3).Value 'cantidad
            claveproducto = sgrilla.Rows(j).Cells(1).Value 'clave


            ' MsgBox(claveproducto)



            If claveproducto = stxtclave.Text Then
                suma = suma + cantidad
                'MsgBox("hay del producto:" & claveproducto & ":" & suma)
            End If


        Next
        Return suma
    End Function

    Public Sub borrar()
        txtactividad.Text = ""
        txtcantidad.Text = ""
        txtcosto.Text = ""
        txttotal.Text = ""
        txtclave.Text = ""
        txtstock.Text = ""




    End Sub
    Public Sub borrarp()
        txtactividadp.Text = ""
        txtcantidadp.Text = ""
        txtcostop.Text = ""
        txtprecioindividualp.Text = ""
        txtpreciomayoreop.Text = ""
        txtclavep.Text = ""
    End Sub

    Public Sub ssumatorio()
        Dim i As Integer = sgrilla.RowCount

        Dim j As Integer
        Dim sumacon, sumasin, cantidad_productos, sumagananciatotal As Double
        Dim a, b, c, d As String
        'suma de valores
        For j = 0 To i - 2
            'MsgBox("valosr de j:" & j)
            'a = venta.grillaventa.Item(j, 3).Value.ToString()
            a = sgrilla.Rows(j).Cells(8).Value 'con cotizador
            c = sgrilla.Rows(j).Cells(9).Value 'sin cotizador
            d = sgrilla.Rows(j).Cells(7).Value 'totalganancia

            b = sgrilla.Rows(j).Cells(3).Value
            cantidad_productos = cantidad_productos + b
            sumacon = sumacon + a
            sumasin = sumasin + c
            sumagananciatotal = sumagananciatotal + d

            'MsgBox(a)
        Next
        stxtpagarcon.Text = sumacon
        stxtpagarsin.Text = sumasin
        stxttotal.Text = sumasin
        stxtgananciatotalproductos.Text = sumagananciatotal

        'el valor siguiente es como funcionaba anteriormente
        '        stxttotal.Text = suma
        stxttotalproductos.Text = cantidad_productos
    End Sub
    Public Sub aplicarcotizacion()

        If setxtfoliocotizador.Text = "" Or setxtfoliocotizador.Text = 0 Then
            chaplicarcotizador.CheckState = False

            MsgBox("No esta en funcion el cotizador, primer realiza la cotización del servicio", MsgBoxStyle.Information, "CTRL+y")

        Else


            Dim i As Integer = sgrilla.RowCount

            Dim j As Integer
            Dim sumacon, sumasin, cantidad_productos, sumagananciatotal As Double
            Dim a, b As String
            Dim c, d, e As Double
            'suma de valores
            For j = 0 To i - 2
                'MsgBox("valosr de j:" & j)
                'a = venta.grillaventa.Item(j, 3).Value.ToString()
                a = sgrilla.Rows(j).Cells(4).Value 'precio del producto
                'c = sgrilla.Rows(j).Cells(9).Value 'sin cotizador
                e = sgrilla.Rows(j).Cells(3).Value 'cantidaddeproductos

                ' MsgBox(a)
                ' MsgBox(e)

                'b = sgrilla.Rows(j).Cells(3).Value
                b = CDbl(a) + CDbl(setxtprecioconproducto.Text)
                'MsgBox("la suma de precioproducto + cotizador es:" + b)

                d = CDbl(b) * CDbl(e)
                ' MsgBox("la multiplicacion del valor resultante con la cantidad de productos es:" + d)
                sumacon = CDbl(sumacon) + CDbl(d)

                'MsgBox("ahorita sumamos:" + sumacon)

                'sumacon = sumacon + a
                'sumasin = sumasin + c
                'sumagananciatotal = sumagananciatotal + d
                sgrilla.Rows(j).Cells(8).Value = b
                sgrilla.Rows(j).Cells(9).Value = d
                'MsgBox(a)
            Next
            stxtpagarcon.Text = sumacon
            stxttotal.Text = sumacon
            'stxtpagarsin.Text = sumasin
            'stxtgananciatotalproductos.Text = sumagananciatotal

            'el valor siguiente es como funcionaba anteriormente
            '        stxttotal.Text = suma
            'stxttotalproductos.Text = cantidad_productos
        End If

    End Sub
    Public Sub desaplicarcotizacion()

        If setxtfoliocotizador.Text = "" Or setxtfoliocotizador.Text = 0 Then
            MsgBox("No esta en funcion el cotizador, primera realiza la cotización del servicio", MsgBoxStyle.Information, "CTRL+y")

        Else


            Dim i As Integer = sgrilla.RowCount

            Dim j As Integer
            Dim sumacon, sumasin, cantidad_productos, sumagananciatotal As Double
            Dim a, b As String
            Dim c, d, e As Double
            'suma de valores
            For j = 0 To i - 2
                'MsgBox("valosr de j:" & j)
                'a = venta.grillaventa.Item(j, 3).Value.ToString()
                a = sgrilla.Rows(j).Cells(4).Value 'precio del producto
                'c = sgrilla.Rows(j).Cells(9).Value 'sin cotizador
                e = sgrilla.Rows(j).Cells(3).Value 'cantidaddeproductos

                ' MsgBox(a)
                ' MsgBox(e)

                'b = sgrilla.Rows(j).Cells(3).Value
                'b = CDbl(a) + CDbl(setxtprecioconproducto.Text)
                'MsgBox("la suma de precioproducto + cotizador es:" + b)

                d = CDbl(a) * CDbl(e)
                ' MsgBox("la multiplicacion del valor resultante con la cantidad de productos es:" + d)
                sumacon = CDbl(sumacon) + CDbl(d)

                'MsgBox("ahorita sumamos:" + sumacon)

                'sumacon = sumacon + a
                'sumasin = sumasin + c
                'sumagananciatotal = sumagananciatotal + d
                'sgrilla.Rows(j).Cells(8).Value = d
                sgrilla.Rows(j).Cells(8).Value = a
                sgrilla.Rows(j).Cells(9).Value = d
                'MsgBox(a)
            Next
            stxtpagarcon.Text = sumacon
            stxttotal.Text = sumacon
            'stxtpagarsin.Text = sumasin
            'stxtgananciatotalproductos.Text = sumagananciatotal

            'el valor siguiente es como funcionaba anteriormente
            '        stxttotal.Text = suma
            'stxttotalproductos.Text = cantidad_productos
        End If

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
        txttotalpagar.Text = suma
        txtunidades.Text = cantidad_productos
    End Sub
    Function cargardatosnotaventa()

        conexionMysql.Open()


        Dim command As New MySqlCommand("select venta.idventa,venta.total,venta.fecha,venta.hora,concat(cliente.nombre,cliente.ap,cliente.am), ventaind.idproducto,ventaind.actividad,ventaind.cantidad,ventaind.costo, (ventaind.cantidad * ventaind.costo)as multi  from venta,ventaind,cliente where venta.idventa = ventaind.idventa and venta.idventa='" & lbfolio.Text & "' and venta.idcliente=cliente.idcliente;", conexionMysql)
        'Dim da As New MySqlDataAdapter("select * from productos", conexionMysql)

        'Dim command As New MySqlCommand("select * from usuario where idusuario=39;", conexionMysql)


        Dim adapter As New MySqlDataAdapter
        Dim dt As New DataTable
        adapter.SelectCommand = command
        adapter.Fill(dt)
        DataGridView1.DataSource = dt
        adapter.Dispose()
        command.Dispose()
        conexionMysql.Close()

    End Function
    Function cargardatosrptcortedia()

        Dim fecha As String

        fecha = calendario.SelectionRange.Start.ToString("yyyy/MM/dd")

        conexionMysql.Open()


        Dim command As New MySqlCommand("select ventaind.actividad, ventaind.cantidad, ventaind.costo,(ventaind.cantidad * ventaind.costo) as Total, ventaind.idproducto, venta.hora from ventaind, venta where ventaind.idventa = venta.idventa and fecha='" & fecha & "';", conexionMysql)

        Dim adapter As New MySqlDataAdapter
        Dim dt As New DataTable
        adapter.SelectCommand = command
        adapter.Fill(dt)
        DataGridView1.DataSource = dt
        adapter.Dispose()
        command.Dispose()
        conexionMysql.Close()

    End Function

    Function cargardatosnotaventa2()


        conexionMysql.Open()


        Dim command As New MySqlCommand("select venta.idventa,venta.total,venta.fecha,venta.hora,concat(cliente.nombre,cliente.ap,cliente.am), ventaind.idproducto,ventaind.actividad,ventaind.cantidad,ventaind.costo, (ventaind.cantidad * ventaind.costo)as multi  from venta,ventaind,cliente where venta.idventa = ventaind.idventa and venta.idventa='" & rptid.Text & "' and venta.idcliente=cliente.idcliente;", conexionMysql)

        Dim adapter As New MySqlDataAdapter
        Dim dt As New DataTable
        adapter.SelectCommand = command
        adapter.Fill(dt)
        DataGridView1.DataSource = dt
        adapter.Dispose()
        command.Dispose()
        conexionMysql.Close()

    End Function
    Function comprobarcaja()
        Dim registrar As Boolean
        Dim idestado, idmaximo, cantidad As Integer

        '---------------------------
        'PRIMERO COMPROBAMOS QUE EXISTE UNA CAJA, PRIMER REGISTRO
        '------------------------------
        Try
            cerrarconexion()

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
            'MsgBox("primer")
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

                ' MsgBox("segundo")
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

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click




        Dim estadocaja As Integer


        estadocaja = comprobarcaja()

        If estadocaja = 0 Then

            obtenerfolio()
            venta()
            ' RPT1.Show()
        Else
            MsgBox("No existe ninguna caja abierta", MsgBoxStyle.Information, "CTRL+y")
        End If

    End Sub
    Function venta()


        'Try

        If txttotalpagar.Text = "0" Or txttotalpagar.Text = "" Then
            MsgBox("No hay ventas que realizar", MsgBoxStyle.Information, "Sistema")
            txttotalpagar.Text = ""
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
            'consultamos el id del cliente para obtener un registro de quien es al que se le esta vendiendo
            Sql32 = "select idusuario from usuario where usuario= '" & usuarioactual & "';"
            Dim cmd32 As New MySqlCommand(Sql32, conexionMysql)
            reader = cmd32.ExecuteReader()
            reader.Read()
            idusuario = reader.GetString(0).ToString()
            '-------------------------------------------------
            '----------datos que se van al reporte
            indexidusuario = idcliente
            indexidventa = lbfolio.Text
            conexionMysql.Close()
            '----------------------------------------
            '--------------------------------------------------------------------------
            cerrarconexion()

            'asignamos a la variable txtpagar el valor a pagar, para que el cambio pueda usarlo y se pueda calcular.
            txtpagar = CDbl(txttotalpagar.Text)
            'Dim pagacon, cambio As String

            Try

                If chcalcularcambio.Checked = True Then

                    '-------------------NUEVO SISTEMA

                    frcambio.ShowDialog()
                    frcambio.txtpaga.Focus()

                    'obtenemos los valores de regreso


                Else
                    lbpagacon.Text = "0"
                    lbcambio.Text = "0"



                End If
            Catch ex As Exception

                lbpagacon.Text = "0"
                lbcambio.Text = "0"
                cerrarconexion()

            End Try



            Dim tipopago As Integer

            Try

                '---------------------------------
                '--------OBTENEMOS EL ID DEL TIPO DE PAGO DE LA VENTA
                conexionMysql.Open()
                Dim Sql322 As String
                'consultamos el id del cliente para obtener un registro de quien es al que se le esta vendiendo
                Sql322 = "SELECT idtipo_pago from tipo_pago where tipo='" & cbformadepago.Text & "';"
                Dim cmd322 As New MySqlCommand(Sql322, conexionMysql)
                reader = cmd322.ExecuteReader()
                reader.Read()
                tipopago = reader.GetString(0).ToString()
                '-------------------------------------------------
                '----------datos que se van al reporte

                conexionMysql.Close()


            Catch ex As Exception

            End Try





            cerrarconexion()

            conexionMysql.Open()
            Dim Sql As String
            Sql = "INSERT INTO venta (idventa, cantidad, total, fecha, hora, idcliente, idusuario,tipoventa,pagacon,cambio,idtipo_pago) VALUES (" & lbfolio.Text & "," & txtunidades.Text & ", " & CDbl(txttotalpagar.Text) & ", '" & fecha & "','" & hora & "', " & idcliente & ", " & idusuario & ",'1','" & lbpagacon.Text & "', '" & lbcambio.Text & "'," & tipopago & ");"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            cmd.ExecuteNonQuery()
            conexionMysql.Close()
            txtactividad.Text = ""
            txtcosto.Text = ""
            txtpagar = CDbl(txttotalpagar.Text)
            rtobservaciones.Text = ""
            'txttotalpagar.Text = ""
            conexionMysql.Close()


            '------------------ FIN insertar reginstro en tabla venta ---------------------------------------


            '------------------ insertar reginstro en tabla ventaIND ---------------------------------------
            Dim i As Integer = grilla.RowCount
            Dim j As Integer
            Dim actividad As String
            Dim cantidad, costo, idventa As Double
            Dim idproducto, observaciones As String

            conexionMysql.Open()

            'suma de valores
            For j = 0 To i - 2
                'MsgBox("valosr de j:" & j)
                'a = venta.grillaventa.Item(j, 3).Value.ToString()
                actividad = grilla.Rows(j).Cells(1).Value 'descripcion
                cantidad = grilla.Rows(j).Cells(2).Value 'cantidad
                costo = grilla.Rows(j).Cells(3).Value 'costo
                idproducto = grilla.Rows(j).Cells(5).Value
                observaciones = grilla.Rows(j).Cells(6).Value
                cerrarconexion()
                conexionMysql.Open()

                'MsgBox("el producto es:" & actividad)

                Dim Sql2 As String
                Sql2 = "INSERT INTO ventaind (actividad, cantidad, costo, idventa,idproducto,descripcion) VALUES ('" & actividad & "'," & cantidad & "," & costo & "," & lbfolio.Text & ",'" & idproducto & "','" & observaciones & "');"
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




            ' End If


            txtcliente.Text = "USUARIO"
            listaclientes.Visible = False
            If chimpresionticket.Checked = True Then
                'impresionticket()

                'vamos a trabajar con el ticket

                imprimir()






            End If
            If chimpresion.Checked = True Then
                '//////////////////////////////////////////////////////
                ' frx.Show()
                'cargamos el formulario 2, temporalmente para ver si funcionan los reportes.
                ''    Form2.TextBox1.Text = lbfolio.Text
                'Dim newformulario As New frnotaventa
                'aqui le cambien por el formulario de prueba, para coregir
                'el problema de los reportes.
                'newformulario.Show()
                'cagamos los datos a la nota de venta primeroa



                'informe1.Show()





                'este codigo si funcionaba
                cargardatosnotaventa()
                FRNOTAVENTA.ShowDialog()
                'imprimirnotaventa()

            End If

            'una vez guardada la venta, se obtiene un nuevo folio para la proxima venta
            obtenerfolio()





            '------------------------------------------------------------------------
            'al finalizar se limpia la grilla y las cajas de texto
            txttotalpagar.Text = ""
            txtunidades.Text = ""
            grilla.Rows.Clear()
            txttotalpagar.Text = ""

            'llamamos para obtener un nuevo folio
            txtclave.Focus()


        End If

        '------------------ FIN insertar reginstro en tabla ventaIND ---------------------------------------
        'Catch ex As Exception
        '    comprobartipoingreso()
        '    MsgBox(ex.Message)
        'End Try

    End Function
    Dim txtetiqueta1, txtetiqueta2, txtetiqueta As String
    Private Sub imprimir()

        'consultamos a la BD la impresora seleccionada por default
        Dim impresora As String
        Try

            conexionMysql.Open()
            Dim Sql1 As String
            Sql1 = "select * from impresora;"
            Dim cmd1 As New MySqlCommand(Sql1, conexionMysql)
            reader = cmd1.ExecuteReader()
            reader.Read()
            impresora = reader.GetString(1).ToString()
            conexionMysql.Close()
        Catch ex As Exception
            MsgBox("No hay una impresora seleccionada", MsgBoxStyle.Information, "Sistema")
        End Try



        txtetiqueta1 = " prueba de impresión"
        txtetiqueta2 = " Nº : " & lbfolio.Text
        txtetiqueta = " De : " & "$" & txttotalpagar.Text &
        Chr(10) & " " & "12/12/!2"
        Try
            Dim PrintDialog1 As New PrintDialog
            PrintDialog1.Document = PrintDocument1
            PrintDialog1.PrinterSettings.PrinterName = impresora
            If PrintDocument1.PrinterSettings.IsValid Then
                PrintDocument1.Print() 'Imprime texto 
            Else
                MsgBox("Impresora invalida", MsgBoxStyle.Exclamation, "CTRL+y")
                'MessageBox.Show("La impresora no es valida")
            End If
            '--------------------------------------------------- 
        Catch ex As Exception
            MsgBox("Hay problemas con la impresion", MsgBoxStyle.Exclamation, "CTRL+y")

            'MessageBox.Show("Hay un problema de impresión",
            ex.ToString()
        End Try

    End Sub
    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        'e.Graphics.DrawString(txtetiqueta1, New Font("verdana", 11, FontStyle.Bold), New SolidBrush(Color.Black), 1, 9)
        'e.Graphics.DrawString(txtetiqueta2, New Font("verdana", 9, FontStyle.Bold), New SolidBrush(Color.Black), 1, 28)
        'e.Graphics.DrawString(txtetiqueta, New Font("verdana", 13, FontStyle.Bold), New SolidBrush(Color.Black), 1, 57)
        'traemos la información del ticket, como encabezado, datos de la empresa etc.
        Dim saludo, ticketnombre, ticketcoloniaciudad, tickettelefono, ticketgiro, p1, p2, p3, p4, comentario As String
        Dim callenumero, cp, estado, whatsapp, correo, rfc As String
        Dim x, y, tfuente, tfuente2, tfuente3 As Integer
        Try


            conexionMysql.Open()
            Dim Sql1 As String
            Sql1 = "select * from datos_empresa;"
            Dim cmd1 As New MySqlCommand(Sql1, conexionMysql)
            reader = cmd1.ExecuteReader()
            reader.Read()
            ticketnombre = reader.GetString(1).ToString()
            callenumero = reader.GetString(2).ToString()
            ticketcoloniaciudad = reader.GetString(3).ToString()
            cp = reader.GetString(4).ToString()
            estado = reader.GetString(5).ToString()
            tickettelefono = reader.GetString(6).ToString()
            whatsapp = reader.GetString(7).ToString()
            correo = reader.GetString(8).ToString()
            'ctxtfacebook.Text = reader.GetString(9).ToString()
            'ctxtsitio.Text = reader.GetString(10).ToString()
            'ctxtencargado.Text = reader.GetString(11).ToString()
            'ctxthorario.Text = reader.GetString(12).ToString()
            ticketgiro = reader.GetString(13).ToString()
            saludo = reader.GetString(24).ToString()
            'p1 = reader.GetString(14).ToString()
            'P2 = reader.GetString(15).ToString()
            'P3 = reader.GetString(16).ToString()
            'p4 = reader.GetString(17).ToString()
            rfc = reader.GetString(22).ToString()

            conexionMysql.Close()

        Catch ex As Exception

        End Try

        tfuente = 10 '7
        tfuente2 = 12
        tfuente3 = 10
        p1 = 10 'posicion de X
        x = 5
        y = 125
        Dim ii, incremento As Integer
        incremento = 14
        Dim yy(20) As Integer
        For ii = 0 To 20
            y = y + incremento
            yy(ii) = y
        Next



        Try
            ' La fuente a usar
            Dim prFont As New Font("Arial", 15, FontStyle.Bold)
            'POSICION DEL LOGO
            ' la posición superior
            e.Graphics.DrawImage(pblogoticket.Image, 50, 20, 110, 110)


            'imprimir el titutlo del ticket



            prFont = New Font("Arial", tfuente2, FontStyle.Bold)
            e.Graphics.DrawString(ticketnombre, prFont, Brushes.Black, x, yy(0))
            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString(ticketgiro, prFont, Brushes.Black, x, yy(2))
            'IMPRESION DE LOGOTIPO,
            'prFont = New Font("Arial", tfuente, FontStyle.Bold)
            'e.Graphics.DrawString(ticketgiro, prFont, Brushes.Black, x, yy(2))


            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString(callenumero, prFont, Brushes.Black, x, yy(3))

            'imprimir el titutlo del ticket
            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString(ticketcoloniaciudad, prFont, Brushes.Black, x, yy(4))
            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString("CP:" & cp, prFont, Brushes.Black, x, yy(5))
            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString("TEL:" & tickettelefono, prFont, Brushes.Black, x, yy(6))
            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString("RFC:" & rfc, prFont, Brushes.Black, x, yy(7))
            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString("==================================", prFont, Brushes.Black, x, yy(8))

            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString("ATENDIO:" & usuarioactual, prFont, Brushes.Black, x, yy(9))

            'imprimir el titutlo del ticket
            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString("CLIENTE:" & txtcliente.Text, prFont, Brushes.Black, x, yy(10))
            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString("FECHA:" & Date.Now, prFont, Brushes.Black, x, yy(11))
            prFont = New Font("Arial", tfuente2, FontStyle.Bold)
            e.Graphics.DrawString("FOLIO:" & lbfolio.Text, prFont, Brushes.Black, x, yy(12))
            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString("==================================", prFont, Brushes.Black, x, yy(13))

            'imprimir el titutlo del ticket

            prFont = New Font("Arial", tfuente3, FontStyle.Bold)
            e.Graphics.DrawString("ARTICULO", prFont, Brushes.Black, x, yy(14))
            prFont = New Font("Arial", tfuente3, FontStyle.Bold)
            e.Graphics.DrawString("ID------PRECIO------CANTIDAD----TOTAL", prFont, Brushes.Black, x, yy(15))

            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString("==================================", prFont, Brushes.Black, x, yy(16))



            'aqui es donde tenemos que leer todos los datos de la grilla llamada "grilla"

            Dim i As Integer = grilla.RowCount
            Dim t1, t2, t3, t4, t5 As Integer
            Dim actividad As String
            Dim cantidad, costo, idventa As Double
            Dim idproducto As String

            t1 = yy(17)
            t2 = yy(18)
            t3 = yy(19)
            t4 = 40

            'suma de valores
            For j = 0 To i - 2
                'MsgBox("valosr de j:" & j)
                'a = venta.grillaventa.Item(j, 3).Value.ToString()
                actividad = grilla.Rows(j).Cells(1).Value 'descripcion
                cantidad = grilla.Rows(j).Cells(2).Value 'cantidad
                costo = grilla.Rows(j).Cells(3).Value 'costo
                idproducto = grilla.Rows(j).Cells(5).Value
                comentario = grilla.Rows(j).Cells(6).Value
                'cerrarconexion()
                'conexionMysql.Open()

                'MsgBox("el producto es:" & actividad)

                'Dim Sql2 As String
                'Sql2 = "INSERT INTO ventaind (actividad, cantidad, costo, idventa,idproducto) VALUES ('" & actividad & "'," & cantidad & "," & costo & "," & lbfolio.Text & ",'" & idproducto & "');"
                'Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
                'cmd2.ExecuteNonQuery()
                'conexionMysql.Close()

                prFont = New Font("Arial", tfuente3, FontStyle.Bold)
                e.Graphics.DrawString(actividad, prFont, Brushes.Black, x, t1)

                prFont = New Font("Arial", tfuente3, FontStyle.Bold)
                e.Graphics.DrawString(idproducto & "-----$" & costo & "-----" & cantidad & "-----$" & (CDbl(costo) * CDbl(cantidad)), prFont, Brushes.Black, x, t2)
                prFont = New Font("Arial", tfuente3, FontStyle.Bold)
                e.Graphics.DrawString(comentario, prFont, Brushes.Black, x, t3)


                'prFont = New Font("Arial", 10, FontStyle.Bold)
                'e.Graphics.DrawString(cantidad & "-- $" & (CDbl(costo) * CDbl(cantidad)), prFont, Brushes.Black, 0, t3)

                t1 = t1 + (incremento * 3.2)
                t2 = t2 + (incremento * 3.2)
                t3 = t3 + (incremento * 3.2)

            Next

            t1 = t1 - (incremento * 2)
            t2 = t2 - (incremento * 2)
            t3 = t3 - (incremento * 2)


            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString("==================================", prFont, Brushes.Black, 0, t3)

            '----------------AQUI SE IMPRIME EL TOTAL A PAGAR

            prFont = New Font("Arial", tfuente3, FontStyle.Bold)
            e.Graphics.DrawString("   Total---->$" & txttotalpagar.Text, prFont, Brushes.Black, x, t3 + incremento)
            prFont = New Font("Arial", tfuente3, FontStyle.Bold)
            e.Graphics.DrawString("Efectivo---->$" & lbpagacon.Text, prFont, Brushes.Black, x, t3 + (incremento * 2))
            prFont = New Font("Arial", tfuente3, FontStyle.Bold)
            e.Graphics.DrawString("  Cambio---->$" & lbcambio.Text, prFont, Brushes.Black, x, t3 + (incremento * 3))

            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString("==================================", prFont, Brushes.Black, x, t3 + (incremento * 4))
            prFont = New Font("Arial", tfuente3, FontStyle.Bold)
            e.Graphics.DrawString(saludo, prFont, Brushes.Black, x, t3 + (incremento * 5))
            'prFont = New Font("Arial", tfuente3, FontStyle.Bold)
            'e.Graphics.DrawString("CTRL+y", prFont, Brushes.Black, 10, t2 + 60)

            ''imprimimos la fecha y hora
            'prFont = New Font("Arial", 10, FontStyle.Regular)
            'e.Graphics.DrawString(Date.Now.ToShortDateString.ToString & " " &
            '                Date.Now.ToShortTimeString.ToString, prFont, Brushes.Black, 15, 385)

            ''imprimimos el nombre del cliente
            'prFont = New Font("Arial", 25, FontStyle.Bold)
            'e.Graphics.DrawString("Nombre del Cliente" & txtcliente.Text, prFont, Brushes.Black, 50, 250)

            ''imprimimos la referencia del pedido
            'e.Graphics.DrawString("Referencia", prFont, Brushes.Black, 50, 520)
            'prFont = New Font("Arial", 18, FontStyle.Bold)
            'e.Graphics.DrawString("Nombre de la Referencia", prFont, Brushes.Black, 50, 555)

            ''imprimimos Pedido Ondupack y Pedido del cliente
            'prFont = New Font("Arial", 22, FontStyle.Regular)
            'e.Graphics.DrawString("Pedido", prFont, Brushes.Black, 50, 660)
            'e.Graphics.DrawString("Palets", prFont, Brushes.Black, 250, 660)

            'prFont = New Font("Arial", 24, FontStyle.Regular)
            'e.Graphics.DrawString("19875", prFont, Brushes.Black, 50, 700)
            'e.Graphics.DrawString("44", prFont, Brushes.Black, 250, 700)

            ''imprimimos Cajas X Palet y Cajas x Paquete
            'prFont = New Font("Arial", 22, FontStyle.Regular)
            'e.Graphics.DrawString("Cajas x Palet", prFont, Brushes.Black, 50, 760)
            'e.Graphics.DrawString("Cajas x Paquete", prFont, Brushes.Black, 250, 760)

            'prFont = New Font("Arial", 24, FontStyle.Regular)
            'e.Graphics.DrawString("500", prFont, Brushes.Black, 50, 800)
            'e.Graphics.DrawString("32", prFont, Brushes.Black, 250, 800)

            ''imprimimos el numero del Palet
            'prFont = New Font("Arial", 24, FontStyle.Regular)
            'e.Graphics.DrawString("Número del Palet     45", prFont, Brushes.Black, 50, 880)
            ''indicamos que hemos llegado al final de la pagina
            'e.HasMorePages = False

        Catch ex As Exception
            MessageBox.Show("ERROR: " & ex.Message, "Administrador",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Function imprimirnotaventa()
    '    Dim dt As New DataTable

    '    With dt

    '        .Columns.Add("idventa")
    '        .Columns.Add("total")
    '        .Columns.Add("fecha")
    '        .Columns.Add("hora")
    '        .Columns.Add("cliente")
    '        .Columns.Add("idproducto")
    '        .Columns.Add("actividad")
    '        .Columns.Add("cantidad")
    '        .Columns.Add("costo")
    '        .Columns.Add("totalpro")

    '    End With

    '    For Each row As DataGridViewRow In DataGridView1.Rows

    '        dt.Rows.Add(row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(4).Value, row.Cells(5).Value, row.Cells(6).Value, row.Cells(7).Value, row.Cells(8).Value, row.Cells(9).Value)

    '    Next


    '    ' FRNOTAVENTA.ReportViewer1.LocalReport.DataSources.Item(0).Value = dt

    '    FRNOTAVENTA.ShowDialog()

    '    FRNOTAVENTA.Dispose()

    'End Function
    Function imprimirnotaventa2()
        Dim dt As New DataTable

        With dt

            .Columns.Add("idventa")

            .Columns.Add("total")
            .Columns.Add("fecha")
            .Columns.Add("hora")
            .Columns.Add("cliente")
            .Columns.Add("idproducto")
            .Columns.Add("actividad")
            .Columns.Add("cantidad")
            .Columns.Add("costo")
            .Columns.Add("totalpro")

        End With

        For Each row As DataGridViewRow In DataGridView1.Rows

            dt.Rows.Add(row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(4).Value, row.Cells(5).Value, row.Cells(6).Value, row.Cells(7).Value, row.Cells(8).Value, row.Cells(9).Value)

        Next


        ' RPTnotaventareimpresion.ReportViewer1.LocalReport.DataSources.Item(0).Value = dt

        'RPTnotaventareimpresion.ShowDialog()

        'RPTnotaventareimpresion.Dispose()

    End Function
    Function imprimircortedia()
        Dim dt As New DataTable

        With dt

            .Columns.Add("activida")

            .Columns.Add("cantidad")
            .Columns.Add("costo")
            .Columns.Add("total")
            .Columns.Add("idproducto")
            .Columns.Add("hora")

        End With

        For Each row As DataGridViewRow In DataGridView1.Rows

            dt.Rows.Add(row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(4).Value, row.Cells(5).Value)

        Next


        ' FRMcortedia.ReportViewer1.LocalReport.DataSources.Item(0).Value = dt

        ' FRMcortedia.ShowDialog()

        ' FRMcortedia.Dispose()

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
    Function inserciondedatosiniciales()
        Try


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
                    'MsgBox("USUARIO CREADO CORRECTAMENTE", MsgBoxStyle.Information, "Sistema")
                    conexionMysql.Close()
                    cerrarconexion()

                    cerrarconexion()
                    conexionMysql.Open()
                    Dim Sql3 As String
                    Sql3 = "INSERT INTO `dwin`.`tipo_usuario` (`tipo_usuario`, `tipo`) VALUES (2, 'USUARIO');"
                    Dim cmd3 As New MySqlCommand(Sql3, conexionMysql)
                    cmd3.ExecuteNonQuery()
                    conexionMysql.Close()

                    conexionMysql.Open()
                    Dim Sql4 As String
                    Sql4 = "INSERT INTO `dwin`.`impresora` (`idimpresora`, `nombre_impresora`) VALUES ('1', 'impresora');"
                    Dim cmd4 As New MySqlCommand(Sql4, conexionMysql)
                    cmd4.ExecuteNonQuery()
                    conexionMysql.Close()

                    'llamar a la funcion limpiar, para limpiar las cajas cada vez que se agrege una nueva compra.
                    '  MsgBox("Registro guardado correctamente", MsgBoxStyle.Information, "Sistema")
                    conexionMysql.Close()

                    conexionMysql.Open()
                    Dim Sql As String
                    Sql = "INSERT INTO usuario (usuario, nombre, ap, am, telefono, correo, direccion, tipo_usuario,pclientes,pcompras,pproductos,pcorte,pusuarios,pproveedores,preportes,pconfiguracion) VALUES ('root', 'root', 'root', 'root', 'root', 'root', 'root', 1,1,1,1,1,1,1,1,1);"
                    Dim cmd As New MySqlCommand(Sql, conexionMysql)
                    cmd.ExecuteNonQuery()
                    conexionMysql.Close()
                    'llamar a la funcion limpiar, para limpiar las cajas cada vez que se agrege una nueva compra.
                    'MsgBox("Registro guardado correctamente", MsgBoxStyle.Information, "Sistema")
                    conexionMysql.Close()


                    cerrarconexion()
                    conexionMysql.Open()
                    Dim Sql44 As String
                    Sql44 = "INSERT INTO `dwin`.`CLIENTE` (`idcliente`, `nombre`, `ap`, `am`, `rfc`, `direccion`, `telefono`, `correo`) VALUES ('1', 'USUARIO', 'USUARIO', 'USUARIO', '000', '000', '000', '000');"
                    Dim cmd44 As New MySqlCommand(Sql44, conexionMysql)
                    cmd44.ExecuteNonQuery()
                    conexionMysql.Close()

                    cerrarconexion()
                    conexionMysql.Open()
                    Dim Sql33 As String
                    Sql33 = "INSERT INTO `dwin`.`proveedor` (`nombre_empresa`, `nombre_encargado`, `ap_encargado`, `am_encargado`, `ciudad`, `estado`, `telefono`, `correo`) VALUES ('general', 'general', 'general', 'general', 'general', 'general', '00', '00');"
                    Dim cmd33 As New MySqlCommand(Sql33, conexionMysql)
                    cmd33.ExecuteNonQuery()
                    conexionMysql.Close()

                    cerrarconexion()
                    conexionMysql.Open()
                    Dim Sql34 As String
                    Sql34 = "INSERT INTO `dwin`.`tipoproducto` (`tipo`) VALUES ('general');"
                    Dim cmd34 As New MySqlCommand(Sql34, conexionMysql)
                    cmd34.ExecuteNonQuery()
                    conexionMysql.Close()



                    'AQUI INSERTAMOS LOS DATOS INICIALES DEL SERVICIO, QUE SON 3, 

                    conexionMysql.Open()
                    Dim Sql35 As String
                    Sql35 = "INSERT INTO `dwin`.`tipoventa` (`idtipoventa`,`tipoventa`) VALUES ('1','venta');"
                    Dim cmd35 As New MySqlCommand(Sql35, conexionMysql)
                    cmd35.ExecuteNonQuery()
                    conexionMysql.Close()
                    conexionMysql.Open()
                    Dim Sql36 As String
                    Sql36 = "INSERT INTO `dwin`.`tipoventa` (`idtipoventa`,`tipoventa`) VALUES ('2','servicios');"
                    Dim cmd36 As New MySqlCommand(Sql36, conexionMysql)
                    cmd36.ExecuteNonQuery()
                    conexionMysql.Close()
                    'MsgBox("se creo tipo de venta")
                    conexionMysql.Open()
                    Dim Sql37 As String
                    Sql37 = "INSERT INTO `dwin`.`tipoventa` (`idtipoventa`,`tipo`) VALUES ('3','vinil');"
                    Dim cmd37 As New MySqlCommand(Sql37, conexionMysql)
                    cmd37.ExecuteNonQuery()
                    conexionMysql.Close()


                    Try
                        conexionMysql.Open()

                        Dim Sql40 As String
                        Sql40 = "INSERT INTO `dwin`.`tipo_pago` (`idtipo_pago`, `tipo`) VALUES ('1', 'EFECTIVO');
INSERT INTO `dwin`.`tipo_pago` (`idtipo_pago`, `tipo`) VALUES ('2', 'DEPOSITO');
INSERT INTO `dwin`.`tipo_pago` (`idtipo_pago`, `tipo`) VALUES ('3', 'TRANSFERENCIA');
;"
                        Dim cmd40 As New MySqlCommand(Sql40, conexionMysql)
                        cmd40.ExecuteNonQuery()
                        conexionMysql.Close()

                    Catch ex As Exception
                        cerrarconexion()
                    End Try





                    MsgBox("EL SISTEMA CREO LOS REGISTROS INICIALES EXITOSAMENTE", MsgBoxStyle.Information, "Sistema")
                Catch ex3 As Exception
                    MsgBox("SISTEMA NO CREO LOS DATOS CORRECTAMENTE", MsgBoxStyle.Exclamation, "Sistema")

                End Try

            End If


        Catch ex As Exception
            MsgBox("UPSSS.... algo no esta bien!!!", MsgBoxStyle.Exclamation, "CTRL+y")
        End Try

    End Function
    Private Sub txtclave_TextChanged(sender As Object, e As EventArgs) Handles txtclave.TextChanged
        If txtclave.Text = "" Then
            borrar()
        Else

            buscarid()
            '    obtenerfolio()
        End If

    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub rbnombre_CheckedChanged(sender As Object, e As EventArgs) Handles rbnombre.CheckedChanged
        If rbnombre.Checked = True Then
            txtnombre.Visible = True
            lbnombre.Visible = True
            'btnbuscarnombre.Visible = True

            txtclave.Visible = False
            lbclave.Visible = False
            'btnbuscarclave.Visible = False
            grilla2.Visible = True
            grilla.Visible = False
            'se habilita los ch, donde se permite la busqueda de productos
            chanexar.Enabled = True
            chpermitircantidad.Enabled = True





        End If

    End Sub

    Private Sub rbclave_CheckedChanged(sender As Object, e As EventArgs) Handles rbclave.CheckedChanged
        If rbclave.Checked = True Then
            txtnombre.Visible = False
            lbnombre.Visible = False
            'btnbuscarnombre.Visible = False
            txtclave.Visible = True
            lbclave.Visible = True
            'btnbuscarclave.Visible = True

            grilla.Visible = True
            grilla2.Visible = False
            chanexar.Enabled = False
            chpermitircantidad.Enabled = False

        Else

            'bloquear los ch, donde se anexa el producto directo y se permite cantidad



        End If
    End Sub

    Private Sub txtnombre_GotFocus(sender As Object, e As EventArgs) Handles txtnombre.GotFocus
        If rbnombre.Checked = True Then
            txtnombre.Visible = True
            lbnombre.Visible = True
            'btnbuscarnombre.Visible = True

            txtclave.Visible = False
            lbclave.Visible = False
            'btnbuscarclave.Visible = False
        End If
    End Sub

    Private Sub txtnombre_TextChanged(sender As Object, e As EventArgs) Handles txtnombre.TextChanged
        grilla2.DefaultCellStyle.Font = New Font("Arial", 20)
        grilla2.RowHeadersVisible = False


        If txtnombre.Text = "" Then
            grilla.Visible = True
            grilla2.Visible = False

        Else

            grilla.Visible = False
            grilla2.Visible = True


        End If

        llenadogrilla2()


    End Sub

    Private Sub grilla2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grilla2.CellContentClick
        'Try

        '    Dim Variable As String = grilla2.Item(0, grilla2.CurrentRow.Index).Value
        '    'MsgBox(Variable)
        '    txtclave.Text = Variable
        '    grilla2.Visible = False
        '    grilla.Visible = True
        '    rbclave.Checked = True
        '    'MsgBox("vamos a agregarr el producto")
        '    'buscaridcompra()

        '    If chanexar.Checked = True And chpermitircantidad.Checked = False Then
        '        MsgBox("solo esta activa la de anexar directo")
        '        Dim cantidad_total, cantidadbd As Integer

        '        'cantidad total es la cantidad que se va a vender
        '        'se le suma 1, porque es el producto que apenas se va anexar a la lista de venta
        '        cantidad_total = comprobacion() + txtcantidad.Text


        '        'cantidadbd, es la cantidad que existe en la BD del producto

        '        cantidadbd = conteoclave()


        '        If cantidad_total > cantidadbd Then
        '            MsgBox("No hay productos suficientes, no se agregara este producto", MsgBoxStyle.Exclamation, "Sistema")
        '            borrar()
        '        Else
        '            agregargrilla()

        '        End If
        '        'en caso de que esten activadas las dos, de permitir cantidad y anexar director entonces, que no haga nada, hasta que se cierre 
        '        'la ventana de permitircantidad.
        '    ElseIf chanexar.Checked = False And chpermitircantidad.Checked = True Then
        '        MsgBox("estan activadas las dos casillas.")
        '        'no hace nada.
        '        'solo mandamos a llamar a la ventana de cantidad.
        '        '-----------------------NUEVO SISTEMA

        '        frcantidad.ShowDialog()


        '        '  MsgBox("anexando")


        '    End If






        'Catch ex As Exception

        'End Try

    End Sub
    Function agregarproductoaventa()
        Try

            Dim Variable As String = grilla2.Item(0, grilla2.CurrentRow.Index).Value
            'MsgBox(Variable)
            txtclave.Text = Variable
            grilla2.Visible = False
            grilla.Visible = True
            rbclave.Checked = True

        Catch ex As Exception

        End Try

    End Function
    Private Sub grilla2_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grilla2.CellDoubleClick
        Try

            Dim Variable As String = grilla2.Item(0, grilla2.CurrentRow.Index).Value
            'MsgBox(Variable)
            txtclave.Text = Variable
            grilla2.Visible = False
            grilla.Visible = True
            rbclave.Checked = True
            'MsgBox("vamos a agregarr el producto")
            'buscaridcompra()

            If chanexar.Checked = True And chpermitircantidad.Checked = False Then
                '               MsgBox("solo esta activa la de anexar directo")
                Dim cantidad_total, cantidadbd As Integer

                'cantidad total es la cantidad que se va a vender
                'se le suma 1, porque es el producto que apenas se va anexar a la lista de venta
                cantidad_total = comprobacion() + txtcantidad.Text


                'cantidadbd, es la cantidad que existe en la BD del producto

                cantidadbd = conteoclave()


                If cantidad_total > cantidadbd Then
                    MsgBox("No hay productos suficientes, no se agregara este producto", MsgBoxStyle.Exclamation, "Sistema")
                    borrar()
                Else
                    agregargrilla()

                End If
                'en caso de que esten activadas las dos, de permitir cantidad y anexar director entonces, que no haga nada, hasta que se cierre 
                'la ventana de permitircantidad.
            ElseIf chanexar.Checked = False And chpermitircantidad.Checked = True Then
                ' MsgBox("estan activadas las dos casillas.")
                'no hace nada.
                'solo mandamos a llamar a la ventana de cantidad.
                '-----------------------NUEVO SISTEMA

                frcantidad.ShowDialog()


                '  MsgBox("anexando")


            End If






        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnbuscarnombre_Click(sender As Object, e As EventArgs)
        Call llenadogrilla2()

    End Sub

    Private Sub txtcosto_Click(sender As Object, e As EventArgs) Handles txtcosto.Click
        Dim costo As Double
        Try


            costo = InputBox("Ingresa el valor del producto:", "Sistema")

            If costo = 0 Then
                MsgBox("Valor no aceptado", MsgBoxStyle.Exclamation, "Sistema")
            Else
                txtcosto.Text = costo
                Try
                    txttotal.Text = CDbl(txtcantidad.Text) * CDbl(txtcosto.Text)

                Catch ex As Exception
                    txttotal.Text = ""
                End Try
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub txtnombrep_KeyDown(sender As Object, e As KeyEventArgs) Handles txtnombrep.KeyDown
        If (e.KeyCode = Keys.Tab) Then
            txtactividadp.Focus()

        End If
    End Sub

    Private Sub txtnombrep_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnombrep.KeyPress


    End Sub

    Private Sub txtnombrep_TextChanged(sender As Object, e As EventArgs) Handles txtnombrep.TextChanged
        grilla2p.DefaultCellStyle.Font = New Font("Arial", 20)
        grilla2p.RowHeadersVisible = False
        grilla2p.Visible = True
        grillap.Visible = False
        grillahistorialesproductos.Visible = False


        If txtnombrep.Text = "" Then
            grillap.Visible = True
            grilla2p.Visible = False

            borrarp()
        Else

            grillap.Visible = False
            grilla2p.Visible = True


        End If

        llenadogrilla2p()
        grillahistorialesproductos.Visible = False


    End Sub

    Private Sub rbnombrep_CheckedChanged(sender As Object, e As EventArgs) Handles rbnombrep.CheckedChanged
        If rbnombrep.Checked = True Then
            txtnombrep.Visible = True
            lbnombrep.Visible = True
            'btnbuscarnombrep.Visible = True

            txtclavep.Visible = False
            lbclavep.Visible = False
            'btnbuscarclavep.Visible = False
            grilla2p.Visible = True
            grillap.Visible = False
            grillahistorialesproductos.Visible = False

        End If
    End Sub

    Private Sub rbclavep_CheckedChanged(sender As Object, e As EventArgs) Handles rbclavep.CheckedChanged
        If rbclavep.Checked = True Then
            txtnombrep.Visible = False
            lbnombrep.Visible = False
            'btnbuscarnombrep.Visible = False
            txtclavep.Visible = True
            lbclavep.Visible = True
            'btnbuscarclavep.Visible = True

            grillap.Visible = True
            grilla2p.Visible = False
            grillahistorialesproductos.Visible = False


        End If
    End Sub

    Private Sub txtclavep_KeyDown(sender As Object, e As KeyEventArgs) Handles txtclavep.KeyDown

    End Sub

    Private Sub txtclavep_KeyUp(sender As Object, e As KeyEventArgs) Handles txtclavep.KeyUp

    End Sub

    Private Sub txtclavep_TextChanged(sender As Object, e As EventArgs) Handles txtclavep.TextChanged
        grillap.Visible = True
        grilla2p.Visible = False
        grillahistorialesproductos.Visible = False



        If txtclavep.Text = "" Then
            borrarp()

        Else
            buscaridp()

        End If
    End Sub

    Private Sub Button21_Click_1(sender As Object, e As EventArgs) Handles Button21.Click
        Dim res As Integer
        res = 1
        If txttipoproducto.Text = "" Or txtproveedor.Text = "" Or txtclavep.Text = "" Or txtactividadp.Text = "" Or txtcantidadp.Text = "" Or txtprecioindividualp.Text = "" Or txtpreciomayoreop.Text = "" Then
            MsgBox("Hace falta información", MsgBoxStyle.Exclamation, "Sistema")
        Else
            'Try
            Dim clave As String
            cerrarconexion()
            'consulto que el ID no exista para poder ingresar uno nuevo
            conexionMysql.Open()
            Dim Sql As String
            Sql = "select idproducto from producto where idproducto='" & txtclavep.Text & "';"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            reader = cmd.ExecuteReader()
            reader.Read()
            Try
                clave = reader.GetString(0).ToString
            Catch ex As Exception
                clave = ""
            End Try
            cerrarconexion()

            conexionMysql.Close()
            'comprobar si devolvio null o un valor real
            If clave = txtclavep.Text Then
                MsgBox("La clave del producto ya existe, asigna un nuevo valor", MsgBoxStyle.Exclamation, "Sistema")
                'Catch ex As Exception
                res = 0
            End If


            'End Try

            '----------------------------------------- obtener id de proveedor
            Dim idproveedor As Integer
            cerrarconexion()

            conexionMysql.Open()
            Dim Sql5 As String
            Sql5 = "select idproveedor from proveedor where nombre_empresa='" & txtproveedor.Text & "';"
            Dim cmd5 As New MySqlCommand(Sql5, conexionMysql)
            reader = cmd5.ExecuteReader()
            reader.Read()

            idproveedor = reader.GetString(0).ToString

            conexionMysql.Close()

            '----------------------------------------- obtener id de tipoproducto
            Dim idtipoproducto As Integer
            cerrarconexion()

            conexionMysql.Open()
            Dim Sql55 As String
            Sql55 = "select idtipoproducto from tipoproducto where tipo='" & txttipoproducto.Text & "';"
            Dim cmd55 As New MySqlCommand(Sql55, conexionMysql)
            reader = cmd55.ExecuteReader()
            reader.Read()

            idtipoproducto = reader.GetString(0).ToString

            conexionMysql.Close()


            If res <> 0 Then


                Try

                    cerrarconexion()

                    conexionMysql.Open()

                    Dim sql2 As String
                    sql2 = "INSERT INTO producto (idproducto,descripcion, cantidad, costo, precio, preciom, idproveedor,idtipoproducto) VALUES ('" & txtclavep.Text & "', '" & txtactividadp.Text & "', " & txtcantidadp.Text & ", " & txtcostop.Text & ", " & txtprecioindividualp.Text & ", " & txtpreciomayoreop.Text & "," & idproveedor & ", " & idtipoproducto & ");"
                    Dim cmd2 As New MySqlCommand(sql2, conexionMysql)
                    cmd2.ExecuteNonQuery()

                    conexionMysql.Close()



                    '---------------------------------------------------------

                    MsgBox("Producto guardado", MsgBoxStyle.Information, "Sistema")
                    'se llena la grilla, tomando en cuenta ninguna elemento.
                    txtnombrep.Text = ""
                    Call llenadogrilla()

                Catch ex As Exception
                    MsgBox("Existe un problema al guardar al registro", MsgBoxStyle.Information, "Sistema")
                End Try

                Call limpiarp()

            End If

        End If


    End Sub

    Function limpiarp()
        'txtclavep.Text = ""
        txtactividadp.Text = ""
        txtcantidadp.Text = ""
        txtprecioindividualp.Text = ""
        txtpreciomayoreop.Text = ""
        txtcostop.Text = ""
        txtproveedor.Text = ""


    End Function


    Function llenadogrilla()


        grillap.DefaultCellStyle.Font = New Font("Arial", 20)
        grillap.RowHeadersVisible = False
        'ampliar columna 
        'grillap.Columns(2).Width = 120


        grillap.AlternatingRowsDefaultCellStyle.BackColor = Color.SkyBlue

        Try


            If conexionMysql.State = ConnectionState.Open Then
                conexionMysql.Close()

            End If
            cerrarconexion()

            conexionMysql.Open()
            Dim sql As String
            sql = "select * from producto"
            Dim cmd As New MySqlCommand(sql, conexionMysql)
            Dim dt As New DataTable
            Dim da As New MySqlDataAdapter(cmd)
            'cargamos el formulario  resumen
            da.Fill(dt)
            grillap.DataSource = dt
            grillap.Columns(1).Width = 200
            grillap.Columns(0).Width = 90
            grillap.Columns(2).Width = 60
            grillap.Columns(3).Width = 60
            grillap.Columns(4).Width = 60
            grillap.Columns(5).Width = 60
            grillap.Columns(6).Width = 60
            grillap.Columns(7).Width = 60

            conexionMysql.Close()
        Catch ex As Exception
            MsgBox("Error del sistema", MsgBoxStyle.Exclamation, "Sistema")
        End Try

    End Function

    Private Sub grilla2p_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grilla2p.CellDoubleClick
        'al darle doble clic, mande el valor a la caja de texto
        Try

            Dim Variable As Integer = grilla2p.Item(0, grilla2p.CurrentRow.Index).Value
            'MsgBox(Variable)
            txtclavep.Text = Variable
            grilla2p.Visible = False
            grillap.Visible = True
            rbclavep.Checked = True

        Catch ex As Exception

        End Try

    End Sub
    Private Sub grilla2p_DoubleClick(sender As Object, e As EventArgs) Handles grilla2p.DoubleClick
        Try

            Dim Variable As Integer = grilla2p.Item(0, grilla2p.CurrentRow.Index).Value
            'MsgBox(Variable)
            txtclavep.Text = Variable
            grilla2p.Visible = False
            grillap.Visible = True
            rbclavep.Checked = True

        Catch ex As Exception

        End Try
    End Sub

    Private Sub grilla2p_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grilla2p.CellContentClick

    End Sub

    Private Sub Button15_Click_1(sender As Object, e As EventArgs) Handles Button15.Click

        If txttipoproducto.Text = "" Or txtproveedor.Text = "" Or txtclavep.Text = "" Or txtactividadp.Text = "" Or txtcostop.Text = "" Or txtcantidadp.Text = "" Or txtprecioindividualp.Text = "" Or txtpreciomayoreop.Text = "" Then
            MsgBox("Hay cajas vacias, verifica nuevamente", MsgBoxStyle.Information, "Sistema")
        Else




            '----------------------------------------- obtener id de proveedor
            Dim idproveedor As Integer
            cerrarconexion()

            conexionMysql.Open()
            Dim Sql5 As String
            Sql5 = "select idproveedor from proveedor where nombre_empresa='" & txtproveedor.Text & "';"
            Dim cmd5 As New MySqlCommand(Sql5, conexionMysql)
            reader = cmd5.ExecuteReader()
            reader.Read()

            idproveedor = reader.GetString(0).ToString

            conexionMysql.Close()

            '----------------------------------------- obtener id de tipoproducto
            Dim idtipoproducto As Integer
            cerrarconexion()

            conexionMysql.Open()
            Dim Sql51 As String
            Sql51 = "select idtipoproducto from tipoproducto where tipo='" & txttipoproducto.Text & "';"
            Dim cmd51 As New MySqlCommand(Sql51, conexionMysql)
            reader = cmd51.ExecuteReader()
            reader.Read()

            idtipoproducto = reader.GetString(0).ToString

            conexionMysql.Close()

            Dim tipo As Integer
            tipo = tipoingreso()

            'MsgBox("TIPO" & tipo)
            '----------------------comprobamos el tipo de usuario, si es un trabajador, solo permito que modifique la cantidad de producto-----
            '----------------------------------------------------------------------------------------------------------------------------------


            If tipo = 2 Then
                cerrarconexion()

                conexionMysql.Open()

                Dim sql22 As String
                sql22 = "UPDATE producto SET cantidad=" & txtcantidadp.Text & " WHERE idproducto='" & txtclavep.Text & "';"
                Dim cmd22 As New MySqlCommand(sql22, conexionMysql)
                cmd22.ExecuteNonQuery()

                conexionMysql.Close()
                MsgBox("Cantidad actualizada", MsgBoxStyle.Information, "Sistema")


                Call limpiarp()


                Call llenadogrilla()


            ElseIf tipo = 1 Then



                Try
                    cerrarconexion()

                    conexionMysql.Open()

                    Dim sql2 As String
                    sql2 = "UPDATE producto SET descripcion='" & txtactividadp.Text & "', cantidad=" & txtcantidadp.Text & ", costo=" & txtcostop.Text & ", precio=" & txtprecioindividualp.Text & ", preciom=" & txtpreciomayoreop.Text & ", idproveedor =" & idproveedor & ", idtipoproducto =" & idtipoproducto & "  WHERE idproducto='" & txtclavep.Text & "';"
                    Dim cmd2 As New MySqlCommand(sql2, conexionMysql)
                    cmd2.ExecuteNonQuery()

                    conexionMysql.Close()
                    MsgBox("Registro actualizado", MsgBoxStyle.Information, "Sistema")


                    Call limpiarp()


                    Call llenadogrilla()

                Catch ex As Exception
                    cerrarconexion()
                    comprobartipoingreso()

                End Try



            End If

        End If


    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click

        Try
            cerrarconexion()

            Dim respuesta As String

            respuesta = MsgBox("¿Estas seguro de eliminar el producto?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Sistema")
            If respuesta = vbYes Then
                conexionMysql.Open()

                Dim sql2 As String
                sql2 = "delete from producto where idproducto='" & txtclavep.Text & "';"
                Dim cmd2 As New MySqlCommand(sql2, conexionMysql)
                cmd2.ExecuteNonQuery()

                conexionMysql.Close()


                MsgBox("Producto Eliminado", MsgBoxStyle.Information, "Sistema")

                Call llenadogrilla()
                Call limpiarp()
            End If


        Catch ex As Exception
            'llamamos a la funcion de comprobar el tipo de usuario para verificar quien es y si es un trabajador
            'avisarle que no tiene permisos para poder realizar dicha eliminacion.
            tipoingreso()
            comprobartipoingreso()

        End Try





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
    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        cerrarconexion()
        Call llenadogrilla()

    End Sub
    Function totalcompradocompras()
        Dim fecha, dia, mes, año As String
        Dim valor As Double

        dia = Date.Now.Day
        mes = Date.Now.Month
        año = Date.Now.Year
        fecha = año & "-" & mes & "-" & dia


        Try
            cerrarconexion()

            conexionMysql.Open()
            Dim sql1 As String
            sql1 = "select sum(total)  from compra where fecha='" & fecha & "';"
            Dim cmd1 As New MySqlCommand(sql1, conexionMysql)
            reader = cmd1.ExecuteReader
            reader.Read()
            valor = reader.GetString(0).ToString()
            conexionMysql.Close()
            Return valor
        Catch ex As Exception

        End Try
    End Function
    Private Sub Button25_Click(sender As Object, e As EventArgs)



    End Sub
    Function climpiar()
        ctxtactividad.Text = ""
        ctxtcosto.Text = ""
        ctxttotal.Text = ""
        ctxtcantidad.Text = ""

    End Function
    Function cllenadogrilla()

        cerrarconexion()

        conexionMysql.Open()
        Dim Sql As String
        Sql = "select * from compra order by fecha desc;"
        Dim cmd As New MySqlCommand(Sql, conexionMysql)
        Dim dt As New DataTable
        Dim da As New MySqlDataAdapter(cmd)
        'cargamos el formulario  resumen
        da.Fill(dt)
        cgrilla.DataSource = dt
        cgrilla.Columns(1).Width = 300
        cgrilla.Columns(0).Width = 60
        cgrilla.Columns(2).Width = 70
        cgrilla.Columns(3).Width = 70
        cgrilla.Columns(4).Width = 80
        cgrilla.Columns(5).Width = 180

        cgrilla.Columns(6).Width = 100



        conexionMysql.Close()
    End Function

    Private Sub ctxtcantidad_TextChanged(sender As Object, e As EventArgs)
        Try
            ctxttotal.Text = CDbl(ctxtcantidad.Text) * CDbl(ctxtcosto.Text)

        Catch ex As Exception
            ctxttotal.Text = ""
        End Try
    End Sub

    Private Sub ctxtcosto_TextChanged(sender As Object, e As EventArgs)
        Try
            ctxttotal.Text = CDbl(ctxtcantidad.Text) * CDbl(ctxtcosto.Text)

        Catch ex As Exception
            ctxttotal.Text = ""
        End Try
    End Sub

    Private Sub ctxtcalendar_ValueChanged(sender As Object, e As EventArgs)

        Dim dia, mes, año, fechacompleta As String

        dia = ctxtcalendar.Value.Day
        mes = ctxtcalendar.Value.Month
        año = ctxtcalendar.Value.Year

        fechacompleta = año & "/" & mes & "/" & dia
        cerrarconexion()


        conexionMysql.Open()
        Dim Sql As String
        Sql = "select * from compra where fecha='" & fechacompleta & "';"
        Dim cmd As New MySqlCommand(Sql, conexionMysql)
        Dim dt As New DataTable
        Dim da As New MySqlDataAdapter(cmd)
        'cargamos el formulario  resumen
        da.Fill(dt)
        cgrilla.DataSource = dt
        cgrilla.Columns(1).Width = 350
        cgrilla.Columns(0).Width = 60
        cgrilla.Columns(2).Width = 70
        cgrilla.Columns(3).Width = 70
        cgrilla.Columns(4).Width = 80
        cgrilla.Columns(5).Width = 180



        conexionMysql.Close()

    End Sub
    Function comprobarpermisoscasillas()




    End Function
    Private Sub Button30_Click(sender As Object, e As EventArgs) Handles Button30.Click
        If utxtusuario.Text = "" Or utxtpass.Text = "" Or utxtnombre.Text = "" Or utxtap.Text = "" Or utxtam.Text = "" Or utxtcorreo.Text = "" Or utxtdireccion.Text = "" Or utxttelefono.Text = "" Or utxttipousuario.Text = "" Then
            MsgBox("Falta información", MsgBoxStyle.Information, "Sistema")

        Else
            'obtener fecha y hora
            Dim dia, mes, año, fecha As String

            dia = Date.Now.Day
            mes = Date.Now.Month
            año = Date.Now.Year
            fecha = año & "-" & mes & "-" & dia
            Dim usuario As String
            usuario = ""

            'comprobar que no exista el usuario en el sistema
            '-----------------------------------------------------------------------------
            Try
                cerrarconexion()

                conexionMysql.Open()
                Dim Sql6 As String
                Sql6 = "select usuario from usuario where usuario='" & utxtusuario.Text & "';"
                Dim cmd6 As New MySqlCommand(Sql6, conexionMysql)
                reader = cmd6.ExecuteReader()
                reader.Read()
                usuario = reader.GetString(0).ToString
                conexionMysql.Close()

            Catch ex As Exception

            End Try

            If usuario <> "" Then

                MsgBox("El usuario que intentas ingresas ya existe", MsgBoxStyle.Exclamation, "Sistema")

            Else


                cerrarconexion()

                Dim tipousuario As Integer
                'obtenemos el id del tipo de usuario que se va a elegir.
                '-----------------------------------------------------------------------------
                conexionMysql.Open()
                Dim Sql5 As String
                Sql5 = "select tipo_usuario from tipo_usuario where tipo='" & utxttipousuario.Text & "';"
                Dim cmd5 As New MySqlCommand(Sql5, conexionMysql)
                reader = cmd5.ExecuteReader()
                reader.Read()
                tipousuario = reader.GetString(0).ToString
                conexionMysql.Close()
                ' '--------------------------------------------------------------------
                ' Try


                cerrarconexion()

                conexionMysql.Open()
                Dim Sql As String
                Sql = "INSERT INTO usuario (usuario, nombre, ap, am, telefono, correo, direccion, tipo_usuario) VALUES ('" & utxtusuario.Text & "', '" & utxtnombre.Text & "', '" & utxtap.Text & "', '" & utxtam.Text & "', '" & utxttelefono.Text & "', '" & utxtcorreo.Text & "', '" & utxtdireccion.Text & "', " & tipousuario & ");"
                Dim cmd As New MySqlCommand(Sql, conexionMysql)
                cmd.ExecuteNonQuery()
                conexionMysql.Close()
                'llamar a la funcion limpiar, para limpiar las cajas cada vez que se agrege una nueva compra.
                MsgBox("Registro guardado correctamente", MsgBoxStyle.Information, "Sistema")
                conexionMysql.Close()

                '------------------------------------------------------------------------------------------------
                'creacion del usuario
                cerrarconexion()

                Try

                    conexionMysql.Open()
                    Dim Sqlu As String
                    Sqlu = "CREATE USER '" & utxtusuario.Text & "'@'%' IDENTIFIED BY '" & utxtpass.Text & "';"
                    Dim cmdu As New MySqlCommand(Sqlu, conexionMysql)
                    cmdu.ExecuteNonQuery()
                    conexionMysql.Close()
                    'llamar a la funcion limpiar, para limpiar las cajas cada vez que se agrege una nueva compra.
                    conexionMysql.Close()
                Catch ex As Exception


                End Try

                'dependiendo del tipo de usuario, si es administrador o trabajador
                '-------------------------------------------------------------------------------------------------
                'asignacion de privilegios

                If tipousuario = 1 Then
                    cerrarconexion()

                    conexionMysql.Open()
                    Dim Sqlu1 As String
                    Sqlu1 = "GRANT ALL PRIVILEGES ON * . * TO '" & utxtusuario.Text & "'@'%' WITH GRANT OPTION;"
                    Dim cmdu1 As New MySqlCommand(Sqlu1, conexionMysql)
                    cmdu1.ExecuteNonQuery()
                    conexionMysql.Close()
                    MsgBox("Se ha creado un usuario Administrador", MsgBoxStyle.Information, "Sistema")
                    'llamar a la funcion limpiar, para limpiar las cajas cada vez que se agrege una nueva compra.
                ElseIf tipousuario = 2 Then

                    cerrarconexion()
                    'por la actualizacion se cambio el tipo de usuari oque se crea, ahora se le dan todos los permisos de la BD
                    'solo lo limitamos a que opcion puede entrar y a cual no.
                    conexionMysql.Open()
                    Dim Sqlu1 As String
                    Sqlu1 = "GRANT ALL PRIVILEGES ON * . * TO '" & utxtusuario.Text & "'@'%' WITH GRANT OPTION;"
                    Dim cmdu1 As New MySqlCommand(Sqlu1, conexionMysql)
                    cmdu1.ExecuteNonQuery()
                    conexionMysql.Close()


                    Dim p1, p2, p3, p4, p5, p6, p7, p8, p9 As Integer
                    If uchclientes.Checked = True Then

                        p1 = 1
                    Else
                        p1 = 0
                    End If


                    If uchcompras.Checked = True Then

                        p2 = 1
                    Else
                        p2 = 0
                    End If

                    If uchproductos.Checked = True Then

                        p3 = 1
                    Else
                        p3 = 0
                    End If
                    If uchcorte.Checked = True Then

                        p4 = 1
                    Else
                        p4 = 0
                    End If

                    If uchusuarios.Checked = True Then

                        p5 = 1
                    Else
                        p5 = 0
                    End If
                    If uchproveedores.Checked = True Then

                        p6 = 1
                    Else
                        p6 = 0
                    End If
                    If uchreportes.Checked = True Then

                        p7 = 1
                    Else
                        p7 = 0
                    End If
                    If uchconfiguracion.Checked = True Then

                        p8 = 1
                    Else
                        p8 = 0
                    End If



                    ' Try

                    conexionMysql.Open()
                    Dim Sqlp1 As String
                    Sqlp1 = "update usuario set pclientes='" & p1 & "',  pcompras ='" & p2 & "', pproductos='" & p3 & "', pcorte='" & p4 & "', pusuarios='" & p5 & "',pproveedores='" & p6 & "', preportes='" & p7 & "', pconfiguracion='" & p8 & "'       where usuario='" & utxtusuario.Text & "';"
                    Dim cmdp1 As New MySqlCommand(Sqlp1, conexionMysql)
                    cmdp1.ExecuteNonQuery()
                    conexionMysql.Close()

                    MsgBox("Registro actualizado", MsgBoxStyle.Information, "Sistema")
                    '   ullenadogrilla()
                    'ulimpiarusuario()
                    ' Catch ex As Exception
                    '  comprobartipoingreso()
                    '    End Try




                    '----------------------------se comento el codigo porque se le asignan todos los permisos igual que un admin,
                    '----------------------------- solo se limita al acceso a las secciones

                    'cerrarconexion()
                    ''actualizacion septiembre 2020

                    'conexionMysql.Open()
                    'Dim Sqlu30sep As String
                    'Sqlu30sep = "GRANT select ON dwin.logo_empresa TO '" & utxtusuario.Text & "'@'%';"
                    'Dim cmdu30sep As New MySqlCommand(Sqlu30sep, conexionMysql)
                    'cmdu30sep.ExecuteNonQuery()
                    'conexionMysql.Close()

                    'conexionMysql.Open()
                    'Dim Sqlu31sep As String
                    'Sqlu31sep = "FLUSH PRIVILEGES;"
                    'Dim cmdu31sep As New MySqlCommand(Sqlu31sep, conexionMysql)
                    'cmdu31sep.ExecuteNonQuery()
                    'conexionMysql.Close()




                    'conexionMysql.Open()
                    'Dim Sqlu28sep As String
                    'Sqlu28sep = "GRANT select,insert,update ON dwin.caja TO '" & utxtusuario.Text & "'@'%';"
                    'Dim cmdu28sep As New MySqlCommand(Sqlu28sep, conexionMysql)
                    'cmdu28sep.ExecuteNonQuery()
                    'conexionMysql.Close()

                    'conexionMysql.Open()
                    'Dim Sqlu29sep As String
                    'Sqlu29sep = "FLUSH PRIVILEGES;"
                    'Dim cmdu29sep As New MySqlCommand(Sqlu29sep, conexionMysql)
                    'cmdu29sep.ExecuteNonQuery()
                    'conexionMysql.Close()




                    'conexionMysql.Open()
                    'Dim Sqlu26sep As String
                    'Sqlu26sep = "GRANT select,insert ON dwin.datos_empresa TO '" & utxtusuario.Text & "'@'%';"
                    'Dim cmdu26sep As New MySqlCommand(Sqlu26sep, conexionMysql)
                    'cmdu26sep.ExecuteNonQuery()
                    'conexionMysql.Close()


                    'conexionMysql.Open()
                    'Dim Sqlu27sep As String
                    'Sqlu27sep = "FLUSH PRIVILEGES;"
                    'Dim cmdu27sep As New MySqlCommand(Sqlu27sep, conexionMysql)
                    'cmdu27sep.ExecuteNonQuery()
                    'conexionMysql.Close()




                    'conexionMysql.Open()
                    'Dim Sqlu1 As String
                    'Sqlu1 = "GRANT select,insert,update ON dwin.venta TO '" & utxtusuario.Text & "'@'%';"
                    'Dim cmdu1 As New MySqlCommand(Sqlu1, conexionMysql)
                    'cmdu1.ExecuteNonQuery()
                    'conexionMysql.Close()


                    'conexionMysql.Open()
                    'Dim Sqlu25 As String
                    'Sqlu25 = "FLUSH PRIVILEGES;"
                    'Dim cmdu25 As New MySqlCommand(Sqlu25, conexionMysql)
                    'cmdu25.ExecuteNonQuery()
                    'conexionMysql.Close()

                    'conexionMysql.Open()
                    'Dim Sqlu26 As String
                    'Sqlu26 = "GRANT select,insert ON dwin.compramercancia TO '" & utxtusuario.Text & "'@'%';"
                    'Dim cmdu26 As New MySqlCommand(Sqlu26, conexionMysql)
                    'cmdu26.ExecuteNonQuery()
                    'conexionMysql.Close()


                    'conexionMysql.Open()
                    'Dim Sqlu27 As String
                    'Sqlu27 = "FLUSH PRIVILEGES;"
                    'Dim cmdu27 As New MySqlCommand(Sqlu27, conexionMysql)
                    'cmdu27.ExecuteNonQuery()
                    'conexionMysql.Close()

                    ''--------------------------------------
                    'conexionMysql.Open()
                    'Dim Sqlu262 As String
                    'Sqlu262 = "GRANT select,insert ON dwin.ventaind TO '" & utxtusuario.Text & "'@'%';"
                    'Dim cmdu262 As New MySqlCommand(Sqlu262, conexionMysql)
                    'cmdu262.ExecuteNonQuery()
                    'conexionMysql.Close()


                    'conexionMysql.Open()
                    'Dim Sqlu272 As String
                    'Sqlu272 = "FLUSH PRIVILEGES;"
                    'Dim cmdu272 As New MySqlCommand(Sqlu272, conexionMysql)
                    'cmdu272.ExecuteNonQuery()
                    'conexionMysql.Close()
                    ''--------------------------------------------
                    'conexionMysql.Open()
                    'Dim Sqlu263 As String
                    'Sqlu263 = "GRANT select,insert ON dwin.venta TO '" & utxtusuario.Text & "'@'%';"
                    'Dim cmdu263 As New MySqlCommand(Sqlu263, conexionMysql)
                    'cmdu263.ExecuteNonQuery()
                    'conexionMysql.Close()


                    'conexionMysql.Open()
                    'Dim Sqlu274 As String
                    'Sqlu274 = "FLUSH PRIVILEGES;"
                    'Dim cmdu274 As New MySqlCommand(Sqlu274, conexionMysql)
                    'cmdu274.ExecuteNonQuery()
                    'conexionMysql.Close()
                    ''--------------------------------------------
                    'conexionMysql.Open()
                    'Dim Sqlu265 As String
                    'Sqlu265 = "GRANT select ON dwin.cliente TO '" & utxtusuario.Text & "'@'%';"
                    'Dim cmdu265 As New MySqlCommand(Sqlu265, conexionMysql)
                    'cmdu265.ExecuteNonQuery()
                    'conexionMysql.Close()


                    'conexionMysql.Open()
                    'Dim Sqlu276 As String
                    'Sqlu276 = "FLUSH PRIVILEGES;"
                    'Dim cmdu276 As New MySqlCommand(Sqlu276, conexionMysql)
                    'cmdu276.ExecuteNonQuery()
                    'conexionMysql.Close()

                    ''--------------------------------------------
                    'conexionMysql.Open()
                    'Dim Sqlu266 As String
                    'Sqlu266 = "GRANT select ON dwin.usuario TO '" & utxtusuario.Text & "'@'%';"
                    'Dim cmdu266 As New MySqlCommand(Sqlu266, conexionMysql)
                    'cmdu266.ExecuteNonQuery()
                    'conexionMysql.Close()


                    'conexionMysql.Open()
                    'Dim Sqlu277 As String
                    'Sqlu277 = "FLUSH PRIVILEGES;"
                    'Dim cmdu277 As New MySqlCommand(Sqlu277, conexionMysql)
                    'cmdu277.ExecuteNonQuery()
                    'conexionMysql.Close()

                    ''--------------------------------------------
                    'conexionMysql.Open()
                    'Dim Sqlu268 As String
                    'Sqlu268 = "GRANT select ON dwin.producto TO '" & utxtusuario.Text & "'@'%';"
                    'Dim cmdu268 As New MySqlCommand(Sqlu268, conexionMysql)
                    'cmdu268.ExecuteNonQuery()
                    'conexionMysql.Close()


                    'conexionMysql.Open()
                    'Dim Sqlu279 As String
                    'Sqlu279 = "FLUSH PRIVILEGES;"
                    'Dim cmdu279 As New MySqlCommand(Sqlu279, conexionMysql)
                    'cmdu279.ExecuteNonQuery()
                    'conexionMysql.Close()

                    ''--------------------------------------------
                    'conexionMysql.Open()
                    'Dim Sqlu281 As String
                    'Sqlu281 = "GRANT update(cantidad) ON dwin.producto TO '" & utxtusuario.Text & "'@'%';"
                    'Dim cmdu281 As New MySqlCommand(Sqlu281, conexionMysql)
                    'cmdu281.ExecuteNonQuery()
                    'conexionMysql.Close()


                    'conexionMysql.Open()
                    'Dim Sqlu282 As String
                    'Sqlu282 = "FLUSH PRIVILEGES;"
                    'Dim cmdu282 As New MySqlCommand(Sqlu282, conexionMysql)
                    'cmdu282.ExecuteNonQuery()
                    'conexionMysql.Close()


                    ''--------------------------------------------
                    'conexionMysql.Open()
                    'Dim Sqlu283 As String
                    'Sqlu283 = "GRANT select ON dwin.proveedor TO '" & utxtusuario.Text & "'@'%';"
                    'Dim cmdu283 As New MySqlCommand(Sqlu283, conexionMysql)
                    'cmdu283.ExecuteNonQuery()
                    'conexionMysql.Close()


                    'conexionMysql.Open()
                    'Dim Sqlu284 As String
                    'Sqlu284 = "FLUSH PRIVILEGES;"
                    'Dim cmdu284 As New MySqlCommand(Sqlu284, conexionMysql)
                    'cmdu284.ExecuteNonQuery()
                    'conexionMysql.Close()
                    ''--------------------------------------------
                    'conexionMysql.Open()
                    'Dim Sqlu285 As String
                    'Sqlu285 = "GRANT select ON dwin.tipoproducto TO '" & utxtusuario.Text & "'@'%';"
                    'Dim cmdu285 As New MySqlCommand(Sqlu285, conexionMysql)
                    'cmdu285.ExecuteNonQuery()
                    'conexionMysql.Close()


                    'conexionMysql.Open()
                    'Dim Sqlu286 As String
                    'Sqlu286 = "FLUSH PRIVILEGES;"
                    'Dim cmdu286 As New MySqlCommand(Sqlu286, conexionMysql)
                    'cmdu286.ExecuteNonQuery()
                    'conexionMysql.Close()

                    ''--------------------------------------------
                    'conexionMysql.Open()
                    'Dim Sqlu287 As String
                    'Sqlu287 = "GRANT select ON dwin.corte TO '" & utxtusuario.Text & "'@'%';"
                    'Dim cmdu287 As New MySqlCommand(Sqlu287, conexionMysql)
                    'cmdu287.ExecuteNonQuery()
                    'conexionMysql.Close()


                    'conexionMysql.Open()
                    'Dim Sqlu288 As String
                    'Sqlu288 = "FLUSH PRIVILEGES;"
                    'Dim cmdu288 As New MySqlCommand(Sqlu288, conexionMysql)
                    'cmdu288.ExecuteNonQuery()
                    'conexionMysql.Close()
                    ''--------------------------------------------
                    'conexionMysql.Open()
                    'Dim Sqlu289 As String
                    'Sqlu289 = "GRANT insert ON dwin.corte TO '" & utxtusuario.Text & "'@'%';"
                    'Dim cmdu289 As New MySqlCommand(Sqlu289, conexionMysql)
                    'cmdu289.ExecuteNonQuery()
                    'conexionMysql.Close()


                    'conexionMysql.Open()
                    'Dim Sqlu290 As String
                    'Sqlu290 = "FLUSH PRIVILEGES;"
                    'Dim cmdu290 As New MySqlCommand(Sqlu290, conexionMysql)
                    'cmdu290.ExecuteNonQuery()
                    'conexionMysql.Close()
                    ''--------------------------------------------
                    'conexionMysql.Open()
                    'Dim Sqlu291 As String
                    'Sqlu291 = "GRANT select ON dwin.tipo_usuario TO '" & utxtusuario.Text & "'@'%';"
                    'Dim cmdu291 As New MySqlCommand(Sqlu291, conexionMysql)
                    'cmdu291.ExecuteNonQuery()
                    'conexionMysql.Close()


                    'conexionMysql.Open()
                    'Dim Sqlu292 As String
                    'Sqlu292 = "FLUSH PRIVILEGES;"
                    'Dim cmdu292 As New MySqlCommand(Sqlu292, conexionMysql)
                    'cmdu292.ExecuteNonQuery()
                    'conexionMysql.Close()
                    ''--------------------------------------------
                    'conexionMysql.Open()
                    'Dim Sqlu2911 As String
                    'Sqlu2911 = "GRANT select ON dwin.tipo_corte TO '" & utxtusuario.Text & "'@'%';"
                    'Dim cmdu2911 As New MySqlCommand(Sqlu2911, conexionMysql)
                    'cmdu2911.ExecuteNonQuery()
                    'conexionMysql.Close()


                    'conexionMysql.Open()
                    'Dim Sqlu2923 As String
                    'Sqlu2923 = "FLUSH PRIVILEGES;"
                    'Dim cmdu2923 As New MySqlCommand(Sqlu2923, conexionMysql)
                    'cmdu2923.ExecuteNonQuery()
                    'conexionMysql.Close()
                    ''conexionMysql.Open()
                    ''Dim Sqlux1 As String
                    ''Sqlux1 = "GRANT select,insert,producto ON dwin.ventaind  TO '" & utxtusuario.Text & "'@'localhost';"
                    ''Dim cmdux1 As New MySqlCommand(Sqlux1, conexionMysql)
                    ''cmdux1.ExecuteNonQuery()
                    ''conexionMysql.Close()

                    ''conexionMysql.Open()
                    ''Dim Sqlux4 As String
                    ''Sqlux4 = "GRANT select,insert,producto ON dwin.ventaind  TO '" & utxtusuario.Text & "'@'localhost';"
                    ''Dim cmdux4 As New MySqlCommand(Sqlux4, conexionMysql)
                    ''cmdux4.ExecuteNonQuery()
                    ''conexionMysql.Close()

                    'conexionMysql.Open()
                    'Dim Sqlux3 As String
                    'Sqlux3 = "GRANT select,update,insert ON dwin.producto  TO '" & utxtusuario.Text & "'@'%';"
                    'Dim cmdux3 As New MySqlCommand(Sqlux3, conexionMysql)
                    'cmdux3.ExecuteNonQuery()
                    'conexionMysql.Close()

                    'conexionMysql.Open()
                    'Dim Sqlu22 As String
                    'Sqlu22 = "FLUSH PRIVILEGES;"
                    'Dim cmdu22 As New MySqlCommand(Sqlu22, conexionMysql)
                    'cmdu22.ExecuteNonQuery()
                    'conexionMysql.Close()


                    'conexionMysql.Open()
                    'Dim Sqlux31 As String
                    'Sqlux31 = "GRANT select ON dwin.datos_empresa  TO '" & utxtusuario.Text & "'@'%';"
                    'Dim cmdux31 As New MySqlCommand(Sqlux31, conexionMysql)
                    'cmdux31.ExecuteNonQuery()
                    'conexionMysql.Close()

                    'conexionMysql.Open()
                    'Dim Sqlu222 As String
                    'Sqlu222 = "FLUSH PRIVILEGES;"
                    'Dim cmdu222 As New MySqlCommand(Sqlu222, conexionMysql)
                    'cmdu222.ExecuteNonQuery()
                    'conexionMysql.Close()


                    'conexionMysql.Open()
                    'Dim Sqlux5 As String
                    'Sqlux5 = "GRANT select, insert, update, delete ON dwin.compra TO '" & utxtusuario.Text & "'@'%';"
                    'Dim cmdux5 As New MySqlCommand(Sqlux5, conexionMysql)
                    'cmdux5.ExecuteNonQuery()
                    'conexionMysql.Close()
                    'conexionMysql.Open()
                    'Dim Sqlu23 As String
                    'Sqlu23 = "FLUSH PRIVILEGES;"
                    'Dim cmdu23 As New MySqlCommand(Sqlu23, conexionMysql)
                    'cmdu23.ExecuteNonQuery()
                    'conexionMysql.Close()


                    ''.....................IMPRESORA-----------------------
                    'conexionMysql.Open()
                    'Dim Sqlux6 As String
                    'Sqlux6 = "GRANT select, insert, update, delete ON dwin.impresora TO '" & utxtusuario.Text & "'@'%';"
                    'Dim cmdux6 As New MySqlCommand(Sqlux6, conexionMysql)
                    'cmdux6.ExecuteNonQuery()
                    'conexionMysql.Close()
                    'conexionMysql.Open()
                    'Dim Sqlu234 As String
                    'Sqlu234 = "FLUSH PRIVILEGES;"
                    'Dim cmdu234 As New MySqlCommand(Sqlu234, conexionMysql)
                    'cmdu234.ExecuteNonQuery()
                    'conexionMysql.Close()


                    MsgBox("Se ha creado un usario tipo Trabajador", MsgBoxStyle.Information, "Sistema")




                End If

                '--------------------------------------------------------------------------------------------
                'limpiar creacion de usuario

                conexionMysql.Open()
                Dim Sqlu2 As String
                Sqlu2 = "FLUSH PRIVILEGES;"
                Dim cmdu2 As New MySqlCommand(Sqlu2, conexionMysql)
                cmdu2.ExecuteNonQuery()
                conexionMysql.Close()
                'llamar a la funcion limpiar, para limpiar las cajas cada vez que se agrege una nueva compra.
                'conexionMysql.Close()

                ulimpiarusuario()
                ullenadogrilla()




                'Catch ex As Exception
                '    MsgBox("Existe un error, comprueba nuevamente", MsgBoxStyle.Exclamation, "Sistema")
                'End Try




            End If

        End If
    End Sub

    Function cerrarconexion()
        If conexionMysql.State = ConnectionState.Open Then
            conexionMysql.Close()

        End If
    End Function

    Function comprobarvaciousuario() As Single
        Dim resultado As Integer
        If utxtusuario.Text = "" Or utxtnombre.Text = "" Or utxtap.Text = "" Or utxtam.Text = "" Or utxtcorreo.Text = "" Or utxtdireccion.Text = "" Or utxttelefono.Text = "" Or utxttipousuario.Text = "" Then
            resultado = 1
        Else
            resultado = 0
        End If
        Return resultado
    End Function

    Function ulimpiarusuario()
        utxtam.Text = ""
        utxtap.Text = ""
        utxtcorreo.Text = ""
        utxtdireccion.Text = ""
        utxtnombre.Text = ""
        utxtpass.Text = ""
        utxttelefono.Text = ""
        utxtusuario.Text = ""
        utxttipousuario.Text = ""

    End Function
    Private Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click
        'boton actualizar de usuario
        Dim usuarioexiste As String
        Dim vatipo_usuario As Integer
        usuarioexiste = ""
        Dim valorretornado As Integer

        valorretornado = comprobarvaciousuario()

        If valorretornado = 1 Then

            MsgBox("Comprueba la información", MsgBoxStyle.Exclamation, "Sistema")
        Else

            Try
                cerrarconexion()

                conexionMysql.Open()
                Dim Sql5 As String
                Sql5 = "select usuario from usuario where usuario='" & utxtusuario.Text & "';"
                Dim cmd5 As New MySqlCommand(Sql5, conexionMysql)
                reader = cmd5.ExecuteReader()
                reader.Read()
                usuarioexiste = reader.GetString(0).ToString
                conexionMysql.Close()

            Catch ex As Exception
            End Try
            '----------------------------------------------------------------------------------------------
            'obtenemos el tipo de usuario al que se va actualizar, dependiendo del tipo que seleccione en el combobox
            Try
                cerrarconexion()

                conexionMysql.Open()
                Dim Sql6 As String
                Sql6 = "select tipo_usuario from tipo_usuario where tipo ='" & utxttipousuario.Text & "';"
                Dim cmd6 As New MySqlCommand(Sql6, conexionMysql)
                reader = cmd6.ExecuteReader()
                reader.Read()
                vatipo_usuario = reader.GetString(0).ToString
                conexionMysql.Close()
            Catch ex As Exception

            End Try

            '----------------------------------------------------------------------------------------------


            'verificamos si existe el usuario para poder consultarlo
            If usuarioexiste = "" Then
                MsgBox("Al parecer, el usuario no existe", MsgBoxStyle.Information, "Sistema")
            Else

                'cerramos la conexion en caso de algún error
                cerrarconexion()
                Try

                    conexionMysql.Open()
                    Dim Sql As String
                    Sql = "update usuario set nombre='" & utxtnombre.Text & "', ap='" & utxtap.Text & "', am='" & utxtap.Text & "', telefono='" & utxttelefono.Text & "', correo='" & utxtcorreo.Text & "', direccion='" & utxtdireccion.Text & "', tipo_usuario=" & vatipo_usuario & " where usuario='" & usuarioexiste & "';"
                    Dim cmd As New MySqlCommand(Sql, conexionMysql)
                    cmd.ExecuteNonQuery()
                    conexionMysql.Close()

                    MsgBox("Registro actualizado", MsgBoxStyle.Information, "Sistema")
                    ullenadogrilla()
                    ulimpiarusuario()
                Catch ex As Exception
                    comprobartipoingreso()
                End Try


            End If
        End If


    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        'llamamos al llenado de la grilla de la tabla usuario
        ullenadogrilla()
        ulimpiarusuario()

    End Sub
    Function ullenadogrilla()
        ugrilla.DefaultCellStyle.Font = New Font("Arial", 20)
        ugrilla.RowHeadersVisible = False
        'ampliar columna 
        'grillap.Columns(2).Width = 120
        ugrilla.AlternatingRowsDefaultCellStyle.BackColor = Color.SkyBlue

        Try
            cerrarconexion()


            conexionMysql.Open()
            Dim sql As String
            sql = "select * from usuario"
            Dim cmd As New MySqlCommand(sql, conexionMysql)
            Dim dt As New DataTable
            Dim da As New MySqlDataAdapter(cmd)
            'cargamos el formulario  resumen
            da.Fill(dt)
            ugrilla.DataSource = dt
            'ugrilla.Columns(1).Width = 350
            'ugrilla.Columns(0).Width = 60
            conexionMysql.Close()
        Catch ex As Exception
            MsgBox("Error del sistema", MsgBoxStyle.Exclamation, "Sistema")
        End Try

    End Function



    Private Sub ugrilla_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles ugrilla.CellContentDoubleClick

    End Sub

    Private Sub ugrilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ugrilla.CellContentClick
        Dim Variable As Integer = ugrilla.Item(0, ugrilla.CurrentRow.Index).Value
        'MsgBox(Variable)
        Dim utipo_usuario, c1, c2, c3, c4, c5, c6, c7, c8 As Integer

        'cerrar conexion en caso de que este abierta
        cerrarconexion()


        conexionMysql.Open()
        Dim sql As String
        sql = "select * from usuario where idusuario=" & Variable & ";"
        Dim cmd As New MySqlCommand(sql, conexionMysql)
        reader = cmd.ExecuteReader()
        reader.Read()
        utxtusuario.Text = reader.GetString(1).ToString
        utxtnombre.Text = reader.GetString(2).ToString
        utxtap.Text = reader.GetString(3).ToString
        utxtam.Text = reader.GetString(4).ToString
        utxttelefono.Text = reader.GetString(5).ToString
        utxtcorreo.Text = reader.GetString(6).ToString
        utxtdireccion.Text = reader.GetString(7).ToString
        'variable para obtener el tipo de usuario
        utipo_usuario = reader.GetString(8).ToString
        c1 = reader.GetString(9).ToString
        c2 = reader.GetString(10).ToString
        c3 = reader.GetString(11).ToString
        c4 = reader.GetString(12).ToString
        c5 = reader.GetString(13).ToString
        c6 = reader.GetString(14).ToString
        c7 = reader.GetString(15).ToString
        c8 = reader.GetString(16).ToString

        If c1 = 1 Then
            uchclientes.Checked = True
        Else
            uchclientes.Checked = False

        End If

        If c2 = 1 Then
            uchcompras.Checked = True
        Else
            uchcompras.Checked = False

        End If

        If c3 = 1 Then
            uchproductos.Checked = True
        Else
            uchproductos.Checked = False

        End If


        If c4 = 1 Then
            uchcorte.Checked = True
        Else
            uchcorte.Checked = False

        End If


        If c5 = 1 Then
            uchusuarios.Checked = True
        Else
            uchusuarios.Checked = False

        End If



        If c6 = 1 Then
            uchproveedores.Checked = True
        Else
            uchproveedores.Checked = False

        End If



        If c7 = 1 Then
            uchreportes.Checked = True
        Else
            uchreportes.Checked = False

        End If



        If c8 = 1 Then
            uchconfiguracion.Checked = True
        Else
            uchconfiguracion.Checked = False

        End If




        conexionMysql.Close()
        cerrarconexion()

        'llamo al tipo de usuario.

        Try
            conexionMysql.Open()
            Dim sql2 As String
            sql2 = "select tipo from tipo_usuario where tipo_usuario=" & utipo_usuario & ";"
            Dim cmd2 As New MySqlCommand(sql2, conexionMysql)
            reader = cmd2.ExecuteReader()
            reader.Read()
            utxttipousuario.Text = reader.GetString(0).ToString
            'variable para obtener el tipo de usuario
            conexionMysql.Close()
        Catch ex As Exception

            tipoingreso()
            comprobartipoingreso()
        End Try

        Try
            conexionMysql.Open()
            Dim sql23 As String
            sql23 = "select * from tipo_usuario where tipo_usuario=" & Variable & ";"
            Dim cmd23 As New MySqlCommand(sql23, conexionMysql)
            reader = cmd23.ExecuteReader()
            reader.Read()
            utxttipousuario.Text = reader.GetString(0).ToString
            'variable para obtener el tipo de usuario
            conexionMysql.Close()
        Catch ex As Exception

            tipoingreso()
            comprobartipoingreso()
        End Try


        'cargamos los checkbox que estan activados.




    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        'codigo boton eliminar usuarios
        Dim valorretornado As Integer

        valorretornado = comprobarvaciousuario()

        If valorretornado = 1 Then

            MsgBox("Comprueba la información", MsgBoxStyle.Exclamation, "Sistema")
        Else


            Try


                If utxtusuario.Text = "root" Then
                    MsgBox("Esta accion es imposible", MsgBoxStyle.Exclamation, "CTRLy")


                Else



                    'se elimina al usuario existente
                    eliminarusuario()
                End If


            Catch ex As Exception


                comprobartipoingreso()
                Dim respuesta As String
                respuesta = MsgBox("El usuario tiene cortes registrados, deseas eliminar toda la información", MsgBoxStyle.YesNo, "CTRLy")

                If respuesta = vbYes Then




                    'Dim idusuario As Integer
                    'cerrarconexion()
                    'conexionMysql.Open()
                    'Dim Sql1 As String
                    'Sql1 = "select idusuario from usuario where usuario='" & utxtusuario.Text & "';"
                    'Dim cmd1 As New MySqlCommand(Sql1, conexionMysql)
                    'reader = cmd1.ExecuteReader
                    'reader.Read()
                    'idusuario = reader.GetString(0).ToString
                    'conexionMysql.Close()
                    'cerrarconexion()



                    ''MsgBox(idusuario)
                    'cerrarconexion()
                    'conexionMysql.Open()
                    'Dim Sql As String
                    'Sql = "delete from corte where idusuario=" & idusuario & ";"
                    'Dim cmd As New MySqlCommand(Sql, conexionMysql)
                    'cmd.ExecuteNonQuery()
                    'conexionMysql.Close()

                    cerrarconexion()

                    'despues de que se eliminan los cortes del usuario, se procede a eliminar toda la informacion de el, tanto del la tabla usuario, como
                    'del servidor
                    eliminarusuario()


                End If



            End Try

        End If




    End Sub
    Function eliminarusuario()
        cerrarconexion()

        conexionMysql.Open()
        Dim Sql As String
        Sql = "delete from usuario where usuario='" & utxtusuario.Text & "';"
        Dim cmd As New MySqlCommand(Sql, conexionMysql)
        cmd.ExecuteNonQuery()
        conexionMysql.Close()

        cerrarconexion()

        conexionMysql.Open()
        Dim Sql2 As String
        Sql2 = "drop user '" & utxtusuario.Text & "'@'%';"
        Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
        cmd2.ExecuteNonQuery()
        conexionMysql.Close()

        MsgBox("Usuario eliminado", MsgBoxStyle.Information, "Sistema")
        'limpiamos las cajas
        ulimpiarusuario()
        'llenamos la grilla nuevamente 
        ullenadogrilla()

    End Function

    Private Sub btnbuscarclavep_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        txtnombrep.Text = ""
        txtclavep.Text = ""
        txtactividadp.Text = ""
        txtcantidadp.Text = ""
        txtcostop.Text = ""
        txtprecioindividualp.Text = ""
        txtpreciomayoreop.Text = ""


    End Sub

    Private Sub txtcliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtcliente.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            txtcliente.Text = "USUARIO"
            listaclientes.Visible = False

        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtcliente.TextChanged
        listaclientes.Visible = True
        listaclientes.Items.Clear()


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
        'Catch ex As Exception

        'End Try


    End Sub

    Private Sub listaclientes_DoubleClick(sender As Object, e As EventArgs) Handles listaclientes.DoubleClick
        listaclientes.Visible = False
        seleccioncliente()
    End Sub

    Private Sub listaclientes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles listaclientes.KeyPress
        If e.KeyChar = Chr(13) Then
            seleccioncliente()
        End If
    End Sub

    Function seleccioncliente()
        'funcion para seleccionar a los clientes al dar enter o al dar doble clic.
        txtcliente.Text = listaclientes.Text
        listaclientes.Visible = False

    End Function

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        'llamamos para limpiar todas las cajas de texto
        ulimpiarusuario()

    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click


        If ctxtnombre.Text = "" Or ctxtap.Text = "" Or ctxtam.Text = "" Or ctxtedad.Text = "" Or ctxtdireccion.Text = "" Or ctxtcorreo.Text = "" Or ctxttelefono.Text = "" Then
            MsgBox("Hay campos vacios, verifica", MsgBoxStyle.Information, "Sistema")
        Else
            Dim resultado As Integer

            Try

                cerrarconexion()

                'comprobamos que no exista otro usuario con la misma información
                conexionMysql.Open()
                Dim sql1 As String
                sql1 = "select idcliente from cliente where nombre ='" & ctxtnombre.Text & "' and ap='" & ctxtap.Text & "' and am='" & ctxtam.Text & "';"
                Dim cmd1 As New MySqlCommand(sql1, conexionMysql)
                reader = cmd1.ExecuteReader
                reader.Read()
                resultado = reader.GetString(0).ToString()
            Catch ex As Exception
                resultado = 0
            End Try


            'MsgBox(resultado)

            If resultado <> 0 Then

                MsgBox("Ya existe un registro con  el mismo nombre, verifica la información", MsgBoxStyle.Exclamation, "Sistema")
            Else

                cerrarconexion()
                Try

                    'BOTON AGREGAR CLIENTE
                    conexionMysql.Open()
                    Dim Sql As String
                    Sql = "insert into cliente (nombre,ap,am,rfc,direccion,telefono,correo) values('" & ctxtnombre.Text & "','" & ctxtap.Text & "','" & ctxtam.Text & "','" & ctxtedad.Text & "','" & ctxtdireccion.Text & "','" & ctxttelefono.Text & "','" & ctxtcorreo.Text & "');"
                    Dim cmd As New MySqlCommand(Sql, conexionMysql)
                    cmd.ExecuteNonQuery()
                    'limpiamos los campos de cliente.
                    limpiarcliente()
                    conexionMysql.Close()
                    MsgBox("Cliente registrado", MsgBoxStyle.Information, "Sistema")
                    cllenadocliente()

                Catch ex As Exception
                    tipoingreso()
                    comprobartipoingreso()

                End Try


            End If

        End If

    End Sub
    Function limpiarcliente()
        ctxtidcliente.Text = ""
        ctxtnombre.Text = ""
        ctxtap.Text = ""
        ctxtam.Text = ""
        ctxtedad.Text = ""
        ctxtdireccion.Text = ""
        ctxttelefono.Text = ""
        ctxtcorreo.Text = ""

    End Function

    Private Sub Button32_Click(sender As Object, e As EventArgs) Handles Button32.Click
        limpiarcliente()

        grillaclienteservicios.Visible = False
        grillacliente.Visible = True
        grupocontrolesclientes.Visible = False

        cllenadocliente()

    End Sub
    Function cllenadocliente()
        grillacliente.DefaultCellStyle.Font = New Font("Arial", 14)
        grillacliente.RowHeadersVisible = False
        'ampliar columna 
        'grillap.Columns(2).Width = 120


        grillacliente.AlternatingRowsDefaultCellStyle.BackColor = Color.SkyBlue

        Try

            cerrarconexion()


            conexionMysql.Open()
            Dim sql As String
            sql = "select * from cliente"
            Dim cmd As New MySqlCommand(sql, conexionMysql)
            Dim dt As New DataTable
            Dim da As New MySqlDataAdapter(cmd)
            'cargamos el formulario  resumen
            da.Fill(dt)
            grillacliente.DataSource = dt
            'ugrilla.Columns(1).Width = 350
            'ugrilla.Columns(0).Width = 60
            conexionMysql.Close()
        Catch ex As Exception
            MsgBox("Error del sistema", MsgBoxStyle.Exclamation, "Sistema")
        End Try

    End Function

    Private Sub grillacliente_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grillacliente.CellContentClick
        ' Try

        'Dim Variable As Integer = grillacliente.Item(0, grillacliente.CurrentRow.Index).Value
        ''MsgBox(Variable)
        'cerrarconexion()


        'Try


        '    conexionMysql.Open()
        '    Dim sql As String
        '    sql = "select * from cliente where idcliente =" & Variable & ";"
        '    Dim cmd As New MySqlCommand(sql, conexionMysql)
        '    reader = cmd.ExecuteReader
        '    reader.Read()
        '    ctxtidcliente.Text = reader.GetString(0).ToString()
        '    ctxtnombre.Text = reader.GetString(1).ToString()
        '    ctxtap.Text = reader.GetString(2).ToString()
        '    ctxtam.Text = reader.GetString(3).ToString()
        '    ctxtedad.Text = reader.GetString(4).ToString()
        '    ctxtdireccion.Text = reader.GetString(5).ToString()
        '    ctxttelefono.Text = reader.GetString(6).ToString()
        '    ctxtcorreo.Text = reader.GetString(7).ToString()


        '    conexionMysql.Close()

        'Catch ex As Exception
        '    cerrarconexion()
        'End Try


        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub Button31_Click(sender As Object, e As EventArgs) Handles Button31.Click

        If ctxtidcliente.Text = "" Then
            MsgBox("Al parecer no haz seleccionado un cliente", MsgBoxStyle.Information, "Sistema")
        Else

            Try
                cerrarconexion()

                conexionMysql.Open()
                Dim sql2 As String
                sql2 = "delete from cliente where idcliente=" & ctxtidcliente.Text & ";"
                Dim cmd2 As New MySqlCommand(sql2, conexionMysql)

                cmd2.ExecuteNonQuery()
                conexionMysql.Close()
                MsgBox("Cliente eliminado", MsgBoxStyle.Information, "Sistema")
                cllenadocliente()
                limpiarcliente()

            Catch ex As Exception
                comprobartipoingreso()

            End Try
        End If

    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs)
        limpiarcliente()

    End Sub

    Private Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click
        If ctxtidcliente.Text = "" Then
            MsgBox("Al parecer no haz seleccionado un cliente", MsgBoxStyle.Information, "Sistema")
        Else

            Try
                cerrarconexion()

                conexionMysql.Open()
                Dim sql2 As String
                sql2 = "update cliente set nombre='" & ctxtnombre.Text & "', ap='" & ctxtap.Text & "', am='" & ctxtam.Text & "', rfc='" & ctxtedad.Text & "', direccion='" & ctxtdireccion.Text & "', telefono='" & ctxttelefono.Text & "', correo='" & ctxtcorreo.Text & "' where idcliente=" & ctxtidcliente.Text & ";"
                Dim cmd2 As New MySqlCommand(sql2, conexionMysql)

                cmd2.ExecuteNonQuery()
                conexionMysql.Close()
                MsgBox("Cliente Actualizado", MsgBoxStyle.Information, "Sistema")
                cllenadocliente()
                limpiarcliente()

            Catch ex As Exception
                comprobartipoingreso()
                'MsgBox("Al parecer tienes ventas con este cliente, no se puede eliminar", MsgBoxStyle.Information, "Sistema")
            End Try
        End If
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        obtener_chticket_Chcambio_venta()
        Dim tipo As Integer

        tipo = tipoingreso()

        comprobarpermisoventana()
        tipo = p6

        If tipo = 0 Then

            TabControl1.SelectedIndex = 1
            Button1.BackColor = Color.DimGray
            Button2.BackColor = Color.FromArgb(47, 56, 72)
            Button3.BackColor = Color.FromArgb(47, 56, 72)
            Button4.BackColor = Color.FromArgb(47, 56, 72)
            Button5.BackColor = Color.FromArgb(47, 56, 72)
            Button6.BackColor = Color.FromArgb(47, 56, 72)
            Button8.BackColor = Color.FromArgb(47, 56, 72)
            Button10.BackColor = Color.FromArgb(47, 56, 72)
            Button12.BackColor = Color.FromArgb(47, 56, 72)
            Button13.BackColor = Color.FromArgb(47, 56, 72)
            Button67.BackColor = Color.FromArgb(47, 56, 72)


            comprobartipoingreso()
        Else


            TabControl1.SelectedIndex = 7

            Button1.BackColor = Color.FromArgb(47, 56, 72)
            Button2.BackColor = Color.FromArgb(47, 56, 72)
            Button3.BackColor = Color.FromArgb(47, 56, 72)
            Button4.BackColor = Color.FromArgb(47, 56, 72)
            Button5.BackColor = Color.FromArgb(47, 56, 72)
            Button6.BackColor = Color.FromArgb(47, 56, 72)
            Button8.BackColor = Color.FromArgb(47, 56, 72)
            Button10.BackColor = Color.FromArgb(47, 56, 72)
            Button12.BackColor = Color.FromArgb(47, 56, 72)
            Button13.BackColor = Color.DimGray
            Button67.BackColor = Color.FromArgb(47, 56, 72)

            'llamamos a la funcion llenar proveedor para que siempre llene los proveedores que  existan en la B.
            llenadoproveedor()
        End If


    End Sub

    Private Sub ctxtcosto_TextChanged_1(sender As Object, e As EventArgs) Handles ctxtcosto.TextChanged
        Try
            ctxttotal.Text = CDbl(ctxtcantidad.Text) * CDbl(ctxtcosto.Text)

        Catch ex As Exception
            ctxttotal.Text = ""
        End Try
    End Sub

    Private Sub ctxtcantidad_TextChanged_1(sender As Object, e As EventArgs) Handles ctxtcantidad.TextChanged
        Try
            ctxttotal.Text = CDbl(ctxtcantidad.Text) * CDbl(ctxtcosto.Text)

        Catch ex As Exception
            ctxttotal.Text = ""
        End Try
    End Sub

    Private Sub ctxtcalendar_ValueChanged_1(sender As Object, e As EventArgs) Handles ctxtcalendar.ValueChanged

        comprasdeldia()

    End Sub
    Function comprasdeldia()
        Dim dia, mes, año, fechacompleta As String

        dia = ctxtcalendar.Value.Day
        mes = ctxtcalendar.Value.Month
        año = ctxtcalendar.Value.Year

        fechacompleta = año & "/" & mes & "/" & dia

        Try
            cerrarconexion()

            conexionMysql.Open()
            Dim Sql As String
            Sql = "select * from compra where fecha='" & fechacompleta & "';"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            Dim dt As New DataTable
            Dim da As New MySqlDataAdapter(cmd)
            'cargamos el formulario  resumen
            da.Fill(dt)
            cgrilla.DataSource = dt
            cgrilla.Columns(1).Width = 280
            cgrilla.Columns(0).Width = 60
            cgrilla.Columns(2).Width = 70
            cgrilla.Columns(3).Width = 70
            cgrilla.Columns(4).Width = 80
            cgrilla.Columns(5).Width = 180

            cgrilla.Columns(5).Width = 130
            conexionMysql.Close()
        Catch ex As Exception

        End Try

    End Function
    Function desglosecortecalendario()
        Dim compra, venta, total As Double
        Try

            'todos los datos son obtenidos con la fecha actual para evitar conflictos
            Dim dia, mes, año, fecha As String

            hora2 = Now.Hour()
            minuto = Now.Minute()
            segundo = Now.Second()

            hora = hora2 & ":" & minuto & ":" & segundo

            fecha = calendario.SelectionRange.Start.ToString("yyyy/MM/dd")
            'CONSULTA PARA TODOS LOS PRODUCTOS EXTRAS, PAPELERIA Y SERVICIOS
            cerrarconexion()

            conexionMysql.Open()
            Dim Sql2 As String
            Sql2 = "select sum(total)as total from venta where fecha='" & fecha & "';"
            Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            reader = cmd2.ExecuteReader
            reader.Read()
            cbtnventas.Text = reader.GetString(0).ToString()
            venta = reader.GetString(0).ToString()

            conexionMysql.Close()
            cerrarconexion()


            'sumamos las compras
            conexionMysql.Open()
            Dim Sql23 As String
            Sql23 = "select sum(total)as total from compra where fecha='" & fecha & "';"
            Dim cmd23 As New MySqlCommand(Sql23, conexionMysql)
            reader = cmd23.ExecuteReader
            reader.Read()
            cbtncompras.Text = reader.GetString(0).ToString()
            compra = reader.GetString(0).ToString()

            conexionMysql.Close()
            cerrarconexion()



            'ahora hacemos la operacion matematica para que saquemos el total
            Try

                cbttotales.Text = CDbl(venta) - CDbl(compra)
            Catch ex As Exception
                cbttotales.Text = 0
            End Try

            'conexionMysql.Open()
            'Dim Sql3 As String
            'Sql3 = "select sum(recargas_venta)as suma1, sum(ciber) as suma from corte where fecha_registro='" & fecha & "';"
            'Dim cmd3 As New MySqlCommand(Sql3, conexionMysql)
            'reader = cmd3.ExecuteReader
            'reader.Read()
            'conexionMysql.Close()
        Catch ex As Exception

        End Try




    End Function
    Function desglosecorte()

        Try

            'todos los datos son obtenidos con la fecha actual para evitar conflictos
            Dim dia, mes, año, fecha As String

            hora2 = Now.Hour()
            minuto = Now.Minute()
            segundo = Now.Second()

            hora = hora2 & ":" & minuto & ":" & segundo

            dia = Date.Now.Day
            mes = Date.Now.Month
            año = Date.Now.Year
            fecha = año & "-" & mes & "-" & dia
            'CONSULTA PARA TODOS LOS PRODUCTOS EXTRAS, PAPELERIA Y SERVICIOS



            cerrarconexion()

            conexionMysql.Open()
            Dim sql1 As String
            sql1 = "select sum(total)  from compra where fecha='" & fecha & "';"
            Dim cmd1 As New MySqlCommand(sql1, conexionMysql)
            reader = cmd1.ExecuteReader
            reader.Read()
            cbtncompras.Text = "$" & reader.GetString(0).ToString()
            conexionMysql.Close()


            cerrarconexion()
            conexionMysql.Open()
            Dim Sql2 As String
            Sql2 = "select sum(total)as total from venta where fecha='" & fecha & "';"
            Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            reader = cmd2.ExecuteReader
            reader.Read()
            cbtnextras.Text = "$" & reader.GetString(0).ToString()
            conexionMysql.Close()
            cerrarconexion()
            conexionMysql.Open()
            Dim Sql3 As String
            Sql3 = "select sum(recargas_venta)as suma1, sum(ciber) as suma from corte where fecha_registro='" & fecha & "';"
            Dim cmd3 As New MySqlCommand(Sql3, conexionMysql)
            reader = cmd3.ExecuteReader
            reader.Read()
            conexionMysql.Close()

            'calculamos las operaciones para que de el final.
            cbttotales.Text = "$ " & CDbl(cbtnextras.Text) - CDbl(cbtncompras.Text)

        Catch ex As Exception

        End Try




    End Function

    Private Sub Button33_Click(sender As Object, e As EventArgs) Handles Button33.Click


        ''Try


        ''obtener fecha y hora
        'Dim dia, mes, año, fecha As String

        'hora2 = Now.Hour()
        'minuto = Now.Minute()
        'segundo = Now.Second()

        'hora = hora2 & ":" & minuto & ":" & segundo

        'dia = Date.Now.Day
        'mes = Date.Now.Month
        'año = Date.Now.Year
        'fecha = año & "-" & mes & "-" & dia


        ''consultamos el usuario para saber sobre quien se hizo el corte
        '' el usuario se encuentra en la variable usuarioactual

        ''--------------------------------------------------------------------
        'Dim idusuario As Integer


        'cerrarconexion()

        ''MsgBox(usuarioactual)


        'conexionMysql.Open()
        'Dim Sql2 As String
        'Sql2 = "select idusuario from usuario where usuario='" & usuarioactual & "';"
        'Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
        'reader = cmd2.ExecuteReader
        'reader.Read()
        'idusuario = reader.GetString(0).ToString()


        ''------------------ insertar reginstro en tabla venta ---------------------------------------
        'cerrarconexion()

        'If conexionMysql.State = ConnectionState.Open Then
        '    conexionMysql.Close()
        '    ' MsgBox("Si estaba abierta")
        'End If

        'If ctxtextras.Text = "" Or ctxttotalescorte.Text = "" Then
        '    MsgBox("Existen campos vacios", MsgBoxStyle.Information, "Sistema")

        'Else




        '    cerrarconexion()


        '    'If ctxtextras.Text = 0 Or ctxtcompras.Text = 0 Or ctxttotalescorte.Text Then
        '    'MsgBox("No es posible hacer un corte con Cero ventas")
        '    'Else


        '    '-----------------CONSULTAMOS SI EN EL CORTE SE HACE DE MAS DE 1 USUARIO, YA QUE UNO DE ELLOS
        '    '-----------------PUDO NO HABER HECHO SU CORTE, ENTONCES LE INDICAMOS AL USUARIO QUE SE HACE DE DOS
        '    'Dim cantidadusuarioscorte As Integer
        '    'Dim observacion As String
        '    'conexionMysql.Open()
        '    'Dim Sql3 As String
        '    'Sql3 = "select count(distinct idusuario) from venta where fecha='" & fecha & "' and hora between '" & horafin1 & "' and '" & hora & "';"

        '    'Dim cmd3 As New MySqlCommand(Sql3, conexionMysql)
        '    'reader = cmd3.ExecuteReader()
        '    'reader.Read()
        '    'cantidadusuarioscorte = reader.GetString(0).ToString
        '    'conexionMysql.Close()

        '    'If cantidadusuarioscorte > 1 Then
        '    '    observacion = "EL CORTE SE HIZO CON MAS DE 1 USUARIO, ADVERTENCIA"
        '    'End If
        '    '---------------------------------------------------------------------------------
        '    '---------------------------------------------------------------------------------
        '    '---------------------------------------------------------------------------------
        '    '---------------------------------------------------------------------------------



        '    conexionMysql.Open()

        '    Dim Sql As String
        '    Sql = "INSERT INTO corte (`extras`, `fecha_registro`, `hora_registro`,`idusuario`,`compra` ) VALUES ('" & ctxtextras.Text & "', '" & fecha & "', '" & hora & "'," & idusuario & "," & ctxtcompras.Text & ");"
        '    Dim cmd As New MySqlCommand(Sql, conexionMysql)
        '    cmd.ExecuteNonQuery()

        '    MsgBox("Registro Guardado", MsgBoxStyle.Information, "Sistema")
        '    'pass.Text = nombre
        '    ' desglosecorte()
        '    consultarcortecalendario()
        '    conexionMysql.Close()

        '    borrarcorte()
        '    ' consultarcorte()

        '    'Dim respuesta As String
        '    'respuesta = MsgBox("¿Desea realizar la impresion de su corte de caja del día?", MsgBoxStyle.YesNo & MsgBoxStyle.Information, "Sistema")

        '    'End If


        'End If


        ''main.Show()



        ''------------------ FIN insertar reginstro en tabla venta ---------------------------------------


        ''------------------ insertar reginstro en tabla ventaIND ---------------------------------------




        ''------------------ FIN insertar reginstro en tabla ventaIND ---------------------------------------

        ''Catch ex As Exception
        ''   MsgBox("No se guardaron los registos", MsgBoxStyle.Exclamation, "Sistema")

        ''End Try
    End Sub
    Function borrarcorte()
        'ctxtextras.Text = ""
        'ctxttotalescorte.Text = ""
        'ctxtcompras.Text = ""


    End Function

    Private Sub Button34_Click(sender As Object, e As EventArgs)
        ''se consulta cuanto se ha vendido...
        'consultacomprascorte()
        'cgrillacorte.RowHeadersVisible = False
        'consultarcorte()
        '' desglosecorte()
        'consultarcortecalendario()

        'Try
        '    ctxttotalescorte.Text = (CDbl(ctxtextras.Text)) - CDbl(ctxtcompras.Text)
        'Catch ex As Exception

        'End Try

    End Sub
    Function consultacomprascorte()


        'Dim dia, mes, año, fecha As String
        'Dim hora As String
        ''MsgBox("holaaaaaaaaaaaaaaaaaaaa")


        'hora2 = Now.Hour()
        'minuto = Now.Minute()
        'segundo = Now.Second()

        'hora = hora2 & ":" & minuto & ":" & segundo



        'dia = Date.Now.Day
        'mes = Date.Now.Month
        'año = Date.Now.Year
        'fecha = año & "-" & mes & "-" & dia


        ''Try

        ''primero selecciono la hora maxima de corte de caja del día de hoy. para que desde esa hora empiece a obtener valores

        'Dim horafin As String

        'cerrarconexion()

        'conexionMysql.Open()
        'Try
        '    Dim Sql1 As String
        '    Sql1 = "select max(hora_registro) from corte where fecha_registro='" & fecha & "';"
        '    Dim cmd1 As New MySqlCommand(Sql1, conexionMysql)
        '    reader = cmd1.ExecuteReader()
        '    reader.Read()

        '    horafin = reader.GetString(0).ToString
        'Catch ex As Exception
        '    horafin = "00:00:00"
        '    tipoingreso()

        'End Try

        'conexionMysql.Close()
        ''  MsgBox("la hora de registro de corte es:" & horafin)
        '' MsgBox("la hora DELSISTEMA ES:" & hora)

        'cerrarconexion()

        'conexionMysql.Open()

        'Dim Sql As String
        ''Sql = "select sum(total), fecha from venta where fecha='" & fecha & "';"
        'Sql = "select sum(total)  from compra where fecha='" & fecha & "' and hora between '" & horafin & "' and '" & hora & "';"
        'Dim cmd As New MySqlCommand(Sql, conexionMysql)
        'reader = cmd.ExecuteReader()
        'reader.Read()
        'Try
        '    ctxtcompras.Text = reader.GetString(0).ToString
        'Catch ex As Exception
        '    MsgBox("Aun no hay compras", MsgBoxStyle.Information, "Sistema")
        '    ctxtcompras.Text = 0

        '    'si aun no hay ventas, intentamos cargar los cortes de caja que se han hecho.

        '    '-----------------------------------------------------------------------------------
        '    'cargamos una funcion que manda a la grilla todos los cortes de caja que se han realizado.




        'End Try


    End Function
    Function consultacompras()

        Dim fecha, dia, mes, año As String
        Dim valor As Double

        dia = Date.Now.Day
        mes = Date.Now.Month
        año = Date.Now.Year
        fecha = año & "-" & mes & "-" & dia


        Try
            cerrarconexion()

            conexionMysql.Open()
            Dim sql1 As String
            sql1 = "select sum(total)  from compra where fecha='" & fecha & "';"
            Dim cmd1 As New MySqlCommand(sql1, conexionMysql)
            reader = cmd1.ExecuteReader
            reader.Read()
            valor = reader.GetString(0).ToString()
            conexionMysql.Close()
            Return valor
        Catch ex As Exception

        End Try
    End Function


    Private Sub ctxtciber_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub calendario_DateChanged(sender As Object, e As DateRangeEventArgs) Handles calendario.DateChanged


        consultacortecalendario()
        desgloseventas()

    End Sub

    Private Sub ctxtextras_MouseClick(sender As Object, e As MouseEventArgs)
        'consultamos el corte y todo lo vendido de tal fecha. al igual que lo cargue en la grilla.

        consultacortecalendario()

    End Sub

    Private Sub cbtnextras_Click(sender As Object, e As EventArgs)

        desgloseventas()



    End Sub
    Function desglosecompras()
        Dim fechacompleta As String

        fechacompleta = calendario.SelectionRange.Start.ToString("yyyy/MM/dd")
        cerrarconexion()
        'MsgBox(fechacompleta)
        conexionMysql.Open()
        Dim Sql As String
        Sql = "select *  from compra where fecha='" & fechacompleta & "';"
        Dim cmd As New MySqlCommand(Sql, conexionMysql)
        Dim dt As New DataTable
        Dim da As New MySqlDataAdapter(cmd)
        'cargamos el formulario  resumen
        da.Fill(dt)
        cgrillacorte.DataSource = dt
        'al dar clic al boton que se cargue todo lo vendido de papeleria y de servicios en la fecha seleccionada.
        conexionMysql.Close()
    End Function
    Function desgloseventas()
        Dim fechacompleta As String

        fechacompleta = calendario.SelectionRange.Start.ToString("yyyy/MM/dd")
        cerrarconexion()
        'MsgBox(fechacompleta)
        conexionMysql.Open()
        Dim Sql As String
        'Sql = "SELECT * FROM venta,ventaind where venta.idventa=ventaind.idventaind and fecha='" & fechacompleta & "';"
        '        Sql = "select venta.idventa, ventaind.idventaind,tipoventa.tipoventa, ventaind.idproducto, ventaind.actividad, ventaind.cantidad, ventaind.costo,(ventaind.cantidad * ventaind.costo) as Total, venta.anticipo,venta.resto, venta.hora from ventaind, venta,tipoventa where ventaind.idventa = venta.idventa and venta.tipoventa=tipoventa.idtipoventa and fecha='" & fechacompleta & "';"
        Sql = "select venta.idventa, ventaind.idventaind, ventaind.actividad, ventaind.cantidad, ventaind.costo,(ventaind.cantidad * ventaind.costo) as Total, ventaind.idproducto, venta.hora,venta.fecha from ventaind, venta where ventaind.idventa = venta.idventa and fecha='" & fechacompleta & "';"

        'Sql = "select venta.idventa, ventaind.idventaind, ventaind.actividad, ventaind.cantidad, ventaind.costo,(ventaind.cantidad * ventaind.costo) as Total, servicios_ventas.anticipo, ventaind.idproducto, venta.hora,venta.fecha from ventaind, venta, servicios_ventas where ventaind.idventa = venta.idventa and venta.idventa= servicios_ventas.idventa and venta.fecha='" & fechacompleta & "';"
        'Sql = "select venta.idventa, ventaind.idventaind, tipoventa.tipoventa, ventaind.actividad, ventaind.cantidad, ventaind.costo,(ventaind.cantidad * ventaind.costo) as Total, servicios_ventas.anticipo, ventaind.idproducto, venta.hora,venta.fecha from tipoventa, ventaind, venta, servicios_ventas where ventaind.idventa = venta.idventa and venta.idventa= servicios_ventas.idventa and venta.tipoventa = tipoventa.idtipoventa and venta.fecha='" & fechacompleta & "';"
        'Sql = "select venta.idventa, ventaind.idventaind, ventaind.actividad, ventaind.cantidad, ventaind.costo,(ventaind.cantidad * ventaind.costo) as Total, servicios_ventas.anticipo, ventaind.idproducto, venta.hora,venta.fecha from servicios_ventas, ventaind, venta where ventaind.idventa = venta.idventa  and venta.fecha='" & fechacompleta & "';"

        Dim cmd As New MySqlCommand(Sql, conexionMysql)
        Dim dt As New DataTable
        Dim da As New MySqlDataAdapter(cmd)
        'cargamos el formulario  resumen
        da.Fill(dt)
        cgrillacorte.DataSource = dt
        'al dar clic al boton que se cargue todo lo vendido de papeleria y de servicios en la fecha seleccionada.
        conexionMysql.Close()

    End Function

    Private Sub Button35_Click(sender As Object, e As EventArgs)
        'boton para agregar un nuevo proveedor

    End Sub

    Private Sub Button36_Click(sender As Object, e As EventArgs) Handles Button36.Click
        If protxtnombreproveedor.Text = "" Or protxtnombrep.Text = "" Or protxtap.Text = "" Or protxtam.Text = "" Or protxtciudad.Text = "" Or protxtestado.Text = "" Or protxttelefono.Text = "" Or protxtcorreo.Text = "" Then
            MsgBox("Hay campos vacios, verifica", MsgBoxStyle.Information, "Sistema")
        Else
            Dim resultado As Integer

            Try

                cerrarconexion()

                'comprobamos que no exista otro usuario con la misma información
                conexionMysql.Open()
                Dim sql1 As String
                sql1 = "select idproveedor from proveedor where nombre_encargado ='" & protxtnombrep.Text & "' and ap_encargado='" & protxtap.Text & "' and am_encargado='" & protxtam.Text & "';"
                Dim cmd1 As New MySqlCommand(sql1, conexionMysql)
                reader = cmd1.ExecuteReader
                reader.Read()
                resultado = reader.GetString(0).ToString()
            Catch ex As Exception
                resultado = 0
            End Try


            'MsgBox(resultado)

            If resultado <> 0 Then

                MsgBox("Ya existe un registro con  el mismo nombre, verifica la información", MsgBoxStyle.Exclamation, "Sistema")
            Else

                cerrarconexion()

                Try

                    'BOTON AGREGAR CLIENTE
                    conexionMysql.Open()
                    Dim Sql As String
                    Sql = "INSERT INTO proveedor (nombre_empresa, nombre_encargado, ap_encargado, am_encargado, ciudad, estado, telefono, correo) VALUES ('" & protxtnombreproveedor.Text & "', '" & protxtnombrep.Text & "', '" & protxtap.Text & "', '" & protxtam.Text & "', '" & protxtciudad.Text & "', '" & protxtestado.Text & "', '" & protxttelefono.Text & "', '" & protxtcorreo.Text & "');"
                    Dim cmd As New MySqlCommand(Sql, conexionMysql)
                    cmd.ExecuteNonQuery()
                    'limpiamos los campos de cliente.
                    limpiarproveedor()
                    conexionMysql.Close()
                    MsgBox("Proveedor registrado", MsgBoxStyle.Information, "Sistema")
                    llenadoproveedor()

                Catch ex As Exception
                    tipoingreso()
                    comprobartipoingreso()

                End Try

            End If

        End If

    End Sub

    Private Sub Button39_Click(sender As Object, e As EventArgs) Handles Button39.Click
        If protxtid.Text = "" Then
            MsgBox("Al parecer no haz seleccionado un proveedor", MsgBoxStyle.Information, "Sistema")
        Else

            Try
                cerrarconexion()

                conexionMysql.Open()
                Dim sql2 As String
                sql2 = "delete from proveedor where idproveedor=" & protxtid.Text & ";"
                Dim cmd2 As New MySqlCommand(sql2, conexionMysql)

                cmd2.ExecuteNonQuery()
                conexionMysql.Close()
                MsgBox("Proveedor eliminado", MsgBoxStyle.Information, "Sistema")
                llenadoproveedor()
                limpiarproveedor()


            Catch ex As Exception
                comprobartipoingreso()
            End Try
        End If

    End Sub
    Function limpiarproveedor()
        protxtid.Text = ""
        protxtnombreproveedor.Text = ""
        protxtnombrep.Text = ""
        protxtam.Text = ""
        protxtap.Text = ""
        protxtciudad.Text = ""
        protxtestado.Text = ""
        protxttelefono.Text = ""
        protxtcorreo.Text = ""

    End Function

    Private Sub Button40_Click(sender As Object, e As EventArgs) Handles Button40.Click
        If protxtid.Text = "" Then
            MsgBox("Al parecer no haz seleccionado un proveedor", MsgBoxStyle.Information, "Sistema")
        Else

            Try
                cerrarconexion()
                conexionMysql.Open()
                Dim sql2 As String
                sql2 = "update proveedor set nombre_empresa='" & protxtnombreproveedor.Text & "', nombre_encargado='" & protxtnombrep.Text & "', ap_encargado='" & protxtap.Text & "', am_encargado='" & protxtam.Text & "', ciudad='" & protxtciudad.Text & "', estado='" & protxtestado.Text & "', telefono='" & protxttelefono.Text & "', correo='" & protxtcorreo.Text & "' where idproveedor=" & protxtid.Text & ";"
                Dim cmd2 As New MySqlCommand(sql2, conexionMysql)
                cmd2.ExecuteNonQuery()
                conexionMysql.Close()
                MsgBox("Proveedor Actualizado", MsgBoxStyle.Information, "Sistema")
                llenadoproveedor()
                limpiarproveedor()

            Catch ex As Exception
                comprobartipoingreso()
                'MsgBox("Al parecer tienes ventas con este cliente, no se puede eliminar", MsgBoxStyle.Information, "Sistema")
            End Try
        End If
    End Sub
    Function llenadoproveedor()
        protxtgrilla.DefaultCellStyle.Font = New Font("Arial", 20)
        protxtgrilla.RowHeadersVisible = False
        'ampliar columna 
        'grillap.Columns(2).Width = 120


        protxtgrilla.AlternatingRowsDefaultCellStyle.BackColor = Color.SkyBlue

        Try



            cerrarconexion()

            conexionMysql.Open()
            Dim sql As String
            sql = "select * from proveedor"
            Dim cmd As New MySqlCommand(sql, conexionMysql)
            Dim dt As New DataTable
            Dim da As New MySqlDataAdapter(cmd)
            'cargamos el formulario  resumen
            da.Fill(dt)
            protxtgrilla.DataSource = dt
            'ugrilla.Columns(1).Width = 350
            'ugrilla.Columns(0).Width = 60
            conexionMysql.Close()
        Catch ex As Exception
            MsgBox("Error del sistema", MsgBoxStyle.Exclamation, "Sistema")
        End Try

    End Function

    Private Sub Button38_Click(sender As Object, e As EventArgs) Handles Button38.Click
        llenadoproveedor()
    End Sub

    Private Sub protxtgrilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles protxtgrilla.CellContentClick
        ' Try

        Dim Variable As Integer = protxtgrilla.Item(0, protxtgrilla.CurrentRow.Index).Value
        'MsgBox(Variable)
        cerrarconexion()


        conexionMysql.Open()
        Dim sql As String
        sql = "select * from proveedor where idproveedor =" & Variable & ";"
        Dim cmd As New MySqlCommand(sql, conexionMysql)
        reader = cmd.ExecuteReader
        reader.Read()
        protxtid.Text = reader.GetString(0).ToString()
        protxtnombreproveedor.Text = reader.GetString(1).ToString()
        protxtnombrep.Text = reader.GetString(2).ToString()
        protxtap.Text = reader.GetString(3).ToString()
        protxtam.Text = reader.GetString(4).ToString()
        protxtciudad.Text = reader.GetString(5).ToString()
        protxtestado.Text = reader.GetString(6).ToString()
        protxttelefono.Text = reader.GetString(7).ToString()
        protxtcorreo.Text = reader.GetString(8).ToString()

        conexionMysql.Close()

        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub Button37_Click(sender As Object, e As EventArgs) Handles Button37.Click
        'maximizar una venta
        'Me.WindowState = FormWindowState.Maximized
        Me.Size = My.Computer.Screen.WorkingArea.Size
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        'Me.Location = New System.Drawing.Point(0, 0)

    End Sub

    Private Sub Button35_Click_1(sender As Object, e As EventArgs) Handles Button35.Click
        'minimizar la ventana
        Me.WindowState = FormWindowState.Minimized

    End Sub

    Private Sub Button41_Click(sender As Object, e As EventArgs) Handles Button41.Click
        Me.Size = New System.Drawing.Size(1359, 699)


        '----------------------------------------------------------
        '1285,711 'esta es la medida antetior...
        '-------------------------------------------------------

        Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2

        'Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
        Me.StartPosition = FormStartPosition.CenterScreen
        'Me.Top = 0
        'Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
    End Sub

    Private Sub TabPage4_Click(sender As Object, e As EventArgs) Handles TabPage4.Click

    End Sub

    Private Sub grillap_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grillap.CellContentClick

    End Sub

    Private Sub grillap_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grillap.CellDoubleClick
        Try

            Dim Variable As Integer = grillap.Item(0, grillap.CurrentRow.Index).Value
            'MsgBox(Variable)
            txtclavep.Text = Variable
            grilla2p.Visible = False
            grillap.Visible = True
            rbclavep.Checked = True

        Catch ex As Exception

        End Try
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

    Private Sub Button42_Click(sender As Object, e As EventArgs)
        'se consulta el corte y se desglosa el total de ventas por todos los cortes que se hallan hecho.

        desglosecortecalendario()
        consultarcortecalendario()

    End Sub

    Private Sub lbfolio_Click(sender As Object, e As EventArgs) Handles lbfolio.Click


    End Sub

    Private Sub lbfolio_DoubleClick(sender As Object, e As EventArgs) Handles lbfolio.DoubleClick
        'al dar doble clic sobre el boton de folio que habra una ventana para poder buscar las ventas hechas por ese folio, poder eliminarlas
        'o escribir alguna observación.

    End Sub

    Private Sub Button34_ClientSizeChanged(sender As Object, e As EventArgs)

    End Sub


    Private Sub cbtncompras_Click(sender As Object, e As EventArgs)
        desglosecompras()
    End Sub
    Function idcompramercangia()
        cerrarconexion()
        Try

            conexionMysql.Open()

            Dim sql As String
            Dim idvalor, idfinal As Integer
            sql = "select max(idcompra) as maximo from compramercancia;"
            Dim cmd As New MySqlCommand(sql, conexionMysql)
            reader = cmd.ExecuteReader
            reader.Read()
            idvalor = reader.GetString(0).ToString()
            idfinal = idvalor + 1
            btnidcompramercancia.Text = idfinal
            conexionMysql.Close()
        Catch ex As Exception
            MsgBox("Al parecer es tu primera compra de mercancia, vamos a generar tu primer id", MsgBoxStyle.Information, "Sistema")
            btnidcompramercancia.Text = 1
        End Try

    End Function

    Private Sub rbgastosmercancia_CheckedChanged(sender As Object, e As EventArgs) Handles rbgastosmercancia.CheckedChanged
        If rbgastosmercancia.Checked = True Then


            Button56.Visible = True
            Button50.Visible = True
            Button51.Visible = True


            cgrilla.Visible = False
            ccgrilla.Visible = True
            cccgrilla.Visible = False


            gb1.Visible = False
            gb2.Visible = True
            ctxtcomprado.Text = ""
            listaproductos.Visible = False
            'cgrilla.Rows.Clear()
            GroupBox24.Visible = True
            GroupBox17.Visible = False
            Button64.Visible = True
            Button64.Enabled = False

            'obtenemos un ID para la nueva compra de mercancia
            btnidcompramercancia.Visible = True

            idcompramercangia()
            chimpresioncompra.Visible = True


        End If


    End Sub

    Private Sub rbgastosdiarios_CheckedChanged(sender As Object, e As EventArgs) Handles rbgastosdiarios.CheckedChanged
        If rbgastosdiarios.Checked = True Then

            cgrilla.Visible = True
            ccgrilla.Visible = False
            'escondemos los botones de buscar, agregar y comprar
            Button56.Visible = False
            Button50.Visible = False
            Button51.Visible = False
            Button64.Visible = False


            gb1.Visible = True
            gb2.Visible = False
            ctxtcomprado.Text = consultacompras()
            comprasdeldia()
            btnidcompramercancia.Visible = False
            GroupBox24.Visible = False
            chimpresioncompra.Visible = False
            GroupBox17.Visible = True


        End If
    End Sub

    Private Sub ctxtdescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ctxtdescripcion.KeyPress

        'If e.KeyCode = Keys.Escape Then
        '    Me.Close()
        'End If
    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles ctxtdescripcion.TextChanged


        'If cbnuevoproducto.Checked = True Then
        'Else
        '    ctxtid.Text = ""

        'End If


        'If ctxtdescripcion.Text = "" Then


        '    listaproductos.Visible = False
        'Else





        '    listaproductos.Visible = True
        '    listaproductos.Items.Clear()


        '    'cerramos la conexion
        '    cerrarconexion()

        '    Dim cantidad, i As Integer
        '    cantidad = 0
        '    conexionMysql.Open()
        '    Dim Sql2 As String
        '    Sql2 = "select count(*) from producto where descripcion like '%" & ctxtdescripcion.Text & "%';"
        '    Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
        '    reader = cmd2.ExecuteReader
        '    reader.Read()
        '    cantidad = reader.GetString(0).ToString

        '    'cargamos el formulario  resumen
        '    conexionMysql.Close()

        '    'MsgBox("hay tantos resultados:" & cantidad)
        '    If cantidad = 0 Then
        '        listaproductos.Visible = False
        '        cbnuevoproducto.Checked = True

        '    Else
        '        listaproductos.Visible = True

        '    End If

        '    cerrarconexion()
        '    conexionMysql.Open()
        '    Dim Sql As String
        '    Sql = "select descripcion as nombre from producto where descripcion like '%" & ctxtdescripcion.Text & "%';"
        '    Dim cmd As New MySqlCommand(Sql, conexionMysql)
        '    reader = cmd.ExecuteReader
        '    For i = 1 To cantidad
        '        reader.Read()

        '        listaproductos.Items.Add(reader.GetString(0).ToString)
        '    Next


        '    conexionMysql.Close()
        '    'Catch ex As Exception

        '    'End Try

        'End If

    End Sub

    Private Sub listaproductos_DoubleClick(sender As Object, e As EventArgs) Handles listaproductos.DoubleClick
        ' seleccionproducto()
    End Sub
    Function seleccionproducto()
        'Try

        'ctxtdescripcion.Text = listaproductos.Text
        'listaproductos.Visible = False
        'Dim valorproveedor As Integer

        ''desactivamos el checked del generador de id.
        'cbnuevoproducto.Checked = False
        ''ponemos en blanco el id del producto
        'ctxtid.Text = ""
        'ctxtid.Enabled = False


        'cerrarconexion()
        'conexionMysql.Open()
        'Dim Sql As String
        'Sql = "select * from producto where descripcion='" & ctxtdescripcion.Text & "';"
        'Dim cmd As New MySqlCommand(Sql, conexionMysql)
        'reader = cmd.ExecuteReader
        'reader.Read()
        'ctxtid.Text = reader.GetString(0).ToString()
        'ctxtdescripcion.Text = reader.GetString(1).ToString()
        'ctxtcantidadactual.Text = reader.GetString(2).ToString()
        'ctxtcostomercancia.Text = reader.GetString(3).ToString()
        'ctxtpreciopublico.Text = reader.GetString(4).ToString()
        'valorproveedor = reader.GetString(6).ToString()





        'conexionMysql.Close()
        ''Catch ex As Exception

        'Dim valor As String
        '    cerrarconexion()
        'conexionMysql.Open()
        'Dim Sql3 As String
        'Sql3 = "select * from proveedor where idproveedor=" & valorproveedor & ";"
        'Dim cmd3 As New MySqlCommand(Sql3, conexionMysql)
        'reader = cmd3.ExecuteReader()
        'reader.Read()
        'valor = reader.GetString(1).ToString()

        'conexionMysql.Close()

        'cbproveedorcompras.Text = valor


        'Catch ex As Exception

        'End Try


    End Function

    Private Sub listaproductos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles listaproductos.KeyPress
        If e.KeyChar = Chr(13) Then
            seleccionproducto()
        End If
    End Sub
    Private Sub listaproductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listaproductos.SelectedIndexChanged

    End Sub

    Private Sub listaclientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listaclientes.SelectedIndexChanged

    End Sub

    Private Sub cbnuevoproducto_CheckedChanged(sender As Object, e As EventArgs)
        'If cbnuevoproducto.Checked = True Then
        '    limpiarcompramercancia()
        '    'en caso de que se active la casilla, que se obtenga un ID automatico para el nuevo producto.
        '    cerrarconexion()
        '    'idfinal almacena el nuevo valor en caso de que sea un producto nuevo
        '    Dim idfinal As Integer
        '    ' Dim existe As Boolean



        '    'si el checket esta activado, habilito el proveedor para que seleccione uno.

        '    cbproveedorcompras.Enabled = True



        '    'MsgBox(idsumado)

        '    'If idsumado = 0 Then
        '    '    idfinal = 1
        '    'Else
        '    '    idfinal = idsumado + 1
        '    'End If

        '    Try

        '        'If idsumado = 1 Then
        '        'idsumado = idsumado + 1

        '        'Else
        '        cerrarconexion()


        '        conexionMysql.Open()
        '        Dim Sql As String
        '        Sql = "select max(idproducto)as maximo from producto;"
        '        Dim cmd As New MySqlCommand(Sql, conexionMysql)
        '        reader = cmd.ExecuteReader
        '        reader.Read()
        '        ctxtid.Text = 1 + CInt(reader.GetString(0).ToString())
        '        'End If

        '        existe = True

        '    Catch ex As Exception

        '        ctxtid.Text = 0
        '        existe = False

        '        'If idsumado = 0 Then

        '        '    MsgBox("Al parece no existe ningun producto, esta será tu primer registro", MsgBoxStyle.Information, "Sistema")

        '        '    ctxtid.Text = 1
        '        '    idsumado = 1
        '        'Else
        '        '    idsumado = idsumado + 1
        '        '    MsgBox(idsumado)
        '        '    ctxtid.Text = idsumado
        '        'End If

        '    End Try
        '    ctxtid.Enabled = False
        '    conexionMysql.Close()
        '    ctxtcantidadactual.Text = 0
        '    ctxtcantidadactual.Enabled = False


        'Else

        '    'llamamos a limpiar las cajas de texto
        '    'limpiarcompramercancia()
        '    ctxtid.Enabled = True

        '    ctxtid.Text = ""
        '    ctxtcantidadactual.Text = ""
        '    cbproveedorcompras.Enabled = False


        'End If
    End Sub
    Function limpiarcompramercancia()
        ctxtid.Text = ""
        ctxtdescripcion.Text = ""
        ctxtcantidadproductos.Text = ""
        ctxtcantidadactual.Text = ""
        ctxtcostomercancia.Text = ""
        ctxtcostototalmercancia.Text = ""
        ctxtpreciopublico.Text = ""
        ctxtcostototalmercancia.Text = ""
        ctxtcostomercancia.Text = ""
        'txtpreciopaquete.Text = ""
        ' txtcantidadpaquete.Text = ""



    End Function



    Private Sub Button53_Click(sender As Object, e As EventArgs)
        abrir.DefaultExt = "sql"
        Dim pathmysql As String
        Dim comando As String
        Dim arg As String
        abrir.Filter = "File MYSQL (*.sql)|*.sql"
        'pathmysql = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MySQL AB\MYSQL Server 5.5", "Location", 0)
        pathmysql = "C:\Program Files\MySQL\MySQL Server 5.5"
        If pathmysql = Nothing Then
            MsgBox("No se encontro en tu equipo Mysql, escoge la carpeta donde esta ubicado")
            carpeta.ShowDialog()
            pathmysql = carpeta.SelectedPath
        End If

        If abrir.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'Try

            comando = pathmysql & "\bin\mysql.exe"
            comando.Replace("\\", "\")
            arg = " --user=root --password=conexion --host=localhost --database dwin < " & Chr(34) & abrir.FileName & Chr(34)
            Dim proceso As New Process
            proceso.StartInfo.FileName = "cmd.exe"
            proceso.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            proceso.StartInfo.UseShellExecute = False
            proceso.StartInfo.RedirectStandardOutput = True
            proceso.StartInfo.RedirectStandardInput = True
            proceso.StartInfo.CreateNoWindow = True
            proceso.Start()
            Dim escribeconsola As StreamWriter = proceso.StandardInput
            Dim leyendoconsola As StreamReader = proceso.StandardOutput
            escribeconsola.WriteLine(comando & arg)
            escribeconsola.Close()
            proceso.WaitForExit()
            proceso.Close()
            MsgBox("Tu sistema ahora tiene vida...", MsgBoxStyle.Information, "Sistema")
        End If
    End Sub

    Private Sub Button52_Click_1(sender As Object, e As EventArgs) Handles Button52.Click
        respaldar.DefaultExt = "sql"
        Dim pathmysql As String
        Dim comando As String
        'pathmysql = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MySQL AB\MYSQL Server 5.5", "Location", 0)
        pathmysql = "C:\Program Files\MySQL\MySQL Server 5.5"
        If pathmysql = Nothing Then
            MsgBox("No se encontro en tu equipo Mysql, escoge la carpeta donde esta ubicado")
            carpeta.ShowDialog()
            pathmysql = carpeta.SelectedPath
        End If
        respaldar.Filter = "File MYSQL (*.sql)|*.sql"
        If respaldar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Try

                Dim contra As String
                'Call InputBox_Password(frmindex, "*")
                contra = InputBox("Ingresa la contraseña del administrador", "CTRL+Y")

                comando = pathmysql & "\bin\mysqldump --user=root --password=" & contra & " --databases dwin --routines -r """ & respaldar.FileName & """"
                Shell(comando, AppWinStyle.MinimizedFocus, True)
                MsgBox("Se realizo el respaldo correctamente", MsgBoxStyle.Information, "Sistema")
            Catch ex As Exception
                MsgBox("Ocurrio un error al respaldar", MsgBoxStyle.Critical, "Informacion")
            End Try

        End If

    End Sub

    Private Sub cbttotales_Click(sender As Object, e As EventArgs)

    End Sub
    Function compramercanciaagregargrilla()
        ccgrilla.DefaultCellStyle.Font = New Font("Arial", 20)
        ccgrilla.RowHeadersVisible = False




        'grilla.Columns(0).Width = 0
        ccgrilla.AlternatingRowsDefaultCellStyle.BackColor = Color.SkyBlue



        If cbproveedorcompras.Text = "" Or ctxtid.Text = "" Or ctxtdescripcion.Text = "" Or ctxtcantidadproductos.Text = "" Or ctxtcostomercancia.Text = "" Or ctxtpreciopublico.Text = "" Or ctxtcostototalmercancia.Text = "" Then

            MsgBox("Falta información para agregar", MsgBoxStyle.Exclamation, "Sistema")

        Else


            'agregamos el producto a la grilla para podr realizar la insercion. 
            agregargillacompra()


            sumatoriocompra()
            '---------------------- en caso de que sea un nuevo articulo, tomo el valo y agrego un nuevo valor para poder saber que id llevo-------------------
            'If cbnuevoproducto.Checked = True Then

            'idsumado = 1
            'despues de agregar, que se desactive la casilla para poder conocer un nuevo valor.
            'cbnuevoproducto.Checked = False
            'MsgBox(idsumado)
            'End If



        End If
    End Function
    Private Sub Button50_Click(sender As Object, e As EventArgs) Handles Button50.Click
        compramercanciaagregargrilla()

    End Sub

    Function agregargillacompra()
        If cbproveedorcompras.Text = "" Or ctxtid.Text = "" Or ctxtdescripcion.Text = "" Or ctxtcantidadproductos.Text = "" Or ctxtcostomercancia.Text = "" Or ctxtpreciopublico.Text = "" Or ctxtcostototalmercancia.Text = "" Then

            MsgBox("No hay productos que agregar", MsgBoxStyle.Information, "Sistema")
            cgrilla.Visible = False

        Else


            'obtengo el id del proveedor, para poder agregarlo


            Dim i As Integer = ccgrilla.RowCount

            ccgrilla.Rows.Add(ctxtid.Text, ctxtdescripcion.Text, ctxtcantidadproductos.Text, ctxtcostomercancia.Text, ctxtpreciopublico.Text, ctxtcostototalmercancia.Text, cbproveedorcompras.Text)
            ccgrilla.Columns(1).Width = 350

            'se hace la operacion de sumar todos los valores de la grilla
            sumatoriocompra()
            'se borran los productos de las cajas de texto
            limpiarcompramercancia()

            ctxtid.Focus()
        End If
    End Function
    Function sumatoriocompra()
        Try

            Dim i As Integer = ccgrilla.RowCount

            Dim j As Integer
            Dim suma, cantidad_productos As Double
            Dim a, b As String
            'suma de valores
            For j = 0 To i - 2
                'MsgBox("valosr de j:" & j)
                'a = venta.grillaventa.Item(j, 3).Value.ToString()
                a = ccgrilla.Rows(j).Cells(5).Value
                b = ccgrilla.Rows(j).Cells(2).Value
                cantidad_productos = cantidad_productos + b
                suma = suma + a
                'MsgBox(a)
            Next
            Dim final, riva As Double
            compratxtsubtotal.Text = suma
            riva = CDbl(compratxtsubtotal.Text) * CDbl(compratxtiva.Text)
            compratxtivatotal.Text = Math.Round(riva, 2)
            final = CDbl(compratxtsubtotal.Text) + CDbl(compratxtivatotal.Text)
            ctxtcomprado2.Text = Math.Round(final, 2)
            'txtunidades.Text = cantidad_productos
        Catch ex As Exception

        End Try


    End Function

    Private Sub ctxtcantidadproductos_TextChanged(sender As Object, e As EventArgs) Handles ctxtcantidadproductos.TextChanged
        calculototalcompraproducto()
    End Sub

    Function calculototalcompraproducto()
        Try

            ctxtcostototalmercancia.Text = CDbl(ctxtcostomercancia.Text) * CDbl(ctxtcantidadproductos.Text)
        Catch ex As Exception

        End Try

    End Function
    Private Sub ctxtcostomercancia_TextChanged(sender As Object, e As EventArgs) Handles ctxtcostomercancia.TextChanged
        calculototalcompraproducto()
    End Sub
    Function existeidproducto(ByVal id As String)
        Dim comprobar As Integer

        Try
            ' MsgBox(id)
            cerrarconexion()
            conexionMysql.Open()
            Dim Sql5 As String
            Sql5 = "select idproducto from producto where idproducto='" & id & "';"
            Dim cmd5 As New MySqlCommand(Sql5, conexionMysql)
            reader = cmd5.ExecuteReader()
            reader.Read()

            comprobar = reader.GetString(0).ToString

            conexionMysql.Close()
            Return comprobar
        Catch ex As Exception
            'MsgBox("al parecer no existe el id")
            comprobar = "0"
            Return comprobar
        End Try

    End Function
    Function maximoproducto()
        Dim idmaximo As Integer

        Try
            ' MsgBox(id)
            cerrarconexion()
            conexionMysql.Open()
            Dim Sql5 As String
            Sql5 = "select max(idproducto)as maximo from producto;"
            Dim cmd5 As New MySqlCommand(Sql5, conexionMysql)
            reader = cmd5.ExecuteReader()
            reader.Read()

            idmaximo = reader.GetString(0).ToString

            conexionMysql.Close()
            Return idmaximo
        Catch ex As Exception
            MsgBox("al parecer no existe el id")
            idmaximo = 0
            Return idmaximo
        End Try

    End Function
    Function insertarproducto(ByVal id As Integer, ByVal actividad As String, ByVal cantidad As Integer, ByVal costo As Double, ByVal precio As Double, ByVal proveedor As String)
        Dim valorproveedor As Integer
        'primero consulto toda la información del proveedor.
        cerrarconexion()
        conexionMysql.Open()
        Dim Sql3 As String
        Sql3 = "select idproveedor from proveedor where nombre_empresa='" & proveedor & "';"
        Dim cmd3 As New MySqlCommand(Sql3, conexionMysql)
        reader = cmd3.ExecuteReader()
        reader.Read()
        valorproveedor = reader.GetString(0).ToString()

        conexionMysql.Close()



        cerrarconexion()

        conexionMysql.Open()

        Dim sql2 As String
        sql2 = "INSERT INTO producto (idproducto,descripcion, cantidad, costo, precio, preciom, idproveedor) VALUES ('" & id & "', '" & actividad & "', " & cantidad & ", " & costo & ", " & precio & ", " & precio & "," & valorproveedor & ");"
        Dim cmd2 As New MySqlCommand(sql2, conexionMysql)
        cmd2.ExecuteNonQuery()

        conexionMysql.Close()


    End Function
    Function actualizarproducto(ByVal id As String, ByVal actividad As String, ByVal cantidad As Integer, ByVal costo As Double, ByVal precio As Double, ByVal proveedor As String)
        Try

            Dim cantidadconsulta As Integer
            'primero consulto toda la información del proveedor.
            cerrarconexion()
            conexionMysql.Open()
            Dim Sql3 As String
            Sql3 = "select cantidad from producto where idproducto='" & id & "';"
            Dim cmd3 As New MySqlCommand(Sql3, conexionMysql)
            reader = cmd3.ExecuteReader()
            reader.Read()
            cantidadconsulta = reader.GetString(0).ToString()

            conexionMysql.Close()


            Dim cantidadtotal As Integer

            cantidadtotal = cantidad + cantidadconsulta
            ' MsgBox(cantidadtotal)
            cerrarconexion()

            conexionMysql.Open()
            Dim sql2 As String
            sql2 = "UPDATE producto SET cantidad=" & cantidadtotal & ", costo=" & costo & ", precio=" & precio & ", preciom=" & precio & "  WHERE idproducto='" & id & "';"
            Dim cmd2 As New MySqlCommand(sql2, conexionMysql)
            cmd2.ExecuteNonQuery()

            conexionMysql.Close()
            ' MsgBox("Registro actualizado", MsgBoxStyle.Information, "Sistema")

        Catch ex As Exception
            comprobartipoingreso()
        End Try



    End Function
    Function generarcompramercancia()
        Try
            'obtener fecha y hora

            Dim err As Integer
            err = 0

            Dim dia, mes, año, fecha As String
            hora2 = Now.Hour()
            minuto = Now.Minute()
            segundo = Now.Second()

            hora = hora2 & ":" & minuto & ":" & segundo

            dia = Date.Now.Day
            mes = Date.Now.Month
            año = Date.Now.Year
            fecha = año & "-" & mes & "-" & dia


            '----------------------------------------- obtener id de proveedor
            Dim idproveedor As Integer





            'If res <> 0 Then


            ' Try
            cerrarconexion()

            '   conexionMysql.Open()

            Dim C1i As Integer = ccgrilla.RowCount
            'C1i = C1i - 1

            If C1i <= 1 Then
                MsgBox("No hay productos por comprar en la lista", MsgBoxStyle.Information, "Sistema")
            Else
                'MsgBox(C1i)

                ' MsgBox("en la grilla hya para vender:" & C1i)

                Dim C1j As Integer
                Dim C1actividad, c1proveedor As String
                Dim C1cantidad, C1costo, c1precio, preciopaquete As Double
                Dim c1idcompra As String
                Dim idcontadordeid, cantidadpaquete As Integer
                idcontadordeid = 0
                'MsgBox(C1i)
                'suma de valores
                For C1j = 0 To C1i - 2
                    'MsgBox("valosr de j:" & C1j)
                    'a = venta.grillaventa.Item(j, 3).Value.ToString()
                    c1idcompra = ccgrilla.Rows(C1j).Cells(0).Value 'iddelproducto
                    C1actividad = ccgrilla.Rows(C1j).Cells(1).Value 'descripcion
                    C1cantidad = ccgrilla.Rows(C1j).Cells(2).Value 'cantidad
                    C1costo = ccgrilla.Rows(C1j).Cells(3).Value 'costo
                    c1precio = ccgrilla.Rows(C1j).Cells(4).Value 'costo
                    c1proveedor = ccgrilla.Rows(C1j).Cells(6).Value
                    'preciopaquete = ccgrilla.Rows(C1j).Cells(7).Value
                    'cantidadpaquete = ccgrilla.Rows(C1j).Cells(8).Value


                    '    MsgBox("vamos en la vuelta numero:" & C1j)

                    'MsgBox("y el id del producto es:" & c1idcompra)
                    Dim valormaximo As Integer
                    Dim respuestas As String


                    'comprobados si el ID del producto ya existe, en caso de que exista, solamente vamos a actualizar el registro.
                    respuestas = existeidproducto(c1idcompra)

                    ''If respuestas = "0" Then
                    'MsgBox("El producto no existe, vamos a guardarlo como nuevo")
                    'en caso de que sea cero, significa que no existe
                    ''If c1idcompra = "0" Then
                    ''c1idcompra = 1
                    ''End If
                    '--------------checamos cual es el maximo id existente y ya despues insertamos el nuevo valor
                    'If existe = False Then
                    ''valormaximo = maximoproducto()
                    ''MsgBox("El maximo id de productos es:" & valormaximo)



                    ''idcontadordeid = valormaximo + CInt(c1idcompra)

                    'MsgBox("ya sumandole 1 es igual a :" & idcontadordeid)

                    'Else
                    '   idcontadordeid = c1idcompra

                    'End If
                    'MsgBox(idcontadordeid)


                    ''insertarproducto(idcontadordeid, C1actividad, C1cantidad, C1costo, c1precio, c1proveedor)
                    '  ccgrilla.Rows.Clear()

                    ''Else
                    'en caso de que sea lo contrario, si existe y es necesario actualizar.
                    'MsgBox("El producto ya existe vamos a actualizarlo")

                    'idcontadordeid = c1idcompra
                    actualizarproducto(c1idcompra, C1actividad, C1cantidad, C1costo, c1precio, c1proveedor)


                    'ccgrilla.Rows.Clear()

                    'End If

                    'en cada vuelta, generamos un id de compra y vamos insertandolo.

                    cerrarconexion()
                    conexionMysql.Open()

                    Dim Sql22 As String
                    err = 1
                    Sql22 = "INSERT INTO `dwin`.`compramercancia` (`idcompra`, `idproducto`, `costo`, `cantidad`, `fecha`, `hora`,`totalcompra`) VALUES (" & btnidcompramercancia.Text & ", '" & c1idcompra & "', " & C1costo & ", " & C1cantidad & ", '" & fecha & "', '" & hora & "','" & ctxtcomprado2.Text & "');"
                    Dim cmd22 As New MySqlCommand(Sql22, conexionMysql)
                    cmd22.ExecuteNonQuery()
                    conexionMysql.Close()
                Next
                MsgBox("Transferencia completa", MsgBoxStyle.Information, "Sistema")
                limpiarcompramercancia()
                borrarcompra()
                ctxtcomprado2.Text = ""




                Dim formulario As New FRNOTACOMPRAMERCANCIA
                formulario.ShowDialog()

                'ctxtcostomercancia.Text = ""
                'ctxtcostototalmercancia.Text = ""
                'If chimpresioncompra.Checked = True Then


                'End If


                'al final solo eliminamos todos de la lista
                ccgrilla.Rows.Clear()



                'obtenemos un nuevo ide para la nueva compra de mercancia

                idcompramercangia()

                'limpiamos la caja de texto que almacena el total a comprar.
                ctxtcomprado.Text = ""



            End If


            '    '------------------ FIN insertar reginstro en tabla ventaIND ---------------------------------------
        Catch ex As Exception
            MsgBox("Existe un problema al generar la venta", MsgBoxStyle.Exclamation, "Sistema")

        End Try

    End Function
    Private Sub Button51_Click(sender As Object, e As EventArgs) Handles Button51.Click
        'boton para guardar lo comprado a proveedores
        generarcompramercancia()

    End Sub

    Private Sub Button49_Click(sender As Object, e As EventArgs)
        Dim cantidadtotal As Double

        cantidadtotal = CDbl(ctxtcantidadactual.Text) + CDbl(ctxtcantidadproductos.Text)
        MsgBox(cantidadtotal)

    End Sub

    Private Sub TabPage3_Click(sender As Object, e As EventArgs) Handles TabPage3.Click

    End Sub

    Private Sub Button45_Click(sender As Object, e As EventArgs)

        'CODIGO DE BOTON ELIMINADO, CREO QUE ES UN REPORTE DE.....
        Try



            cargardatosrptcortedia()
            imprimircortedia()

            ' Dim formventas As New frventas
            ' formventas.Show()
        Catch ex As Exception
            MsgBox("Existe un problema al generar el reporte", MsgBoxStyle.Exclamation, "Sistema")
        End Try


    End Sub

    Private Sub Button44_Click(sender As Object, e As EventArgs)
        Dim fecha As Date
        fecha = calendario.SelectionRange.Start.ToString("yyyy/MM/dd")
        '  Frcortes.Show()

    End Sub

    Private Sub Button46_Click(sender As Object, e As EventArgs) Handles Button46.Click
        Dim formulario As New FRinventario
        formulario.ShowDialog()
        'FRproductos.Show()

    End Sub

    Private Sub Button49_Click_1(sender As Object, e As EventArgs) Handles Button49.Click

        If rptid.Text = "" Then
            MsgBox("Ingresa un ID valido", MsgBoxStyle.Exclamation, "Sistema")
        Else

            Dim formulario As New FRNOTAVENTAREIMPRESION
            formulario.ShowDialog()


            'cargardatosnotaventa2()
            'imprimirnotaventa2()

            '   FReventa.Show()

        End If


    End Sub

    Private Sub GroupBox18_Enter(sender As Object, e As EventArgs) Handles GroupBox18.Enter

    End Sub

    Private Sub Button53_Click_1(sender As Object, e As EventArgs) Handles Button53.Click


        Try

            If ctxttiposervicio.Text = "" Then
                MsgBox("Ingresa un dato valido", MsgBoxStyle.Information, "Sistema")
            Else

                cerrarconexion()
                'consultamos que no exista el servicio
                Dim tiposervicio As String
                tiposervicio = ""
                Try
                    conexionMysql.Open()
                    Dim Sql6 As String
                    'consultamos cuantos registros se insertaros para posteriormente actualizarlos en su registro original
                    Sql6 = "select tipo from tipoproducto where tipo='" & ctxttiposervicio.Text & "';"
                    Dim cmd6 As New MySqlCommand(Sql6, conexionMysql)
                    reader = cmd6.ExecuteReader()

                    reader.Read()
                    'guardamos los valores en una matriz
                    tiposervicio = reader.GetString(0).ToString()
                    conexionMysql.Close()
                Catch ex As Exception
                End Try



                If tiposervicio <> "" Then
                    MsgBox("El servicio ya existe", MsgBoxStyle.Exclamation, "Sistema")
                Else
                    'insertamos el nuevo registro
                    cerrarconexion()
                    conexionMysql.Open()

                    Dim Sql2 As String
                    Sql2 = "INSERT INTO tipoproducto(tipo) VALUES ('" & ctxttiposervicio.Text & "');"
                    Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
                    cmd2.ExecuteNonQuery()
                    conexionMysql.Close()
                    MsgBox("Servicio Guardado", MsgBoxStyle.Information, "Sistema")

                    ctxttiposervicio.Text = ""




                End If



            End If

        Catch ex As Exception
            MsgBox("Upsss, tenemos un problema al guardar tu servicio", MsgBoxStyle.Exclamation, "Sistema")
        End Try


    End Sub

    Private Sub txtproveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtproveedor.SelectedIndexChanged

    End Sub
    'Function impresionticket()
    '    parametro1.ParameterValueType = ParameterValueKind.NumberParameter
    '    'parametro2.ParameterValueType = ParameterValueKind.StringParameter
    '    'se indica el nombre del parametro del procedimiento almacenado
    '    parametro1.ParameterFieldName = "clave"
    '    'parametro2.ParameterFieldName = "nom"

    '    'se indica el valor que va a tomar el parametro
    '    myDiscretevalue.Value = CInt(lbfolio.Text)
    '    'm() 'yDiscretevalue2.Value = CStr(TextBox2.Text)
    '    'MsgBox(frmindex.lbfolio.Text)
    '    parametro1.CurrentValues.Add(myDiscretevalue)
    '    'parametro2.CurrentValues.Add(myDiscretevalue2)

    '    parametros.Add(parametro1)
    '    'parametros.Add(parametro2)

    '    'CrystalReportViewer1.ParameterFieldInfo = parametros
    '    ' Dim infox As New CRventaticket
    '    'infox.ParameterFieldInfo = parametros
    '    'CrystalReportViewer1.ReportSource = infox

    '    'CrystalReportViewer1.ReportSource = infcrystalReports1
    '    '--- CrystalReportViewer1.PrintReport()

    '    Dim impresorapredeterminada As String
    '    impresorapredeterminada = impresoradefault()

    '    'MsgBox(impresorapredeterminada)
    '    'Dim objrptFactura As New CRventaticket
    '    'objrptFactura.PrintOptions.PrinterName = impresorapredeterminada
    '    'objrptFactura.PrintToPrinter(1, False, 0, 0)



    'End Function
    Function impresoradefault()
        Dim instance As New Printing.PrinterSettings

        Dim impresosaPredt As String = instance.PrinterName
        Return impresosaPredt
    End Function

    Private Sub GroupBox4_Enter(sender As Object, e As EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick


    End Sub

    Private Sub Button56_Click(sender As Object, e As EventArgs) Handles Button56.Click
        '--------------------------nuevo sistema
        Dim formulario As New frbuscarcompras
        formulario.ShowDialog()

    End Sub
    Private Sub chpermitircantidad_CheckedChanged(sender As Object, e As EventArgs) Handles chpermitircantidad.CheckedChanged

    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub
    Function borrarcompra()
        ctxtdescripcion.Text = ""
        ctxtcantidadactual.Text = ""
        ctxtcostomercancia.Text = ""
        ctxtpreciopublico.Text = ""
        compratxtsubtotal.Text = ""
        compratxtivatotal.Text = ""

    End Function
    Function buscaridcomprapro()

        Try
            Dim cantidad As Integer

            cerrarconexion()


            conexionMysql.Open()
            Dim Sql As String
            Sql = "select * from producto where idproducto='" & ctxtid.Text & "';"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            reader = cmd.ExecuteReader()
            reader.Read()
            ctxtdescripcion.Text = reader.GetString(1).ToString()
            ctxtcantidadactual.Text = reader.GetString(2).ToString()
            ctxtcostomercancia.Text = reader.GetString(3).ToString()
            ctxtpreciopublico.Text = reader.GetString(4).ToString()

            'txtstock.Text = reader.GetString(2).ToString
            ''si encuentra el valor, llamamos al focus del boton.
            'Button17.Focus()

            reader.Close()

            conexionMysql.Close()


        Catch ex As Exception
            'MsgBox("El producto no existe o no se a podido procesar", MsgBoxStyle.Exclamation, "Sistema")

            ''If conexionMysql.State = ConnectionState.Open Then
            ''conexionMysql.Close()
            'End If
            'Call limpiar()
            borrarcompra()
        End Try

    End Function
    Private Sub ctxtid_TextChanged(sender As Object, e As EventArgs) Handles ctxtid.TextChanged
        buscaridcomprapro()
    End Sub
    Function buscaridcompra()
        If ctxtid.Text = "" Or txtclave.Text = "0" Then
        Else

            Try
                Dim cantidad As Integer

                respuesta = vbYes


                cerrarconexion()


                conexionMysql.Open()
                Dim Sql As String
                Sql = "select * from producto where idproducto='" & txtclave.Text & "';"
                Dim cmd As New MySqlCommand(Sql, conexionMysql)
                reader = cmd.ExecuteReader()
                reader.Read()
                txtactividad.Text = reader.GetString(1).ToString()
                cantidad = reader.GetString(2).ToString()
                txtcosto.Text = reader.GetString(4).ToString()
                txtstock.Text = reader.GetString(2).ToString
                ''si encuentra el valor, llamamos al focus del boton.
                'Button17.Focus()

                reader.Close()

                conexionMysql.Close()



                If cantidad = 1 Then
                    MsgBox("Este es el ultimo producto existente, recuerda adquirir más", MsgBoxStyle.Information, "Sistema")
                ElseIf cantidad = 0 Then
                    respuesta = MsgBox("Ya no hay productos por vender." & vbCrLf & "Para mantener la integridad de la información, primero agrega mas productos", MsgBoxStyle.Exclamation, "Sistema")
                    borrar()

                End If

                'en caso de que quede 1, si se vende, pero si queda 0, depende de la respuesta.

                If respuesta = vbYes Then
                    txtcantidad.Text = 1

                Else
                    txtactividad.Text = ""
                    txtcosto.Text = ""
                    txtcantidad.Text = ""


                End If








                'realizar operacion para obtener el total 

                txttotal.Text = CDbl(txtcantidad.Text) * CDbl(txtcosto.Text)

                MsgBox("verificamo que esten activas las casillas")
                '--------------------IMPORTANTE------------------------------
                'verificamos si la casilla de anexar directo esta activada, entonces, automaticamente llammos a la funcion
                'de agregar a la grilla.

                If chanexar.Checked = True And chpermitircantidad.Checked = False Then
                    MsgBox("solo esta activa la de anexar directo")
                    Dim cantidad_total, cantidadbd As Integer

                    'cantidad total es la cantidad que se va a vender
                    'se le suma 1, porque es el producto que apenas se va anexar a la lista de venta
                    cantidad_total = comprobacion() + txtcantidad.Text


                    'cantidadbd, es la cantidad que existe en la BD del producto

                    cantidadbd = conteoclave()


                    If cantidad_total > cantidadbd Then
                        MsgBox("No hay productos suficientes, no se agregara este producto", MsgBoxStyle.Exclamation, "Sistema")
                        borrar()
                    Else
                        agregargrilla()

                    End If
                    'en caso de que esten activadas las dos, de permitir cantidad y anexar director entonces, que no haga nada, hasta que se cierre 
                    'la ventana de permitircantidad.
                ElseIf chanexar.Checked = True And chpermitircantidad.Checked = True Then
                    MsgBox("estan activadas las dos casillas.")
                    'no hace nada.
                    'solo mandamos a llamar a la ventana de cantidad.
                    '-----------------------NUEVO SISTEMA
                    frcantidad.Show()

                    MsgBox("anexando")


                End If



            Catch ex As Exception
                'MsgBox("El producto no existe o no se a podido procesar", MsgBoxStyle.Exclamation, "Sistema")

                ''If conexionMysql.State = ConnectionState.Open Then
                ''conexionMysql.Close()

                'End If

                Call limpiar()

            End Try
        End If

    End Function

    Private Sub Button57_Click(sender As Object, e As EventArgs)
        '-----------------------NUEVO SISTEMA

        '        prueba.Show()


    End Sub

    Private Sub grilla_KeyDown(sender As Object, e As KeyEventArgs) Handles grilla.KeyDown
        If e.KeyCode = Keys.F1 Then
            venta()

        End If
    End Sub

    Private Sub txttotalpagar_KeyDown(sender As Object, e As KeyEventArgs) Handles txttotalpagar.KeyDown
        If e.KeyCode = Keys.F1 Then
            venta()

        End If
    End Sub

    Private Sub txttotalpagar_TextChanged(sender As Object, e As EventArgs) Handles txttotalpagar.TextChanged

    End Sub

    Private Sub Button54_Click(sender As Object, e As EventArgs) Handles Button54.Click
        'Try
        cerrarconexion()
        conexionMysql.Open()
        Dim Sql6 As String
        Dim idventa As Integer
        'consultamos cuantos registros se insertaros para posteriormente actualizarlos en su registro original
        Sql6 = "select * from venta where idventa=" & txtventaeliminar.Text & ";"
        Dim cmd6 As New MySqlCommand(Sql6, conexionMysql)
        reader = cmd6.ExecuteReader()

        reader.Read()
        'guardamos los valores en una matriz
        idventa = reader.GetString(0).ToString()
        conexionMysql.Close()

        'en caso de que exista el idventa, entonces lo eliminamos.
        cerrarconexion()


        conexionMysql.Open()

        Dim Sql2xx As String
        Sql2xx = "delete from servicios_ventas where idventa=" & txtventaeliminar.Text & ";"
        Dim cmd2xx As New MySqlCommand(Sql2xx, conexionMysql)
        cmd2xx.ExecuteNonQuery()
        conexionMysql.Close()





        conexionMysql.Open()

        Dim Sql2x As String
        Sql2x = "delete from ventaind where idventa=" & txtventaeliminar.Text & ";"
        Dim cmd2x As New MySqlCommand(Sql2x, conexionMysql)
        cmd2x.ExecuteNonQuery()
        conexionMysql.Close()


        conexionMysql.Open()




        Dim Sql2 As String
        Sql2 = "delete from venta where idventa=" & txtventaeliminar.Text & ";"
        Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
        cmd2.ExecuteNonQuery()
        conexionMysql.Close()
        MsgBox("Venta eliminada", MsgBoxStyle.Information, "Sistema")

        txtventaeliminar.Text = ""




        ' Catch ex As Exception
        cerrarconexion()
        comprobartipoingreso()
        'End Try

    End Sub

    Private Sub Button55_Click(sender As Object, e As EventArgs) Handles Button55.Click
        Try
            cerrarconexion()
            conexionMysql.Open()
            Dim Sql6 As String
            Dim idventa As Integer
            'consultamos cuantos registros se insertaros para posteriormente actualizarlos en su registro original
            Sql6 = "select * from compramercancia where idcompra=" & txtcompraeliminar.Text & "; "
            Dim cmd6 As New MySqlCommand(Sql6, conexionMysql)
            reader = cmd6.ExecuteReader()

            reader.Read()
            'guardamos los valores en una matriz
            idventa = reader.GetString(0).ToString()
            conexionMysql.Close()

            'en caso de que exista el idventa, entonces lo eliminamos.
            cerrarconexion()
            conexionMysql.Open()

            Dim Sql2 As String
            Sql2 = "delete from compramercancia where idcompra=" & txtcompraeliminar.Text & ";"
            Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            cmd2.ExecuteNonQuery()
            conexionMysql.Close()
            MsgBox("Compra eliminada", MsgBoxStyle.Information, "Sistema")

            txtventaeliminar.Text = ""




        Catch ex As Exception
            cerrarconexion()
            comprobartipoingreso()
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

    End Sub

    Private Sub ToolTip1_Popup(sender As Object, e As PopupEventArgs) Handles ToolTip1.Popup

    End Sub

    Private Sub GroupBox19_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtcompraeliminar_TextChanged(sender As Object, e As EventArgs) Handles txtcompraeliminar.TextChanged

    End Sub

    Private Sub Label73_Click(sender As Object, e As EventArgs) Handles Label73.Click

    End Sub

    Private Sub GroupBox22_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub TabPage10_Click(sender As Object, e As EventArgs) Handles TabPage10.Click

    End Sub

    Private Sub rptid_TextChanged(sender As Object, e As EventArgs) Handles rptid.TextChanged

    End Sub

    Private Sub Label58_Click(sender As Object, e As EventArgs) Handles Label58.Click

    End Sub

    Private Sub GroupBox7_Enter(sender As Object, e As EventArgs) Handles GroupBox7.Enter

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Label41_Click(sender As Object, e As EventArgs) Handles Label41.Click

    End Sub

    Private Sub Button58_Click(sender As Object, e As EventArgs) Handles Button58.Click

    End Sub

    Private Sub Label42_Click(sender As Object, e As EventArgs) Handles Label42.Click

    End Sub

    Private Sub Button59_Click(sender As Object, e As EventArgs) Handles Button59.Click

    End Sub

    Private Sub Label43_Click(sender As Object, e As EventArgs) Handles Label43.Click

    End Sub

    Private Sub Button60_Click(sender As Object, e As EventArgs) Handles Button60.Click

    End Sub

    Private Sub Label45_Click(sender As Object, e As EventArgs) Handles Label45.Click

    End Sub

    Private Sub Button61_Click(sender As Object, e As EventArgs) Handles Button61.Click

    End Sub

    Private Sub GroupBox20_Enter(sender As Object, e As EventArgs) Handles GroupBox20.Enter

    End Sub

    Private Sub Button62_Click(sender As Object, e As EventArgs) Handles Button62.Click

    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged

    End Sub

    Private Sub Label72_Click(sender As Object, e As EventArgs) Handles Label72.Click

    End Sub

    Private Sub GroupBox21_Enter(sender As Object, e As EventArgs) Handles GroupBox21.Enter

    End Sub

    Private Sub TabPage9_Click(sender As Object, e As EventArgs) Handles TabPage9.Click

    End Sub

    Private Sub GroupBox10_Enter(sender As Object, e As EventArgs) Handles GroupBox10.Enter

    End Sub

    Private Sub TabPage7_Click(sender As Object, e As EventArgs) Handles TabPage7.Click

    End Sub

    Private Sub TabPage6_Click(sender As Object, e As EventArgs) Handles TabPage6.Click

    End Sub

    Private Sub Label44_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GroupBox11_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub GroupBox12_Enter(sender As Object, e As EventArgs) Handles GroupBox12.Enter

    End Sub

    Private Sub cgrillacorte_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles cgrillacorte.CellContentClick

    End Sub

    Private Sub GroupBox14_Enter(sender As Object, e As EventArgs) Handles GroupBox14.Enter

    End Sub

    Private Sub Button43_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GroupBox16_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub TabPage5_Click(sender As Object, e As EventArgs) Handles TabPage5.Click

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

    End Sub

    Private Sub Label46_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ctxttotalescorte_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label47_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ctxtcompras_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub utxtdireccion_TextChanged(sender As Object, e As EventArgs) Handles utxtdireccion.TextChanged

    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs) Handles Label20.Click

    End Sub

    Private Sub Label21_Click(sender As Object, e As EventArgs) Handles Label21.Click

    End Sub

    Private Sub utxtcorreo_TextChanged(sender As Object, e As EventArgs) Handles utxtcorreo.TextChanged

    End Sub

    Private Sub utxtnombre_TextChanged(sender As Object, e As EventArgs) Handles utxtnombre.TextChanged

    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub utxtap_TextChanged(sender As Object, e As EventArgs) Handles utxtap.TextChanged

    End Sub

    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles Label19.Click

    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click

    End Sub

    Private Sub utxttelefono_TextChanged(sender As Object, e As EventArgs) Handles utxttelefono.TextChanged

    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Label16.Click

    End Sub

    Private Sub utxtam_TextChanged(sender As Object, e As EventArgs) Handles utxtam.TextChanged

    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click

    End Sub

    Private Sub Label61_Click(sender As Object, e As EventArgs) Handles Label61.Click

    End Sub

    Private Sub ctxtextras_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub lbnombrep_Click(sender As Object, e As EventArgs) Handles lbnombrep.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub txtprecioindividualp_TextChanged(sender As Object, e As EventArgs) Handles txtprecioindividualp.TextChanged

    End Sub

    Private Sub txtcostop_TextChanged(sender As Object, e As EventArgs) Handles txtcostop.TextChanged

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub txtpreciomayoreop_TextChanged(sender As Object, e As EventArgs) Handles txtpreciomayoreop.TextChanged

    End Sub

    Private Sub txtcantidadp_TextChanged(sender As Object, e As EventArgs) Handles txtcantidadp.TextChanged

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub lbclavep_Click(sender As Object, e As EventArgs) Handles lbclavep.Click

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub txtactividadp_TextChanged(sender As Object, e As EventArgs) Handles txtactividadp.TextChanged

    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click

    End Sub

    Private Sub Label60_Click(sender As Object, e As EventArgs) Handles Label60.Click

    End Sub

    Private Sub txttipoproducto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txttipoproducto.SelectedIndexChanged

    End Sub

    Private Sub GroupBox5_Enter(sender As Object, e As EventArgs) Handles GroupBox5.Enter

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Label22_Click(sender As Object, e As EventArgs) Handles Label22.Click

    End Sub

    Private Sub utxttipousuario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles utxttipousuario.SelectedIndexChanged
        'revisamos que ha seleccionado. si es admin, entonces activamos todas las casillas. en caso contrario, la desactivamos

        If utxttipousuario.SelectedIndex = 0 Then
            activarcasillaspermisos()
        Else
            desactivarcasillaspermisos()
        End If


    End Sub
    Function activarcasillaspermisos()
        uchclientes.Checked = True
        uchcompras.Checked = True
        uchconfiguracion.Checked = True
        uchcorte.Checked = True
        uchproductos.Checked = True
        uchproveedores.Checked = True
        uchreportes.Checked = True
        uchusuarios.Checked = True


    End Function
    Function desactivarcasillaspermisos()
        uchclientes.CheckState = False
        uchcompras.CheckState = False
        uchconfiguracion.CheckState = False
        uchcorte.CheckState = False
        uchproductos.CheckState = False
        uchproveedores.CheckState = False
        uchreportes.CheckState = False
        uchusuarios.CheckState = False


    End Function

    Private Sub Label24_Click(sender As Object, e As EventArgs) Handles Label24.Click

    End Sub

    Private Sub utxtusuario_TextChanged(sender As Object, e As EventArgs) Handles utxtusuario.TextChanged

    End Sub

    Private Sub Label23_Click(sender As Object, e As EventArgs) Handles Label23.Click

    End Sub

    Private Sub utxtpass_TextChanged(sender As Object, e As EventArgs) Handles utxtpass.TextChanged

    End Sub

    Private Sub ctxtdireccion_TextChanged(sender As Object, e As EventArgs) Handles ctxtdireccion.TextChanged

    End Sub

    Private Sub Label34_Click(sender As Object, e As EventArgs) Handles Label34.Click

    End Sub

    Private Sub Label33_Click(sender As Object, e As EventArgs) Handles Label33.Click

    End Sub

    Private Sub ctxtcorreo_TextChanged(sender As Object, e As EventArgs) Handles ctxtcorreo.TextChanged

    End Sub

    Private Sub Label32_Click(sender As Object, e As EventArgs) Handles Label32.Click

    End Sub

    Private Sub ctxttelefono_TextChanged(sender As Object, e As EventArgs) Handles ctxttelefono.TextChanged

    End Sub

    Private Sub Label31_Click(sender As Object, e As EventArgs) Handles Label31.Click

    End Sub

    Private Sub ctxtam_TextChanged(sender As Object, e As EventArgs) Handles ctxtam.TextChanged

    End Sub

    Private Sub Label30_Click(sender As Object, e As EventArgs) Handles Label30.Click

    End Sub

    Private Sub ctxtap_TextChanged(sender As Object, e As EventArgs) Handles ctxtap.TextChanged

    End Sub

    Private Sub Label29_Click(sender As Object, e As EventArgs) Handles Label29.Click

    End Sub

    Private Sub ctxtnombre_TextChanged(sender As Object, e As EventArgs) Handles ctxtnombre.TextChanged
        'lbclientes.Visible = True
        'lbclientes.Items.Clear()


        ''cerramos la conexion
        'cerrarconexion()

        'Dim cantidad, i As Integer
        'cantidad = 0
        'conexionMysql.Open()
        'Dim Sql2 As String
        'Sql2 = "select count(*) from cliente where concat(nombre, ' ',ap, ' ', am) like '%" & ctxtnombre.Text & "%';"
        'Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
        'reader = cmd2.ExecuteReader
        'reader.Read()
        'cantidad = reader.GetString(0).ToString

        ''cargamos el formulario  resumen
        'conexionMysql.Close()

        ''MsgBox("hay tantos resultados:" & cantidad)

        'cerrarconexion()


        'If cantidad = 0 Then
        '    lbclientes.Visible = False
        'Else


        '    conexionMysql.Open()
        '    Dim Sql As String
        '    Sql = "select concat(nombre, ' ', ap, ' ', am) as nombre from cliente where concat(nombre, ' ',ap, ' ', am) like '%" & ctxtnombre.Text & "%';"
        '    Dim cmd As New MySqlCommand(Sql, conexionMysql)
        '    reader = cmd.ExecuteReader
        '    For i = 1 To cantidad
        '        reader.Read()

        '        lbclientes.Items.Add(reader.GetString(0).ToString)
        '    Next


        '    conexionMysql.Close()
        'End If

        ''Catch ex As Exception

        ''End Try
    End Sub

    Private Sub ctxtedad_TextChanged(sender As Object, e As EventArgs) Handles ctxtedad.TextChanged

    End Sub

    Private Sub Label35_Click(sender As Object, e As EventArgs) Handles Label35.Click

    End Sub

    Private Sub ctxtidcliente_TextChanged(sender As Object, e As EventArgs) Handles ctxtidcliente.TextChanged

    End Sub

    Private Sub Label36_Click(sender As Object, e As EventArgs) Handles Label36.Click

    End Sub

    Private Sub GroupBox9_Enter(sender As Object, e As EventArgs) Handles GroupBox9.Enter

    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub gb2_Enter(sender As Object, e As EventArgs) Handles gb2.Enter

    End Sub

    Private Sub ccgrilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ccgrilla.CellContentClick

    End Sub

    Private Sub btnidcompramercancia_Click(sender As Object, e As EventArgs) Handles btnidcompramercancia.Click

    End Sub

    Private Sub chimpresioncompra_CheckedChanged(sender As Object, e As EventArgs) Handles chimpresioncompra.CheckedChanged

    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel1.Paint

    End Sub

    Private Sub Label67_Click(sender As Object, e As EventArgs) Handles Label67.Click

    End Sub

    Private Sub ctxtcantidadactual_TextChanged(sender As Object, e As EventArgs) Handles ctxtcantidadactual.TextChanged

    End Sub

    Private Sub Label66_Click(sender As Object, e As EventArgs) Handles Label66.Click

    End Sub

    Private Sub Label65_Click(sender As Object, e As EventArgs) Handles Label65.Click

    End Sub

    Private Sub ctxtcostototalmercancia_TextChanged(sender As Object, e As EventArgs) Handles ctxtcostototalmercancia.TextChanged

    End Sub

    Private Sub Label64_Click(sender As Object, e As EventArgs) Handles Label64.Click

    End Sub

    Private Sub Label63_Click(sender As Object, e As EventArgs) Handles Label63.Click

    End Sub

    Private Sub Label62_Click(sender As Object, e As EventArgs) Handles Label62.Click

    End Sub

    Private Sub Label68_Click(sender As Object, e As EventArgs) Handles Label68.Click

    End Sub

    Private Sub Label70_Click(sender As Object, e As EventArgs) Handles Label70.Click

    End Sub

    Private Sub ctxtpreciopublico_TextChanged(sender As Object, e As EventArgs) Handles ctxtpreciopublico.TextChanged

    End Sub

    Private Sub Label69_Click(sender As Object, e As EventArgs) Handles Label69.Click

    End Sub

    Private Sub Label71_Click(sender As Object, e As EventArgs) Handles Label71.Click

    End Sub

    Private Sub chimpresion_CheckedChanged(sender As Object, e As EventArgs) Handles chimpresion.CheckedChanged

    End Sub

    Private Sub chimpresionticket_CheckedChanged(sender As Object, e As EventArgs) Handles chimpresionticket.CheckedChanged

    End Sub

    Private Sub chcalcularcambio_CheckedChanged(sender As Object, e As EventArgs) Handles chcalcularcambio.CheckedChanged

    End Sub

    Private Sub lbventas_Click(sender As Object, e As EventArgs) Handles lbventas.Click

    End Sub

    Private Sub lbventastotal_Click(sender As Object, e As EventArgs) Handles lbventastotal.Click

    End Sub

    Private Sub Label27_Click(sender As Object, e As EventArgs) Handles Label27.Click

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub ToolTip2_Popup(sender As Object, e As PopupEventArgs) Handles ToolTip2.Popup

    End Sub

    Private Sub Button47_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ctxtactividad_TextChanged(sender As Object, e As EventArgs) Handles ctxtactividad.TextChanged

    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub ctxttotal_TextChanged(sender As Object, e As EventArgs) Handles ctxttotal.TextChanged

    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click

    End Sub

    Private Sub Label37_Click(sender As Object, e As EventArgs) Handles Label37.Click

    End Sub

    Private Sub Label38_Click(sender As Object, e As EventArgs) Handles Label38.Click

    End Sub

    Private Sub gb1_Enter(sender As Object, e As EventArgs) Handles gb1.Enter

    End Sub

    Private Sub txtcantidadpaquete_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label57_Click(sender As Object, e As EventArgs) Handles Label57.Click

    End Sub

    Private Sub ctxtcomprado_TextChanged(sender As Object, e As EventArgs) Handles ctxtcomprado.TextChanged

    End Sub

    Private Sub Button48_Click(sender As Object, e As EventArgs) Handles Button48.Click

    End Sub

    Private Sub GroupBox17_Enter(sender As Object, e As EventArgs) Handles GroupBox17.Enter

    End Sub

    Private Sub cbproveedorcompras_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbproveedorcompras.SelectedIndexChanged

    End Sub

    Private Sub Label74_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtpreciopaquete_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label75_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label76_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub protxtcorreo_TextChanged(sender As Object, e As EventArgs) Handles protxtcorreo.TextChanged

    End Sub

    Private Sub Label55_Click(sender As Object, e As EventArgs) Handles Label55.Click

    End Sub

    Private Sub Label54_Click(sender As Object, e As EventArgs) Handles Label54.Click

    End Sub

    Private Sub protxttelefono_TextChanged(sender As Object, e As EventArgs) Handles protxttelefono.TextChanged

    End Sub

    Private Sub Label53_Click(sender As Object, e As EventArgs) Handles Label53.Click

    End Sub

    Private Sub protxtestado_TextChanged(sender As Object, e As EventArgs) Handles protxtestado.TextChanged

    End Sub

    Private Sub Label52_Click(sender As Object, e As EventArgs) Handles Label52.Click

    End Sub

    Private Sub GroupBox13_Enter(sender As Object, e As EventArgs) Handles GroupBox13.Enter

    End Sub

    Private Sub GroupBox15_Enter(sender As Object, e As EventArgs) Handles GroupBox15.Enter

    End Sub

    Private Sub TabPage8_Click(sender As Object, e As EventArgs) Handles TabPage8.Click

    End Sub

    Private Sub protxtap_TextChanged(sender As Object, e As EventArgs) Handles protxtap.TextChanged

    End Sub

    Private Sub Label51_Click(sender As Object, e As EventArgs) Handles Label51.Click

    End Sub

    Private Sub protxtnombrep_TextChanged(sender As Object, e As EventArgs) Handles protxtnombrep.TextChanged

    End Sub

    Private Sub Label50_Click(sender As Object, e As EventArgs) Handles Label50.Click

    End Sub

    Private Sub protxtnombreproveedor_TextChanged(sender As Object, e As EventArgs) Handles protxtnombreproveedor.TextChanged

    End Sub

    Private Sub protxtciudad_TextChanged(sender As Object, e As EventArgs) Handles protxtciudad.TextChanged

    End Sub

    Private Sub Label49_Click(sender As Object, e As EventArgs) Handles Label49.Click

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

    End Sub

    Private Sub ctxttiposervicio_TextChanged(sender As Object, e As EventArgs) Handles ctxttiposervicio.TextChanged

    End Sub

    Private Sub Label59_Click(sender As Object, e As EventArgs) Handles Label59.Click

    End Sub

    Private Sub txtventaeliminar_TextChanged(sender As Object, e As EventArgs) Handles txtventaeliminar.TextChanged

    End Sub

    Private Sub txtactividad_TextChanged(sender As Object, e As EventArgs) Handles txtactividad.TextChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click

    End Sub

    Private Sub Label25_Click(sender As Object, e As EventArgs) Handles Label25.Click

    End Sub

    Private Sub txttotal_Click(sender As Object, e As EventArgs) Handles txttotal.Click

    End Sub

    Private Sub txtunidades_Click(sender As Object, e As EventArgs) Handles txtunidades.Click

    End Sub

    Private Sub Label26_Click(sender As Object, e As EventArgs) Handles Label26.Click

    End Sub

    Private Sub Label39_Click(sender As Object, e As EventArgs) Handles Label39.Click

    End Sub

    Private Sub Label40_Click(sender As Object, e As EventArgs) Handles Label40.Click

    End Sub

    Private Sub GroupBox6_Enter(sender As Object, e As EventArgs) Handles GroupBox6.Enter

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click

    End Sub

    Private Sub Label28_Click(sender As Object, e As EventArgs) Handles Label28.Click

    End Sub

    Private Sub GroupBox8_Enter(sender As Object, e As EventArgs) Handles GroupBox8.Enter

    End Sub

    Private Sub btventas_Click(sender As Object, e As EventArgs)
        Dim formulario As New acercade
        'FRagregaranticipo.ShowDialog()
        formulario.ShowDialog()
    End Sub

    Private Sub FlowLayoutPanel2_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel2.Paint

    End Sub

    Private Sub lbcalendario_Click(sender As Object, e As EventArgs) Handles lbcalendario.Click

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

    End Sub

    Private Sub lbusuario_Click(sender As Object, e As EventArgs) Handles lbusuario.Click

    End Sub

    Private Sub cgrilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles cgrilla.CellContentClick

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub chanexar_CheckedChanged(sender As Object, e As EventArgs) Handles chanexar.CheckedChanged


    End Sub

    Private Sub protxtid_TextChanged(sender As Object, e As EventArgs) Handles protxtid.TextChanged

    End Sub

    Private Sub Label48_Click(sender As Object, e As EventArgs) Handles Label48.Click

    End Sub

    Private Sub Label56_Click(sender As Object, e As EventArgs) Handles Label56.Click

    End Sub

    Private Sub protxtam_TextChanged(sender As Object, e As EventArgs) Handles protxtam.TextChanged

    End Sub

    Private Sub btnprohistorialventas_Click(sender As Object, e As EventArgs) Handles btnprohistorialventas.Click
        Try
            grilla2p.Visible = False
            grillap.Visible = False
            grillahistorialesproductos.Visible = True

            cerrarconexion()
            conexionMysql.Open()
            Dim Sql As String
            Sql = "select * from ventaind,venta where idproducto='" & txtclavep.Text & "' and ventaind.idventa= venta.idventa;"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            Dim dt As New DataTable
            Dim da As New MySqlDataAdapter(cmd)
            'cargamos el formulario  resumen
            da.Fill(dt)
            grillahistorialesproductos.DataSource = dt
            'cgrilla.Columns(1).Width = 280
            'cgrilla.Columns(0).Width = 60
            'cgrilla.Columns(2).Width = 70
            'cgrilla.Columns(3).Width = 70
            'cgrilla.Columns(4).Width = 80
            'cgrilla.Columns(5).Width = 180

            'cgrilla.Columns(5).Width = 130



            conexionMysql.Close()

            cerrarconexion()


            conexionMysql.Open()
            Dim Sql2 As String
            Sql2 = "select sum(cantidad*costo)as suma, sum(cantidad)as suma2 from ventaind where idproducto='" & txtclavep.Text & "';"
            Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            reader = cmd2.ExecuteReader()
            reader.Read()
            txttotalgenerado.Text = reader.GetString(0).ToString()
            txttotalvendido.Text = reader.GetString(1).ToString()

            'txtstock.Text = reader.GetString(2).ToString
            ''si encuentra el valor, llamamos al focus del boton.
            'Button17.Focus()

            conexionMysql.Close()

        Catch ex As Exception
            cerrarconexion()
            'MsgBox("Se ha generado un error", MsgBoxStyle.Information, "Sistema")
            txttotalgenerado.Text = "0"
            txttotalvendido.Text = "0"

        End Try

    End Sub

    Private Sub lbclave_Click(sender As Object, e As EventArgs) Handles lbclave.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub txtstock_TextChanged(sender As Object, e As EventArgs) Handles txtstock.TextChanged

    End Sub

    Private Sub lbnombre_Click(sender As Object, e As EventArgs) Handles lbnombre.Click

    End Sub

    Private Sub txtcantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtcantidad.KeyDown
        If e.KeyCode = Keys.F1 Then
            venta()
        ElseIf e.KeyCode = Keys.F2 Or e.KeyCode = Keys.Enter Then
            agregarproductogrilla()
        End If
    End Sub

    Private Sub ctxtid_KeyDown(sender As Object, e As KeyEventArgs) Handles ctxtid.KeyDown
        If e.KeyCode = Keys.F2 Then
            compramercanciaagregargrilla()

        ElseIf e.KeyCode = Keys.F1 Then
            generarcompramercancia()
        End If

    End Sub

    Private Sub ctxtcantidadproductos_KeyDown(sender As Object, e As KeyEventArgs) Handles ctxtcantidadproductos.KeyDown
        If e.KeyCode = Keys.F2 Then
            compramercanciaagregargrilla()

        ElseIf e.KeyCode = Keys.F1 Then
            generarcompramercancia()
        End If

    End Sub

    Private Sub btnprohistorialcompras_Click(sender As Object, e As EventArgs) Handles btnprohistorialcompras.Click
        Try


            grilla2p.Visible = False
            grillap.Visible = False
            grillahistorialesproductos.Visible = True

            cerrarconexion()
            conexionMysql.Open()
            Dim Sql As String
            Sql = "select * from compramercancia where idproducto='" & txtclavep.Text & "';"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            Dim dt As New DataTable
            Dim da As New MySqlDataAdapter(cmd)
            'cargamos el formulario  resumen
            da.Fill(dt)
            grillahistorialesproductos.DataSource = dt
            'cgrilla.Columns(1).Width = 280
            'cgrilla.Columns(0).Width = 60
            'cgrilla.Columns(2).Width = 70
            'cgrilla.Columns(3).Width = 70
            'cgrilla.Columns(4).Width = 80
            'cgrilla.Columns(5).Width = 180

            'cgrilla.Columns(5).Width = 130



            conexionMysql.Close()
            conexionMysql.Open()
            Dim Sql2 As String
            Sql2 = "select sum(costo * cantidad)as total, sum(cantidad)as total2 from compramercancia where idproducto='" & txtclavep.Text & "';"
            Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            reader = cmd2.ExecuteReader()
            reader.Read()
            txttotalcomprado.Text = reader.GetString(1).ToString()
            txttotalegresos.Text = reader.GetString(0).ToString()

            'txtstock.Text = reader.GetString(2).ToString
            ''si encuentra el valor, llamamos al focus del boton.
            'Button17.Focus()

            conexionMysql.Close()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button63_Click(sender As Object, e As EventArgs) Handles Button63.Click
        'Frmdevoluciones.Show()
        Frmdevoluciones.ShowDialog()


    End Sub

    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles txtfoliocompramercancia.TextChanged

        Try


            If txtfoliocompramercancia.Text = "" Then

                cccgrilla.Visible = False
                ccgrilla.Visible = True


            Else


                cccgrilla.Visible = True
                ccgrilla.Visible = False

            End If
            Dim contador As Integer

            cerrarconexion()
            conexionMysql.Open()
            Dim Sql2 As String
            Sql2 = "select count(*)as contador from compramercancia where idcompra=" & txtfoliocompramercancia.Text & ";"
            Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            reader = cmd2.ExecuteReader()
            reader.Read()
            contador = reader.GetString(0).ToString()


            If contador = 0 Then
                Button64.Enabled = False
            Else
                Button64.Enabled = True
            End If

            'txtstock.Text = reader.GetString(2).ToString
            ''si encuentra el valor, llamamos al focus del boton.
            'Button17.Focus()

            conexionMysql.Close()







            cerrarconexion()
            'la busqueda se hace automatica
            conexionMysql.Open()
            Dim sql As String
            sql = "select * from compramercancia where idcompra=" & txtfoliocompramercancia.Text & ";"
            Dim cmd As New MySqlCommand(sql, conexionMysql)
            Dim dt As New DataTable
            Dim da As New MySqlDataAdapter(cmd)
            'cargamos el formulario  resumen
            da.Fill(dt)
            cccgrilla.DataSource = dt
            conexionMysql.Close()


            cerrarconexion()
            'la busqueda se hace automatica
            conexionMysql.Open()
            Dim sql23 As String
            sql23 = "select * from compramercancia where idcompra=" & txtfoliocompramercancia.Text & ";"
            Dim cmd23 As New MySqlCommand(sql23, conexionMysql)
            reader = cmd23.ExecuteReader()
            reader.Read()
            ctxtcomprado2.Text = reader.GetString(7).ToString()

            conexionMysql.Close()






        Catch ex As Exception

        End Try





    End Sub

    Private Sub Button25_Click_1(sender As Object, e As EventArgs) Handles Button25.Click


        Dim estadocaja As Integer


        estadocaja = comprobarcaja()
        ' MsgBox(estadocaja)
        If estadocaja = 0 Then

            ' RPT1.Show()




            If ctxtactividad.Text = "" Or ctxtcantidad.Text = "" Or ctxtcosto.Text = "" Or ctxttotal.Text = "" Then
                MsgBox("Falta información", MsgBoxStyle.Information, "Sistema")

            Else
                Dim hora2, minuto, segundo As String
                Dim total As Double
                'obtener fecha y hora
                hora2 = Now.Hour()
                minuto = Now.Minute()
                segundo = Now.Second()

                hora = hora2 & ":" & minuto & ":" & segundo


                Dim dia, mes, año, fecha As String

                dia = Date.Now.Day
                mes = Date.Now.Month
                año = Date.Now.Year
                fecha = año & "-" & mes & "-" & dia


                '----------------consultamos al usuario que esta realizando la venta ------------------
                Dim idusuario As Integer

                cerrarconexion()

                conexionMysql.Open()
                Dim Sql32 As String
                'consultamos el id del usuario para obtener un registro de quien es al que se le esta vendiendo
                Sql32 = "select idusuario from usuario where usuario= '" & usuarioactual & "';"
                Dim cmd32 As New MySqlCommand(Sql32, conexionMysql)
                reader = cmd32.ExecuteReader()
                reader.Read()
                idusuario = reader.GetString(0).ToString()
                conexionMysql.Close()
                cerrarconexion()
                '--------------------------------------------------------------------------





                Try
                    cerrarconexion()
                    conexionMysql.Open()

                    Dim Sql As String
                    Sql = "INSERT INTO compra (actividad, cantidad, costo, total, fecha, hora, idusuario) VALUES ('" & ctxtactividad.Text & "', " & ctxtcantidad.Text & ", " & ctxtcosto.Text & ", " & ctxttotal.Text & ", '" & fecha & "','" & hora & "'," & idusuario & ");"
                    Dim cmd As New MySqlCommand(Sql, conexionMysql)
                    cmd.ExecuteNonQuery()
                    conexionMysql.Close()
                    'llamar a la funcion limpiar, para limpiar las cajas cada vez que se agrege una nueva compra.
                    climpiar()
                    'llenar la grilla con los nuevos valores establecidos.
                    cllenadogrilla()


                    ctxtcomprado.Text = consultacompras()

                    conexionMysql.Close()





                Catch ex As Exception
                    MsgBox("Existe un error, comprueba nuevamente", MsgBoxStyle.Exclamation, "Sistema")
                End Try


            End If



        Else
            MsgBox("No existe ninguna caja abierta", MsgBoxStyle.Information, "CTRL+y")
        End If

    End Sub
    Function imprimirCompraProductos()
        'consultamos a la BD la impresora seleccionada por default
        Dim impresora As String
        Try

            conexionMysql.Open()
            Dim Sql1 As String
            Sql1 = "select * from impresora;"
            Dim cmd1 As New MySqlCommand(Sql1, conexionMysql)
            reader = cmd1.ExecuteReader()
            reader.Read()
            impresora = reader.GetString(1).ToString()
            conexionMysql.Close()
        Catch ex As Exception
            MsgBox("No hay una impresora seleccionada", MsgBoxStyle.Information, "Sistema")
        End Try



        'txtetiqueta1 = " prueba de impresión"
        'txtetiqueta2 = " Nº : " & lbfolio.Text
        'txtetiqueta = " De : " & "$" & txttotalpagar.Text &
        'Chr(10) & " " & "12/12/!2"
        Try
            Dim PrintDialog1 As New PrintDialog
            PrintDialog1.Document = PrintDocument2
            PrintDialog1.PrinterSettings.PrinterName = impresora
            If PrintDocument2.PrinterSettings.IsValid Then
                PrintDocument2.Print() 'Imprime texto 
            Else
                MsgBox("Impresora invalida", MsgBoxStyle.Exclamation, "CTRL+y")
                'MessageBox.Show("La impresora no es valida")
            End If
            '--------------------------------------------------- 
        Catch ex As Exception
            MsgBox("Hay problemas con la impresion", MsgBoxStyle.Exclamation, "CTRL+y")

            'MessageBox.Show("Hay un problema de impresión",
            ex.ToString()
        End Try

    End Function
    Private Sub Button47_Click_1(sender As Object, e As EventArgs) Handles Button47.Click
        FRMverdevoluciones.ShowDialog()

    End Sub

    Private Sub ctxtcostomercancia_KeyDown(sender As Object, e As KeyEventArgs) Handles ctxtcostomercancia.KeyDown
        If e.KeyCode = Keys.F2 Then
            compramercanciaagregargrilla()

        ElseIf e.KeyCode = Keys.F1 Then
            generarcompramercancia()
        End If

    End Sub

    Private Sub ctxtpreciopublico_KeyDown(sender As Object, e As KeyEventArgs) Handles ctxtpreciopublico.KeyDown
        If e.KeyCode = Keys.F2 Then
            compramercanciaagregargrilla()

        ElseIf e.KeyCode = Keys.F1 Then
            generarcompramercancia()
        End If

    End Sub

    Private Sub txtpreciopaquete_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.F2 Then
            compramercanciaagregargrilla()

        ElseIf e.KeyCode = Keys.F1 Then
            generarcompramercancia()
        End If

    End Sub

    Private Sub Button65_Click(sender As Object, e As EventArgs) Handles Button65.Click


        Dim respuesta As String

        respuesta = MsgBox("¿Estas seguro de reiniciar el Sistema CTRL+y y eliminar toda la información?", MsgBoxStyle.YesNo, "CTRL+y")
        If respuesta = vbYes Then
            '--------------------------------- en caso de que la respuesta sea correcta
            '--------------------------------- se procede a eliminar todo


            conexionMysql.Open()
            Dim Sql15 As String
            Sql15 = "SET FOREIGN_KEY_CHECKS=0;"
            Dim cmd15 As New MySqlCommand(Sql15, conexionMysql)
            cmd15.ExecuteNonQuery()
            conexionMysql.Close()

            conexionMysql.Open()
            Dim Sql151 As String
            Sql151 = "delete from proveedor;"
            Dim cmd151 As New MySqlCommand(Sql151, conexionMysql)
            cmd151.ExecuteNonQuery()
            conexionMysql.Close()




            conexionMysql.Open()
            Dim Sql As String
            Sql = "TRUNCATE table producto;"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            cmd.ExecuteNonQuery()
            conexionMysql.Close()




            conexionMysql.Open()
            Dim Sql2 As String
            Sql2 = "TRUNCATE table compra;"
            Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            cmd2.ExecuteNonQuery()
            conexionMysql.Close()

            conexionMysql.Open()
            Dim Sql3 As String
            Sql3 = "TRUNCATE table compramercancia;"
            Dim cmd3 As New MySqlCommand(Sql3, conexionMysql)
            cmd3.ExecuteNonQuery()
            conexionMysql.Close()

            conexionMysql.Open()
            Dim Sql4 As String
            Sql4 = "TRUNCATE table configuracion;"
            Dim cmd4 As New MySqlCommand(Sql4, conexionMysql)
            cmd4.ExecuteNonQuery()
            conexionMysql.Close()


            conexionMysql.Open()
            Dim Sql5 As String
            Sql5 = "TRUNCATE table corte;"
            Dim cmd5 As New MySqlCommand(Sql5, conexionMysql)
            cmd5.ExecuteNonQuery()
            conexionMysql.Close()


            conexionMysql.Open()
            Dim Sql6 As String
            Sql6 = "TRUNCATE table cotizador_gral;"
            Dim cmd6 As New MySqlCommand(Sql6, conexionMysql)
            cmd6.ExecuteNonQuery()
            conexionMysql.Close()



            conexionMysql.Open()
            Dim Sql8 As String
            Sql8 = "TRUNCATE table cotizador_marco_ind;"
            Dim cmd8 As New MySqlCommand(Sql8, conexionMysql)
            cmd8.ExecuteNonQuery()
            conexionMysql.Close()

            conexionMysql.Open()
            Dim Sql7 As String
            Sql7 = "delete from cotizador_marco;"
            Dim cmd7 As New MySqlCommand(Sql7, conexionMysql)
            cmd7.ExecuteNonQuery()
            conexionMysql.Close()













            conexionMysql.Open()
            Dim Sql9 As String
            Sql9 = "TRUNCATE table datos_empresa;"
            Dim cmd9 As New MySqlCommand(Sql9, conexionMysql)
            cmd9.ExecuteNonQuery()
            conexionMysql.Close()

            conexionMysql.Open()
            Dim Sql10 As String
            Sql10 = "TRUNCATE table devolucion;"
            Dim cmd10 As New MySqlCommand(Sql10, conexionMysql)
            cmd10.ExecuteNonQuery()
            conexionMysql.Close()

            conexionMysql.Open()
            Dim Sql11 As String
            Sql11 = "TRUNCATE table impresora;"
            Dim cmd11 As New MySqlCommand(Sql11, conexionMysql)
            cmd11.ExecuteNonQuery()
            conexionMysql.Close()

            conexionMysql.Open()
            Dim Sql12 As String
            Sql12 = "TRUNCATE table logo_empresa;"
            Dim cmd12 As New MySqlCommand(Sql12, conexionMysql)
            cmd12.ExecuteNonQuery()
            conexionMysql.Close()

            conexionMysql.Open()
            Dim Sql13 As String
            Sql13 = "TRUNCATE table luzserigrafia;"
            Dim cmd13 As New MySqlCommand(Sql13, conexionMysql)
            cmd13.ExecuteNonQuery()
            conexionMysql.Close()


            conexionMysql.Open()
            Dim Sql17 As String
            Sql17 = "TRUNCATE table secotizaciontintas;"
            Dim cmd17 As New MySqlCommand(Sql17, conexionMysql)
            cmd17.ExecuteNonQuery()
            conexionMysql.Close()

            conexionMysql.Open()
            Dim Sql14 As String
            Sql14 = "delete from  producto_serigrafia;"
            Dim cmd14 As New MySqlCommand(Sql14, conexionMysql)
            cmd14.ExecuteNonQuery()
            conexionMysql.Close()






            conexionMysql.Open()
            Dim Sql16 As String
            Sql16 = "delete from secotizacion;"
            Dim cmd16 As New MySqlCommand(Sql16, conexionMysql)
            cmd16.ExecuteNonQuery()
            conexionMysql.Close()



            conexionMysql.Open()
            Dim Sql18 As String
            Sql18 = "TRUNCATE table servicio_serigrafia;"
            Dim cmd18 As New MySqlCommand(Sql18, conexionMysql)
            cmd18.ExecuteNonQuery()
            conexionMysql.Close()
            conexionMysql.Open()
            Dim Sql19 As String
            Sql19 = "TRUNCATE table servicios_ventas;"
            Dim cmd19 As New MySqlCommand(Sql19, conexionMysql)
            cmd19.ExecuteNonQuery()
            conexionMysql.Close()


            conexionMysql.Open()
            Dim Sql1 As String
            Sql1 = "TRUNCATE table cliente;"
            Dim cmd1 As New MySqlCommand(Sql1, conexionMysql)
            cmd1.ExecuteNonQuery()
            conexionMysql.Close()


            conexionMysql.Open()
            Dim Sql20 As String
            Sql20 = "TRUNCATE table so;"
            Dim cmd20 As New MySqlCommand(Sql20, conexionMysql)
            cmd20.ExecuteNonQuery()
            conexionMysql.Close()

            conexionMysql.Open()
            Dim Sql21 As String
            Sql21 = "TRUNCATE table sodesglose;"
            Dim cmd21 As New MySqlCommand(Sql21, conexionMysql)
            cmd21.ExecuteNonQuery()
            conexionMysql.Close()

            conexionMysql.Open()
            Dim Sql22 As String
            Sql22 = "TRUNCATE table software;"
            Dim cmd22 As New MySqlCommand(Sql22, conexionMysql)
            cmd22.ExecuteNonQuery()
            conexionMysql.Close()
            conexionMysql.Open()
            Dim Sql23 As String
            Sql23 = "TRUNCATE table tipo_corte;"
            Dim cmd23 As New MySqlCommand(Sql23, conexionMysql)
            cmd23.ExecuteNonQuery()
            conexionMysql.Close()
            conexionMysql.Open()
            Dim Sql24 As String
            Sql24 = "TRUNCATE table tipo_usuario;"
            Dim cmd24 As New MySqlCommand(Sql24, conexionMysql)
            cmd24.ExecuteNonQuery()
            conexionMysql.Close()
            conexionMysql.Open()
            Dim Sql25 As String
            Sql25 = "TRUNCATE table tipoproducto;"
            Dim cmd25 As New MySqlCommand(Sql25, conexionMysql)
            cmd25.ExecuteNonQuery()
            conexionMysql.Close()
            conexionMysql.Open()
            Dim Sql26 As String
            Sql26 = "TRUNCATE table tipoventa;"
            Dim cmd26 As New MySqlCommand(Sql26, conexionMysql)
            cmd26.ExecuteNonQuery()
            conexionMysql.Close()
            conexionMysql.Open()
            Dim Sql27 As String
            Sql27 = "TRUNCATE table usuario;"
            Dim cmd27 As New MySqlCommand(Sql27, conexionMysql)
            cmd27.ExecuteNonQuery()
            conexionMysql.Close()
            conexionMysql.Open()
            Dim Sql28 As String
            Sql28 = "TRUNCATE table venta;"
            Dim cmd28 As New MySqlCommand(Sql28, conexionMysql)
            cmd28.ExecuteNonQuery()
            conexionMysql.Close()
            conexionMysql.Open()
            Dim Sql29 As String
            Sql29 = "TRUNCATE table ventaind;"
            Dim cmd29 As New MySqlCommand(Sql29, conexionMysql)
            cmd29.ExecuteNonQuery()
            conexionMysql.Close()
            conexionMysql.Open()
            Dim Sql30 As String
            Sql30 = "TRUNCATE table vinildificultad;"
            Dim cmd30 As New MySqlCommand(Sql30, conexionMysql)
            cmd30.ExecuteNonQuery()
            conexionMysql.Close()

            conexionMysql.Open()
            Dim Sql31 As String
            Sql31 = "TRUNCATE table vinilproducto;"
            Dim cmd31 As New MySqlCommand(Sql31, conexionMysql)
            cmd31.ExecuteNonQuery()
            conexionMysql.Close()

            conexionMysql.Open()
            Dim Sql3x1 As String
            Sql3x1 = "TRUNCATE table caja;"
            Dim cmd3x1 As New MySqlCommand(Sql3x1, conexionMysql)
            cmd3x1.ExecuteNonQuery()
            conexionMysql.Close()

            conexionMysql.Open()
            Dim Sql152 As String
            Sql152 = "SET FOREIGN_KEY_CHECKS=1;"
            Dim cmd152 As New MySqlCommand(Sql152, conexionMysql)
            cmd152.ExecuteNonQuery()
            conexionMysql.Close()


            valoresiniciales()
            'inserciondedatosiniciales()
            MsgBox("Se ha reiniciado el sistema completamente, no existe ningun registro, salvo los iniciales", MsgBoxStyle.Information, "CTRL+y")




        Else



        End If
    End Sub
    Function valoresiniciales()


        'Try

        conexionMysql.Open()
        Dim Sql As String
        Sql = "INSERT INTO `dwin`.`cliente` (`nombre`, `ap`, `am`, `rfc`, `direccion`, `telefono`, `correo`) VALUES ('usuario', 'usuario', 'usuario', '0', '0', '0', '0');"
        Dim cmd As New MySqlCommand(Sql, conexionMysql)
        cmd.ExecuteNonQuery()
        conexionMysql.Close()


        conexionMysql.Open()
        Dim Sql3 As String
        Sql3 = "INSERT INTO `dwin`.`tipo_usuario` (`tipo_usuario`, `tipo`) VALUES ('1', 'ADMINISTRADOR');"
        Dim cmd3 As New MySqlCommand(Sql3, conexionMysql)
        cmd3.ExecuteNonQuery()
        conexionMysql.Close()


        conexionMysql.Open()
        Dim Sql4 As String
        Sql4 = "INSERT INTO `dwin`.`tipo_usuario` (`tipo_usuario`, `tipo`) VALUES ('2', 'TRABAJADOR');"
        Dim cmd4 As New MySqlCommand(Sql4, conexionMysql)
        cmd4.ExecuteNonQuery()
        conexionMysql.Close()


        conexionMysql.Open()
        Dim Sql5 As String
        Sql5 = "INSERT INTO `dwin`.`proveedor` (`nombre_empresa`, `nombre_encargado`, `ap_encargado`, `am_encargado`, `ciudad`, `estado`, `telefono`, `correo`) VALUES ('INDEFINIDO', 'INDEFINIDO', 'INDEFINIDO', 'INDEFINIDO', '00', '00', '00', '00');"
        Dim cmd5 As New MySqlCommand(Sql5, conexionMysql)
        cmd5.ExecuteNonQuery()
        conexionMysql.Close()




        conexionMysql.Open()
        Dim Sql5X As String
        Sql5X = "INSERT INTO `dwin`.`tipo_corte` (`idtipo_corte`, `tipo`, `estado`) VALUES ('1', 'USUARIO', '1');"
        Dim cmd5X As New MySqlCommand(Sql5X, conexionMysql)
        cmd5X.ExecuteNonQuery()
        conexionMysql.Close()


        conexionMysql.Open()
        Dim Sql5X1 As String
        Sql5X1 = "INSERT INTO `dwin`.`tipo_corte` (`idtipo_corte`, `tipo`, `estado`) VALUES ('2', 'TIEMPO', '0');"
        Dim cmd5X1 As New MySqlCommand(Sql5X1, conexionMysql)
        cmd5X1.ExecuteNonQuery()
        conexionMysql.Close()




        conexionMysql.Open()
        Dim Sql6 As String
        Sql6 = "INSERT INTO `dwin`.`tipoproducto` (`tipo`) VALUES ('INDEFINIDO');"
        Dim cmd6 As New MySqlCommand(Sql6, conexionMysql)
        cmd6.ExecuteNonQuery()
        conexionMysql.Close()



        conexionMysql.Open()
        Dim Sql35 As String
        Sql35 = "INSERT INTO `dwin`.`tipoventa` (`idtipoventa`,`tipoventa`) VALUES ('1','venta');"
        Dim cmd35 As New MySqlCommand(Sql35, conexionMysql)
        cmd35.ExecuteNonQuery()
        conexionMysql.Close()
        conexionMysql.Open()
        Dim Sql36 As String
        Sql36 = "INSERT INTO `dwin`.`tipoventa` (`idtipoventa`,`tipoventa`) VALUES ('2','servicios');"
        Dim cmd36 As New MySqlCommand(Sql36, conexionMysql)
        cmd36.ExecuteNonQuery()
        conexionMysql.Close()
        'MsgBox("se creo tipo de venta")
        '-----------------------------------------------------------------------------------------

        'reiniciamos los valores de autoincrementables en 0
        conexionMysql.Open()
        Dim Sql7 As String
        Sql7 = "alter table tipo_usuario auto_increment=0;"
        Dim cmd7 As New MySqlCommand(Sql7, conexionMysql)
        cmd7.ExecuteNonQuery()
        conexionMysql.Close()


        conexionMysql.Open()
        Dim Sql8 As String
        Sql8 = "alter table cliente auto_increment=0;"
        Dim cmd8 As New MySqlCommand(Sql8, conexionMysql)
        cmd8.ExecuteNonQuery()
        conexionMysql.Close()

        conexionMysql.Open()
        Dim Sql9 As String
        Sql9 = "alter table compra auto_increment=0;"
        Dim cmd9 As New MySqlCommand(Sql9, conexionMysql)
        cmd9.ExecuteNonQuery()
        conexionMysql.Close()

        conexionMysql.Open()
        Dim Sql91 As String
        Sql91 = "alter table compramercancia auto_increment=0;"
        Dim cmd91 As New MySqlCommand(Sql91, conexionMysql)
        cmd91.ExecuteNonQuery()
        conexionMysql.Close()


        conexionMysql.Open()
        Dim Sql92 As String
        Sql92 = "alter table corte auto_increment=0;"
        Dim cmd92 As New MySqlCommand(Sql92, conexionMysql)
        cmd92.ExecuteNonQuery()
        conexionMysql.Close()

        conexionMysql.Open()
        Dim Sql93 As String
        Sql93 = "alter table cotizador_marco_ind auto_increment=0;"
        Dim cmd93 As New MySqlCommand(Sql93, conexionMysql)
        cmd93.ExecuteNonQuery()
        conexionMysql.Close()

        conexionMysql.Open()
        Dim Sql94 As String
        Sql94 = "alter table devolucion auto_increment=0;"
        Dim cmd94 As New MySqlCommand(Sql94, conexionMysql)
        cmd94.ExecuteNonQuery()
        conexionMysql.Close()

        conexionMysql.Open()
        Dim Sql95 As String
        Sql95 = "alter table proveedor auto_increment=0;"
        Dim cmd95 As New MySqlCommand(Sql95, conexionMysql)
        cmd95.ExecuteNonQuery()
        conexionMysql.Close()

        conexionMysql.Open()
        Dim Sql96 As String
        Sql96 = "alter table secotizaciontintas auto_increment=0;"
        Dim cmd96 As New MySqlCommand(Sql96, conexionMysql)
        cmd96.ExecuteNonQuery()
        conexionMysql.Close()


        conexionMysql.Open()
        Dim Sql97 As String
        Sql97 = "alter table servicios_ventas auto_increment=0;"
        Dim cmd97 As New MySqlCommand(Sql97, conexionMysql)
        cmd97.ExecuteNonQuery()
        conexionMysql.Close()


        conexionMysql.Open()
        Dim Sql98 As String
        Sql98 = "alter table tipo_usuario auto_increment=0;"
        Dim cmd98 As New MySqlCommand(Sql98, conexionMysql)
        cmd98.ExecuteNonQuery()
        conexionMysql.Close()

        conexionMysql.Open()
        Dim Sql99 As String
        Sql99 = "alter table tipoproducto auto_increment=0;"
        Dim cmd99 As New MySqlCommand(Sql99, conexionMysql)
        cmd99.ExecuteNonQuery()
        conexionMysql.Close()

        conexionMysql.Open()
        Dim Sql910 As String
        Sql910 = "alter table usuario auto_increment=0;"
        Dim cmd910 As New MySqlCommand(Sql910, conexionMysql)
        cmd910.ExecuteNonQuery()
        conexionMysql.Close()

        conexionMysql.Open()
        Dim Sql911 As String
        Sql911 = "alter table ventaind auto_increment=0;"
        Dim cmd911 As New MySqlCommand(Sql911, conexionMysql)
        cmd911.ExecuteNonQuery()
        conexionMysql.Close()

        conexionMysql.Open()
        Dim Sql912 As String
        Sql912 = "alter table vinildificultad auto_increment=0;"
        Dim cmd912 As New MySqlCommand(Sql912, conexionMysql)
        cmd912.ExecuteNonQuery()
        conexionMysql.Close()


        'PARA PODER TENER UN USUARIO, NECESITO LOS TIPOS DE USUARIOS REGISTRADOR EN LOS DOS INSERT ANTERIORES.                          
        conexionMysql.Open()
        Dim Sql2 As String
        Sql2 = "INSERT INTO `dwin`.`usuario` (`usuario`, `nombre`, `ap`, `am`, `telefono`, `correo`, `direccion`, `tipo_usuario`) VALUES ('root', '0', '0', '0', '0', '0', '0', '1');"
        Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
        cmd2.ExecuteNonQuery()
        conexionMysql.Close()

        ' Catch ex As Exception

        'End Try




    End Function

    Function reiniciarsistema()

    End Function


    Private Sub Button66_Click(sender As Object, e As EventArgs)
        cargardatosnotaventa()
        'imprimirnotaventa()
    End Sub



    Private Sub Button67_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub stxtclave_TextChanged(sender As Object, e As EventArgs) Handles stxtclave.TextChanged
        sgrilla.Visible = True

        sgrilla2.Visible = False

        stxtclave.BackColor = Color.White



        Try

            listaservicios.Visible = False
            If stxtclave.Text = "" Then

                sborrar()



            Else
                '  obtenerfolio()


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
                Sql = "select * from producto where idproducto='" & stxtclave.Text & "';"
                Dim cmd As New MySqlCommand(Sql, conexionMysql)
                reader = cmd.ExecuteReader()
                reader.Read()
                stxtnombre.Text = reader.GetString(1).ToString()
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
                Sql2 = "select * from producto where idproducto='" & stxtclave.Text & "';"
                Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
                reader = cmd2.ExecuteReader()
                reader.Read()
                stxtprecio.Text = reader.GetString(4).ToString()
                txtcostoproductoserigrafia.Text = reader.GetString(3).ToString
                '-----------------------------------------------------------------------------
                'CALCULAMOS LA GANANCIA DEL PRODUCTO

                stxtgananciaproducto.Text = CDbl(stxtprecio.Text) - CDbl(txtcostoproductoserigrafia.Text)



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

        Catch ex As Exception

            stxtprecio.Text = ""
            stxtnombre.Text = ""

        End Try

    End Sub


    Private Sub txtcantidadpaquete_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.F2 Then
            compramercanciaagregargrilla()

        ElseIf e.KeyCode = Keys.F1 Then
            generarcompramercancia()
        End If

    End Sub

    Private Sub listaservicios_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub cbproveedorcompras_KeyDown(sender As Object, e As KeyEventArgs) Handles cbproveedorcompras.KeyDown
        If e.KeyCode = Keys.F2 Then
            compramercanciaagregargrilla()

        ElseIf e.KeyCode = Keys.F1 Then
            generarcompramercancia()
        End If

    End Sub

    Private Sub Button64_Click(sender As Object, e As EventArgs) Handles Button64.Click
        cargardatosnotacompra()
        imprimirnotacompra()

    End Sub

    Private Sub TextBox9_TextChanged_1(sender As Object, e As EventArgs) Handles stxtcantidad.TextChanged
        Try

            stxttotalproducto.Text = CDbl(stxtcantidad.Text) * CDbl(stxtprecio.Text)
            stxtcantidad.BackColor = Color.White
            stxtprecio.BackColor = Color.White
            stxttotalproducto.BackColor = Color.White

            Try

                conexionMysql.Open()
                Dim Sql2 As String
                Sql2 = "select * from producto where idproducto='" & stxtclave.Text & "';"
                Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
                reader = cmd2.ExecuteReader()
                reader.Read()
                stxtprecio.Text = reader.GetString(4).ToString()
                txtcostoproductoserigrafia.Text = reader.GetString(3).ToString
                reader.Close()
                conexionMysql.Close()

            Catch ex As Exception

            End Try



        Catch ex As Exception

            stxttotalproducto.Text = ""


        End Try

    End Sub

    Private Sub Button69_Click(sender As Object, e As EventArgs) Handles Button69.Click
        stxtprecio.BackColor = Color.White
        stxttotalproducto.BackColor = Color.White

        sagregarproductogrilla()
        stxtanticipo.Text = ""
        stxtanticipo.Enabled = True
        stxtresto.Enabled = True
        stxtclave.Focus()

    End Sub
    Function sagregarproductogrilla()
        sgrilla.DefaultCellStyle.Font = New Font("Arial", 20)
        sgrilla.RowHeadersVisible = False




        'grilla.Columns(0).Width = 0
        sgrilla.AlternatingRowsDefaultCellStyle.BackColor = Color.SkyBlue



        If stxtclave.Text = "" Or stxtnombre.Text = "" Or stxtcantidad.Text = "" Or stxtprecio.Text = "" Or stxtcliente.Text = "" Then

            MsgBox("Falta información para agregar", MsgBoxStyle.Exclamation, "Sistema")

        Else




            Dim cantidad_total, cantidadbd As Integer

            'cantidad total es la cantidad que se va a vender
            'se le suma 1, porque es el producto que apenas se va anexar a la lista de venta
            Try
                cantidad_total = scomprobacion() + stxtcantidad.Text


                'cantidadbd, es la cantidad que existe en la BD del producto

                cantidadbd = sconteoclave()

                If cantidad_total > cantidadbd Then
                    MsgBox("No hay productos suficientes, no se agregara este producto", MsgBoxStyle.Exclamation, "Sistema")
                    sborrar()
                Else
                    sagregargrilla()
                    ssumatorio()
                    stxtclave.Text = ""
                    stxtclave.Focus()


                End If

            Catch ex As Exception

                MsgBox("No podemos procesar esta solicitud, Verifica la información", MsgBoxStyle.Exclamation, "Sistema")
            End Try

        End If


        '------------------------------------------------------------------------------------------------------------------

        '------------------------------------------------------------------------------------------------------------------


    End Function

    Private Sub stxtcliente_TextChanged(sender As Object, e As EventArgs) Handles stxtcliente.TextChanged
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


        'End Try
    End Sub

    Private Sub stxtanticipo_TextChanged(sender As Object, e As EventArgs) Handles stxtanticipo.TextChanged
        Try


            If CDbl(stxtanticipo.Text) > CDbl(stxttotal.Text) Then
                MsgBox("Valor fuera del total", MsgBoxStyle.Information, "CTRL+y")
                stxtanticipo.Text = ""
                stxtresto.Text = ""
            Else
                stxtresto.Text = CDbl(stxttotal.Text) - CDbl(stxtanticipo.Text)

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtfecharegistroventa_TextChanged(sender As Object, e As EventArgs) Handles stxtfecharegistroventa.TextChanged

    End Sub

    Private Sub txthoraregistroventa_TextChanged(sender As Object, e As EventArgs) Handles stxthoraregistroventa.TextChanged

    End Sub

    Private Sub stxtfoliobusquedaventa_TextChanged(sender As Object, e As EventArgs) Handles stxtfoliobusquedaventa.TextChanged
        If stxtfoliobusquedaventa.Text = "" Then
            nuevoservicio()
            sgrilla2.DataSource = ""
        End If



    End Sub

    Function cargardatosnotacompra()

        conexionMysql.Open()


        Dim command As New MySqlCommand("select compramercancia.idcompra, compramercancia.idproducto, compramercancia.costo, compramercancia.cantidad, compramercancia.fecha,compramercancia.hora, producto.descripcion from compramercancia, producto where compramercancia.idcompra=" & txtfoliocompramercancia.Text & " and compramercancia.idproducto=producto.idproducto;", conexionMysql)

        Dim adapter As New MySqlDataAdapter
        Dim dt As New DataTable
        adapter.SelectCommand = command
        adapter.Fill(dt)
        DataGridView1.DataSource = dt
        adapter.Dispose()
        command.Dispose()
        conexionMysql.Close()

    End Function
    Function imprimirnotacompra()
        Dim dt As New DataTable

        With dt

            .Columns.Add("idcompra")
            .Columns.Add("idproducto")
            .Columns.Add("costo")
            .Columns.Add("cantidad")
            .Columns.Add("fecha")
            .Columns.Add("hora")
            .Columns.Add("descripcion")

        End With

        For Each row As DataGridViewRow In DataGridView1.Rows

            dt.Rows.Add(row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(4).Value, row.Cells(5).Value, row.Cells(6).Value)

        Next


        'FRMRPTnotacompra.ReportViewer1.LocalReport.DataSources.Item(0).Value = dt

        'FRMRPTnotacompra.ShowDialog()

        'FRMRPTnotacompra.Dispose()

    End Function




    Function cargarservicio()
        'aqui lo que hacemos es cargar el servicio a la caja de texto de txtnombre y mandamos la clave al la caja de texto txtclave,
        Try

            conexionMysql.Open()
            Dim Sql As String
            Sql = "select * from producto where descripcion='" & listaservicios.Text & "';"
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



    Private Sub stxtfoliobusquedaventa_KeyDown(sender As Object, e As KeyEventArgs) Handles stxtfoliobusquedaventa.KeyDown
        If e.KeyCode = Keys.Enter Then
            buscarfolioservicio()
            sgrilla2.Visible = True
            sgrilla.Visible = False


        End If
    End Sub

    Private Sub Button67_Click_1(sender As Object, e As EventArgs) Handles Button67.Click

        obtener_chticket_Chcambio_venta()
        cargarformadepago()
        obtenerfolio()
        Dim tipo As Integer
        'tipo = tipoingreso()
        'If tipo = 2 Then
        'TabControl1.SelectedIndex = 1
        '    Button1.BackColor = Color.DimGray
        '    Button2.BackColor = Color.FromArgb(47, 56, 72)
        '    Button3.BackColor = Color.FromArgb(47, 56, 72)
        '    Button4.BackColor = Color.FromArgb(47, 56, 72)
        '    Button5.BackColor = Color.FromArgb(47, 56, 72)
        '    Button6.BackColor = Color.FromArgb(47, 56, 72)
        '    Button8.BackColor = Color.FromArgb(47, 56, 72)
        '    Button10.BackColor = Color.FromArgb(47, 56, 72)
        '    Button12.BackColor = Color.FromArgb(47, 56, 72)
        '    Button13.BackColor = Color.FromArgb(47, 56, 72)
        '    Button67.BackColor = Color.FromArgb(47, 56, 72)


        '    comprobartipoingreso()
        'Else

        picturepagado.Visible = False

            TabControl1.SelectedIndex = 10
            Button1.BackColor = Color.FromArgb(47, 56, 72)
            Button2.BackColor = Color.FromArgb(47, 56, 72)
            Button3.BackColor = Color.FromArgb(47, 56, 72)
            Button4.BackColor = Color.FromArgb(47, 56, 72)
            Button5.BackColor = Color.FromArgb(47, 56, 72)
            Button6.BackColor = Color.FromArgb(47, 56, 72)
            Button8.BackColor = Color.FromArgb(47, 56, 72)
            Button10.BackColor = Color.FromArgb(47, 56, 72)
            Button12.BackColor = Color.FromArgb(47, 56, 72)
            Button13.BackColor = Color.FromArgb(47, 56, 72)
            Button67.BackColor = Color.DimGray




            listaservicios.Visible = False
            stxtlistaclientes.Visible = False
            lbmensaje.Visible = False

            '------------------se obtiene el folio para la venta del servicio
            sobtenerfolio()

            grilla2.Visible = False
            'cargarmarcos()
            'listacolores.Visible = False

            cargarformadepago()

        'End If

    End Sub

    Private Sub stxtlistaclientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles stxtlistaclientes.SelectedIndexChanged

    End Sub

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

            If tipoventa = 1 Or tipoventa = 3 Then
                MsgBox("El folio corresponde a una venta de productos no de servicios", MsgBoxStyle.Exclamation, "CTRL+y")
                lbmensaje.Visible = True
                sborrartodo()
                sgrilla2.Visible = True
                sgrilla2.Visible = False
                'sgrilla.Visible = False
                ' nuevoservicio()

            ElseIf tipoventa = 2 Then
                'en caso de que el tipo de venta sea de 2 entonces significa que si es un servicio y lo buscamos y cargamos
                '----cargamos el folio a la ventana de servicios de la ventana de servicios
                lbmensaje.Visible = False
                cargarfolioventa()
                'agregargrillaventa()
                sgrilla2.Visible = True
                stxtclave.Text = ""
                'ASIGNO EL FOLIO A SLBFOLIO PARA QUE LE INDIQUEMOS QUE ESTAMOS TRABAJANDO CON LA BUSQUEDA DE UN FOLIO



                llenadogrillaventafolio()


                'bloqueamos la caja de txtanticipo
                stxtanticipo.Enabled = False



            End If


        Catch ex As Exception
            MsgBox("Folio de venta no encontrado", MsgBoxStyle.Information, "CTRL+y")
            sborrartodo()
            sgrilla2.DataSource = ""
            cerrarconexion()
        End Try

    End Function
    Function llenadogrillaventafolio()


        sgrilla2.DefaultCellStyle.Font = New Font("Arial", 20)
        sgrilla2.RowHeadersVisible = False




        'grilla.Columns(0).Width = 0
        sgrilla2.AlternatingRowsDefaultCellStyle.BackColor = Color.SkyBlue

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
        sgrilla2.DataSource = dt

        '        cgrilla.Columns(6).Width = 100

        conexionMysql.Close()
        sgrilla2.Columns(1).Width = 350

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
        stxttotalproductos.Text = reader.GetString(1).ToString()
        stxttotal.Text = reader.GetString(2).ToString()
        stxtfecharegistroventa.Text = reader.GetString(3).ToString()
        stxthoraregistroventa.Text = reader.GetString(4).ToString()
        idcliente = reader.GetString(5).ToString()
        DateTimePicker1.Text = reader.GetString(7).ToString()

        '        stxtfechaentregaventa.Text = reader.GetString(7).ToString()
        stxtanticipo.Text = reader.GetString(8).ToString()
        stxtresto.Text = reader.GetString(9).ToString()
        setxtfoliocotizador.Text = reader.GetString(13).ToString()
        Try

            idtipo_pago = reader.GetString(14).ToString()
        Catch ex As Exception

        End Try








        If CInt(stxtresto.Text) = 0 Then

            picturepagado.Visible = True
        Else
            picturepagado.Visible = False
        End If
        conexionMysql.Close()

        'cargamos los datos del tipo de pago

        cerrarconexion()
        conexionMysql.Open()
        Dim Sql22 As String
        Sql22 = "select tipo from tipo_pago where idtipo_pago=" & idtipo_pago & ";"
        Dim cmd22 As New MySqlCommand(Sql22, conexionMysql)
        reader = cmd22.ExecuteReader()
        reader.Read()
        cbformadepagoservicios.Text = reader.GetString(0).ToString()







        conexionMysql.Close()


        'cargamos el cliente, sus datos

        '


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
            indexidusuario = idcliente
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

    Private Sub Button72_Click(sender As Object, e As EventArgs) Handles Button72.Click

        Dim estadocaja As Integer


        estadocaja = comprobarcaja()

        If estadocaja = 0 Then

            Dim respuesta As String

            'comprobar cuantas filas tiene la grilla donde se almacenan los valores para agregar a la venta

            If stxtfoliobusquedaventa.Text = "" Then
                sobtenerfolio()

                sventa()



                setxtgastosgenerales.Text = ""
                setxtgananciaserigrafia.Text = ""
                setxtgananciaproducto.Text = ""
                setxtganancianeta.Text = ""
                setxtprecioestampado.Text = ""
                setxtprecioconproducto.Text = ""
                setxtfoliocotizador.Text = "0"
                stxtprecio.BackColor = Color.White
                stxttotalproducto.BackColor = Color.White
            Else
                respuesta = MsgBox("Estas consultado un folio, ¿quieres realizar una nueva venta?", MsgBoxStyle.YesNo, "CTRL+y")

                If respuesta = vbYes Then
                    nuevoservicio()
                    stxtfoliobusquedaventa.Text = ""
                    stxtclave.Focus()

                End If

            End If

            'COMPROBAMOS QUE LA CAJA DE TEXTO DE BUSQUEDA DE FOLIO ESTE VACIA PARA PODER REALIZAR UNA VENTA
        Else
            MsgBox("No existe ninguna caja abierta", MsgBoxStyle.Information, "CTRL+y")
        End If




        'sventa()

    End Sub
    Function sventa()
        ' Try

        ' MsgBox("intento 1")

        If stxttotal.Text = "" Or stxtanticipo.Text = "" Or stxtresto.Text = "" Then
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
                Sql31 = "select idcliente from cliente where concat(nombre, ' ',ap, ' ', am) like '%" & stxtcliente.Text & "%';"
                Dim cmd31 As New MySqlCommand(Sql31, conexionMysql)
                reader = cmd31.ExecuteReader()
                reader.Read()
                idcliente = reader.GetString(0).ToString()
                indexidusuario = idcliente
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
            Sql32 = "select idusuario from usuario where usuario= '" & usuarioactual & "';"
            Dim cmd32 As New MySqlCommand(Sql32, conexionMysql)
            reader = cmd32.ExecuteReader()
            reader.Read()
            idusuario = reader.GetString(0).ToString()
            conexionMysql.Close()
            '--------------------------------------------------------------------------
            cerrarconexion()

            ' MsgBox("1")




            Dim tipopago As Integer

            Try

                '---------------------------------
                '--------OBTENEMOS EL ID DEL TIPO DE PAGO DE LA VENTA
                conexionMysql.Open()
                Dim Sql322 As String
                'consultamos el id del cliente para obtener un registro de quien es al que se le esta vendiendo
                Sql322 = "SELECT idtipo_pago from tipo_pago where tipo='" & cbformadepagoservicios.Text & "';"
                Dim cmd322 As New MySqlCommand(Sql322, conexionMysql)
                reader = cmd322.ExecuteReader()
                reader.Read()
                tipopago = reader.GetString(0).ToString()
                '-------------------------------------------------
                '----------datos que se van al reporte

                conexionMysql.Close()


            Catch ex As Exception

            End Try





            '------------------------------------ insertamos el anticipo o el total que debe ..
            '-------------------------------------EN LA TABLA DE SERVICIOS_ANTICIPO

            Dim fechaentrega As String
            fechaentrega = DateTimePicker1.Value.ToString("yyyy/MM/dd")

            'MsgBox(fechaentrega)
            conexionMysql.Open()
            Dim Sql As String
            Sql = "INSERT INTO venta (idventa, cantidad, total, fecha, hora, idcliente, idusuario, fechaentrega, anticipo, resto, tipoventa,idsecotizacion,idtipo_pago) VALUES (" & slbfolio.Text & "," & stxttotalproductos.Text & ", " & CDbl(stxttotal.Text) & ", '" & fecha & "','" & hora & "', " & idcliente & ", " & idusuario & ",'" & fechaentrega & "'," & stxtanticipo.Text & "," & stxtresto.Text & ",'2'," & setxtfoliocotizador.Text & "," & tipopago & ");"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            cmd.ExecuteNonQuery()
            conexionMysql.Close()






            '---------------------------------------------------------
            'MsgBox(fechaentrega)
            conexionMysql.Open()
            Dim Sql33 As String
            ' Sql33 = "INSERT INTO venta (idventa, cantidad, total, fecha, hora, idcliente, idusuario, fechaentrega, anticipo, resto, tipoventa) VALUES (" & slbfolio.Text & "," & stxttotalproductos.Text & ", " & CDbl(stxttotal.Text) & ", '" & fecha & "','" & hora & "', " & idcliente & ", " & idusuario & ",'" & fechaentrega & "'," & stxtanticipo.Text & "," & stxtresto.Text & ",'2');"
            Sql33 = "INSERT INTO `dwin`.`SERVICIOS_vENTAS` (`idventa`, `fecha`, `hora`, `idcliente`, `anticipo`, `total`) VALUES (" & slbfolio.Text & ", '" & fecha & "', '" & hora & "', " & idcliente & ", " & stxtanticipo.Text & ", " & CDbl(stxttotal.Text) & ");"
            Dim cmd33 As New MySqlCommand(Sql33, conexionMysql)
            cmd33.ExecuteNonQuery()
            conexionMysql.Close()

            '---------------------------------------------------------------
            'ANTES DE BORRAR TODA LA INFORMACIÓN, MANDO A IMPRIMIR EL REPORTE (NOTA)






            stxtnombre.Text = ""
            stxtprecio.Text = ""
            'stxtpagar = CDbl(stxttotal.Text)
            stxttotal.Text = ""
            stxtanticipo.Text = ""
            stxtresto.Text = ""
            stxttotalproductos.Text = ""
            stxtclave.Text = ""


            conexionMysql.Close()


            stxtnombre.Text = ""
            stxtprecio.Text = ""
            'stxtpagar = CDbl(stxttotal.Text)
            stxttotal.Text = ""
            stxtanticipo.Text = ""
            stxtresto.Text = ""
            stxttotalproductos.Text = ""
            stxtclave.Text = ""






            '------------------ FIN insertar reginstro en tabla venta ---------------------------------------


            '------------------ insertar reginstro en tabla ventaIND ---------------------------------------
            Dim i As Integer = sgrilla.RowCount
            Dim j As Integer
            Dim actividad, descripcion As String
            Dim cantidad, costo, idventa As Double
            Dim idproducto As String

            conexionMysql.Open()

            'suma de valores
            For j = 0 To i - 2
                'MsgBox("valosr de j:" & j)
                'a = venta.grillaventa.Item(j, 3).Value.ToString()
                actividad = sgrilla.Rows(j).Cells(2).Value 'descripcion
                cantidad = sgrilla.Rows(j).Cells(3).Value 'cantidad
                costo = sgrilla.Rows(j).Cells(8).Value 'costo del producto aplicando o no el cotizador
                idproducto = sgrilla.Rows(j).Cells(1).Value
                descripcion = sgrilla.Rows(j).Cells(10).Value
                cerrarconexion()
                conexionMysql.Open()

                'MsgBox("el producto es:" & actividad)

                Dim Sql2 As String
                Sql2 = "INSERT INTO ventaind (actividad, cantidad, costo, idventa,idproducto,descripcion) VALUES ('" & actividad & "'," & cantidad & "," & costo & "," & slbfolio.Text & ",'" & idproducto & "','" & descripcion & "');"
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
            Sql3 = "select count(distinct idproducto) from ventaind where idventa=" & slbfolio.Text & " and idproducto <> '';"
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
            Sql4 = "select idproducto, sum(cantidad) from ventaind where idventa=" & slbfolio.Text & "  group by idproducto;"
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
            cargarformadepago()
            FRNOTASERVICIO.ShowDialog()



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
            sobtenerfolio()





            '------------------------------------------------------------------------
            'al finalizar se limpia la grilla y las cajas de texto
            'txttotalpagar.Text = ""
            'txtunidades.Text = ""
            sgrilla.Rows.Clear()
            'llamamos para obtener un nuevo folio


        End If

        '------------------ FIN insertar reginstro en tabla ventaIND ---------------------------------------
        'Catch ex As Exception
        comprobartipoingreso()
        '    MsgBox(ex.Message)
        ' End Try

    End Function

    Private Sub GroupBox26_Enter(sender As Object, e As EventArgs) Handles GroupBox26.Enter

    End Sub

    Function sborrar()
        stxtnombre.Text = ""
        stxtprecio.Text = ""
        stxtcantidad.Text = ""
        stxtdescripcion.Text = ""
        stxttotalproducto.Text = ""

    End Function

    Private Sub Stxtdescripcion_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button71_Click(sender As Object, e As EventArgs) Handles Button71.Click
        Try

            buscarfolioservicio()
            sgrilla2.Visible = True
            sgrilla.Visible = False
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button68_Click(sender As Object, e As EventArgs) Handles Button68.Click
        Dim formulario As New ADDclientes
        formulario.ShowDialog()
        listaclientes.Visible = False

    End Sub

    Private Sub Button70_Click(sender As Object, e As EventArgs) Handles Button70.Click
        Dim folioventa As Integer


        If stxtfoliobusquedaventa.Text = "" Then

            MsgBox("Accion no valida, no hay una busqueda en ejecución", MsgBoxStyle.Information, "Ctrl+y")

        Else

            folioventa = stxtfoliobusquedaventa.Text

            'MsgBox(folioventa)
            Dim formulario As New FRagregaranticipo
            'FRagregaranticipo.ShowDialog()
            formulario.ShowDialog()
            FRagregaranticipo.txtcantidad.Text = stxtfoliobusquedaventa.Text
        End If

    End Sub

    Private Sub Picturepagado_Click(sender As Object, e As EventArgs) Handles picturepagado.Click
        picturepagado.Visible = False

    End Sub

    Private Sub Stxtprecio_TextChanged(sender As Object, e As EventArgs) Handles stxtprecio.TextChanged
        Try

            stxttotalproducto.Text = CDbl(stxtprecio.Text) * CDbl(stxtcantidad.Text)
        Catch ex As Exception

        End Try

    End Sub

    Function sborrartodo()
        stxtfoliobusquedaventa.Text = ""
        stxtclave.Text = ""
        stxtcantidad.Text = ""
        stxtnombre.Text = ""
        stxtcliente.Text = ""
        stxttotal.Text = ""
        stxttotalproducto.Text = ""
        stxttotalproductos.Text = ""
        stxtanticipo.Text = ""
        stxtresto.Text = ""
        stxtfechaentregaventa.Text = ""
        stxtfecharegistroventa.Text = ""
        stxthoraregistroventa.Text = ""
        stxtdescripcion.Text = ""
    End Function

    Private Sub stxtlistaclientes_KeyDown(sender As Object, e As KeyEventArgs) Handles stxtlistaclientes.KeyDown
        If e.KeyCode = Keys.Enter Then

            'cargarservicio()

            stxtcliente.Text = stxtlistaclientes.Text

            stxtlistaclientes.Visible = False

            stxtdescripcion.Focus()


        End If

    End Sub

    Private Sub Button73_Click(sender As Object, e As EventArgs) Handles Button73.Click

        'CARGAMOS EL FORMULARIO DE FRASIGNARPRECIOSERVICIO
        Dim formulario As New frasignarprecioservicio
        formulario.ShowDialog()

    End Sub

    Private Sub Stxtnombre_TextChanged_1(sender As Object, e As EventArgs) Handles stxtnombre.TextChanged
        grilla2.Visible = False

        listaservicios.Visible = True
        listaservicios.Items.Clear()

        If stxtnombre.Text = "" Then
            listaservicios.Visible = False
            sborrar()
            'stxtclave.Text = ""


        Else

            Try

                'cerramos la conexion
                cerrarconexion()

                Dim cantidad, i As Integer
                cantidad = 0
                conexionMysql.Open()
                Dim Sql2 As String
                Sql2 = "select count(*) from producto where descripcion like '%" & stxtnombre.Text & "%';"
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
                Sql = "select descripcion from producto where descripcion like '%" & stxtnombre.Text & "%';"
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


    Public Sub sobtenerfolio()
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
            slbfolio.Text = folio + 1



            conexionMysql.Close()
            'MsgBox("si hay folio")

        Catch ex As Exception
            slbfolio.Text = folio + 1
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
                Sql4 = "INSERT INTO `dwin`.`CLIENTE` (`idcliente`, `nombre`, `ap`, `am`, `rfc`, `direccion`, `telefono`, `correo`) VALUES ('1', 'USUARIO', 'USUARIO', 'USUARIO', '000', '000', '000', '000');"
                Dim cmd4 As New MySqlCommand(Sql4, conexionMysql)
                cmd4.ExecuteNonQuery()
                conexionMysql.Close()
                MsgBox("Registro guardado correctamente", MsgBoxStyle.Information, "Sistema")

            End If


        End Try

    End Sub

    Private Sub Listaservicios_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles listaservicios.SelectedIndexChanged

    End Sub

    Private Sub stxtcliente_KeyDown(sender As Object, e As KeyEventArgs) Handles stxtcliente.KeyDown
        If e.KeyCode = Keys.Down Then
            stxtlistaclientes.Focus()


        End If

    End Sub

    Private Sub stxtprecio_DoubleClick(sender As Object, e As EventArgs) Handles stxtprecio.DoubleClick


    End Sub

    Private Sub Sgrilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles sgrilla.CellContentClick

    End Sub

    Private Sub stxtcantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles stxtcantidad.KeyDown

    End Sub

    Private Sub stxtnombre_KeyDown(sender As Object, e As KeyEventArgs) Handles stxtnombre.KeyDown
        If e.KeyCode = Keys.Down Then
            stxtlistaclientes.Focus()


        End If



    End Sub

    Private Sub Button75_Click(sender As Object, e As EventArgs) Handles Button75.Click


        cerrarconexion()
        'cargamos la ventana de frdatosorganizacion

        Dim formulario As New frdatosorganizacion

        formulario.ShowDialog()




    End Sub
    Function cargardatos_empresa()
        Try

            conexionMysql.Open()
            Dim Sql1 As String
            Sql1 = "select * from datos_empresa;"
            Dim cmd1 As New MySqlCommand(Sql1, conexionMysql)
            reader = cmd1.ExecuteReader()
            reader.Read()
            orgrfc.Text = reader.GetString(22).ToString()

            '  MsgBox(reader.GetString(22).ToString())

            orgnombre.Text = reader.GetString(1).ToString()
            orgcallenumero.Text = reader.GetString(2).ToString()
            orgcoloniaciudad.Text = reader.GetString(3).ToString()
            orgcp.Text = reader.GetString(4).ToString()
            orgestado.Text = reader.GetString(5).ToString()
            orgtelefono.Text = reader.GetString(6).ToString()
            orgwhatsapp.Text = reader.GetString(7).ToString()
            orgcorreo.Text = reader.GetString(8).ToString()
            orgfacebook.Text = reader.GetString(9).ToString()
            orgsitioweb.Text = reader.GetString(10).ToString()
            orgencargado.Text = reader.GetString(11).ToString()
            orghorario.Text = reader.GetString(12).ToString()
            orggiro.Text = reader.GetString(13).ToString()
            orgsaludo.Text = reader.GetString(20).ToString()
            ctxtminimoarticulos.Text = reader.GetString(21).ToString()


            conexionMysql.Close()
        Catch ex As Exception

        End Try

    End Function

    Private Sub GroupBox31_Enter(sender As Object, e As EventArgs) Handles GroupBox31.Enter

    End Sub

    Private Sub Label107_Click(sender As Object, e As EventArgs) Handles Label107.Click

    End Sub

    Private Sub Label105_Click(sender As Object, e As EventArgs) Handles orggiro.Click

    End Sub

    Private Sub Btnconfigticket_Click(sender As Object, e As EventArgs) Handles btnconfigticket.Click

        Dim formulario As New frmconfigticket

        formulario.ShowDialog()



    End Sub

    Private Sub Button76_Click(sender As Object, e As EventArgs) Handles btncerrarcajamenu.Click
        cerrarcaja()

        'primero vemos que forma de hacer el corte esta activa, si por tiempo o por usuario

        'Dim tipo_corte As Integer
        'tipo_corte = seleccion_tipo_corte_configuracion()
        ''MsgBox("el tipo actual es:" & tipo_corte)


        ''---------------------------------------------------------------------
        ''en caso de que sea el valor de 1, corresponde a tipo por usuario
        'If tipo_corte = 1 Then

        '    corteusuariotipo1()

        '    Dim formulario As New frmresumencorte
        '    formulario.ShowDialog()

        '    '-----------------------------------------------------------------
        '    'en caso de que sea tipo 2, corresponde a tipo por tiempo
        'ElseIf tipo_corte = 2 Then
        '    'hacemos el corte de las ventas
        '    corteusuariotipo2()
        '    'cargamos la ventana de resumen del corte para que podamos imprimir un ticket y al igual que imprimir un ticket de venta de todos los productos.

        '    Dim formulario As New frmresumencorte
        '    formulario.ShowDialog()
        '    '------------------------------------------------------------------


        'End If







        'tenemos que mandar los datos del corte... se tiene que elegir el ultimo corte registrado.
    End Sub
    Function verificarcorteusuario()



    End Function

    Function corteusuariotipo1()
        lbcalendario.Text = Date.Now
        Dim diax, mesx, añox, fechax As String
        Dim horax As String
        'MsgBox("holaaaaaaaaaaaaaaaaaaaa")


        hora2 = Now.Hour()
        minuto = Now.Minute()
        segundo = Now.Second()

        horax = hora2 & ":" & minuto & ":" & segundo

        'MsgBox(horax)


        'If horax = "0:40:0" Then

        '            MsgBox("ya es hora")

        'si son las 12:00 de la madrugada, entonces hacemos corte de caja en automatico, del usuario actual y lo guardamos

        '-------------------------------------consultamos las ventas realizadas hasta el momento
        Dim dia, mes, año, fecha As String
        Dim hora As String
        'MsgBox("holaaaaaaaaaaaaaaaaaaaa")


        hora2 = Now.Hour()
        minuto = Now.Minute()
        segundo = Now.Second()

        hora = hora2 & ":" & minuto & ":" & segundo





        dia = Date.Now.Day
        mes = Date.Now.Month
        año = Date.Now.Year
        fecha = año & "-" & mes & "-" & dia


        'Try

        'primero selecciono la hora maxima de corte de caja del día de hoy. para que desde esa hora empiece a obtener valores

        Dim horafin1 As String
        Dim idusuario As Integer

        cerrarconexion()


        conexionMysql.Open()
        Dim Sql2 As String
        Sql2 = "select idusuario from usuario where usuario='" & usuarioactual & "';"
        Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
        reader = cmd2.ExecuteReader
        reader.Read()
        idusuario = reader.GetString(0).ToString()
        conexionMysql.Close()


        conexionMysql.Open()
        Try
            Dim Sql111 As String
            Sql111 = "select max(hora_registro) from corte where fecha_registro='" & fecha & "' and idusuario = '" & idusuario & "';"
            Dim cmd111 As New MySqlCommand(Sql111, conexionMysql)
            reader = cmd111.ExecuteReader()
            reader.Read()
            horafin1 = reader.GetString(0).ToString
        Catch ex As Exception
            horafin1 = "00:00:00"
            tipoingreso()
        End Try

        conexionMysql.Close()
        '  MsgBox("la hora de registro de corte es:" & horafin)
        ' MsgBox("la hora DELSISTEMA ES:" & hora)
        cerrarconexion()




        ''-----------------CONSULTAMOS SI EN EL CORTE SE HACE DE MAS DE 1 USUARIO, YA QUE UNO DE ELLOS
        ''-----------------PUDO NO HABER HECHO SU CORTE, ENTONCES LE INDICAMOS AL USUARIO QUE SE HACE DE DOS
        'Dim cantidadusuarioscorte As Integer
        'Dim observacion As String
        'observacion = ""
        'conexionMysql.Open()
        'Dim Sql3 As String
        'Sql3 = "select count(distinct idusuario) from venta where fecha='" & fecha & "' and hora between '" & horafin1 & "' and '" & hora & "';"

        'Dim cmd3 As New MySqlCommand(Sql3, conexionMysql)
        'reader = cmd3.ExecuteReader()
        'reader.Read()
        'cantidadusuarioscorte = reader.GetString(0).ToString
        ''conexionMysql.Close()

        'If cantidadusuarioscorte > 1 Then
        '    observacion = "EL CORTE SE HIZO CON MAS DE 1 USUARIO, ADVERTENCIA"
        'End If


        'conexionMysql.Close()

        '---------------------------------------------------------------------------------
        '---------------------------------------------------------------------------------
        '---------------------------------------------------------------------------------
        '---------------------------------------------------------------------------------

        conexionMysql.Open()
        Dim Sqla1 As String
        Dim totalcorteventa As String
        Dim totalproductosvendidos As Integer
        'Sql = "select sum(total), fecha from venta where fecha='" & fecha & "';"
        Sqla1 = "select sum(total), sum(cantidad) from venta where fecha='" & fecha & "' and hora between '" & horafin1 & "' and '" & hora & "' and idusuario='" & idusuario & "';"
        Dim cmda1 As New MySqlCommand(Sqla1, conexionMysql)
        reader = cmda1.ExecuteReader()
        reader.Read()
        Try
            totalcorteventa = reader.GetString(0).ToString
            totalproductosvendidos = reader.GetString(1).ToString
        Catch ex As Exception
            ' MsgBox("Aun no hay ventas.", MsgBoxStyle.Information, "Sistema")
            totalcorteventa = 0
            totalproductosvendidos = 0
            'si aun no hay ventas, intentamos cargar los cortes de caja que se han hecho.

            '-----------------------------------------------------------------------------------
            'cargamos una funcion que manda a la grilla todos los cortes de caja que se han realizado.

            cerrarconexion()

            'conexionMysql.Open()
            'Dim Sqlx12 As String
            'Sqlx12 = "select corte.idcorte, corte.extras, corte.fecha_registro, corte.hora_registro, usuario.usuario from corte, usuario where corte.fecha_registro='" & fecha & "'  and corte.idusuario=usuario.idusuario;"
            'Dim cmdx12 As New MySqlCommand(Sqlx12, conexionMysql)
            'Dim dt As New DataTable
            'Dim da As New MySqlDataAdapter(cmdx12)
            ''cargamos el formulario  resumen
            'da.Fill(dt)
            'cgrillacorte.DataSource = dt
            'cgrillacorte.Columns(0).Width = 50
            ''cgrillacorte.Columns(1).Width = 20
            'cgrillacorte.Columns(2).Width = 100
            'cgrillacorte.Columns(3).Width = 100
            'cgrillacorte.Columns(4).Width = 190
            ''cgrillacorte.Columns(5).Width = 80
            ''cgrillacorte.Columns(5).Width = 180

            'conexionMysql.Close()




        End Try

        conexionMysql.Close()
        cerrarconexion()
        ' Catch ex As Exception

        'End Try

        'obtener totales






        '--------------------------------------------------------------------------------------------- '---------------------------------------------------------------------------------------------
        '---------------------------------------------------------------------------------------------
        'primero seleccionamos el corte que se va a realizar

        ' Dim dia, mes, año, fecha As String
        'Dim hora As String
        'MsgBox("holaaaaaaaaaaaaaaaaaaaa")


        hora2 = Now.Hour()
        minuto = Now.Minute()
        segundo = Now.Second()

        hora = hora2 & ":" & minuto & ":" & segundo



        dia = Date.Now.Day
        mes = Date.Now.Month
        año = Date.Now.Year
        fecha = año & "-" & mes & "-" & dia


        'Try

        'primero selecciono la hora maxima de corte de caja del día de hoy. para que desde esa hora empiece a obtener valores

        Dim horafin As String

        cerrarconexion()

        conexionMysql.Open()
        Try
            Dim Sql1 As String
            Sql1 = "select max(hora_registro) from corte where fecha_registro='" & fecha & "' and idusuario='" & idusuario & "';"
            Dim cmd1 As New MySqlCommand(Sql1, conexionMysql)
            reader = cmd1.ExecuteReader()
            reader.Read()

            horafin = reader.GetString(0).ToString
        Catch ex As Exception
            horafin = "00:00:00"
            '    tipoingreso()

        End Try

        conexionMysql.Close()
        '  MsgBox("la hora de registro de corte es:" & horafin)
        ' MsgBox("la hora DELSISTEMA ES:" & hora)

        cerrarconexion()

        conexionMysql.Open()

        Dim Sqlx1 As String
        Dim totalcortecompra As String
        'Sql = "select sum(total), fecha from venta where fecha='" & fecha & "';"
        Sqlx1 = "select sum(total)  from compra where fecha='" & fecha & "' and hora between '" & horafin & "' and '" & hora & "' and idusuario='" & idusuario & "';"
        Dim cmdx1 As New MySqlCommand(Sqlx1, conexionMysql)
        reader = cmdx1.ExecuteReader()
        reader.Read()
        Try
            totalcortecompra = reader.GetString(0).ToString
        Catch ex As Exception
            'MsgBox("Aun no hay compras", MsgBoxStyle.Information, "Sistema")
            totalcortecompra = 0

            'si aun no hay ventas, intentamos cargar los cortes de caja que se han hecho.

            '-----------------------------------------------------------------------------------
            'cargamos una funcion que manda a la grilla todos los cortes de caja que se han realizado.




        End Try

        '----------------------------------------------------------------------------------------------



        'obtener fecha y hora
        ' Dim dia, mes, año, fecha As String

        hora2 = Now.Hour()
        minuto = Now.Minute()
        segundo = Now.Second()

        hora = hora2 & ":" & minuto & ":" & segundo

        dia = Date.Now.Day
        mes = Date.Now.Month
        año = Date.Now.Year
        fecha = año & "-" & mes & "-" & dia


        'consultamos el usuario para saber sobre quien se hizo el corte
        ' el usuario se encuentra en la variable usuarioactual

        '--------------------------------------------------------------------
        'Dim idusuario As Integer


        cerrarconexion()

        'MsgBox(usuarioactual)





        '------------------ insertar reginstro en tabla venta ---------------------------------------
        cerrarconexion()

        If conexionMysql.State = ConnectionState.Open Then
            conexionMysql.Close()
            ' MsgBox("Si estaba abierta")
        End If

        If totalcorteventa = "" Or totalcortecompra = "" Then
            MsgBox("Existen campos vacios", MsgBoxStyle.Information, "Sistema")

        Else




            cerrarconexion()


            'If ctxtextras.Text = 0 Or ctxtcompras.Text = 0 Or ctxttotalescorte.Text Then
            'MsgBox("No es posible hacer un corte con Cero ventas")
            'Else



            Dim tipo_Corte_configuracion As Integer

            tipo_Corte_configuracion = seleccion_tipo_corte_configuracion()



            conexionMysql.Open()

            Dim Sql As String
            Sql = "INSERT INTO corte (`extras`, `fecha_registro`, `hora_registro`,`idusuario`,`compra`,`horainicio`,`horafin`,`observacion`,`tipocorte`,`cant_productos` ) VALUES ('" & totalcorteventa & "', '" & fecha & "', '" & hora & "'," & idusuario & "," & totalcortecompra & ",'" & horafin1 & "', '" & hora & "', ''," & tipo_Corte_configuracion & "," & totalproductosvendidos & ");"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            cmd.ExecuteNonQuery()


            MsgBox("Registro Guardado", MsgBoxStyle.Information, "Sistema")
            'MsgBox("Se ha generado automaticamente un corte siendo las 12:00 horas, para mantener la integridad del sistema, se iniciara con un nuevo registro de venta", MsgBoxStyle.Exclamation, "Sistema")






            'pass.Text = nombre
            ' desglosecorte()
            'consultarcortecalendario()
            conexionMysql.Close()

            'borrarcorte()
            ' consultarcorte()

            'Dim respuesta As String
            'respuesta = MsgBox("¿Desea realizar la impresion de su corte de caja del día?", MsgBoxStyle.YesNo & MsgBoxStyle.Information, "Sistema")

            'End If


        End If





        'Else

        '    ' MsgBox("aun no es hora")
        'End If

    End Function


    Function corteusuariotipo2()
        lbcalendario.Text = Date.Now
        Dim diax, mesx, añox, fechax As String
        Dim horax As String
        'MsgBox("holaaaaaaaaaaaaaaaaaaaa")


        hora2 = Now.Hour()
        minuto = Now.Minute()
        segundo = Now.Second()

        horax = hora2 & ":" & minuto & ":" & segundo

        'MsgBox(horax)


        'If horax = "0:40:0" Then

        '            MsgBox("ya es hora")

        'si son las 12:00 de la madrugada, entonces hacemos corte de caja en automatico, del usuario actual y lo guardamos





        '-------------------------------------consultamos las ventas realizadas hasta el momento
        Dim dia, mes, año, fecha As String
        Dim hora As String
        'MsgBox("holaaaaaaaaaaaaaaaaaaaa")


        hora2 = Now.Hour()
        minuto = Now.Minute()
        segundo = Now.Second()

        hora = hora2 & ":" & minuto & ":" & segundo





        dia = Date.Now.Day
        mes = Date.Now.Month
        año = Date.Now.Year
        fecha = año & "-" & mes & "-" & dia


        'Try

        'primero selecciono la hora maxima de corte de caja del día de hoy. para que desde esa hora empiece a obtener valores

        Dim horafin1 As String


        cerrarconexion()

        conexionMysql.Open()
        Try
            Dim Sql111 As String
            Sql111 = "select max(hora_registro) from corte where fecha_registro='" & fecha & "';"
            Dim cmd111 As New MySqlCommand(Sql111, conexionMysql)
            reader = cmd111.ExecuteReader()
            reader.Read()

            horafin1 = reader.GetString(0).ToString
        Catch ex As Exception
            horafin1 = "00:00:00"
            tipoingreso()
        End Try

        conexionMysql.Close()
        '  MsgBox("la hora de registro de corte es:" & horafin)
        ' MsgBox("la hora DELSISTEMA ES:" & hora)
        cerrarconexion()




        '-----------------CONSULTAMOS SI EN EL CORTE SE HACE DE MAS DE 1 USUARIO, YA QUE UNO DE ELLOS
        '-----------------PUDO NO HABER HECHO SU CORTE, ENTONCES LE INDICAMOS AL USUARIO QUE SE HACE DE DOS
        Dim cantidadusuarioscorte As Integer
        Dim observacion As String
        observacion = ""
        conexionMysql.Open()
        Dim Sql3 As String
        Sql3 = "select count(distinct idusuario) from venta where fecha='" & fecha & "' and hora between '" & horafin1 & "' and '" & hora & "';"

        Dim cmd3 As New MySqlCommand(Sql3, conexionMysql)
        reader = cmd3.ExecuteReader()
        reader.Read()
        cantidadusuarioscorte = reader.GetString(0).ToString
        'conexionMysql.Close()

        If cantidadusuarioscorte > 1 Then
            observacion = "EL CORTE SE HIZO CON MAS DE 1 USUARIO, ADVERTENCIA"
        End If


        conexionMysql.Close()

        '---------------------------------------------------------------------------------
        '---------------------------------------------------------------------------------
        '---------------------------------------------------------------------------------
        '---------------------------------------------------------------------------------







        conexionMysql.Open()

        Dim cantidad_total_productos As String


        Dim Sqla1 As String
        Dim totalcorteventa As String
        'Sql = "select sum(total), fecha from venta where fecha='" & fecha & "';"
        Sqla1 = "select sum(total) as suma, sum(cantidad)  from venta where fecha='" & fecha & "' and hora between '" & horafin1 & "' and '" & hora & "';"
        Dim cmda1 As New MySqlCommand(Sqla1, conexionMysql)
        reader = cmda1.ExecuteReader()
        reader.Read()
        Try
            totalcorteventa = reader.GetString(0).ToString
            cantidad_total_productos = reader.GetString(1).ToString


        Catch ex As Exception
            ' MsgBox("Aun no hay ventas.", MsgBoxStyle.Information, "Sistema")
            totalcorteventa = 0
            cantidad_total_productos = 0

            'si aun no hay ventas, intentamos cargar los cortes de caja que se han hecho.

            '-----------------------------------------------------------------------------------
            'cargamos una funcion que manda a la grilla todos los cortes de caja que se han realizado.

            cerrarconexion()

            'conexionMysql.Open()
            'Dim Sqlx12 As String
            'Sqlx12 = "select corte.idcorte, corte.extras, corte.fecha_registro, corte.hora_registro, usuario.usuario from corte, usuario where corte.fecha_registro='" & fecha & "'  and corte.idusuario=usuario.idusuario;"
            'Dim cmdx12 As New MySqlCommand(Sqlx12, conexionMysql)
            'Dim dt As New DataTable
            'Dim da As New MySqlDataAdapter(cmdx12)
            ''cargamos el formulario  resumen
            'da.Fill(dt)
            'cgrillacorte.DataSource = dt
            'cgrillacorte.Columns(0).Width = 50
            ''cgrillacorte.Columns(1).Width = 20
            'cgrillacorte.Columns(2).Width = 100
            'cgrillacorte.Columns(3).Width = 100
            'cgrillacorte.Columns(4).Width = 190
            ''cgrillacorte.Columns(5).Width = 80
            ''cgrillacorte.Columns(5).Width = 180

            'conexionMysql.Close()




        End Try

        conexionMysql.Close()
        cerrarconexion()
        ' Catch ex As Exception

        'End Try

        'obtener totales






        '--------------------------------------------------------------------------------------------- '---------------------------------------------------------------------------------------------
        '---------------------------------------------------------------------------------------------
        'primero seleccionamos el corte que se va a realizar

        ' Dim dia, mes, año, fecha As String
        'Dim hora As String
        'MsgBox("holaaaaaaaaaaaaaaaaaaaa")


        hora2 = Now.Hour()
        minuto = Now.Minute()
        segundo = Now.Second()

        hora = hora2 & ":" & minuto & ":" & segundo



        dia = Date.Now.Day
        mes = Date.Now.Month
        año = Date.Now.Year
        fecha = año & "-" & mes & "-" & dia


        'Try

        'primero selecciono la hora maxima de corte de caja del día de hoy. para que desde esa hora empiece a obtener valores

        Dim horafin As String

        cerrarconexion()

        conexionMysql.Open()
        Try
            Dim Sql1 As String
            Sql1 = "select max(hora_registro) from corte where fecha_registro='" & fecha & "';"
            Dim cmd1 As New MySqlCommand(Sql1, conexionMysql)
            reader = cmd1.ExecuteReader()
            reader.Read()

            horafin = reader.GetString(0).ToString
        Catch ex As Exception
            horafin = "00:00:00"
            '    tipoingreso()

        End Try

        conexionMysql.Close()
        '  MsgBox("la hora de registro de corte es:" & horafin)
        ' MsgBox("la hora DELSISTEMA ES:" & hora)

        cerrarconexion()

        conexionMysql.Open()

        Dim Sqlx1 As String
        Dim totalcortecompra As String
        'Sql = "select sum(total), fecha from venta where fecha='" & fecha & "';"
        Sqlx1 = "select sum(total)  from compra where fecha='" & fecha & "' and hora between '" & horafin & "' and '" & hora & "';"
        Dim cmdx1 As New MySqlCommand(Sqlx1, conexionMysql)
        reader = cmdx1.ExecuteReader()
        reader.Read()
        Try
            totalcortecompra = reader.GetString(0).ToString
        Catch ex As Exception
            'MsgBox("Aun no hay compras", MsgBoxStyle.Information, "Sistema")
            totalcortecompra = 0

            'si aun no hay ventas, intentamos cargar los cortes de caja que se han hecho.

            '-----------------------------------------------------------------------------------
            'cargamos una funcion que manda a la grilla todos los cortes de caja que se han realizado.




        End Try

        '----------------------------------------------------------------------------------------------



        'obtener fecha y hora
        ' Dim dia, mes, año, fecha As String

        hora2 = Now.Hour()
        minuto = Now.Minute()
        segundo = Now.Second()

        hora = hora2 & ":" & minuto & ":" & segundo

        dia = Date.Now.Day
        mes = Date.Now.Month
        año = Date.Now.Year
        fecha = año & "-" & mes & "-" & dia


        'consultamos el usuario para saber sobre quien se hizo el corte
        ' el usuario se encuentra en la variable usuarioactual

        '--------------------------------------------------------------------
        Dim idusuario As Integer


        cerrarconexion()

        'MsgBox(usuarioactual)


        conexionMysql.Open()
        Dim Sql2 As String
        Sql2 = "select idusuario from usuario where usuario='" & usuarioactual & "';"
        Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
        reader = cmd2.ExecuteReader
        reader.Read()
        idusuario = reader.GetString(0).ToString()


        '------------------ insertar reginstro en tabla venta ---------------------------------------
        cerrarconexion()

        If conexionMysql.State = ConnectionState.Open Then
            conexionMysql.Close()
            ' MsgBox("Si estaba abierta")
        End If

        If totalcorteventa = "" Or totalcortecompra = "" Then
            MsgBox("Existen campos vacios", MsgBoxStyle.Information, "Sistema")

        Else




            cerrarconexion()


            'If ctxtextras.Text = 0 Or ctxtcompras.Text = 0 Or ctxttotalescorte.Text Then
            'MsgBox("No es posible hacer un corte con Cero ventas")
            'Else

            Dim tipo_Corte_configuracion As Integer

            tipo_Corte_configuracion = seleccion_tipo_corte_configuracion()




            conexionMysql.Open()

            Dim Sql As String
            Sql = "INSERT INTO corte (`extras`, `fecha_registro`, `hora_registro`,`idusuario`,`compra`,`horainicio`,`horafin`,`observacion`,`tipocorte`, `cant_productos`  ) VALUES ('" & totalcorteventa & "', '" & fecha & "', '" & hora & "'," & idusuario & "," & totalcortecompra & ",'" & horafin1 & "', '" & hora & "', '" & observacion & "'," & tipo_Corte_configuracion & ", " & cantidad_total_productos & ");"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            cmd.ExecuteNonQuery()


            MsgBox("Registro Guardado", MsgBoxStyle.Information, "Sistema")
            'MsgBox("Se ha generado automaticamente un corte siendo las 12:00 horas, para mantener la integridad del sistema, se iniciara con un nuevo registro de venta", MsgBoxStyle.Exclamation, "Sistema")






            'pass.Text = nombre
            ' desglosecorte()
            'consultarcortecalendario()
            conexionMysql.Close()

            'borrarcorte()
            ' consultarcorte()

            'Dim respuesta As String
            'respuesta = MsgBox("¿Desea realizar la impresion de su corte de caja del día?", MsgBoxStyle.YesNo & MsgBoxStyle.Information, "Sistema")

            'End If


        End If





        'Else

        '    ' MsgBox("aun no es hora")
        'End If

    End Function

    Private Sub Rbusuario_CheckedChanged(sender As Object, e As EventArgs) Handles rbusuario.CheckedChanged
        Try


            'en caso de haber seleccionado que se haga el corte por usuario, actualizamos el estado del usuario a 1 y colorcamos
            'el de tiempo en cero en su estado (campo)
            conexionMysql.Open()
            Dim Sql2 As String
            Sql2 = "UPDATE `dwin`.`tipo_corte` SET `estado` = '1' WHERE (`idtipo_corte` = '1');"
            Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            cmd2.ExecuteNonQuery()
            conexionMysql.Close()
            conexionMysql.Open()
            Dim Sql22 As String
            Sql22 = "UPDATE `dwin`.`tipo_corte` SET `estado` = '0' WHERE (`idtipo_corte` = '2');"
            Dim cmd22 As New MySqlCommand(Sql22, conexionMysql)
            cmd22.ExecuteNonQuery()
            conexionMysql.Close()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Rbtiempo_CheckedChanged(sender As Object, e As EventArgs) Handles rbtiempo.CheckedChanged


        Try

            'en caso de haber seleccionado que se haga el corte por usuario, actualizamos el estado del usuario a 1 y colorcamos
            'el de tiempo en cero en su estado (campo)
            conexionMysql.Open()
            Dim Sql2 As String
            Sql2 = "UPDATE `dwin`.`tipo_corte` SET `estado` = '0' WHERE (`idtipo_corte` = '1');"
            Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            cmd2.ExecuteNonQuery()
            conexionMysql.Close()
            conexionMysql.Open()
            Dim Sql22 As String
            Sql22 = "UPDATE `dwin`.`tipo_corte` SET `estado` = '1' WHERE (`idtipo_corte` = '2');"
            Dim cmd22 As New MySqlCommand(Sql22, conexionMysql)
            cmd22.ExecuteNonQuery()
            conexionMysql.Close()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Chticket_CheckedChanged(sender As Object, e As EventArgs) Handles chticket.CheckedChanged
        cerrarconexion()

        Try
            cerrarconexion()
            Dim valor As Integer
            valor = 0
            If chticket.Checked = True Then
                valor = 1
            ElseIf chticket.Checked = False Then
                valor = 0
            End If

            'MsgBox("LA IMPRESORA A GUARDAR ES:" & impresosaPredt)


            conexionMysql.Open()
            Dim Sql22 As String
            Sql22 = "UPDATE `datos_empresa` SET `obligarticket` = '" & valor & "';"
            Dim cmd22 As New MySqlCommand(Sql22, conexionMysql)
            cmd22.ExecuteNonQuery()
            conexionMysql.Close()
            'MsgBox("Valor Actrualizado", MsgBoxStyle.Information, "CTRL+y")

        Catch ex As Exception
            MsgBox(ex.Message, "12")
        End Try
    End Sub

    Private Sub Chcambio_CheckedChanged(sender As Object, e As EventArgs) Handles chcambio.CheckedChanged
        'Try
        Dim valor As Integer
        valor = 0
        If chticket.Checked = True Then
            valor = 1
        ElseIf chticket.Checked = False Then
            valor = 0
        End If

        'MsgBox("LA IMPRESORA A GUARDAR ES:" & impresosaPredt)


        conexionMysql.Open()
        Dim Sql22 As String
        Sql22 = "UPDATE `dwin`.`datos_empresa` SET `obligarcambio` = '" & valor & "';"
        Dim cmd22 As New MySqlCommand(Sql22, conexionMysql)
        cmd22.ExecuteNonQuery()
        conexionMysql.Close()
        'MsgBox("Valor Actualizado", MsgBoxStyle.Information, "CTRL+y")

        'Catch ex As Exception
        'MsgBox(ex.Message, "13")
        'End Try
    End Sub

    'Private Sub Button78_Click(sender As Object, e As EventArgs)
    '    nuevoservicio()

    'End Sub
    Function nuevoservicio()
        stxtcantidad.Text = ""
        stxtcliente.Text = ""
        stxtdescripcion.Text = ""
        stxtprecio.Text = ""
        stxttotal.Text = ""
        stxtanticipo.Text = ""
        stxtresto.Text = ""
        stxttotalproductos.Text = ""
        stxttotalproducto.Text = ""
        stxtclave.Text = ""
        stxtnombre.Text = ""
        sgrilla.Rows.Clear()
        sgrilla2.Visible = False
        sgrilla.Visible = True
        'habilitamos la caja de anticipo
        stxtanticipo.Enabled = True
        stxtfechaentregaventa.Text = ""
        stxtfecharegistroventa.Text = ""
        stxthoraregistroventa.Text = ""
        txtcostoproductoserigrafia.Text = ""
        stxtgananciatotalproductos.Text = ""
        stxtpagarcon.Text = ""
        stxtpagarsin.Text = ""
        stxtfoliobusquedaventa.Text = ""
        picturepagado.Visible = False






        setxtgastosgenerales.Text = ""
        setxtgananciaserigrafia.Text = ""
        setxtgananciaproducto.Text = ""
        setxtganancianeta.Text = ""
        setxtprecioestampado.Text = ""
        setxtprecioconproducto.Text = ""
        setxtfoliocotizador.Text = "0"
        stxtprecio.BackColor = Color.White
        stxttotalproducto.BackColor = Color.White


        'ASIGNAMOS NUEVA FECHA ACTUAL AL DATETIMEPICKER1
        DateTimePicker1.Value = Date.Now

        'CARGAMOS LOS TIPOS DE PAGO NUEVAMENTE
        cargarformadepago()



    End Function
    Private Sub Stxttotal_TextChanged(sender As Object, e As EventArgs) Handles stxttotal.TextChanged

    End Sub

    Private Sub PrintDocument_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument.PrintPage

    End Sub

    Private Sub Button80_Click(sender As Object, e As EventArgs)
        Dim formulario As New frmcalculomarco
        'FRagregaranticipo.ShowDialog()
        formulario.ShowDialog()
    End Sub



    'Function cargarmarcos()
    '    Try
    '        cbmmarco.Items.Clear()
    '        'cerramos la conexion
    '        cerrarconexion()

    '        Dim cantidad, i As Integer
    '        cantidad = 0
    '        conexionMysql.Open()
    '        Dim Sql2 As String
    '        Sql2 = "select count(*) from cotizador_marco;"
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
    '        Sql = "select medida from cotizador_marco;"
    '        Dim cmd As New MySqlCommand(Sql, conexionMysql)
    '        reader = cmd.ExecuteReader
    '        For i = 1 To cantidad
    '            reader.Read()

    '            cbmmarco.Items.Add(reader.GetString(0).ToString)
    '        Next


    '        conexionMysql.Close()

    '    Catch ex As Exception
    '        cerrarconexion()
    '    End Try
    'End Function

    Private Sub GroupBox34_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button81_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Txtcantidadmarcos_TextChanged(sender As Object, e As EventArgs)
        'Try

        '    txtcantidadimpresiones.Text = txtcantidadmarcos.Text
        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub Txt_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Listacolores_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button77_Click(sender As Object, e As EventArgs) Handles Button77.Click


        'actualizamos la impresora seleccionada
        Try


            Dim instance As New Printing.PrinterSettings
            Dim impresosaPredt As String = instance.PrinterName
            'MsgBox("LA IMPRESORA A GUARDAR ES:" & impresosaPredt)

            txtnombreimpresora.Text = impresosaPredt

            conexionMysql.Open()
            Dim Sql22 As String
            Sql22 = "UPDATE `dwin`.`impresora` SET `nombre_impresora` = '" & impresosaPredt & "';"
            Dim cmd22 As New MySqlCommand(Sql22, conexionMysql)
            cmd22.ExecuteNonQuery()
            conexionMysql.Close()
            MsgBox("Impresora Actualizada", MsgBoxStyle.Information, "CTRL+y")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Txtfoliotinta_TextChanged(sender As Object, e As EventArgs)
        '   sgrilla2.Visible = False


        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub Txttintausada_TextChanged(sender As Object, e As EventArgs)

    End Sub


    Private Sub Button74_Click(sender As Object, e As EventArgs) Handles Button74.Click


        'ocultamos la grilla de corte y mostrarmos las grillas de entradas y salidas.
        cgrillacorte.Visible = True
        cgrillaentrada.Visible = False
        cgrillasalida.Visible = False
        clbentrada.Visible = False
        clbsalidas.Visible = False


        consultarcortecalendario()

    End Sub

    Private Sub Button79_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub Sgrilla2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles sgrilla2.CellContentClick

    End Sub

    Private Sub Grillacolores_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub listaservicios_KeyDown(sender As Object, e As KeyEventArgs) Handles listaservicios.KeyDown
        If e.KeyCode = Keys.Enter Then
            cargarservicio()
            stxtcantidad.Focus()
            listaservicios.Visible = False
        End If
    End Sub

    Private Sub TextBox1_TextChanged_2(sender As Object, e As EventArgs)

    End Sub

    Private Sub Txthorastrabajo_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub listaservicios_DoubleClick(sender As Object, e As EventArgs) Handles listaservicios.DoubleClick
        cargarservicio()
        listaservicios.Visible = False
        stxtcantidad.Focus()
    End Sub
    Function comprobacionproductoserigrafia()

        If stxtclave.Text = "" Then

            stxtclave.BackColor = Color.Coral
            'break
            stxtclave.Focus()




            Return False
        Else
            If stxtnombre.Text = "" Then
                stxtnombre.BackColor = Color.Coral
                stxtnombre.Focus()
                Return False
            Else

                If stxtcantidad.Text = "" Then
                    stxtcantidad.BackColor = Color.Coral
                    stxtcantidad.Focus()

                    Return False
                    'MsgBox("asdasdasd")

                Else
                    'en caso contrario, si llega a este punto, significa que todo esta bien, y devolvemos un valor true

                    Return True


                End If
            End If

        End If

    End Function
    Private Sub Button79_Click_1(sender As Object, e As EventArgs)

        Dim valor As Boolean

        'valor = comprobacionproductoserigrafia()

        Try

            'If valor = True Then
            If stxtpagarsin.Text <> 0 Then

                Dim formulario As New frmgastosgralesserigrafia
                'FRagregaranticipo.ShowDialog()
                formulario.ShowDialog()
            Else
                MsgBox("No hay productos para aplicar una cotización", MsgBoxStyle.Information, "CTRL+y")

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Txtcostoporhora_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub sgrilla_DoubleClick(sender As Object, e As EventArgs) Handles sgrilla.DoubleClick
        Try

            'eliminar datos al dar doble clic.
            'grilla.CurrentRow.Index
            sgrilla.Rows.RemoveAt(sgrilla.CurrentRow.Index)
            'eliminado el registro, sumamos el total de valores. 
            ssumatorio()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub stxtlistaclientes_DoubleClick(sender As Object, e As EventArgs) Handles stxtlistaclientes.DoubleClick
        stxtcliente.Text = stxtlistaclientes.Text
        stxtlistaclientes.Visible = False
        stxtdescripcion.Focus()
    End Sub


    Private Sub Button80_Click_1(sender As Object, e As EventArgs) Handles Button80.Click
        stxtprecio.Text = setxtprecioestampado.Text
        stxtprecio.BackColor = Color.Wheat
        stxttotalproducto.BackColor = Color.Wheat
    End Sub

    Private Sub Button81_Click_1(sender As Object, e As EventArgs) Handles Button81.Click
        cerrarconexion()
        aplicarcotizacion()

        'Try

        '    conexionMysql.Open()

        '    Dim Sql As String
        '    Sql = "select * from producto where idproducto='" & stxtclave.Text & "';"
        '    Dim cmd As New MySqlCommand(Sql, conexionMysql)
        '    reader = cmd.ExecuteReader()
        '    reader.Read()
        '    stxtnombre.Text = reader.GetString(1).ToString()
        '    '            txtcantidad.Text = reader.GetString(4).ToString()


        '    'MsgBox("Se caego la clave")
        '    'Dim precio As String

        '    'listaservicios.Visible = False



        '    'precio = reader.GetString(1).ToString()
        '    'txtprecio.Text = precio

        '    reader.Close()
        '    conexionMysql.Close()


        '    stxtprecio.Text = setxtprecioconproducto.Text
        '    stxtprecio.BackColor = Color.LightCoral
        '    stxttotalproducto.BackColor = Color.LightCoral



        'Catch ex As Exception
        '    MsgBox("No hay productos disponibles", MsgBoxStyle.Information, "CTRL+y")
        '    stxtprecio.BackColor = Color.White
        '    stxttotalproducto.BackColor = Color.White



        'End Try


    End Sub

    Private Sub Setxtfoliocotizador_TextChanged(sender As Object, e As EventArgs) Handles setxtfoliocotizador.TextChanged
        'Try

        cerrarconexion()


        Try


            conexionMysql.Open()


            Dim Sql111 As String
            Sql111 = "select gastosgenerales,gananciaserigrafia,gananciaproducto,ganancianeta,costosoloestampado,costoconproducto from secotizacion where idsecotizacion=" & setxtfoliocotizador.Text & ";"
            Dim cmd111 As New MySqlCommand(Sql111, conexionMysql)
            reader = cmd111.ExecuteReader()
            reader.Read()

            setxtgastosgenerales.Text = reader.GetString(0).ToString
            setxtgananciaserigrafia.Text = reader.GetString(1).ToString
            setxtgananciaproducto.Text = reader.GetString(2).ToString
            setxtganancianeta.Text = reader.GetString(3).ToString
            setxtprecioestampado.Text = reader.GetString(4).ToString
            setxtprecioconproducto.Text = reader.GetString(5).ToString

            conexionMysql.Close()


            'al recibir un valor, en automatico que cambie los valores del folio
            'Catch ex As Exception

            'End Try


        Catch ex As Exception
            cerrarconexion()
        End Try



    End Sub

    Private Sub Button82_Click(sender As Object, e As EventArgs)
        ' Form1.Show()

    End Sub
    Public Function cargarlogo()

        'Try
        '    Dim rI As ADODB.Recordset, cI As ADODB.Connection
        '    'función que conecta a base de datos y retorna recordset
        '    ConnSQL(rI, cI "BDEMPRESA", "SERVIDOR", "sa", "emp48", "Select foto from clientes(NOLOCK) where codcli='" & codigoCliente & "'")
        '    If Not rI.EOF Then
        '        Dim bits As Byte() = CType(rI.Fields("imagen").Value, Byte())
        '        Dim memorybits As New System.IO.MemoryStream(bits)
        '        Dim bitmap As New Bitmap(memorybits)
        '        picturebox1.Image = bitmap
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        '------------------------------------------------------------------------
        'conexionMysql.Open()

        'Dim logo As Byte()
        'Dim Sql111 As String
        'Sql111 = "select logo from logo_empresa"
        'Dim cmd111 As New MySqlCommand(Sql111, conexionMysql)
        'reader = cmd111.ExecuteReader()
        'reader.Read()
        'logo = reader.
        'Me.pblogo.Image = Bytes_Imagen(logo)
        ''pblogo.Image = reader.GetBytes(0).ToString
        ''reader.GetString(0).ToString
        'setxtgananciaserigrafia.Text = reader.GetString(1).ToString
        'setxtgananciaproducto.Text = reader.GetString(2).ToString
        'setxtganancianeta.Text = reader.GetString(3).ToString
        'setxtprecioestampado.Text = reader.GetString(4).ToString
        'setxtprecioconproducto.Text = reader.GetString(5).ToString

        'conexionMysql.Close()
        '--------------------------------------------------
        Try
            ' Dim strconexion As String
            ' strconexion = "Server=" & d1 & "; DataBase=" & bd & "; UID=" & user & "; PWD=" & pass & "; Port=" & puerto & ";"


            Dim Sql As String = "select logo from logo_empresa;"
            Dim lector As MySqlDataReader
            conexionMysql = New MySqlConnection(strconexion)
            conexionMysql.Open()
            If conexionMysql.State = ConnectionState.Open Then
                Dim Imag As Byte()
                Dim Comando As New MySqlCommand(Sql, conexionMysql)
                lector = Comando.ExecuteReader
                While lector.Read
                    Imag = lector("logo")
                    Me.pblogo.Image = Bytes_Imagen(Imag)
                End While
            End If
            conexionMysql.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Private Sub Button83_Click(sender As Object, e As EventArgs) Handles Button83.Click
        cerrarconexion()
        '--------------------------------
        'Try
        Dim res As Integer

        Try

            conexionMysql.Open()
            Dim sql As String = "insert into logo_empresa(idlogo_empresa,logo)values(1,?imagen)"
            'conexionMysql = New MySqlConnection(StrConexion)
            Dim Comando As New MySqlCommand(sql, conexionMysql)
            Dim Imag As Byte()
            Imag = Imagen_Bytes(Me.pblogo.Image)

            Comando.Parameters.AddWithValue("?imagen", Imag)

            'conexionMysql.Open()
            'If conexionMysql.State = ConnectionState.Open Then
            Comando.ExecuteNonQuery()
            'End If
            conexionMysql.Close()

            res = 0

        Catch ex As Exception
            res = 1
        End Try



        If res = 1 Then

            ' Try
            MsgBox("Ya existe una imagen en el sistema, será remplazada", MsgBoxStyle.Information, "CTRL+y")
            cerrarconexion()
            conexionMysql.Open()

            Dim sql2 As String
            sql2 = "delete from  logo_empresa"
            Dim cmd2 As New MySqlCommand(sql2, conexionMysql)
            cmd2.ExecuteNonQuery()

            conexionMysql.Close()

            conexionMysql.Open()
            Dim sql As String = "insert into logo_empresa(idlogo_empresa,logo)values(1,?imagen)"
            'conexionMysql = New MySqlConnection(StrConexion)
            Dim Comando As New MySqlCommand(sql, conexionMysql)

            Dim Imag As Byte()
            Imag = Imagen_Bytes(Me.pblogo.Image)

            Comando.Parameters.AddWithValue("?imagen", Imag)

            'conexionMysql.Open()
            'If conexionMysql.State = ConnectionState.Open Then
            Comando.ExecuteNonQuery()
            'End If
            conexionMysql.Close()



            Dim nuevaruta As String
            nuevaruta = Replace(txtrutaimagen.Text, "\", "\\")
            'MsgBox("nuevaruta" & nuevaruta)

            cerrarconexion()
            conexionMysql.Open()
            'Try

            Dim Sql36 As String
            Sql36 = "UPDATE `dwin`.`datos_empresa` SET `ruta_logo` = '" & nuevaruta & "' WHERE (`iddatos_empresa` = '1');"
            Dim cmd36 As New MySqlCommand(Sql36, conexionMysql)
            cmd36.ExecuteNonQuery()
            conexionMysql.Close()

            'MsgBox(txtrutaimagen.Text)
            '-------------------------------------------------------------------------------------------------------

            '--------ALMACENAMOS LA RUTA EN EL ARCHIVO DE TEXTO

            Try

                'zxczxc
                Dim rutaimagen As String

                'IP = InputBox("Ingresa la ip del servidor de la BD")
                rutaimagen = nuevaruta


                Dim lines() As String = {rutaimagen}
                ' Dim lines2() As String = {port}

                ' Set a variable to the My Documents path.
                Dim mydocpath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

                ' Write the string array to a new file named "WriteLines.txt".
                Using outputFile As New StreamWriter(mydocpath & Convert.ToString("\rutaImagenNoBorrar.txt"))
                    For Each line As String In lines
                        outputFile.WriteLine(line)
                    Next
                End Using
            Catch ex As Exception
                MsgBox("Error al generar el archivo .txt", MsgBoxStyle.Information, "CTRL+y")
            End Try


            '-----------------------------------------------




            ' MsgBox("Logotipo Guardado", MsgBoxStyle.Information, "CTRL+y")




            '----------------------------------------------------------------------------------------------------------
            MsgBox("Logotipo Guardado", MsgBoxStyle.Information, "CTRL+y")
            cargarlogoticket()


        End If

        ' Catch ex As Exception
        'MessageBox.Show(ex.Message)
        ' MsgBox("Ya existe un logotipo en el sistema", MsgBoxStyle.Information, "CTRL+y")
        'End Try
        '-------------------------
        'Catch ex As Exception
        'MsgBox("error")
        'End Try





        'Dim file As New OpenFileDialog()
        'Dim imag As Byte

        'file.Filter = "Archivo JPG|*.jpg"
        'If file.ShowDialog() = DialogResult.OK Then
        '    pblogo.Image = Image.FromFile(file.FileName)

        '    Imag = Imagen_Bytes(Me.pblogo.Image)

        '    ' lbnombreimagen.Text = Path.GetFileName(pblogo.Tag.ToString())
        'End If
    End Sub

    Private Sub Button84_Click(sender As Object, e As EventArgs) Handles Button84.Click

        '  Private Sub abrir_inventario_existente()
        Dim filename As String
        Dim openfiler As New OpenFileDialog
        'Definiendo propiedades al openfiledialog
        With openfiler
            'directorio inicial
            .InitialDirectory = "C:\"
            'archivos que se pueden abrir
            .Filter = "Archivos de imágen(*.png)|*.png|All Files (*.*)|*.*"
            'indice del archivo de lectura por defecto
            .FilterIndex = 1
            'restaurar el directorio al cerrar el dialogo
            .RestoreDirectory = True
        End With
        '
        If openfiler.ShowDialog = Windows.Forms.DialogResult.OK Then  'Evalua si el usuario hace click en el boton abrir
            'Obteniendo la ruta completa del archivo xml
            filename = openfiler.FileName
            Me.pblogo.Image = Image.FromFile(filename)
            pblogo.SizeMode = PictureBoxSizeMode.Zoom
            pblogo.Visible = True

            txtrutaimagen.Text = pblogo.ImageLocation
            'filename = File.FileName
            'txtrutaimagen.Text = File.FileName
            '------------------------------
            filename = openfiler.FileName
            txtrutaimagen.Text = openfiler.FileName
            '-------------------------------

            If pblogo.Image Is Nothing Then
                ' el PB no tiene una imagen cargada
                pblogo.Visible = False
            Else
                ' SI tiene una imagen cargada
                pblogo.Visible = True

            End If



        End If
        'End Sub


        'Dim nuevaruta As String
        'nuevaruta = Replace(txtrutaimagen.Text, "\", "\\")


        'conexionMysql.Open()

        'Dim Sql36 As String
        'Sql36 = "UPDATE `dwin`.`datos_empresa` SET `ruta_logo` = '" & nuevaruta & "' WHERE (`iddatos_empresa` = '1');"
        'Dim cmd36 As New MySqlCommand(Sql36, conexionMysql)
        'cmd36.ExecuteNonQuery()
        'conexionMysql.Close()

        'MsgBox(txtrutaimagen.Text)



    End Sub

    Private Sub abrir_inventario_existente()
        Dim filename As String
        Dim openfiler As New OpenFileDialog
        'Definiendo propiedades al openfiledialog
        With openfiler
            'directorio inicial
            .InitialDirectory = "C:\"
            'archivos que se pueden abrir
            .Filter = "Archivos de imágen(*.jpg)|*.jpg|All Files (*.*)|*.*"
            'indice del archivo de lectura por defecto
            .FilterIndex = 1
            'restaurar el directorio al cerrar el dialogo
            .RestoreDirectory = True
        End With
        '
        If openfiler.ShowDialog = Windows.Forms.DialogResult.OK Then  'Evalua si el usuario hace click en el boton abrir
            'Obteniendo la ruta completa del archivo xml
            filename = openfiler.FileName
            Me.pblogo.Image = Image.FromFile(filename)
        End If
    End Sub
    Private Function Bytes_Imagen(ByVal Imagen As Byte()) As Image
        Try
            'si hay imagen
            If Not Imagen Is Nothing Then
                'caturar array con memorystream hacia Bin
                Dim Bin As New MemoryStream(Imagen)
                'con el método FroStream de Image obtenemos imagen
                Dim Resultado As Image = Image.FromStream(Bin)
                'y la retornamos
                Return Resultado
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    'convertir imagen a binario
    Private Function Imagen_Bytes(ByVal Imagen As Image) As Byte()
        'si hay imagen
        If Not Imagen Is Nothing Then
            'variable de datos binarios en stream(flujo)
            Dim Bin As New MemoryStream
            'convertir a bytes
            Imagen.Save(Bin, Imaging.ImageFormat.Jpeg)
            'retorna binario
            Return Bin.GetBuffer
        Else
            Return Nothing
        End If
    End Function

    Private Sub Pblogo_Click(sender As Object, e As EventArgs) Handles pblogo.Click

    End Sub

    Private Sub Button87_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button79_Click_2(sender As Object, e As EventArgs) Handles Button79.Click
        Dim valor As Boolean

        'valor = comprobacionproductoserigrafia()

        Try

            'If valor = True Then
            If stxtpagarsin.Text <> 0 Then

                Dim formulario As New frmgastosgralesserigrafia
                'FRagregaranticipo.ShowDialog()
                formulario.ShowDialog()
            Else
                MsgBox("No hay productos para aplicar una cotización", MsgBoxStyle.Information, "CTRL+y")

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button85_Click(sender As Object, e As EventArgs) Handles Button85.Click
        'Dim valor As Boolean

        ''valor = comprobacionproductoserigrafia()

        'Try

        '    'If valor = True Then
        '    If stxtpagarsin.Text <> 0 Then

        Dim formulario As New frmcotizadorvinil
        'FRagregaranticipo.ShowDialog()
        formulario.ShowDialog()
        '    Else
        '        MsgBox("No hay productos para aplicar una cotización", MsgBoxStyle.Information, "CTRL+y")

        '    End If
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub Grillahistorialesproductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grillahistorialesproductos.CellContentClick

    End Sub

    Private Sub listacolores_DoubleClick(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button87_Click_1(sender As Object, e As EventArgs) Handles Button87.Click
        cerrarconexion()

        Try

            conexionMysql.Open()

            Dim sql2 As String
            sql2 = "delete from  logo_empresa"
            Dim cmd2 As New MySqlCommand(sql2, conexionMysql)
            cmd2.ExecuteNonQuery()

            conexionMysql.Close()

            ' Liberamos los recursos utilizados por el objeto Image
            'Try



            'pblogo.Image.Dispose()
            'pblogo.Visible = False

            'Catch ex As Exception

            'End Try

            ' Establecemos a Nothing el valor de la propiedad Image
            ' del control PictureBox.

            cargarlogook()
            MsgBox("Imagen Eliminada", MsgBoxStyle.Information, "Sistema")
            'comprobarexistenciadelogo()

        Catch ex As Exception

        End Try



    End Sub

    Private Sub Chaplicarcotizador_CheckedChanged(sender As Object, e As EventArgs) Handles chaplicarcotizador.CheckedChanged
        If chaplicarcotizador.Checked = True Then
            cerrarconexion()
            aplicarcotizacion()

        ElseIf chaplicarcotizador.Checked = False Then
            cerrarconexion()
            desaplicarcotizacion()



        End If

    End Sub

    Private Sub Slbfolio_Click(sender As Object, e As EventArgs) Handles slbfolio.Click

    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick

    End Sub

    Private Sub Button88_Click(sender As Object, e As EventArgs) Handles Button88.Click

        Dim respuesta As String

        respuesta = MsgBox("¿Estas seguro de ELIMINAR completamente el archivo de la BD?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "CTRL+y")
        If respuesta = vbYes Then
            '--------------------------------- en caso de que la respuesta sea correcta
            '--------------------------------- se procede a eliminar todo

            conexionMysql.Open()

            Dim sql2 As String
            sql2 = "drop database dwin"
            Dim cmd2 As New MySqlCommand(sql2, conexionMysql)
            cmd2.ExecuteNonQuery()

            conexionMysql.Close()

            MsgBox("Base de datos eliminada" & Chr(13) &
            "El sistema se cerrara automaticamente para que vuelvas a cargar la BD", MsgBoxStyle.Information, "CTRL+y")
            End


        End If

    End Sub

    Private Sub Button57_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button42_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Rtobservaciones_TextChanged(sender As Object, e As EventArgs) Handles rtobservaciones.TextChanged

    End Sub

    Private Sub Lbclientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbclientes.SelectedIndexChanged
        lbclientes.Visible = False
        seleccioncliente2()
    End Sub


    Function seleccioncliente2()


        'buscamos los datos del cliente y los mandamos directo a donde corresponde.
        'Try
        cerrarconexion()
        conexionMysql.Open()


        Dim Sql111 As String
        Sql111 = "select * from cliente where concat(nombre,' ',ap,' ',am) like '%" & lbclientes.Text & "%';"
        Dim cmd111 As New MySqlCommand(Sql111, conexionMysql)
        reader = cmd111.ExecuteReader()
        reader.Read()

        ctxtid.Text = reader.GetString(0).ToString
        conexionMysql.Close()



        cerrarconexion()
        conexionMysql.Open()

        Dim Sql As String
        Sql = "select * from cliente where idcliente='" & ctxtid.Text & "';"
        Dim cmd As New MySqlCommand(Sql, conexionMysql)
        reader = cmd.ExecuteReader()
        reader.Read()

        '        ctxtid.Text = reader.GetString(0).ToString

        ctxtnombre.Text = reader.GetString(1).ToString
        ctxtap.Text = reader.GetString(2).ToString
        ctxtam.Text = reader.GetString(3).ToString
        ctxtedad.Text = reader.GetString(4).ToString
        ctxtdireccion.Text = reader.GetString(5).ToString
        ctxttelefono.Text = reader.GetString(6).ToString
        ctxtcorreo.Text = reader.GetString(7).ToString
        conexionMysql.Close()


        'Catch ex As Exception
        '    cerrarconexion()
        '    MsgBox(lbclientes.Text)
        '    MsgBox("Controlador de errores:" & ex.Message, MsgBoxStyle.Exclamation, "CTRL+y")
        'End Try




        lbclientes.Visible = False
    End Function
    Function cargarhistorialventascliente()

        grillaclienteservicios.DefaultCellStyle.Font = New Font("Arial", 12)
        grillaclienteservicios.RowHeadersVisible = False
        'ampliar columna 
        'grillap.Columns(2).Width = 120


        grillaclienteservicios.AlternatingRowsDefaultCellStyle.BackColor = Color.SkyBlue







        'Try



        If ctxtidcliente.Text = "" Then
            MsgBox("Primero selecciona un cliente de la lista", MsgBoxStyle.Information, "CTRL+y")
            'hacemos que se muestren y ocultan algunas grillas y controles
            grillaclienteservicios.Visible = False
            grillacliente.Visible = True
            grupocontrolesclientes.Visible = False

        Else
            'hacemos que se muestren y ocultan algunas grillas y controles
            grillaclienteservicios.Visible = True
            grillacliente.Visible = False
            grupocontrolesclientes.Visible = True

            conexionMysql.Open()


            Dim Sql As String
            Sql = "select venta.idventa, venta.cantidad, venta.total,venta.fecha,venta.fechaentrega,venta.anticipo,venta.resto, venta.pagacon, venta.cambio, tipoventa.tipoventa from venta,tipoventa where venta.idcliente='" & ctxtidcliente.Text & "' and tipoventa.idtipoventa=venta.tipoventa order by  venta.idventa desc;"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            Dim dt As New DataTable
            Dim da As New MySqlDataAdapter(cmd)
            'cargamos el formulario  resumen
            da.Fill(dt)
            grillaclienteservicios.DataSource = dt
            conexionMysql.Close()
            'Dim tamaño As Integer
            'tamaño = 50
            ''le asignamos nuevos tamaños a ciertas columnas
            'grillaclienteservicios.Columns(0).Width = tamaño
            'grillaclienteservicios.Columns(1).Width = tamaño
            'grillaclienteservicios.Columns(2).Width = tamaño
            'grillaclienteservicios.Columns(5).Width = tamaño
            'grillaclienteservicios.Columns(6).Width = tamaño
            'grillaclienteservicios.Columns(7).Width = tamaño
            grillaclienteservicios.Columns(9).Width = 120
        End If

        'Catch ex As Exception
        cerrarconexion()
        btninconsistencia.Visible = True
        'MsgBox("CONTROLADOR DE ERRORES:" & ex.Message, MsgBoxStyle.Exclamation, "CTRL+y")
        'End Try

    End Function
    Private Sub Btnverhistorialventas_Click(sender As Object, e As EventArgs) Handles btnverhistorialventas.Click
        txtclientefolioservicio.Text = ""
        txtclientetotalpagar.Text = ""
        txtclienteadeudo.Text = ""
        txtclientetiposervicio.Text = ""

        cargarhistorialventascliente()
    End Sub

    Private Sub Button42_Click_2(sender As Object, e As EventArgs) Handles Button42.Click
        limpiarcliente()

        grillaclienteservicios.Visible = False
        grillacliente.Visible = True
        grupocontrolesclientes.Visible = False


    End Sub

    Private Sub Grillaclienteservicios_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grillaclienteservicios.CellContentClick
        'Try

        '    txtclientefolioservicio.Text = grillaclienteservicios.Item(0, grillaclienteservicios.CurrentRow.Index).Value
        '    txtclienteadeudo.Text = grillaclienteservicios.Item(6, grillaclienteservicios.CurrentRow.Index).Value
        '    txtclientetiposervicio.Text = grillaclienteservicios.Item(9, grillaclienteservicios.CurrentRow.Index).Value
        '    txtclientetotalpagar.Text = grillaclienteservicios.Item(2, grillaclienteservicios.CurrentRow.Index).Value
        'Catch ex As Exception
        '    'MsgBox()
        '    cerrarconexion()
        'End Try


    End Sub

    Private Sub Button19_Click_1(sender As Object, e As EventArgs) Handles Button19.Click

        If txtclienteadeudo.Text = "" Or txtclientetiposervicio.Text = "VENTA GENERAL" Then
            MsgBox("Los servicios generales no se pueden pagar completamente", MsgBoxStyle.Information, "CTRL+y")

        Else
            Dim formulario As New frmclienteadeudopagar
            'FRagregaranticipo.ShowDialog()
            formulario.ShowDialog()
        End If

    End Sub

    Function comprobarexistenciadelogo()
        cerrarconexion()
        Dim id As String
        Try

            conexionMysql.Open()


            Dim Sql111 As String
            Sql111 = "select idlogo_empresa from logo_empresa;"
            Dim cmd111 As New MySqlCommand(Sql111, conexionMysql)
            reader = cmd111.ExecuteReader()
            reader.Read()

            id = reader.GetString(0).ToString
        Catch ex As Exception
            cerrarconexion()
            id = 0
        End Try



        'MsgBox(id)

        If id = 1 Then

            pblogo.Visible = True
            ' MsgBox("visible")
        Else
            pblogo.Visible = False
            '       MsgBox("Nooooooooo visible")

        End If


        conexionMysql.Close()

    End Function

    Private Sub grillacolores_DoubleClick(sender As Object, e As EventArgs)

    End Sub

    Private Sub Cbtncompras_TextChanged(sender As Object, e As EventArgs) Handles cbtncompras.TextChanged

    End Sub
    Function resumenventas()
        Dim fechacompleta As String

        fechacompleta = calendario.SelectionRange.Start.ToString("yyyy/MM/dd")
        cerrarconexion()
        'MsgBox(fechacompleta)
        conexionMysql.Open()
        Dim Sql As String
        Sql = "select venta.idventa, ventaind.idventaind, ventaind.actividad, ventaind.cantidad, ventaind.costo,(ventaind.cantidad * ventaind.costo) as Total, ventaind.idproducto, venta.hora,venta.fecha from ventaind, venta where ventaind.idventa = venta.idventa and fecha='" & fechacompleta & "';"
        Dim cmd As New MySqlCommand(Sql, conexionMysql)
        Dim dt As New DataTable
        Dim da As New MySqlDataAdapter(cmd)
        'cargamos el formulario  resumen
        da.Fill(dt)
        cgrillaentrada.DataSource = dt
        'al dar clic al boton que se cargue todo lo vendido de papeleria y de servicios en la fecha seleccionada.
        conexionMysql.Close()

    End Function
    Function resumencompras()
        Dim fechacompleta As String

        fechacompleta = calendario.SelectionRange.Start.ToString("yyyy/MM/dd")
        cerrarconexion()
        'MsgBox(fechacompleta)
        conexionMysql.Open()
        Dim Sql As String
        Sql = "select compra.idcompra, compra.actividad, compra.cantidad,compra.costo,compra.total,compra.fecha,compra.hora, usuario.usuario from compra,usuario where compra.idusuario= usuario.idusuario and compra.fecha='" & fechacompleta & "';"
        Dim cmd As New MySqlCommand(Sql, conexionMysql)
        Dim dt As New DataTable
        Dim da As New MySqlDataAdapter(cmd)
        'cargamos el formulario  resumen
        da.Fill(dt)
        cgrillasalida.DataSource = dt
        'al dar clic al boton que se cargue todo lo vendido de papeleria y de servicios en la fecha seleccionada.
        conexionMysql.Close()

    End Function

    Private Sub Button57_Click_2(sender As Object, e As EventArgs) Handles cbtnresumen.Click
        btnproductosfaltantes.Visible = False


        btncortes.Visible = False
        btnventasrapidas.Visible = True
        btncomprasdia.Visible = True
        btnanticiposventas.Visible = True


        'ocultamos la grilla de corte y mostrarmos las grillas de entradas y salidas.
        cgrillacorte.Visible = False
        cgrillaentrada.Visible = True
        cgrillasalida.Visible = True
        clbentrada.Visible = True
        clbsalidas.Visible = True
        pgrillaproductosfaltantes.Visible = False
        lbfiltrarfaltante.Visible = False
        corcbproveedores.Visible = False
        btnimprimirfiltro.Visible = False

        'consultamos la informacion de entradas y las mandamos a la grilla que corresponde
        resumenventas()
        resumencompras()








    End Sub

    Private Sub Button34_Click_1(sender As Object, e As EventArgs) Handles cbtverventas.Click


        btnproductosfaltantes.Visible = False

        btncortes.Visible = False
        btnventasrapidas.Visible = True
        btncomprasdia.Visible = True
        btnanticiposventas.Visible = True

        'cgrillaentrada.Visible = True
        'resumenventas()
        desgloseventas()
        cgrillacorte.Visible = True
        cgrillaentrada.Visible = False
        cgrillasalida.Visible = False
        clbsalidas.Visible = False
        clbentrada.Visible = False
        pgrillaproductosfaltantes.Visible = False
        lbfiltrarfaltante.Visible = False
        corcbproveedores.Visible = False
        btnimprimirfiltro.Visible = False

    End Sub

    Private Sub Button43_Click_1(sender As Object, e As EventArgs) Handles cbtvercortes.Click
        btnproductosfaltantes.Visible = False

        btncortes.Visible = True
        btnventasrapidas.Visible = False
        btncomprasdia.Visible = False
        btnanticiposventas.Visible = False


        'ocultamos la grilla de corte y mostrarmos las grillas de entradas y salidas.
        cgrillacorte.Visible = True
        cgrillaentrada.Visible = False
        cgrillasalida.Visible = False
        clbentrada.Visible = False
        clbsalidas.Visible = False
        pgrillaproductosfaltantes.Visible = False
        btnimprimirfiltro.Visible = False

        lbfiltrarfaltante.Visible = False
        corcbproveedores.Visible = False
        consultarcortecalendario()
    End Sub

    Private Sub Btnabrircaja_Click(sender As Object, e As EventArgs) Handles btnabrircaja.Click
        abrircaja()
    End Sub
    Function abrircaja()

        'primero comprobamos si existe caja abierta.
        '------------------------------------------------
        Dim cantidad As Integer

        Try
            'verificamos que exista al menos 1 registro, en caso de que exista 0, indicamos que el valor es 0;
            conexionMysql.Open()
            Dim sql22 As String
            sql22 = "select count(idcaja) from caja;"
            Dim cmd22 As New MySqlCommand(sql22, conexionMysql)
            reader = cmd22.ExecuteReader
            reader.Read()
            cantidad = reader.GetString(0).ToString()
            conexionMysql.Close()
        Catch ex As Exception
            cantidad = 0
        End Try

        'si la cantidad es cero, entonces, significa que si puede abrir una caja, porque no hay nada aun.
        If cantidad = 0 Then


        Else


            Try

                conexionMysql.Open()
                Dim sql2 As String
                sql2 = "select count(idcaja) from caja where estado=0;"
                Dim cmd2 As New MySqlCommand(sql2, conexionMysql)
                reader = cmd2.ExecuteReader
                reader.Read()
                cantidad = reader.GetString(0).ToString()
                conexionMysql.Close()
            Catch ex As Exception
                cantidad = 1
            End Try
        End If


        If cantidad = 0 Then


            Dim formulario As New FRabrircaja

            formulario.ShowDialog()
        Else
            Dim respuesta As String
            respuesta = MsgBox("Existen cajas abiertas sin cerrar, ¿deseas forzas cierre?, todo se pondrá en Ceros", MsgBoxStyle.YesNo, "CTRL+y")


            If respuesta = vbYes Then

                cerrarconexion()

                conexionMysql.Open()
                'actualizo el dato
                Dim Sql5 As String
                Sql5 = "UPDATE `dwin`.`caja` SET `estado` = '1';"
                Dim cmd5 As New MySqlCommand(Sql5, conexionMysql)
                cmd5.ExecuteNonQuery()
                conexionMysql.Close()
                MsgBox("Cajas cerradas", MsgBoxStyle.Information, "CTR+y")
                Dim formulario As New FRabrircaja
                formulario.ShowDialog()
                '---------------------------------
            End If




        End If

    End Function
    Private Sub Btncerrarcaja_Click(sender As Object, e As EventArgs) Handles btncerrarcaja.Click
        cerrarcaja()

    End Sub
    Function cerrarcaja()
        Dim registrar As Boolean
        Dim idestado, idmaximo, contador As Integer

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
            'PRIMERO VERIFICAMOS QUE EXISTA UN REGISTRO EN LA TABLA
            '------------------------------

            conexionMysql.Open()
            Dim sql22 As String
            sql22 = "select count(*) from caja;"
            Dim cmd22 As New MySqlCommand(sql22, conexionMysql)
            reader = cmd22.ExecuteReader
            reader.Read()
            contador = reader.GetString(0).ToString()
            conexionMysql.Close()
            '---------------------------

            If contador <= 0 Then
                idestado = 1
                MsgBox("Al parecer tu sistema es nuevo, inicia abriendo una caja!!!", MsgBoxStyle.Information, "CTRL+y")
            Else

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
                'MsgBox(idestado, MsgBoxStyle.Exclamation, "CTRL+y")

                'MsgBox("No existe caja abierta", MsgBoxStyle.Exclamation, "CTRL+y")
            End If

        Catch ex As Exception
            registrar = True
            ' idestado = 1
            ' MsgBox("error")
        End Try



        If idestado = 0 Then
            'en caso de que exista una caja abierta, entonces abrimos la ventana para cerrar la caja
            Dim formulario As New FRcerrarcaja
            formulario.ShowDialog()

        End If
    End Function


    Private Sub Button34_Click_2(sender As Object, e As EventArgs) Handles btncortes.Click
        Dim formulario As New FRMNOTAVENTASCORTE
        formulario.ShowDialog()
    End Sub

    Private Sub Button43_Click_2(sender As Object, e As EventArgs) Handles Button43.Click

        If rptidservicio.Text = "" Then
            MsgBox("Ingresa un ID valido", MsgBoxStyle.Exclamation, "Sistema")
        Else

            'Dim formulario As New FRNOTASERVICIOREIMPRESION

            'formulario.ShowDialog()


            'cargardatosnotaventa2()
            'imprimirnotaventa2()

            FRNNOTASERVICIOREIMPRESION.Show()

        End If
    End Sub

    Private Sub TabPage11_Click(sender As Object, e As EventArgs) Handles TabPage11.Click

    End Sub

    Private Sub Button44_Click_1(sender As Object, e As EventArgs) Handles Button44.Click

        Dim formulario As New FRventaporcliente
        'FRagregaranticipo.ShowDialog()
        formulario.ShowDialog()
    End Sub

    Private Sub Button45_Click_1(sender As Object, e As EventArgs) Handles Button45.Click






        Dim estadocaja As Integer


        estadocaja = comprobarcaja()

        If estadocaja = 0 Then

            Dim respuesta As String

            'comprobar cuantas filas tiene la grilla donde se almacenan los valores para agregar a la venta

            If stxtfoliobusquedaventa.Text = "" Then
                sobtenerfolio()

                sventa()



                setxtgastosgenerales.Text = ""
                setxtgananciaserigrafia.Text = ""
                setxtgananciaproducto.Text = ""
                setxtganancianeta.Text = ""
                setxtprecioestampado.Text = ""
                setxtprecioconproducto.Text = ""
                setxtfoliocotizador.Text = "0"
                stxtprecio.BackColor = Color.White
                stxttotalproducto.BackColor = Color.White
            Else
                respuesta = MsgBox("Estas consultado un folio, ¿quieres realizar una nueva venta?", MsgBoxStyle.YesNo, "CTRL+y")

                If respuesta = vbYes Then
                    nuevoservicio()
                    stxtfoliobusquedaventa.Text = ""
                    stxtclave.Focus()

                End If

            End If

            'COMPROBAMOS QUE LA CAJA DE TEXTO DE BUSQUEDA DE FOLIO ESTE VACIA PARA PODER REALIZAR UNA VENTA
        Else
            MsgBox("No existe ninguna caja abierta", MsgBoxStyle.Information, "CTRL+y")
        End If




        'sventa()

    End Sub

    Private Sub Btninconsistencia_Click(sender As Object, e As EventArgs) Handles btninconsistencia.Click

    End Sub

    Private Sub listacolores_KeyDown(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub Ch_CheckedChanged(sender As Object, e As EventArgs) Handles chagenda.CheckedChanged
        If chagenda.Checked = True Then
            agendacalendario.Visible = True
            agendagrilla.Visible = True
            agendagrilla.DefaultCellStyle.Font = New Font("Arial", 12)
            agendagrilla.RowHeadersVisible = False
            agendagrilla.AlternatingRowsDefaultCellStyle.BackColor = Color.Coral

            cargaragenda()
        Else

            agendacalendario.Visible = False
            agendagrilla.Visible = False
        End If
    End Sub
    Function cargaragenda()
        cerrarconexion()
        Dim fecha As String

        fecha = agendacalendario.SelectionRange.Start.ToString("yyyy/MM/dd")
        Try

            conexionMysql.Open()
            Dim Sql As String
            Sql = "select * from venta where fechaentrega='" & fecha & "';"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            Dim dt As New DataTable
            Dim da As New MySqlDataAdapter(cmd)
            'cargamos el formulario  resumen
            da.Fill(dt)
            agendagrilla.DataSource = dt
            'agendagrilla.Columns(1).Width = 700
            'agendagrilla.Columns(0).Width = 100
            'grilla2.Columns(2).Width = 70
            'grilla2.Columns(3).Width = 70
            'grilla2.Columns(4).Width = 70
            'grilla2.Columns(5).Width = 70
            'grilla2.Columns(6).Width = 70
            'grilla2.Columns(7).Width = 70

            conexionMysql.Close()
        Catch ex As Exception

        End Try

    End Function

    Private Sub Button57_Click_3(sender As Object, e As EventArgs) Handles Button57.Click

        '.----------------------------------------------------------
        '------------------------------------------------------------
        'APLICACIÓN DE PARCHE CREACION DE CAMPOS EN TABLA usuario PARA AGREGAR permitir acceder a las diferentes secciones
        '-------------------------------------------------------------
        '--------------------------------------------------------------
        Try
            conexionMysql.Open()
            Dim Sql As String
            Sql = "ALTER TABLE `dwin`.`usuario` 
ADD COLUMN `pclientes` INT NULL AFTER `tipo_usuario`,
ADD COLUMN `pcompras` INT NULL AFTER `pclientes`,
ADD COLUMN `pproductos` INT NULL AFTER `pcompras`,
ADD COLUMN `pcorte` INT NULL AFTER `pproductos`,
ADD COLUMN `pusuarios` INT NULL AFTER `pcorte`,
ADD COLUMN `pproveedores` INT NULL AFTER `pusuarios`,
ADD COLUMN `preportes` INT NULL AFTER `pproveedores`,
ADD COLUMN `pconfiguracion` INT NULL AFTER `preportes`;"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            cmd.ExecuteNonQuery()
            conexionMysql.Close()
        Catch
            'MsgBox
            cerrarconexion()

        End Try
        cerrarconexion()









        '.----------------------------------------------------------
        '------------------------------------------------------------
        'APLICACIÓN DE PARCHE CREACION DE CAMPOS EN TABLA CAJA PARA AGREGAR VALORES
        '-------------------------------------------------------------
        '--------------------------------------------------------------
        Try
            conexionMysql.Open()
            Dim Sql As String
            Sql = "ALTER TABLE `dwin`.`caja` 
ADD COLUMN `venta_rapida` DOUBLE NULL AFTER `observaciones`,
ADD COLUMN `anticipos` DOUBLE NULL AFTER `venta_rapida`,
ADD COLUMN `compras` DOUBLE NULL AFTER `anticipos`,
ADD COLUMN `total_ventas_compras` DOUBLE NULL AFTER `compras`,
ADD COLUMN `total_deberia_existir` DOUBLE NULL AFTER `total_ventas_compras`,
ADD COLUMN `diferencia` DOUBLE NULL AFTER `total_deberia_existir`;"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            cmd.ExecuteNonQuery()
            conexionMysql.Close()
        Catch
            'MsgBox
            cerrarconexion()

        End Try
        cerrarconexion()



        Try
            conexionMysql.Open()
            Dim SqlP2 As String
            SqlP2 = "ALTER TABLE `dwin`.`datos_empresa` 
CHANGE COLUMN `nombre` `nombre` VARCHAR(100) NULL DEFAULT NULL ,
CHANGE COLUMN `calle_numero` `calle_numero` VARCHAR(100) NULL DEFAULT NULL ,
CHANGE COLUMN `colonia_ciudad` `colonia_ciudad` VARCHAR(100) NULL DEFAULT NULL ,
CHANGE COLUMN `cp` `cp` VARCHAR(100) NULL DEFAULT NULL ,
CHANGE COLUMN `estado` `estado` VARCHAR(100) NULL DEFAULT NULL ,
CHANGE COLUMN `telefono` `telefono` VARCHAR(100) NULL DEFAULT NULL ,
CHANGE COLUMN `whatsapp` `whatsapp` VARCHAR(100) NULL DEFAULT NULL ,
CHANGE COLUMN `correo` `correo` VARCHAR(100) NULL DEFAULT NULL ,
CHANGE COLUMN `fanpage` `fanpage` VARCHAR(100) NULL DEFAULT NULL ,
CHANGE COLUMN `sitio_web` `sitio_web` VARCHAR(100) NULL DEFAULT NULL ,
CHANGE COLUMN `director` `director` VARCHAR(100) NULL DEFAULT NULL ,
CHANGE COLUMN `horario` `horario` VARCHAR(100) NULL DEFAULT NULL ,
CHANGE COLUMN `giro` `giro` VARCHAR(300) NULL DEFAULT NULL ;
"
            Dim cmdP2 As New MySqlCommand(SqlP2, conexionMysql)
            cmdP2.ExecuteNonQuery()
            conexionMysql.Close()



        Catch ex As Exception
            cerrarconexion()
        End Try


        Try

            'modificación 08-08-2020
            'se agrega el tipo de servicio de vinil, motivo: activar busqueda por cliente para poder hacer un
            'filtro de que se realice pura busqueda de vinil
            conexionMysql.Open()

            Dim Sql36 As String
            Sql36 = "INSERT INTO `dwin`.`tipoventa` (`idtipoventa`,`tipoventa`) VALUES ('3','Vinil');"
            Dim cmd36 As New MySqlCommand(Sql36, conexionMysql)
            cmd36.ExecuteNonQuery()
            conexionMysql.Close()

        Catch ex As Exception
            cerrarconexion()
        End Try



        Try

            'modificación 08-08-2020
            'se agrega el tipo de servicio de vinil, motivo: activar busqueda por cliente para poder hacer un
            'filtro de que se realice pura busqueda de vinil

            conexionMysql.Open()

            Dim Sql37 As String
            Sql37 = " ALTER TABLE `dwin`.`datos_empresa` 
ADD COLUMN `minimoproductos` INT(10) NULL AFTER `saludo_nota`;"
            Dim cmd37 As New MySqlCommand(Sql37, conexionMysql)
            cmd37.ExecuteNonQuery()
            conexionMysql.Close()

        Catch ex As Exception
            cerrarconexion()
        End Try

        Try

            'modificación 08-08-2020
            'se agrega el tipo de servicio de vinil, motivo: activar busqueda por cliente para poder hacer un
            'filtro de que se realice pura busqueda de vinil

            conexionMysql.Open()

            Dim Sql38 As String
            Sql38 = " ALTER TABLE `dwin`.`compramercancia` 
DROP COLUMN `cantidad_paquete`,
DROP COLUMN `costo_paquete`,
ADD COLUMN `totalcompra` DOUBLE NULL AFTER `hora`;
"
            Dim cmd38 As New MySqlCommand(Sql38, conexionMysql)
            cmd38.ExecuteNonQuery()
            conexionMysql.Close()

        Catch ex As Exception
            cerrarconexion()
        End Try


        Try

            'modificación 08-08-2020
            'se agrega el tipo de servicio de vinil, motivo: activar busqueda por cliente para poder hacer un
            'filtro de que se realice pura busqueda de vinil

            conexionMysql.Open()

            Dim Sql39 As String
            Sql39 = "
        ALTER TABLE `dwin`.`cliente` 
CHANGE COLUMN `edad` `rfc` VARCHAR(20) NULL DEFAULT NULL ;"
            Dim cmd39 As New MySqlCommand(Sql39, conexionMysql)
            cmd39.ExecuteNonQuery()
            conexionMysql.Close()

        Catch ex As Exception
            cerrarconexion()
        End Try


        '---------------------------------
        '---------------------------------
        '--creacion de una nueva tabla de pago
        '---------------------------------
        '---------------------------------

        Try
            conexionMysql.Open()

            Dim Sql40 As String
            Sql40 = "CREATE TABLE `dwin`.`tipo_pago` (
  `idtipo_pago` INT NOT NULL,
  `tipo` VARCHAR(45) NULL,
  PRIMARY KEY (`idtipo_pago`));
"
            Dim cmd40 As New MySqlCommand(Sql40, conexionMysql)
            cmd40.ExecuteNonQuery()
            conexionMysql.Close()

        Catch ex As Exception
            cerrarconexion()
        End Try

        '---------------------------------
        '---------------------------------
        '---------------------------------
        '---------------------------------
        '-insercion de registros para parche

        Try
            conexionMysql.Open()

            Dim Sql40 As String
            Sql40 = "INSERT INTO `dwin`.`tipo_pago` (`idtipo_pago`, `tipo`) VALUES ('1', 'EFECTIVO');
INSERT INTO `dwin`.`tipo_pago` (`idtipo_pago`, `tipo`) VALUES ('2', 'TRANSFERENCIAS');
INSERT INTO `dwin`.`tipo_pago` (`idtipo_pago`, `tipo`) VALUES ('3', 'TARJETA DEBITO/CREDITO');
INSERT INTO `dwin`.`tipo_pago` (`idtipo_pago`, `tipo`) VALUES ('4', 'VALES');

"
            Dim cmd40 As New MySqlCommand(Sql40, conexionMysql)
            cmd40.ExecuteNonQuery()
            conexionMysql.Close()

        Catch ex As Exception
            cerrarconexion()
        End Try
        '---------------------------------
        '---------------------------------


        '---------------------------------
        '---------------------------------
        '-insercion de registros para parche

        Try
            conexionMysql.Open()

            Dim Sql41 As String
            Sql41 = "ALTER TABLE `dwin`.`venta` 
ADD COLUMN `idtipo_pago` INT(11) NULL AFTER `idsecotizacion`,
ADD INDEX `idtipo_pago_idx` (`idtipo_pago` ASC);
;
ALTER TABLE `dwin`.`venta` 
ADD CONSTRAINT `idtipo_pago`
  FOREIGN KEY (`idtipo_pago`)
  REFERENCES `dwin`.`tipo_pago` (`idtipo_pago`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;
"
            Dim cmd41 As New MySqlCommand(Sql41, conexionMysql)
            cmd41.ExecuteNonQuery()
            conexionMysql.Close()

        Catch ex As Exception
            cerrarconexion()
        End Try
        '---------------------------------
        '---------------------------------





        '---------------------------------
        '---------------------------------
        '-insercion de registros para parche

        Try
            conexionMysql.Open()

            Dim Sql41 As String
            Sql41 = "ALTER TABLE `dwin`.`cliente` 
CHANGE COLUMN `direccion` `direccion` VARCHAR(100) NULL DEFAULT NULL ,
CHANGE COLUMN `correo` `correo` VARCHAR(100) NULL DEFAULT NULL ;"
            Dim cmd41 As New MySqlCommand(Sql41, conexionMysql)
            cmd41.ExecuteNonQuery()
            conexionMysql.Close()

        Catch ex As Exception
            cerrarconexion()
        End Try
        '---------------------------------
        '---------------------------------

        '---------------------------------
        '---------------------------------
        '-insercion de registros para parche

        Try
            conexionMysql.Open()
            Dim Sql41 As String
            Sql41 = "ALTER TABLE `dwin`.`datos_empresa` 
ADD COLUMN `rfc` VARCHAR(45) NULL AFTER `minimoproductos`;"
            Dim cmd41 As New MySqlCommand(Sql41, conexionMysql)
            cmd41.ExecuteNonQuery()
            conexionMysql.Close()
        Catch ex As Exception
            cerrarconexion()
        End Try
        '---------------------------------
        '---------------------------------
        '---------------------------------
        '---------------------------------
        '-insercion de registros para parche

        Try
            conexionMysql.Open()
            Dim Sql42 As String
            Sql42 = "ALTER TABLE `dwin`.`datos_empresa` 
ADD COLUMN `ruta_logo` VARCHAR(200) NULL AFTER `rfc`;"
            Dim cmd42 As New MySqlCommand(Sql42, conexionMysql)
            cmd42.ExecuteNonQuery()
            conexionMysql.Close()
        Catch ex As Exception
            cerrarconexion()
        End Try
        '---------------------------------
        '---------------------------------

        '---------------------------------
        '---------------------------------
        '-insercion de registros para parche

        Try
            conexionMysql.Open()
            Dim Sql43 As String
            Sql43 = "ALTER TABLE `dwin`.`datos_empresa` 
ADD COLUMN `saludo_ticket` VARCHAR(45) NULL AFTER `ruta_logo`;
"
            Dim cmd43 As New MySqlCommand(Sql43, conexionMysql)
            cmd43.ExecuteNonQuery()
            conexionMysql.Close()
        Catch ex As Exception
            cerrarconexion()
        End Try
        '---------------------------------
        '---------------------------------

        'Try
        '    conexionMysql.Open()
        '    Dim Sql43 As String
        '    Sql43 = "update producto set idproveedor=16;"

        '    Dim cmd43 As New MySqlCommand(Sql43, conexionMysql)
        '    cmd43.ExecuteNonQuery()
        '    conexionMysql.Close()
        'Catch ex As Exception
        '    cerrarconexion()
        'End Try
        ''---------------------------------
        ''---------------------------------






        MsgBox("Parche aplicado con exito", MsgBoxStyle.Information, "CTRL+y")

        'Catch ex As Exception
        'MsgBox("El parche ya fue aplicado", MsgBoxStyle.Information, "CTRL+y")
        'End Try


    End Sub

    Private Sub Btncomprasdia_Click(sender As Object, e As EventArgs) Handles btncomprasdia.Click
        Dim formulario As New FRNOTACOMPRAS
        formulario.ShowDialog()
    End Sub

    Private Sub Btnventasrapidas_Click(sender As Object, e As EventArgs) Handles btnventasrapidas.Click
        Dim formulario As New FRNOTAVENTASRAPIDAS
        formulario.ShowDialog()
    End Sub

    Private Sub Btnanticiposventas_Click(sender As Object, e As EventArgs) Handles btnanticiposventas.Click
        Dim formulario As New FRNOTAANTICIPOSVENTAS
        formulario.ShowDialog()
    End Sub

    Private Sub Agendacalendario_DateChanged(sender As Object, e As DateRangeEventArgs) Handles agendacalendario.DateChanged
        cargaragenda()
    End Sub

    Private Sub Button78_Click_1(sender As Object, e As EventArgs) Handles Button78.Click
        nuevoservicio()
    End Sub

    Private Sub Btnconactualizararticulosminimos_Click(sender As Object, e As EventArgs) Handles btnconactualizararticulosminimos.Click

        Try

            conexionMysql.Open()
            'actualizo el dato
            Dim Sql5 As String
            Sql5 = "UPDATE `dwin`.`datos_empresa` SET `minimoproductos` = '" & ctxtminimoarticulos.Text & "' WHERE (`iddatos_empresa` = '1');"
            Dim cmd5 As New MySqlCommand(Sql5, conexionMysql)
            cmd5.ExecuteNonQuery()
            MsgBox("Registro actualizado", MsgBoxStyle.Information, "CTRL+y")
            conexionMysql.Close()
        Catch ex As Exception
            cerrarconexion()
        End Try

    End Sub

    Private Sub Btnverfaltantesproductos_Click(sender As Object, e As EventArgs) Handles btnverfaltantesproductos.Click

        'ocultamos la grilla de corte ,las grillas de entradas y salidas y mostramos la grilla de productos faltantes.
        cgrillacorte.Visible = False
        cgrillaentrada.Visible = False
        cgrillasalida.Visible = False
        clbentrada.Visible = False
        clbsalidas.Visible = False
        pgrillaproductosfaltantes.Visible = True
        btnproductosfaltantes.Visible = True
        lbfiltrarfaltante.Visible = True
        corcbproveedores.Visible = True
        btnimprimirfiltro.Visible = False

        'consultamos los productos menores a la cantidad indicada

        consultaproductosfaltantes()

        btncortes.Visible = False
        btnventasrapidas.Visible = False
        btncomprasdia.Visible = False
        btnanticiposventas.Visible = False
        'CARGAMOS LOS PROVEEDORES PARA HACER UN FILTRO POR PROVEEDOR
        cargarproveedorproductosfaltantes()

    End Sub
    Function cargarproveedorproductosfaltantes()

        'limpiar el combo para que no se duplique
        corcbproveedores.Items.Clear()

        Try


            Dim cantidadproveedor, i As Integer
            cerrarconexion()

            conexionMysql.Open()
            Dim Sql As String
            Sql = "select count(*)as contador from proveedor;"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            reader = cmd.ExecuteReader()
            reader.Read()
            cantidadproveedor = reader.GetString(0).ToString()

            conexionMysql.Close()


            cerrarconexion()

            conexionMysql.Open()
            Dim Sql2 As String
            Sql2 = "select * from proveedor;"
            Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            reader = cmd2.ExecuteReader()

            For i = 1 To cantidadproveedor

                reader.Read()

                corcbproveedores.Items.Add(reader.GetString(1).ToString())
            Next

            reader.Close()

            conexionMysql.Close()


        Catch ex As Exception

        End Try


    End Function
    Function consultaproductosfaltantescombobox()



        Dim cantidadminima, idproveedor As Integer
        'primero consultamos cual es el minimo de productos por mostrar
        conexionMysql.Open()
        Dim sql26 As String
        sql26 = "Select idproveedor from proveedor where nombre_empresa ='" & corcbproveedores.Text & "';"
        Dim cmd26 As New MySqlCommand(sql26, conexionMysql)
        reader = cmd26.ExecuteReader
        reader.Read()
        idproveedor = reader.GetString(0).ToString()
        conexionMysql.Close()

        'Dim cantidadminima As Integer
        'primero consultamos cual es el minimo de productos por mostrar
        conexionMysql.Open()
        Dim sql25 As String
        sql25 = "select minimoproductos from datos_empresa;"
        Dim cmd25 As New MySqlCommand(sql25, conexionMysql)
        reader = cmd25.ExecuteReader
        reader.Read()
        cantidadminima = reader.GetString(0).ToString()
        conexionMysql.Close()
        conexionMysql.Open()
        Dim Sql As String
        Sql = "select idproducto, descripcion, cantidad from producto where cantidad <=" & cantidadminima & " and idproveedor=" & idproveedor & ";"
        Dim cmd As New MySqlCommand(Sql, conexionMysql)
        Dim dt As New DataTable
        Dim da As New MySqlDataAdapter(cmd)
        'cargamos el formulario  resumen
        da.Fill(dt)
        pgrillaproductosfaltantes.DataSource = dt
        pgrillaproductosfaltantes.Columns(1).Width = 700
        conexionMysql.Close()

        'mostramos el boton para imprimir sobre el filtro realizado

        btnimprimirfiltro.Visible = True


        idproveedorfiltro = idproveedor


    End Function
    Function consultaproductosfaltantes()

        Dim cantidadminima As Integer
        'primero consultamos cual es el minimo de productos por mostrar
        conexionMysql.Open()
        Dim sql25 As String
        sql25 = "select minimoproductos from datos_empresa;"
        Dim cmd25 As New MySqlCommand(sql25, conexionMysql)
        reader = cmd25.ExecuteReader
        reader.Read()
        cantidadminima = reader.GetString(0).ToString()
        conexionMysql.Close()


        conexionMysql.Open()
        Dim Sql As String
        Sql = "select idproducto, descripcion, cantidad from producto where cantidad <=" & cantidadminima & ";"
        Dim cmd As New MySqlCommand(Sql, conexionMysql)
        Dim dt As New DataTable
        Dim da As New MySqlDataAdapter(cmd)
        'cargamos el formulario  resumen
        da.Fill(dt)
        pgrillaproductosfaltantes.DataSource = dt
        pgrillaproductosfaltantes.Columns(1).Width = 700
        conexionMysql.Close()
    End Function

    Private Sub Btnproductosfaltantes_Click(sender As Object, e As EventArgs) Handles btnproductosfaltantes.Click
        Dim formulario As New FRNOTAPRODUCTOSFALTANTES
        formulario.ShowDialog()
    End Sub

    Private Sub Btnimprimirfiltro_Click(sender As Object, e As EventArgs) Handles btnimprimirfiltro.Click

        Dim formulario As New FRNOTAPRODUCTOSFALTANTESFILTRO
        formulario.ShowDialog()


    End Sub

    Private Sub Corcbproveedores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles corcbproveedores.SelectedIndexChanged
        consultaproductosfaltantescombobox()








    End Sub

    Private Sub Button66_Click_1(sender As Object, e As EventArgs) Handles Button66.Click
        Dim valores As String
        valores = My.Computer.Name.ToString
        MsgBox(valores)
    End Sub

    Private Sub Button82_Click_1(sender As Object, e As EventArgs) Handles btnabrircajamenu.Click
        abrircaja()
    End Sub

    Private Sub Button76_Click_1(sender As Object, e As EventArgs) Handles Button76.Click
        'cambiamos la contraseña
        FRMPASS.ShowDialog()
    End Sub

    Private Sub stxtclave_GotFocus(sender As Object, e As EventArgs) Handles stxtclave.GotFocus
        'stxtclave.BackColor = Color.White

    End Sub

    Private Sub Compratxtiva_TextChanged(sender As Object, e As EventArgs) Handles compratxtiva.TextChanged
        sumatoriocompra()
    End Sub

    Private Sub PrintDocument2_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument2.PrintPage
        'e.Graphics.DrawString(txtetiqueta1, New Font("verdana", 11, FontStyle.Bold), New SolidBrush(Color.Black), 1, 9)
        'e.Graphics.DrawString(txtetiqueta2, New Font("verdana", 9, FontStyle.Bold), New SolidBrush(Color.Black), 1, 28)
        'e.Graphics.DrawString(txtetiqueta, New Font("verdana", 13, FontStyle.Bold), New SolidBrush(Color.Black), 1, 57)
        'traemos la información del ticket, como encabezado, datos de la empresa etc.
        Dim saludo, ticketnombre, ticketcoloniaciudad, tickettelefono, ticketgiro, p1, p2, p3, p4, comentario As String
        Dim callenumero, cp, estado, whatsapp, correo, rfc As String
        Dim x, y, tfuente, tfuente2, tfuente3 As Integer
        Try


            conexionMysql.Open()
            Dim Sql1 As String
            Sql1 = "select * from datos_empresa;"
            Dim cmd1 As New MySqlCommand(Sql1, conexionMysql)
            reader = cmd1.ExecuteReader()
            reader.Read()
            ticketnombre = reader.GetString(1).ToString()
            callenumero = reader.GetString(2).ToString()
            ticketcoloniaciudad = reader.GetString(3).ToString()
            cp = reader.GetString(4).ToString()
            estado = reader.GetString(5).ToString()
            tickettelefono = reader.GetString(6).ToString()
            whatsapp = reader.GetString(7).ToString()
            correo = reader.GetString(8).ToString()
            'ctxtfacebook.Text = reader.GetString(9).ToString()
            'ctxtsitio.Text = reader.GetString(10).ToString()
            'ctxtencargado.Text = reader.GetString(11).ToString()
            'ctxthorario.Text = reader.GetString(12).ToString()
            ticketgiro = reader.GetString(13).ToString()
            saludo = reader.GetString(24).ToString()
            'p1 = reader.GetString(14).ToString()
            'P2 = reader.GetString(15).ToString()
            'P3 = reader.GetString(16).ToString()
            'p4 = reader.GetString(17).ToString()
            rfc = reader.GetString(22).ToString()

            conexionMysql.Close()

        Catch ex As Exception

        End Try

        Dim id, actividad, cantidad, costo, total, fecha, hora, idusuario, idmax As String

        conexionMysql.Open()
        Dim Sql12 As String
        Sql12 = "Select Case max(idcompra) from compra;"
        Dim cmd12 As New MySqlCommand(Sql12, conexionMysql)
        reader = cmd12.ExecuteReader()
        reader.Read()
        idmax = reader.GetString(1).ToString()
        conexionMysql.Close()

        cerrarcaja()

        Try
            conexionMysql.Open()
            Dim Sql13 As String
            Sql13 = "select * from compra where max;"
            Dim cmd13 As New MySqlCommand(Sql13, conexionMysql)
            reader = cmd13.ExecuteReader()
            reader.Read()
            id = reader.GetString(1).ToString()
            actividad = reader.GetString(2).ToString()
            costo = reader.GetString(3).ToString()
            total = reader.GetString(4).ToString()
            fecha = reader.GetString(5).ToString()
            hora = reader.GetString(6).ToString()
            idusuario = reader.GetString(7).ToString()
            'correo = reader.GetString(8).ToString()
            'ctxtfacebook.Text = reader.GetString(9).ToString()
            'ctxtsitio.Text = reader.GetString(10).ToString()
            'ctxtencargado.Text = reader.GetString(11).ToString()
            'ctxthorario.Text = reader.GetString(12).ToString()
            'ticketgiro = reader.GetString(13).ToString()
            'saludo = reader.GetString(24).ToString()
            'p1 = reader.GetString(14).ToString()
            'P2 = reader.GetString(15).ToString()
            'P3 = reader.GetString(16).ToString()
            'p4 = reader.GetString(17).ToString()
            'rfc = reader.GetString(22).ToString()
            conexionMysql.Close()
        Catch ex As Exception

        End Try








        tfuente = 10 '7
        tfuente2 = 12
        tfuente3 = 10
        p1 = 10 'posicion de X
        x = 5
        y = 125
        Dim ii, incremento As Integer
        incremento = 14
        Dim yy(20) As Integer
        For ii = 0 To 20
            y = y + incremento
            yy(ii) = y
        Next



        Try
            ' La fuente a usar
            Dim prFont As New Font("Arial", 15, FontStyle.Bold)
            'POSICION DEL LOGO
            ' la posición superior
            e.Graphics.DrawImage(pblogoticket.Image, 50, 20, 110, 110)


            'imprimir el titutlo del ticket



            prFont = New Font("Arial", tfuente2, FontStyle.Bold)
            e.Graphics.DrawString(ticketnombre, prFont, Brushes.Black, x, yy(0))
            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString(ticketgiro, prFont, Brushes.Black, x, yy(2))
            'IMPRESION DE LOGOTIPO,
            'prFont = New Font("Arial", tfuente, FontStyle.Bold)
            'e.Graphics.DrawString(ticketgiro, prFont, Brushes.Black, x, yy(2))


            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString(callenumero, prFont, Brushes.Black, x, yy(3))

            'imprimir el titutlo del ticket
            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString(ticketcoloniaciudad, prFont, Brushes.Black, x, yy(4))
            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString("CP:" & cp, prFont, Brushes.Black, x, yy(5))
            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString("TEL:" & tickettelefono, prFont, Brushes.Black, x, yy(6))
            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString("RFC:" & rfc, prFont, Brushes.Black, x, yy(7))
            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString("==================================", prFont, Brushes.Black, x, yy(8))

            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString("USUARIO:" & usuarioactual, prFont, Brushes.Black, x, yy(9))

            'imprimir el titutlo del ticket
            'prFont = New Font("Arial", tfuente, FontStyle.Bold)
            'e.Graphics.DrawString("CLIENTE:" & txtcliente.Text, prFont, Brushes.Black, x, yy(10))
            'prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString("FECHA:" & Date.Now, prFont, Brushes.Black, x, yy(11))
            prFont = New Font("Arial", tfuente2, FontStyle.Bold)
            e.Graphics.DrawString("FOLIO #:" & lbfolio.Text, prFont, Brushes.Black, x, yy(12))
            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString("==================================", prFont, Brushes.Black, x, yy(13))

            'imprimir el titutlo del ticket

            prFont = New Font("Arial", tfuente3, FontStyle.Bold)
            e.Graphics.DrawString("ARTICULO", prFont, Brushes.Black, x, yy(14))
            prFont = New Font("Arial", tfuente3, FontStyle.Bold)
            e.Graphics.DrawString("ID------PRECIO------CANTIDAD----TOTAL", prFont, Brushes.Black, x, yy(15))

            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString("==================================", prFont, Brushes.Black, x, yy(16))



            ''aqui es donde tenemos que leer todos los datos de la grilla llamada "grilla"

            Dim i As Integer = grilla.RowCount
            Dim t1, t2, t3, t4, t5 As Integer
            'Dim actividad As String
            'Dim cantidad, costo, idventa As Double
            Dim idproducto As String

            't1 = yy(17)
            't2 = yy(18)
            't3 = yy(19)
            't4 = 40

            ''suma de valores
            'For j = 0 To i - 2
            '    'MsgBox("valosr de j:" & j)
            '    'a = venta.grillaventa.Item(j, 3).Value.ToString()
            '    actividad = grilla.Rows(j).Cells(1).Value 'descripcion
            '    cantidad = grilla.Rows(j).Cells(2).Value 'cantidad
            '    costo = grilla.Rows(j).Cells(3).Value 'costo
            '    idproducto = grilla.Rows(j).Cells(5).Value
            '    comentario = grilla.Rows(j).Cells(6).Value
            '    'cerrarconexion()
            '    'conexionMysql.Open()

            '    'MsgBox("el producto es:" & actividad)

            '    'Dim Sql2 As String
            '    'Sql2 = "INSERT INTO ventaind (actividad, cantidad, costo, idventa,idproducto) VALUES ('" & actividad & "'," & cantidad & "," & costo & "," & lbfolio.Text & ",'" & idproducto & "');"
            '    'Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            '    'cmd2.ExecuteNonQuery()
            '    'conexionMysql.Close()

            '    prFont = New Font("Arial", tfuente3, FontStyle.Bold)
            '    e.Graphics.DrawString(actividad, prFont, Brushes.Black, x, t1)

            '    prFont = New Font("Arial", tfuente3, FontStyle.Bold)
            '    e.Graphics.DrawString(idproducto & "-----$" & costo & "-----" & cantidad & "-----$" & (CDbl(costo) * CDbl(cantidad)), prFont, Brushes.Black, x, t2)
            '    prFont = New Font("Arial", tfuente3, FontStyle.Bold)
            '    e.Graphics.DrawString(comentario, prFont, Brushes.Black, x, t3)


            '    'prFont = New Font("Arial", 10, FontStyle.Bold)
            '    'e.Graphics.DrawString(cantidad & "-- $" & (CDbl(costo) * CDbl(cantidad)), prFont, Brushes.Black, 0, t3)

            '    t1 = t1 + (incremento * 3.2)
            '    t2 = t2 + (incremento * 3.2)
            '    t3 = t3 + (incremento * 3.2)

            'Next

            t1 = t1 - (incremento * 2)
            t2 = t2 - (incremento * 2)
            t3 = t3 - (incremento * 2)


            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString("==================================", prFont, Brushes.Black, 0, t3)

            '----------------AQUI SE IMPRIME EL TOTAL A PAGAR

            prFont = New Font("Arial", tfuente3, FontStyle.Bold)
            e.Graphics.DrawString("   Total---->$" & txttotalpagar.Text, prFont, Brushes.Black, x, t3 + incremento)
            prFont = New Font("Arial", tfuente3, FontStyle.Bold)
            e.Graphics.DrawString("Efectivo---->$" & lbpagacon.Text, prFont, Brushes.Black, x, t3 + (incremento * 2))
            prFont = New Font("Arial", tfuente3, FontStyle.Bold)
            e.Graphics.DrawString("  Cambio---->$" & lbcambio.Text, prFont, Brushes.Black, x, t3 + (incremento * 3))

            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString("==================================", prFont, Brushes.Black, x, t3 + (incremento * 4))
            prFont = New Font("Arial", tfuente3, FontStyle.Bold)
            e.Graphics.DrawString(saludo, prFont, Brushes.Black, x, t3 + (incremento * 5))
            'prFont = New Font("Arial", tfuente3, FontStyle.Bold)
            'e.Graphics.DrawString("CTRL+y", prFont, Brushes.Black, 10, t2 + 60)

            ''imprimimos la fecha y hora
            'prFont = New Font("Arial", 10, FontStyle.Regular)
            'e.Graphics.DrawString(Date.Now.ToShortDateString.ToString & " " &
            '                Date.Now.ToShortTimeString.ToString, prFont, Brushes.Black, 15, 385)

            ''imprimimos el nombre del cliente
            'prFont = New Font("Arial", 25, FontStyle.Bold)
            'e.Graphics.DrawString("Nombre del Cliente" & txtcliente.Text, prFont, Brushes.Black, 50, 250)

            ''imprimimos la referencia del pedido
            'e.Graphics.DrawString("Referencia", prFont, Brushes.Black, 50, 520)
            'prFont = New Font("Arial", 18, FontStyle.Bold)
            'e.Graphics.DrawString("Nombre de la Referencia", prFont, Brushes.Black, 50, 555)

            ''imprimimos Pedido Ondupack y Pedido del cliente
            'prFont = New Font("Arial", 22, FontStyle.Regular)
            'e.Graphics.DrawString("Pedido", prFont, Brushes.Black, 50, 660)
            'e.Graphics.DrawString("Palets", prFont, Brushes.Black, 250, 660)

            'prFont = New Font("Arial", 24, FontStyle.Regular)
            'e.Graphics.DrawString("19875", prFont, Brushes.Black, 50, 700)
            'e.Graphics.DrawString("44", prFont, Brushes.Black, 250, 700)

            ''imprimimos Cajas X Palet y Cajas x Paquete
            'prFont = New Font("Arial", 22, FontStyle.Regular)
            'e.Graphics.DrawString("Cajas x Palet", prFont, Brushes.Black, 50, 760)
            'e.Graphics.DrawString("Cajas x Paquete", prFont, Brushes.Black, 250, 760)

            'prFont = New Font("Arial", 24, FontStyle.Regular)
            'e.Graphics.DrawString("500", prFont, Brushes.Black, 50, 800)
            'e.Graphics.DrawString("32", prFont, Brushes.Black, 250, 800)

            ''imprimimos el numero del Palet
            'prFont = New Font("Arial", 24, FontStyle.Regular)
            'e.Graphics.DrawString("Número del Palet     45", prFont, Brushes.Black, 50, 880)
            ''indicamos que hemos llegado al final de la pagina
            'e.HasMorePages = False

        Catch ex As Exception
            MessageBox.Show("ERROR: " & ex.Message, "Administrador",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub PrintDocument3_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument3.PrintPage
        'e.Graphics.DrawString(txtetiqueta1, New Font("verdana", 11, FontStyle.Bold), New SolidBrush(Color.Black), 1, 9)
        'e.Graphics.DrawString(txtetiqueta2, New Font("verdana", 9, FontStyle.Bold), New SolidBrush(Color.Black), 1, 28)
        'e.Graphics.DrawString(txtetiqueta, New Font("verdana", 13, FontStyle.Bold), New SolidBrush(Color.Black), 1, 57)
        'traemos la información del ticket, como encabezado, datos de la empresa etc.
        Dim saludo, ticketnombre, ticketcoloniaciudad, tickettelefono, ticketgiro, p1, p2, p3, p4, comentario As String
        Dim callenumero, cp, estado, whatsapp, correo, rfc As String
        Dim x, y, tfuente, tfuente2, tfuente3 As Integer
        Try


            conexionMysql.Open()
            Dim Sql1 As String
            Sql1 = "select * from datos_empresa;"
            Dim cmd1 As New MySqlCommand(Sql1, conexionMysql)
            reader = cmd1.ExecuteReader()
            reader.Read()
            ticketnombre = reader.GetString(1).ToString()
            callenumero = reader.GetString(2).ToString()
            ticketcoloniaciudad = reader.GetString(3).ToString()
            cp = reader.GetString(4).ToString()
            estado = reader.GetString(5).ToString()
            tickettelefono = reader.GetString(6).ToString()
            whatsapp = reader.GetString(7).ToString()
            correo = reader.GetString(8).ToString()
            'ctxtfacebook.Text = reader.GetString(9).ToString()
            'ctxtsitio.Text = reader.GetString(10).ToString()
            'ctxtencargado.Text = reader.GetString(11).ToString()
            'ctxthorario.Text = reader.GetString(12).ToString()
            ticketgiro = reader.GetString(13).ToString()
            saludo = reader.GetString(24).ToString()
            'p1 = reader.GetString(14).ToString()
            'P2 = reader.GetString(15).ToString()
            'P3 = reader.GetString(16).ToString()
            'p4 = reader.GetString(17).ToString()
            rfc = reader.GetString(22).ToString()

            conexionMysql.Close()

        Catch ex As Exception

        End Try

        Dim id, actividad, cantidad, costo, total, fecha, hora, idusuario, idmax As String

        conexionMysql.Open()
        Dim Sql12 As String
        Sql12 = "Select Case max(idcompra) from compra;"
        Dim cmd12 As New MySqlCommand(Sql12, conexionMysql)
        reader = cmd12.ExecuteReader()
        reader.Read()
        idmax = reader.GetString(1).ToString()
        conexionMysql.Close()

        cerrarcaja()

        Try
            conexionMysql.Open()
            Dim Sql13 As String
            Sql13 = "select * from compra where max;"
            Dim cmd13 As New MySqlCommand(Sql13, conexionMysql)
            reader = cmd13.ExecuteReader()
            reader.Read()
            id = reader.GetString(1).ToString()
            actividad = reader.GetString(2).ToString()
            costo = reader.GetString(3).ToString()
            total = reader.GetString(4).ToString()
            fecha = reader.GetString(5).ToString()
            hora = reader.GetString(6).ToString()
            idusuario = reader.GetString(7).ToString()
            'correo = reader.GetString(8).ToString()
            'ctxtfacebook.Text = reader.GetString(9).ToString()
            'ctxtsitio.Text = reader.GetString(10).ToString()
            'ctxtencargado.Text = reader.GetString(11).ToString()
            'ctxthorario.Text = reader.GetString(12).ToString()
            'ticketgiro = reader.GetString(13).ToString()
            'saludo = reader.GetString(24).ToString()
            'p1 = reader.GetString(14).ToString()
            'P2 = reader.GetString(15).ToString()
            'P3 = reader.GetString(16).ToString()
            'p4 = reader.GetString(17).ToString()
            'rfc = reader.GetString(22).ToString()
            conexionMysql.Close()
        Catch ex As Exception

        End Try








        tfuente = 10 '7
        tfuente2 = 12
        tfuente3 = 10
        p1 = 10 'posicion de X
        x = 5
        y = 125
        Dim ii, incremento As Integer
        incremento = 14
        Dim yy(20) As Integer
        For ii = 0 To 20
            y = y + incremento
            yy(ii) = y
        Next



        Try
            ' La fuente a usar
            Dim prFont As New Font("Arial", 15, FontStyle.Bold)
            'POSICION DEL LOGO
            ' la posición superior
            e.Graphics.DrawImage(pblogoticket.Image, 50, 20, 110, 110)


            'imprimir el titutlo del ticket



            prFont = New Font("Arial", tfuente2, FontStyle.Bold)
            e.Graphics.DrawString(ticketnombre, prFont, Brushes.Black, x, yy(0))
            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString(ticketgiro, prFont, Brushes.Black, x, yy(2))
            'IMPRESION DE LOGOTIPO,
            'prFont = New Font("Arial", tfuente, FontStyle.Bold)
            'e.Graphics.DrawString(ticketgiro, prFont, Brushes.Black, x, yy(2))


            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString(callenumero, prFont, Brushes.Black, x, yy(3))

            'imprimir el titutlo del ticket
            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString(ticketcoloniaciudad, prFont, Brushes.Black, x, yy(4))
            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString("CP:" & cp, prFont, Brushes.Black, x, yy(5))
            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString("TEL:" & tickettelefono, prFont, Brushes.Black, x, yy(6))
            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString("RFC:" & rfc, prFont, Brushes.Black, x, yy(7))
            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString("==================================", prFont, Brushes.Black, x, yy(8))

            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString("USUARIO:" & usuarioactual, prFont, Brushes.Black, x, yy(9))

            'imprimir el titutlo del ticket
            'prFont = New Font("Arial", tfuente, FontStyle.Bold)
            'e.Graphics.DrawString("CLIENTE:" & txtcliente.Text, prFont, Brushes.Black, x, yy(10))
            'prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString("FECHA:" & Date.Now, prFont, Brushes.Black, x, yy(11))
            prFont = New Font("Arial", tfuente2, FontStyle.Bold)
            e.Graphics.DrawString("FOLIO #:" & lbfolio.Text, prFont, Brushes.Black, x, yy(12))
            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString("==================================", prFont, Brushes.Black, x, yy(13))

            'imprimir el titutlo del ticket

            prFont = New Font("Arial", tfuente3, FontStyle.Bold)
            e.Graphics.DrawString("ARTICULO", prFont, Brushes.Black, x, yy(14))
            prFont = New Font("Arial", tfuente3, FontStyle.Bold)
            e.Graphics.DrawString("ID------PRECIO------CANTIDAD----TOTAL", prFont, Brushes.Black, x, yy(15))

            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString("==================================", prFont, Brushes.Black, x, yy(16))



            'aqui es donde tenemos que leer todos los datos de la grilla llamada "grilla"

            Dim i As Integer = grilla.RowCount
            Dim t1, t2, t3, t4, t5 As Integer
            ' Dim actividad As String
            ' Dim cantidad, costo, idventa As Double
            Dim idproducto As String

            t1 = yy(17)
            t2 = yy(18)
            t3 = yy(19)
            t4 = 40

            'suma de valores
            For j = 0 To i - 2
                'MsgBox("valosr de j:" & j)
                'a = venta.grillaventa.Item(j, 3).Value.ToString()
                actividad = grilla.Rows(j).Cells(1).Value 'descripcion
                cantidad = grilla.Rows(j).Cells(2).Value 'cantidad
                costo = grilla.Rows(j).Cells(3).Value 'costo
                idproducto = grilla.Rows(j).Cells(5).Value
                comentario = grilla.Rows(j).Cells(6).Value
                'cerrarconexion()
                'conexionMysql.Open()

                'MsgBox("el producto es:" & actividad)

                'Dim Sql2 As String
                'Sql2 = "INSERT INTO ventaind (actividad, cantidad, costo, idventa,idproducto) VALUES ('" & actividad & "'," & cantidad & "," & costo & "," & lbfolio.Text & ",'" & idproducto & "');"
                'Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
                'cmd2.ExecuteNonQuery()
                'conexionMysql.Close()

                prFont = New Font("Arial", tfuente3, FontStyle.Bold)
                e.Graphics.DrawString(actividad, prFont, Brushes.Black, x, t1)

                prFont = New Font("Arial", tfuente3, FontStyle.Bold)
                e.Graphics.DrawString(idproducto & "-----$" & costo & "-----" & cantidad & "-----$" & (CDbl(costo) * CDbl(cantidad)), prFont, Brushes.Black, x, t2)
                prFont = New Font("Arial", tfuente3, FontStyle.Bold)
                e.Graphics.DrawString(comentario, prFont, Brushes.Black, x, t3)


                'prFont = New Font("Arial", 10, FontStyle.Bold)
                'e.Graphics.DrawString(cantidad & "-- $" & (CDbl(costo) * CDbl(cantidad)), prFont, Brushes.Black, 0, t3)

                t1 = t1 + (incremento * 3.2)
                t2 = t2 + (incremento * 3.2)
                t3 = t3 + (incremento * 3.2)

            Next

            t1 = t1 - (incremento * 2)
            t2 = t2 - (incremento * 2)
            t3 = t3 - (incremento * 2)


            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString("==================================", prFont, Brushes.Black, 0, t3)

            '----------------AQUI SE IMPRIME EL TOTAL A PAGAR

            prFont = New Font("Arial", tfuente3, FontStyle.Bold)
            e.Graphics.DrawString("   Total---->$" & txttotalpagar.Text, prFont, Brushes.Black, x, t3 + incremento)
            prFont = New Font("Arial", tfuente3, FontStyle.Bold)
            e.Graphics.DrawString("Efectivo---->$" & lbpagacon.Text, prFont, Brushes.Black, x, t3 + (incremento * 2))
            prFont = New Font("Arial", tfuente3, FontStyle.Bold)
            e.Graphics.DrawString("  Cambio---->$" & lbcambio.Text, prFont, Brushes.Black, x, t3 + (incremento * 3))

            prFont = New Font("Arial", tfuente, FontStyle.Bold)
            e.Graphics.DrawString("==================================", prFont, Brushes.Black, x, t3 + (incremento * 4))
            prFont = New Font("Arial", tfuente3, FontStyle.Bold)
            e.Graphics.DrawString(saludo, prFont, Brushes.Black, x, t3 + (incremento * 5))
            'prFont = New Font("Arial", tfuente3, FontStyle.Bold)
            'e.Graphics.DrawString("CTRL+y", prFont, Brushes.Black, 10, t2 + 60)

            ''imprimimos la fecha y hora
            'prFont = New Font("Arial", 10, FontStyle.Regular)
            'e.Graphics.DrawString(Date.Now.ToShortDateString.ToString & " " &
            '                Date.Now.ToShortTimeString.ToString, prFont, Brushes.Black, 15, 385)

            ''imprimimos el nombre del cliente
            'prFont = New Font("Arial", 25, FontStyle.Bold)
            'e.Graphics.DrawString("Nombre del Cliente" & txtcliente.Text, prFont, Brushes.Black, 50, 250)

            ''imprimimos la referencia del pedido
            'e.Graphics.DrawString("Referencia", prFont, Brushes.Black, 50, 520)
            'prFont = New Font("Arial", 18, FontStyle.Bold)
            'e.Graphics.DrawString("Nombre de la Referencia", prFont, Brushes.Black, 50, 555)

            ''imprimimos Pedido Ondupack y Pedido del cliente
            'prFont = New Font("Arial", 22, FontStyle.Regular)
            'e.Graphics.DrawString("Pedido", prFont, Brushes.Black, 50, 660)
            'e.Graphics.DrawString("Palets", prFont, Brushes.Black, 250, 660)

            'prFont = New Font("Arial", 24, FontStyle.Regular)
            'e.Graphics.DrawString("19875", prFont, Brushes.Black, 50, 700)
            'e.Graphics.DrawString("44", prFont, Brushes.Black, 250, 700)

            ''imprimimos Cajas X Palet y Cajas x Paquete
            'prFont = New Font("Arial", 22, FontStyle.Regular)
            'e.Graphics.DrawString("Cajas x Palet", prFont, Brushes.Black, 50, 760)
            'e.Graphics.DrawString("Cajas x Paquete", prFont, Brushes.Black, 250, 760)

            'prFont = New Font("Arial", 24, FontStyle.Regular)
            'e.Graphics.DrawString("500", prFont, Brushes.Black, 50, 800)
            'e.Graphics.DrawString("32", prFont, Brushes.Black, 250, 800)

            ''imprimimos el numero del Palet
            'prFont = New Font("Arial", 24, FontStyle.Regular)
            'e.Graphics.DrawString("Número del Palet     45", prFont, Brushes.Black, 50, 880)
            ''indicamos que hemos llegado al final de la pagina
            'e.HasMorePages = False

        Catch ex As Exception
            MessageBox.Show("ERROR: " & ex.Message, "Administrador",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Button82_Click_2(sender As Object, e As EventArgs) Handles Button82.Click
        comprobarpermisoscasillas()
    End Sub

    Private Sub stxtnombre_GotFocus(sender As Object, e As EventArgs) Handles stxtnombre.GotFocus
        stxtnombre.BackColor = Color.White

    End Sub

    Private Sub Button2_GotFocus(sender As Object, e As EventArgs) Handles Button2.GotFocus

    End Sub

    Private Sub stxtcantidad_GotFocus(sender As Object, e As EventArgs) Handles stxtcantidad.GotFocus

    End Sub

    Private Sub grilla2p_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grilla2p.CellContentDoubleClick
        Try

            Dim Variable As String = grilla2p.Item(0, grilla2p.CurrentRow.Index).Value
            'MsgBox(Variable)
            txtclavep.Text = Variable
            grilla2p.Visible = False
            grillap.Visible = True
            rbclavep.Checked = True

        Catch ex As Exception

        End Try
    End Sub

    Private Sub listaservicios_KeyPress(sender As Object, e As KeyPressEventArgs) Handles listaservicios.KeyPress

    End Sub

    Private Sub grillaclienteservicios_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grillaclienteservicios.CellClick
        'MsgBox("dando clic a la celda")
        'Try
        Dim fechaentrega As String

        txtclientefolioservicio.Text = grillaclienteservicios.Item(0, grillaclienteservicios.CurrentRow.Index).Value
        Try

            txtclienteadeudo.Text = grillaclienteservicios.Item(6, grillaclienteservicios.CurrentRow.Index).Value
        Catch ex As Exception
            txtclienteadeudo.Text = ""
        End Try


        Try

            txtclientetiposervicio.Text = grillaclienteservicios.Item(9, grillaclienteservicios.CurrentRow.Index).Value
        Catch ex As Exception
            txtclientetiposervicio.Text = ""
        End Try


        Try

            txtclientetotalpagar.Text = grillaclienteservicios.Item(2, grillaclienteservicios.CurrentRow.Index).Value
        Catch ex As Exception
            txtclientetotalpagar.Text = ""
        End Try

        Try

            fechaentrega = grillaclienteservicios.Item(4, grillaclienteservicios.CurrentRow.Index).Value
        Catch ex As Exception
            txtclientetiposervicio.Text = "VENTA GENERAL"

        End Try


        'Catch ex As Exception
        'MsgBox()
        'cerrarconexion()
        'End Try

    End Sub

    Private Sub grillacliente_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grillacliente.CellClick
        Try

            Dim Variable As Integer = grillacliente.Item(0, grillacliente.CurrentRow.Index).Value
            'MsgBox(Variable)
            cerrarconexion()


            Try


                conexionMysql.Open()
                Dim sql As String
                sql = "select * from cliente where idcliente =" & Variable & ";"
                Dim cmd As New MySqlCommand(sql, conexionMysql)
                reader = cmd.ExecuteReader
                reader.Read()
                ctxtidcliente.Text = reader.GetString(0).ToString()
                ctxtnombre.Text = reader.GetString(1).ToString()
                ctxtap.Text = reader.GetString(2).ToString()
                ctxtam.Text = reader.GetString(3).ToString()
                ctxtdireccion.Text = reader.GetString(5).ToString()
                ctxttelefono.Text = reader.GetString(6).ToString()
                ctxtcorreo.Text = reader.GetString(7).ToString()

                ctxtedad.Text = reader.GetString(4).ToString()

                conexionMysql.Close()

            Catch ex As Exception
                cerrarconexion()
                btninconsistencia.Visible = True


            End Try
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btninconsistencia_GotFocus(sender As Object, e As EventArgs) Handles btninconsistencia.GotFocus
        btninconsistencia.Visible = False

    End Sub

    Private Sub ccgrilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles ccgrilla.CellDoubleClick
        Try

            'eliminar datos al dar doble clic.
            'grilla.CurrentRow.Index
            ccgrilla.Rows.RemoveAt(ccgrilla.CurrentRow.Index)
            'eliminado el registro, sumamos el total de valores. 
            sumatoriocompra()
        Catch ex As Exception

        End Try
    End Sub
End Class