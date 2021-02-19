Imports MySql.Data.MySqlClient
Public Class Frmdevoluciones

    Private Sub Frmdevoluciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Function cerrarconexion()
        If conexionMysql.State = ConnectionState.Open Then
            conexionMysql.Close()

        End If
    End Function
    Function limpiarcajas()
        txtcantidad.Text = ""
        txtclaveproducto.Text = ""
        txtdescripcion.Text = ""

        txtprecio.Text = ""
        txttotal.Text = ""
        'txttotalpagar.Text = ""
        'txttotalpagarantes.Text = ""

    End Function
    'Private Sub txtfolio_TextChanged(sender As Object, e As EventArgs)
    '    buscarfolioventa()
    'End Sub
    Function buscarfolioventa()
        If txtfolio.Text = "" Then

            ''en caso de que no eista ningun valor dentro de la caja de texto enttonces limpiamos las cajas
            limpiarcajas()




        Else

            txtfolioproducto.Text = ""


            Try

                Dim cantidad As Integer

                respuesta = vbYes


                cerrarconexion()


                conexionMysql.Open()
                Dim Sql As String
                Sql = "select ventaind.idventaind, ventaind.actividad,ventaind.cantidad, ventaind.costo, (ventaind.costo*ventaind.cantidad)as total, venta.fecha, venta.hora from ventaind, venta where ventaind.idventa=venta.idventa and venta.idventa=" & txtfolio.Text & ";"
                Dim cmd As New MySqlCommand(Sql, conexionMysql)
                Dim dt As New DataTable
                Dim da As New MySqlDataAdapter(cmd)
                'cargamos el formulario  resumen
                da.Fill(dt)
                grilla.DataSource = dt
                'grilla2.Columns(1).Width = 350
                'grilla2.Columns(0).Width = 60
                conexionMysql.Close()

                conexionMysql.Open()
                Dim Sql2 As String
                Sql2 = "select total from venta where idventa=" & txtfolio.Text & ";"
                Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
                reader = cmd2.ExecuteReader()
                reader.Read()
                'txttotalpagarantes.Text = reader.GetString(0).ToString()
                conexionMysql.Close()




            Catch ex As Exception
                'txttotalpagarantes.Text = ""
                'MsgBox("Problema al generar la busqueda")
            End Try

        End If
    End Function
    Private Sub grilla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub



    'Private Sub txtfolioproducto_TextChanged(sender As Object, e As EventArgs)
    '    buscarproducto()
    'End Sub
    Function buscarproducto()
        If txtfolioproducto.Text = "" Then

            ''en caso de que no eista ningun valor dentro de la caja de texto enttonces limpiamos las cajas
            limpiarcajas()




        Else
            txtfolio.Text = ""


            Try

                Dim dia, mes, año As Integer

                Dim fecha As String


                dia = datetimer.Value.Day
                mes = datetimer.Value.Month
                año = datetimer.Value.Year

                fecha = año & "-" & mes & "-" & dia



                respuesta = vbYes


                cerrarconexion()


                conexionMysql.Open()
                Dim Sql As String
                Sql = "select * from ventaind,venta where venta.idventa=ventaind.idventa and ventaind.idproducto='" & txtfolioproducto.Text & "' and venta.fecha='" & fecha & "';"
                Dim cmd As New MySqlCommand(Sql, conexionMysql)
                Dim dt As New DataTable
                Dim da As New MySqlDataAdapter(cmd)
                'cargamos el formulario  resumen
                da.Fill(dt)
                grilla.DataSource = dt
                'grilla2.Columns(1).Width = 350
                'grilla2.Columns(0).Width = 60
                conexionMysql.Close()




            Catch ex As Exception
                'txttotalpagarantes.Text = ""
                'MsgBox("Problema al generar la busqueda")
            End Try

        End If
    End Function




    Function comprobaciondevolucion(ByVal folio As Integer)
        Dim respuesta As Boolean
        Dim conteo, i, a As Integer

        conteo = grilla2.RowCount



        For i = 0 To conteo - 1

            '        MsgBox("vuelta" & i)
            a = grilla2.Rows(i).Cells(0).Value
            '       MsgBox(a)

            If (txtclaveproducto.Text = a) Then
                i = conteo - 1

                respuesta = True
            Else
                respuesta = False

            End If


        Next



        Return respuesta

    End Function

    Private Sub Button15_Click(sender As Object, e As EventArgs)



    End Sub

    Private Sub Txtfolio_TextChanged_1(sender As Object, e As EventArgs) Handles txtfolio.TextChanged
        buscarfolioventa()

    End Sub

    Private Sub Txtfolioproducto_TextChanged_1(sender As Object, e As EventArgs) Handles txtfolioproducto.TextChanged
        buscarproducto()
    End Sub


    Private Sub grilla_DoubleClick(sender As Object, e As EventArgs) Handles grilla.DoubleClick
        'al darle doble clic, obtenemos la clave de la venta y la mandamos a las cajas de texto

        Dim Variable As Integer = grilla.Item(0, grilla.CurrentRow.Index).Value


        'una vez obtenida la clave de la venta individual, la mandamos a las cajas de texto.

        conexionMysql.Open()
        Dim Sql2 As String
        Sql2 = "select * from ventaind where idventaind=" & Variable & ";"
        Dim cmd2 As New MySqlCommand(Sql2, conexionMysql)
        reader = cmd2.ExecuteReader()
        reader.Read()
        txtclaveproducto.Text = reader.GetString(0).ToString()
        txtdescripcion.Text = reader.GetString(1).ToString()
        txtcantidad.Text = reader.GetString(2).ToString()
        txtprecio.Text = reader.GetString(3).ToString()
        txttotal.Text = CDbl(txtcantidad.Text) * CDbl(txtprecio.Text)
        conexionMysql.Close()




    End Sub

    Private Sub Button56_Click_1(sender As Object, e As EventArgs) Handles Button56.Click
        'para agregar el valor a la lista primero debo saber el folio de venta individual del producto.
        Dim i As Integer

        'vamos a buscar el iddel producto que queremos agregar a la grilla, en caso de que ya exista, lo omitimos.
        '    MsgBox(grilla2.RowCount)


        Dim folio As Integer
        'i = grilla2.RowCount

        'If i = 1 Then
        '    i = 1
        'Else
        '    i = i - 1
        'End If
        'Dim x As Integer

        Dim respuesta As Boolean


        If txtclaveproducto.Text = "" Then
            MsgBox("Ingresa un producto valido", MsgBoxStyle.Information, "Sistema")
        Else


            respuesta = comprobaciondevolucion(txtclaveproducto.Text)



            If respuesta = False Then
                grilla2.Rows.Add(txtclaveproducto.Text, txtdescripcion.Text, txtcantidad.Text, txtprecio.Text, txttotal.Text)
                '                grilla2.Columns(1).Width = 350
                MsgBox("Producto agregado", MsgBoxStyle.Information, "Sistema")
                limpiarcajas()

            End If
        End If

        'For x = 0 To i
        '    If x > 0 Then


        '    End If


        '    'folio = grilla2.Item(1, x).Value

        '    MsgBox("folio" & folio)
        '    MsgBox("clave prod" & txtclaveproducto.Text)

        '    If folio = txtclaveproducto.Text Then

        '        MsgBox("el folio ya existe en la lista", MsgBoxStyle.Information, "Sistema")

        '    Else




        '    End If


        'Next



    End Sub

    Private Sub Button15_Click_1(sender As Object, e As EventArgs) Handles Button15.Click
        Dim dia, mes, año As Integer
        Dim fecha, hora, min, seg As String
        dia = Date.Now.Day
        mes = Date.Now.Month
        año = Date.Now.Year
        fecha = año & "-" & mes & "-" & dia
        hora = Now.Hour & ":" & Now.Minute & ":" & Now.Second



        Dim respuesta As Boolean
        Dim conteo, cantidadventas, cantidadactualproducto, cantidadnuevaproducto, folioventagral, i, cantidadregresar, a, totalproductos As Integer
        Dim totalventa As Double
        Dim idproducto As String

        conteo = grilla2.RowCount



        For i = 0 To conteo - 1

            '        MsgBox("vuelta" & i)
            'se obtiene primero el folio de la venta individual
            a = grilla2.Rows(i).Cells(0).Value
            'MsgBox(a)


            If a = 0 Then

            Else


                'una vez que se tiene el folio. se procede a buscar su folio de venta para darlo de baja
                ' y actualizar el total de ese valor

                Dim costo As Double


                Try
                    cerrarconexion()
                    conexionMysql.Open()
                    Dim Sql31 As String
                    'consultamos el id del cliente para obtener un registro de quien es al que se le esta vendiendo
                    Sql31 = "select idventa,cantidad, idproducto, costo from ventaind where idventaind=" & a & ";"
                    Dim cmd31 As New MySqlCommand(Sql31, conexionMysql)
                    reader = cmd31.ExecuteReader()
                    reader.Read()
                    folioventagral = reader.GetString(0).ToString()
                    cantidadregresar = reader.GetString(1).ToString()
                    idproducto = reader.GetString(2).ToString()
                    costo = reader.GetString(3).ToString()

                    conexionMysql.Close()
                    'MsgBox(idcliente)
                Catch ex As Exception
                    MsgBox("error en la busqueda de la ventaind.", MsgBoxStyle.Exclamation, "Sistema")

                End Try

                'antes de eliminar, busco la cantidad de productos que se van a devolver para sumarle 
                'a los productos que ya existen en la BD.

                Try
                    cerrarconexion()
                    conexionMysql.Open()
                    Dim Sql34 As String
                    'consultamos el id del cliente para obtener un registro de quien es al que se le esta vendiendo
                    Sql34 = "select cantidad from producto where idproducto='" & idproducto & "';"
                    Dim cmd34 As New MySqlCommand(Sql34, conexionMysql)
                    reader = cmd34.ExecuteReader()
                    reader.Read()
                    cantidadactualproducto = reader.GetString(0).ToString()


                    conexionMysql.Close()
                    'MsgBox(idcliente)
                Catch ex As Exception
                    MsgBox("error en la busqueda de la ventaind.", MsgBoxStyle.Exclamation, "Sistema")

                End Try

                'se hace la suma de la cantidad actual del producto mas la que se va a regresar. 
                cantidadnuevaproducto = cantidadactualproducto + cantidadregresar
                'una vez que se tiene el valor a regresar, se actualiza el registro del producto con la nueva cantidad


                Try
                    cerrarconexion()
                    conexionMysql.Open()

                    Dim sql25 As String
                    sql25 = "update producto set cantidad=" & cantidadnuevaproducto & " where idproducto='" & idproducto & "';"
                    Dim cmd25 As New MySqlCommand(sql25, conexionMysql)
                    cmd25.ExecuteNonQuery()

                    conexionMysql.Close()

                Catch ex As Exception
                    MsgBox("error en la actualizacion", MsgBoxStyle.Exclamation, "Sistema")
                End Try

                Try
                    cerrarconexion()
                    conexionMysql.Open()



                    Dim sql26 As String
                    sql26 = "insert into devolucion (idproducto,idventa,idventaind,cantidad,costo,fecha,hora) values('" & idproducto & "'," & folioventagral & "," & a & "," & cantidadregresar & "," & costo & ",'" & fecha & "','" & hora & "');"
                    Dim cmd26 As New MySqlCommand(sql26, conexionMysql)
                    cmd26.ExecuteNonQuery()

                    conexionMysql.Close()

                Catch ex As Exception
                    MsgBox("error en la insercion", MsgBoxStyle.Exclamation, "Sistema")
                End Try





                'se procede a eliminar el folio de ventaind de la bd
                Try
                    cerrarconexion()
                    conexionMysql.Open()

                    Dim sql2 As String
                    sql2 = "delete from ventaind where idventaind='" & a & "';"
                    Dim cmd2 As New MySqlCommand(sql2, conexionMysql)
                    cmd2.ExecuteNonQuery()

                    conexionMysql.Close()

                Catch ex As Exception
                    MsgBox("error en la eliminación de la ventaind.", MsgBoxStyle.Exclamation, "Sistema")
                End Try




                'para que sepamos si aun queda un producto vendido, verificamos si hay aun ventas del folio

                Try
                    cerrarconexion()
                    conexionMysql.Open()
                    Dim Sql39 As String
                    'consultamos el id del cliente para obtener un registro de quien es al que se le esta vendiendo
                    Sql39 = "Select count(*) from ventaind where idventa=" & folioventagral & ";"
                    Dim cmd39 As New MySqlCommand(Sql39, conexionMysql)
                    reader = cmd39.ExecuteReader()
                    reader.Read()

                    cantidadventas = reader.GetString(0).ToString()
                    conexionMysql.Close()
                    'MsgBox(idcliente)
                Catch ex As Exception
                    MsgBox("error en la busqueda", MsgBoxStyle.Exclamation, "Sistema")
                End Try




                'una vez que ya se tiene el folio de la venta general, se proecde a realizar la operacion matematica
                'para calcular nuevamente la venta total


                MsgBox(cantidadventas)

                If cantidadventas = 0 Then
                    'en caso de que ya no exista productos vendidos en el folio de venta, se realiza una actualización de valores a cero
                    Try
                        cerrarconexion()
                        conexionMysql.Open()

                        Dim sql21x As String
                        sql21x = "update venta set cantidad=0, total=0 where idventa=" & folioventagral & ";"
                        Dim cmd21x As New MySqlCommand(sql21x, conexionMysql)
                        cmd21x.ExecuteNonQuery()

                        conexionMysql.Close()

                    Catch ex As Exception
                        MsgBox("error en la actualizacion", MsgBoxStyle.Exclamation, "Sistema")
                    End Try




                Else


                    Try
                        cerrarconexion()
                        conexionMysql.Open()
                        Dim Sql3 As String
                        'consultamos el id del cliente para obtener un registro de quien es al que se le esta vendiendo
                        Sql3 = "select sum(cantidad*costo)as total,sum(cantidad)as suma from ventaind where idventa=" & folioventagral & ";"
                        Dim cmd3 As New MySqlCommand(Sql3, conexionMysql)
                        reader = cmd3.ExecuteReader()
                        reader.Read()
                        totalventa = reader.GetString(0).ToString()
                        totalproductos = reader.GetString(1).ToString()
                        conexionMysql.Close()
                        'MsgBox(idcliente)
                    Catch ex As Exception
                        MsgBox("error en la busqueda", MsgBoxStyle.Exclamation, "Sistema")
                    End Try



                    MsgBox("Lo vendido del folio:" & folioventagral)
                    MsgBox("es de:" & totalventa)




                    Try
                        cerrarconexion()
                        conexionMysql.Open()

                        Dim sql21 As String
                        sql21 = "update venta set cantidad=" & totalproductos & ", total=" & totalventa & " where idventa=" & folioventagral & ";"
                        Dim cmd21 As New MySqlCommand(sql21, conexionMysql)
                        cmd21.ExecuteNonQuery()

                        conexionMysql.Close()

                    Catch ex As Exception
                        MsgBox("error en la actualizacion", MsgBoxStyle.Exclamation, "Sistema")
                    End Try



                End If


                'If (txtclaveproducto.Text = a) Then
                '    i = conteo - 1

                '    respuesta = True
                'Else
                '    respuesta = False

                'End If
            End If


        Next
        MsgBox("Productos devueltos correctamente", MsgBoxStyle.Information, "Sistema")
        'se eliminan los regisros de la grilla2, para indicar que se han eliminado del sistema
        grilla2.Rows.Clear()
        buscarfolioventa()
        buscarproducto()
        'grilla.Rows.Clear()
    End Sub

    Private Sub Datetimer_ValueChanged_1(sender As Object, e As EventArgs) Handles datetimer.ValueChanged
        buscarproducto()
    End Sub

    Private Sub Grilla_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles grilla.CellContentClick

    End Sub

    Private Sub Grilla2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grilla2.CellContentClick

    End Sub
End Class