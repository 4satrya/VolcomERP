<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class barcodeaa
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.MemoEdit1 = New DevExpress.XtraEditors.MemoEdit()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextEdit1 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.MemoEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(450, 305)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(125, 46)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Test Print Sato"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'MemoEdit1
        '
        Me.MemoEdit1.Location = New System.Drawing.Point(12, 12)
        Me.MemoEdit1.Name = "MemoEdit1"
        Me.MemoEdit1.Size = New System.Drawing.Size(563, 287)
        Me.MemoEdit1.TabIndex = 1
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(319, 305)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(125, 46)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Test Print Zebra"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextEdit1
        '
        Me.TextEdit1.Location = New System.Drawing.Point(12, 331)
        Me.TextEdit1.Name = "TextEdit1"
        Me.TextEdit1.Size = New System.Drawing.Size(234, 20)
        Me.TextEdit1.TabIndex = 3
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 312)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl1.TabIndex = 4
        Me.LabelControl1.Text = "No Ketik"
        '
        'barcodeaa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(587, 363)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.TextEdit1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.MemoEdit1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "barcodeaa"
        Me.Text = "barcodeaa"
        CType(Me.MemoEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents MemoEdit1 As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents Button2 As Button
    Friend WithEvents TextEdit1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
End Class
