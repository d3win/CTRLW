
Imports System
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO
Public Class print
    Dim txtetiqueta1, txtetiqueta2, txtetiqueta As String

    Private Sub Print_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        imprimir()

    End Sub

    Private Sub imprimir()
        txtetiqueta1 = " prueba de impresión"
        txtetiqueta2 = " Nº : " & "numero"
        txtetiqueta = " De : " & " 100 " & " €" &
        Chr(10) & " " & "12/12/!2"
        Try
            Dim PrintDialog1 As New PrintDialog
            PrintDialog1.Document = PrintDocument1
            PrintDialog1.PrinterSettings.PrinterName = "OneNote"
            If PrintDocument1.PrinterSettings.IsValid Then
                PrintDocument1.Print() 'Imprime texto 
            Else
                MessageBox.Show("La impresora no es valida")
            End If
            '--------------------------------------------------- 
        Catch ex As Exception
            MessageBox.Show("Hay un problema de impresión",
            ex.ToString())
        End Try

    End Sub
    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.DrawString(txtetiqueta1, New Font("verdana", 11, FontStyle.Bold), New SolidBrush(Color.Black), 1, 9)
        e.Graphics.DrawString(txtetiqueta2, New Font("verdana", 9, FontStyle.Bold), New SolidBrush(Color.Black), 1, 28)
        e.Graphics.DrawString(txtetiqueta, New Font("verdana", 13, FontStyle.Bold), New SolidBrush(Color.Black), 1, 57)
        Try
            ' La fuente a usar
            Dim prFont As New Font("Arial", 15, FontStyle.Bold)
            ' la posición superior

            'imprimimos la fecha y hora
            prFont = New Font("Arial", 10, FontStyle.Regular)
            e.Graphics.DrawString(Date.Now.ToShortDateString.ToString & " " &
                            Date.Now.ToShortTimeString.ToString, prFont, Brushes.Black, 15, 385)

            'imprimimos el nombre del cliente
            prFont = New Font("Arial", 25, FontStyle.Bold)
            e.Graphics.DrawString("Nombre del Cliente" & "PEdro1", prFont, Brushes.Black, 50, 250)


            'imprimimos el nombre del cliente
            prFont = New Font("Arial", 25, FontStyle.Bold)
            e.Graphics.DrawString("Nombre del Cliente" & "PEdro2", prFont, Brushes.Black, 0, 100)


            'imprimimos el nombre del cliente
            prFont = New Font("Arial", 25, FontStyle.Bold)
            e.Graphics.DrawString("Nombre del Cliente" & "PEdro3", prFont, Brushes.Black, 100, 150)

            'imprimimos la referencia del pedido
            e.Graphics.DrawString("Referencia", prFont, Brushes.Black, 50, 520)
            prFont = New Font("Arial", 18, FontStyle.Bold)
            e.Graphics.DrawString("Nombre de la Referencia", prFont, Brushes.Black, 50, 555)

            'imprimimos Pedido Ondupack y Pedido del cliente
            prFont = New Font("Arial", 22, FontStyle.Regular)
            e.Graphics.DrawString("Pedido", prFont, Brushes.Black, 50, 660)
            e.Graphics.DrawString("Palets", prFont, Brushes.Black, 250, 660)

            prFont = New Font("Arial", 24, FontStyle.Regular)
            e.Graphics.DrawString("19875", prFont, Brushes.Black, 50, 700)
            e.Graphics.DrawString("44", prFont, Brushes.Black, 250, 700)

            'imprimimos Cajas X Palet y Cajas x Paquete
            prFont = New Font("Arial", 22, FontStyle.Regular)
            e.Graphics.DrawString("Cajas x Palet", prFont, Brushes.Black, 50, 760)
            e.Graphics.DrawString("Cajas x Paquete", prFont, Brushes.Black, 250, 760)

            prFont = New Font("Arial", 24, FontStyle.Regular)
            e.Graphics.DrawString("500", prFont, Brushes.Black, 50, 800)
            e.Graphics.DrawString("32", prFont, Brushes.Black, 250, 800)

            'imprimimos el numero del Palet
            prFont = New Font("Arial", 24, FontStyle.Regular)
            e.Graphics.DrawString("Número del Palet     45", prFont, Brushes.Black, 50, 880)
            'indicamos que hemos llegado al final de la pagina
            e.HasMorePages = False

        Catch ex As Exception
            MessageBox.Show("ERROR: " & ex.Message, "Administrador",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class