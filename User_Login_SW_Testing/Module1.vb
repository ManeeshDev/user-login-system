Imports System.Data.SqlClient

Module Module1

    Public Cn As New SqlConnection

    Public Sub LD()

        'Cn = New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\Manish\VB @VTA_DIP_2019\User_Login_ SW-Testing\User_Login_SW_Testing\UserLoginDB.mdf;Integrated Security=True")
        Cn = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\MP_ Works\My Dev Projects\Vb .net\user-login-system\User_Login_SW_Testing\UserLoginDB.mdf;Integrated Security=True;Connect Timeout=30")

    End Sub

End Module
