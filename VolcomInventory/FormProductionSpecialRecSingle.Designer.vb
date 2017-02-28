<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProductionSpecialRecSingle
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BClose = New DevExpress.XtraEditors.SimpleButton()
        Me.BOpenLock = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.TEMemoNumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.TEMemoNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BClose)
        Me.PanelControl1.Controls.Add(Me.BOpenLock)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 57)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(369, 34)
        Me.PanelControl1.TabIndex = 0
        '
        'BClose
        '
        Me.BClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BClose.Location = New System.Drawing.Point(186, 2)
        Me.BClose.Name = "BClose"
        Me.BClose.Size = New System.Drawing.Size(68, 30)
        Me.BClose.TabIndex = 1
        Me.BClose.Text = "Cancel"
        '
        'BOpenLock
        '
        Me.BOpenLock.Dock = System.Windows.Forms.DockStyle.Right
        Me.BOpenLock.Location = New System.Drawing.Point(254, 2)
        Me.BOpenLock.Name = "BOpenLock"
        Me.BOpenLock.Size = New System.Drawing.Size(113, 30)
        Me.BOpenLock.TabIndex = 0
        Me.BOpenLock.Text = "Disable Tolerance"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.TEMemoNumber)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(369, 57)
        Me.PanelControl2.TabIndex = 1
        '
        'TEMemoNumber
        '
        Me.TEMemoNumber.Location = New System.Drawing.Point(85, 18)
        Me.TEMemoNumber.Name = "TEMemoNumber"
        Me.TEMemoNumber.Size = New System.Drawing.Size(257, 20)
        Me.TEMemoNumber.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 21)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(67, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Memo number"
        '
        'FormProductionSpecialRecSingle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(369, 91)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormProductionSpecialRecSingle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Disable Receiving Tolerance"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.TEMemoNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BOpenLock As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEMemoNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
End Class
