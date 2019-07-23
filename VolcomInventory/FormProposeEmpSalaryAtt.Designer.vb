<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormProposeEmpSalaryAtt
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProposeEmpSalaryAtt))
        Me.PCAction = New DevExpress.XtraEditors.PanelControl()
        Me.SBClose = New DevExpress.XtraEditors.SimpleButton()
        Me.PictureEdit = New DevExpress.XtraEditors.PictureEdit()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.XSCImageList = New DevExpress.XtraEditors.XtraScrollableControl()
        CType(Me.PCAction, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCAction.SuspendLayout()
        CType(Me.PictureEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PCAction
        '
        Me.PCAction.Controls.Add(Me.SBClose)
        Me.PCAction.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PCAction.Location = New System.Drawing.Point(0, 520)
        Me.PCAction.Name = "PCAction"
        Me.PCAction.Size = New System.Drawing.Size(584, 41)
        Me.PCAction.TabIndex = 2
        '
        'SBClose
        '
        Me.SBClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SBClose.Image = CType(resources.GetObject("SBClose.Image"), System.Drawing.Image)
        Me.SBClose.Location = New System.Drawing.Point(511, 6)
        Me.SBClose.Name = "SBClose"
        Me.SBClose.Size = New System.Drawing.Size(67, 29)
        Me.SBClose.TabIndex = 3
        Me.SBClose.Text = "Close"
        '
        'PictureEdit
        '
        Me.PictureEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureEdit.Location = New System.Drawing.Point(0, 0)
        Me.PictureEdit.Name = "PictureEdit"
        Me.PictureEdit.Properties.ReadOnly = True
        Me.PictureEdit.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.PictureEdit.Properties.ShowScrollBars = True
        Me.PictureEdit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
        Me.PictureEdit.Properties.ZoomingOperationMode = DevExpress.XtraEditors.Repository.ZoomingOperationMode.MouseWheel
        Me.PictureEdit.Size = New System.Drawing.Size(584, 468)
        Me.PictureEdit.TabIndex = 3
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.XSCImageList)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 468)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(584, 52)
        Me.PanelControl1.TabIndex = 4
        '
        'XSCImageList
        '
        Me.XSCImageList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XSCImageList.Location = New System.Drawing.Point(2, 2)
        Me.XSCImageList.Name = "XSCImageList"
        Me.XSCImageList.Size = New System.Drawing.Size(580, 48)
        Me.XSCImageList.TabIndex = 2
        '
        'FormProposeEmpSalaryAtt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 561)
        Me.Controls.Add(Me.PictureEdit)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.PCAction)
        Me.MinimizeBox = False
        Me.Name = "FormProposeEmpSalaryAtt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contract"
        CType(Me.PCAction, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCAction.ResumeLayout(False)
        CType(Me.PictureEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PCAction As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SBClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PictureEdit As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents XSCImageList As DevExpress.XtraEditors.XtraScrollableControl
End Class
