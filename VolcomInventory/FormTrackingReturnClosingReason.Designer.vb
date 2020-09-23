<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTrackingReturnClosingReason
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormTrackingReturnClosingReason))
        Me.MERemark = New DevExpress.XtraEditors.MemoEdit()
        Me.SBSave = New DevExpress.XtraEditors.SimpleButton()
        Me.SBCancel = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.MERemark.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MERemark
        '
        Me.MERemark.Location = New System.Drawing.Point(12, 12)
        Me.MERemark.Name = "MERemark"
        Me.MERemark.Size = New System.Drawing.Size(360, 40)
        Me.MERemark.TabIndex = 0
        '
        'SBSave
        '
        Me.SBSave.Image = CType(resources.GetObject("SBSave.Image"), System.Drawing.Image)
        Me.SBSave.Location = New System.Drawing.Point(297, 58)
        Me.SBSave.Name = "SBSave"
        Me.SBSave.Size = New System.Drawing.Size(75, 23)
        Me.SBSave.TabIndex = 1
        Me.SBSave.Text = "Save"
        '
        'SBCancel
        '
        Me.SBCancel.Image = CType(resources.GetObject("SBCancel.Image"), System.Drawing.Image)
        Me.SBCancel.Location = New System.Drawing.Point(216, 58)
        Me.SBCancel.Name = "SBCancel"
        Me.SBCancel.Size = New System.Drawing.Size(75, 23)
        Me.SBCancel.TabIndex = 2
        Me.SBCancel.Text = "Cancel"
        '
        'FormTrackingReturnClosingReason
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 93)
        Me.Controls.Add(Me.SBCancel)
        Me.Controls.Add(Me.SBSave)
        Me.Controls.Add(Me.MERemark)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormTrackingReturnClosingReason"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Closing Remark"
        CType(Me.MERemark.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MERemark As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents SBSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBCancel As DevExpress.XtraEditors.SimpleButton
End Class
