<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesPOSNoStockAdd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSalesPOSNoStockAdd))
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtAdd = New DevExpress.XtraEditors.TextEdit()
        Me.TxtSize = New DevExpress.XtraEditors.TextEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtDesign = New DevExpress.XtraEditors.TextEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtCode = New DevExpress.XtraEditors.TextEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtPrice = New DevExpress.XtraEditors.TextEdit()
        Me.BtnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnBrowse = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.TxtAdd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSize.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDesign.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPrice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 98)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(25, 13)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Qty"
        '
        'TxtAdd
        '
        Me.TxtAdd.Location = New System.Drawing.Point(65, 95)
        Me.TxtAdd.Name = "TxtAdd"
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
        Me.TxtSize.Location = New System.Drawing.Point(65, 69)
        Me.TxtSize.Name = "TxtSize"
        Me.TxtSize.Size = New System.Drawing.Size(67, 20)
        Me.TxtSize.TabIndex = 28
        Me.TxtSize.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Size"
        '
        'TxtDesign
        '
        Me.TxtDesign.Enabled = False
        Me.TxtDesign.Location = New System.Drawing.Point(65, 43)
        Me.TxtDesign.Name = "TxtDesign"
        Me.TxtDesign.Size = New System.Drawing.Size(276, 20)
        Me.TxtDesign.TabIndex = 26
        Me.TxtDesign.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Design"
        '
        'TxtCode
        '
        Me.TxtCode.Location = New System.Drawing.Point(65, 17)
        Me.TxtCode.Name = "TxtCode"
        Me.TxtCode.Size = New System.Drawing.Size(276, 20)
        Me.TxtCode.TabIndex = 24
        Me.TxtCode.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Code"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(135, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Price"
        '
        'TxtPrice
        '
        Me.TxtPrice.Enabled = False
        Me.TxtPrice.Location = New System.Drawing.Point(164, 69)
        Me.TxtPrice.Name = "TxtPrice"
        Me.TxtPrice.Properties.DisplayFormat.FormatString = "N0"
        Me.TxtPrice.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtPrice.Properties.Mask.EditMask = "N0"
        Me.TxtPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtPrice.Size = New System.Drawing.Size(146, 20)
        Me.TxtPrice.TabIndex = 31
        '
        'BtnAdd
        '
        Me.BtnAdd.Appearance.BackColor = System.Drawing.SystemColors.Highlight
        Me.BtnAdd.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAdd.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnAdd.Appearance.Options.UseBackColor = True
        Me.BtnAdd.Appearance.Options.UseFont = True
        Me.BtnAdd.Appearance.Options.UseForeColor = True
        Me.BtnAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAdd.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.BtnAdd.Location = New System.Drawing.Point(297, 2)
        Me.BtnAdd.LookAndFeel.SkinName = "Metropolis"
        Me.BtnAdd.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnAdd.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(66, 33)
        Me.BtnAdd.TabIndex = 139
        Me.BtnAdd.Text = "Add"
        '
        'BtnClose
        '
        Me.BtnClose.Appearance.BackColor = System.Drawing.Color.Crimson
        Me.BtnClose.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnClose.Appearance.Options.UseBackColor = True
        Me.BtnClose.Appearance.Options.UseFont = True
        Me.BtnClose.Appearance.Options.UseForeColor = True
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnClose.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.BtnClose.Location = New System.Drawing.Point(230, 2)
        Me.BtnClose.LookAndFeel.SkinName = "Metropolis"
        Me.BtnClose.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnClose.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(67, 33)
        Me.BtnClose.TabIndex = 140
        Me.BtnClose.Text = "Close"
        '
        'BtnBrowse
        '
        Me.BtnBrowse.Image = CType(resources.GetObject("BtnBrowse.Image"), System.Drawing.Image)
        Me.BtnBrowse.Location = New System.Drawing.Point(314, 69)
        Me.BtnBrowse.Name = "BtnBrowse"
        Me.BtnBrowse.Size = New System.Drawing.Size(27, 20)
        Me.BtnBrowse.TabIndex = 141
        Me.BtnBrowse.Text = "SimpleButton1"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnClose)
        Me.PanelControl1.Controls.Add(Me.BtnAdd)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 174)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(365, 37)
        Me.PanelControl1.TabIndex = 142
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(65, 121)
        Me.MENote.Name = "MENote"
        Me.MENote.Size = New System.Drawing.Size(276, 37)
        Me.MENote.TabIndex = 143
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(20, 123)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl1.TabIndex = 144
        Me.LabelControl1.Text = "Note"
        '
        'FormSalesPOSNoStockAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(365, 211)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.MENote)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.BtnBrowse)
        Me.Controls.Add(Me.TxtPrice)
        Me.Controls.Add(Me.Label4)
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
        Me.Name = "FormSalesPOSNoStockAdd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "No Stock - Add"
        CType(Me.TxtAdd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSize.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDesign.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPrice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents TxtPrice As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BtnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnBrowse As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
End Class
