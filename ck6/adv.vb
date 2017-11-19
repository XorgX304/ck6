Public Class adv
    Private Sub adv_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub FlatButton2_Click(sender As Object, e As EventArgs) Handles FlatButton2.Click
        Try
            Dim lol = Process.GetProcessById(TextBox2.Text)
            fsccts = lol.Modules(0).FileName
            Form1.cons.Text = "Client Path: " + fsccts + vbNewLine + Form1.cons.Text
            MsgBox("Process ID's File path has been tracked. [Client Restart] Module for Fail safe system is now operable. It is now safe to kill the Client.")
        Catch
            MsgBox("Can't fetch Process ID.")
        End Try
    End Sub
End Class