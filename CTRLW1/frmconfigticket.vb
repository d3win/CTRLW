
Imports MySql.Data.MySqlClient
Public Class frmconfigticket

    Private Sub Frmconfigticket_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            conexionMysql.Open()
            Dim Sql As String
            Sql = "select * from datos_empresa;"
            Dim cmd2 As New MySqlCommand(Sql, conexionMysql)
            reader = cmd2.ExecuteReader()
            reader.Read()
            p1.Text = reader.GetString(14).ToString()
            p2.Text = reader.GetString(15).ToString()
            p3.Text = reader.GetString(16).ToString()
            ' p4.Text = reader.GetString(17).ToString()
            conexionMysql.Close()
        Catch ex As Exception
            cerrarconexion()
            MsgBox("No hay datos de la empresa aun", MsgBoxStyle.Information, "CTRL+y")
        End Try



        Try

            conexionMysql.Open()
            Dim Sql As String
            Sql = "select f_titulo, f_contenido, f_tipo from datos_empresa;"
            Dim cmd2 As New MySqlCommand(Sql, conexionMysql)
            reader = cmd2.ExecuteReader()
            reader.Read()
            cbtitulo.Text = reader.GetString(0).ToString()
            cbcontenido.Text = reader.GetString(1).ToString()
            cbfuente.Text = reader.GetString(2).ToString()
            conexionMysql.Close()
        Catch ex As Exception
            cerrarconexion()
            MsgBox("No hay datos de la empresa aun", MsgBoxStyle.Information, "CTRL+y")
        End Try


    End Sub
    Function cerrarconexion()
        If conexionMysql.State = ConnectionState.Open Then
            conexionMysql.Close()

        End If
    End Function
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        'se imprime la prueba del ticket para ver si esta configurado correctamente
        imprimir()

    End Sub
    Dim txtetiqueta1, txtetiqueta2, txtetiqueta As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'almacenamos los valores dentro de la BD que serian las posiciones de las etiquetas


        Try
            conexionMysql.Open()

            Dim sql22 As String
            sql22 = "UPDATE datos_empresa SET p1=" & p1.Text & ", p2=" & p2.Text & ", p3=" & p3.Text & ";"
            Dim cmd22 As New MySqlCommand(sql22, conexionMysql)
            cmd22.ExecuteNonQuery()

            conexionMysql.Close()

            MsgBox("Valores actualizados", MsgBoxStyle.Information, "CTRL+y")

        Catch ex As Exception
            cerrarconexion()
        End Try

        Try
            conexionMysql.Open()
            Dim Sql As String
            Sql = "UPDATE `dwin`.`datos_empresa` SET `f_titulo` = '" & cbtitulo.Text & "', `f_contenido` = '" & cbcontenido.Text & "', `f_tipo` = '" & cbfuente.Text & "'  WHERE (`iddatos_empresa` = '1');"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            cmd.ExecuteNonQuery()
            conexionMysql.Close()
        Catch
            'MsgBox
            cerrarconexion()
        End Try


    End Sub

    Private Sub Pbabrir_Click(sender As Object, e As EventArgs) Handles pbabrir.Click
        Dim filename As String
        Dim file As New OpenFileDialog
        file.Filter = "Archivo jpg|*.jpg"
        If file.ShowDialog() = DialogResult.OK Then
            logoticket.Image = Image.FromFile(file.FileName)
            'String nombre = path.
            txtruta.Text = logoticket.ImageLocation
            filename = file.FileName
            txtruta.Text = file.FileName
            Me.logoticket.Image = Image.FromFile(filename)
            logoticket.Visible = True
        End If
    End Sub

    Private Function filename() As Object
        Throw New NotImplementedException()
    End Function

    Private Sub imprimir()
        'txtetiqueta1 = " prueba de impresión"
        'txtetiqueta2 = " Nº : " & lbfolio.Text
        'txtetiqueta = " De : " & "$" & txttotalpagar.Text &
        'Chr(10) & " " & "12/12/!2"


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
            MsgBox("No hay una impresora asignada al sistema", MsgBoxStyle.Information, "CTRL+y")
            cerrarconexion()

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
        Dim P1, P2, P3, P4 As Integer


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
            P1 = reader.GetString(14).ToString()
            P2 = reader.GetString(15).ToString()
            P3 = reader.GetString(16).ToString()
            ' P4 = reader.GetString(17).ToString()

            conexionMysql.Close()
        Catch ex As Exception
            MsgBox("Algo ocurrio mientras mandabamos a imprimir, revisa tu impresora", MsgBoxStyle.Information, "CTRL+y")
        End Try


        Try
            ' La fuente a usar
            Dim prFont As New Font("Arial", 15, FontStyle.Bold)
            ' la posición superior


            'imprimir el titutlo del ticket
            prFont = New Font("Arial", 24, FontStyle.Bold)
            e.Graphics.DrawString(ticketnombre, prFont, Brushes.Black, P1, 20)
            prFont = New Font("Arial", 14, FontStyle.Bold)
            e.Graphics.DrawString(ticketgiro, prFont, Brushes.Black, P2, 50)


            'imprimir el titutlo del ticket
            prFont = New Font("Arial", 14, FontStyle.Bold)
            e.Graphics.DrawString(ticketcoloniaciudad, prFont, Brushes.Black, P3, 70)
            'imprimir el titutlo del ticket
            prFont = New Font("Arial", 14, FontStyle.Bold)
            e.Graphics.DrawString(tickettelefono, prFont, Brushes.Black, P4, 90)


            prFont = New Font("Arial", 14, FontStyle.Bold)
            e.Graphics.DrawString("---------------------------------", prFont, Brushes.Black, 0, 110)

            prFont = New Font("Arial", 14, FontStyle.Bold)
            e.Graphics.DrawString("USUARIO: CTRL + Y", prFont, Brushes.Black, 0, 130)

            'imprimir el titutlo del ticket
            prFont = New Font("Arial", 14, FontStyle.Bold)
            e.Graphics.DrawString("CLIENTE: CLIENTE ", prFont, Brushes.Black, 0, 160)
            prFont = New Font("Arial", 14, FontStyle.Bold)
            e.Graphics.DrawString("FECHA:" & Date.Now, prFont, Brushes.Black, 0, 190)
            prFont = New Font("Arial", 30, FontStyle.Bold)
            e.Graphics.DrawString("FOLIO: 0000", prFont, Brushes.Black, 0, 220)
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

            Dim i As Integer = 1
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
                actividad = "Producto" 'descripcion
                cantidad = "000" 'cantidad
                costo = "$000" 'costo
                idproducto = "X"
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
            e.Graphics.DrawString("TOTAL A PAGAR:----- $ 000", prFont, Brushes.Black, 0, t2 - 10)


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
End Class