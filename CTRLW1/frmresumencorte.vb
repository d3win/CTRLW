Imports MySql.Data.MySqlClient


Public Class frmresumencorte
    Private Sub Frmresumencorte_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim usuario, idcorte As Integer


        conexionMysql.Open()
        Dim Sql111 As String
        Sql111 = "select max(idcorte) from corte;"
        Dim cmd111 As New MySqlCommand(Sql111, conexionMysql)
        reader = cmd111.ExecuteReader()
        reader.Read()

        idcorte = reader.GetString(0).ToString
        lbid.Text = idcorte

        conexionMysql.Close()



        conexionMysql.Open()
        Dim Sql1113 As String
        Sql1113 = "select * from corte where idcorte=" & idcorte & ";"
        Dim cmd1113 As New MySqlCommand(Sql1113, conexionMysql)
        reader = cmd1113.ExecuteReader()
        reader.Read()
        lbventatotal.Text = "$ " & reader.GetString(4).ToString

        lbfecha.Text = reader.GetString(5).ToString
        lbhora.Text = reader.GetString(6).ToString
        usuario = reader.GetString(7).ToString
        lbhorainicio.Text = reader.GetString(9).ToString
        lbhorafin.Text = reader.GetString(10).ToString
        lbobservacion.Text = reader.GetString(11).ToString
        lbcantproductos.Text = reader.GetString(13).ToString




        conexionMysql.Close()




        conexionMysql.Open()


        Dim Sql11 As String
        Sql11 = "select usuario from usuario where idusuario=" & usuario & ""
        Dim cmd11 As New MySqlCommand(Sql11, conexionMysql)
        reader = cmd11.ExecuteReader()
        reader.Read()
        lbusuario.Text = reader.GetString(0).ToString
        conexionMysql.Close()

    End Sub

    Private Sub frmresumencorte_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Or (e.KeyCode = Keys.Enter) Then
            Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'se hace la impresion del ticket
        imprimir()


    End Sub



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
        Dim ticketnombre, ticketcoloniaciudad, tickettelefono, ticketgiro As String
        Dim p1, p2, p3, p4 As String

        Dim idcorte As Integer
        Try
            conexionMysql.Open()
            Dim Sql111 As String
            Sql111 = "select max(idcorte) from corte;"
            Dim cmd111 As New MySqlCommand(Sql111, conexionMysql)
            reader = cmd111.ExecuteReader()
            reader.Read()
            idcorte = reader.GetString(0).ToString
            conexionMysql.Close()
        Catch ex As Exception
            MsgBox("pasa algo")
        End Try


        Dim totalventa As Double
        Dim observacion, fecharegistro, horaregistro, horainicio, horafin, cantproductos As String
        horainicio = ""
        horafin = ""
        Try


            conexionMysql.Open()
            Dim Sql111 As String
            Sql111 = "select * from corte where idcorte=" & idcorte & ";"
            Dim cmd111 As New MySqlCommand(Sql111, conexionMysql)
            reader = cmd111.ExecuteReader()
            reader.Read()
            totalventa = reader.GetString(4).ToString
            fecharegistro = reader.GetString(5).ToString
            horaregistro = reader.GetString(6).ToString
            horainicio = reader.GetString(9).ToString
            horafin = reader.GetString(10).ToString
            observacion = reader.GetString(11).ToString
            cantproductos = reader.GetString(13).ToString

            conexionMysql.Close()
        Catch ex As Exception
            MsgBox("pasa algo")
        End Try


        'Dim p1, p2, p3, p4 As String
        Try




            ' Try

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
            P1 = reader.GetString(14).ToString()
            P2 = reader.GetString(15).ToString()
            P3 = reader.GetString(16).ToString()
            P4 = reader.GetString(17).ToString()
            conexionMysql.Close()
            ' La fuente a usar
            Dim prFont As New Font("Arial", 15, FontStyle.Bold)
            ' la posición superior
            'imprimir el titutlo del ticket
            prFont = New Font("Arial", 14, FontStyle.Bold)
            e.Graphics.DrawString(ticketnombre, prFont, Brushes.Black, p1, 20)
            prFont = New Font("Arial", 7, FontStyle.Bold)
            e.Graphics.DrawString(ticketgiro, prFont, Brushes.Black, p2, 40)


            'imprimir el titutlo del ticket
            prFont = New Font("Arial", 7, FontStyle.Bold)
            e.Graphics.DrawString(ticketcoloniaciudad, prFont, Brushes.Black, p3, 55)
            'imprimir el titutlo del ticket
            prFont = New Font("Arial", 7, FontStyle.Bold)
            e.Graphics.DrawString(tickettelefono, prFont, Brushes.Black, p4, 70)



            prFont = New Font("Arial", 14, FontStyle.Bold)
            e.Graphics.DrawString("CORTE DE CAJA", prFont, Brushes.Black, 0, 80)


            prFont = New Font("Arial", 7, FontStyle.Bold)
            e.Graphics.DrawString("===================================", prFont, Brushes.Black, 0, 100)

            prFont = New Font("Arial", 7, FontStyle.Bold)
            e.Graphics.DrawString("USUARIO CORTE:" & lbusuario.Text, prFont, Brushes.Black, 0, 115)

            'imprimir el titutlo del ticket
            prFont = New Font("Arial", 7, FontStyle.Bold)
            e.Graphics.DrawString("FECHA:" & Date.Now, prFont, Brushes.Black, 0, 130)
            prFont = New Font("Arial", 18, FontStyle.Bold)
            e.Graphics.DrawString("FOLIO:" & idcorte, prFont, Brushes.Black, 0, 145)
            prFont = New Font("Arial", 7, FontStyle.Bold)
            e.Graphics.DrawString("===================================", prFont, Brushes.Black, 0, 185)

            'imprimir el titutlo del ticket
            prFont = New Font("Arial", 8, FontStyle.Bold)
            e.Graphics.DrawString("HORA INI:" & horainicio, prFont, Brushes.Black, 0, 195)
            prFont = New Font("Arial", 8, FontStyle.Bold)
            e.Graphics.DrawString("HORA FIN:" & horafin, prFont, Brushes.Black, 0, 205)
            prFont = New Font("Arial", 7, FontStyle.Bold)
            e.Graphics.DrawString("===================================", prFont, Brushes.Black, 0, 215)
            prFont = New Font("Arial", 8, FontStyle.Bold)
            e.Graphics.DrawString("VENTAS: $ " & totalventa, prFont, Brushes.Black, 0, 225)

            prFont = New Font("Arial", 8, FontStyle.Bold)
            e.Graphics.DrawString("Cant. Prod:" & cantproductos, prFont, Brushes.Black, 0, 235)
            prFont = New Font("Arial", 7, FontStyle.Bold)
            e.Graphics.DrawString("===================================", prFont, Brushes.Black, 0, 245)

            prFont = New Font("Arial", 7, FontStyle.Bold)
            e.Graphics.DrawString("===============CTRL+Y==============", prFont, Brushes.Black, 0, 255)
            'prFont = New Font("Arial", 7, FontStyle.Bold)
            'e.Graphics.DrawString("ctrl+y", prFont, Brushes.Black, 0, 265)


            'aqui es donde tenemos que leer todos los datos de la grilla llamada "grilla"


            'Dim i As Integer = grilla.RowCount
            'Dim t1, t2, t3, t4, t5 As Integer
            'Dim actividad As String
            'Dim cantidad, costo, idventa As Double
            'Dim idproducto As String

            't1 = 315
            't2 = 330
            't3 = 345
            't4 = 360

            ''suma de valores
            'For j = 0 To i - 2
            '    'MsgBox("valosr de j:" & j)
            '    'a = venta.grillaventa.Item(j, 3).Value.ToString()
            '    actividad = grilla.Rows(j).Cells(1).Value 'descripcion
            '    cantidad = grilla.Rows(j).Cells(2).Value 'cantidad
            '    costo = grilla.Rows(j).Cells(3).Value 'costo
            '    idproducto = grilla.Rows(j).Cells(5).Value
            '    'cerrarconexion()
            '    'conexionMysql.Open()

            '    'MsgBox("el producto es:" & actividad)

            'Dim Sql2 As String
            'Sql2 = "INSERT INTO ventaind (actividad, cantidad, costo, idventa,idproducto) VALUES ('" & actividad & "'," & cantidad & "," & costo & "," & lbfolio.Text & ",'" & idproducto & "');"
            'Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            'cmd2.ExecuteNonQuery()
            'conexionMysql.Close()

            'prFont = New Font("Arial", 10, FontStyle.Bold)
            '    e.Graphics.DrawString(actividad, prFont, Brushes.Black, 0, t1)

            '    prFont = New Font("Arial", 10, FontStyle.Bold)
            '    e.Graphics.DrawString(idproducto & "-- $" & costo & "--" & cantidad & "-- $" & (CDbl(costo) * CDbl(cantidad)), prFont, Brushes.Black, 0, t2)


            'prFont = New Font("Arial", 10, FontStyle.Bold)
            'e.Graphics.DrawString(cantidad & "-- $" & (CDbl(costo) * CDbl(cantidad)), prFont, Brushes.Black, 0, t3)

            '    t1 = t1 + 40
            '    t2 = t2 + 40
            'Next
            'prFont = New Font("Arial", 10, FontStyle.Bold)
            'e.Graphics.DrawString("---------------------------------", prFont, Brushes.Black, 0, t2 - 20)

            ''----------------AQUI SE IMPRIME EL TOTAL A PAGAR

            'prFont = New Font("Arial", 10, FontStyle.Bold)
            'e.Graphics.DrawString("TOTAL A PAGAR:----- $" & txttotalpagar.Text, prFont, Brushes.Black, 0, t2 - 10)


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

        End Try


    End Function
    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        imprimirventa()
    End Sub

    Function imprimirventa()


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
            'ex.ToString()
        End Try
    End Function

    Private Sub PrintDocument2_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument2.PrintPage
        'e.Graphics.DrawString(txtetiqueta1, New Font("verdana", 11, FontStyle.Bold), New SolidBrush(Color.Black), 1, 9)
        'e.Graphics.DrawString(txtetiqueta2, New Font("verdana", 9, FontStyle.Bold), New SolidBrush(Color.Black), 1, 28)
        'e.Graphics.DrawString(txtetiqueta, New Font("verdana", 13, FontStyle.Bold), New SolidBrush(Color.Black), 1, 57)
        'traemos la información del ticket, como encabezado, datos de la empresa etc.
        Dim ticketnombre, ticketcoloniaciudad, tickettelefono, ticketgiro, p1, p2, p3, p4 As String


        ' Try


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
            p1 = reader.GetString(14).ToString()
            p2 = reader.GetString(15).ToString()
            p3 = reader.GetString(16).ToString()
            p4 = reader.GetString(17).ToString()
            conexionMysql.Close()

        'Catch ex As Exception
        '  MsgBox("1")
        'End Try
        Dim valminimo, valmaximo, totalregistrosventa As Integer
        Dim dia, mes, año, fecha As String

        dia = Now.Day
        mes = Now.Month
        año = Now.Year

        fecha = año & "/" & mes & "/" & dia

        conexionMysql.Open()
        Dim Sql2 As String
        Sql2 = "select min(idventa), max(idventa) from venta where fecha='" & fecha & "' and hora between '" & lbhorainicio.Text & "' and '" & lbhorafin.Text & "';"
        Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
        reader = cmd2.ExecuteReader()
        reader.Read()
        valminimo = reader.GetString(0).ToString()
        valmaximo = reader.GetString(1).ToString()
        conexionMysql.Close()

        conexionMysql.Open()
        Dim Sql3 As String
        Sql3 = "select count(*) from ventaind where idventa between " & valminimo & " and " & valmaximo & ";"
        Dim cmd3 As New MySqlCommand(Sql3, conexionMysql)
        reader = cmd3.ExecuteReader()
        reader.Read()
        totalregistrosventa = reader.GetString(0).ToString()
        conexionMysql.Close()





        ' Try
        ' La fuente a usar
        Dim prFont As New Font("Arial", 15, FontStyle.Bold)
            ' la posición superior


            'imprimir el titutlo del ticket
            prFont = New Font("Arial", 14, FontStyle.Bold)
            e.Graphics.DrawString(ticketnombre, prFont, Brushes.Black, p1, 20)
            prFont = New Font("Arial", 7, FontStyle.Bold)
            e.Graphics.DrawString(ticketgiro, prFont, Brushes.Black, p2, 40)


            'imprimir el titutlo del ticket
            prFont = New Font("Arial", 7, FontStyle.Bold)
            e.Graphics.DrawString(ticketcoloniaciudad, prFont, Brushes.Black, p3, 55)
            'imprimir el titutlo del ticket
            prFont = New Font("Arial", 7, FontStyle.Bold)
            e.Graphics.DrawString(tickettelefono, prFont, Brushes.Black, p4, 70)


            prFont = New Font("Arial", 7, FontStyle.Bold)
            e.Graphics.DrawString("==================================", prFont, Brushes.Black, 0, 80)

            prFont = New Font("Arial", 7, FontStyle.Bold)
            e.Graphics.DrawString("USUARIO:" & frmindex.usuarioactual, prFont, Brushes.Black, 0, 95)

            'imprimir el titutlo del ticket
            'prFont = New Font("Arial", 7, FontStyle.Bold)
            'e.Graphics.DrawString("CLIENTE:" & txtcliente.Text, prFont, Brushes.Black, 0, 110)
            'prFont = New Font("Arial", 7, FontStyle.Bold)
            '125-140
            e.Graphics.DrawString("FECHA:" & Date.Now, prFont, Brushes.Black, 0, 110)
            prFont = New Font("Arial", 23, FontStyle.Bold)
            e.Graphics.DrawString("FOLIO/CORTE:" & lbid.Text, prFont, Brushes.Black, 40, 125)
            prFont = New Font("Arial", 7, FontStyle.Bold)
            e.Graphics.DrawString("IMPRESION VENTAS", prFont, Brushes.Black, 0, 145)
            prFont = New Font("Arial", 7, FontStyle.Bold)

            e.Graphics.DrawString("==================================", prFont, Brushes.Black, 0, 180)

            'imprimir el titutlo del ticket

            prFont = New Font("Arial", 6, FontStyle.Bold)
            e.Graphics.DrawString("ARTICULO", prFont, Brushes.Black, 0, 190)
            prFont = New Font("Arial", 6, FontStyle.Bold)
            e.Graphics.DrawString("ID-- PRECIO--CANTIDAD--TOTAL", prFont, Brushes.Black, 0, 200)

            prFont = New Font("Arial", 7, FontStyle.Bold)
            e.Graphics.DrawString("==================================", prFont, Brushes.Black, 0, 210)



            'aqui es donde tenemos que leer todos los datos de la grilla llamada "grilla"

            'Dim i As Integer = grilla.RowCount
            Dim t1, t2, t3, t4, t5 As Integer
            'Dim actividad As String
            'Dim cantidad, costo, idventa As Double
            'Dim idproducto As String


            'obtenemos la lista de productos vendidos desde la hora y fecha consultadas en el corte






            t1 = 220
            t2 = 228
            t3 = 260
            t4 = 275


            '-------------CONSULTAMOS LA INFORMACION DE LAS VENTAS ECHAS DEL CORTE REGISTRADO,
            '/ YA INDICANDO LAS FECHAS QUE SE MUESTRAS EN LOS LABELS DE LA MISMA VENTANA

            Dim idventaind, actividad, cantidad, costo, idventa As String

            conexionMysql.Open()
            Dim Sql4 As String
            Sql4 = "select * from ventaind where idventa between " & valminimo & " and " & valmaximo & ";"
            Dim cmd4 As New MySqlCommand(Sql4, conexionMysql)
            reader = cmd4.ExecuteReader()
        MsgBox("nada por aqui")

        For j = 1 To totalregistrosventa

                reader.Read()
                idventaind = reader.GetString(0).ToString()
                actividad = reader.GetString(1).ToString()
                cantidad = reader.GetString(2).ToString()
                costo = reader.GetString(3).ToString()
                idventa = reader.GetString(4).ToString()
            MsgBox(idventa)

            prFont = New Font("Arial", 6, FontStyle.Bold)
                e.Graphics.DrawString(actividad, prFont, Brushes.Black, 0, t1)

                prFont = New Font("Arial", 6, FontStyle.Bold)
                e.Graphics.DrawString(idventaind & "-- $" & costo & "--" & cantidad & "-- $" & (CDbl(costo) * CDbl(cantidad)), prFont, Brushes.Black, 0, t2)


                'prFont = New Font("Arial", 10, FontStyle.Bold)
                'e.Graphics.DrawString(cantidad & "-- $" & (CDbl(costo) * CDbl(cantidad)), prFont, Brushes.Black, 0, t3)

                t1 = t1 + 20
                t2 = t2 + 20
            Next
            conexionMysql.Close()

            prFont = New Font("Arial", 7, FontStyle.Bold)
            e.Graphics.DrawString("==================================", prFont, Brushes.Black, 0, t2 - 10)

            '----------------AQUI SE IMPRIME EL TOTAL A PAGAR

            'prFont = New Font("Arial", 6, FontStyle.Bold)
            'e.Graphics.DrawString("TOTAL A PAGAR: $" & txttotalpagar.Text, prFont, Brushes.Black, 0, t2)
            'prFont = New Font("Arial", 6, FontStyle.Bold)
            'e.Graphics.DrawString("PAGA CON: $" & lbpagacon.Text, prFont, Brushes.Black, 0, t2 + 10)
            'prFont = New Font("Arial", 6, FontStyle.Bold)
            'e.Graphics.DrawString("CAMBIO: $" & lbcambio.Text, prFont, Brushes.Black, 0, t2 + 20)

            prFont = New Font("Arial", 7, FontStyle.Bold)
            e.Graphics.DrawString("==================================", prFont, Brushes.Black, 0, t2)
            prFont = New Font("Arial", 7, FontStyle.Bold)
            e.Graphics.DrawString("¡Gracias por tu compra!", prFont, Brushes.Black, 0, t2 + 10)
            prFont = New Font("Arial", 7, FontStyle.Bold)
            e.Graphics.DrawString("ctrl+y", prFont, Brushes.Black, 10, t2 + 20)



        'Catch ex As Exception
        ' MessageBox.Show("ERROR: " & ex.Message, "Administrador",
        'MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Me.Width = 4729
        Dim formulario As New FRMNOTAVENTASCORTE
        formulario.ShowDialog()


    End Sub
End Class