﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormSalesReturnRecDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSalesReturnRecDet))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.TECreatedDate = New DevExpress.XtraEditors.TextEdit()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        Me.TEDONumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TENumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TEProductCode = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.GCList = New DevExpress.XtraGrid.GridControl()
        Me.GVList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCIdProduct = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCProductName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCProductFullCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCCodeDetailName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCQuantity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.SBMark = New DevExpress.XtraEditors.SimpleButton()
        Me.SBPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.SBCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.SBSave = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TECreatedDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEDONumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEProductCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.TECreatedDate)
        Me.PanelControl1.Controls.Add(Me.MENote)
        Me.PanelControl1.Controls.Add(Me.TEDONumber)
        Me.PanelControl1.Controls.Add(Me.LabelControl5)
        Me.PanelControl1.Controls.Add(Me.LabelControl4)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.TENumber)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.TEProductCode)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(868, 100)
        Me.PanelControl1.TabIndex = 0
        '
        'TECreatedDate
        '
        Me.TECreatedDate.Location = New System.Drawing.Point(379, 49)
        Me.TECreatedDate.Name = "TECreatedDate"
        Me.TECreatedDate.Properties.ReadOnly = True
        Me.TECreatedDate.Size = New System.Drawing.Size(180, 20)
        Me.TECreatedDate.TabIndex = 10
        '
        'MENote
        '
        Me.MENote.EditValue = ""
        Me.MENote.Location = New System.Drawing.Point(678, 50)
        Me.MENote.Name = "MENote"
        Me.MENote.Size = New System.Drawing.Size(180, 40)
        Me.MENote.TabIndex = 9
        '
        'TEDONumber
        '
        Me.TEDONumber.EditValue = ""
        Me.TEDONumber.Location = New System.Drawing.Point(678, 9)
        Me.TEDONumber.Name = "TEDONumber"
        Me.TEDONumber.Size = New System.Drawing.Size(180, 20)
        Me.TEDONumber.TabIndex = 8
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(617, 52)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl5.TabIndex = 6
        Me.LabelControl5.Text = "Note"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(617, 12)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(55, 13)
        Me.LabelControl4.TabIndex = 5
        Me.LabelControl4.Text = "DO Number"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(308, 52)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl3.TabIndex = 4
        Me.LabelControl3.Text = "Created Date"
        '
        'TENumber
        '
        Me.TENumber.Location = New System.Drawing.Point(379, 9)
        Me.TENumber.Name = "TENumber"
        Me.TENumber.Properties.ReadOnly = True
        Me.TENumber.Size = New System.Drawing.Size(180, 20)
        Me.TENumber.TabIndex = 3
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(308, 12)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Number"
        '
        'TEProductCode
        '
        Me.TEProductCode.Location = New System.Drawing.Point(83, 10)
        Me.TEProductCode.Name = "TEProductCode"
        Me.TEProductCode.Size = New System.Drawing.Size(180, 20)
        Me.TEProductCode.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Product Code"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.GCList)
        Me.PanelControl2.Controls.Add(Me.GroupControl1)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl2.Location = New System.Drawing.Point(0, 100)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(868, 408)
        Me.PanelControl2.TabIndex = 1
        '
        'GCList
        '
        Me.GCList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCList.Location = New System.Drawing.Point(2, 2)
        Me.GCList.MainView = Me.GVList
        Me.GCList.Name = "GCList"
        Me.GCList.Size = New System.Drawing.Size(864, 353)
        Me.GCList.TabIndex = 1
        Me.GCList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVList})
        '
        'GVList
        '
        Me.GVList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCIdProduct, Me.GCProductName, Me.GCProductFullCode, Me.GCCodeDetailName, Me.GCQuantity})
        Me.GVList.GridControl = Me.GCList
        Me.GVList.Name = "GVList"
        Me.GVList.OptionsBehavior.Editable = False
        Me.GVList.OptionsView.ShowGroupPanel = False
        '
        'GCIdProduct
        '
        Me.GCIdProduct.Caption = "Id"
        Me.GCIdProduct.FieldName = "id_product"
        Me.GCIdProduct.Name = "GCIdProduct"
        '
        'GCProductName
        '
        Me.GCProductName.Caption = "Name"
        Me.GCProductName.FieldName = "product_name"
        Me.GCProductName.Name = "GCProductName"
        Me.GCProductName.Visible = True
        Me.GCProductName.VisibleIndex = 0
        '
        'GCProductFullCode
        '
        Me.GCProductFullCode.Caption = "Code"
        Me.GCProductFullCode.FieldName = "product_full_code"
        Me.GCProductFullCode.Name = "GCProductFullCode"
        Me.GCProductFullCode.Visible = True
        Me.GCProductFullCode.VisibleIndex = 1
        '
        'GCCodeDetailName
        '
        Me.GCCodeDetailName.Caption = "Size"
        Me.GCCodeDetailName.FieldName = "code_detail_name"
        Me.GCCodeDetailName.Name = "GCCodeDetailName"
        Me.GCCodeDetailName.Visible = True
        Me.GCCodeDetailName.VisibleIndex = 2
        '
        'GCQuantity
        '
        Me.GCQuantity.Caption = "Quantity"
        Me.GCQuantity.DisplayFormat.FormatString = "N0"
        Me.GCQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCQuantity.FieldName = "quantity"
        Me.GCQuantity.Name = "GCQuantity"
        Me.GCQuantity.Visible = True
        Me.GCQuantity.VisibleIndex = 3
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.SBMark)
        Me.GroupControl1.Controls.Add(Me.SBPrint)
        Me.GroupControl1.Controls.Add(Me.SBCancel)
        Me.GroupControl1.Controls.Add(Me.SBSave)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupControl1.Location = New System.Drawing.Point(2, 355)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(864, 51)
        Me.GroupControl1.TabIndex = 38
        '
        'SBMark
        '
        Me.SBMark.Dock = System.Windows.Forms.DockStyle.Left
        Me.SBMark.Image = CType(resources.GetObject("SBMark.Image"), System.Drawing.Image)
        Me.SBMark.Location = New System.Drawing.Point(20, 2)
        Me.SBMark.Name = "SBMark"
        Me.SBMark.Size = New System.Drawing.Size(81, 47)
        Me.SBMark.TabIndex = 4
        Me.SBMark.Text = "Mark"
        '
        'SBPrint
        '
        Me.SBPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBPrint.Image = CType(resources.GetObject("SBPrint.Image"), System.Drawing.Image)
        Me.SBPrint.Location = New System.Drawing.Point(591, 2)
        Me.SBPrint.Name = "SBPrint"
        Me.SBPrint.Size = New System.Drawing.Size(90, 47)
        Me.SBPrint.TabIndex = 3
        Me.SBPrint.Text = "Print"
        '
        'SBCancel
        '
        Me.SBCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBCancel.Image = CType(resources.GetObject("SBCancel.Image"), System.Drawing.Image)
        Me.SBCancel.Location = New System.Drawing.Point(681, 2)
        Me.SBCancel.Name = "SBCancel"
        Me.SBCancel.Size = New System.Drawing.Size(90, 47)
        Me.SBCancel.TabIndex = 2
        Me.SBCancel.Text = "Cancel"
        '
        'SBSave
        '
        Me.SBSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBSave.Enabled = False
        Me.SBSave.Image = CType(resources.GetObject("SBSave.Image"), System.Drawing.Image)
        Me.SBSave.Location = New System.Drawing.Point(771, 2)
        Me.SBSave.Name = "SBSave"
        Me.SBSave.Size = New System.Drawing.Size(91, 47)
        Me.SBSave.TabIndex = 1
        Me.SBSave.Text = "Save"
        '
        'FormSalesReturnRecDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(868, 508)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormSalesReturnRecDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Receive Return Detail"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.TECreatedDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEDONumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEProductCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TEProductCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TENumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents TEDONumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCIdProduct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCProductName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCProductFullCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCCodeDetailName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCQuantity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SBMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TECreatedDate As DevExpress.XtraEditors.TextEdit
End Class
