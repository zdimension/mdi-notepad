Imports System.Windows.Forms
Imports System.Drawing.Printing

Public Class Form1

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Créez une nouvelle instance du formulaire enfant.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Configurez-la en tant qu'enfant de ce formulaire MDI avant de l'afficher.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Fenêtre " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripMenuItem.Click, OpenToolStripButton.Click

        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Fichiers texte (*.txt)|*.txt|Documents Rich Text (*.rtf)|*.rtf"
        OpenFileDialog.FileName = ""

        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            Dim texte As New Texte
            If IO.File.Exists(FileName) Then
                Dim wshshell = CreateObject("WScript.Shell")
                Dim fs = CreateObject("Scripting.FileSystemObject")
                Select Case LCase(fs.GetExtensionName(FileName))
                    Case "txt"
                        texte.rtb.LoadFile(FileName, RichTextBoxStreamType.PlainText)
                        texte.MdiParent = Me
                        texte.Text = FileName.ToString
                        texte.Icon = My.Resources.txt
                        texte.Show()
                    Case "rtf"
                        texte.rtb.LoadFile(FileName, RichTextBoxStreamType.RichText)
                        texte.MdiParent = Me
                        texte.Text = FileName.ToString
                        texte.Icon = My.Resources.rtf
                        texte.Show()
                    Case Else
                        texte.rtb.Text = "** Erreur dans le fichier **"
                        texte.MdiParent = Me
                        texte.Text = FileName.ToString
                        texte.Show()
                End Select

            End If

        End If
    End Sub
    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Long, ByVal wMsg As Long, ByVal wParam As Integer, ByVal lParam As Long) As Long
    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveToolStripMenuItem.Click, SaveToolStripButton.Click
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Fichiers texte (*.txt)|*.txt"
        SaveFileDialog.FileName = ""
        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            If IO.File.Exists(FileName) Then
                Dim reponse = MsgBox("Le fichier " & FileName & " éxiste déjà. Le remplacer ?", vbYesNo)
                If reponse = vbYes Then
                    Dim wrt As New IO.StreamWriter(FileName)
                    wrt.Write(CType(Me.ActiveMdiChild, Texte).rtb.Text)
                End If
            End If
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CutToolStripMenuItem.Click
        My.Computer.Clipboard.SetText(CType(Me.ActiveMdiChild, Object).rtb.Text)
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopyToolStripMenuItem.Click
        My.Computer.Clipboard.SetText(CType(Me.ActiveMdiChild, Object).rtb.Text)
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PasteToolStripMenuItem.Click
        CType(Me.ActiveMdiChild, Texte).rtb.Text = My.Computer.Clipboard.GetText
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Fermez tous les formulaires enfants du parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub ContentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsToolStripMenuItem.Click
        options.ShowDialog(Me)
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.Show(Me)
    End Sub


    Private Sub RechercherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RechercherToolStripMenuItem.Click
        find.ShowDialog(Me)
    End Sub

    

    Private Sub PrintSetupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintSetupToolStripMenuItem.Click, PrintToolStripButton.Click
        Dim configPg As New PageSettings
        Dim configPrt As New PrinterSettings
        With dlgPgSetup
            .PageSettings = configPg
            .PrinterSettings = configPrt
            .AllowPrinter = True
            .ShowDialog()
            MessageBox.Show("Vous avez choisi d'imprimer avec l'imprimante " + .PrinterSettings.PrinterName + " sur du papier " + .PageSettings.PaperSize.PaperName + " en format " + (IIf(.PageSettings.Landscape, "paysage.", "portrait.")))

        End With

    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        Dim configPrt As New PrinterSettings
        With dlgprinter
            .PrinterSettings = configPrt
            .AllowSomePages = True
            .AllowSelection = True
            .ShowDialog()
            Select Case (dlgprinter.PrinterSettings.PrintRange)
                Case PrintRange.AllPages
                    MessageBox.Show("Vous avez demandé l'impression de tout le document.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Case PrintRange.SomePages
                    MessageBox.Show("Vous avez demandé l'impression de la page " + .PrinterSettings.FromPage + " à la page " + .PrinterSettings.ToPage + ".", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Case PrintRange.Selection
                    MessageBox.Show("Vous avez demandé l'impression de la séléction.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Select

        End With
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub RetourAutomatiqueÀLaLigneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetourAutomatiqueÀLaLigneToolStripMenuItem.Click
        If Not Me.ActiveMdiChild Is Nothing Then
            CType(Me.ActiveMdiChild, Texte).rtb.WordWrap = IIf(RetourAutomatiqueÀLaLigneToolStripMenuItem.Checked, True, False)
        End If
    End Sub
End Class
