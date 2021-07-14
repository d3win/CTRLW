Imports System.IO
Imports MySql.Data.MySqlClient
Public Class FRMNuevoproducto
    Private Sub FRMNuevoproducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarproveedor()
        cargartiposervicio()
    End Sub
    Function cerrarconexion()
        If conexionMysql.State = ConnectionState.Open Then
            conexionMysql.Close()

        End If
    End Function
    Function cargartiposervicio()

        'limpiar el combo para que no se duplique
        txttipoproducto.Items.Clear()

        Try


            Dim cantidadtiposervicio, i As Integer
            cerrarconexion()

            conexionMysql.Open()
            Dim Sql As String
            Sql = "select count(*)as contador from tipoproducto;"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            reader = cmd.ExecuteReader()
            reader.Read()
            cantidadtiposervicio = reader.GetString(0).ToString()

            conexionMysql.Close()


            cerrarconexion()

            conexionMysql.Open()
            Dim Sql2 As String
            Sql2 = "select * from tipoproducto;"
            Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            reader = cmd2.ExecuteReader()

            For i = 1 To cantidadtiposervicio

                reader.Read()

                txttipoproducto.Items.Add(reader.GetString(1).ToString())
            Next

            reader.Close()

            conexionMysql.Close()


        Catch ex As Exception

        End Try


    End Function
    Function cargarproveedor()

        'limpiar el combo para que no se duplique
        txtproveedor.Items.Clear()

        Try


            Dim cantidadproveedor, i As Integer
            cerrarconexion()

            conexionMysql.Open()
            Dim Sql As String
            Sql = "select count(*)as contador from proveedor;"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            reader = cmd.ExecuteReader()
            reader.Read()
            cantidadproveedor = reader.GetString(0).ToString()

            conexionMysql.Close()


            cerrarconexion()

            conexionMysql.Open()
            Dim Sql2 As String
            Sql2 = "select * from proveedor;"
            Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
            reader = cmd2.ExecuteReader()

            For i = 1 To cantidadproveedor

                reader.Read()

                txtproveedor.Items.Add(reader.GetString(1).ToString())
            Next

            reader.Close()

            conexionMysql.Close()


        Catch ex As Exception

        End Try


    End Function

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        Dim res As Integer
        res = 1
        If txttipoproducto.Text = "" Or txtproveedor.Text = "" Or txtclavep.Text = "" Or txtactividadp.Text = "" Or txtcantidadp.Text = "" Or txtprecioindividualp.Text = "" Or txtpreciomayoreop.Text = "" Or txtpzasmayoreop.Text = "" Then
            MsgBox("Hace falta información", MsgBoxStyle.Exclamation, "Sistema")
        Else
            'Try
            Dim clave As String
            cerrarconexion()
            'consulto que el ID no exista para poder ingresar uno nuevo
            conexionMysql.Open()
            Dim Sql As String
            Sql = "select idproducto from producto where idproducto='" & txtclavep.Text & "';"
            Dim cmd As New MySqlCommand(Sql, conexionMysql)
            reader = cmd.ExecuteReader()
            reader.Read()
            Try
                clave = reader.GetString(0).ToString
            Catch ex As Exception
                clave = ""
            End Try
            cerrarconexion()

            conexionMysql.Close()
            'comprobar si devolvio null o un valor real
            If clave = txtclavep.Text Then
                MsgBox("La clave del producto ya existe, asigna un nuevo valor", MsgBoxStyle.Exclamation, "Sistema")
                'Catch ex As Exception
                res = 0
            End If


            'End Try

            '----------------------------------------- obtener id de proveedor
            Dim idproveedor As Integer
            cerrarconexion()

            conexionMysql.Open()
            Dim Sql5 As String
            Sql5 = "select idproveedor from proveedor where nombre_empresa='" & txtproveedor.Text & "';"
            Dim cmd5 As New MySqlCommand(Sql5, conexionMysql)
            reader = cmd5.ExecuteReader()
            reader.Read()

            idproveedor = reader.GetString(0).ToString

            conexionMysql.Close()

            '----------------------------------------- obtener id de tipoproducto
            Dim idtipoproducto As Integer
            cerrarconexion()

            conexionMysql.Open()
            Dim Sql55 As String
            Sql55 = "select idtipoproducto from tipoproducto where tipo='" & txttipoproducto.Text & "';"
            Dim cmd55 As New MySqlCommand(Sql55, conexionMysql)
            reader = cmd55.ExecuteReader()
            reader.Read()

            idtipoproducto = reader.GetString(0).ToString

            conexionMysql.Close()


            If res <> 0 Then

                'me quede en donde tengo que guardar la cantidad de piezas por mayoreo
                Try

                    cerrarconexion()

                    conexionMysql.Open()

                    Dim sql2 As String
                    sql2 = "INSERT INTO producto (idproducto,descripcion, cantidad, costo, precio, preciom, idproveedor,idtipoproducto,cantidad_mayoreo) VALUES ('" & txtclavep.Text & "', '" & txtactividadp.Text & "', " & txtcantidadp.Text & ", " & txtcostop.Text & ", " & txtprecioindividualp.Text & ", " & txtpreciomayoreop.Text & "," & idproveedor & ", " & idtipoproducto & "," & txtpzasmayoreop.Text & ");"
                    Dim cmd2 As New MySqlCommand(sql2, conexionMysql)
                    cmd2.ExecuteNonQuery()

                    conexionMysql.Close()



                    '---------------------------------------------------------

                    MsgBox("Producto guardado", MsgBoxStyle.Information, "Sistema")
                    'se llena la grilla, tomando en cuenta ninguna elemento.
                    'txtnombrep.Text = ""
                    'Call llenadogrilla()

                Catch ex As Exception
                    MsgBox("Existe un problema al guardar al registro", MsgBoxStyle.Information, "Sistema")
                End Try

                Call limpiarp()

            End If

        End If
    End Sub
    Function limpiarp()
        txtclavep.Text = ""
        txtactividadp.Text = ""
        txtcantidadp.Text = ""
        txtprecioindividualp.Text = ""
        txtpreciomayoreop.Text = ""
        txtcostop.Text = ""
        txtproveedor.Text = ""



    End Function

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        limpiarp()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()


    End Sub
End Class