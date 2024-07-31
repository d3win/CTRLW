Imports MySql.Data.MySqlClient

Public Class frVentaAdicional
    Private Sub Button69_Click(sender As Object, e As EventArgs) Handles Button69.Click
        frmindex.stxtdescripcion.Text = stxtdescripcion.Text
        Me.Close()
    End Sub

    Private Sub frVentaAdicional_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        stxtdescripcion.Text = frmindex.stxtdescripcion.Text
        lbfolio.Text = frmindex.stxtclave.Text
        cargartipovariable()
    End Sub
    Function cargartipovariable()

        'limpiar el combo para que no se duplique
        cbvaloradicional.Items.Clear()

        Try


            Dim cantidadvariable, i As Integer
            conexionMysql.Close()

            conexionMysql.Open()
            Dim Sql As String
            Sql = "select count(*)as contador from variableproducto where idproducto='" & lbfolio.Text & "';"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            reader = cmd.ExecuteReader()
            reader.Read()
            cantidadvariable = reader.GetString(0).ToString()

            conexionMysql.Close()




            conexionMysql.Open()
            Dim Sql2 As String
            Sql2 = "select variable from variableproducto where idproducto='" & lbfolio.Text & "';"
            Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            reader = cmd2.ExecuteReader()

            For i = 1 To cantidadvariable

                reader.Read()

                cbvaloradicional.Items.Add(reader.GetString(0).ToString())
            Next

            reader.Close()

            conexionMysql.Close()


        Catch ex As Exception

        End Try


    End Function

    Private Sub Button109_Click(sender As Object, e As EventArgs) Handles Button109.Click
        'concatenar dos valores
        Dim textocompleto As String

        textocompleto = stxtdescripcion.Text + " 
" + cbvaloradicional.Text
        stxtdescripcion.Text = textocompleto



    End Sub
End Class