Public Class frm3

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Hide()
        frmUserLogin.Show()
    End Sub

    Private Sub frm3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class