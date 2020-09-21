<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSampleDevelopmentVerifyCPS2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSampleDevelopmentVerifyCPS2))
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.BUpdate = New DevExpress.XtraEditors.SimpleButton()
        Me.TEDesignName = New DevExpress.XtraEditors.TextEdit()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TEDesignCode = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TEFGPO = New DevExpress.XtraEditors.TextEdit()
        Me.TEVendor = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.DEVerifyDate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.TEDesignName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEDesignCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEFGPO.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEVendor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEVerifyDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEVerifyDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.SimpleButton1)
        Me.PanelControl2.Controls.Add(Me.BUpdate)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 274)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(511, 40)
        Me.PanelControl2.TabIndex = 3
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButton1.Image = CType(resources.GetObject("SimpleButton1.Image"), System.Drawing.Image)
        Me.SimpleButton1.ImageIndex = 7
        Me.SimpleButton1.Location = New System.Drawing.Point(212, 2)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(99, 36)
        Me.SimpleButton1.TabIndex = 8912
        Me.SimpleButton1.Text = "Cancel"
        '
        'BUpdate
        '
        Me.BUpdate.Dock = System.Windows.Forms.DockStyle.Right
        Me.BUpdate.Image = CType(resources.GetObject("BUpdate.Image"), System.Drawing.Image)
        Me.BUpdate.ImageIndex = 7
        Me.BUpdate.Location = New System.Drawing.Point(311, 2)
        Me.BUpdate.Name = "BUpdate"
        Me.BUpdate.Size = New System.Drawing.Size(198, 36)
        Me.BUpdate.TabIndex = 8911
        Me.BUpdate.Text = "Verify Copy Prototype Sample 2"
        '
        'TEDesignName
        '
        Me.TEDesignName.Location = New System.Drawing.Point(195, 64)
        Me.TEDesignName.Name = "TEDesignName"
        Me.TEDesignName.Properties.ReadOnly = True
        Me.TEDesignName.Size = New System.Drawing.Size(292, 20)
        Me.TEDesignName.TabIndex = 4
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(70, 90)
        Me.MENote.Name = "MENote"
        Me.MENote.Size = New System.Drawing.Size(417, 141)
        Me.MENote.TabIndex = 5
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(10, 67)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(32, 13)
        Me.LabelControl1.TabIndex = 6
        Me.LabelControl1.Text = "Design"
        '
        'TEDesignCode
        '
        Me.TEDesignCode.Location = New System.Drawing.Point(70, 64)
        Me.TEDesignCode.Name = "TEDesignCode"
        Me.TEDesignCode.Properties.ReadOnly = True
        Me.TEDesignCode.Size = New System.Drawing.Size(119, 20)
        Me.TEDesignCode.TabIndex = 7
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(10, 92)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl2.TabIndex = 8
        Me.LabelControl2.Text = "Note"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(10, 15)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl3.TabIndex = 9
        Me.LabelControl3.Text = "F.G.PO"
        '
        'TEFGPO
        '
        Me.TEFGPO.Location = New System.Drawing.Point(70, 12)
        Me.TEFGPO.Name = "TEFGPO"
        Me.TEFGPO.Properties.ReadOnly = True
        Me.TEFGPO.Size = New System.Drawing.Size(241, 20)
        Me.TEFGPO.TabIndex = 10
        '
        'TEVendor
        '
        Me.TEVendor.Location = New System.Drawing.Point(70, 38)
        Me.TEVendor.Name = "TEVendor"
        Me.TEVendor.Properties.ReadOnly = True
        Me.TEVendor.Size = New System.Drawing.Size(331, 20)
        Me.TEVendor.TabIndex = 12
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(10, 41)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl4.TabIndex = 11
        Me.LabelControl4.Text = "Vendor"
        '
        'DEVerifyDate
        '
        Me.DEVerifyDate.EditValue = Nothing
        Me.DEVerifyDate.Location = New System.Drawing.Point(70, 237)
        Me.DEVerifyDate.Name = "DEVerifyDate"
        Me.DEVerifyDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEVerifyDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEVerifyDate.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEVerifyDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEVerifyDate.Size = New System.Drawing.Size(253, 20)
        Me.DEVerifyDate.TabIndex = 13
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(10, 240)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(54, 13)
        Me.LabelControl5.TabIndex = 14
        Me.LabelControl5.Text = "Verify Date"
        '
        'FormSampleDevelopmentVerifyCPS2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(511, 314)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.DEVerifyDate)
        Me.Controls.Add(Me.TEVendor)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.TEFGPO)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.TEDesignCode)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.MENote)
        Me.Controls.Add(Me.TEDesignName)
        Me.Controls.Add(Me.PanelControl2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSampleDevelopmentVerifyCPS2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Verify Copy Prototype Sample 2"
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.TEDesignName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEDesignCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEFGPO.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEVendor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEVerifyDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEVerifyDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BUpdate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEDesignName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEDesignCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEFGPO As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEVendor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEVerifyDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
End Class
