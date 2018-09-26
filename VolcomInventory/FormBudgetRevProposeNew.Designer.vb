<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBudgetRevProposeNew
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBudgetRevProposeNew))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtTotal = New DevExpress.XtraEditors.TextEdit()
        Me.TxtYear = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TxtTotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnCancel)
        Me.PanelControl1.Controls.Add(Me.BtnSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 130)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(393, 42)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(232, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(85, 38)
        Me.BtnCancel.TabIndex = 4
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnSave
        '
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSave.Image = CType(resources.GetObject("BtnSave.Image"), System.Drawing.Image)
        Me.BtnSave.Location = New System.Drawing.Point(317, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(74, 38)
        Me.BtnSave.TabIndex = 3
        Me.BtnSave.Text = "OK"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(17, 49)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(100, 16)
        Me.LabelControl2.TabIndex = 6
        Me.LabelControl2.Text = "Total Anggaran"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(17, 21)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(36, 16)
        Me.LabelControl1.TabIndex = 4
        Me.LabelControl1.Text = "Tahun"
        '
        'TxtTotal
        '
        Me.TxtTotal.Location = New System.Drawing.Point(136, 46)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotal.Properties.Appearance.Options.UseFont = True
        Me.TxtTotal.Properties.DisplayFormat.FormatString = "n2"
        Me.TxtTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtTotal.Properties.Mask.EditMask = "n2"
        Me.TxtTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtTotal.Size = New System.Drawing.Size(242, 22)
        Me.TxtTotal.TabIndex = 1
        '
        'TxtYear
        '
        Me.TxtYear.Location = New System.Drawing.Point(136, 18)
        Me.TxtYear.Name = "TxtYear"
        Me.TxtYear.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtYear.Properties.Appearance.Options.UseFont = True
        Me.TxtYear.Properties.Mask.EditMask = "f0"
        Me.TxtYear.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtYear.Properties.MaxLength = 4
        Me.TxtYear.Size = New System.Drawing.Size(99, 22)
        Me.TxtYear.TabIndex = 0
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(17, 75)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(26, 16)
        Me.LabelControl5.TabIndex = 9
        Me.LabelControl5.Text = "Note"
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(136, 74)
        Me.MENote.Name = "MENote"
        Me.MENote.Size = New System.Drawing.Size(242, 35)
        Me.MENote.TabIndex = 2
        '
        'FormBudgetRevProposeNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(393, 172)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.MENote)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.TxtTotal)
        Me.Controls.Add(Me.TxtYear)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormBudgetRevProposeNew"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create New"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.TxtTotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtTotal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtYear As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
End Class
