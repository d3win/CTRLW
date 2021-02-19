Imports System.ComponentModel
Imports MySql.Data.MySqlClient
Public Class frmconfigurarluz
    Private Sub Frmconfigurarluz_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try


            conexionMysql.Open()
            Dim contador As String

            Dim Sql2 As String
            Sql2 = "select * from luzserigrafia;"
            Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            reader = cmd2.ExecuteReader()
            reader.Read()
            txtcostobimestral.Text = reader.GetString(1).ToString()
            txtdiasusado.Text = reader.GetString(2).ToString()
            txtcostodiasusado.Text = reader.GetString(3).ToString()
            txtcostohorasusado.Text = reader.GetString(4).ToString()
            txtcostofinal.Text = reader.GetString(5).ToString()

            frmgastosgralesserigrafia.txttotalluz.Text = txtcostofinal.Text

            conexionMysql.Close()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Txtdiasusado_TextChanged(sender As Object, e As EventArgs) Handles txtdiasusado.TextChanged
        costodias()

    End Sub
    Function costodias()
        Try
            Dim valor As Double
            valor = CDbl(txtcostobimestral.Text) / CDbl(txtdiasusado.Text)
            txtcostodiasusado.Text = Math.Round(valor, 2)
        Catch ex As Exception

        End Try

    End Function

    Private Sub Txtcostobimestral_TextChanged(sender As Object, e As EventArgs) Handles txtcostobimestral.TextChanged
        costodias()
        costohora()


    End Sub

    Private Sub Txtcostohorasusado_TextChanged(sender As Object, e As EventArgs) Handles txtcostohorasusado.TextChanged
        costohora()

    End Sub
    Function costohora()
        Try
            Dim valor As Double
            valor = CDbl(txtcostodiasusado.Text) / CDbl(txtcostohorasusado.Text)

            txtcostofinal.Text = Math.Round(valor, 2)
        Catch ex As Exception

        End Try

    End Function

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
    Function cerrarconexion()
        If conexionMysql.State = ConnectionState.Open Then
            conexionMysql.Close()

        End If
    End Function
    Private Sub Button78_Click(sender As Object, e As EventArgs) Handles Button78.Click




        cerrarconexion()


        'verificar que no existan registros
        conexionMysql.Open()
        Dim contador As String

        Dim Sql2 As String
        Sql2 = "select count(*) from luzserigrafia;"
        Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
        reader = cmd2.ExecuteReader()
        reader.Read()
        contador = reader.GetString(0).ToString()
        conexionMysql.Close()


        If contador = 0 Then
            conexionMysql.Open()


            'comprobar que las cajas no esten vacias

            If txtcostofinal.Text <> "0" Then



                Dim Sql As String
                'Sql = "INSERT INTO corte (`extras`, `fecha_registro`, `hora_registro`,`idusuario`,`compra` ) VALUES ('" & totalcorteventa & "', '" & fecha & "', '" & hora & "'," & idusuario & "," & totalcortecompra & ");"
                Sql = "INSERT INTO `dwin`.`luzserigrafia` (`idluzserigrafia`, `costo_bimestre`, `dias`, `costo_diario`, `horas_trabajadas`, `costohorastrabajo`) VALUES ('1', '" & txtcostobimestral.Text & "', '" & txtdiasusado.Text & "', '" & txtcostodiasusado.Text & "', '" & txtcostohorasusado.Text & "', '" & txtcostofinal.Text & "');"
                Dim cmd As New MySqlCommand(Sql, conexionMysql)
                cmd.ExecuteNonQuery()
                conexionMysql.Close()
                MsgBox("Registro guardado", MsgBoxStyle.Information, "CTRL+y")
                frmgastosgralesserigrafia.llenadoluz()
                Me.Close()
            Else

            End If


        Else
            conexionMysql.Open()
            Dim Sql3 As String
            Sql3 = "update luzserigrafia set costo_bimestre='" & txtcostobimestral.Text & "', dias='" & txtdiasusado.Text & "', costo_diario='" & txtcostodiasusado.Text & "', horas_trabajadas='" & txtcostohorasusado.Text & "', costohorastrabajo='" & txtcostofinal.Text & "';"
            Dim cmd3 As New MySqlCommand(Sql3, conexionMysql)
            cmd3.ExecuteNonQuery()
            conexionMysql.Close()
            'frmgastosgralesserigrafia.txttotalluz.Text = txtcostofinal.Text

            MsgBox("Información actualizada", MsgBoxStyle.Information, "CTRL+y")
            frmgastosgralesserigrafia.llenadoluz()

            Me.Close()

        End If


    End Sub

    Private Sub frmconfigurarluz_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing


    End Sub

    Private Sub frmconfigurarluz_Closed(sender As Object, e As EventArgs) Handles Me.Closed

    End Sub

    Private Sub Txtcostofinal_TextChanged(sender As Object, e As EventArgs) Handles txtcostofinal.TextChanged

        frmgastosgralesserigrafia.txttotalluz.Text = txtcostofinal.Text

    End Sub

    Private Sub txtcostobimestral_KeyDown(sender As Object, e As KeyEventArgs) Handles txtcostobimestral.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()


        End If
    End Sub
    Function salir()

    End Function

    Private Sub txtdiasusado_KeyDown(sender As Object, e As KeyEventArgs) Handles txtdiasusado.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()


        End If
    End Sub

    Private Sub txtcostohorasusado_KeyDown(sender As Object, e As KeyEventArgs) Handles txtcostohorasusado.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()


        End If
    End Sub
End Class