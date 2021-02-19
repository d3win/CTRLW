Imports System.ComponentModel
Imports MySql.Data.MySqlClient

Public Class ADDclientes
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try

            conexionMysql.Open()
            Dim Sql As String
            Sql = "insert into cliente (nombre,ap,am,direccion,telefono,correo) values('" & ctxtnombre.Text & "','" & ctxtap.Text & "','" & ctxtam.Text & "','" & ctxtdireccion.Text & "','" & ctxttelefono.Text & "','" & ctxtcorreo.Text & "');"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            cmd.ExecuteNonQuery()
            'limpiamos los campos de cliente.
            conexionMysql.Close()
            MsgBox("Cliente registrado", MsgBoxStyle.Information, "Sistema")

            Me.Close()
        Catch ex As Exception
            MsgBox("Al parecer algún dato esta demasiado grande,verifica", MsgBoxStyle.Information, "CTRL+y")
        End Try

    End Sub

    Private Sub ADDclientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ADDclientes_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        servicios.txtcliente.Focus()

    End Sub

    Private Sub ADDclientes_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub ctxtnombre_TextChanged(sender As Object, e As EventArgs) Handles ctxtnombre.TextChanged

    End Sub

    Private Sub ctxtnombre_KeyDown(sender As Object, e As KeyEventArgs) Handles ctxtnombre.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub ctxtap_TextChanged(sender As Object, e As EventArgs) Handles ctxtap.TextChanged

    End Sub

    Private Sub ctxtap_KeyDown(sender As Object, e As KeyEventArgs) Handles ctxtap.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub ctxtam_TextChanged(sender As Object, e As EventArgs) Handles ctxtam.TextChanged

    End Sub

    Private Sub ctxtam_KeyDown(sender As Object, e As KeyEventArgs) Handles ctxtam.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub ctxttelefono_TextChanged(sender As Object, e As EventArgs) Handles ctxttelefono.TextChanged

    End Sub

    Private Sub ctxttelefono_KeyDown(sender As Object, e As KeyEventArgs) Handles ctxttelefono.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub
End Class