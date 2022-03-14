Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class FRNOTASERVICIO
    Private Sub FRNOTASERVICIO_Load(sender As Object, e As EventArgs) Handles MyBase.Load





        'MsgBox(frmindex.slbfolio.Text)
        'MsgBox(frmindex.indexidusuario)
        '-------------------



        '-------------------
        '
        conexionMysql.Open()
        Dim ds As DataSet
        Dim Sql As String
        Sql = "select venta.idventa, (venta.cantidad)as cantidad1,venta.total,venta.fecha,venta.hora,venta.fechaentrega,venta.anticipo,venta.resto,venta.idsecotizacion, ventaind.actividad,(ventaind.cantidad)as cantidad2,ventaind.costo,ventaind.descripcion, ventaind.idproducto, (ventaind.costo * ventaind.cantidad)as total2 from venta,ventaind where venta.idventa=ventaind.idventa and venta.idventa=" & frmindex.slbfolio.Text & ";"
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
        'EL LOGOTIPO
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
        '-------------------
        'DATOS DEL usuario
        conexionMysql.Open()
        Dim ds24 As DataSet
        Dim Sql24 As String
        Sql24 = "select nombre,ap,am,direccion,telefono,correo,rfc from cliente where idcliente=" & frmindex.indexidusuario & ";"
        Dim cmd24 As New MySqlCommand(Sql24, conexionMysql)
        Dim dt24 As New DataTable
        Dim da24 As New MySqlDataAdapter(cmd24)
        'cargamos el formulario  resumen
        'da.Fill(dt)
        ds24 = New DataSet()
        da24.Fill(ds24)
        conexionMysql.Close()
        '------------------


        'conexionMysql.Open()

        'Dim idtipo_pago As String
        ''MsgBox("el producto es:" & matriz(x, 0))
        'Dim Sql6 As String
        ''consultamos cuantos registros se insertaros para posteriormente actualizarlos en su registro original
        'Sql6 = "SELECT tipo_pago.tipo from tipo_pago,venta where tipo_pago.idtipo_pago=venta.idtipo_pago and venta.idventa=" & frmindex.indexidusuario & ";"
        'Dim cmd6 As New MySqlCommand(Sql6, conexionMysql)
        'reader = cmd6.ExecuteReader()

        'reader.Read()
        ''guardamos los valores en una matriz
        'idtipo_pago = reader.GetString(0).ToString()
        'conexionMysql.Close()



        '------------------------------------
        '-------------------
        'DATOS DEL tipo de pago
        conexionMysql.Open()
        Dim ds25 As DataSet
        Dim Sql25 As String
        Sql25 = "SELECT tipo_pago.tipo from tipo_pago,venta where tipo_pago.idtipo_pago=venta.idtipo_pago and venta.idventa=" & frmindex.slbfolio.Text & ";"
        Dim cmd25 As New MySqlCommand(Sql25, conexionMysql)
        Dim dt25 As New DataTable
        Dim da25 As New MySqlDataAdapter(cmd25)
        'cargamos el formulario  resumen
        'da.Fill(dt)
        ds25 = New DataSet()
        da25.Fill(ds25)
        conexionMysql.Close()
        '------------------


        Dim rds As New ReportDataSource("dsservicio", ds.Tables(0))
        Dim rds2 As New ReportDataSource("dsdatos_empresa", ds2.Tables(0))
        Dim rds3 As New ReportDataSource("dslogo", ds23.Tables(0))
        Dim rds4 As New ReportDataSource("dscliente", ds24.Tables(0))
        Dim rds5 As New ReportDataSource("dstipo_pago", ds25.Tables(0))

        ReportViewer1.LocalReport.DataSources.Clear()              'limpio la fuente de datos
        ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewer1.LocalReport.DataSources.Add(rds2)
        ReportViewer1.LocalReport.DataSources.Add(rds3)
        ReportViewer1.LocalReport.DataSources.Add(rds4)
        ReportViewer1.LocalReport.DataSources.Add(rds5)

        ' Me.ReportViewer1.RefreshReport()
        ' MsgBox("intentando imprimir directo")
        'Me.ReportViewer1.PrinterSettings.PrinterName = ""
        'Me.ReportViewer1.Print()
        Me.ReportViewer1.RefreshReport()



        ' LocalReport Report2 = New LocalReport()



        'Me.ReportViewer1.PrintDialog()
        'Me.ReportViewer1.Clear()
        'Me.ReportViewer1.LocalReport.ReleaseSandboxAppDomain()

    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load

    End Sub
End Class