<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesReturnDetProblem
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSalesReturnDetProblem))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtCode = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtDesign = New DevExpress.XtraEditors.TextEdit()
        Me.TxtSize = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtBarcode = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtRemark = New DevExpress.XtraEditors.TextEdit()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelSearch = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtSearch = New DevExpress.XtraEditors.TextEdit()
        Me.BtnFind = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.TxtCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDesign.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSize.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtBarcode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtRemark.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelSearch.SuspendLayout()
        CType(Me.TxtSearch.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 46)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(25, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Code"
        '
        'TxtCode
        '
        Me.TxtCode.Enabled = False
        Me.TxtCode.Location = New System.Drawing.Point(12, 65)
        Me.TxtCode.Name = "TxtCode"
        Me.TxtCode.Size = New System.Drawing.Size(119, 20)
        Me.TxtCode.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 91)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Description"
        '
        'TxtDesign
        '
        Me.TxtDesign.EditValue = ""
        Me.TxtDesign.Enabled = False
        Me.TxtDesign.Location = New System.Drawing.Point(12, 110)
        Me.TxtDesign.Name = "TxtDesign"
        Me.TxtDesign.Size = New System.Drawing.Size(330, 20)
        Me.TxtDesign.TabIndex = 3
        '
        'TxtSize
        '
        Me.TxtSize.Enabled = False
        Me.TxtSize.Location = New System.Drawing.Point(134, 65)
        Me.TxtSize.Name = "TxtSize"
        Me.TxtSize.Size = New System.Drawing.Size(44, 20)
        Me.TxtSize.TabIndex = 4
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(134, 46)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(19, 13)
        Me.LabelControl3.TabIndex = 5
        Me.LabelControl3.Text = "Size"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(180, 46)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl4.TabIndex = 6
        Me.LabelControl4.Text = "Barcode"
        '
        'TxtBarcode
        '
        Me.TxtBarcode.EditValue = ""
        Me.TxtBarcode.Enabled = False
        Me.TxtBarcode.Location = New System.Drawing.Point(180, 65)
        Me.TxtBarcode.Name = "TxtBarcode"
        Me.TxtBarcode.Size = New System.Drawing.Size(162, 20)
        Me.TxtBarcode.TabIndex = 7
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(12, 136)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl5.TabIndex = 8
        Me.LabelControl5.Text = "Remark"
        '
        'TxtRemark
        '
        Me.TxtRemark.EditValue = ""
        Me.TxtRemark.Location = New System.Drawing.Point(12, 155)
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(330, 20)
        Me.TxtRemark.TabIndex = 9
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SimpleButton1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 193)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(360, 37)
        Me.PanelControl1.TabIndex = 10
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButton1.Image = CType(resources.GetObject("SimpleButton1.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(283, 2)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(75, 33)
        Me.SimpleButton1.TabIndex = 0
        Me.SimpleButton1.Text = "OK"
        '
        'PanelSearch
        '
        Me.PanelSearch.Controls.Add(Me.BtnFind)
        Me.PanelSearch.Controls.Add(Me.TxtSearch)
        Me.PanelSearch.Controls.Add(Me.LabelControl6)
        Me.PanelSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSearch.Location = New System.Drawing.Point(0, 0)
        Me.PanelSearch.Name = "PanelSearch"
        Me.PanelSearch.Size = New System.Drawing.Size(360, 34)
        Me.PanelSearch.TabIndex = 11
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(12, 10)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(33, 13)
        Me.LabelControl6.TabIndex = 12
        Me.LabelControl6.Text = "Search"
        '
        'TxtSearch
        '
        Me.TxtSearch.Location = New System.Drawing.Point(51, 7)
        Me.TxtSearch.Name = "TxtSearch"
        Me.TxtSearch.Size = New System.Drawing.Size(119, 20)
        Me.TxtSearch.TabIndex = 12
        '
        'BtnFind
        '
        Me.BtnFind.Location = New System.Drawing.Point(175, 7)
        Me.BtnFind.Name = "BtnFind"
        Me.BtnFind.Size = New System.Drawing.Size(75, 20)
        Me.BtnFind.TabIndex = 13
        Me.BtnFind.Text = "Find"
        '
        'FormSalesReturnDetProblem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(360, 230)
        Me.Controls.Add(Me.PanelSearch)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.TxtRemark)
        Me.Controls.Add(Me.TxtBarcode)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.TxtSize)
        Me.Controls.Add(Me.TxtDesign)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.TxtCode)
        Me.Controls.Add(Me.LabelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSalesReturnDetProblem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detail Non Stock"
        CType(Me.TxtCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDesign.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSize.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtBarcode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtRemark.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelSearch.ResumeLayout(False)
        Me.PanelSearch.PerformLayout()
        CType(Me.TxtSearch.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtDesign As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtSize As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtBarcode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtRemark As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelSearch As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnFind As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtSearch As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
End Class
