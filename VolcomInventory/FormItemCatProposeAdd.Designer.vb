<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormItemCatProposeAdd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormItemCatProposeAdd))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LookUpEdit1 = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtCat = New DevExpress.XtraEditors.TextEdit()
        Me.TxtCatEn = New DevExpress.XtraEditors.TextEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BTnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.LookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCatEn.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Expense Type"
        '
        'LookUpEdit1
        '
        Me.LookUpEdit1.Location = New System.Drawing.Point(133, 18)
        Me.LookUpEdit1.Name = "LookUpEdit1"
        Me.LookUpEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LookUpEdit1.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_expense_type", "Id", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("expense_type", "Type")})
        Me.LookUpEdit1.Size = New System.Drawing.Size(231, 20)
        Me.LookUpEdit1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Category"
        '
        'TxtCat
        '
        Me.TxtCat.Location = New System.Drawing.Point(133, 44)
        Me.TxtCat.Name = "TxtCat"
        Me.TxtCat.Size = New System.Drawing.Size(231, 20)
        Me.TxtCat.TabIndex = 3
        '
        'TxtCatEn
        '
        Me.TxtCatEn.Location = New System.Drawing.Point(133, 168)
        Me.TxtCatEn.Name = "TxtCatEn"
        Me.TxtCatEn.Size = New System.Drawing.Size(231, 20)
        Me.TxtCatEn.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 171)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Category (english)"
        '
        'BTnOK
        '
        Me.BTnOK.Image = CType(resources.GetObject("BTnOK.Image"), System.Drawing.Image)
        Me.BTnOK.Location = New System.Drawing.Point(289, 77)
        Me.BTnOK.Name = "BTnOK"
        Me.BTnOK.Size = New System.Drawing.Size(75, 36)
        Me.BTnOK.TabIndex = 6
        Me.BTnOK.Text = "OK"
        '
        'BtnCancel
        '
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(195, 77)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(88, 36)
        Me.BtnCancel.TabIndex = 7
        Me.BtnCancel.Text = "Cancel"
        '
        'FormItemCatProposeAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(383, 136)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BTnOK)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtCatEn)
        Me.Controls.Add(Me.TxtCat)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LookUpEdit1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormItemCatProposeAdd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add"
        CType(Me.LookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCatEn.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents LookUpEdit1 As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtCat As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtCatEn As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents BTnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
End Class
