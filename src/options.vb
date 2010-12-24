Imports System.Windows.Forms

Public Class options
    Dim color As Color
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Color = ColorDialog1.Color
            PictureBox1.BackColor = Color
        End If
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
        Form1.MenuStrip.BackColor = color
        Form1.StatusStrip.BackColor = color
        Form1.ToolStrip.BackColor = color
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


End Class
