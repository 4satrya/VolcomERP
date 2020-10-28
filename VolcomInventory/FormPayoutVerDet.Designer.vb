<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPayoutVerDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPayoutVerDet))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAttachment = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnUpdate = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.TxtNumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtCreatedBy = New DevExpress.XtraEditors.TextEdit()
        Me.DECreated = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtCheckoutId = New DevExpress.XtraEditors.TextEdit()
        Me.TxtOrderNumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControlNav = New DevExpress.XtraEditors.PanelControl()
        Me.BtnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_list_payout_ver_det = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_list_payout_ver = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_acc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnacc_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnacc_description = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_dc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndc_code = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnvalue = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.TxtNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCreatedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DECreated.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DECreated.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCheckoutId.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtOrderNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlNav.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnClose)
        Me.PanelControl1.Controls.Add(Me.BtnAttachment)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 352)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(634, 45)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnClose
        '
        Me.BtnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(434, 2)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(88, 41)
        Me.BtnClose.TabIndex = 2
        Me.BtnClose.Text = "Close"
        '
        'BtnAttachment
        '
        Me.BtnAttachment.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAttachment.Image = CType(resources.GetObject("BtnAttachment.Image"), System.Drawing.Image)
        Me.BtnAttachment.Location = New System.Drawing.Point(522, 2)
        Me.BtnAttachment.Name = "BtnAttachment"
        Me.BtnAttachment.Size = New System.Drawing.Size(110, 41)
        Me.BtnAttachment.TabIndex = 1
        Me.BtnAttachment.Text = "Attachment"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BtnUpdate)
        Me.PanelControl2.Controls.Add(Me.PanelControl3)
        Me.PanelControl2.Controls.Add(Me.LabelControl2)
        Me.PanelControl2.Controls.Add(Me.TxtCheckoutId)
        Me.PanelControl2.Controls.Add(Me.TxtOrderNumber)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(634, 99)
        Me.PanelControl2.TabIndex = 1
        '
        'BtnUpdate
        '
        Me.BtnUpdate.Location = New System.Drawing.Point(226, 7)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(50, 23)
        Me.BtnUpdate.TabIndex = 3
        Me.BtnUpdate.Text = "update"
        '
        'PanelControl3
        '
        Me.PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl3.Controls.Add(Me.TxtNumber)
        Me.PanelControl3.Controls.Add(Me.LabelControl5)
        Me.PanelControl3.Controls.Add(Me.LabelControl4)
        Me.PanelControl3.Controls.Add(Me.TxtCreatedBy)
        Me.PanelControl3.Controls.Add(Me.DECreated)
        Me.PanelControl3.Controls.Add(Me.LabelControl3)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl3.Location = New System.Drawing.Point(335, 2)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(297, 95)
        Me.PanelControl3.TabIndex = 4
        '
        'TxtNumber
        '
        Me.TxtNumber.Location = New System.Drawing.Point(86, 7)
        Me.TxtNumber.Name = "TxtNumber"
        Me.TxtNumber.Properties.ReadOnly = True
        Me.TxtNumber.Size = New System.Drawing.Size(201, 20)
        Me.TxtNumber.TabIndex = 5
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(12, 10)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl5.TabIndex = 7
        Me.LabelControl5.Text = "Number"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(12, 62)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(54, 13)
        Me.LabelControl4.TabIndex = 6
        Me.LabelControl4.Text = "Created By"
        '
        'TxtCreatedBy
        '
        Me.TxtCreatedBy.Location = New System.Drawing.Point(86, 59)
        Me.TxtCreatedBy.Name = "TxtCreatedBy"
        Me.TxtCreatedBy.Properties.ReadOnly = True
        Me.TxtCreatedBy.Size = New System.Drawing.Size(201, 20)
        Me.TxtCreatedBy.TabIndex = 5
        '
        'DECreated
        '
        Me.DECreated.EditValue = Nothing
        Me.DECreated.Enabled = False
        Me.DECreated.Location = New System.Drawing.Point(86, 33)
        Me.DECreated.Name = "DECreated"
        Me.DECreated.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DECreated.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DECreated.Properties.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.DECreated.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DECreated.Size = New System.Drawing.Size(201, 20)
        Me.DECreated.TabIndex = 2
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(12, 36)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl3.TabIndex = 5
        Me.LabelControl3.Text = "Created Date"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 38)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(59, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Checkout ID"
        '
        'TxtCheckoutId
        '
        Me.TxtCheckoutId.Location = New System.Drawing.Point(101, 35)
        Me.TxtCheckoutId.Name = "TxtCheckoutId"
        Me.TxtCheckoutId.Properties.ReadOnly = True
        Me.TxtCheckoutId.Size = New System.Drawing.Size(175, 20)
        Me.TxtCheckoutId.TabIndex = 2
        '
        'TxtOrderNumber
        '
        Me.TxtOrderNumber.Location = New System.Drawing.Point(101, 9)
        Me.TxtOrderNumber.Name = "TxtOrderNumber"
        Me.TxtOrderNumber.Size = New System.Drawing.Size(123, 20)
        Me.TxtOrderNumber.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(68, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Order Number"
        '
        'PanelControlNav
        '
        Me.PanelControlNav.Controls.Add(Me.BtnDelete)
        Me.PanelControlNav.Controls.Add(Me.BtnAdd)
        Me.PanelControlNav.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlNav.Location = New System.Drawing.Point(0, 99)
        Me.PanelControlNav.Name = "PanelControlNav"
        Me.PanelControlNav.Size = New System.Drawing.Size(634, 35)
        Me.PanelControlNav.TabIndex = 2
        '
        'BtnDelete
        '
        Me.BtnDelete.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDelete.Image = CType(resources.GetObject("BtnDelete.Image"), System.Drawing.Image)
        Me.BtnDelete.Location = New System.Drawing.Point(482, 2)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(75, 31)
        Me.BtnDelete.TabIndex = 1
        Me.BtnDelete.Text = "Delete"
        '
        'BtnAdd
        '
        Me.BtnAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAdd.Image = CType(resources.GetObject("BtnAdd.Image"), System.Drawing.Image)
        Me.BtnAdd.Location = New System.Drawing.Point(557, 2)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(75, 31)
        Me.BtnAdd.TabIndex = 0
        Me.BtnAdd.Text = "Add"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 134)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(634, 218)
        Me.GCData.TabIndex = 3
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_list_payout_ver_det, Me.GridColumnid_list_payout_ver, Me.GridColumnid_acc, Me.GridColumnacc_name, Me.GridColumnacc_description, Me.GridColumnid_dc, Me.GridColumndc_code, Me.GridColumnvalue})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.ReadOnly = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_list_payout_ver_det
        '
        Me.GridColumnid_list_payout_ver_det.Caption = "id_list_payout_ver_det"
        Me.GridColumnid_list_payout_ver_det.FieldName = "id_list_payout_ver_det"
        Me.GridColumnid_list_payout_ver_det.Name = "GridColumnid_list_payout_ver_det"
        '
        'GridColumnid_list_payout_ver
        '
        Me.GridColumnid_list_payout_ver.Caption = "id_list_payout_ver"
        Me.GridColumnid_list_payout_ver.FieldName = "id_list_payout_ver"
        Me.GridColumnid_list_payout_ver.Name = "GridColumnid_list_payout_ver"
        '
        'GridColumnid_acc
        '
        Me.GridColumnid_acc.Caption = "id_acc"
        Me.GridColumnid_acc.FieldName = "id_acc"
        Me.GridColumnid_acc.Name = "GridColumnid_acc"
        '
        'GridColumnacc_name
        '
        Me.GridColumnacc_name.Caption = "COA"
        Me.GridColumnacc_name.FieldName = "acc_name"
        Me.GridColumnacc_name.Name = "GridColumnacc_name"
        Me.GridColumnacc_name.Visible = True
        Me.GridColumnacc_name.VisibleIndex = 0
        '
        'GridColumnacc_description
        '
        Me.GridColumnacc_description.Caption = "COA Description"
        Me.GridColumnacc_description.FieldName = "acc_description"
        Me.GridColumnacc_description.Name = "GridColumnacc_description"
        Me.GridColumnacc_description.Visible = True
        Me.GridColumnacc_description.VisibleIndex = 1
        '
        'GridColumnid_dc
        '
        Me.GridColumnid_dc.Caption = "id_dc"
        Me.GridColumnid_dc.FieldName = "id_dc"
        Me.GridColumnid_dc.Name = "GridColumnid_dc"
        '
        'GridColumndc_code
        '
        Me.GridColumndc_code.Caption = "D/K"
        Me.GridColumndc_code.FieldName = "dc_code"
        Me.GridColumndc_code.Name = "GridColumndc_code"
        Me.GridColumndc_code.Visible = True
        Me.GridColumndc_code.VisibleIndex = 2
        '
        'GridColumnvalue
        '
        Me.GridColumnvalue.Caption = "Value"
        Me.GridColumnvalue.DisplayFormat.FormatString = "N2"
        Me.GridColumnvalue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnvalue.FieldName = "value"
        Me.GridColumnvalue.Name = "GridColumnvalue"
        Me.GridColumnvalue.Visible = True
        Me.GridColumnvalue.VisibleIndex = 3
        '
        'FormPayoutVerDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 397)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControlNav)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormPayoutVerDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Payout Reconcile"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.TxtNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCreatedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DECreated.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DECreated.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCheckoutId.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtOrderNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlNav.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnAttachment As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtCheckoutId As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtOrderNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtCreatedBy As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DECreated As DevExpress.XtraEditors.DateEdit
    Friend WithEvents PanelControlNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumnid_list_payout_ver_det As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_list_payout_ver As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_acc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnacc_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnacc_description As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_dc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndc_code As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnvalue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnUpdate As DevExpress.XtraEditors.SimpleButton
End Class
