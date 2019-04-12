<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormOLStoreOrderId
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
        Me.TxtOrderNumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtItemId = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtOLStoreId = New DevExpress.XtraEditors.TextEdit()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnDiscard = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.TxtOrderNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtItemId.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtOLStoreId.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(17, 14)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(68, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Order Number"
        '
        'TxtOrderNumber
        '
        Me.TxtOrderNumber.Location = New System.Drawing.Point(17, 33)
        Me.TxtOrderNumber.Name = "TxtOrderNumber"
        Me.TxtOrderNumber.Size = New System.Drawing.Size(290, 20)
        Me.TxtOrderNumber.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(17, 59)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Item Id"
        '
        'TxtItemId
        '
        Me.TxtItemId.Location = New System.Drawing.Point(17, 78)
        Me.TxtItemId.Name = "TxtItemId"
        Me.TxtItemId.Size = New System.Drawing.Size(290, 20)
        Me.TxtItemId.TabIndex = 3
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(17, 104)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(55, 13)
        Me.LabelControl3.TabIndex = 4
        Me.LabelControl3.Text = "OL Store Id"
        '
        'TxtOLStoreId
        '
        Me.TxtOLStoreId.Location = New System.Drawing.Point(17, 123)
        Me.TxtOLStoreId.Name = "TxtOLStoreId"
        Me.TxtOLStoreId.Size = New System.Drawing.Size(290, 20)
        Me.TxtOLStoreId.TabIndex = 5
        '
        'BtnSave
        '
        Me.BtnSave.Appearance.BackColor = System.Drawing.SystemColors.Highlight
        Me.BtnSave.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnSave.Appearance.Options.UseBackColor = True
        Me.BtnSave.Appearance.Options.UseFont = True
        Me.BtnSave.Appearance.Options.UseForeColor = True
        Me.BtnSave.Location = New System.Drawing.Point(206, 153)
        Me.BtnSave.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnSave.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Red
        Me.BtnSave.LookAndFeel.SkinName = "Metropolis"
        Me.BtnSave.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnSave.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(101, 31)
        Me.BtnSave.TabIndex = 9
        Me.BtnSave.Text = "Save Changes"
        '
        'BtnDiscard
        '
        Me.BtnDiscard.Appearance.BackColor = System.Drawing.Color.Crimson
        Me.BtnDiscard.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDiscard.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnDiscard.Appearance.Options.UseBackColor = True
        Me.BtnDiscard.Appearance.Options.UseFont = True
        Me.BtnDiscard.Appearance.Options.UseForeColor = True
        Me.BtnDiscard.Location = New System.Drawing.Point(117, 153)
        Me.BtnDiscard.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnDiscard.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Red
        Me.BtnDiscard.LookAndFeel.SkinName = "Metropolis"
        Me.BtnDiscard.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnDiscard.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnDiscard.Name = "BtnDiscard"
        Me.BtnDiscard.Size = New System.Drawing.Size(85, 31)
        Me.BtnDiscard.TabIndex = 10
        Me.BtnDiscard.Text = "Discard"
        '
        'FormOLStoreOrderId
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(325, 205)
        Me.Controls.Add(Me.BtnDiscard)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.TxtOLStoreId)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.TxtItemId)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.TxtOrderNumber)
        Me.Controls.Add(Me.LabelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormOLStoreOrderId"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Order Id"
        CType(Me.TxtOrderNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtItemId.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtOLStoreId.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtOrderNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtItemId As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtOLStoreId As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnDiscard As DevExpress.XtraEditors.SimpleButton
End Class
