<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGPOClose
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.XTCFGPO = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        CType(Me.XTCFGPO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCFGPO.SuspendLayout()
        Me.SuspendLayout()
        '
        'XTCFGPO
        '
        Me.XTCFGPO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCFGPO.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCFGPO.Location = New System.Drawing.Point(0, 0)
        Me.XTCFGPO.Name = "XTCFGPO"
        Me.XTCFGPO.SelectedTabPage = Me.XtraTabPage1
        Me.XTCFGPO.Size = New System.Drawing.Size(853, 594)
        Me.XTCFGPO.TabIndex = 0
        Me.XTCFGPO.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(847, 566)
        Me.XtraTabPage1.Text = "XtraTabPage1"
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(294, 272)
        Me.XtraTabPage2.Text = "XtraTabPage2"
        '
        'FormFGPOClose
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 594)
        Me.Controls.Add(Me.XTCFGPO)
        Me.Name = "FormFGPOClose"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Closing FGPO"
        CType(Me.XTCFGPO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCFGPO.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCFGPO As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
End Class
