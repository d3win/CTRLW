Imports System.ComponentModel
Imports MySql.Data.MySqlClient
Public Class frmclienteadeudopagar
    Public idfoliocliente, idcliente As Integer
    Private Sub Frmclienteadeudopagar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        idcliente = frmindex.ctxtidcliente.Text
        idfoliocliente = frmindex.txtclientefolioservicio.Text


        idvinil = idfoliocliente

        'MsgBox(idvinil)
        '-----------IMPORTANTE------------------------------------
        'el idfoliocliente es el folio de la venta del servicio
        '-----------IMPORTANTE------------------------------------

        Dim adeudo As Double


        adeudo = frmindex.txtclienteadeudo.Text

        If adeudo = "0" Then
            txtcantidad.Text = 0
            txtcantidad.Enabled = False
            ch1.Enabled = False

        Else
            txtcantidad.Enabled = True
            ch1.Enabled = True

        End If





    End Sub
    Function cerrarconexion()
        If conexionMysql.State = ConnectionState.Open Then
            conexionMysql.Close()

        End If
    End Function
    Function sumaranticipo()
        'Try
        cerrarconexion()

        'MsgBox(frmcotizadorvinil.stxtfoliobusquedaventa.Text,,)

        Dim anticipo, resto, total As Double
        conexionMysql.Open()
        Dim Sql2 As String
        Sql2 = "select * from venta where idventa=" & idfoliocliente & ";"
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
            Sql2X = "insert into servicios_ventas (idventa,fecha, hora, idcliente,anticipo,total) values('" & idfoliocliente & "', '" & fecha & "', '" & hora & "','" & idcliente & "'," & txtcantidad.Text & "," & total & " )"
            Dim cmd2X As New MySqlCommand(Sql2X, conexionMysql)
            cmd2X.ExecuteNonQuery()
            conexionMysql.Close()


            '--------------------------------------------------

            conexionMysql.Open()
            Dim sql22 As String
            sql22 = "UPDATE venta SET anticipo=" & anticipo & ", resto=" & resto & "  WHERE idventa='" & idfoliocliente & "';"
            Dim cmd22 As New MySqlCommand(sql22, conexionMysql)
            cmd22.ExecuteNonQuery()

            conexionMysql.Close()

            MsgBox("Hemos actualizado la información del pago", MsgBoxStyle.Information, "CTRL+y")

            'frmcotizadorvinil.picturepagado.Visible = False



            frmindex.txtclienteadeudo.Text = resto
            'frmcotizadorvinil.stxtanticipo1.Text = anticipo

            'frmcotizadorvinil.TextBox2.Text = anticipo


            If total = anticipo Then
                MsgBox("El servicio ha sido pagado completamente", MsgBoxStyle.Information, "CTRL+y")
                'frmcotizadorvinil.picturepagado.Visible = True
            End If

            'llamamos a la funcion imprimir de cualquier modo
            ' imprimir()

            'llamamos a la funcion imprimir de cualquier modo
            Dim formulario As New FRMANTICIPOSERVICIOVINIL
            'FRagregaranticipo.ShowDialog()
            formulario.ShowDialog()

            'imprimir()





            'frmcotizadorvinil.Label15.Focus()

            'frmcotizadorvinil.txtfoliobusqueda.Text = frmcotizadorvinil.stxtfoliobusquedaventa.Text
            'FRagregaranticipovinil.stxtfoliobusquedaventa.Text
            'frmcotizadorvinil.recargarfolioventa()
            frmindex.cargarhistorialventascliente()
            Me.Close()



        End If

        'Catch ex As Exception
        cerrarconexion()
        'End Try

        idtimer = 1
        ' MsgBox("idtimer" & idtimer)
    End Function

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        sumaranticipo()

    End Sub

    Private Sub Txtcantidad_TextChanged(sender As Object, e As EventArgs) Handles txtcantidad.TextChanged

    End Sub

    Private Sub Ch1_CheckedChanged(sender As Object, e As EventArgs) Handles ch1.CheckedChanged
        Try

            Dim anticipo, resto, total As Double
            conexionMysql.Open()
            Dim Sql2 As String
            Sql2 = "select * from venta where idventa=" & idfoliocliente & ";"
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
        Catch ex As Exception
            cerrarconexion()
        End Try

    End Sub

    Private Sub txtcantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtcantidad.KeyDown
        If e.KeyCode = Keys.Enter Then

            sumaranticipo()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()


        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()

    End Sub

    Private Sub frmclienteadeudopagar_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()


        End If
    End Sub
End Class