<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPayoutZaloraComm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPayoutZaloraComm))
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnDiscard = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnConfirm = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtComm = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtCommTax = New DevExpress.XtraEditors.TextEdit()
        Me.TxtTotalCommInput = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtLinkComm = New DevExpress.XtraEditors.HyperLinkEdit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TxtComm.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCommTax.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTotalCommInput.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtLinkComm.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnDiscard)
        Me.PanelControl1.Controls.Add(Me.BtnConfirm)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 205)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(400, 44)
        Me.PanelControl1.TabIndex = 1
        '
        'BtnDiscard
        '
        Me.BtnDiscard.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDiscard.Image = CType(resources.GetObject("BtnDiscard.Image"), System.Drawing.Image)
        Me.BtnDiscard.Location = New System.Drawing.Point(226, 2)
        Me.BtnDiscard.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BtnDiscard.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnDiscard.Name = "BtnDiscard"
        Me.BtnDiscard.Size = New System.Drawing.Size(86, 40)
        Me.BtnDiscard.TabIndex = 1
        Me.BtnDiscard.Text = "Discard"
        '
        'BtnConfirm
        '
        Me.BtnConfirm.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnConfirm.Image = CType(resources.GetObject("BtnConfirm.Image"), System.Drawing.Image)
        Me.BtnConfirm.Location = New System.Drawing.Point(312, 2)
        Me.BtnConfirm.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BtnConfirm.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnConfirm.Name = "BtnConfirm"
        Me.BtnConfirm.Size = New System.Drawing.Size(86, 40)
        Me.BtnConfirm.TabIndex = 0
        Me.BtnConfirm.Text = "Confirm"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(108, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Verified Commision"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 57)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "Commision"
        '
        'TxtComm
        '
        Me.TxtComm.Location = New System.Drawing.Point(12, 76)
        Me.TxtComm.Name = "TxtComm"
        Me.TxtComm.Properties.DisplayFormat.FormatString = "N2"
        Me.TxtComm.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtComm.Properties.Mask.EditMask = "N2"
        Me.TxtComm.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtComm.Size = New System.Drawing.Size(371, 20)
        Me.TxtComm.TabIndex = 5
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(12, 102)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(84, 13)
        Me.LabelControl3.TabIndex = 7
        Me.LabelControl3.Text = "Tax of Commision"
        '
        'TxtCommTax
        '
        Me.TxtCommTax.Location = New System.Drawing.Point(12, 121)
        Me.TxtCommTax.Name = "TxtCommTax"
        Me.TxtCommTax.Properties.DisplayFormat.FormatString = "N2"
        Me.TxtCommTax.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtCommTax.Properties.Mask.EditMask = "N2"
        Me.TxtCommTax.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtCommTax.Size = New System.Drawing.Size(371, 20)
        Me.TxtCommTax.TabIndex = 8
        '
        'TxtTotalCommInput
        '
        Me.TxtTotalCommInput.Enabled = False
        Me.TxtTotalCommInput.Location = New System.Drawing.Point(12, 166)
        Me.TxtTotalCommInput.Name = "TxtTotalCommInput"
        Me.TxtTotalCommInput.Properties.DisplayFormat.FormatString = "N2"
        Me.TxtTotalCommInput.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtTotalCommInput.Properties.Mask.EditMask = "N2"
        Me.TxtTotalCommInput.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtTotalCommInput.Size = New System.Drawing.Size(371, 20)
        Me.TxtTotalCommInput.TabIndex = 9
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(12, 147)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(77, 13)
        Me.LabelControl4.TabIndex = 10
        Me.LabelControl4.Text = "Total Commision"
        '
        'TxtLinkComm
        '
        Me.TxtLinkComm.Location = New System.Drawing.Point(12, 31)
        Me.TxtLinkComm.Name = "TxtLinkComm"
        Me.TxtLinkComm.Properties.DisplayFormat.FormatString = "N2"
        Me.TxtLinkComm.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtLinkComm.Properties.ReadOnly = True
        Me.TxtLinkComm.Size = New System.Drawing.Size(371, 20)
        Me.TxtLinkComm.TabIndex = 11
        '
        'FormPayoutZaloraComm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 249)
        Me.Controls.Add(Me.TxtLinkComm)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.TxtTotalCommInput)
        Me.Controls.Add(Me.TxtCommTax)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.TxtComm)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPayoutZaloraComm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Setup Commision"
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.TxtComm.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCommTax.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTotalCommInput.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtLinkComm.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnDiscard As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnConfirm As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtComm As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtCommTax As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtTotalCommInput As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtLinkComm As DevExpress.XtraEditors.HyperLinkEdit
End Class
