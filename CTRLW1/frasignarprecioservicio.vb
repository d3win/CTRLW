Public Class frasignarprecioservicio
    Private Sub Txtcantidad_TextChanged(sender As Object, e As EventArgs) Handles txtprecioservicio.TextChanged

        'asignamos el nuevo precio del servicio
        Try

            If txtprecioservicio.Text = "" Or txtprecioservicio.Text = 0 Then
            Else
                asignarprecio()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtprecioservicio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtprecioservicio.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.Close()

        End If
        'al dar enter cerramos la ventana

    End Sub

    Function asignarprecio()



        If txtprecioservicio.Text = 0 Or txtprecioservicio.Text = "" Then
            MsgBox("El servicio no puede tener un valor de Cero o vacio", MsgBoxStyle.Information, "CTRL+y")
            'en caso de que quiera poner valores de cero o vacio retomamos el mismo precio del servicio anteriormente asignado
            txtprecioservicio.Text = frmindex.stxtprecio.Text


        Else


            frmindex.stxtprecio.Text = txtprecioservicio.Text



            'calculamos el costo total del servicio
            Try

                frmindex.stxttotalproducto.Text = CDbl(frmindex.stxtcantidad.Text) * CDbl(frmindex.stxtprecio.Text)
            Catch ex As Exception

                frmindex.stxttotalproducto.Text = ""


            End Try

        End If

    End Function

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click

        Try

            If txtprecioservicio.Text = "" Or txtprecioservicio.Text = 0 Then

                MsgBox("¡Precio no valido!", MsgBoxStyle.Exclamation, "Ctrl+y")
            Else
                asignarprecio()
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox("¡Precio no valido!", MsgBoxStyle.Exclamation, "Ctrl+y")

        End Try

    End Sub
End Class