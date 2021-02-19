Imports MySql.Data.MySqlClient

Public Class FRMverdevoluciones
    Private Sub MonthCalendar1_DateChanged(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        Dim fecha As String

        Try

            fecha = MonthCalendar1.SelectionRange.Start.ToString("yyyy/MM/dd")


            conexionMysql.Open()
            Dim Sql As String
            Sql = "select * from devolucion where fecha='" & fecha & "';"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            Dim dt As New DataTable
            Dim da As New MySqlDataAdapter(cmd)
            'cargamos el formulario  resumen
            da.Fill(dt)
            frmindex.cgrillacorte.DataSource = dt
            'grilla2.Columns(1).Width = 350
            'grilla2.Columns(0).Width = 60
            conexionMysql.Close()

        Catch ex As Exception

        End Try






    End Sub

    Private Sub MonthCalendar1_KeyDown(sender As Object, e As KeyEventArgs) Handles MonthCalendar1.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Hide()

        End If
    End Sub

    Private Sub FRMverdevoluciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim fecha As String

        Try

            fecha = Now.Year & "-" & Now.Month & "-" & Now.Day


            conexionMysql.Open()
            Dim Sql As String
            Sql = "select * from devolucion where fecha='" & fecha & "';"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            Dim dt As New DataTable
            Dim da As New MySqlDataAdapter(cmd)
            'cargamos el formulario  resumen
            da.Fill(dt)
            frmindex.cgrillacorte.DataSource = dt
            'grilla2.Columns(1).Width = 350
            'grilla2.Columns(0).Width = 60
            conexionMysql.Close()

        Catch ex As Exception

        End Try




    End Sub
End Class