Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class informe1
    Private Sub Informe1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Me.ReportViewer2.RefreshReport()


        Dim dt As New DataTable
        Dim da As New MySqlDataAdapter("select * from tipo_corte", conexionMysql)
        da.Fill(dt)

        ReportViewer2.LocalReport.DataSources.Clear()
        Dim rpt As New ReportDataSource("tipo_corte", dt)
        ReportViewer2.LocalReport.DataSources.Add(rpt)
        ReportViewer2.RefreshReport()


    End Sub
End Class