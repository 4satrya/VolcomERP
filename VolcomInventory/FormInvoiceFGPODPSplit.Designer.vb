<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInvoiceFGPODPSplit
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
        Me.BSplit = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TEAmount = New DevExpress.XtraEditors.TextEdit()
        Me.TEVAT = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TEAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEVAT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BSplit)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 87)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(372, 34)
        Me.PanelControl1.TabIndex = 0
        '
        'BSplit
        '
        Me.BSplit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BSplit.Location = New System.Drawing.Point(2, 2)
        Me.BSplit.Name = "BSplit"
        Me.BSplit.Size = New System.Drawing.Size(368, 30)
        Me.BSplit.TabIndex = 0
        Me.BSplit.Text = "Split"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 24)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Amount"
        '
        'TEAmount
        '
        Me.TEAmount.Location = New System.Drawing.Point(93, 21)
        Me.TEAmount.Name = "TEAmount"
        Me.TEAmount.Properties.Appearance.Options.UseTextOptions = True
        Me.TEAmount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEAmount.Properties.DisplayFormat.FormatString = "N2"
        Me.TEAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TEAmount.Properties.Mask.EditMask = "N2"
        Me.TEAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEAmount.Size = New System.Drawing.Size(267, 20)
        Me.TEAmount.TabIndex = 2
        '
        'TEVAT
        '
        Me.TEVAT.Location = New System.Drawing.Point(93, 47)
        Me.TEVAT.Name = "TEVAT"
        Me.TEVAT.Properties.Appearance.Options.UseTextOptions = True
        Me.TEVAT.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEVAT.Properties.DisplayFormat.FormatString = "N2"
        Me.TEVAT.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TEVAT.Properties.Mask.EditMask = "N2"
        Me.TEVAT.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEVAT.Size = New System.Drawing.Size(267, 20)
        Me.TEVAT.TabIndex = 4
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 50)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(19, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "VAT"
        '
        'FormInvoiceFGPODPSplit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(372, 121)
        Me.Controls.Add(Me.TEVAT)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.TEAmount)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormInvoiceFGPODPSplit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Split Invoice"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.TEAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEVAT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BSplit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEAmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEVAT As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
End Class
