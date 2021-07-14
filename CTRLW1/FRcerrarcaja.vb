Imports System.IO
Imports MySql.Data.MySqlClient
Public Class FRcerrarcaja


    Private Sub FRcerrarcaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbmensaje.Visible = False
        Timer1.Enabled = True

        desglosecorte()
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
            'btventas.Image = Image.FromFile(ruta)
            'btventas.BackgroundImageLayout = ImageLayout.Stretch
            'btventas.SizeMode = PictureBoxSizeMode.Zoom
            'pblogo.Image = Image.FromFile(ruta)
            'btventas.BackgroundImageLayout = ImageLayout.Stretch
            'pblogo.SizeMode = PictureBoxSizeMode.Zoom
        Catch ex As Exception

        End Try



    End Function
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
            cerrarconexion()
        End Try



        'txtetiqueta1 = " prueba de impresión"
        'txtetiqueta2 = " Nº : " & lbfolio.Text
        'txtetiqueta = " De : " & "$" & txttotalpagar.Text &
        'Chr(10) & " " & "12/12/!2"
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
            ' ex.ToString()
        End Try

    End Sub
    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        'e.Graphics.DrawString(txtetiqueta1, New Font("verdana", 11, FontStyle.Bold), New SolidBrush(Color.Black), 1, 9)
        'e.Graphics.DrawString(txtetiqueta2, New Font("verdana", 9, FontStyle.Bold), New SolidBrush(Color.Black), 1, 28)
        'e.Graphics.DrawString(txtetiqueta, New Font("verdana", 13, FontStyle.Bold), New SolidBrush(Color.Black), 1, 57)
        'traemos la información del ticket, como encabezado, datos de la empresa etc.
        Dim saludo, ticketnombre, ticketcoloniaciudad, tickettelefono, ticketgiro, p1, p2, p3, p4, comentario As String
        Dim callenumero, cp, estado, whatsapp, correo, rfc, f_tipo As String
        Dim x, y, tfuente, tfuente2, tfuente3, cant_filas, f_titulo, f_contenido As Integer
        Try


            conexionMysql.Open()
            Dim Sql1 As String

            Sql1 = "Select * From datos_empresa;"
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
            rfc = reader.GetString(22).ToString()
            'p1 = reader.GetString(15).ToString()
            'p2 = reader.GetString(16).ToString()
            ' p3 = reader.GetString(17).ToString()
            ' p4 = reader.GetString(18).ToString()





            conexionMysql.Close()

        Catch ex As Exception

        End Try





        '----------------------------------------
        'NUEVA CONSULTA MAYO 2021
        'CONSULTAMOS EL TAMAÑO D FUENTE Y TIPO DE FUENTE

        conexionMysql.Open()
        Dim Sql1x As String

        Sql1x = "Select f_titulo,f_contenido,f_tipo,p1,p2,p3 From datos_empresa;"
        Dim cmd1x As New MySqlCommand(Sql1x, conexionMysql)
        reader = cmd1x.ExecuteReader()
        reader.Read()
        ' ticketnombre = reader.GetString(1).ToString()





        f_titulo = reader.GetString(0).ToString()
        f_contenido = reader.GetString(1).ToString()
        f_tipo = reader.GetString(2).ToString()
        p1 = reader.GetString(3).ToString()
        p2 = reader.GetString(4).ToString()
        p3 = reader.GetString(5).ToString()

        cerrarconexion()

        '---------------------------------------------------------------------------------------------------

        'consultamos la cantidad de filas del richtextbos
        'Try
        '    conexionMysql.Open()
        '    Dim Sql1 As String
        '    Sql1 = "SELECT cant_filas_descripcion FROM ventaind where idventa='" & lbfolio.Text & "';"
        '    Dim cmd1 As New MySqlCommand(Sql1, conexionMysql)
        '    reader = cmd1.ExecuteReader()
        '    reader.Read()
        '    cant_filas = reader.GetString(1).ToString()

        '    conexionMysql.Close()

        'Catch ex As Exception

        'End Try
        'MsgBox(cant_filas)

        tfuente = f_contenido '7
        tfuente2 = f_titulo
        tfuente3 = f_contenido
        ' p1 = 10 'posicion de X
        x = 5
        y = 125
        Dim ii, incremento As Integer
        incremento = 14
        Dim yy(34) As Integer
        For ii = 0 To 34
            y = y + incremento
            yy(ii) = y
        Next



        Try
            ' La fuente a usar
            Dim prFont As New Font(f_tipo, 15, FontStyle.Bold)
            'POSICION DEL LOGO
            ' la posición superior
            e.Graphics.DrawImage(pblogoticket.Image, 50, 20, 110, 110)


            'imprimir el titutlo del ticket



            prFont = New Font(f_tipo, tfuente2, FontStyle.Bold)
            e.Graphics.DrawString(ticketnombre, prFont, Brushes.Black, p1, yy(0))
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString(ticketgiro, prFont, Brushes.Black, p2, yy(2))
            'IMPRESION DE LOGOTIPO,
            'prFont = New Font("Arial", tfuente, FontStyle.Bold)
            'e.Graphics.DrawString(ticketgiro, prFont, Brushes.Black, x, yy(2))


            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString(callenumero, prFont, Brushes.Black, x, yy(3))

            'imprimir el titutlo del ticket
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString(ticketcoloniaciudad, prFont, Brushes.Black, x, yy(4))
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("CP:" & cp, prFont, Brushes.Black, x, yy(5))
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("TEL:" & tickettelefono, prFont, Brushes.Black, x, yy(6))
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("RFC:" & rfc, prFont, Brushes.Black, x, yy(7))
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("=============================", prFont, Brushes.Black, x, yy(8))

            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("USUARIO:" & frmindex.usuarioactual, prFont, Brushes.Black, x, yy(9))

            'imprimir el titutlo del ticket
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            '''''''''e.Graphics.DrawString("CLIENTE:" & txtcliente.Text, prFont, Brushes.Black, x, yy(10))
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("FECHA:" & Date.Now, prFont, Brushes.Black, x, yy(10))
            prFont = New Font(f_tipo, tfuente2, FontStyle.Bold)
            e.Graphics.DrawString("FOLIO:" & txtid.Text, prFont, Brushes.Black, p3, yy(11))
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("=============================", prFont, Brushes.Black, x, yy(12))

            'imprimir el titutlo del ticket

            'prFont = New Font(f_tipo, tfuente3, FontStyle.Bold)
            'e.Graphics.DrawString("ARTICULO", prFont, Brushes.Black, x, yy(14))
            'prFont = New Font(f_tipo, tfuente3, FontStyle.Bold)
            'e.Graphics.DrawString("ID----PRECIO----CANTIDAD---TOTAL", prFont, Brushes.Black, x, yy(15))

            'prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            'e.Graphics.DrawString("=============================", prFont, Brushes.Black, x, yy(16))


            Dim monto_inicial, monto_final, existencia_caja, fechainicial, hora_inicial, hora_final, observaciones, venta_rapida, anticipos, compras, total_deberia_existir, diferencia, ganancia, fecha_cierre As String
            'aqui es donde tenemos que leer todos los datos deK CORTE DE CAJA
            Dim f1, f2 As String
            'consultamos la cantidad de filas del richtextbos
            Try
                conexionMysql.Open()
                Dim Sql1 As String
                Sql1 = "SELECT * from caja where idcaja='" & txtid.Text & "';"
                Dim cmd1 As New MySqlCommand(Sql1, conexionMysql)
                reader = cmd1.ExecuteReader()
                reader.Read()
                monto_inicial = reader.GetString(1).ToString()
                monto_final = reader.GetString(2).ToString()
                existencia_caja = reader.GetString(3).ToString()
                fechainicial = reader.GetString(4).ToString()
                hora_inicial = reader.GetString(5).ToString()
                hora_final = reader.GetString(6).ToString()
                observaciones = reader.GetString(8).ToString()
                venta_rapida = reader.GetString(9).ToString()
                anticipos = reader.GetString(10).ToString()
                compras = reader.GetString(11).ToString()
                total_deberia_existir = reader.GetString(13).ToString()
                diferencia = reader.GetString(14).ToString()
                ganancia = reader.GetString(15).ToString()
                fecha_cierre = reader.GetString(16).ToString()
                conexionMysql.Close()

            Catch ex As Exception

            End Try

            f1 = Format(CDate(fechainicial), "dd/MM/yyyy")
            f2 = Format(CDate(fecha_cierre), "dd/MM/yyyy")

            ' fechainicial = Format(fechainicial, "")


            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("FECHA APERTURA:" & f1, prFont, Brushes.Black, x, yy(13))
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("Hora Apertura:" & hora_inicial, prFont, Brushes.Black, x, yy(14))
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("FECHA CIERRE:" & f2, prFont, Brushes.Black, x, yy(15))
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("Hora Cierre:" & hora_final, prFont, Brushes.Black, x, yy(16))
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("=============================", prFont, Brushes.Black, x, yy(17))
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("MONTO INICIAL:", prFont, Brushes.Black, x, yy(18))
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("$ " & monto_inicial, prFont, Brushes.Black, 150, yy(18))


            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("MONTO FINAL:", prFont, Brushes.Black, x, yy(19))
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("$ " & monto_final, prFont, Brushes.Black, 150, yy(19))

            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("EXISTENCIA:", prFont, Brushes.Black, x, yy(20))
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("$ " & existencia_caja, prFont, Brushes.Black, 150, yy(20))


            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("DEB. EXISTIR:", prFont, Brushes.Black, x, yy(21))
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("$ " & total_deberia_existir, prFont, Brushes.Black, 150, yy(21))


            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("DIFERENCIA:", prFont, Brushes.Black, x, yy(22))
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("$ " & diferencia, prFont, Brushes.Black, 150, yy(22))

            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("GANANCIA:", prFont, Brushes.Black, x, yy(23))
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("$ " & ganancia, prFont, Brushes.Black, 150, yy(23))

            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("OBS.", prFont, Brushes.Black, x, yy(24))
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString(observaciones, prFont, Brushes.Black, x, yy(25))


            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("=============================", prFont, Brushes.Black, x, yy(26))
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("VENTAS:", prFont, Brushes.Black, x, yy(27))
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("$ " & venta_rapida, prFont, Brushes.Black, 150, yy(27))

            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("COMPRAS:", prFont, Brushes.Black, x, yy(28))
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("$ " & compras, prFont, Brushes.Black, 150, yy(28))

            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("ANTICIPOS:", prFont, Brushes.Black, x, yy(29))
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("$ " & anticipos, prFont, Brushes.Black, 150, yy(29))

            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("========CIERRE CAJA========", prFont, Brushes.Black, x, yy(32))
            'prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            'e.Graphics.DrawString("" & , prFont, Brushes.Black, x, yy(1))
            'prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            'e.Graphics.DrawString("" & , prFont, Brushes.Black, x, yy(1))
            'prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            'e.Graphics.DrawString("" & , prFont, Brushes.Black, x, yy(1))


            'Dim i As Integer = grilla.RowCount
            'Dim t1, t2, t3, t4, t5, cant_f_ob As Integer
            'Dim actividad As String
            'Dim cantidad, costo, idventa As Double
            'Dim idproducto As String

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
            '    cant_f_ob = grilla.Rows(j).Cells(7).Value
            'cerrarconexion()
            'conexionMysql.Open()

            'MsgBox("el producto es:" & actividad)

            'Dim Sql2 As String
            'Sql2 = "INSERT INTO ventaind (actividad, cantidad, costo, idventa,idproducto) VALUES ('" & actividad & "'," & cantidad & "," & costo & "," & lbfolio.Text & ",'" & idproducto & "');"
            'Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            'cmd2.ExecuteNonQuery()
            'conexionMysql.Close()

            'prFont = New Font(f_tipo, tfuente3, FontStyle.Bold)
            '    e.Graphics.DrawString(actividad, prFont, Brushes.Black, x, t1)

            '    prFont = New Font(f_tipo, tfuente3, FontStyle.Bold)
            '    e.Graphics.DrawString(idproducto & "-----$" & costo & "-----" & cantidad & "-----$" & (CDbl(costo) * CDbl(cantidad)), prFont, Brushes.Black, x, t2)
            '    prFont = New Font(f_tipo, tfuente3, FontStyle.Bold)
            '    e.Graphics.DrawString(comentario, prFont, Brushes.Black, x, t3)


            '    'prFont = New Font("Arial", 10, FontStyle.Bold)
            '    'e.Graphics.DrawString(cantidad & "-- $" & (CDbl(costo) * CDbl(cantidad)), prFont, Brushes.Black, 0, t3)

            '    t1 = t1 + (incremento * 3.2) + cant_f_ob
            '    t2 = t2 + (incremento * 3.2) + cant_f_ob
            '    t3 = t3 + (incremento * 3.2) + cant_f_ob

            'Next

            't1 = t1 - (incremento * 2) + cant_f_ob
            't2 = t2 - (incremento * 2) + cant_f_ob
            't3 = t3 - (incremento * 2) + cant_f_ob


            'prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            'e.Graphics.DrawString("=============================", prFont, Brushes.Black, 0, t3)

            ''----------------AQUI SE IMPRIME EL TOTAL A PAGAR

            'prFont = New Font(f_tipo, tfuente3, FontStyle.Bold)
            'e.Graphics.DrawString("   Total---->$" & txttotalpagar.Text, prFont, Brushes.Black, x, t3 + incremento)
            'prFont = New Font(f_tipo, tfuente3, FontStyle.Bold)
            'e.Graphics.DrawString("Efectivo---->$" & lbpagacon.Text, prFont, Brushes.Black, x, t3 + (incremento * 2))
            'prFont = New Font(f_tipo, tfuente3, FontStyle.Bold)
            'e.Graphics.DrawString("  Cambio---->$" & lbcambio.Text, prFont, Brushes.Black, x, t3 + (incremento * 3))

            'prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            'e.Graphics.DrawString("=============================", prFont, Brushes.Black, x, t3 + (incremento * 4))
            'prFont = New Font(f_tipo, tfuente3, FontStyle.Bold)
            'e.Graphics.DrawString(saludo, prFont, Brushes.Black, x, t3 + (incremento * 5))
            ''prFont = New Font("Arial", tfuente3, FontStyle.Bold)
            ''e.Graphics.DrawString("CTRL+y", prFont, Brushes.Black, 10, t2 + 60)

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


    Function cerrarconexion()
        If conexionMysql.State = ConnectionState.Open Then
            conexionMysql.Close()

        End If
    End Function
    Function desglosecorte()
        cerrarconexion()
        'Try

        'todos los datos son obtenidos con la fecha actual para evitar conflictos
        Dim dia, mes, año, fecha, horacaja, fechacaja As String
        Dim hora2, minuto, segundo, hora, compras, anticipo, fechafinal As String
        ' Dim fechacaja As Date
        hora2 = Now.Hour()
        minuto = Now.Minute()
        segundo = Now.Second()

        hora = hora2 & ":" & minuto & ":" & segundo

        dia = Date.Now.Day
        mes = Date.Now.Month
        año = Date.Now.Year
        fecha = año & "-" & mes & "-" & dia

        fechafinal = fecha + " " + hora




        'CONSULTA PARA TODOS LOS PRODUCTOS EXTRAS, PAPELERIA Y SERVICIOS

        'consulto el id maximo mas actual y obtengo la fecha para saber que id se quedo con caja abierta
        '------------------------------------------------------------------
        Dim id As Integer
        cerrarconexion()
        conexionMysql.Open()
        Dim sql1 As String
        sql1 = "select max(idcaja) from caja where estado=0;"
        Dim cmd1 As New MySqlCommand(sql1, conexionMysql)
        reader = cmd1.ExecuteReader
        reader.Read()
        'id del registro abierto para cerrarlo
        id = reader.GetString(0).ToString()
        txtid.Text = id
        conexionMysql.Close()
        '------------------------------------------------------------------
        'consulto la hora inicial y la fecha en que se abrio la caja, esto significa que  desde ese momento vamos a comenzar a contar lo vendido
        '------------------------------------------------------------------
        cerrarconexion()
        conexionMysql.Open()
        Dim sql13 As String
        sql13 = "select DATE_FORMAT(fecha, '%Y-%m-%d')as fecha, hora_inicial,monto_inicial   from caja where idcaja=" & id & ";"
        Dim cmd13 As New MySqlCommand(sql13, conexionMysql)
        reader = cmd13.ExecuteReader
        reader.Read()
        'fecha que se abrio la caja
        fechacaja = reader.GetString(0).ToString()
        'hora en que se abrio la caja
        horacaja = reader.GetString(1).ToString()
        txtsaldoinicial.Text = reader.GetString(2).ToString()
        conexionMysql.Close()
        'MsgBox(fechacaja & " hora: " & horacaja)

        cerrarconexion()

        '        MsgBox(fecha)
        '---------------------------------------------------------
        '----------------------------------------------------'
        'comprobar si el cierre de caja se hizo en el mismo dia, o se hace ne otro dia diferente. 
        '---------------------------------------------------
        '-----------------------------------------------------
        Dim fechainicial As String
        fechainicial = fechacaja + " " + horacaja

        'se manda la fecha y hora al label de la pantalla
        lbfechaapertura.Text = fechainicial
        lbfechacierre.Text = fechafinal





        '-----------------------------------------------------------------------------

        '-----------------------------------------------------------------------------
        Try

            conexionMysql.Open()
            Dim Sql2bx As String
            '------PRIMERO SUMAMOS LAS VENTAS DE LOS SERVICIOS
            Sql2bx = "select sum(anticipo)  from servicios_ventas where fecha between '" & fechainicial & "' and '" & fechafinal & "'"
            'Sql2 = "select sum(total)as total from venta where fecha='" & fecha & "';"
            Dim cmd2bx As New MySqlCommand(Sql2bx, conexionMysql)
            reader = cmd2bx.ExecuteReader
            reader.Read()

            txtanticipos.Text = reader.GetString(0).ToString()
            'MsgBox(anticipo)
            'MsgBox(reader.GetString(0).ToString())
            conexionMysql.Close()
            cerrarconexion()
        Catch ex As Exception
            txtanticipos.Text = 0
        End Try
        'Try

        '    conexionMysql.Open()
        '    Dim Sql2b As String
        '    '------PRIMERO SUMAMOS LAS VENTAS DE LOS SERVICIOS
        '    Sql2b = "select sum(anticipo)  from venta where fecha between '" & fechainicial & "' and '" & fechafinal & "' and tipoventa=2;"
        '    'Sql2 = "select sum(total)as total from venta where fecha='" & fecha & "';"
        '    Dim cmd2b As New MySqlCommand(Sql2b, conexionMysql)
        '    reader = cmd2b.ExecuteReader
        '    reader.Read()

        '    txtanticipos.Text = reader.GetString(0).ToString()
        '    'MsgBox(anticipo)
        '    'MsgBox(reader.GetString(0).ToString())
        '    conexionMysql.Close()
        '    cerrarconexion()
        'Catch ex As Exception
        '    txtanticipos.Text = 0
        'End Try


        '.--------------------------------------------------------
        'COMPROBACION DE LAS COMPRAS REALIZADAS CUANDO SE ABRIO LA CAJA Y LA FECHA
        '----------------------------------------------------------
        Try
            cerrarconexion()

            conexionMysql.Open()
            Dim sql1a As String
            sql1a = "select sum(total)  from compra where fecha between '" & fechainicial & "' and '" & fechafinal & "';"
            Dim cmd1a As New MySqlCommand(sql1a, conexionMysql)
            reader = cmd1a.ExecuteReader
            reader.Read()
            txtcompras.Text = reader.GetString(0).ToString()
            conexionMysql.Close()
            cerrarconexion()
        Catch ex As Exception
            'MsgBox("Aun no hay compras realizadas", MsgBoxStyle.Information, "Sistema")
            txtcompras.Text = 0
            cerrarconexion()
        End Try

        '------------------------------------------------------------
        'MsgBox(fechacaja)
        ' MsgBox(horacaja)
        '.--------------------------------------------------------
        'COMPROBACION DE LAS COMPRAS de mercancia
        '----------------------------------------------------------
        Try
            cerrarconexion()

            conexionMysql.Open()
            Dim sql1ab As String
            sql1ab = "select sum(totalcompra)  from compramercancia where fecha between '" & fechainicial & "' and '" & fechafinal & "';"
            Dim cmd1ab As New MySqlCommand(sql1ab, conexionMysql)
            reader = cmd1ab.ExecuteReader
            reader.Read()
            txtcompramercancia.Text = reader.GetString(0).ToString()
            conexionMysql.Close()
            cerrarconexion()
        Catch ex As Exception
            'MsgBox("Aun no hay compras realizadas", MsgBoxStyle.Information, "Sistema")
            txtcompramercancia.Text = 0
            cerrarconexion()
        End Try

        '------------------------------------------------------------


        'verificamos que la fecha que se consulto sea la fecha actual, 
        'posiblemente la caja esta abierta desde el día de ayer, entonces cerramos la caja anterior


        '------------------------
        'If fecha = fechacaja Then
        'Else
        '    'en caso de que sean diferentes, vamos a cerrar la caja anterior.
        '    MsgBox("Existe un registro de caja abierta del dia " & fechacaja & ", para continuar, primero cierra la caja anterior")

        'End If


        '------------------------------------------------------------------
        Dim min, max As Integer
        '----------------------------------------------------------------
        'CORRESPONDE AL RANGO DE ID DE VENTA QUE SE HAN HECHO
        Try
            'MsgBox("verificar")
            cerrarconexion()
            conexionMysql.Open()
            Dim sql22 As String
            sql22 = "select min(idventa)as minimo, max(idventa) as maximo from venta where fecha between '" & fechainicial & "' and '" & fechafinal & "';"
            Dim cmd22 As New MySqlCommand(sql22, conexionMysql)
            reader = cmd22.ExecuteReader
            reader.Read()
            min = reader.GetString(0).ToString()
            max = reader.GetString(1).ToString()

            conexionMysql.Close()
            '-----------------------------------------------------------------


            'MsgBox("min:" & min & "max:" & max)

        Catch ex As Exception
            min = 0
            max = 0
            cerrarconexion()
        End Try


        ' MsgBox("id minimo" & min)
        ' MsgBox("id maximo" & max)

        '-----------------CONSULTAMOS SI EN EL CORTE SE HACE DE MAS DE 1 USUARIO, YA QUE UNO DE ELLOS
        '-----------------PUDO NO HABER HECHO SU CORTE, ENTONCES LE INDICAMOS AL USUARIO QUE SE HACE DE DOS
        Dim cantidad_total_productos As String


        'If min = 0 And max = 0 Then

        '    'txtsaldogenerado.Text = 0
        '    txttotalproductos.Text = 0
        'Else






        ' MsgBox(fechainicial)
        '--------------------------------------------------------------------
        'SUMA DE LAS VENTAS DE VENTAS RAPIDAS
        '-----------------------------------------------------------------------
        Try

            cerrarconexion()
            Dim Sqla1 As String
            'Dim totalcorteventa As String
            conexionMysql.Open()
            'Sql = "select sum(total), fecha from venta where fecha='" & fecha & "';"
            Sqla1 = "select sum(total)  from venta where fecha between '" & fechainicial & "' and '" & fechafinal & "' and tipoventa=1;"

            'Sqla1 = "Select sum(total)As suma from venta where fecha>='" & fechacaja & "' and hora>='" & horacaja & "' and tipoventa=1;"
            'Sqla1 = "select sum(total)as suma, sum(cantidad)as cantidad  from venta where idventa between '" & min & "' and '" & max & "';"
            Dim cmda1 As New MySqlCommand(Sqla1, conexionMysql)
            reader = cmda1.ExecuteReader()
            reader.Read()
            'Try
            txtventasproductos.Text = reader.GetString(0).ToString
            'txtventasefectivo.Text = reader.GetString(0).ToString

            'txttotalproductos.Text = reader.GetString(1).ToString
        Catch ex As Exception
            cerrarconexion()
            txtventasproductos.Text = 0
            'txtventasefectivo.Text = 0

        End Try



        '--------------------------------------------------------------------
        'SUMA DE LAS VENTAS DE VENTAS efectivo
        '-----------------------------------------------------------------------
        Try

            cerrarconexion()
            Dim Sqla12 As String
            Dim totalcorteventa As String
            conexionMysql.Open()
            'Sql = "select sum(total), fecha from venta where fecha='" & fecha & "';"
            Sqla12 = "select sum(total)as suma, sum(cantidad)as cantidad  from venta where fecha between '" & fechainicial & "' and '" & fechafinal & "' and idtipo_pago=1;"
            'Sqla1 = "select sum(total)as suma, sum(cantidad)as cantidad  from venta where idventa between '" & min & "' and '" & max & "';"
            Dim cmda12 As New MySqlCommand(Sqla12, conexionMysql)
            reader = cmda12.ExecuteReader()
            reader.Read()
            'Try
            'txtventasproductos.Text = reader.GetString(0).ToString
            txtventasefectivo.Text = reader.GetString(0).ToString
            ' MsgBox("echo")
            'txttotalproductos.Text = reader.GetString(1).ToString
        Catch ex As Exception
            cerrarconexion()
            'txtventasproductos.Text = 0
            txtventasefectivo.Text = 0

        End Try


        '-------------------------------------------------------------------
        'SUMA De ventas por transferencias
        '---------------------------------------------------------------------------

        Try

            cerrarconexion()
            Dim Sqla13 As String
            'Dim totalcorteventa As String
            conexionMysql.Open()
            'Sql = "select sum(total), fecha from venta where fecha='" & fecha & "';"
            Sqla13 = "select sum(anticipo)as suma from venta where fecha between '" & fechainicial & "' and '" & fechafinal & "' and idtipo_pago=2"
            'Sqla1 = "select sum(total)as suma, sum(cantidad)as cantidad  from venta where idventa between '" & min & "' and '" & max & "';"
            Dim cmda13 As New MySqlCommand(Sqla13, conexionMysql)
            reader = cmda13.ExecuteReader()
            reader.Read()
            'Try
            txtventastransferencias.Text = reader.GetString(0).ToString
            'txttotalproductos.Text = reader.GetString(1).ToString
        Catch ex As Exception
            cerrarconexion()
            txtventastransferencias.Text = 0
        End Try

        '-------------------------------------------------------------------
        'SUMA De ventas por tarjeta
        '---------------------------------------------------------------------------

        Try

            cerrarconexion()
            Dim Sqla14 As String
            'Dim totalcorteventa As String
            conexionMysql.Open()
            'Sql = "select sum(total), fecha from venta where fecha='" & fecha & "';"
            Sqla14 = "select sum(total)as suma from venta where fecha between '" & fechainicial & "' and '" & fechafinal & "' and idtipo_pago=3;"
            'Sqla1 = "select sum(total)as suma, sum(cantidad)as cantidad  from venta where idventa between '" & min & "' and '" & max & "';"
            Dim cmda14 As New MySqlCommand(Sqla14, conexionMysql)
            reader = cmda14.ExecuteReader()
            reader.Read()
            'Try
            txtventastarjeta.Text = reader.GetString(0).ToString
            'txttotalproductos.Text = reader.GetString(1).ToString
        Catch ex As Exception
            cerrarconexion()
            txtventastarjeta.Text = 0
        End Try



        '-------------------------------------------------------------------
        'SUMA De ventas por vales
        '---------------------------------------------------------------------------

        Try

            cerrarconexion()
            Dim Sqla15 As String
            ' Dim totalcorteventa As String
            conexionMysql.Open()
            'Sql = "select sum(total), fecha from venta where fecha='" & fecha & "';"
            Sqla15 = "select sum(total)as suma from venta where fecha between '" & fechainicial & "' and '" & fechafinal & "' and idtipo_pago=4;"
            'Sqla1 = "select sum(total)as suma, sum(cantidad)as cantidad  from venta where idventa between '" & min & "' and '" & max & "';"
            Dim cmda15 As New MySqlCommand(Sqla15, conexionMysql)
            reader = cmda15.ExecuteReader()
            reader.Read()
            'Try
            txtventavales.Text = reader.GetString(0).ToString
            'txttotalproductos.Text = reader.GetString(1).ToString
        Catch ex As Exception
            cerrarconexion()
            txtventavales.Text = 0
        End Try
        '-------------------------------------------------------------------
        'SUMA DE LOS ANTICIPOS DADOS POR LOS SERVICIOS
        '---------------------------------------------------------------------------
        '--------------------------------------------------
        'Try
        ' MsgBox(fechacaja)

        'MsgBox(horacaja)


        ' Catch ex As Exception
        'MsgBox("error 1")
        'txtanticipos.Text = 0
        ' cerrarconexion()
        '  End Try


        ' End If

        '    Catch ex As Exception
        ' MsgBox("Aun no hay ventas.", MsgBoxStyle.Information, "Sistema")
        ' txtsaldogenerado.Text = 0
        'txttotalproductos.Text = 0
        conexionMysql.Close()


        cerrarconexion()

        calculoganancia(max, min, fechainicial, fechafinal)




        '    End Try
        '-------------------------------------------------------------------------------------


        '----------------------------------------------------------
        'SE REALIZA LA SUMA DE TODAS LAS VENTAS QUE SE REALIZARON EL DIA
        'TOMANDO EN CUENTA LA FECHA DE APERTURA DE LA CAJA
        '----------------------------------------------------------


        'Dim sumaventas As Double
        'cerrarconexion()
        'conexionMysql.Open()
        'Dim Sql2 As String
        'Sql2 = "select sum(total)as total from venta where fecha='" & fecha & "';"
        'Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
        'reader = cmd2.ExecuteReader
        'reader.Read()
        'txtsaldogenerado.Text = reader.GetString(0).ToString()
        'conexionMysql.Close()
        '    --------------------------------------------------------------------
        '    cerrarconexion()

        'conexionMysql.Open()
        'Dim Sql3 As String
        'Sql3 = "select sum(recargas_venta)as suma1, sum(ciber) as suma from corte where fecha_registro='" & fecha & "';"
        'Dim cmd3 As New MySqlCommand(Sql3, conexionMysql)
        'reader = cmd3.ExecuteReader
        'reader.Read()
        'conexionMysql.Close()

        'calculamos las operaciones para que de el final.
        ' cbttotales.Text = "$ " & CDbl(cbtnextras.Text) - CDbl(cbtncompras.Text)
        'hacemos la ultima oepracion matematica
        'Try

        txttotalfinalventas.Text = CDbl(txtventasproductos.Text) + CDbl(txtanticipos.Text)




            txtcomprastotales.Text = CDbl(txtcompras.Text) + CDbl(txtcompramercancia.Text)

            txttotalventascompras.Text = CDbl(txttotalfinalventas.Text) - CDbl(txtcomprastotales.Text)
            txtdeberialexistir.Text = CDbl(txtsaldoinicial.Text) + CDbl(txttotalventascompras.Text)

        'Catch ex As Exception

        'End Try

        '  Catch ex As Exception
        '    MsgBox("error")
        ' End Try



    End Function
    Function calculoganancia(ByVal max1 As Integer, ByVal min As Integer, ByVal fechainicial As String, ByVal fechafinal As String)
        Dim cantidad, idmax, idmin, i As Integer
        Try

            cerrarconexion()
            Dim Sqla15 As String
            conexionMysql.Open()
            Sqla15 = "select min(idventaind),max(idventaind), count(idventaind) from ventaind where idventa between " & min & " and " & max1 & ";"
            Dim cmda15 As New MySqlCommand(Sqla15, conexionMysql)
            reader = cmda15.ExecuteReader()
            reader.Read()
            idmin = reader.GetString(0).ToString
            idmax = reader.GetString(1).ToString
            cantidad = reader.GetString(2).ToString



        Catch ex As Exception
            cerrarconexion()
            cantidad = 0
        End Try

        'MsgBox(idmin)
        'MsgBox(idmax)
        'MsgBox(cantidad)


        Dim clave As String
        Dim costo, precio, valor, sumaGanancia As Double
        sumaGanancia = 0
        If cantidad >= 1 Then


            For i = idmin To idmax


                '  MsgBox(i)

                cerrarconexion()
                Dim Sqla15 As String
                conexionMysql.Open()
                Sqla15 = "select idproducto,costo from ventaind where idventaind=" & i & ";"
                Dim cmda15 As New MySqlCommand(Sqla15, conexionMysql)
                reader = cmda15.ExecuteReader()
                reader.Read()
                clave = reader.GetString(0).ToString
                precio = reader.GetString(1).ToString
                cerrarconexion()

                '  MsgBox("precio" & precio)


                cerrarconexion()
                Dim Sqla16 As String
                conexionMysql.Open()
                Sqla16 = "select costo from producto where idproducto='" & clave & "';"
                Dim cmda16 As New MySqlCommand(Sqla16, conexionMysql)
                reader = cmda16.ExecuteReader()
                reader.Read()
                costo = reader.GetString(0).ToString
                cerrarconexion()

                ' MsgBox("costo" & costo)


                valor = CDbl(precio) - CDbl(costo)
                ' MsgBox(valor)
                sumaGanancia = sumaGanancia + valor
                ' MsgBox(sumaGanancia)


            Next

            txtganancia.Text = sumaGanancia

        Else
            txtganancia.Text = "0"
        End If







    End Function
    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click


        Try

            'todos los datos son obtenidos con la fecha actual para evitar conflictos
            Dim dia, mes, año, fecha, horacaja, fechacaja As String
            Dim hora2, minuto, segundo, hora As String
            ' Dim fechacaja As Date
            hora2 = Now.Hour()
            minuto = Now.Minute()
            segundo = Now.Second()

            hora = hora2 & ":" & minuto & ":" & segundo

            dia = Date.Now.Day
            mes = Date.Now.Month
            año = Date.Now.Year
            fecha = año & "-" & mes & "-" & dia
            '-----------------------------------
            'guardamos el registro dentro de la BD CORTE
            '------------------------------------
            cerrarconexion()
            conexionMysql.Open()
            'actualizo el dato
            Dim Sql5 As String
            Sql5 = "UPDATE `dwin`.`caja` SET `monto_final` = '" & txttotalfinalventas.Text & "', `existencia_caja` = '" & txtsaldocaja.Text & "', `hora_final` = '" & hora & "', `estado` = '1', observaciones='" & txtobservaciones.Text & "' WHERE (`idcaja` = '" & txtid.Text & "');"
            Dim cmd5 As New MySqlCommand(Sql5, conexionMysql)
            cmd5.ExecuteNonQuery()
            conexionMysql.Close()
            MsgBox("Se ha cerrado la caja", MsgBoxStyle.Information, "CTRL+y")
            Me.Close()
        Catch ex As Exception
            MsgBox("Verifica la información", MsgBoxStyle.Information, "CTRL+y")
        End Try


    End Sub
    Function diferencia()
        Try

            txtdiferencia.Text = CDbl(txtsaldocaja.Text) - CDbl(txtdeberialexistir.Text)
            If txtdiferencia.Text < 0 Then
                txtdiferencia.BackColor = Color.Coral
                lbmensaje.Visible = True



                'txtdiferencia.ForeColor = Color.White
            Else
                txtdiferencia.BackColor = Color.White
                'txtdiferencia.ForeColor = Color.Black
                lbmensaje.Visible = False

            End If
        Catch ex As Exception

        End Try

    End Function
    Private Sub Txtsaldocaja_TextChanged(sender As Object, e As EventArgs) Handles txtsaldocaja.TextChanged
        diferencia()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Function cerrarcaja()
        cerrarconexion()

        Try

            'todos los datos son obtenidos con la fecha actual para evitar conflictos
            Dim dia, mes, año, fecha, horacaja, fechacaja As String
            Dim hora2, minuto, segundo, hora As String
            ' Dim fechacaja As Date
            hora2 = Now.Hour()
            minuto = Now.Minute()
            segundo = Now.Second()

            hora = hora2 & ":" & minuto & ":" & segundo

            dia = Date.Now.Day
            mes = Date.Now.Month
            año = Date.Now.Year
            fecha = año & "-" & mes & "-" & dia
            '-----------------------------------
            'guardamos el registro dentro de la BD CORTE
            '------------------------------------
            cerrarconexion()
            conexionMysql.Open()
            'actualizo el dato
            Dim Sql5 As String
            Sql5 = "UPDATE `dwin`.`caja` SET `monto_final` = '" & txttotalfinalventas.Text & "', `existencia_caja` = '" & txtsaldocaja.Text & "', `hora_final` = '" & hora & "', `estado` = '1', observaciones='" & txtobservaciones.Text & "', venta_rapida=" & txtventasproductos.Text & ", anticipos=" & txtanticipos.Text & ", compras=" & txtcompras.Text & ", total_ventas_compras=" & txttotalventascompras.Text & ", total_deberia_existir=" & txtdeberialexistir.Text & ", diferencia=" & txtdiferencia.Text & ", ganancia='" & txtganancia.Text & "', fecha_cierre='" & fecha & "'   WHERE (`idcaja` = '" & txtid.Text & "');"
            Dim cmd5 As New MySqlCommand(Sql5, conexionMysql)
            cmd5.ExecuteNonQuery()
            conexionMysql.Close()
            MsgBox("Se ha cerrado la caja", MsgBoxStyle.Information, "CTRL+y")
            'llamamos al a funcion de impresion de tickets
            imprimir()
            If ChAnticipos.Checked = True Then
                imprimiranticipos()

            End If

            'MsgBox(txtid.Text)
            'FRNOTACERRARCAJA.ShowDialog()

            frmindex.btnabrircajamenu.Visible = True
            frmindex.btncerrarcajamenu.Visible = False
            Me.Close()
        Catch ex As Exception
            MsgBox("Verifica la información", MsgBoxStyle.Information, "CTRL+y")
        End Try

    End Function
    Private Sub imprimiranticipos()

        'consultamos a la BD la impresora seleccionada por default
        Dim impresora As String
        Try
            cerrarconexion()
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
            PrintDialog1.Document = PrintDocument4anticipos
            PrintDialog1.PrinterSettings.PrinterName = impresora
            If PrintDocument4anticipos.PrinterSettings.IsValid Then
                PrintDocument4anticipos.Print() 'Imprime texto 
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
    Private Sub Button45_Click(sender As Object, e As EventArgs) Handles Button45.Click



    End Sub

    Private Sub Button85_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim dia, mes, año, fecha, hora2, minuto, segundo, hora, compras, anticipo, fechafinal As String
        ' Dim fechacaja As Date
        hora2 = Now.Hour()
        minuto = Now.Minute()
        segundo = Now.Second()

        hora = hora2 & ":" & minuto & ":" & segundo

        dia = Date.Now.Day
        mes = Date.Now.Month
        año = Date.Now.Year
        fecha = año & "-" & mes & "-" & dia

        fechafinal = fecha + " " + hora
        lbfechacierre.Text = fechafinal

    End Sub

    Private Sub Txttotalventascompras_TextChanged(sender As Object, e As EventArgs) Handles txttotalventascompras.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cerrarcaja()
    End Sub

    Private Sub PrintDocument3_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument3.PrintPage

    End Sub

    Private Sub PrintDocument2_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument2.PrintPage

    End Sub

    Private Sub PrintDocument4anticipos_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument4anticipos.PrintPage
        'e.Graphics.DrawString(txtetiqueta1, New Font("verdana", 11, FontStyle.Bold), New SolidBrush(Color.Black), 1, 9)
        'e.Graphics.DrawString(txtetiqueta2, New Font("verdana", 9, FontStyle.Bold), New SolidBrush(Color.Black), 1, 28)
        'e.Graphics.DrawString(txtetiqueta, New Font("verdana", 13, FontStyle.Bold), New SolidBrush(Color.Black), 1, 57)
        'traemos la información del ticket, como encabezado, datos de la empresa etc.
        Dim saludo, ticketnombre, ticketcoloniaciudad, tickettelefono, ticketgiro, p1, p2, p3, p4, comentario As String
        Dim callenumero, cp, estado, whatsapp, correo, rfc, f_tipo As String
        Dim x, y, tfuente, tfuente2, tfuente3, cant_filas, f_titulo, f_contenido As Integer
        Try

            cerrarconexion()
            conexionMysql.Open()
            Dim Sql1 As String

            Sql1 = "Select * From datos_empresa;"
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
            rfc = reader.GetString(22).ToString()
            'p1 = reader.GetString(15).ToString()
            'p2 = reader.GetString(16).ToString()
            ' p3 = reader.GetString(17).ToString()
            ' p4 = reader.GetString(18).ToString()





            conexionMysql.Close()

        Catch ex As Exception

        End Try





        '----------------------------------------
        'NUEVA CONSULTA MAYO 2021
        'CONSULTAMOS EL TAMAÑO D FUENTE Y TIPO DE FUENTE
        cerrarconexion()
        conexionMysql.Open()
        Dim Sql1x As String

        Sql1x = "Select f_titulo,f_contenido,f_tipo,p1,p2,p3 From datos_empresa;"
        Dim cmd1x As New MySqlCommand(Sql1x, conexionMysql)
        reader = cmd1x.ExecuteReader()
        reader.Read()
        ' ticketnombre = reader.GetString(1).ToString()





        f_titulo = reader.GetString(0).ToString()
        f_contenido = reader.GetString(1).ToString()
        f_tipo = reader.GetString(2).ToString()
        p1 = reader.GetString(3).ToString()
        p2 = reader.GetString(4).ToString()
        p3 = reader.GetString(5).ToString()

        cerrarconexion()



        tfuente = f_contenido '7
        tfuente2 = f_titulo
        tfuente3 = f_contenido
        ' p1 = 10 'posicion de X
        x = 5
        y = 125
        Dim ii, incremento As Integer
        incremento = 14
        Dim yy(34) As Integer
        For ii = 0 To 34
            y = y + incremento
            yy(ii) = y
        Next



        Try
            ' La fuente a usar
            Dim prFont As New Font(f_tipo, 15, FontStyle.Bold)
            'POSICION DEL LOGO
            ' la posición superior
            e.Graphics.DrawImage(pblogoticket.Image, 50, 20, 110, 110)


            'imprimir el titutlo del ticket



            prFont = New Font(f_tipo, tfuente2, FontStyle.Bold)
            e.Graphics.DrawString(ticketnombre, prFont, Brushes.Black, x, yy(0))
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString(ticketgiro, prFont, Brushes.Black, x, yy(2))
            'IMPRESION DE LOGOTIPO,
            'prFont = New Font("Arial", tfuente, FontStyle.Bold)
            'e.Graphics.DrawString(ticketgiro, prFont, Brushes.Black, x, yy(2))


            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString(callenumero, prFont, Brushes.Black, x, yy(3))

            'imprimir el titutlo del ticket
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString(ticketcoloniaciudad, prFont, Brushes.Black, x, yy(4))
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("CP:" & cp, prFont, Brushes.Black, x, yy(5))
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("TEL:" & tickettelefono, prFont, Brushes.Black, x, yy(6))
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("RFC:" & rfc, prFont, Brushes.Black, x, yy(7))
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("=============================", prFont, Brushes.Black, x, yy(8))

            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("USUARIO:" & frmindex.usuarioactual, prFont, Brushes.Black, x, yy(9))

            'imprimir el titutlo del ticket
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            '''''''''e.Graphics.DrawString("CLIENTE:" & txtcliente.Text, prFont, Brushes.Black, x, yy(10))
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("FECHA:" & Date.Now, prFont, Brushes.Black, x, yy(10))
            prFont = New Font(f_tipo, tfuente2, FontStyle.Bold)
            e.Graphics.DrawString("FOLIO CORTE:" & txtid.Text, prFont, Brushes.Black, x, yy(11))
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("=============================", prFont, Brushes.Black, x, yy(12))



            Dim monto_inicial, monto_final, existencia_caja, fechainicial, hora_inicial, hora_final, observaciones, venta_rapida, anticipos, compras, total_deberia_existir, diferencia, ganancia, fecha_cierre As String
            'aqui es donde tenemos que leer todos los datos deK CORTE DE CAJA
            Dim f1, f2 As String
            'consultamos la cantidad de filas del richtextbos
            Try
                cerrarconexion()
                conexionMysql.Open()
                Dim Sql1xa As String
                Sql1xa = "SELECT * from caja where idcaja='" & txtid.Text & "';"
                Dim cmd1xa As New MySqlCommand(Sql1xa, conexionMysql)
                reader = cmd1xa.ExecuteReader()
                reader.Read()
                monto_inicial = reader.GetString(1).ToString()
                monto_final = reader.GetString(2).ToString()
                existencia_caja = reader.GetString(3).ToString()
                fechainicial = reader.GetString(4).ToString()
                hora_inicial = reader.GetString(5).ToString()
                hora_final = reader.GetString(6).ToString()
                observaciones = reader.GetString(8).ToString()
                venta_rapida = reader.GetString(9).ToString()
                anticipos = reader.GetString(10).ToString()
                compras = reader.GetString(11).ToString()
                total_deberia_existir = reader.GetString(13).ToString()
                diferencia = reader.GetString(14).ToString()
                ganancia = reader.GetString(15).ToString()
                fecha_cierre = reader.GetString(16).ToString()
                conexionMysql.Close()

            Catch ex As Exception

            End Try

            f1 = Format(CDate(fechainicial), "dd/MM/yyyy")
            f2 = Format(CDate(fecha_cierre), "dd/MM/yyyy")

            Dim idventa, cantidad, total, anticipo, resto, sumtotal, sumanticipo, sumresto, idcliente As String
            Dim i, j As Integer
            ' fechainicial = Format(fechainicial, "")
            'Try
            '    cerrarconexion()
            '    conexionMysql.Open()
            '    Dim Sql1xs As String
            '    Sql1xs = "select idventa,cantidad, total, anticipo, resto from venta where tipoventa=2 and fecha between '" & lbfechaapertura.Text & "' and '" & lbfechacierre.Text & "';"
            '    Dim cmd1xs As New MySqlCommand(Sql1xs, conexionMysql)
            '    reader = cmd1xs.ExecuteReader()
            '    reader.Read()
            '    idventa = reader.GetString(0).ToString()
            '    cantidad = reader.GetString(1).ToString()
            '    total = reader.GetString(2).ToString()
            '    anticipo = reader.GetString(3).ToString()
            '    resto = reader.GetString(4).ToString()
            '    conexionMysql.Close()
            'Catch ex As Exception
            'End Try




            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("FECHA APERTURA:" & f1, prFont, Brushes.Black, x, yy(13))
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("Hora Apertura:" & hora_inicial, prFont, Brushes.Black, x, yy(14))
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("FECHA CIERRE:" & f2, prFont, Brushes.Black, x, yy(15))
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("Hora Cierre:" & hora_final, prFont, Brushes.Black, x, yy(16))
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("=============================", prFont, Brushes.Black, x, yy(17))
            prFont = New Font(f_tipo, tfuente3, FontStyle.Bold)
            e.Graphics.DrawString("F.Venta---IDClie---Total--Anti--Resto", prFont, Brushes.Black, x, yy(18))

            '----------------AQUI SE IMPRIME EL TOTAL A PAGAR
            Try
                cerrarconexion()
                conexionMysql.Open()
                Dim Sql12 As String
                Sql12 = "select count(*), sum(total), sum(anticipo) from servicios_ventas where fecha between '" & lbfechaapertura.Text & "' and '" & lbfechacierre.Text & "';"
                Dim cmd12 As New MySqlCommand(Sql12, conexionMysql)
                reader = cmd12.ExecuteReader()
                reader.Read()
                i = reader.GetString(0).ToString()
                sumtotal = reader.GetString(1).ToString()
                sumanticipo = reader.GetString(2).ToString()
                'sumresto = reader.GetString(3).ToString()
                conexionMysql.Close()
            Catch ex As Exception
            End Try
            Dim inc As Integer
            inc = yy(17)
            'Try
            cerrarconexion()
            conexionMysql.Open()
                Dim Sql1 As String
            Sql1 = "select idventa,idcliente, total, anticipo,resto from servicios_ventas where fecha between '" & lbfechaapertura.Text & "' and '" & lbfechacierre.Text & "';"
            Dim cmd1 As New MySqlCommand(Sql1, conexionMysql)
                reader = cmd1.ExecuteReader()

            For j = 0 To i - 1
                reader.Read()

                'MsgBox(j)

                inc = inc + incremento

                idventa = reader.GetString(0).ToString()
                idcliente = reader.GetString(1).ToString()
                total = reader.GetString(2).ToString()
                anticipo = reader.GetString(3).ToString()
                resto = reader.GetString(4).ToString()
                ' MsgBox(idventa)
                'MsgBox("valosr de j:" & j)
                'a = venta.grillaventa.Item(j, 3).Value.ToString()
                'actividad = grilla.Rows(j).Cells(1).Value 'descripcion
                'cantidad = grilla.Rows(j).Cells(2).Value 'cantidad
                'costo = grilla.Rows(j).Cells(3).Value 'costo
                'idproducto = grilla.Rows(j).Cells(5).Value
                'comentario = grilla.Rows(j).Cells(6).Value
                'cant_f_ob = grilla.Rows(j).Cells(7).Value
                'cerrarconexion()
                'conexionMysql.Open()

                'MsgBox("el producto es:" & actividad)

                'Dim Sql2 As String
                'Sql2 = "INSERT INTO ventaind (actividad, cantidad, costo, idventa,idproducto) VALUES ('" & actividad & "'," & cantidad & "," & costo & "," & lbfolio.Text & ",'" & idproducto & "');"
                'Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
                'cmd2.ExecuteNonQuery()
                'conexionMysql.Close()


                prFont = New Font(f_tipo, tfuente3, FontStyle.Bold)
                e.Graphics.DrawString(idventa & "---" & idcliente & "--- $" & total & "---$" & anticipo & "---$" & resto, prFont, Brushes.Black, x, inc + 14)



                'prFont = New Font("Arial", 10, FontStyle.Bold)
                'e.Graphics.DrawString(cantidad & "-- $" & (CDbl(costo) * CDbl(cantidad)), prFont, Brushes.Black, 0, t3)

                't1 = t1 + (incremento * 3.2) + cant_f_ob
                't2 = t2 + (incremento * 3.2) + cant_f_ob
                't3 = t3 + (incremento * 3.2) + cant_f_ob





            Next
            conexionMysql.Close()
            ' Catch ex As Exception
            'End Try

            Dim t1, t2, t3 As Integer

            t1 = inc + (incremento * 2)
            t2 = inc + (incremento * 3)
            t3 = inc + (incremento * 4)
            ' MsgBox("t1" & t1)

            'MsgBox("t2" & t2)

            'MsgBox("t3" & t3)
            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
            e.Graphics.DrawString("=============================", prFont, Brushes.Black, 0, t1)



            prFont = New Font(f_tipo, tfuente3, FontStyle.Bold)
                e.Graphics.DrawString("   Totales---->$" & sumtotal, prFont, Brushes.Black, x, t2)
                prFont = New Font(f_tipo, tfuente3, FontStyle.Bold)
                e.Graphics.DrawString(" Anticipos---->$" & sumanticipo, prFont, Brushes.Black, x, t3)
            ' prFont = New Font(f_tipo, tfuente3, FontStyle.Bold)
            '   e.Graphics.DrawString("    Restos---->$" & sumresto, prFont, Brushes.Black, x, t3 + 14)

            prFont = New Font(f_tipo, tfuente, FontStyle.Bold)
                e.Graphics.DrawString("=============================", prFont, Brushes.Black, x, t3 + 28)
                prFont = New Font(f_tipo, tfuente3, FontStyle.Bold)
                e.Graphics.DrawString(saludo, prFont, Brushes.Black, x, t3 + 42)


        Catch ex As Exception
                MessageBox.Show("ERROR: " & ex.Message, "Administrador",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class