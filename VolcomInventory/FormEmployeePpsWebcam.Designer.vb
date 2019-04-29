<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmployeePpsWebcam
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmployeePpsWebcam))
        Me.CameraControl = New DevExpress.XtraEditors.Camera.CameraControl()
        Me.PanelControl = New DevExpress.XtraEditors.PanelControl()
        Me.SBCapture = New DevExpress.XtraEditors.SimpleButton()
        Me.SBClose = New DevExpress.XtraEditors.SimpleButton()
        Me.SBSave = New DevExpress.XtraEditors.SimpleButton()
        Me.PictureEdit = New DevExpress.XtraEditors.PictureEdit()
        CType(Me.PanelControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl.SuspendLayout()
        CType(Me.PictureEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CameraControl
        '
        Me.CameraControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CameraControl.Location = New System.Drawing.Point(0, 0)
        Me.CameraControl.Name = "CameraControl"
        Me.CameraControl.Size = New System.Drawing.Size(784, 520)
        Me.CameraControl.TabIndex = 0
        Me.CameraControl.Text = "CameraControl"
        '
        'PanelControl
        '
        Me.PanelControl.Controls.Add(Me.SBClose)
        Me.PanelControl.Controls.Add(Me.SBCapture)
        Me.PanelControl.Controls.Add(Me.SBSave)
        Me.PanelControl.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl.Location = New System.Drawing.Point(0, 520)
        Me.PanelControl.Name = "PanelControl"
        Me.PanelControl.Size = New System.Drawing.Size(784, 41)
        Me.PanelControl.TabIndex = 2
        '
        'SBCapture
        '
        Me.SBCapture.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBCapture.Image = CType(resources.GetObject("SBCapture.Image"), System.Drawing.Image)
        Me.SBCapture.Location = New System.Drawing.Point(598, 2)
        Me.SBCapture.Name = "SBCapture"
        Me.SBCapture.Size = New System.Drawing.Size(92, 37)
        Me.SBCapture.TabIndex = 0
        Me.SBCapture.Text = "Capture"
        '
        'SBClose
        '
        Me.SBClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBClose.Image = CType(resources.GetObject("SBClose.Image"), System.Drawing.Image)
        Me.SBClose.Location = New System.Drawing.Point(506, 2)
        Me.SBClose.Name = "SBClose"
        Me.SBClose.Size = New System.Drawing.Size(92, 37)
        Me.SBClose.TabIndex = 1
        Me.SBClose.Text = "Close"
        '
        'SBSave
        '
        Me.SBSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBSave.Enabled = False
        Me.SBSave.Image = CType(resources.GetObject("SBSave.Image"), System.Drawing.Image)
        Me.SBSave.Location = New System.Drawing.Point(690, 2)
        Me.SBSave.Name = "SBSave"
        Me.SBSave.Size = New System.Drawing.Size(92, 37)
        Me.SBSave.TabIndex = 2
        Me.SBSave.Text = "Save"
        '
        'PictureEdit
        '
        Me.PictureEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureEdit.Location = New System.Drawing.Point(0, 0)
        Me.PictureEdit.Name = "PictureEdit"
        Me.PictureEdit.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.PictureEdit.Size = New System.Drawing.Size(784, 520)
        Me.PictureEdit.TabIndex = 3
        Me.PictureEdit.Visible = False
        '
        'FormEmployeePpsWebcam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.CameraControl)
        Me.Controls.Add(Me.PictureEdit)
        Me.Controls.Add(Me.PanelControl)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEmployeePpsWebcam"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Webcam"
        CType(Me.PanelControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl.ResumeLayout(False)
        CType(Me.PictureEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CameraControl As DevExpress.XtraEditors.Camera.CameraControl
    Friend WithEvents PanelControl As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SBCapture As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PictureEdit As DevExpress.XtraEditors.PictureEdit
End Class
