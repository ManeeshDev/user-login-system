Imports System.Data.SqlClient

Public Class frmUserLogin

    Private Sub frmUserLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LD()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim ans As String
        Dim cmdcheck As New SqlCommand
        Dim cmd As New SqlCommand
        
        If Cn.State = ConnectionState.Closed Then
            Cn.Open() 'To open the data base connection
        End If

        cmd = New SqlCommand("SELECT Uname,Password FROM ULogin WHERE Uname='" & txtUName.Text & "'", Cn)

        
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable

        adapter.Fill(table)

        'clear() 'clear form data

        cmdcheck = New SqlCommand(" SELECT count(Uname) FROM ULogin WHERE Uname='" & txtUName.Text & "' ", Cn)
        Dim Count = Convert.ToInt32(cmdcheck.ExecuteScalar)

        If txtUName.Text <> "" Or txtPswrd.Text <> "" Then
            If txtUName.Text <> "" Then
                If txtUName.Text <> "" And Count <> 0 Then
                    If txtPswrd.Text <> "" Then
                        If Count > 0 Then
                            If txtUName.Text = table.Rows(0)(0).ToString() Then
                                If txtPswrd.Text = table.Rows(0)(1).ToString() Then
                                    frm3.Show()
                                    Me.Hide()
                                    clear()
                                Else
                                    MsgBox("Wrong Password..!")
                                End If
                            End If
                         
                        End If
                    Else
                        MsgBox("Please enter password..!")
                    End If
                Else
                    If txtPswrd.Text = "" Then
                        MsgBox("Please enter password..!")
                    Else
                        ans = MsgBox("User Name Dosn't Exist..! Please Sign Up..", MsgBoxStyle.OkCancel, "LogIn")
                        If ans = vbOK Then
                            Me.Hide()
                            frmSignUP.Show()
                            clear()
                        End If
                    End If
                End If
            Else
                MsgBox("Please enter user name..!")
            End If
        Else
            MsgBox("Please enter user name and password..!")
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Hide()
        frmSignUP.Show()
        clear()
    End Sub

    Private Sub btnCnsl_Click(sender As Object, e As EventArgs) Handles btnCnsl.Click
        Dim ans2 As String
        ans2 = MsgBox("Do you want to Exit..?", MsgBoxStyle.YesNo, "Exit")
        If ans2 = vbYes Then
            End
        End If

    End Sub

    Private Sub clear()
        txtPswrd.Text = ""
        txtUName.Text = ""
    End Sub

End Class
