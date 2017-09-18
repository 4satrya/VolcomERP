<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormSalesOrderDetEdit
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtCode = New DevExpress.XtraEditors.TextEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtDesign = New DevExpress.XtraEditors.TextEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtSize = New DevExpress.XtraEditors.TextEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtCurrent = New DevExpress.XtraEditors.TextEdit()
        Me.TxtAdd = New DevExpress.XtraEditors.TextEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtQty = New DevExpress.XtraEditors.TextEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.TxtCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDesign.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSize.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCurrent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtAdd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtQty.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Code"
        '
        'TxtCode
        '
        Me.TxtCode.Enabled = False
        Me.TxtCode.Location = New System.Drawing.Point(89, 12)
        Me.TxtCode.Name = "TxtCode"
        Me.TxtCode.Size = New System.Drawing.Size(276, 20)
        Me.TxtCode.TabIndex = 1
        Me.TxtCode.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Design"
        '
        'TxtDesign
        '
        Me.TxtDesign.Enabled = False
        Me.TxtDesign.Location = New System.Drawing.Point(89, 38)
        Me.TxtDesign.Name = "TxtDesign"
        Me.TxtDesign.Size = New System.Drawing.Size(276, 20)
        Me.TxtDesign.TabIndex = 3
        Me.TxtDesign.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Size"
        '
        'TxtSize
        '
        Me.TxtSize.Enabled = False
        Me.TxtSize.Location = New System.Drawing.Point(89, 64)
        Me.TxtSize.Name = "TxtSize"
        Me.TxtSize.Size = New System.Drawing.Size(276, 20)
        Me.TxtSize.TabIndex = 5
        Me.TxtSize.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Current Qty"
        '
        'TxtCurrent
        '
        Me.TxtCurrent.Enabled = False
        Me.TxtCurrent.Location = New System.Drawing.Point(89, 87)
        Me.TxtCurrent.Name = "TxtCurrent"
        Me.TxtCurrent.Properties.DisplayFormat.FormatString = "N0"
        Me.TxtCurrent.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtCurrent.Size = New System.Drawing.Size(276, 20)
        Me.TxtCurrent.TabIndex = 7
        Me.TxtCurrent.TabStop = False
        '
        'TxtAdd
        '
        Me.TxtAdd.Location = New System.Drawing.Point(89, 113)
        Me.TxtAdd.Name = "TxtAdd"
        Me.TxtAdd.Properties.DisplayFormat.FormatString = "N0"
        Me.TxtAdd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtAdd.Properties.Mask.EditMask = "N0"
        Me.TxtAdd.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtAdd.Size = New System.Drawing.Size(276, 20)
        Me.TxtAdd.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Added Qty"
        '
        'TxtQty
        '
        Me.TxtQty.Enabled = False
        Me.TxtQty.Location = New System.Drawing.Point(89, 139)
        Me.TxtQty.Name = "TxtQty"
        Me.TxtQty.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtQty.Properties.Appearance.Options.UseFont = True
        Me.TxtQty.Properties.DisplayFormat.FormatString = "N0"
        Me.TxtQty.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtQty.Size = New System.Drawing.Size(276, 20)
        Me.TxtQty.TabIndex = 10
        Me.TxtQty.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 142)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(27, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Qty"
        '
        'FormSalesOrderDetEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(386, 183)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtQty)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtAdd)
        Me.Controls.Add(Me.TxtCurrent)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtSize)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtDesign)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtCode)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSalesOrderDetEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Quantity"
        CType(Me.TxtCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDesign.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSize.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCurrent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtAdd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtQty.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TxtCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtDesign As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtSize As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtCurrent As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtAdd As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtQty As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label6 As Label
End Class
