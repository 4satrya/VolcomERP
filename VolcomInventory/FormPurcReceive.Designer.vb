<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormPurcReceive
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
        Me.XTCRec = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPOrder = New DevExpress.XtraTab.XtraTabPage()
        Me.GCPO = New DevExpress.XtraGrid.GridControl()
        Me.GVPO = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn35 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn37 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn36 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdComp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BView = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEVendor = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCompNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncompName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPReceived = New DevExpress.XtraTab.XtraTabPage()
        Me.GCReceive = New DevExpress.XtraGrid.GridControl()
        Me.GVReceive = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdRec = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRecNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOrderNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnArrivalDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLastUpdate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnUpdatedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnVendor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDOVENDOR = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.XTCRec, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCRec.SuspendLayout()
        Me.XTPOrder.SuspendLayout()
        CType(Me.GCPO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLEVendor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPReceived.SuspendLayout()
        CType(Me.GCReceive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVReceive, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCRec
        '
        Me.XTCRec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCRec.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCRec.Location = New System.Drawing.Point(0, 0)
        Me.XTCRec.Name = "XTCRec"
        Me.XTCRec.SelectedTabPage = Me.XTPOrder
        Me.XTCRec.Size = New System.Drawing.Size(783, 548)
        Me.XTCRec.TabIndex = 0
        Me.XTCRec.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPOrder, Me.XTPReceived})
        '
        'XTPOrder
        '
        Me.XTPOrder.Controls.Add(Me.GCPO)
        Me.XTPOrder.Controls.Add(Me.PanelControl1)
        Me.XTPOrder.Name = "XTPOrder"
        Me.XTPOrder.Size = New System.Drawing.Size(777, 520)
        Me.XTPOrder.Text = "Purchase Order List"
        '
        'GCPO
        '
        Me.GCPO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPO.Location = New System.Drawing.Point(0, 42)
        Me.GCPO.MainView = Me.GVPO
        Me.GCPO.Name = "GCPO"
        Me.GCPO.Size = New System.Drawing.Size(777, 478)
        Me.GCPO.TabIndex = 3
        Me.GCPO.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPO})
        '
        'GVPO
        '
        Me.GVPO.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn7, Me.GridColumn1, Me.GridColumn2, Me.GridColumn35, Me.GridColumn3, Me.GridColumn37, Me.GridColumn36, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumnIdComp})
        Me.GVPO.GridControl = Me.GCPO
        Me.GVPO.Name = "GVPO"
        Me.GVPO.OptionsView.ShowGroupPanel = False
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "ID PO"
        Me.GridColumn7.FieldName = "id_purc_order"
        Me.GridColumn7.Name = "GridColumn7"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "PO Number"
        Me.GridColumn1.FieldName = "purc_order_number"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Created By"
        Me.GridColumn2.FieldName = "emp_created"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumn35
        '
        Me.GridColumn35.Caption = "Vendor Code"
        Me.GridColumn35.FieldName = "comp_number"
        Me.GridColumn35.Name = "GridColumn35"
        Me.GridColumn35.Visible = True
        Me.GridColumn35.VisibleIndex = 3
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Vendor"
        Me.GridColumn3.FieldName = "comp_name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        '
        'GridColumn37
        '
        Me.GridColumn37.Caption = "Contact Person"
        Me.GridColumn37.FieldName = "contact_person"
        Me.GridColumn37.Name = "GridColumn37"
        Me.GridColumn37.Visible = True
        Me.GridColumn37.VisibleIndex = 5
        '
        'GridColumn36
        '
        Me.GridColumn36.Caption = "Contact Number"
        Me.GridColumn36.FieldName = "contact_number"
        Me.GridColumn36.Name = "GridColumn36"
        Me.GridColumn36.Visible = True
        Me.GridColumn36.VisibleIndex = 7
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Created Date"
        Me.GridColumn4.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn4.FieldName = "date_created"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 4
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Last Update By"
        Me.GridColumn5.FieldName = "emp_updated"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 6
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Last Update"
        Me.GridColumn6.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn6.FieldName = "last_update"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 8
        '
        'GridColumnIdComp
        '
        Me.GridColumnIdComp.Caption = "ID Comp"
        Me.GridColumnIdComp.FieldName = "id_comp"
        Me.GridColumnIdComp.Name = "GridColumnIdComp"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BView)
        Me.PanelControl1.Controls.Add(Me.SLEVendor)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(777, 42)
        Me.PanelControl1.TabIndex = 2
        '
        'BView
        '
        Me.BView.Location = New System.Drawing.Point(234, 8)
        Me.BView.Name = "BView"
        Me.BView.Size = New System.Drawing.Size(60, 23)
        Me.BView.TabIndex = 8913
        Me.BView.Text = "view"
        '
        'SLEVendor
        '
        Me.SLEVendor.Location = New System.Drawing.Point(51, 10)
        Me.SLEVendor.Name = "SLEVendor"
        Me.SLEVendor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEVendor.Properties.View = Me.GridView2
        Me.SLEVendor.Size = New System.Drawing.Size(177, 20)
        Me.SLEVendor.TabIndex = 8912
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn13, Me.GridColumnCompNumber, Me.GridColumncompName})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "ID"
        Me.GridColumn13.FieldName = "id_comp"
        Me.GridColumn13.Name = "GridColumn13"
        '
        'GridColumnCompNumber
        '
        Me.GridColumnCompNumber.Caption = "Account"
        Me.GridColumnCompNumber.FieldName = "comp_number"
        Me.GridColumnCompNumber.Name = "GridColumnCompNumber"
        Me.GridColumnCompNumber.Visible = True
        Me.GridColumnCompNumber.VisibleIndex = 0
        '
        'GridColumncompName
        '
        Me.GridColumncompName.Caption = "Description"
        Me.GridColumncompName.FieldName = "comp_name"
        Me.GridColumncompName.Name = "GridColumncompName"
        Me.GridColumncompName.Visible = True
        Me.GridColumncompName.VisibleIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(11, 13)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl2.TabIndex = 8911
        Me.LabelControl2.Text = "Vendor"
        '
        'XTPReceived
        '
        Me.XTPReceived.Controls.Add(Me.GCReceive)
        Me.XTPReceived.Name = "XTPReceived"
        Me.XTPReceived.Size = New System.Drawing.Size(777, 520)
        Me.XTPReceived.Text = "Received List"
        '
        'GCReceive
        '
        Me.GCReceive.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCReceive.Location = New System.Drawing.Point(0, 0)
        Me.GCReceive.MainView = Me.GVReceive
        Me.GCReceive.Name = "GCReceive"
        Me.GCReceive.Size = New System.Drawing.Size(777, 520)
        Me.GCReceive.TabIndex = 0
        Me.GCReceive.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVReceive})
        '
        'GVReceive
        '
        Me.GVReceive.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdRec, Me.GridColumnRecNumber, Me.GridColumnOrderNumber, Me.GridColumnCreatedDate, Me.GridColumnArrivalDate, Me.GridColumnCreatedBy, Me.GridColumnLastUpdate, Me.GridColumnUpdatedBy, Me.GridColumnNote, Me.GridColumnStatus, Me.GridColumnVendor, Me.GridColumnDOVENDOR})
        Me.GVReceive.GridControl = Me.GCReceive
        Me.GVReceive.Name = "GVReceive"
        Me.GVReceive.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVReceive.OptionsBehavior.Editable = False
        Me.GVReceive.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdRec
        '
        Me.GridColumnIdRec.Caption = "ID"
        Me.GridColumnIdRec.FieldName = "id_purc_rec"
        Me.GridColumnIdRec.Name = "GridColumnIdRec"
        '
        'GridColumnRecNumber
        '
        Me.GridColumnRecNumber.Caption = "Number"
        Me.GridColumnRecNumber.FieldName = "purc_rec_number"
        Me.GridColumnRecNumber.Name = "GridColumnRecNumber"
        Me.GridColumnRecNumber.Visible = True
        Me.GridColumnRecNumber.VisibleIndex = 0
        '
        'GridColumnOrderNumber
        '
        Me.GridColumnOrderNumber.Caption = "Order Number"
        Me.GridColumnOrderNumber.FieldName = "purc_order_number"
        Me.GridColumnOrderNumber.Name = "GridColumnOrderNumber"
        Me.GridColumnOrderNumber.Visible = True
        Me.GridColumnOrderNumber.VisibleIndex = 2
        '
        'GridColumnCreatedDate
        '
        Me.GridColumnCreatedDate.Caption = "Created Date"
        Me.GridColumnCreatedDate.DisplayFormat.FormatString = "dd MMMM yyyy \/ HH:mm"
        Me.GridColumnCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnCreatedDate.FieldName = "date_created"
        Me.GridColumnCreatedDate.Name = "GridColumnCreatedDate"
        Me.GridColumnCreatedDate.Visible = True
        Me.GridColumnCreatedDate.VisibleIndex = 5
        '
        'GridColumnArrivalDate
        '
        Me.GridColumnArrivalDate.Caption = "Arrival Date"
        Me.GridColumnArrivalDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnArrivalDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnArrivalDate.FieldName = "date_arrived"
        Me.GridColumnArrivalDate.Name = "GridColumnArrivalDate"
        Me.GridColumnArrivalDate.Visible = True
        Me.GridColumnArrivalDate.VisibleIndex = 4
        '
        'GridColumnCreatedBy
        '
        Me.GridColumnCreatedBy.Caption = "Created By"
        Me.GridColumnCreatedBy.FieldName = "created_by_name"
        Me.GridColumnCreatedBy.Name = "GridColumnCreatedBy"
        Me.GridColumnCreatedBy.Visible = True
        Me.GridColumnCreatedBy.VisibleIndex = 6
        '
        'GridColumnLastUpdate
        '
        Me.GridColumnLastUpdate.Caption = "Last Updated"
        Me.GridColumnLastUpdate.DisplayFormat.FormatString = "dd MMMM yyyy \/ HH:mm"
        Me.GridColumnLastUpdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnLastUpdate.FieldName = "last_update"
        Me.GridColumnLastUpdate.Name = "GridColumnLastUpdate"
        '
        'GridColumnUpdatedBy
        '
        Me.GridColumnUpdatedBy.Caption = "Updated By"
        Me.GridColumnUpdatedBy.FieldName = "last_update_by_name"
        Me.GridColumnUpdatedBy.Name = "GridColumnUpdatedBy"
        '
        'GridColumnNote
        '
        Me.GridColumnNote.Caption = "Note"
        Me.GridColumnNote.FieldName = "note"
        Me.GridColumnNote.Name = "GridColumnNote"
        Me.GridColumnNote.Visible = True
        Me.GridColumnNote.VisibleIndex = 7
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Status"
        Me.GridColumnStatus.FieldName = "report_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.VisibleIndex = 8
        '
        'GridColumnVendor
        '
        Me.GridColumnVendor.Caption = "Vendor"
        Me.GridColumnVendor.FieldName = "vendor"
        Me.GridColumnVendor.Name = "GridColumnVendor"
        Me.GridColumnVendor.Visible = True
        Me.GridColumnVendor.VisibleIndex = 3
        '
        'GridColumnDOVENDOR
        '
        Me.GridColumnDOVENDOR.Caption = "DO Number"
        Me.GridColumnDOVENDOR.FieldName = "do_vendor_number"
        Me.GridColumnDOVENDOR.Name = "GridColumnDOVENDOR"
        Me.GridColumnDOVENDOR.Visible = True
        Me.GridColumnDOVENDOR.VisibleIndex = 1
        '
        'FormPurcReceive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(783, 548)
        Me.Controls.Add(Me.XTCRec)
        Me.Name = "FormPurcReceive"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase Receive"
        CType(Me.XTCRec, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCRec.ResumeLayout(False)
        Me.XTPOrder.ResumeLayout(False)
        CType(Me.GCPO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLEVendor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPReceived.ResumeLayout(False)
        CType(Me.GCReceive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVReceive, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCRec As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPOrder As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPReceived As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SLEVendor As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCPO As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPO As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn35 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn37 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn36 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCReceive As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVReceive As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdRec As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRecNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOrderNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLastUpdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUpdatedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncompName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnVendor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnArrivalDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDOVENDOR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdComp As DevExpress.XtraGrid.Columns.GridColumn
End Class
