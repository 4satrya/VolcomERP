<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterEmployeeSalary
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
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtBasicSalary = New DevExpress.XtraEditors.TextEdit()
        Me.TxtAllowJob = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtAllowMeal = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtAllowTrans = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtAllowHouse = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtAllowCar = New DevExpress.XtraEditors.TextEdit()
        Me.TETotal = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TxtBasicSalary.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtAllowJob.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtAllowMeal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtAllowTrans.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtAllowHouse.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtAllowCar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TETotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 344)
        Me.PanelControl1.LookAndFeel.SkinName = "Blue"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(463, 38)
        Me.PanelControl1.TabIndex = 100
        '
        'BtnSave
        '
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSave.Location = New System.Drawing.Point(386, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 34)
        Me.BtnSave.TabIndex = 6
        Me.BtnSave.Text = "Save"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(57, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Basic Salary"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 57)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(68, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Job Allowance"
        '
        'TxtBasicSalary
        '
        Me.TxtBasicSalary.Location = New System.Drawing.Point(12, 31)
        Me.TxtBasicSalary.Name = "TxtBasicSalary"
        Me.TxtBasicSalary.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBasicSalary.Properties.Appearance.Options.UseFont = True
        Me.TxtBasicSalary.Properties.Mask.EditMask = "n2"
        Me.TxtBasicSalary.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtBasicSalary.Properties.Mask.SaveLiteral = False
        Me.TxtBasicSalary.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TxtBasicSalary.Properties.MaxLength = 50
        Me.TxtBasicSalary.Size = New System.Drawing.Size(427, 20)
        Me.TxtBasicSalary.TabIndex = 0
        Me.TxtBasicSalary.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.TxtBasicSalary.ToolTipTitle = "Information"
        '
        'TxtAllowJob
        '
        Me.TxtAllowJob.Location = New System.Drawing.Point(12, 76)
        Me.TxtAllowJob.Name = "TxtAllowJob"
        Me.TxtAllowJob.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAllowJob.Properties.Appearance.Options.UseFont = True
        Me.TxtAllowJob.Properties.Mask.EditMask = "n2"
        Me.TxtAllowJob.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtAllowJob.Properties.Mask.SaveLiteral = False
        Me.TxtAllowJob.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TxtAllowJob.Properties.MaxLength = 50
        Me.TxtAllowJob.Size = New System.Drawing.Size(427, 20)
        Me.TxtAllowJob.TabIndex = 1
        Me.TxtAllowJob.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.TxtAllowJob.ToolTipTitle = "Information"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(12, 102)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(73, 13)
        Me.LabelControl3.TabIndex = 5
        Me.LabelControl3.Text = "Meal Allowance"
        '
        'TxtAllowMeal
        '
        Me.TxtAllowMeal.Location = New System.Drawing.Point(12, 121)
        Me.TxtAllowMeal.Name = "TxtAllowMeal"
        Me.TxtAllowMeal.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAllowMeal.Properties.Appearance.Options.UseFont = True
        Me.TxtAllowMeal.Properties.Mask.EditMask = "n2"
        Me.TxtAllowMeal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtAllowMeal.Properties.Mask.SaveLiteral = False
        Me.TxtAllowMeal.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TxtAllowMeal.Properties.MaxLength = 50
        Me.TxtAllowMeal.Size = New System.Drawing.Size(427, 20)
        Me.TxtAllowMeal.TabIndex = 2
        Me.TxtAllowMeal.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.TxtAllowMeal.ToolTipTitle = "Information"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(12, 147)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(98, 13)
        Me.LabelControl4.TabIndex = 7
        Me.LabelControl4.Text = "Transport Allowance"
        '
        'TxtAllowTrans
        '
        Me.TxtAllowTrans.Location = New System.Drawing.Point(12, 166)
        Me.TxtAllowTrans.Name = "TxtAllowTrans"
        Me.TxtAllowTrans.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAllowTrans.Properties.Appearance.Options.UseFont = True
        Me.TxtAllowTrans.Properties.Mask.EditMask = "n2"
        Me.TxtAllowTrans.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtAllowTrans.Properties.Mask.SaveLiteral = False
        Me.TxtAllowTrans.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TxtAllowTrans.Properties.MaxLength = 50
        Me.TxtAllowTrans.Size = New System.Drawing.Size(427, 20)
        Me.TxtAllowTrans.TabIndex = 3
        Me.TxtAllowTrans.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.TxtAllowTrans.ToolTipTitle = "Information"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(12, 192)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(81, 13)
        Me.LabelControl5.TabIndex = 9
        Me.LabelControl5.Text = "House Allowance"
        '
        'TxtAllowHouse
        '
        Me.TxtAllowHouse.Location = New System.Drawing.Point(12, 211)
        Me.TxtAllowHouse.Name = "TxtAllowHouse"
        Me.TxtAllowHouse.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAllowHouse.Properties.Appearance.Options.UseFont = True
        Me.TxtAllowHouse.Properties.Mask.EditMask = "n2"
        Me.TxtAllowHouse.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtAllowHouse.Properties.Mask.SaveLiteral = False
        Me.TxtAllowHouse.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TxtAllowHouse.Properties.MaxLength = 50
        Me.TxtAllowHouse.Size = New System.Drawing.Size(427, 20)
        Me.TxtAllowHouse.TabIndex = 4
        Me.TxtAllowHouse.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.TxtAllowHouse.ToolTipTitle = "Information"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(12, 237)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(107, 13)
        Me.LabelControl6.TabIndex = 11
        Me.LabelControl6.Text = "Attendance Allowance"
        '
        'TxtAllowCar
        '
        Me.TxtAllowCar.Location = New System.Drawing.Point(12, 256)
        Me.TxtAllowCar.Name = "TxtAllowCar"
        Me.TxtAllowCar.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAllowCar.Properties.Appearance.Options.UseFont = True
        Me.TxtAllowCar.Properties.Mask.EditMask = "n2"
        Me.TxtAllowCar.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtAllowCar.Properties.Mask.SaveLiteral = False
        Me.TxtAllowCar.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TxtAllowCar.Properties.MaxLength = 50
        Me.TxtAllowCar.Size = New System.Drawing.Size(427, 20)
        Me.TxtAllowCar.TabIndex = 5
        Me.TxtAllowCar.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.TxtAllowCar.ToolTipTitle = "Information"
        '
        'TETotal
        '
        Me.TETotal.Location = New System.Drawing.Point(12, 301)
        Me.TETotal.Name = "TETotal"
        Me.TETotal.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TETotal.Properties.Appearance.Options.UseFont = True
        Me.TETotal.Properties.Mask.EditMask = "n2"
        Me.TETotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TETotal.Properties.Mask.SaveLiteral = False
        Me.TETotal.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TETotal.Properties.MaxLength = 50
        Me.TETotal.Properties.ReadOnly = True
        Me.TETotal.Size = New System.Drawing.Size(427, 20)
        Me.TETotal.TabIndex = 101
        Me.TETotal.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.TETotal.ToolTipTitle = "Information"
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(12, 282)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(57, 13)
        Me.LabelControl7.TabIndex = 102
        Me.LabelControl7.Text = "Total Salary"
        '
        'FormMasterEmployeeSalary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(463, 382)
        Me.Controls.Add(Me.TETotal)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.TxtAllowCar)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.TxtAllowHouse)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.TxtAllowTrans)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.TxtAllowMeal)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.TxtAllowJob)
        Me.Controls.Add(Me.TxtBasicSalary)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterEmployeeSalary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Salary"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.TxtBasicSalary.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtAllowJob.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtAllowMeal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtAllowTrans.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtAllowHouse.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtAllowCar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TETotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtBasicSalary As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtAllowJob As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtAllowMeal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtAllowTrans As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtAllowHouse As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtAllowCar As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TETotal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
End Class
