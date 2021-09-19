Imports MySql.Data.MySqlClient
Public Class FRabrircaja

    Function cerrarconexion()
        If conexionMysql.State = ConnectionState.Open Then
            conexionMysql.Close()

        End If
    End Function
    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        abrircaja()

    End Sub
    Function abrircaja()
        If txtmontoinicial.Text = "" Then
            MsgBox("Ingresa el valor inicial del sistema", MsgBoxStyle.Information, "CTRL+y")
        Else
            Try


                Dim estado As Integer
                Dim registrar As Boolean
                'buscamos si hay ya abierta una caja, osea un registro de tal hora y tal fecha
                'Try
                Dim hora, fecha, fechahoy, fechaatras, dia, mes, año As String
                dia = Date.Now.Day
                mes = Date.Now.Month
                año = Date.Now.Year
                fecha = año & "-" & mes & "-" & dia



                Dim hora2, minuto, segundo As String
                Dim horax As String
                'MsgBox("holaaaaaaaaaaaaaaaaaaaa")


                hora2 = Now.Hour()
                minuto = Now.Minute()
                segundo = Now.Second()

                horax = hora2 & ":" & minuto & ":" & segundo

                '--------------------------------------------------------
                Try

                    conexionMysql.Open()
                    Dim sql2 As String
                    sql2 = "select * from caja where fecha='" & fecha & "' and estado='0';"
                    Dim cmd2 As New MySqlCommand(sql2, conexionMysql)
                    reader = cmd2.ExecuteReader
                    reader.Read()
                    fechahoy = reader.GetString(0).ToString()
                    conexionMysql.Close()
                    registrar = False
                    MsgBox("Existe ya un registro abierto, primero cierra tu cuenta de caja", MsgBoxStyle.Exclamation, "CTRL+y")
                    Me.Close()

                Catch ex As Exception
                    registrar = True
                End Try

                'MsgBox(registrar)
                'si registrar es verdadero, significa que no hay ninguna caja abierta, todas estan cerradas
                If registrar = True Then

                    'primero verificamos que no exista ningun registro realizado en tal fecha y tal hora.

                    cerrarconexion()

                    conexionMysql.Open()
                    'se registra el valor
                    Dim Sql2X As String
                    Sql2X = "INSERT INTO `dwin`.`caja` (`monto_inicial`, `fecha`, `hora_inicial`, `estado`) VALUES ('" & txtmontoinicial.Text & "', '" & fecha & "', '" & horax & "', '0');"
                    Dim cmd2X As New MySqlCommand(Sql2X, conexionMysql)
                    cmd2X.ExecuteNonQuery()
                    conexionMysql.Close()



                    MsgBox("Registro almacenado", MsgBoxStyle.Information, "CTRL+y")
                    ' MsgBox("aqui")
                    imprimirabrircaja()

                    Me.Close()
                    frmindex.btnabrircajamenu.Visible = False
                    frmindex.btncerrarcajamenu.Visible = True
                Else

                    '--------------------------------------------------------
                    'conexionMysql.Open()
                    'Dim sql As String
                    'sql = "select max(idcaja), estado from caja where fecha='" & fecha & "';"
                    'Dim cmd As New MySqlCommand(sql, conexionMysql)
                    'reader = cmd.ExecuteReader
                    'reader.Read()
                    'estado = reader.GetString(0).ToString()
                    'conexionMysql.Close()
                    ''--------------------------------------------------------
                End If
                'Catch ex As Exception
                ' MsgBox("Existe un problema con la entrada de información", MsgBoxStyle.Information, "CTRL+y")
                'End Try

            Catch ex As Exception
                cerrarconexion()
            End Try

        End If



    End Function


    Private Sub imprimirabrircaja()

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
            '   ex.ToString()
        End Try

    End Sub
    'Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

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
        cerrarconexion()
        '----------------------------------------
        'NUEVA CONSULTA MAYO 2021
        'CONSULTAMOS ID MAXIMO DE LA TABLA CAJA.
        Dim idmaximo As Integer
        conexionMysql.Open()
        Dim Sql1x1 As String
        Sql1x1 = "SELECT max(idcaja)as maximo from caja where estado=0;"
        Dim cmd1x1 As New MySqlCommand(Sql1x1, conexionMysql)
        reader = cmd1x1.ExecuteReader()
        reader.Read()
        idmaximo = reader.GetString(0).ToString()
        cerrarconexion()
        '---------------------------------------------------------------------------------------------------




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
            e.Graphics.DrawString("FOLIO:" & idmaximo, prFont, Brushes.Black, p3, yy(11))
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
                Sql1 = "SELECT * from caja where idcaja='" & idmaximo & "';"
                Dim cmd1 As New MySqlCommand(Sql1, conexionMysql)
                reader = cmd1.ExecuteReader()
                reader.Read()

                monto_inicial = reader.GetString(1).ToString()
                monto_final = "-"
                existencia_caja = "-"
                fechainicial = reader.GetString(4).ToString()
                hora_inicial = reader.GetString(5).ToString()
                hora_final = "-"
                observaciones = "-"
                venta_rapida = "-"
                anticipos = "-"
                compras = "-"
                total_deberia_existir = "-"
                diferencia = "-"
                ganancia = "-"
                fecha_cierre = "-"
                conexionMysql.Close()

            Catch ex As Exception

            End Try

            f1 = Format(CDate(fechainicial), "dd/MM/yyyy")
            '           f2 = Format(CDate(fecha_cierre), "dd/MM/yyyy")

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
            e.Graphics.DrawString("========APERTURA CAJA========", prFont, Brushes.Black, x, yy(32))
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

    Function cargarlogoticket()



        Dim ruta As String
        Try
            'verificamos que exista al menos 1 registro, en caso de que exista 0, indicamos que el valor es 0;

            Dim lineas As New ArrayList()
            Dim carpeta As String
            Dim rutaImagen As String

            carpeta = Environment.GetFolderPath(Environment.SpecialFolder.Personal)

            Dim freader As New IO.StreamReader(carpeta & "\rutaImagenNoBorrar.txt")

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
    Private Sub FRabrircaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtmontoinicial.Focus()
        cargarlogoticket()

    End Sub

    Private Sub Btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Me.Close()

    End Sub

    Private Sub Txtmontoinicial_TextChanged(sender As Object, e As EventArgs) Handles txtmontoinicial.TextChanged

    End Sub

    Private Sub txtmontoinicial_KeyDown(sender As Object, e As KeyEventArgs) Handles txtmontoinicial.KeyDown
        If e.KeyCode = Keys.Enter Then
            abrircaja()
        End If
    End Sub
End Class