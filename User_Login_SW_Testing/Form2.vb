Imports System.Data.SqlClient
Public Class frmSignUP

    Private Sub frmSignUP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LD()

    End Sub

    Private Sub btnReg_Click(sender As Object, e As EventArgs) Handles btnReg.Click
        Cn.Open()

        Dim cmd As SqlCommand
        Dim cmdcheck As SqlCommand
        Dim ans As String

        If txtFname.Text <> "" And txtLname.Text <> "" And txtAddress.Text <> "" And txtEmail.Text <> "" And txtMobile.Text <> "" And cmbUsrType.SelectedIndex <> -1 Then
            If txtRegUName.Text <> "" Then

                If txtRegPswrd.Text <> "" Then
                    If txtRegPswrd.Text.Length >= 8 And txtRegPswrd.Text.Length <= 12 Then
                        If txtRegPswrd.Text = txtRegRePswrd.Text Then

                            cmdcheck = New SqlCommand(" SELECT count(Uname) FROM ULogin WHERE Uname='" & txtRegUName.Text & "' ", Cn)
                            Dim Count = Convert.ToInt32(cmdcheck.ExecuteScalar)

                            If Count = 0 Then
                                cmd = New SqlCommand("INSERT INTO ULogin(Uname,Password,Fname,Lname,Address,Email,Mobile,UserType) Values('" & txtRegUName.Text & "','" & txtRegPswrd.Text & "','" & txtFname.Text & "','" & txtLname.Text & "','" & txtAddress.Text & "','" & txtEmail.Text & "', '" & txtMobile.Text & "', '" & cmbUsrType.Text & "' )", Cn)
                                ans = MsgBox("Do you want to register..?", MsgBoxStyle.YesNo, "SignUp")

                                If ans = vbYes Then
                                    cmd.ExecuteNonQuery()
                                    MsgBox("Registration successfully...!!!", , "Registration")
                                    clear()
                                End If
                            Else
                                MsgBox("User Name Already Exist..!  Please Re-enter Different User Name..", MsgBoxStyle.OkCancel, "SignUp")
                            End If

                        Else
                            MsgBox("Password doesn't match,  Please Enter Same Password!!!")
                        End If

                    Else
                        MsgBox("Please Enter 8-12 characters")
                    End If
                Else
                    MsgBox("Please Enter Password..!")
                End If
            Else
                MsgBox("Please Enter User Name..!")
            End If
        Else
            MsgBox("Please Fill thr Form Before the Register..!!!")
        End If
        Cn.Close()
    End Sub

    Private Sub btnCnsl_Click(sender As Object, e As EventArgs) Handles btnCnsl.Click
        Dim ans2 As String
        ans2 = MsgBox("Do you want to Exit..?", MsgBoxStyle.YesNo, "Exit")
        If ans2 = vbYes Then
            End
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Hide()
        frmUserLogin.Show()
        clear()
    End Sub

    Private Sub clear()
        txtFname.Text = ""
        txtLname.Text = ""
        txtAddress.Text = ""
        txtEmail.Text = ""
        txtMobile.Text = ""
        cmbUsrType.SelectedIndex = -1
        txtRegUName.Text = ""
        txtRegPswrd.Text = ""
        txtRegRePswrd.Text = ""
    End Sub


End Class