Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class FRNOTAVENTA
    Private Sub FRNOTAVENTA_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        '' MsgBox(frmindex.lbfolio.Text)
        '' MsgBox(frmindex.indexidusuario)
        ''-----------------------------------
        'conexionMysql.Open()
        'Dim Sql55 As String
        'Sql55 = "select idcliente from venta where idventa=46;"
        'Dim cmd55 As New MySqlCommand(Sql55, conexionMysql)
        'reader = cmd55.ExecuteReader()
        'reader.Read()

        'idtipoproducto = reader.GetString(0).ToString

        'conexionMysql.Close()
        ''-----------------------------------



        '-------------------
        'DATOS DEL TIPO DE USUARIO
        conexionMysql.Open()
        Dim ds As DataSet
        Dim Sql As String
        'Sql = "select venta.idventa, (venta.cantidad) as cantidad1,(venta.total) as total1,venta.fecha,venta.hora, ventaind.actividad, (ventaind.cantidad)  as cantidad2,ventaind.costo,ventaind.idproducto, concat(cliente.nombre,' ',cliente.ap,' ', cliente.am)as cliente, (ventaind.cantidad * ventaind.costo) as totalind from venta,ventaind,cliente where venta.idventa=" & frmindex.indexidventa & " and ventaind.idventa=" & frmindex.indexidventa & " and venta.idcliente=" & frmindex.indexidusuario & ";"
        Sql = "select venta.idventa, (venta.cantidad) as cantidad1,(venta.total) as total1,venta.fecha,venta.hora, ventaind.actividad, (ventaind.cantidad)  as cantidad2,ventaind.costo,ventaind.idproducto, concat(cliente.nombre,' ',cliente.ap,' ', cliente.am)as cliente, (ventaind.cantidad * ventaind.costo) as totalind, ventaind.descripcion from venta,ventaind,cliente where venta.idventa = ventaind.idventa And ventaind.idventa = " & frmindex.indexidventa & " And cliente.idcliente = venta.idcliente And venta.idcliente = " & frmindex.indexidusuario & ";"

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

        Dim rds As New ReportDataSource("dsventapro", ds.Tables(0))
        Dim rds2 As New ReportDataSource("dsdatos_empresa", ds2.Tables(0))
        Dim rds3 As New ReportDataSource("dslogo", ds23.Tables(0))

        ReportViewer1.LocalReport.DataSources.Clear()              'limpio la fuente de datos
        ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewer1.LocalReport.DataSources.Add(rds2)
        ReportViewer1.LocalReport.DataSources.Add(rds3)

        Me.ReportViewer1.RefreshReport()




        '        imprimirnotaventa()
        '  Me.ReportViewer1.RefreshReport()

    End Sub
    Function imprimirnotaventa()
        Dim dt As New DataTable

        With dt

            .Columns.Add("idventa")
            .Columns.Add("total")
            .Columns.Add("fecha")
            .Columns.Add("hora")
            .Columns.Add("cliente")
            .Columns.Add("idproducto")
            .Columns.Add("actividad")
            .Columns.Add("cantidad")
            .Columns.Add("costo")
            .Columns.Add("totalpro")

        End With

        For Each row As DataGridViewRow In frmindex.DataGridView1.Rows

            dt.Rows.Add(row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(4).Value, row.Cells(5).Value, row.Cells(6).Value, row.Cells(7).Value, row.Cells(8).Value, row.Cells(9).Value)

        Next


        ReportViewer1.LocalReport.DataSources.Item(0).Value = dt

        'FRNOTAVENTA.ShowDialog()

        Me.Dispose()

    End Function

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load

    End Sub
End Class