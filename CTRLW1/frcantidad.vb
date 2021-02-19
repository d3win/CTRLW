Public Class frcantidad
    Private Sub txtcantidad_TextChanged(sender As Object, e As EventArgs)

    End Sub


    Function cantidad()
        'despues de que se presione enter, que se agrege el valor de la cantidad.
        'MsgBox("cantidad")

        If txtcantidad.Text = "" Then
            txtcantidad.Text = 1
        End If


        Dim cantidad_total, cantidadbd As Integer

        'cantidad total es la cantidad que se va a vender
        'se le suma 1, porque es el producto que apenas se va anexar a la lista de venta
        cantidad_total = frmindex.comprobacion() + txtcantidad.Text
        frmindex.txtcantidad.Text = txtcantidad.Text


        'cantidadbd, es la cantidad que existe en la BD del producto

        cantidadbd = frmindex.conteoclave()


        If cantidad_total > cantidadbd Then
            MsgBox("No hay productos suficientes, no se agregara este producto", MsgBoxStyle.Exclamation, "Sistema")
            frmindex.borrar()
        Else
            frmindex.agregargrilla()



        End If


        Me.Close()
    End Function





    Private Sub btnanexar_Click(sender As Object, e As EventArgs) 
        cantidad()
    End Sub


    Private Sub Btnanexar_Click_1(sender As Object, e As EventArgs) Handles btnanexar.Click
        cantidad()

    End Sub

    Private Sub txtcantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtcantidad.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            'despues de que se presione enter, que se agrege el valor de la cantidad.

            cantidad()

        End If
    End Sub
End Class