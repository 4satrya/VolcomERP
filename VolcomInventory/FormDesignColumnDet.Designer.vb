<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormDesignColumnDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDesignColumnDet))
        Me.TEColumnName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.CEIsLookUp = New DevExpress.XtraEditors.CheckEdit()
        Me.SBSave = New DevExpress.XtraEditors.SimpleButton()
        Me.SBClose = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.TEColumnName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CEIsLookUp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TEColumnName
        '
        Me.TEColumnName.Location = New System.Drawing.Point(12, 31)
        Me.TEColumnName.Name = "TEColumnName"
        Me.TEColumnName.Size = New System.Drawing.Size(360, 20)
        Me.TEColumnName.TabIndex = 3
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Column Name"
        '
        'CEIsLookUp
        '
        Me.CEIsLookUp.EditValue = True
        Me.CEIsLookUp.Location = New System.Drawing.Point(12, 65)
        Me.CEIsLookUp.Name = "CEIsLookUp"
        Me.CEIsLookUp.Properties.Caption = "Is Look Up"
        Me.CEIsLookUp.Size = New System.Drawing.Size(75, 19)
        Me.CEIsLookUp.TabIndex = 4
        '
        'SBSave
        '
        Me.SBSave.Image = CType(resources.GetObject("SBSave.Image"), System.Drawing.Image)
        Me.SBSave.Location = New System.Drawing.Point(297, 101)
        Me.SBSave.Name = "SBSave"
        Me.SBSave.Size = New System.Drawing.Size(75, 23)
        Me.SBSave.TabIndex = 5
        Me.SBSave.Text = "Save"
        '
        'SBClose
        '
        Me.SBClose.Image = CType(resources.GetObject("SBClose.Image"), System.Drawing.Image)
        Me.SBClose.Location = New System.Drawing.Point(216, 101)
        Me.SBClose.Name = "SBClose"
        Me.SBClose.Size = New System.Drawing.Size(75, 23)
        Me.SBClose.TabIndex = 6
        Me.SBClose.Text = "Close"
        '
        'FormDesignColumnDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 138)
        Me.Controls.Add(Me.SBClose)
        Me.Controls.Add(Me.SBSave)
        Me.Controls.Add(Me.CEIsLookUp)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.TEColumnName)
        Me.Name = "FormDesignColumnDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Design Column Detail"
        CType(Me.TEColumnName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CEIsLookUp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TEColumnName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CEIsLookUp As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents SBSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBClose As DevExpress.XtraEditors.SimpleButton
End Class
