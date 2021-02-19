Imports MySql.Data.MySqlClient
Public Class FRagregaranticipo
    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        sumaranticipo()

    End Sub

    Function sumaranticipo()
        Try
            cerrarconexion()

            Dim anticipo, resto, total As Double
            conexionMysql.Open()
            Dim Sql2 As String
            Sql2 = "select * from venta where idventa=" & frmindex.stxtfoliobusquedaventa.Text & ";"
            Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            reader = cmd2.ExecuteReader()
            reader.Read()
            total = reader.GetString(2).ToString()
            anticipo = reader.GetString(8).ToString()
            resto = reader.GetString(9).ToString()
            conexionMysql.Close()


            '--------comprobamos que la suma no exceda el total


            If CDbl(txtcantidad.Text) > resto Then
                MsgBox("Se esta excediendo en el pago, solo te falta pagar: " & resto, MsgBoxStyle.Information, "CTRL+y")
            Else
                '-----------en caso contrario si no ha excedido se hace una actualizacion del registro a la BD

                anticipo = CDbl(anticipo) + CDbl(txtcantidad.Text)

                'MsgBox("Estas dando de anticipo un total de: " & anticipo)

                resto = CDbl(total) - CDbl(anticipo)

                'MsgBox("te resta de pago:" & resto)



                '--------------------------------------------------
                'INSERTAMOS EL REGISTRO DEL ANTICIPO QUE SE ESTA DANDO EN ESTE MOMENTO
                'PARA PODER IMPRIMIR UN HISTORIAL DE ANTICIPOS QUE SE ESTAN REALIZANDO

                Dim dia, mes, año, fecha As String
                Dim hora2, hora, minuto, segundo As String

                hora2 = Now.Hour()
                minuto = Now.Minute()
                segundo = Now.Second()

                hora = hora2 & ":" & minuto & ":" & segundo

                dia = Date.Now.Day
                mes = Date.Now.Month
                año = Date.Now.Year
                fecha = año & "-" & mes & "-" & dia
                cerrarconexion()
                conexionMysql.Open()






                Dim Sql2X As String
                Sql2X = "insert into servicios_ventas (idventa,fecha, hora, idcliente,anticipo,total) values('" & frmindex.stxtfoliobusquedaventa.Text & "', '" & fecha & "', '" & hora & "','" & frmindex.indexidusuario & "'," & txtcantidad.Text & "," & total & " )"
                Dim cmd2X As New MySqlCommand(Sql2X, conexionMysql)
                cmd2X.ExecuteNonQuery()
                conexionMysql.Close()


                '--------------------------------------------------

                conexionMysql.Open()
                Dim sql22 As String
                sql22 = "UPDATE venta SET anticipo=" & anticipo & ", resto=" & resto & "  WHERE idventa='" & frmindex.stxtfoliobusquedaventa.Text & "';"
                Dim cmd22 As New MySqlCommand(sql22, conexionMysql)
                cmd22.ExecuteNonQuery()

                conexionMysql.Close()

                MsgBox("Hemos actualizado la información del pago", MsgBoxStyle.Information, "CTRL+y")

                frmindex.picturepagado.Visible = False

                frmindex.stxtresto.Text = resto
                frmindex.stxtanticipo.Text = anticipo

                If total = anticipo Then
                    MsgBox("El servicio ha sido pagado completamente", MsgBoxStyle.Information, "CTRL+y")
                    frmindex.picturepagado.Visible = True

                End If

                'llamamos a la funcion imprimir de cualquier modo
                Dim formulario As New FRNOTAANTICIPOSERVICIO
                'FRagregaranticipo.ShowDialog()
                formulario.ShowDialog()

                'imprimir()



                Me.Close()



            End If


        Catch ex As Exception
            cerrarconexion()
        End Try


    End Function
    Function cerrarconexion()
        If conexionMysql.State = ConnectionState.Open Then
            conexionMysql.Close()

        End If
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
    Private Sub FRagregaranticipo_Load(sender As Object, e As EventArgs) Handles MyBase.Load



    End Sub

    Private Sub Txtcantidad_TextChanged(sender As Object, e As EventArgs) Handles txtcantidad.TextChanged

    End Sub

    Private Sub txtcantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtcantidad.KeyDown
        If e.KeyCode = Keys.Enter Then

            sumaranticipo()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()


        End If

    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        'e.Graphics.DrawString(txtetiqueta1, New Font("verdana", 11, FontStyle.Bold), New SolidBrush(Color.Black), 1, 9)
        'e.Graphics.DrawString(txtetiqueta2, New Font("verdana", 9, FontStyle.Bold), New SolidBrush(Color.Black), 1, 28)
        'e.Graphics.DrawString(txtetiqueta, New Font("verdana", 13, FontStyle.Bold), New SolidBrush(Color.Black), 1, 57)
        'traemos la información del ticket, como encabezado, datos de la empresa etc.
        Dim ticketnombre, ticketcoloniaciudad, tickettelefono, ticketgiro, p1, p2, p3, p4 As String


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
            p1 = reader.GetString(14).ToString()
            p2 = reader.GetString(15).ToString()
            p3 = reader.GetString(16).ToString()
            p4 = reader.GetString(17).ToString()
            conexionMysql.Close()

        Catch ex As Exception

        End Try

        Try
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
            prFont = New Font("Arial", 7, FontStyle.Bold)
            e.Graphics.DrawString("CLIENTE:" & frmindex.txtcliente.Text, prFont, Brushes.Black, 0, 110)
            prFont = New Font("Arial", 7, FontStyle.Bold)
            e.Graphics.DrawString("FECHA:" & Date.Now, prFont, Brushes.Black, 0, 125)
            prFont = New Font("Arial", 18, FontStyle.Bold)
            e.Graphics.DrawString("FOLIO:" & frmindex.slbfolio.Text, prFont, Brushes.Black, 0, 140)
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
            'Dim t1, t2, t3, t4, t5 As Integer
            'Dim actividad As String
            'Dim cantidad, costo, idventa As Double
            'Dim idproducto As String

            't1 = 220
            't2 = 228
            't3 = 260
            't4 = 275

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

            '    'Dim Sql2 As String
            '    'Sql2 = "INSERT INTO ventaind (actividad, cantidad, costo, idventa,idproducto) VALUES ('" & actividad & "'," & cantidad & "," & costo & "," & lbfolio.Text & ",'" & idproducto & "');"
            '    'Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            '    'cmd2.ExecuteNonQuery()
            '    'conexionMysql.Close()

            '    prFont = New Font("Arial", 6, FontStyle.Bold)
            '    e.Graphics.DrawString(actividad, prFont, Brushes.Black, 0, t1)

            '    prFont = New Font("Arial", 6, FontStyle.Bold)
            '    e.Graphics.DrawString(idproducto & "-- $" & costo & "--" & cantidad & "-- $" & (CDbl(costo) * CDbl(cantidad)), prFont, Brushes.Black, 0, t2)


            '    'prFont = New Font("Arial", 10, FontStyle.Bold)
            '    'e.Graphics.DrawString(cantidad & "-- $" & (CDbl(costo) * CDbl(cantidad)), prFont, Brushes.Black, 0, t3)

            '    t1 = t1 + 20
            '    t2 = t2 + 20
            'Next
            'prFont = New Font("Arial", 7, FontStyle.Bold)
            'e.Graphics.DrawString("==================================", prFont, Brushes.Black, 0, t2 - 10)

            ''----------------AQUI SE IMPRIME EL TOTAL A PAGAR

            'prFont = New Font("Arial", 6, FontStyle.Bold)
            'e.Graphics.DrawString("TOTAL A PAGAR: $" & txttotalpagar.Text, prFont, Brushes.Black, 0, t2)
            'prFont = New Font("Arial", 6, FontStyle.Bold)
            'e.Graphics.DrawString("PAGA CON: $" & lbpagacon.Text, prFont, Brushes.Black, 0, t2 + 10)
            'prFont = New Font("Arial", 6, FontStyle.Bold)
            'e.Graphics.DrawString("CAMBIO: $" & lbcambio.Text, prFont, Brushes.Black, 0, t2 + 20)

            'prFont = New Font("Arial", 7, FontStyle.Bold)
            'e.Graphics.DrawString("==================================", prFont, Brushes.Black, 0, t2 + 30)
            'prFont = New Font("Arial", 7, FontStyle.Bold)
            'e.Graphics.DrawString("¡Gracias por tu compra!", prFont, Brushes.Black, 0, t2 + 40)
            'prFont = New Font("Arial", 7, FontStyle.Bold)
            'e.Graphics.DrawString("ctrl+y", prFont, Brushes.Black, 10, t2 + 50)



        Catch ex As Exception
            MessageBox.Show("ERROR: " & ex.Message, "Administrador",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Ch1_CheckedChanged(sender As Object, e As EventArgs) Handles ch1.CheckedChanged
        Dim anticipo, resto, total As Double
        conexionMysql.Open()
        Dim Sql2 As String
        Sql2 = "select * from venta where idventa=" & frmindex.stxtfoliobusquedaventa.Text & ";"
        Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
        reader = cmd2.ExecuteReader()
        reader.Read()
        total = reader.GetString(2).ToString()
        anticipo = reader.GetString(8).ToString()
        resto = reader.GetString(9).ToString()
        conexionMysql.Close()
        If ch1.Checked = True Then
            txtcantidad.Text = resto
        ElseIf ch1.Checked = False Then
            txtcantidad.Text = ""
        End If
    End Sub
End Class