Imports MySql.Data.MySqlClient
Imports System.IO
Public Class FRMPASS
    Public conexionMysqlx, conexionMysqlx2 As New MySqlConnection
    Public reader As MySqlDataReader

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button53_Click(sender As Object, e As EventArgs) Handles Button53.Click
        '------------- CONECTAR AL SERVIDOR ---------------------------
        Dim lineas As New ArrayList()
        Dim carpeta As String
        Dim servidor, port, puerto, bd As String

        carpeta = Environment.GetFolderPath(Environment.SpecialFolder.Personal)

        Dim freader As New StreamReader(carpeta & "\SISTEMANOBORRAR.txt")

        servidor = freader.ReadLine() 'leo primera linea
        port = freader.ReadLine() 'leo primera linea
        'MsgBox(port)
        'servidor = "localhost"
        'MsgBox(servidor)
        'MsgBox(contenido) 'pego primera linea
        bd = "dwin" 'leo segunda linea
        'user = freader.ReadLine()
        'pass = freader.ReadLine()
        puerto = port
        'MsgBox(contenido) 'pego segunda linea


        user = "root"
        pass = txtpassactual.Text



        'freader.Close()
        '-------------------------------------------------------------------------
        If conexionMysqlx.State = ConnectionState.Open Then
            conexionMysqlx.Close()

        End If

        conexionMysqlx.ConnectionString = "Server=" & servidor & "; DataBase=" & bd & "; UID=" & user & "; PWD=" & pass & "; Port=" & puerto & ";"
        'conexionMysql.ConnectionString = "Server=localhost; DataBase=dwin; UID=root; PWD=; Port=3306"
        conexionMysqlx2.ConnectionString = "Server=" & servidor & "; DataBase=mysql; UID=" & user & "; PWD=" & pass & "; Port=" & puerto & ";"


        '        nombreusuario = user

        'd1 = servidor
        'd2 = bd
        'd3 = user
        'd4 = pass
        'd5 = puerto
        Try

            conexionMysqlx.Open()

            conexionMysqlx.Close()


            'si se abre y cierra la conexion continuamos para actualizar

            If txtpassnuevo.Text = txtpassnuevore.Text Then



                conexionMysqlx.Open()
                Dim Sql2 As String
                Sql2 = "use mysql;"
                Dim cmd2 As New MySqlCommand(Sql2, conexionMysqlx)
                cmd2.ExecuteNonQuery()
                conexionMysqlx.Close()

                conexionMysqlx2.Open()
                Dim Sql21 As String
                Sql21 = "update user set password=PASSWORD('" & txtpassnuevo.Text & "') where User='root';"
                Dim cmd21 As New MySqlCommand(Sql21, conexionMysqlx2)
                cmd21.ExecuteNonQuery()
                conexionMysqlx2.Close()

                conexionMysqlx2.Open()
                Dim Sql22 As String
                Sql22 = "flush privileges;"
                Dim cmd22 As New MySqlCommand(Sql22, conexionMysqlx2)
                cmd22.ExecuteNonQuery()
                conexionMysqlx2.Close()

                MsgBox("Contraseña actualizada correctamente", MsgBoxStyle.Information, "CTRL+y")

                MsgBox("El sistema se cerrará", MsgBoxStyle.Information, "CTRL+y")
                End


            Else
                MsgBox("Las contraseñas no coinciden", MsgBoxStyle.Information, "CTRL+y")
            End If


        Catch ex As Exception

            MsgBox("Contraseña incorrecta", MsgBoxStyle.Exclamation, "CTRLY")


        End Try




    End Sub
End Class