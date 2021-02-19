Imports MySql.Data.MySqlClient
Public Class busquedafolio
    Dim nombre As String
    Public idventaservicioextra As Integer



    Function buscarfolioservicio()
        Dim tipoventa As Integer
        ' Try
        cerrarconexion()
            conexionMysql.Open()
            Dim Sql2 As String
            Sql2 = "select * from venta where idventa=" & txtfolioservicio.Text & ";"
            Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            reader = cmd2.ExecuteReader()
            reader.Read()
            idventaservicioextra = reader.GetString(0).ToString()
            tipoventa = reader.GetString(10).ToString()
            conexionMysql.Close()

            If tipoventa = 1 Then
                'MsgBox("El folio corresponde a una venta de productos no de servicios", MsgBoxStyle.Information, "CTRL+y")
                lbmensaje.Visible = True

            ElseIf tipoventa = 2 Then
            'en caso de que el tipo de venta sea de 2 entonces significa que si es un servicio y lo buscamos y cargamos
            '----cargamos el folio a la ventana de servicios de la ventana de servicios
            lbmensaje.Visible = False
            servicios.txtfoliobusquedaventa.Text = txtfolioservicio.Text
            servicios.folioventabusqueda = txtfolioservicio.Text
            MsgBox("servicios.txtfoliobusquedaventa.text")
            MsgBox(servicios.txtfoliobusquedaventa.Text)


            MsgBox("txtfolioservicio.text")
            MsgBox(txtfolioservicio.Text)
            servicios.cargarfolioventa()
                Me.Close()


            End If


        'Catch ex As Exception
        'MsgBox("Folio de venta no encontrado", MsgBoxStyle.Information, "CTRL+y")
        cerrarconexion()
        'End Try

    End Function
    Function cerrarconexion()
        If conexionMysql.State = ConnectionState.Open Then
            conexionMysql.Close()
        End If
    End Function
    Private Sub txtfolioservicio_TextChanged(sender As Object, e As EventArgs) Handles txtfolioservicio.TextChanged
        If txtfolioservicio.Text = "" Then
            lbmensaje.Visible = False
        End If

    End Sub

    Private Sub busquedafolio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbmensaje.Visible = False

    End Sub

    Private Sub busquedafolio_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown


    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        buscarfolioservicio()
    End Sub

    Private Sub txtfolioservicio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtfolioservicio.KeyDown
        If e.KeyCode = Keys.Enter Then

            buscarfolioservicio()

        End If
    End Sub
End Class