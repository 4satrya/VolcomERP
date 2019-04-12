<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpFP
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
        Me.components = New System.ComponentModel.Container()
        Me.GCFP = New DevExpress.XtraGrid.GridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TestConnectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MasterMachineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddMachineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditMachineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteMachineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DownloadTemplateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowFingerTemplateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DownloadFingerTemplateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DownloadFaceTemplateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UploadFingerTemplateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UploadFaceTemplateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UploadFingerFacespesifikToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeviceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RestartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TurnOffToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVFP = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPort = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnFPRegister = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.BAccept = New DevExpress.XtraEditors.SimpleButton()
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.VolcomMRP.WaitForm), True, True)
        CType(Me.GCFP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GVFP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCFP
        '
        Me.GCFP.ContextMenuStrip = Me.ContextMenuStrip1
        Me.GCFP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCFP.Location = New System.Drawing.Point(0, 0)
        Me.GCFP.MainView = Me.GVFP
        Me.GCFP.Name = "GCFP"
        Me.GCFP.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCFP.Size = New System.Drawing.Size(519, 228)
        Me.GCFP.TabIndex = 1
        Me.GCFP.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVFP})
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TestConnectionToolStripMenuItem, Me.MasterMachineToolStripMenuItem, Me.DataToolStripMenuItem, Me.DeviceToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(161, 114)
        '
        'TestConnectionToolStripMenuItem
        '
        Me.TestConnectionToolStripMenuItem.Name = "TestConnectionToolStripMenuItem"
        Me.TestConnectionToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.TestConnectionToolStripMenuItem.Text = "Test Connection"
        '
        'MasterMachineToolStripMenuItem
        '
        Me.MasterMachineToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddMachineToolStripMenuItem, Me.EditMachineToolStripMenuItem, Me.DeleteMachineToolStripMenuItem, Me.ToolStripMenuItem1})
        Me.MasterMachineToolStripMenuItem.Name = "MasterMachineToolStripMenuItem"
        Me.MasterMachineToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.MasterMachineToolStripMenuItem.Text = "Master Machine"
        '
        'AddMachineToolStripMenuItem
        '
        Me.AddMachineToolStripMenuItem.Name = "AddMachineToolStripMenuItem"
        Me.AddMachineToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.AddMachineToolStripMenuItem.Text = "Add Machine"
        '
        'EditMachineToolStripMenuItem
        '
        Me.EditMachineToolStripMenuItem.Name = "EditMachineToolStripMenuItem"
        Me.EditMachineToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.EditMachineToolStripMenuItem.Text = "Edit Machine"
        '
        'DeleteMachineToolStripMenuItem
        '
        Me.DeleteMachineToolStripMenuItem.Name = "DeleteMachineToolStripMenuItem"
        Me.DeleteMachineToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.DeleteMachineToolStripMenuItem.Text = "Delete Machine"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(198, 22)
        Me.ToolStripMenuItem1.Text = "Set as Register Machine"
        '
        'DataToolStripMenuItem
        '
        Me.DataToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DownloadTemplateToolStripMenuItem, Me.ShowFingerTemplateToolStripMenuItem, Me.DownloadFingerTemplateToolStripMenuItem, Me.DownloadFaceTemplateToolStripMenuItem, Me.UploadFingerTemplateToolStripMenuItem, Me.UploadFaceTemplateToolStripMenuItem, Me.UploadFingerFacespesifikToolStripMenuItem})
        Me.DataToolStripMenuItem.Name = "DataToolStripMenuItem"
        Me.DataToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.DataToolStripMenuItem.Text = "Data"
        '
        'DownloadTemplateToolStripMenuItem
        '
        Me.DownloadTemplateToolStripMenuItem.Name = "DownloadTemplateToolStripMenuItem"
        Me.DownloadTemplateToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.DownloadTemplateToolStripMenuItem.Text = "Show Finger Template"
        '
        'ShowFingerTemplateToolStripMenuItem
        '
        Me.ShowFingerTemplateToolStripMenuItem.Name = "ShowFingerTemplateToolStripMenuItem"
        Me.ShowFingerTemplateToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.ShowFingerTemplateToolStripMenuItem.Text = "Show Face Template"
        '
        'DownloadFingerTemplateToolStripMenuItem
        '
        Me.DownloadFingerTemplateToolStripMenuItem.Name = "DownloadFingerTemplateToolStripMenuItem"
        Me.DownloadFingerTemplateToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.DownloadFingerTemplateToolStripMenuItem.Text = "Download Finger Template"
        '
        'DownloadFaceTemplateToolStripMenuItem
        '
        Me.DownloadFaceTemplateToolStripMenuItem.Name = "DownloadFaceTemplateToolStripMenuItem"
        Me.DownloadFaceTemplateToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.DownloadFaceTemplateToolStripMenuItem.Text = "Download Face Template"
        '
        'UploadFingerTemplateToolStripMenuItem
        '
        Me.UploadFingerTemplateToolStripMenuItem.Name = "UploadFingerTemplateToolStripMenuItem"
        Me.UploadFingerTemplateToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.UploadFingerTemplateToolStripMenuItem.Text = "Upload Finger Template"
        '
        'UploadFaceTemplateToolStripMenuItem
        '
        Me.UploadFaceTemplateToolStripMenuItem.Name = "UploadFaceTemplateToolStripMenuItem"
        Me.UploadFaceTemplateToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.UploadFaceTemplateToolStripMenuItem.Text = "Upload Face Template"
        '
        'UploadFingerFacespesifikToolStripMenuItem
        '
        Me.UploadFingerFacespesifikToolStripMenuItem.Name = "UploadFingerFacespesifikToolStripMenuItem"
        Me.UploadFingerFacespesifikToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.UploadFingerFacespesifikToolStripMenuItem.Text = "Upload Finger & Face (spesifik)"
        '
        'DeviceToolStripMenuItem
        '
        Me.DeviceToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RestartToolStripMenuItem, Me.TurnOffToolStripMenuItem})
        Me.DeviceToolStripMenuItem.Name = "DeviceToolStripMenuItem"
        Me.DeviceToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.DeviceToolStripMenuItem.Text = "Device"
        '
        'RestartToolStripMenuItem
        '
        Me.RestartToolStripMenuItem.Name = "RestartToolStripMenuItem"
        Me.RestartToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.RestartToolStripMenuItem.Text = "Restart"
        '
        'TurnOffToolStripMenuItem
        '
        Me.TurnOffToolStripMenuItem.Name = "TurnOffToolStripMenuItem"
        Me.TurnOffToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.TurnOffToolStripMenuItem.Text = "Turn Off"
        '
        'GVFP
        '
        Me.GVFP.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnId, Me.GridColumnName, Me.GridColumnSN, Me.GridColumnIP, Me.GridColumnPort, Me.GridColumnFPRegister})
        Me.GVFP.GridControl = Me.GCFP
        Me.GVFP.Name = "GVFP"
        Me.GVFP.OptionsBehavior.Editable = False
        Me.GVFP.OptionsView.ShowGroupPanel = False
        '
        'GridColumnId
        '
        Me.GridColumnId.Caption = "Id"
        Me.GridColumnId.FieldName = "id_fingerprint"
        Me.GridColumnId.Name = "GridColumnId"
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Name"
        Me.GridColumnName.FieldName = "name"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 0
        '
        'GridColumnSN
        '
        Me.GridColumnSN.Caption = "Serial Number"
        Me.GridColumnSN.FieldName = "sn"
        Me.GridColumnSN.Name = "GridColumnSN"
        Me.GridColumnSN.Visible = True
        Me.GridColumnSN.VisibleIndex = 1
        '
        'GridColumnIP
        '
        Me.GridColumnIP.Caption = "IP"
        Me.GridColumnIP.FieldName = "ip"
        Me.GridColumnIP.Name = "GridColumnIP"
        Me.GridColumnIP.Visible = True
        Me.GridColumnIP.VisibleIndex = 2
        '
        'GridColumnPort
        '
        Me.GridColumnPort.Caption = "Port"
        Me.GridColumnPort.FieldName = "port"
        Me.GridColumnPort.Name = "GridColumnPort"
        Me.GridColumnPort.Visible = True
        Me.GridColumnPort.VisibleIndex = 3
        '
        'GridColumnFPRegister
        '
        Me.GridColumnFPRegister.Caption = "Register Machine"
        Me.GridColumnFPRegister.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumnFPRegister.FieldName = "register"
        Me.GridColumnFPRegister.Name = "GridColumnFPRegister"
        Me.GridColumnFPRegister.Visible = True
        Me.GridColumnFPRegister.VisibleIndex = 4
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'BAccept
        '
        Me.BAccept.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BAccept.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BAccept.Appearance.ForeColor = System.Drawing.Color.White
        Me.BAccept.Appearance.Options.UseBackColor = True
        Me.BAccept.Appearance.Options.UseFont = True
        Me.BAccept.Appearance.Options.UseForeColor = True
        Me.BAccept.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BAccept.Location = New System.Drawing.Point(0, 228)
        Me.BAccept.LookAndFeel.SkinName = "Metropolis"
        Me.BAccept.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BAccept.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BAccept.Name = "BAccept"
        Me.BAccept.Size = New System.Drawing.Size(519, 34)
        Me.BAccept.TabIndex = 137
        Me.BAccept.Text = "Syncronize All Machine"
        '
        'SplashScreenManager1
        '
        Me.SplashScreenManager1.ClosingDelay = 500
        '
        'FormEmpFP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(519, 262)
        Me.Controls.Add(Me.GCFP)
        Me.Controls.Add(Me.BAccept)
        Me.Name = "FormEmpFP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fingerprint Setup"
        CType(Me.GCFP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GVFP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCFP As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVFP As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPort As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFPRegister As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents BAccept As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents MasterMachineToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddMachineToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditMachineToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteMachineToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents DataToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeviceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DownloadTemplateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ShowFingerTemplateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DownloadFingerTemplateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DownloadFaceTemplateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UploadFingerTemplateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UploadFaceTemplateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RestartToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TurnOffToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TestConnectionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
    Friend WithEvents UploadFingerFacespesifikToolStripMenuItem As ToolStripMenuItem
End Class
