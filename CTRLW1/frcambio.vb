Public Class frcambio

    Private Sub frcambio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lbtotal.Text = frmindex.txtpagar
        txtpaga.Focus()

    End Sub

    Private Sub txtpaga_KeyDown(sender As Object, e As KeyEventArgs) Handles txtpaga.KeyDown
        If (e.KeyCode = Keys.Escape) Or (e.KeyCode = Keys.Enter) Then
            txtpaga.Text = ""
            ' frmindex.lbcambio.Text = lbcambio.Text
            'frmindex.lbpagacon.Text = txtpaga.Text
            Me.Close()
        End If
    End Sub

    Private Sub txtpaga_TextChanged(sender As Object, e As EventArgs) Handles txtpaga.TextChanged
        Try
            lbcambio.Text = CDbl(txtpaga.Text) - CDbl(lbtotal.Text)
            frmindex.lbcambio.Text = lbcambio.Text
            frmindex.lbpagacon.Text = txtpaga.Text

        Catch ex As Exception

        End Try

    End Sub



    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        'If (e.KeyCode = Keys.Escape) Or (e.KeyCode = Keys.Enter) Then



        txtpaga.Text = ""
        'frmindex.lbcambio.Text = lbcambio.Text
        'frmindex.lbpagacon.Text = txtpaga.Text
        Me.Close()

        'End If
    End Sub
End Class