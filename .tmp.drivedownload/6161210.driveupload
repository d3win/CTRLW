Imports MySql.Data.MySqlClient

'librerias para poder importar y exportar una BD de Mysql
Imports System.IO.StreamWriter
Imports System.IO

Public Class frmindex
    Public respaldar As New SaveFileDialog
    Public carpeta As New FolderBrowserDialog
    Public abrir As New OpenFileDialog
    Public hora, hora2, minuto, segundo, usuarioactual As String
    Dim respuesta As String
    Dim idsumado As Integer
    Dim existe As Boolean
    Public txtpagar, ventamaxima As Double
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
            grilla2.Columns(1).Width = 350
            grilla2.Columns(0).Width = 60
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
        listaclientes.Visible = False
        'inicio la variable en 0, COMPRAS mercancia
        idsumado = 0

        Button1.BackColor = Color.DimGray



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




    End Sub
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
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        ' Button14.ForeColor = Color.White
        TabControl1.SelectedIndex = 1
            txtcliente.Text = "USUARIO"
            listaclientes.Visible = False
            grilla.DefaultCellStyle.Font = New Font("Arial", 20)
            grilla.RowHeadersVisible = False



            Button2.BackColor = Color.DimGray
            Button1.BackColor = Color.FromArgb(64, 64, 64)
            Button3.BackColor = Color.FromArgb(64, 64, 64)
            Button4.BackColor = Color.FromArgb(64, 64, 64)
            Button5.BackColor = Color.FromArgb(64, 64, 64)
            Button6.BackColor = Color.FromArgb(64, 64, 64)
            Button8.BackColor = Color.FromArgb(64, 64, 64)
            Button10.BackColor = Color.FromArgb(64, 64, 64)
            Button12.BackColor = Color.FromArgb(64, 64, 64)
            Button13.BackColor = Color.FromArgb(64, 64, 64)
            Button67.BackColor = Color.FromArgb(64, 64, 64)



            'se obtiene el folio cada vez que se agrege un producto. 
            obtenerfolio()

            txtclave.Focus()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TabControl1.SelectedIndex = 0

        Button1.BackColor = Color.DimGray
        Button2.BackColor = Color.FromArgb(64, 64, 64)
        Button3.BackColor = Color.FromArgb(64, 64, 64)
        Button4.BackColor = Color.FromArgb(64, 64, 64)
        Button5.BackColor = Color.FromArgb(64, 64, 64)
        Button6.BackColor = Color.FromArgb(64, 64, 64)
        Button8.BackColor = Color.FromArgb(64, 64, 64)
        Button10.BackColor = Color.FromArgb(64, 64, 64)
        Button12.BackColor = Color.FromArgb(64, 64, 64)
        Button13.BackColor = Color.FromArgb(64, 64, 64)
        Button67.BackColor = Color.FromArgb(64, 64, 64)

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

        tipo = tipoingreso()


        If tipo = 2 Then

            TabControl1.SelectedIndex = 1
            Button1.BackColor = Color.DimGray
            Button2.BackColor = Color.FromArgb(64, 64, 64)
            Button3.BackColor = Color.FromArgb(64, 64, 64)
            Button4.BackColor = Color.FromArgb(64, 64, 64)
            Button5.BackColor = Color.FromArgb(64, 64, 64)
            Button6.BackColor = Color.FromArgb(64, 64, 64)
            Button8.BackColor = Color.FromArgb(64, 64, 64)
            Button10.BackColor = Color.FromArgb(64, 64, 64)
            Button12.BackColor = Color.FromArgb(64, 64, 64)
            Button13.BackColor = Color.FromArgb(64, 64, 64)
            Button67.BackColor = Color.FromArgb(64, 64, 64)


            comprobartipoingreso()
        Else


            listaproductos.Visible = False


            'cargamos los proveedores de compras.
            cargarproveedorcompras()

            'rbgastosdiarios.Enabled = True
            rbgastosdiarios.Checked = True

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

            comprasdeldia()
            ctxtcomprado.Text = consultacompras()



            Button1.BackColor = Color.FromArgb(64, 64, 64)
            Button2.BackColor = Color.FromArgb(64, 64, 64)
            Button3.BackColor = Color.DimGray
            Button4.BackColor = Color.FromArgb(64, 64, 64)
            Button5.BackColor = Color.FromArgb(64, 64, 64)
            Button6.BackColor = Color.FromArgb(64, 64, 64)
            Button8.BackColor = Color.FromArgb(64, 64, 64)
            Button10.BackColor = Color.FromArgb(64, 64, 64)
            Button12.BackColor = Color.FromArgb(64, 64, 64)
            Button13.BackColor = Color.FromArgb(64, 64, 64)
            Button67.BackColor = Color.FromArgb(64, 64, 64)

        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim tipo As Integer

        tipo = tipoingreso()


        If tipo = 2 Then

            TabControl1.SelectedIndex = 1
            Button1.BackColor = Color.DimGray
            Button2.BackColor = Color.FromArgb(64, 64, 64)
            Button3.BackColor = Color.FromArgb(64, 64, 64)
            Button4.BackColor = Color.FromArgb(64, 64, 64)
            Button5.BackColor = Color.FromArgb(64, 64, 64)
            Button6.BackColor = Color.FromArgb(64, 64, 64)
            Button8.BackColor = Color.FromArgb(64, 64, 64)
            Button10.BackColor = Color.FromArgb(64, 64, 64)
            Button12.BackColor = Color.FromArgb(64, 64, 64)
            Button13.BackColor = Color.FromArgb(64, 64, 64)
            Button67.BackColor = Color.FromArgb(64, 64, 64)


            comprobartipoingreso()
        Else

            TabControl1.SelectedIndex = 3
            txtnombrep.Visible = False
            'btnbuscarnombrep.Visible = False
            rbclavep.Checked = True
            cargarproveedor()
            cargartiposervicio()
            Button1.BackColor = Color.FromArgb(64, 64, 64)
            Button2.BackColor = Color.FromArgb(64, 64, 64)
            Button3.BackColor = Color.FromArgb(64, 64, 64)
            Button4.BackColor = Color.DimGray
            Button5.BackColor = Color.FromArgb(64, 64, 64)
            Button6.BackColor = Color.FromArgb(64, 64, 64)
            Button8.BackColor = Color.FromArgb(64, 64, 64)
            Button10.BackColor = Color.FromArgb(64, 64, 64)
            Button12.BackColor = Color.FromArgb(64, 64, 64)
            Button13.BackColor = Color.FromArgb(64, 64, 64)
            Button67.BackColor = Color.FromArgb(64, 64, 64)

            llenadogrilla()
        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click



        Dim tipo As Integer

        tipo = tipoingreso()


        If tipo = 2 Then

            TabControl1.SelectedIndex = 1
            Button1.BackColor = Color.DimGray
            Button2.BackColor = Color.FromArgb(64, 64, 64)
            Button3.BackColor = Color.FromArgb(64, 64, 64)
            Button4.BackColor = Color.FromArgb(64, 64, 64)
            Button5.BackColor = Color.FromArgb(64, 64, 64)
            Button6.BackColor = Color.FromArgb(64, 64, 64)
            Button8.BackColor = Color.FromArgb(64, 64, 64)
            Button10.BackColor = Color.FromArgb(64, 64, 64)
            Button12.BackColor = Color.FromArgb(64, 64, 64)
            Button13.BackColor = Color.FromArgb(64, 64, 64)
            Button67.BackColor = Color.FromArgb(64, 64, 64)


            comprobartipoingreso()
        Else




            cgrillacorte.DefaultCellStyle.Font = New Font("Arial", 20)
            cgrillacorte.RowHeadersVisible = False
            'ampliar columna 
            'grillap.Columns(2).Width = 120


            cgrillacorte.AlternatingRowsDefaultCellStyle.BackColor = Color.SkyBlue

            'desglosecorte sirve para hacer un recuento de cuanto se ha vendido hasta el momento de extras, paleleria y servicios
            desglosecorte()
            desgloseventas()
            desglosecortecalendario()


            TabControl1.SelectedIndex = 4

            Button1.BackColor = Color.FromArgb(64, 64, 64)
            Button2.BackColor = Color.FromArgb(64, 64, 64)
            Button3.BackColor = Color.FromArgb(64, 64, 64)
            Button4.BackColor = Color.FromArgb(64, 64, 64)
            Button5.BackColor = Color.DimGray
            Button6.BackColor = Color.FromArgb(64, 64, 64)
            Button8.BackColor = Color.FromArgb(64, 64, 64)
            Button10.BackColor = Color.FromArgb(64, 64, 64)
            Button12.BackColor = Color.FromArgb(64, 64, 64)
            Button13.BackColor = Color.FromArgb(64, 64, 64)
            Button67.BackColor = Color.FromArgb(64, 64, 64)





            'se consulta cuanto se ha vendido...
            consultacomprascorte()
            cgrillacorte.RowHeadersVisible = False
            consultarcorte()
            ' desglosecorte()
            '  consultarcortecalendario()

            Try
                ctxttotalescorte.Text = CDbl(ctxtextras.Text) - CDbl(ctxtcompras.Text)
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
            MsgBox("Aun no hay compras realizadas", MsgBoxStyle.Information, "Sistema")
            cbtncompras.Text = "$00.0"
            cerrarconexion()
        End Try


        Try

            conexionMysql.Open()

            Dim Sql2 As String
            Sql2 = "select sum(total)as total from venta where fecha='" & fecha & "';"
            Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            reader = cmd2.ExecuteReader
            reader.Read()
            cbtnextras.Text = "$" & reader.GetString(0).ToString()
            conexionMysql.Close()
            cerrarconexion()
            'conexionMysql.Open()
            'Dim Sql3 As String
            ' Sql3 = "select sum(recargas_venta)as suma1, sum(ciber) as suma from corte where fecha_registro='" & fecha & "';"
            'Dim cmd3 As New MySqlCommand(Sql3, conexionMysql)
            'reader = cmd3.ExecuteReader
            'reader.Read()

            'conexionMysql.Close()
        Catch ex As Exception
            MsgBox("Aun no hay ventas realizadas", MsgBoxStyle.Information, "Sistema")
            cbtnextras.Text = "$00.0"
        End Try


        Try

            'calculamos las operaciones para que de el final.
            cbttotales.Text = "$ " & CDbl(cbtnextras.Text) - CDbl(cbtncompras.Text)
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




            MsgBox("cargado cortes")
            conexionMysql.Open()
            Dim Sqlx1 As String
            Sqlx1 = "select corte.idcorte, corte.extras, corte.compra , corte.fecha_registro, corte.hora_registro, usuario.usuario from corte, usuario where corte.fecha_registro='" & fecha & "'  and corte.idusuario=usuario.idusuario;"
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
            ctxtextras.Text = reader.GetString(0).ToString
        Catch ex As Exception
            MsgBox("Aun no hay ventas.", MsgBoxStyle.Information, "Sistema")
            ctxtextras.Text = 0

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

        Dim tipo As Integer

        tipo = tipoingreso()


        If tipo = 2 Then

            TabControl1.SelectedIndex = 1
            Button1.BackColor = Color.DimGray
            Button2.BackColor = Color.FromArgb(64, 64, 64)
            Button3.BackColor = Color.FromArgb(64, 64, 64)
            Button4.BackColor = Color.FromArgb(64, 64, 64)
            Button5.BackColor = Color.FromArgb(64, 64, 64)
            Button6.BackColor = Color.FromArgb(64, 64, 64)
            Button8.BackColor = Color.FromArgb(64, 64, 64)
            Button10.BackColor = Color.FromArgb(64, 64, 64)
            Button12.BackColor = Color.FromArgb(64, 64, 64)
            Button13.BackColor = Color.FromArgb(64, 64, 64)
            Button67.BackColor = Color.FromArgb(64, 64, 64)


            comprobartipoingreso()
        Else


            TabControl1.SelectedIndex = 5
            'cargamos los usuario.
            ucargartipousuario()


            Button1.BackColor = Color.FromArgb(64, 64, 64)
            Button2.BackColor = Color.FromArgb(64, 64, 64)
            Button3.BackColor = Color.FromArgb(64, 64, 64)
            Button4.BackColor = Color.FromArgb(64, 64, 64)
            Button5.BackColor = Color.FromArgb(64, 64, 64)
            Button6.BackColor = Color.DimGray
            Button8.BackColor = Color.FromArgb(64, 64, 64)
            Button10.BackColor = Color.FromArgb(64, 64, 64)
            Button12.BackColor = Color.FromArgb(64, 64, 64)
            Button13.BackColor = Color.FromArgb(64, 64, 64)
            Button67.BackColor = Color.FromArgb(64, 64, 64)


        End If

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim tipo As Integer

        tipo = tipoingreso()


        If tipo = 2 Then

            TabControl1.SelectedIndex = 1
            Button1.BackColor = Color.DimGray
            Button2.BackColor = Color.FromArgb(64, 64, 64)
            Button3.BackColor = Color.FromArgb(64, 64, 64)
            Button4.BackColor = Color.FromArgb(64, 64, 64)
            Button5.BackColor = Color.FromArgb(64, 64, 64)
            Button6.BackColor = Color.FromArgb(64, 64, 64)
            Button8.BackColor = Color.FromArgb(64, 64, 64)
            Button10.BackColor = Color.FromArgb(64, 64, 64)
            Button12.BackColor = Color.FromArgb(64, 64, 64)
            Button13.BackColor = Color.FromArgb(64, 64, 64)
            Button67.BackColor = Color.FromArgb(64, 64, 64)


            comprobartipoingreso()
        Else


            TabControl1.SelectedIndex = 6

            Button1.BackColor = Color.FromArgb(64, 64, 64)
            Button2.BackColor = Color.FromArgb(64, 64, 64)
            Button3.BackColor = Color.FromArgb(64, 64, 64)
            Button4.BackColor = Color.FromArgb(64, 64, 64)
            Button5.BackColor = Color.FromArgb(64, 64, 64)
            Button6.BackColor = Color.FromArgb(64, 64, 64)
            Button8.BackColor = Color.DimGray
            Button10.BackColor = Color.FromArgb(64, 64, 64)
            Button12.BackColor = Color.FromArgb(64, 64, 64)
            Button13.BackColor = Color.FromArgb(64, 64, 64)
            Button67.BackColor = Color.FromArgb(64, 64, 64)


        End If

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click


        Dim tipo As Integer

        tipo = tipoingreso()


        If tipo = 2 Then


            TabControl1.SelectedIndex = 1
            Button1.BackColor = Color.DimGray
            Button2.BackColor = Color.FromArgb(64, 64, 64)
            Button3.BackColor = Color.FromArgb(64, 64, 64)
            Button4.BackColor = Color.FromArgb(64, 64, 64)
            Button5.BackColor = Color.FromArgb(64, 64, 64)
            Button6.BackColor = Color.FromArgb(64, 64, 64)
            Button8.BackColor = Color.FromArgb(64, 64, 64)
            Button10.BackColor = Color.FromArgb(64, 64, 64)
            Button12.BackColor = Color.FromArgb(64, 64, 64)
            Button13.BackColor = Color.FromArgb(64, 64, 64)
            Button67.BackColor = Color.FromArgb(64, 64, 64)


            comprobartipoingreso()
        Else
            TabControl1.SelectedIndex = 8

            Button1.BackColor = Color.FromArgb(64, 64, 64)
            Button2.BackColor = Color.FromArgb(64, 64, 64)
            Button3.BackColor = Color.FromArgb(64, 64, 64)
            Button4.BackColor = Color.FromArgb(64, 64, 64)
            Button5.BackColor = Color.FromArgb(64, 64, 64)
            Button6.BackColor = Color.FromArgb(64, 64, 64)
            Button8.BackColor = Color.FromArgb(64, 64, 64)
            Button10.BackColor = Color.DimGray
            Button12.BackColor = Color.FromArgb(64, 64, 64)
            Button13.BackColor = Color.FromArgb(64, 64, 64)
            Button67.BackColor = Color.FromArgb(64, 64, 64)


        End If


    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click

        Dim tipo As Integer

        tipo = tipoingreso()


        If tipo = 2 Then

            TabControl1.SelectedIndex = 1
            Button1.BackColor = Color.DimGray
            Button2.BackColor = Color.FromArgb(64, 64, 64)
            Button3.BackColor = Color.FromArgb(64, 64, 64)
            Button4.BackColor = Color.FromArgb(64, 64, 64)
            Button5.BackColor = Color.FromArgb(64, 64, 64)
            Button6.BackColor = Color.FromArgb(64, 64, 64)
            Button8.BackColor = Color.FromArgb(64, 64, 64)
            Button10.BackColor = Color.FromArgb(64, 64, 64)
            Button12.BackColor = Color.FromArgb(64, 64, 64)
            Button13.BackColor = Color.FromArgb(64, 64, 64)
            Button67.BackColor = Color.FromArgb(64, 64, 64)


            comprobartipoingreso()
        Else

            TabControl1.SelectedIndex = 9

            Button1.BackColor = Color.FromArgb(64, 64, 64)
            Button2.BackColor = Color.FromArgb(64, 64, 64)
            Button3.BackColor = Color.FromArgb(64, 64, 64)
            Button4.BackColor = Color.FromArgb(64, 64, 64)
            Button5.BackColor = Color.FromArgb(64, 64, 64)
            Button6.BackColor = Color.FromArgb(64, 64, 64)
            Button8.BackColor = Color.FromArgb(64, 64, 64)
            Button10.BackColor = Color.FromArgb(64, 64, 64)
            Button12.BackColor = Color.DimGray
            Button13.BackColor = Color.FromArgb(64, 64, 64)


        End If

        'cargamos los datos de la empresa para que se muestren, en caso de que exista un valor.
        cargardatos_empresa()



    End Sub

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
                claveproveedor = reader.GetString(6).ToString()
                clavetipoproducto = reader.GetString(7).ToString()

                reader.Close()


                'MsgBox("actividad:" & txtactividad.Text)

                'Catch ex As Exception
                'MsgBox("hay problemas", MsgBoxStyle.Exclamation)
                'End Try


                conexionMysql.Close()




                '   MsgBox(clavetipoproducto)

                If reader.HasRows Then
                    reader.Close()

                End If



                '-------------cargamos el proveedor del producto.

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

                Dim valortipopro As String



                'MsgBox("hahahahaha" & clavetipoproducto)

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

            sgrilla.Rows.Add(i, stxtnombre.Text, stxtcantidad.Text, stxtprecio.Text, stxttotalproducto.Text, stxtclave.Text, stxtdescripcion.Text)
            sgrilla.Columns(1).Width = 350


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

            grilla.Rows.Add(i, txtactividad.Text, txtcantidad.Text, txtcosto.Text, txttotal.Text, txtclave.Text)
            grilla.Columns(1).Width = 350


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
            cantidad = sgrilla.Rows(j).Cells(2).Value 'cantidad
            claveproducto = sgrilla.Rows(j).Cells(5).Value 'clave


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
        Dim suma, cantidad_productos As Double
        Dim a, b As String
        'suma de valores
        For j = 0 To i - 2
            'MsgBox("valosr de j:" & j)
            'a = venta.grillaventa.Item(j, 3).Value.ToString()
            a = sgrilla.Rows(j).Cells(4).Value
            b = sgrilla.Rows(j).Cells(2).Value
            cantidad_productos = cantidad_productos + b
            suma = suma + a
            'MsgBox(a)
        Next
        stxttotal.Text = suma
        stxttotalproductos.Text = cantidad_productos
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


    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        venta()
        ' RPT1.Show()

    End Sub
    Function venta()
        Try

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
                conexionMysql.Close()
                '--------------------------------------------------------------------------
                cerrarconexion()



                conexionMysql.Open()
                Dim Sql As String
                Sql = "INSERT INTO venta (idventa, cantidad, total, fecha, hora, idcliente, idusuario,tipoventa) VALUES (" & lbfolio.Text & "," & txtunidades.Text & ", " & CDbl(txttotalpagar.Text) & ", '" & fecha & "','" & hora & "', " & idcliente & ", " & idusuario & ",'1');"
                Dim cmd As New MySqlCommand(Sql, conexionMysql)
                cmd.ExecuteNonQuery()
                conexionMysql.Close()
                txtactividad.Text = ""
                txtcosto.Text = ""
                txtpagar = CDbl(txttotalpagar.Text)
                'txttotalpagar.Text = ""
                conexionMysql.Close()


                '------------------ FIN insertar reginstro en tabla venta ---------------------------------------


                '------------------ insertar reginstro en tabla ventaIND ---------------------------------------
                Dim i As Integer = grilla.RowCount
                Dim j As Integer
                Dim actividad As String
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
                    cerrarconexion()
                    conexionMysql.Open()

                    'MsgBox("el producto es:" & actividad)

                    Dim Sql2 As String
                    Sql2 = "INSERT INTO ventaind (actividad, cantidad, costo, idventa,idproducto) VALUES ('" & actividad & "'," & cantidad & "," & costo & "," & lbfolio.Text & ",'" & idproducto & "');"
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



                If chcalcularcambio.Checked = True Then

                    '-------------------NUEVO SISTEMA

                    frcambio.ShowDialog()
                    frcambio.txtpaga.Focus()


                Else

                    MsgBox("Venta realizada", MsgBoxStyle.Information, "Sistema")




                End If


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

                    cargardatosnotaventa()
                    imprimirnotaventa()

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


            End If

            '------------------ FIN insertar reginstro en tabla ventaIND ---------------------------------------
        Catch ex As Exception
            comprobartipoingreso()
            MsgBox(ex.Message)
        End Try

    End Function
    Dim txtetiqueta1, txtetiqueta2, txtetiqueta As String
    Private Sub imprimir()
        txtetiqueta1 = " prueba de impresión"
        txtetiqueta2 = " Nº : " & lbfolio.Text
        txtetiqueta = " De : " & "$" & txttotalpagar.Text &
        Chr(10) & " " & "12/12/!2"
        Try
            Dim PrintDialog1 As New PrintDialog
            PrintDialog1.Document = PrintDocument1
            PrintDialog1.PrinterSettings.PrinterName = "OneNote"
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
        Dim ticketnombre, ticketcoloniaciudad, tickettelefono, ticketgiro As String


        Try

            conexionMysql.Open()
            Dim Sql1 As String
            Sql1 = "select * from datos_empresa;"
            Dim cmd1 As New MySqlCommand(Sql1, conexionMysql)
            reader = cmd1.ExecuteReader()
            reader.Read()
            ticketnombre = reader.GetString(1).ToString()
            'ctxtcallenumero.Text = reader.GetString(2).ToString()
            ticketcoloniaciudad = reader.GetString(3).ToString()
            'ctxtcp.Text = reader.GetString(4).ToString()
            'ctxtestado.Text = reader.GetString(5).ToString()
            tickettelefono = reader.GetString(6).ToString()
            'ctxtwhatsapp.Text = reader.GetString(7).ToString()
            'ctxtcorreo.Text = reader.GetString(8).ToString()
            'ctxtfacebook.Text = reader.GetString(9).ToString()
            'ctxtsitio.Text = reader.GetString(10).ToString()
            'ctxtencargado.Text = reader.GetString(11).ToString()
            'ctxthorario.Text = reader.GetString(12).ToString()
            ticketgiro = reader.GetString(13).ToString()
            conexionMysql.Close()
        Catch ex As Exception
            MsgBox("pasa algo")
        End Try



        Try
            ' La fuente a usar
            Dim prFont As New Font("Arial", 15, FontStyle.Bold)
            ' la posición superior


            'imprimir el titutlo del ticket
            prFont = New Font("Arial", 24, FontStyle.Bold)
            e.Graphics.DrawString(ticketnombre, prFont, Brushes.Black, 0, 20)
            prFont = New Font("Arial", 14, FontStyle.Bold)
            e.Graphics.DrawString(ticketgiro, prFont, Brushes.Black, 0, 50)


            'imprimir el titutlo del ticket
            prFont = New Font("Arial", 14, FontStyle.Bold)
            e.Graphics.DrawString(ticketcoloniaciudad, prFont, Brushes.Black, 0, 70)
            'imprimir el titutlo del ticket
            prFont = New Font("Arial", 14, FontStyle.Bold)
            e.Graphics.DrawString(tickettelefono, prFont, Brushes.Black, 60, 90)


            prFont = New Font("Arial", 14, FontStyle.Bold)
            e.Graphics.DrawString("---------------------------------", prFont, Brushes.Black, 0, 110)

            prFont = New Font("Arial", 14, FontStyle.Bold)
            e.Graphics.DrawString("USUARIO:" & usuarioactual, prFont, Brushes.Black, 0, 130)

            'imprimir el titutlo del ticket
            prFont = New Font("Arial", 14, FontStyle.Bold)
            e.Graphics.DrawString("CLIENTE:" & txtcliente.Text, prFont, Brushes.Black, 0, 160)
            prFont = New Font("Arial", 14, FontStyle.Bold)
            e.Graphics.DrawString("FECHA:" & Date.Now, prFont, Brushes.Black, 0, 190)
            prFont = New Font("Arial", 30, FontStyle.Bold)
            e.Graphics.DrawString("FOLIO:" & lbfolio.Text, prFont, Brushes.Black, 40, 220)
            prFont = New Font("Arial", 14, FontStyle.Bold)
            e.Graphics.DrawString("---------------------------------", prFont, Brushes.Black, 0, 250)

            'imprimir el titutlo del ticket

            prFont = New Font("Arial", 10, FontStyle.Bold)
            e.Graphics.DrawString("ARTICULO", prFont, Brushes.Black, 0, 270)
            prFont = New Font("Arial", 10, FontStyle.Bold)
            e.Graphics.DrawString("ID-- PRECIO--CANTIDAD--TOTAL", prFont, Brushes.Black, 0, 285)

            prFont = New Font("Arial", 10, FontStyle.Bold)
            e.Graphics.DrawString("---------------------------------", prFont, Brushes.Black, 0, 300)



            'aqui es donde tenemos que leer todos los datos de la grilla llamada "grilla"

            Dim i As Integer = grilla.RowCount
            Dim t1, t2, t3, t4, t5 As Integer
            Dim actividad As String
            Dim cantidad, costo, idventa As Double
            Dim idproducto As String

            t1 = 315
            t2 = 330
            t3 = 345
            t4 = 360

            'suma de valores
            For j = 0 To i - 2
                'MsgBox("valosr de j:" & j)
                'a = venta.grillaventa.Item(j, 3).Value.ToString()
                actividad = grilla.Rows(j).Cells(1).Value 'descripcion
                cantidad = grilla.Rows(j).Cells(2).Value 'cantidad
                costo = grilla.Rows(j).Cells(3).Value 'costo
                idproducto = grilla.Rows(j).Cells(5).Value
                'cerrarconexion()
                'conexionMysql.Open()

                'MsgBox("el producto es:" & actividad)

                'Dim Sql2 As String
                'Sql2 = "INSERT INTO ventaind (actividad, cantidad, costo, idventa,idproducto) VALUES ('" & actividad & "'," & cantidad & "," & costo & "," & lbfolio.Text & ",'" & idproducto & "');"
                'Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
                'cmd2.ExecuteNonQuery()
                'conexionMysql.Close()

                prFont = New Font("Arial", 10, FontStyle.Bold)
                e.Graphics.DrawString(actividad, prFont, Brushes.Black, 0, t1)

                prFont = New Font("Arial", 10, FontStyle.Bold)
                e.Graphics.DrawString(idproducto & "-- $" & costo & "--" & cantidad & "-- $" & (CDbl(costo) * CDbl(cantidad)), prFont, Brushes.Black, 0, t2)


                'prFont = New Font("Arial", 10, FontStyle.Bold)
                'e.Graphics.DrawString(cantidad & "-- $" & (CDbl(costo) * CDbl(cantidad)), prFont, Brushes.Black, 0, t3)

                t1 = t1 + 40
                t2 = t2 + 40
            Next
            prFont = New Font("Arial", 10, FontStyle.Bold)
            e.Graphics.DrawString("---------------------------------", prFont, Brushes.Black, 0, t2 - 20)

            '----------------AQUI SE IMPRIME EL TOTAL A PAGAR

            prFont = New Font("Arial", 10, FontStyle.Bold)
            e.Graphics.DrawString("TOTAL A PAGAR:----- $" & txttotalpagar.Text, prFont, Brushes.Black, 0, t2 - 10)


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

    Function imprimirnotaventa()
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


        'FRNOTAVENTA.ReportViewer1.LocalReport.DataSources.Item(0).Value = dt

        FRNOTAVENTA.ShowDialog()

        FRNOTAVENTA.Dispose()

    End Function
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

    Private Sub txtclave_TextChanged(sender As Object, e As EventArgs) Handles txtclave.TextChanged
        If txtclave.Text = "" Then
            borrar()
        Else

            buscarid()

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
                '   MsgBox("solo esta activa la de anexar directo")
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
                'MsgBox("estan activadas las dos casillas.")
                'no hace nada.
                'solo mandamos a llamar a la ventana de cantidad.
                '-----------------------NUEVO SISTEMA
                frcantidad.ShowDialog()


                '  MsgBox("anexando")


            End If






        Catch ex As Exception

        End Try

    End Sub

    Private Sub grilla2_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grilla2.CellDoubleClick
        Try

            Dim Variable As String = grilla2.Item(0, grilla2.CurrentRow.Index).Value
            'MsgBox(Variable)
            txtclave.Text = Variable
            grilla2.Visible = False
            grilla.Visible = True
            rbclave.Checked = True

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
            grillap.Columns(1).Width = 350
            grillap.Columns(0).Width = 60
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

            MsgBox("TIPO" & tipo)
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
                    Sqlu = "CREATE USER '" & utxtusuario.Text & "'@'localhost' IDENTIFIED BY '" & utxtpass.Text & "';"
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
                    Sqlu1 = "GRANT ALL PRIVILEGES ON * . * TO '" & utxtusuario.Text & "'@'localhost' WITH GRANT OPTION;"
                    Dim cmdu1 As New MySqlCommand(Sqlu1, conexionMysql)
                    cmdu1.ExecuteNonQuery()
                    conexionMysql.Close()
                    MsgBox("Se ha creado un usuario Administrador", MsgBoxStyle.Information, "Sistema")
                    'llamar a la funcion limpiar, para limpiar las cajas cada vez que se agrege una nueva compra.
                ElseIf tipousuario = 2 Then
                    cerrarconexion()

                    conexionMysql.Open()
                    Dim Sqlu1 As String
                    Sqlu1 = "GRANT select,insert,update ON dwin.venta TO '" & utxtusuario.Text & "'@'localhost';"
                    Dim cmdu1 As New MySqlCommand(Sqlu1, conexionMysql)
                    cmdu1.ExecuteNonQuery()
                    conexionMysql.Close()


                    conexionMysql.Open()
                    Dim Sqlu25 As String
                    Sqlu25 = "FLUSH PRIVILEGES;"
                    Dim cmdu25 As New MySqlCommand(Sqlu25, conexionMysql)
                    cmdu25.ExecuteNonQuery()
                    conexionMysql.Close()

                    conexionMysql.Open()
                    Dim Sqlu26 As String
                    Sqlu26 = "GRANT select,insert ON dwin.compramercancia TO '" & utxtusuario.Text & "'@'localhost';"
                    Dim cmdu26 As New MySqlCommand(Sqlu26, conexionMysql)
                    cmdu26.ExecuteNonQuery()
                    conexionMysql.Close()


                    conexionMysql.Open()
                    Dim Sqlu27 As String
                    Sqlu27 = "FLUSH PRIVILEGES;"
                    Dim cmdu27 As New MySqlCommand(Sqlu27, conexionMysql)
                    cmdu27.ExecuteNonQuery()
                    conexionMysql.Close()

                    '--------------------------------------
                    conexionMysql.Open()
                    Dim Sqlu262 As String
                    Sqlu262 = "GRANT select,insert ON dwin.ventaind TO '" & utxtusuario.Text & "'@'localhost';"
                    Dim cmdu262 As New MySqlCommand(Sqlu262, conexionMysql)
                    cmdu262.ExecuteNonQuery()
                    conexionMysql.Close()


                    conexionMysql.Open()
                    Dim Sqlu272 As String
                    Sqlu272 = "FLUSH PRIVILEGES;"
                    Dim cmdu272 As New MySqlCommand(Sqlu272, conexionMysql)
                    cmdu272.ExecuteNonQuery()
                    conexionMysql.Close()
                    '--------------------------------------------
                    conexionMysql.Open()
                    Dim Sqlu263 As String
                    Sqlu263 = "GRANT select,insert ON dwin.venta TO '" & utxtusuario.Text & "'@'localhost';"
                    Dim cmdu263 As New MySqlCommand(Sqlu263, conexionMysql)
                    cmdu263.ExecuteNonQuery()
                    conexionMysql.Close()


                    conexionMysql.Open()
                    Dim Sqlu274 As String
                    Sqlu274 = "FLUSH PRIVILEGES;"
                    Dim cmdu274 As New MySqlCommand(Sqlu274, conexionMysql)
                    cmdu274.ExecuteNonQuery()
                    conexionMysql.Close()
                    '--------------------------------------------
                    conexionMysql.Open()
                    Dim Sqlu265 As String
                    Sqlu265 = "GRANT select ON dwin.cliente TO '" & utxtusuario.Text & "'@'localhost';"
                    Dim cmdu265 As New MySqlCommand(Sqlu265, conexionMysql)
                    cmdu265.ExecuteNonQuery()
                    conexionMysql.Close()


                    conexionMysql.Open()
                    Dim Sqlu276 As String
                    Sqlu276 = "FLUSH PRIVILEGES;"
                    Dim cmdu276 As New MySqlCommand(Sqlu276, conexionMysql)
                    cmdu276.ExecuteNonQuery()
                    conexionMysql.Close()

                    '--------------------------------------------
                    conexionMysql.Open()
                    Dim Sqlu266 As String
                    Sqlu266 = "GRANT select ON dwin.usuario TO '" & utxtusuario.Text & "'@'localhost';"
                    Dim cmdu266 As New MySqlCommand(Sqlu266, conexionMysql)
                    cmdu266.ExecuteNonQuery()
                    conexionMysql.Close()


                    conexionMysql.Open()
                    Dim Sqlu277 As String
                    Sqlu277 = "FLUSH PRIVILEGES;"
                    Dim cmdu277 As New MySqlCommand(Sqlu277, conexionMysql)
                    cmdu277.ExecuteNonQuery()
                    conexionMysql.Close()

                    '--------------------------------------------
                    conexionMysql.Open()
                    Dim Sqlu268 As String
                    Sqlu268 = "GRANT select ON dwin.producto TO '" & utxtusuario.Text & "'@'localhost';"
                    Dim cmdu268 As New MySqlCommand(Sqlu268, conexionMysql)
                    cmdu268.ExecuteNonQuery()
                    conexionMysql.Close()


                    conexionMysql.Open()
                    Dim Sqlu279 As String
                    Sqlu279 = "FLUSH PRIVILEGES;"
                    Dim cmdu279 As New MySqlCommand(Sqlu279, conexionMysql)
                    cmdu279.ExecuteNonQuery()
                    conexionMysql.Close()

                    '--------------------------------------------
                    conexionMysql.Open()
                    Dim Sqlu281 As String
                    Sqlu281 = "GRANT update(cantidad) ON dwin.producto TO '" & utxtusuario.Text & "'@'localhost';"
                    Dim cmdu281 As New MySqlCommand(Sqlu281, conexionMysql)
                    cmdu281.ExecuteNonQuery()
                    conexionMysql.Close()


                    conexionMysql.Open()
                    Dim Sqlu282 As String
                    Sqlu282 = "FLUSH PRIVILEGES;"
                    Dim cmdu282 As New MySqlCommand(Sqlu282, conexionMysql)
                    cmdu282.ExecuteNonQuery()
                    conexionMysql.Close()


                    '--------------------------------------------
                    conexionMysql.Open()
                    Dim Sqlu283 As String
                    Sqlu283 = "GRANT select ON dwin.proveedor TO '" & utxtusuario.Text & "'@'localhost';"
                    Dim cmdu283 As New MySqlCommand(Sqlu283, conexionMysql)
                    cmdu283.ExecuteNonQuery()
                    conexionMysql.Close()


                    conexionMysql.Open()
                    Dim Sqlu284 As String
                    Sqlu284 = "FLUSH PRIVILEGES;"
                    Dim cmdu284 As New MySqlCommand(Sqlu284, conexionMysql)
                    cmdu284.ExecuteNonQuery()
                    conexionMysql.Close()
                    '--------------------------------------------
                    conexionMysql.Open()
                    Dim Sqlu285 As String
                    Sqlu285 = "GRANT select ON dwin.tipoproducto TO '" & utxtusuario.Text & "'@'localhost';"
                    Dim cmdu285 As New MySqlCommand(Sqlu285, conexionMysql)
                    cmdu285.ExecuteNonQuery()
                    conexionMysql.Close()


                    conexionMysql.Open()
                    Dim Sqlu286 As String
                    Sqlu286 = "FLUSH PRIVILEGES;"
                    Dim cmdu286 As New MySqlCommand(Sqlu286, conexionMysql)
                    cmdu286.ExecuteNonQuery()
                    conexionMysql.Close()

                    '--------------------------------------------
                    conexionMysql.Open()
                    Dim Sqlu287 As String
                    Sqlu287 = "GRANT select ON dwin.corte TO '" & utxtusuario.Text & "'@'localhost';"
                    Dim cmdu287 As New MySqlCommand(Sqlu287, conexionMysql)
                    cmdu287.ExecuteNonQuery()
                    conexionMysql.Close()


                    conexionMysql.Open()
                    Dim Sqlu288 As String
                    Sqlu288 = "FLUSH PRIVILEGES;"
                    Dim cmdu288 As New MySqlCommand(Sqlu288, conexionMysql)
                    cmdu288.ExecuteNonQuery()
                    conexionMysql.Close()
                    '--------------------------------------------
                    conexionMysql.Open()
                    Dim Sqlu289 As String
                    Sqlu289 = "GRANT insert ON dwin.corte TO '" & utxtusuario.Text & "'@'localhost';"
                    Dim cmdu289 As New MySqlCommand(Sqlu289, conexionMysql)
                    cmdu289.ExecuteNonQuery()
                    conexionMysql.Close()


                    conexionMysql.Open()
                    Dim Sqlu290 As String
                    Sqlu290 = "FLUSH PRIVILEGES;"
                    Dim cmdu290 As New MySqlCommand(Sqlu290, conexionMysql)
                    cmdu290.ExecuteNonQuery()
                    conexionMysql.Close()
                    '--------------------------------------------
                    conexionMysql.Open()
                    Dim Sqlu291 As String
                    Sqlu291 = "GRANT select ON dwin.tipo_usuario TO '" & utxtusuario.Text & "'@'localhost';"
                    Dim cmdu291 As New MySqlCommand(Sqlu291, conexionMysql)
                    cmdu291.ExecuteNonQuery()
                    conexionMysql.Close()


                    conexionMysql.Open()
                    Dim Sqlu292 As String
                    Sqlu292 = "FLUSH PRIVILEGES;"
                    Dim cmdu292 As New MySqlCommand(Sqlu292, conexionMysql)
                    cmdu292.ExecuteNonQuery()
                    conexionMysql.Close()
                    'conexionMysql.Open()
                    'Dim Sqlux1 As String
                    'Sqlux1 = "GRANT select,insert,producto ON dwin.ventaind  TO '" & utxtusuario.Text & "'@'localhost';"
                    'Dim cmdux1 As New MySqlCommand(Sqlux1, conexionMysql)
                    'cmdux1.ExecuteNonQuery()
                    'conexionMysql.Close()

                    'conexionMysql.Open()
                    'Dim Sqlux4 As String
                    'Sqlux4 = "GRANT select,insert,producto ON dwin.ventaind  TO '" & utxtusuario.Text & "'@'localhost';"
                    'Dim cmdux4 As New MySqlCommand(Sqlux4, conexionMysql)
                    'cmdux4.ExecuteNonQuery()
                    'conexionMysql.Close()

                    conexionMysql.Open()
                    Dim Sqlux3 As String
                    Sqlux3 = "GRANT select,update,insert ON dwin.producto  TO '" & utxtusuario.Text & "'@'localhost';"
                    Dim cmdux3 As New MySqlCommand(Sqlux3, conexionMysql)
                    cmdux3.ExecuteNonQuery()
                    conexionMysql.Close()

                    conexionMysql.Open()
                    Dim Sqlu22 As String
                    Sqlu22 = "FLUSH PRIVILEGES;"
                    Dim cmdu22 As New MySqlCommand(Sqlu22, conexionMysql)
                    cmdu22.ExecuteNonQuery()
                    conexionMysql.Close()


                    conexionMysql.Open()
                    Dim Sqlux31 As String
                    Sqlux31 = "GRANT select ON dwin.datos_empresa  TO '" & utxtusuario.Text & "'@'localhost';"
                    Dim cmdux31 As New MySqlCommand(Sqlux31, conexionMysql)
                    cmdux31.ExecuteNonQuery()
                    conexionMysql.Close()

                    conexionMysql.Open()
                    Dim Sqlu222 As String
                    Sqlu222 = "FLUSH PRIVILEGES;"
                    Dim cmdu222 As New MySqlCommand(Sqlu222, conexionMysql)
                    cmdu222.ExecuteNonQuery()
                    conexionMysql.Close()


                    conexionMysql.Open()
                    Dim Sqlux5 As String
                    Sqlux5 = "GRANT ALL PRIVILEGES ON dwin.compra TO '" & utxtusuario.Text & "'@'localhost';"
                    Dim cmdux5 As New MySqlCommand(Sqlux5, conexionMysql)
                    cmdux5.ExecuteNonQuery()
                    conexionMysql.Close()
                    conexionMysql.Open()
                    Dim Sqlu23 As String
                    Sqlu23 = "FLUSH PRIVILEGES;"
                    Dim cmdu23 As New MySqlCommand(Sqlu23, conexionMysql)
                    cmdu23.ExecuteNonQuery()
                    conexionMysql.Close()

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
        Dim utipo_usuario As Integer

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




                    Dim idusuario As Integer
                    cerrarconexion()
                    conexionMysql.Open()
                    Dim Sql1 As String
                    Sql1 = "select idusuario from usuario where usuario='" & utxtusuario.Text & "';"
                    Dim cmd1 As New MySqlCommand(Sql1, conexionMysql)
                    reader = cmd1.ExecuteReader
                    reader.Read()
                    idusuario = reader.GetString(0).ToString
                    conexionMysql.Close()
                    cerrarconexion()



                    'MsgBox(idusuario)
                    cerrarconexion()
                    conexionMysql.Open()
                    Dim Sql As String
                    Sql = "delete from corte where idusuario=" & idusuario & ";"
                    Dim cmd As New MySqlCommand(Sql, conexionMysql)
                    cmd.ExecuteNonQuery()
                    conexionMysql.Close()

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
        Sql2 = "drop user '" & utxtusuario.Text & "'@'localhost';"
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
                    Sql = "insert into cliente (nombre,ap,am,edad,direccion,telefono,correo) values('" & ctxtnombre.Text & "','" & ctxtap.Text & "','" & ctxtam.Text & "'," & ctxtedad.Text & ",'" & ctxtdireccion.Text & "','" & ctxttelefono.Text & "','" & ctxtcorreo.Text & "');"
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
        cllenadocliente()

    End Sub
    Function cllenadocliente()
        grillacliente.DefaultCellStyle.Font = New Font("Arial", 20)
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
            ctxtedad.Text = reader.GetString(4).ToString()
            ctxtdireccion.Text = reader.GetString(5).ToString()
            ctxttelefono.Text = reader.GetString(6).ToString()
            ctxtcorreo.Text = reader.GetString(7).ToString()


            conexionMysql.Close()

        Catch ex As Exception
            cerrarconexion()
        End Try


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

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
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
                sql2 = "update cliente set nombre='" & ctxtnombre.Text & "', ap='" & ctxtap.Text & "', am='" & ctxtam.Text & "', edad=" & ctxtedad.Text & ", direccion='" & ctxtdireccion.Text & "', telefono='" & ctxttelefono.Text & "', correo='" & ctxtcorreo.Text & "' where idcliente=" & ctxtidcliente.Text & ";"
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
        Dim tipo As Integer

        tipo = tipoingreso()


        If tipo = 2 Then

            TabControl1.SelectedIndex = 1
            Button1.BackColor = Color.DimGray
            Button2.BackColor = Color.FromArgb(64, 64, 64)
            Button3.BackColor = Color.FromArgb(64, 64, 64)
            Button4.BackColor = Color.FromArgb(64, 64, 64)
            Button5.BackColor = Color.FromArgb(64, 64, 64)
            Button6.BackColor = Color.FromArgb(64, 64, 64)
            Button8.BackColor = Color.FromArgb(64, 64, 64)
            Button10.BackColor = Color.FromArgb(64, 64, 64)
            Button12.BackColor = Color.FromArgb(64, 64, 64)
            Button13.BackColor = Color.FromArgb(64, 64, 64)
            Button67.BackColor = Color.FromArgb(64, 64, 64)


            comprobartipoingreso()
        Else


            TabControl1.SelectedIndex = 7

            Button1.BackColor = Color.FromArgb(64, 64, 64)
            Button2.BackColor = Color.FromArgb(64, 64, 64)
            Button3.BackColor = Color.FromArgb(64, 64, 64)
            Button4.BackColor = Color.FromArgb(64, 64, 64)
            Button5.BackColor = Color.FromArgb(64, 64, 64)
            Button6.BackColor = Color.FromArgb(64, 64, 64)
            Button8.BackColor = Color.FromArgb(64, 64, 64)
            Button10.BackColor = Color.FromArgb(64, 64, 64)
            Button12.BackColor = Color.FromArgb(64, 64, 64)
            Button13.BackColor = Color.DimGray
            Button67.BackColor = Color.FromArgb(64, 64, 64)

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


        'Try


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

        If ctxtextras.Text = "" Or ctxttotalescorte.Text = "" Then
            MsgBox("Existen campos vacios", MsgBoxStyle.Information, "Sistema")

        Else




            cerrarconexion()


            'If ctxtextras.Text = 0 Or ctxtcompras.Text = 0 Or ctxttotalescorte.Text Then
            'MsgBox("No es posible hacer un corte con Cero ventas")
            'Else




            conexionMysql.Open()

                Dim Sql As String
                Sql = "INSERT INTO corte (`extras`, `fecha_registro`, `hora_registro`,`idusuario`,`compra` ) VALUES ('" & ctxtextras.Text & "', '" & fecha & "', '" & hora & "'," & idusuario & "," & ctxtcompras.Text & ");"
                Dim cmd As New MySqlCommand(Sql, conexionMysql)
                cmd.ExecuteNonQuery()

                MsgBox("Registro Guardado", MsgBoxStyle.Information, "Sistema")
                'pass.Text = nombre
                ' desglosecorte()
                consultarcortecalendario()
                conexionMysql.Close()

                borrarcorte()
            ' consultarcorte()

            'Dim respuesta As String
            'respuesta = MsgBox("¿Desea realizar la impresion de su corte de caja del día?", MsgBoxStyle.YesNo & MsgBoxStyle.Information, "Sistema")

            'End If


        End If


        'main.Show()



        '------------------ FIN insertar reginstro en tabla venta ---------------------------------------


        '------------------ insertar reginstro en tabla ventaIND ---------------------------------------




        '------------------ FIN insertar reginstro en tabla ventaIND ---------------------------------------

        'Catch ex As Exception
        '   MsgBox("No se guardaron los registos", MsgBoxStyle.Exclamation, "Sistema")

        'End Try
    End Sub
    Function borrarcorte()
        ctxtextras.Text = ""
        ctxttotalescorte.Text = ""
        ctxtcompras.Text = ""


    End Function

    Private Sub Button34_Click(sender As Object, e As EventArgs) Handles Button34.Click
        'se consulta cuanto se ha vendido...
        consultacomprascorte()
        cgrillacorte.RowHeadersVisible = False
        consultarcorte()
        ' desglosecorte()
        consultarcortecalendario()

        Try
            ctxttotalescorte.Text = (CDbl(ctxtextras.Text)) - CDbl(ctxtcompras.Text)
        Catch ex As Exception

        End Try

    End Sub
    Function consultacomprascorte()


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
        Sql = "select sum(total)  from compra where fecha='" & fecha & "' and hora between '" & horafin & "' and '" & hora & "';"
        Dim cmd As New MySqlCommand(Sql, conexionMysql)
        reader = cmd.ExecuteReader()
        reader.Read()
        Try
            ctxtcompras.Text = reader.GetString(0).ToString
        Catch ex As Exception
            MsgBox("Aun no hay compras", MsgBoxStyle.Information, "Sistema")
            ctxtcompras.Text = 0

            'si aun no hay ventas, intentamos cargar los cortes de caja que se han hecho.

            '-----------------------------------------------------------------------------------
            'cargamos una funcion que manda a la grilla todos los cortes de caja que se han realizado.




        End Try


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

    Private Sub ctxtextras_MouseClick(sender As Object, e As MouseEventArgs) Handles ctxtextras.MouseClick
        'consultamos el corte y todo lo vendido de tal fecha. al igual que lo cargue en la grilla.

        consultacortecalendario()

    End Sub

    Private Sub cbtnextras_Click(sender As Object, e As EventArgs) Handles cbtnextras.Click

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
        Sql = "select venta.idventa, ventaind.idventaind, ventaind.actividad, ventaind.cantidad, ventaind.costo,(ventaind.cantidad * ventaind.costo) as Total, ventaind.idproducto, venta.hora from ventaind, venta where ventaind.idventa = venta.idventa and fecha='" & fechacompleta & "';"
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
        Me.Size = New System.Drawing.Size(1400, 900)


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

    Private Sub Button34_ClientSizeChanged(sender As Object, e As EventArgs) Handles Button34.ClientSizeChanged

    End Sub


    Private Sub cbtncompras_Click(sender As Object, e As EventArgs) Handles cbtncompras.Click
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
                comando = pathmysql & "\bin\mysqldump --user=root --password=conexion --databases dwin --routines -r """ & respaldar.FileName & """"
                Shell(comando, AppWinStyle.MinimizedFocus, True)
                MsgBox("Se realizo el respaldo correctamente", MsgBoxStyle.Information, "Sistema")
            Catch ex As Exception
                MsgBox("Ocurrio un error al respaldar", MsgBoxStyle.Critical, "Informacion")
            End Try

        End If

    End Sub

    Private Sub cbttotales_Click(sender As Object, e As EventArgs) Handles cbttotales.Click

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
        If cbproveedorcompras.Text = "" Or ctxtid.Text = "" Or ctxtdescripcion.Text = "" Or ctxtcantidadproductos.Text = "" Or ctxtcostomercancia.Text = "" Or ctxtpreciopublico.Text = "" Or ctxtcostototalmercancia.Text = "" Or txtpreciopaquete.Text = "" Or txtcantidadpaquete.Text = "" Then

            MsgBox("No hay productos que agregar", MsgBoxStyle.Information, "Sistema")

        Else


            'obtengo el id del proveedor, para poder agregarlo


            Dim i As Integer = ccgrilla.RowCount

            ccgrilla.Rows.Add(ctxtid.Text, ctxtdescripcion.Text, ctxtcantidadproductos.Text, ctxtcostomercancia.Text, ctxtpreciopublico.Text, ctxtcostototalmercancia.Text, cbproveedorcompras.Text, txtpreciopaquete.Text, txtcantidadpaquete.Text)
            ccgrilla.Columns(1).Width = 350

            'se hace la operacion de sumar todos los valores de la grilla
            sumatoriocompra()
            'se borran los productos de las cajas de texto
            limpiarcompramercancia()

            ctxtid.Focus()
        End If
    End Function
    Function sumatoriocompra()
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
        ctxtcomprado.Text = suma
        'txtunidades.Text = cantidad_productos
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
                    preciopaquete = ccgrilla.Rows(C1j).Cells(7).Value
                    cantidadpaquete = ccgrilla.Rows(C1j).Cells(8).Value


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
                    Sql22 = "INSERT INTO `dwin`.`compramercancia` (`idcompra`, `idproducto`, `costo`, `cantidad`, `fecha`, `hora`, `costo_paquete`, `cantidad_paquete`) VALUES (" & btnidcompramercancia.Text & ", '" & c1idcompra & "', " & C1costo & ", " & C1cantidad & ", '" & fecha & "', '" & hora & "'," & preciopaquete & "," & cantidadpaquete & ");"
                    Dim cmd22 As New MySqlCommand(Sql22, conexionMysql)
                    cmd22.ExecuteNonQuery()
                    conexionMysql.Close()
                Next
                MsgBox("Transferencia completa", MsgBoxStyle.Information, "Sistema")


                If chimpresioncompra.Checked = True Then


                End If


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

    Private Sub Button45_Click(sender As Object, e As EventArgs) Handles Button45.Click
        Try



            cargardatosrptcortedia()
            imprimircortedia()

            ' Dim formventas As New frventas
            ' formventas.Show()
        Catch ex As Exception
            MsgBox("Existe un problema al generar el reporte", MsgBoxStyle.Exclamation, "Sistema")
        End Try


    End Sub

    Private Sub Button44_Click(sender As Object, e As EventArgs) Handles Button44.Click
        Dim fecha As Date
        fecha = calendario.SelectionRange.Start.ToString("yyyy/MM/dd")
        '  Frcortes.Show()

    End Sub

    Private Sub Button46_Click(sender As Object, e As EventArgs) Handles Button46.Click
        'FRproductos.Show()

    End Sub

    Private Sub Button49_Click_1(sender As Object, e As EventArgs) Handles Button49.Click

        If rptid.Text = "" Then
            MsgBox("Ingresa un ID valido", MsgBoxStyle.Exclamation, "Sistema")
        Else

            cargardatosnotaventa2()
            imprimirnotaventa2()

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
        Try
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

            Dim Sql2 As String
            Sql2 = "delete from venta where idventa=" & txtventaeliminar.Text & ";"
            Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            cmd2.ExecuteNonQuery()
            conexionMysql.Close()
            MsgBox("Venta eliminada", MsgBoxStyle.Information, "Sistema")

            txtventaeliminar.Text = ""




        Catch ex As Exception
            cerrarconexion()
            comprobartipoingreso()
        End Try

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

    Private Sub GroupBox19_Enter(sender As Object, e As EventArgs) Handles GroupBox19.Enter

    End Sub

    Private Sub txtcompraeliminar_TextChanged(sender As Object, e As EventArgs) Handles txtcompraeliminar.TextChanged

    End Sub

    Private Sub Label73_Click(sender As Object, e As EventArgs) Handles Label73.Click

    End Sub

    Private Sub GroupBox22_Enter(sender As Object, e As EventArgs) Handles GroupBox22.Enter

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

    Private Sub Label44_Click(sender As Object, e As EventArgs) Handles Label44.Click

    End Sub

    Private Sub GroupBox11_Enter(sender As Object, e As EventArgs) Handles GroupBox11.Enter

    End Sub

    Private Sub GroupBox12_Enter(sender As Object, e As EventArgs) Handles GroupBox12.Enter

    End Sub

    Private Sub cgrillacorte_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles cgrillacorte.CellContentClick

    End Sub

    Private Sub GroupBox14_Enter(sender As Object, e As EventArgs) Handles GroupBox14.Enter

    End Sub

    Private Sub Button43_Click(sender As Object, e As EventArgs) Handles Button43.Click

    End Sub

    Private Sub GroupBox16_Enter(sender As Object, e As EventArgs) Handles GroupBox16.Enter

    End Sub

    Private Sub TabPage5_Click(sender As Object, e As EventArgs) Handles TabPage5.Click

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

    End Sub

    Private Sub Label46_Click(sender As Object, e As EventArgs) Handles Label46.Click

    End Sub

    Private Sub ctxttotalescorte_TextChanged(sender As Object, e As EventArgs) Handles ctxttotalescorte.TextChanged

    End Sub

    Private Sub Label47_Click(sender As Object, e As EventArgs) Handles Label47.Click

    End Sub

    Private Sub ctxtcompras_TextChanged(sender As Object, e As EventArgs) Handles ctxtcompras.TextChanged

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

    Private Sub ctxtextras_TextChanged(sender As Object, e As EventArgs) Handles ctxtextras.TextChanged

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

    End Sub

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

    Private Sub txtcantidadpaquete_TextChanged(sender As Object, e As EventArgs) Handles txtcantidadpaquete.TextChanged

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

    Private Sub Label74_Click(sender As Object, e As EventArgs) Handles Label74.Click

    End Sub

    Private Sub txtpreciopaquete_TextChanged(sender As Object, e As EventArgs) Handles txtpreciopaquete.TextChanged

    End Sub

    Private Sub Label75_Click(sender As Object, e As EventArgs) Handles Label75.Click

    End Sub

    Private Sub Label76_Click(sender As Object, e As EventArgs) Handles Label76.Click

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

    Private Sub btventas_Click(sender As Object, e As EventArgs) Handles btventas.Click

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
            MsgBox("Se ha generado un error", MsgBoxStyle.Information, "Sistema")
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

        Catch ex As Exception

        End Try





    End Sub

    Private Sub Button25_Click_1(sender As Object, e As EventArgs) Handles Button25.Click

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


            Try
                cerrarconexion()
                conexionMysql.Open()

                Dim Sql As String
                Sql = "INSERT INTO compra (actividad, cantidad, costo, total, fecha, hora) VALUES ('" & ctxtactividad.Text & "', " & ctxtcantidad.Text & ", " & ctxtcosto.Text & ", " & ctxttotal.Text & ", '" & fecha & "','" & hora & "');"
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
    End Sub

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

    Private Sub txtpreciopaquete_KeyDown(sender As Object, e As KeyEventArgs) Handles txtpreciopaquete.KeyDown
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

            Dim Sql As String
            Sql = "TRUNCATE table producto;"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            cmd.ExecuteNonQuery()
            conexionMysql.Close()


        Else

        End If
    End Sub

    Private Sub Button66_Click(sender As Object, e As EventArgs)
        cargardatosnotaventa()
        imprimirnotaventa()
    End Sub

    Private Sub Button66_Click_1(sender As Object, e As EventArgs) Handles Button66.Click
        Dim formulario As New print
        formulario.ShowDialog()

    End Sub

    Private Sub Button67_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub stxtclave_TextChanged(sender As Object, e As EventArgs) Handles stxtclave.TextChanged
        sgrilla2.Visible = False


        Try

            listaservicios.Visible = False
            If stxtclave.Text = "" Then

                sborrar()



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


    Private Sub txtcantidadpaquete_KeyDown(sender As Object, e As KeyEventArgs) Handles txtcantidadpaquete.KeyDown
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
        Catch ex As Exception

            stxttotalproducto.Text = ""


        End Try

    End Sub

    Private Sub Button69_Click(sender As Object, e As EventArgs) Handles Button69.Click
        sagregarproductogrilla()

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

        End If
    End Sub

    Private Sub Button67_Click_1(sender As Object, e As EventArgs) Handles Button67.Click

        Dim tipo As Integer

        tipo = tipoingreso()


        If tipo = 2 Then

            TabControl1.SelectedIndex = 1
            Button1.BackColor = Color.DimGray
            Button2.BackColor = Color.FromArgb(64, 64, 64)
            Button3.BackColor = Color.FromArgb(64, 64, 64)
            Button4.BackColor = Color.FromArgb(64, 64, 64)
            Button5.BackColor = Color.FromArgb(64, 64, 64)
            Button6.BackColor = Color.FromArgb(64, 64, 64)
            Button8.BackColor = Color.FromArgb(64, 64, 64)
            Button10.BackColor = Color.FromArgb(64, 64, 64)
            Button12.BackColor = Color.FromArgb(64, 64, 64)
            Button13.BackColor = Color.FromArgb(64, 64, 64)
            Button67.BackColor = Color.FromArgb(64, 64, 64)


            comprobartipoingreso()
        Else

            picturepagado.Visible = False

            TabControl1.SelectedIndex = 10

            Button1.BackColor = Color.FromArgb(64, 64, 64)
            Button2.BackColor = Color.FromArgb(64, 64, 64)
            Button3.BackColor = Color.FromArgb(64, 64, 64)
            Button4.BackColor = Color.FromArgb(64, 64, 64)
            Button5.BackColor = Color.FromArgb(64, 64, 64)
            Button6.BackColor = Color.FromArgb(64, 64, 64)
            Button8.BackColor = Color.FromArgb(64, 64, 64)
            Button10.BackColor = Color.FromArgb(64, 64, 64)
            Button67.BackColor = Color.DimGray
            Button12.BackColor = Color.FromArgb(64, 64, 64)

            Button13.BackColor = Color.FromArgb(64, 64, 64)
            listaservicios.Visible = False
            stxtlistaclientes.Visible = False
            lbmensaje.Visible = False

            '------------------se obtiene el folio para la venta del servicio
            sobtenerfolio()

            grilla2.Visible = False

        End If

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

            If tipoventa = 1 Then
                MsgBox("El folio corresponde a una venta de productos no de servicios", MsgBoxStyle.Exclamation, "CTRL+y")
                lbmensaje.Visible = True
                sborrartodo()
                sgrilla2.Visible = False

            ElseIf tipoventa = 2 Then
                'en caso de que el tipo de venta sea de 2 entonces significa que si es un servicio y lo buscamos y cargamos
                '----cargamos el folio a la ventana de servicios de la ventana de servicios
                lbmensaje.Visible = False
                cargarfolioventa()
                'agregargrillaventa()
                sgrilla2.Visible = True
                stxtclave.Text = ""

                llenadogrillaventafolio()

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
        Dim idcliente As Integer
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
        stxtfechaentregaventa.Text = reader.GetString(7).ToString()
        stxtanticipo.Text = reader.GetString(8).ToString()
        stxtresto.Text = reader.GetString(9).ToString()

        If CInt(stxtresto.Text) = 0 Then

            picturepagado.Visible = True
        Else
            picturepagado.Visible = False
        End If
        conexionMysql.Close()
        '----cargamos el folio a la ventana de servicios de la ventana de servicios

        'Catch ex As Exception
        'MsgBox("Folio de venta no encontrado", MsgBoxStyle.Information, "CTRL+y")
        cerrarconexion()
        'End Try
    End Function

    Private Sub Button72_Click(sender As Object, e As EventArgs) Handles Button72.Click
        sventa()

    End Sub
    Function sventa()
        ' Try

        If stxttotal.Text = "0" Or stxttotal.Text = "" Or stxtanticipo.Text = "" Or stxtresto.Text = "" Then
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


            Dim fechaentrega As String
            fechaentrega = DateTimePicker1.Value.ToString("yyyy/MM/dd")

            'MsgBox(fechaentrega)
            conexionMysql.Open()
            Dim Sql As String
            Sql = "INSERT INTO venta (idventa, cantidad, total, fecha, hora, idcliente, idusuario, fechaentrega, anticipo, resto, tipoventa) VALUES (" & slbfolio.Text & "," & stxttotalproductos.Text & ", " & CDbl(stxttotal.Text) & ", '" & fecha & "','" & hora & "', " & idcliente & ", " & idusuario & ",'" & fechaentrega & "'," & stxtanticipo.Text & "," & stxtresto.Text & ",'2');"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            cmd.ExecuteNonQuery()
            conexionMysql.Close()
            stxtnombre.Text = ""
            stxtprecio.Text = ""
            'stxtpagar = CDbl(stxttotal.Text)
            stxttotal.Text = ""
            stxtanticipo.Text = ""
            stxtresto.Text = ""
            stxttotalproductos.Text = ""

            conexionMysql.Close()


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
                actividad = sgrilla.Rows(j).Cells(1).Value 'descripcion
                cantidad = sgrilla.Rows(j).Cells(2).Value 'cantidad
                costo = sgrilla.Rows(j).Cells(3).Value 'costo
                idproducto = sgrilla.Rows(j).Cells(5).Value
                descripcion = sgrilla.Rows(j).Cells(6).Value
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
        ' Catch ex As Exception
        comprobartipoingreso()
        'MsgBox(ex.Message)
        'End Try

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

    End Sub

    Private Sub Button68_Click(sender As Object, e As EventArgs) Handles Button68.Click
        Dim formulario As New ADDclientes
        formulario.ShowDialog()
        listaclientes.Visible = False

    End Sub

    Private Sub Button70_Click(sender As Object, e As EventArgs) Handles Button70.Click
        Dim folioventa As Integer

        folioventa = stxtfoliobusquedaventa.Text

        'MsgBox(folioventa)
        Dim formulario As New FRagregaranticipo
        'FRagregaranticipo.ShowDialog()
        formulario.ShowDialog()
        FRagregaranticipo.txtcantidad.Text = stxtfoliobusquedaventa.Text

    End Sub

    Private Sub Picturepagado_Click(sender As Object, e As EventArgs) Handles picturepagado.Click
        picturepagado.Visible = False

    End Sub

    Private Sub Stxtprecio_TextChanged(sender As Object, e As EventArgs) Handles stxtprecio.TextChanged

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
                Sql4 = "INSERT INTO `dwin`.`CLIENTE` (`idcliente`, `nombre`, `ap`, `am`, `edad`, `direccion`, `telefono`, `correo`) VALUES ('1', 'USUARIO', 'USUARIO', 'USUARIO', '000', '000', '000', '000');"
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
            listaservicios.Focus()
        End If
    End Sub

    Private Sub Button75_Click(sender As Object, e As EventArgs) Handles Button75.Click
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

    Private Sub stxtnombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles stxtnombre.KeyPress
        If e.KeyChar = Chr(80) Then
            listaservicios.Focus()
        End If
    End Sub

    Private Sub Button74_Click(sender As Object, e As EventArgs) Handles Button74.Click
        consultarcortecalendario()

    End Sub

    Private Sub listaservicios_KeyDown(sender As Object, e As KeyEventArgs) Handles listaservicios.KeyDown
        If e.KeyCode = Keys.Enter Then
            cargarservicio()
            listaservicios.Visible = False
        End If
    End Sub

    Private Sub listaservicios_DoubleClick(sender As Object, e As EventArgs) Handles listaservicios.DoubleClick
        cargarservicio()
        listaservicios.Visible = False
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

    Private Sub stxtcliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles stxtcliente.KeyPress

    End Sub
End Class