Public NotInheritable Class AboutBox1

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Définissez le titre du formulaire.
        'Dim ApplicationTitle As String
        'I() 'f My.Application.Info.Title <> "" Then
        'ApplicationTitle = My.Application.Info.Title
        'e() 'lse
        'Ap() 'plicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        'End ' If
        'Me.T() 'ext = String.Format("À propos de {0}", ApplicationTitle)
        ' Ini'tialisez tout le texte affiché dans la boîte de dialogue À propos de.
        ' TODO' : personnalisez les informations d'assembly de l'application dans le volet "Application" de la 
        '    bo'îte de dialogue Propriétés du projet (sous le menu "Projet").
        'Me.Label() 'ProductName.Text = My.Application.Info.ProductName
        'Me.LabelV() 'ersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
        'Me.LabelCo() 'pyright.Text = My.Application.Info.Copyright
        'Me.LabelCom() 'panyName.Text = My.Application.Info.CompanyName
        'Me.TextBoxDe'scription.Text = My.Application.Info.Description
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

End Class
