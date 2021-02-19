Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        'Dim cmd1 As New MySqlCommand(sql1, conexionMysql)
        'reader = cmd1.ExecuteReader


        ' datos1()
        'datos2()

        'Dim sql As String
        'Dim cn As MySqlConnection
        'Dim cm As MySqlCommand
        'Dim da As MySqlDataAdapter


        '-------------------
        'DATOS DEL TIPO DE USUARIO
        conexionMysql.Open()
        Dim ds As DataSet
        Dim Sql As String
        Sql = "select venta.idventa, (venta.cantidad) as cantidad1,(venta.total) as total1,venta.fecha,venta.hora, ventaind.actividad, (ventaind.cantidad)  as cantidad2,ventaind.costo,ventaind.idproducto, concat(cliente.nombre,' ',cliente.ap,' ', cliente.am)as cliente, (ventaind.cantidad * ventaind.costo) as totalind from venta,ventaind,cliente where venta.idventa=7 and ventaind.idventa=7 and venta.idcliente=2;"
        Dim cmd As New MySqlCommand(sql, conexionMysql)
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
        Dim cmd2 As New MySqlCommand(sql2, conexionMysql)
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
        '-----------------------------------------
        'dgv.datasource = ds.Tables(0).DefaultView



        'Me.ReportViewer1.RefreshReport()

        '-------
        '-------
        '-------
        '-------
        '-------
        '-------
        '-------
        '-------
        '-------
        '-------

        'sql = "select * from tipo_usuario"
        'cn = New MySqlConnection("Data Source=servidor;Database=base_de_datos;User ID=usuario; Password=clave; Allow Zero Datetime=True; CHARSET=latin1")
        'conexionMysql.Open()

        'cm = New MySqlCommand()
        'cm.CommandText = sql
        'cm.CommandType = CommandType.Text
        'cm.Connection = conexionMysql
        'cm.Parameters.Add("?curso", MySqlDbType.Int32)
        'cm.Parameters("?curso").Value = 2006
        'da = New MySqlDataAdapter(cm)



        '-----------------------------------
        'Dim sql2 As String
        ''Dim cn As MySqlConnection
        'Dim cm2 As MySqlCommand
        'Dim da2 As MySqlDataAdapter
        'Dim ds2 As DataSet

        'sql2 = "select nombre,calle_numero from datos_empresa;"
        ''cn = New MySqlConnection("Data Source=servidor;Database=base_de_datos;User ID=usuario; Password=clave; Allow Zero Datetime=True; CHARSET=latin1")
        'conexionMysql.Open()

        'cm2 = New MySqlCommand()
        'cm2.CommandText = sql2
        'cm2.CommandType = CommandType.Text
        'cm2.Connection = conexionMysql
        ''cm.Parameters.Add("?curso", MySqlDbType.Int32)
        ''cm.Parameters("?curso").Value = 2006
        'da2 = New MySqlDataAdapter(cm2)

        'ds2 = New DataSet()
        'da2.Fill(ds2)
        'conexionMysql.Close()


    End Sub
    Function datos1()



        Dim sql As String
        'Dim cn As MySqlConnection
        Dim cm As MySqlCommand
        Dim da As MySqlDataAdapter
        Dim ds As DataSet

        sql = "select * from tipo_usuario"
        'cn = New MySqlConnection("Data Source=servidor;Database=base_de_datos;User ID=usuario; Password=clave; Allow Zero Datetime=True; CHARSET=latin1")
        conexionMysql.Open()

        cm = New MySqlCommand()
        cm.CommandText = sql
        cm.CommandType = CommandType.Text
        cm.Connection = conexionMysql
        'cm.Parameters.Add("?curso", MySqlDbType.Int32)
        'cm.Parameters("?curso").Value = 2006
        da = New MySqlDataAdapter(cm)

        ds = New DataSet()
        da.Fill(ds)

        conexionMysql.Close()

        '-----------------------------------
        Dim sql2 As String
        'Dim cn As MySqlConnection
        Dim cm2 As MySqlCommand
        Dim da2 As MySqlDataAdapter
        Dim ds2 As DataSet

        sql2 = "select nombre,calle_numero from datos_empresa"
        'cn = New MySqlConnection("Data Source=servidor;Database=base_de_datos;User ID=usuario; Password=clave; Allow Zero Datetime=True; CHARSET=latin1")
        conexionMysql.Open()

        cm2 = New MySqlCommand()
        cm2.CommandText = sql2
        cm2.CommandType = CommandType.Text
        cm2.Connection = conexionMysql
        'cm.Parameters.Add("?curso", MySqlDbType.Int32)
        'cm.Parameters("?curso").Value = 2006
        da2 = New MySqlDataAdapter(cm2)

        ds2 = New DataSet()
        da2.Fill(ds2)

        Dim rds2 As New ReportDataSource("DataSet2", ds2.Tables(0))
        '.-----------------------------------

        Dim rds As New ReportDataSource("DataSet1", ds.Tables(0))
        ReportViewer1.LocalReport.DataSources.Clear()              'limpio la fuente de datos
        ReportViewer1.LocalReport.DataSources.Add(rds)
        Me.ReportViewer1.RefreshReport()
        'dgv.datasource = ds.Tables(0).DefaultView
        conexionMysql.Close()
    End Function
    Function datos2()
        Dim sql As String
        'Dim cn As MySqlConnection
        Dim cm2 As MySqlCommand
        Dim da2 As MySqlDataAdapter
        Dim ds2 As DataSet

        sql = "select nombre,calle_numero from datos_empresa"
        'cn = New MySqlConnection("Data Source=servidor;Database=base_de_datos;User ID=usuario; Password=clave; Allow Zero Datetime=True; CHARSET=latin1")
        conexionMysql.Open()

        cm2 = New MySqlCommand()
        cm2.CommandText = sql
        cm2.CommandType = CommandType.Text
        cm2.Connection = conexionMysql
        'cm.Parameters.Add("?curso", MySqlDbType.Int32)
        'cm.Parameters("?curso").Value = 2006
        da2 = New MySqlDataAdapter(cm2)

        ds2 = New DataSet()
        da2.Fill(ds2)

        Dim rds2 As New ReportDataSource("DataSet2", ds2.Tables(0))
        'dgv.datasource = ds.Tables(0).DefaultView
        ReportViewer1.LocalReport.DataSources.Clear()              'limpio la fuente de datos
        ReportViewer1.LocalReport.DataSources.Add(rds2)
        conexionMysql.Close()
    End Function
End Class