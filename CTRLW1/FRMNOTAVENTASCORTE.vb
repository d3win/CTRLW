Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class FRMNOTAVENTASCORTE
    Private Sub FRMNOTAVENTASCORTE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Private Sub FRNOTAVENTA_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Try



        'buscamos primero el id de venta para ver si existe

        '--------------------------------------------
        'Dim idventa As String
        'conexionMysql.Open()
        'Dim Sql556 As String
        'Sql556 = "select idventa from venta where ideventa= '" & frmindex.rptid.Text & "';"
        'Dim cmd556 As New MySqlCommand(Sql556, conexionMysql)
        'reader = cmd556.ExecuteReader()
        'reader.Read()
        ''Try

        'idventa = reader.GetString(0).ToString
        ''Catch ex As Exception
        'conexionMysql.Close()
        '    idventa = 0
        'End Try

        'conexionMysql.Close()
        ''-----------------------------------

        'If idventa = 0 Then
        '    MsgBox("No existe el folio de venta", MsgBoxStyle.Exclamation, "CTRL+y")
        'Else



        Dim fechacompleta As String
            fechacompleta = frmindex.calendario.SelectionRange.Start.ToString("yyyy/MM/dd")


            '' MsgBox(frmindex.lbfolio.Text)
            '' MsgBox(frmindex.indexidusuario)
            '-----------------------------------
            'Dim claveusuario As String
            'conexionMysql.Open()
            'Dim Sql55 As String
            'Sql55 = "select idcliente from venta where idventa=" & frmindex.rptid.Text & ";"
            'Dim cmd55 As New MySqlCommand(Sql55, conexionMysql)
            'reader = cmd55.ExecuteReader()
            'reader.Read()

            'claveusuario = reader.GetString(0).ToString

            'conexionMysql.Close()
            '-----------------------------------


            MsgBox(fechacompleta)
            '-------------------
            'DATOS DEL TIPO DE USUARIO
            conexionMysql.Open()
            Dim ds As DataSet
            Dim Sql As String
            'Sql = "select venta.idventa, (venta.cantidad) as cantidad1,(venta.total) as total1,venta.fecha,venta.hora, ventaind.actividad, (ventaind.cantidad)  as cantidad2,ventaind.costo,ventaind.idproducto, concat(cliente.nombre,' ',cliente.ap,' ', cliente.am)as cliente, (ventaind.cantidad * ventaind.costo) as totalind from venta,ventaind,cliente where venta.idventa=" & frmindex.indexidventa & " and ventaind.idventa=" & frmindex.indexidventa & " and venta.idcliente=" & frmindex.indexidusuario & ";"
            Sql = "select venta.idventa, ventaind.idventaind, ventaind.actividad, ventaind.cantidad, ventaind.costo,(ventaind.cantidad * ventaind.costo) as Total, ventaind.idproducto, venta.hora, sum(venta.anticipo) sumatotal from ventaind, venta where ventaind.idventa = venta.idventa and fecha='" & fechacompleta & "';"

            'venta.idventa = ventaind.idventa And ventaind.idventa = 26 And cliente.idcliente = venta.idcliente And venta.idcliente = 2
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            Dim dt As New DataTable
            Dim da As New MySqlDataAdapter(cmd)
            'cargamos el formulario  resumen
            'da.Fill(dt)
            ds = New DataSet()
            da.Fill(ds)
            conexionMysql.Close()
            '------------------


            '-----------------------------------
            'DATOS DE LA EMPRESA
            conexionMysql.Open()
            Dim ds2 As DataSet
            Dim Sql2 As String
            Sql2 = "select nombre,calle_numero,colonia_ciudad,cp,estado,telefono,whatsapp,correo,fanpage,sitio_web,director,horario,giro, saludo_nota from datos_empresa;"
            Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            Dim dt2 As New DataTable
            Dim da2 As New MySqlDataAdapter(cmd2)
            'cargamos el formulario  resumen
            'da.Fill(dt)
            ds2 = New DataSet()
            da2.Fill(ds2)
            conexionMysql.Close()

            '.-----------------------------------
            conexionMysql.Open()
            Dim ds23 As DataSet
            Dim Sql23 As String
            Sql23 = "select logo from logo_empresa"
            Dim cmd23 As New MySqlCommand(Sql23, conexionMysql)
            Dim dt23 As New DataTable
            Dim da23 As New MySqlDataAdapter(cmd23)
            'cargamos el formulario  resumen
            'da.Fill(dt)
            ds23 = New DataSet()
            da23.Fill(ds23)
            conexionMysql.Close()

            '------------------------------------

            conexionMysql.Open()
            Dim ds24 As DataSet
            Dim Sql24 As String
        Sql24 = "select * from caja where fecha='" & fechacompleta & "';"
        'Sql24 = "select venta.idventa, (venta.cantidad) as cantidad1,(venta.total) as total1,venta.fecha,venta.hora, ventaind.actividad, (ventaind.cantidad)  as cantidad2,ventaind.costo,ventaind.idproducto, concat(cliente.nombre,' ',cliente.ap,' ', cliente.am)as cliente, (ventaind.cantidad * ventaind.costo) as totalind from venta,ventaind,cliente where venta.idventa=" & frmindex.indexidventa & " and ventaind.idventa=" & frmindex.indexidventa & " and venta.idcliente=" & frmindex.indexidusuario & ";"
        'Sql = "select venta.idventa, ventaind.idventaind, ventaind.actividad, ventaind.cantidad, ventaind.costo,(ventaind.cantidad * ventaind.costo) as Total, ventaind.idproducto, venta.hora, sum(venta.anticipo) sumatotal from ventaind, venta where ventaind.idventa = venta.idventa and fecha='" & fechacompleta & "';"

        'venta.idventa = ventaind.idventa And ventaind.idventa = 26 And cliente.idcliente = venta.idcliente And venta.idcliente = 2
        Dim cmd24 As New MySqlCommand(Sql24, conexionMysql)
            Dim dt24 As New DataTable
            Dim da24 As New MySqlDataAdapter(cmd24)
            'cargamos el formulario  resumen
            'da.Fill(dt)
            ds24 = New DataSet()
            da24.Fill(ds24)
            conexionMysql.Close()

        ' Dim rds As New ReportDataSource("DTCERRARCAJA", ds.Tables(0))

        Dim rds2 As New ReportDataSource("dsdatos_empresa", ds2.Tables(0))
            Dim rds3 As New ReportDataSource("dslogo", ds23.Tables(0))
        Dim rds4 As New ReportDataSource("DTCERRARCAJA", ds24.Tables(0))

        ReportViewer1.LocalReport.DataSources.Clear()              'limpio la fuente de datos
        'ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewer1.LocalReport.DataSources.Add(rds2)
            ReportViewer1.LocalReport.DataSources.Add(rds3)
        ReportViewer1.LocalReport.DataSources.Add(rds4)


        Me.ReportViewer1.RefreshReport()

            'End If


            '        imprimirnotaventa()
            '  Me.ReportViewer1.RefreshReport()
            Me.ReportViewer1.RefreshReport()
        ' Catch ex As Exception
        If conexionMysql.State = ConnectionState.Open Then
                conexionMysql.Close()

            End If
            MsgBox("No existe el folio de venta", MsgBoxStyle.Exclamation, "CTRL+y")
        'End Try


        Me.ReportViewer1.RefreshReport()
    End Sub

End Class