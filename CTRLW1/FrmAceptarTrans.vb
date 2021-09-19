Public Class FrmAceptarTrans
    Private Sub FrmAceptarTrans_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Me.Close()

    End Sub

    Private Sub FrmAceptarTrans_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmAceptarTrans_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        Me.Close()
    End Sub
End Class