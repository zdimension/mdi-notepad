Imports System.Windows.Forms

Public Class find

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Dim recherche As String = TextBox1.Text
        Dim position As Integer = 0
        position = CType(Form1.ActiveMdiChild, Object).rtb.Text.ToString.IndexOf(recherche)
        While (position > 0)
            MsgBox(String.Format("Chaîne trouvée à la position {0}", position))
            position = CType(Form1.ActiveMdiChild, Object).rtb.Text.ToString.IndexOf(recherche, position + 1)
        End While

        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
