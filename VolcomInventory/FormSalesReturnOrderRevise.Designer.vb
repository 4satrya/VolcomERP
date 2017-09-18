<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesReturnOrderRevise
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtAdd = New DevExpress.XtraEditors.TextEdit()
        Me.TxtSize = New DevExpress.XtraEditors.TextEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtDesign = New DevExpress.XtraEditors.TextEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtCode = New DevExpress.XtraEditors.TextEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtProcess = New DevExpress.XtraEditors.TextEdit()
        Me.TxtOutstanding = New DevExpress.XtraEditors.TextEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.TxtAdd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSize.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDesign.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtProcess.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtOutstanding.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 150)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 13)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Total Order"
        '
        'TxtAdd
        '
        Me.TxtAdd.Enabled = False
        Me.TxtAdd.Location = New System.Drawing.Point(90, 147)
        Me.TxtAdd.Name = "TxtAdd"
        Me.TxtAdd.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAdd.Properties.Appearance.Options.UseFont = True
        Me.TxtAdd.Properties.DisplayFormat.FormatString = "N0"
        Me.TxtAdd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtAdd.Properties.Mask.EditMask = "N0"
        Me.TxtAdd.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtAdd.Size = New System.Drawing.Size(276, 20)
        Me.TxtAdd.TabIndex = 23
        '
        'TxtSize
        '
        Me.TxtSize.Enabled = False
        Me.TxtSize.Location = New System.Drawing.Point(90, 69)
        Me.TxtSize.Name = "TxtSize"
        Me.TxtSize.Size = New System.Drawing.Size(276, 20)
        Me.TxtSize.TabIndex = 28
        Me.TxtSize.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Size"
        '
        'TxtDesign
        '
        Me.TxtDesign.Enabled = False
        Me.TxtDesign.Location = New System.Drawing.Point(90, 43)
        Me.TxtDesign.Name = "TxtDesign"
        Me.TxtDesign.Size = New System.Drawing.Size(276, 20)
        Me.TxtDesign.TabIndex = 26
        Me.TxtDesign.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Design"
        '
        'TxtCode
        '
        Me.TxtCode.Enabled = False
        Me.TxtCode.Location = New System.Drawing.Point(90, 17)
        Me.TxtCode.Name = "TxtCode"
        Me.TxtCode.Size = New System.Drawing.Size(276, 20)
        Me.TxtCode.TabIndex = 24
        Me.TxtCode.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Code"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "On Process"
        '
        'TxtProcess
        '
        Me.TxtProcess.Enabled = False
        Me.TxtProcess.Location = New System.Drawing.Point(90, 95)
        Me.TxtProcess.Name = "TxtProcess"
        Me.TxtProcess.Properties.DisplayFormat.FormatString = "N0"
        Me.TxtProcess.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtProcess.Properties.Mask.EditMask = "N0"
        Me.TxtProcess.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtProcess.Size = New System.Drawing.Size(276, 20)
        Me.TxtProcess.TabIndex = 30
        '
        'TxtOutstanding
        '
        Me.TxtOutstanding.Location = New System.Drawing.Point(90, 121)
        Me.TxtOutstanding.Name = "TxtOutstanding"
        Me.TxtOutstanding.Properties.DisplayFormat.FormatString = "N0"
        Me.TxtOutstanding.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtOutstanding.Properties.Mask.EditMask = "N0"
        Me.TxtOutstanding.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtOutstanding.Size = New System.Drawing.Size(276, 20)
        Me.TxtOutstanding.TabIndex = 32
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 124)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "Outstanding"
        '
        'FormSalesReturnOrderRevise
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(391, 192)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtOutstanding)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtProcess)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtAdd)
        Me.Controls.Add(Me.TxtSize)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtDesign)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtCode)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSalesReturnOrderRevise"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Revise Qty"
        CType(Me.TxtAdd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSize.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDesign.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtProcess.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtOutstanding.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label5 As Label
    Friend WithEvents TxtAdd As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtSize As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtDesign As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtProcess As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtOutstanding As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label6 As Label
End Class
