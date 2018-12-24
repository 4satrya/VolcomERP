<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormTestBarcodeScan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormTestBarcodeScan))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TEDONumber = New DevExpress.XtraEditors.TextEdit()
        Me.TENumber = New DevExpress.XtraEditors.TextEdit()
        Me.TECreatedDate = New DevExpress.XtraEditors.TextEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TECodeInput = New DevExpress.XtraEditors.TextEdit()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.GCList = New DevExpress.XtraGrid.GridControl()
        Me.GVList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCIdProduct = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCProductName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCProductFullCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCCodeDetailName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCQuantity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.SBAttachment = New DevExpress.XtraEditors.SimpleButton()
        Me.SBMark = New DevExpress.XtraEditors.SimpleButton()
        Me.SBPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.SBCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.SBSave = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEDONumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECreatedDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECodeInput.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.MENote)
        Me.PanelControl1.Controls.Add(Me.Label5)
        Me.PanelControl1.Controls.Add(Me.Label4)
        Me.PanelControl1.Controls.Add(Me.TEDONumber)
        Me.PanelControl1.Controls.Add(Me.TENumber)
        Me.PanelControl1.Controls.Add(Me.TECreatedDate)
        Me.PanelControl1.Controls.Add(Me.Label3)
        Me.PanelControl1.Controls.Add(Me.Label2)
        Me.PanelControl1.Controls.Add(Me.Label1)
        Me.PanelControl1.Controls.Add(Me.TECodeInput)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(970, 97)
        Me.PanelControl1.TabIndex = 0
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(634, 46)
        Me.MENote.Name = "MENote"
        Me.MENote.Size = New System.Drawing.Size(241, 43)
        Me.MENote.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(569, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Note"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(566, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "DO Number"
        '
        'TEDONumber
        '
        Me.TEDONumber.EditValue = ""
        Me.TEDONumber.Location = New System.Drawing.Point(634, 12)
        Me.TEDONumber.Name = "TEDONumber"
        Me.TEDONumber.Size = New System.Drawing.Size(241, 20)
        Me.TEDONumber.TabIndex = 6
        '
        'TENumber
        '
        Me.TENumber.EditValue = ""
        Me.TENumber.Location = New System.Drawing.Point(385, 12)
        Me.TENumber.Name = "TENumber"
        Me.TENumber.Size = New System.Drawing.Size(174, 20)
        Me.TENumber.TabIndex = 5
        '
        'TECreatedDate
        '
        Me.TECreatedDate.EditValue = ""
        Me.TECreatedDate.Enabled = False
        Me.TECreatedDate.Location = New System.Drawing.Point(385, 46)
        Me.TECreatedDate.Name = "TECreatedDate"
        Me.TECreatedDate.Size = New System.Drawing.Size(174, 20)
        Me.TECreatedDate.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(307, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Created Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(307, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Number"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Product Code"
        '
        'TECodeInput
        '
        Me.TECodeInput.EditValue = ""
        Me.TECodeInput.Location = New System.Drawing.Point(90, 12)
        Me.TECodeInput.Name = "TECodeInput"
        Me.TECodeInput.Size = New System.Drawing.Size(173, 20)
        Me.TECodeInput.TabIndex = 0
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.GCList)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl2.Location = New System.Drawing.Point(0, 97)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(970, 306)
        Me.PanelControl2.TabIndex = 1
        '
        'GCList
        '
        Me.GCList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCList.Location = New System.Drawing.Point(2, 2)
        Me.GCList.MainView = Me.GVList
        Me.GCList.Name = "GCList"
        Me.GCList.Size = New System.Drawing.Size(966, 302)
        Me.GCList.TabIndex = 0
        Me.GCList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVList})
        '
        'GVList
        '
        Me.GVList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCIdProduct, Me.GCProductName, Me.GCProductFullCode, Me.GCCodeDetailName, Me.GCQuantity})
        Me.GVList.GridControl = Me.GCList
        Me.GVList.Name = "GVList"
        Me.GVList.OptionsBehavior.Editable = False
        Me.GVList.OptionsView.ShowFooter = True
        '
        'GCIdProduct
        '
        Me.GCIdProduct.Caption = "Id"
        Me.GCIdProduct.FieldName = "id_product"
        Me.GCIdProduct.Name = "GCIdProduct"
        Me.GCIdProduct.Visible = True
        Me.GCIdProduct.VisibleIndex = 0
        '
        'GCProductName
        '
        Me.GCProductName.Caption = "Name"
        Me.GCProductName.FieldName = "product_name"
        Me.GCProductName.Name = "GCProductName"
        Me.GCProductName.Visible = True
        Me.GCProductName.VisibleIndex = 1
        '
        'GCProductFullCode
        '
        Me.GCProductFullCode.Caption = "Code"
        Me.GCProductFullCode.FieldName = "product_full_code"
        Me.GCProductFullCode.Name = "GCProductFullCode"
        Me.GCProductFullCode.Visible = True
        Me.GCProductFullCode.VisibleIndex = 2
        '
        'GCCodeDetailName
        '
        Me.GCCodeDetailName.Caption = "Size"
        Me.GCCodeDetailName.FieldName = "code_detail_name"
        Me.GCCodeDetailName.Name = "GCCodeDetailName"
        Me.GCCodeDetailName.Visible = True
        Me.GCCodeDetailName.VisibleIndex = 3
        '
        'GCQuantity
        '
        Me.GCQuantity.Caption = "Quantity"
        Me.GCQuantity.DisplayFormat.FormatString = "N0"
        Me.GCQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCQuantity.FieldName = "quantity"
        Me.GCQuantity.Name = "GCQuantity"
        Me.GCQuantity.Visible = True
        Me.GCQuantity.VisibleIndex = 4
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.GroupControl1)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 353)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(970, 50)
        Me.PanelControl3.TabIndex = 2
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.SBAttachment)
        Me.GroupControl1.Controls.Add(Me.SBMark)
        Me.GroupControl1.Controls.Add(Me.SBPrint)
        Me.GroupControl1.Controls.Add(Me.SBCancel)
        Me.GroupControl1.Controls.Add(Me.SBSave)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(2, 2)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(966, 46)
        Me.GroupControl1.TabIndex = 37
        '
        'SBAttachment
        '
        Me.SBAttachment.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBAttachment.Enabled = False
        Me.SBAttachment.Image = CType(resources.GetObject("SBAttachment.Image"), System.Drawing.Image)
        Me.SBAttachment.Location = New System.Drawing.Point(592, 2)
        Me.SBAttachment.Name = "SBAttachment"
        Me.SBAttachment.Size = New System.Drawing.Size(101, 42)
        Me.SBAttachment.TabIndex = 5
        Me.SBAttachment.Text = "Attachment"
        '
        'SBMark
        '
        Me.SBMark.Dock = System.Windows.Forms.DockStyle.Left
        Me.SBMark.Enabled = False
        Me.SBMark.Image = CType(resources.GetObject("SBMark.Image"), System.Drawing.Image)
        Me.SBMark.Location = New System.Drawing.Point(20, 2)
        Me.SBMark.Name = "SBMark"
        Me.SBMark.Size = New System.Drawing.Size(81, 42)
        Me.SBMark.TabIndex = 4
        Me.SBMark.Text = "Mark"
        '
        'SBPrint
        '
        Me.SBPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBPrint.Image = CType(resources.GetObject("SBPrint.Image"), System.Drawing.Image)
        Me.SBPrint.Location = New System.Drawing.Point(693, 2)
        Me.SBPrint.Name = "SBPrint"
        Me.SBPrint.Size = New System.Drawing.Size(90, 42)
        Me.SBPrint.TabIndex = 3
        Me.SBPrint.Text = "Print"
        '
        'SBCancel
        '
        Me.SBCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBCancel.Image = CType(resources.GetObject("SBCancel.Image"), System.Drawing.Image)
        Me.SBCancel.Location = New System.Drawing.Point(783, 2)
        Me.SBCancel.Name = "SBCancel"
        Me.SBCancel.Size = New System.Drawing.Size(90, 42)
        Me.SBCancel.TabIndex = 2
        Me.SBCancel.Text = "Cancel"
        '
        'SBSave
        '
        Me.SBSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBSave.Enabled = False
        Me.SBSave.Image = CType(resources.GetObject("SBSave.Image"), System.Drawing.Image)
        Me.SBSave.Location = New System.Drawing.Point(873, 2)
        Me.SBSave.Name = "SBSave"
        Me.SBSave.Size = New System.Drawing.Size(91, 42)
        Me.SBSave.TabIndex = 1
        Me.SBSave.Text = "Save"
        '
        'FormTestBarcodeScan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(970, 403)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormTestBarcodeScan"
        Me.Text = "Test Barcode Scan"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEDONumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECreatedDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECodeInput.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TECodeInput As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCIdProduct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCProductName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCProductFullCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCCodeDetailName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCQuantity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SBAttachment As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TEDONumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TENumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TECreatedDate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
End Class
