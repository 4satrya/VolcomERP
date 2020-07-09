<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterStoreDet
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
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SBSave = New DevExpress.XtraEditors.SimpleButton()
        Me.TEStore = New DevExpress.XtraEditors.TextEdit()
        CType(Me.TEStore.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(17, 18)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(26, 13)
        Me.LabelControl1.TabIndex = 16
        Me.LabelControl1.Text = "Store"
        '
        'SBSave
        '
        Me.SBSave.Location = New System.Drawing.Point(192, 63)
        Me.SBSave.Name = "SBSave"
        Me.SBSave.Size = New System.Drawing.Size(75, 23)
        Me.SBSave.TabIndex = 15
        Me.SBSave.Text = "Save"
        '
        'TEStore
        '
        Me.TEStore.Location = New System.Drawing.Point(17, 37)
        Me.TEStore.Name = "TEStore"
        Me.TEStore.Size = New System.Drawing.Size(250, 20)
        Me.TEStore.TabIndex = 14
        '
        'FormMasterStoreDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 101)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.SBSave)
        Me.Controls.Add(Me.TEStore)
        Me.Name = "FormMasterStoreDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Master Store Detail"
        CType(Me.TEStore.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SBSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEStore As DevExpress.XtraEditors.TextEdit
End Class
