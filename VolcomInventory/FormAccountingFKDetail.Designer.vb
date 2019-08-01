<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAccountingFKDetail
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
        Me.XTCFKDetail = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPNoFaktur = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPExportedCSV = New DevExpress.XtraTab.XtraTabPage()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.GCHeader = New DevExpress.XtraGrid.GridControl()
        Me.GVHeader = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.XTCFKDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCFKDetail.SuspendLayout()
        Me.XTPNoFaktur.SuspendLayout()
        CType(Me.GCHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCFKDetail
        '
        Me.XTCFKDetail.AppearancePage.HeaderActive.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XTCFKDetail.AppearancePage.HeaderActive.Options.UseFont = True
        Me.XTCFKDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCFKDetail.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCFKDetail.Location = New System.Drawing.Point(0, 0)
        Me.XTCFKDetail.LookAndFeel.SkinName = "Metropolis"
        Me.XTCFKDetail.LookAndFeel.UseDefaultLookAndFeel = False
        Me.XTCFKDetail.Name = "XTCFKDetail"
        Me.XTCFKDetail.SelectedTabPage = Me.XTPNoFaktur
        Me.XTCFKDetail.Size = New System.Drawing.Size(783, 497)
        Me.XTCFKDetail.TabIndex = 0
        Me.XTCFKDetail.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPNoFaktur, Me.XTPExportedCSV})
        '
        'XTPNoFaktur
        '
        Me.XTPNoFaktur.Controls.Add(Me.GCHeader)
        Me.XTPNoFaktur.Controls.Add(Me.SimpleButton1)
        Me.XTPNoFaktur.Name = "XTPNoFaktur"
        Me.XTPNoFaktur.Size = New System.Drawing.Size(781, 472)
        Me.XTPNoFaktur.Text = "Step I : No Faktur && NPWP"
        '
        'XTPExportedCSV
        '
        Me.XTPExportedCSV.Name = "XTPExportedCSV"
        Me.XTPExportedCSV.Size = New System.Drawing.Size(644, 409)
        Me.XTPExportedCSV.Text = "Step II : Export as CSV"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SimpleButton1.Location = New System.Drawing.Point(0, 439)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(781, 33)
        Me.SimpleButton1.TabIndex = 0
        Me.SimpleButton1.Text = "Next Step"
        '
        'GCHeader
        '
        Me.GCHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCHeader.Location = New System.Drawing.Point(0, 0)
        Me.GCHeader.MainView = Me.GVHeader
        Me.GCHeader.Name = "GCHeader"
        Me.GCHeader.Size = New System.Drawing.Size(781, 439)
        Me.GCHeader.TabIndex = 1
        Me.GCHeader.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVHeader})
        '
        'GVHeader
        '
        Me.GVHeader.GridControl = Me.GCHeader
        Me.GVHeader.Name = "GVHeader"
        Me.GVHeader.OptionsView.ShowGroupPanel = False
        '
        'FormAccountingFKDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(783, 497)
        Me.Controls.Add(Me.XTCFKDetail)
        Me.MinimizeBox = False
        Me.Name = "FormAccountingFKDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FK Detail"
        CType(Me.XTCFKDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCFKDetail.ResumeLayout(False)
        Me.XTPNoFaktur.ResumeLayout(False)
        CType(Me.GCHeader, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCFKDetail As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPNoFaktur As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPExportedCSV As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCHeader As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVHeader As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
End Class
