<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesReturnInputTanggalPickup
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
        Me.DETanggalInput = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SBSave = New DevExpress.XtraEditors.SimpleButton()
        Me.SBClose = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.DETanggalInput.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DETanggalInput.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DETanggalInput
        '
        Me.DETanggalInput.EditValue = Nothing
        Me.DETanggalInput.Location = New System.Drawing.Point(12, 41)
        Me.DETanggalInput.Name = "DETanggalInput"
        Me.DETanggalInput.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DETanggalInput.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DETanggalInput.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DETanggalInput.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DETanggalInput.Properties.EditFormat.FormatString = "dd MMMM yyyy"
        Me.DETanggalInput.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DETanggalInput.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DETanggalInput.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DETanggalInput.Size = New System.Drawing.Size(260, 20)
        Me.DETanggalInput.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 17)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(89, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Store Pick Up Date"
        '
        'SBSave
        '
        Me.SBSave.Location = New System.Drawing.Point(197, 67)
        Me.SBSave.Name = "SBSave"
        Me.SBSave.Size = New System.Drawing.Size(75, 23)
        Me.SBSave.TabIndex = 2
        Me.SBSave.Text = "Save"
        '
        'SBClose
        '
        Me.SBClose.Location = New System.Drawing.Point(116, 67)
        Me.SBClose.Name = "SBClose"
        Me.SBClose.Size = New System.Drawing.Size(75, 23)
        Me.SBClose.TabIndex = 3
        Me.SBClose.Text = "Close"
        '
        'FormSalesReturnInputTanggalPickup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 104)
        Me.Controls.Add(Me.SBClose)
        Me.Controls.Add(Me.SBSave)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.DETanggalInput)
        Me.Name = "FormSalesReturnInputTanggalPickup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Input Store Pick Up Date"
        CType(Me.DETanggalInput.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DETanggalInput.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DETanggalInput As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SBSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBClose As DevExpress.XtraEditors.SimpleButton
End Class
