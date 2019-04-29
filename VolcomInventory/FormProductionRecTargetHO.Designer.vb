<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProductionRecTargetHO
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProductionRecTargetHO))
        Me.BUpdate = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.DEBefore = New DevExpress.XtraEditors.DateEdit()
        Me.DEAfter = New DevExpress.XtraEditors.DateEdit()
        CType(Me.DEBefore.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEBefore.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEAfter.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEAfter.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BUpdate
        '
        Me.BUpdate.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BUpdate.Image = CType(resources.GetObject("BUpdate.Image"), System.Drawing.Image)
        Me.BUpdate.Location = New System.Drawing.Point(0, 76)
        Me.BUpdate.Name = "BUpdate"
        Me.BUpdate.Size = New System.Drawing.Size(397, 34)
        Me.BUpdate.TabIndex = 8909
        Me.BUpdate.Text = "Update Target Handover"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 19)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(32, 13)
        Me.LabelControl1.TabIndex = 8910
        Me.LabelControl1.Text = "Before"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 45)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(25, 13)
        Me.LabelControl2.TabIndex = 8911
        Me.LabelControl2.Text = "After"
        '
        'DEBefore
        '
        Me.DEBefore.EditValue = Nothing
        Me.DEBefore.Enabled = False
        Me.DEBefore.Location = New System.Drawing.Point(68, 16)
        Me.DEBefore.Name = "DEBefore"
        Me.DEBefore.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEBefore.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEBefore.Size = New System.Drawing.Size(318, 20)
        Me.DEBefore.TabIndex = 8912
        '
        'DEAfter
        '
        Me.DEAfter.EditValue = Nothing
        Me.DEAfter.Location = New System.Drawing.Point(68, 42)
        Me.DEAfter.Name = "DEAfter"
        Me.DEAfter.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEAfter.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEAfter.Size = New System.Drawing.Size(318, 20)
        Me.DEAfter.TabIndex = 8913
        '
        'FormProductionRecTargetHO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(397, 110)
        Me.Controls.Add(Me.DEAfter)
        Me.Controls.Add(Me.DEBefore)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.BUpdate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormProductionRecTargetHO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Target Handover"
        CType(Me.DEBefore.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEBefore.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEAfter.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEAfter.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BUpdate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEBefore As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEAfter As DevExpress.XtraEditors.DateEdit
End Class
