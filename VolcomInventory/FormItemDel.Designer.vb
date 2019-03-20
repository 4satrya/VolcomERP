<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormItemDel
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
        Me.components = New System.ComponentModel.Container()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.XTCDel = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPRequest = New DevExpress.XtraTab.XtraTabPage()
        Me.GCRequest = New DevExpress.XtraGrid.GridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewDetailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVRequest = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdReq = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRecNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDeptReq = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreateddateReq = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedByReq = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SLEPackingStatus = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdPrepareStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPrepareStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPDel = New DevExpress.XtraTab.XtraTabPage()
        Me.GCDelivery = New DevExpress.XtraGrid.GridControl()
        Me.GVDelivery = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDept = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedByName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ToolTipController1 = New DevExpress.Utils.ToolTipController(Me.components)
        Me.GridColumnAction = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BtnDetail = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        CType(Me.XTCDel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCDel.SuspendLayout()
        Me.XTPRequest.SuspendLayout()
        CType(Me.GCRequest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GVRequest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLEPackingStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPDel.SuspendLayout()
        CType(Me.GCDelivery, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDelivery, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCDel
        '
        Me.XTCDel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCDel.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCDel.Location = New System.Drawing.Point(0, 0)
        Me.XTCDel.Name = "XTCDel"
        Me.XTCDel.SelectedTabPage = Me.XTPRequest
        Me.XTCDel.Size = New System.Drawing.Size(711, 438)
        Me.XTCDel.TabIndex = 0
        Me.XTCDel.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPRequest, Me.XTPDel})
        '
        'XTPRequest
        '
        Me.XTPRequest.Controls.Add(Me.GCRequest)
        Me.XTPRequest.Controls.Add(Me.PanelControl1)
        Me.XTPRequest.Name = "XTPRequest"
        Me.XTPRequest.Size = New System.Drawing.Size(705, 410)
        Me.XTPRequest.Text = "Request"
        '
        'GCRequest
        '
        Me.GCRequest.ContextMenuStrip = Me.ContextMenuStrip1
        Me.GCRequest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRequest.Location = New System.Drawing.Point(0, 46)
        Me.GCRequest.MainView = Me.GVRequest
        Me.GCRequest.Name = "GCRequest"
        Me.GCRequest.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.BtnDetail})
        Me.GCRequest.Size = New System.Drawing.Size(705, 364)
        Me.GCRequest.TabIndex = 0
        Me.GCRequest.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRequest})
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewDetailToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(131, 26)
        '
        'ViewDetailToolStripMenuItem
        '
        Me.ViewDetailToolStripMenuItem.Name = "ViewDetailToolStripMenuItem"
        Me.ViewDetailToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.ViewDetailToolStripMenuItem.Text = "view detail"
        Me.ViewDetailToolStripMenuItem.Visible = False
        '
        'GVRequest
        '
        Me.GVRequest.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdReq, Me.GridColumnRecNumber, Me.GridColumnDeptReq, Me.GridColumnCreateddateReq, Me.GridColumnCreatedByReq, Me.GridColumnAction})
        Me.GVRequest.GridControl = Me.GCRequest
        Me.GVRequest.Name = "GVRequest"
        Me.GVRequest.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVRequest.OptionsCustomization.AllowSort = False
        Me.GVRequest.OptionsFind.AlwaysVisible = True
        Me.GVRequest.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdReq
        '
        Me.GridColumnIdReq.Caption = "Id"
        Me.GridColumnIdReq.FieldName = "id_item_req"
        Me.GridColumnIdReq.Name = "GridColumnIdReq"
        Me.GridColumnIdReq.OptionsColumn.AllowEdit = False
        '
        'GridColumnRecNumber
        '
        Me.GridColumnRecNumber.Caption = "Number"
        Me.GridColumnRecNumber.FieldName = "number"
        Me.GridColumnRecNumber.Name = "GridColumnRecNumber"
        Me.GridColumnRecNumber.OptionsColumn.AllowEdit = False
        Me.GridColumnRecNumber.Visible = True
        Me.GridColumnRecNumber.VisibleIndex = 0
        '
        'GridColumnDeptReq
        '
        Me.GridColumnDeptReq.Caption = "Department"
        Me.GridColumnDeptReq.FieldName = "departement"
        Me.GridColumnDeptReq.Name = "GridColumnDeptReq"
        Me.GridColumnDeptReq.OptionsColumn.AllowEdit = False
        Me.GridColumnDeptReq.Visible = True
        Me.GridColumnDeptReq.VisibleIndex = 2
        '
        'GridColumnCreateddateReq
        '
        Me.GridColumnCreateddateReq.Caption = "Created Date"
        Me.GridColumnCreateddateReq.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm"
        Me.GridColumnCreateddateReq.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnCreateddateReq.FieldName = "created_date"
        Me.GridColumnCreateddateReq.Name = "GridColumnCreateddateReq"
        Me.GridColumnCreateddateReq.OptionsColumn.AllowEdit = False
        Me.GridColumnCreateddateReq.Visible = True
        Me.GridColumnCreateddateReq.VisibleIndex = 1
        '
        'GridColumnCreatedByReq
        '
        Me.GridColumnCreatedByReq.Caption = "Request by"
        Me.GridColumnCreatedByReq.FieldName = "created_by_name"
        Me.GridColumnCreatedByReq.Name = "GridColumnCreatedByReq"
        Me.GridColumnCreatedByReq.OptionsColumn.AllowEdit = False
        Me.GridColumnCreatedByReq.Visible = True
        Me.GridColumnCreatedByReq.VisibleIndex = 3
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SLEPackingStatus)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(705, 46)
        Me.PanelControl1.TabIndex = 1
        '
        'SLEPackingStatus
        '
        Me.SLEPackingStatus.Location = New System.Drawing.Point(96, 14)
        Me.SLEPackingStatus.Name = "SLEPackingStatus"
        Me.SLEPackingStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEPackingStatus.Properties.ShowClearButton = False
        Me.SLEPackingStatus.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEPackingStatus.Size = New System.Drawing.Size(156, 20)
        Me.SLEPackingStatus.TabIndex = 8898
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdPrepareStatus, Me.GridColumnPrepareStatus})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdPrepareStatus
        '
        Me.GridColumnIdPrepareStatus.Caption = "Id Prepare Status"
        Me.GridColumnIdPrepareStatus.FieldName = "id_prepare_status"
        Me.GridColumnIdPrepareStatus.Name = "GridColumnIdPrepareStatus"
        Me.GridColumnIdPrepareStatus.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnPrepareStatus
        '
        Me.GridColumnPrepareStatus.Caption = "Status"
        Me.GridColumnPrepareStatus.FieldName = "prepare_status"
        Me.GridColumnPrepareStatus.Name = "GridColumnPrepareStatus"
        Me.GridColumnPrepareStatus.Visible = True
        Me.GridColumnPrepareStatus.VisibleIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(14, 17)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(74, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Request Status"
        '
        'XTPDel
        '
        Me.XTPDel.Controls.Add(Me.GCDelivery)
        Me.XTPDel.Name = "XTPDel"
        Me.XTPDel.Size = New System.Drawing.Size(705, 410)
        Me.XTPDel.Text = "Delivery List"
        '
        'GCDelivery
        '
        Me.GCDelivery.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDelivery.Location = New System.Drawing.Point(0, 0)
        Me.GCDelivery.MainView = Me.GVDelivery
        Me.GCDelivery.Name = "GCDelivery"
        Me.GCDelivery.Size = New System.Drawing.Size(705, 410)
        Me.GCDelivery.TabIndex = 1
        Me.GCDelivery.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDelivery})
        '
        'GVDelivery
        '
        Me.GVDelivery.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNumber, Me.GridColumnDept, Me.GridColumnCreatedDate, Me.GridColumnCreatedByName, Me.GridColumnStt})
        Me.GVDelivery.GridControl = Me.GCDelivery
        Me.GVDelivery.Name = "GVDelivery"
        Me.GVDelivery.OptionsBehavior.Editable = False
        Me.GVDelivery.OptionsFind.AlwaysVisible = True
        Me.GVDelivery.OptionsView.ShowGroupPanel = False
        '
        'GridColumnNumber
        '
        Me.GridColumnNumber.Caption = "Number"
        Me.GridColumnNumber.FieldName = "number"
        Me.GridColumnNumber.Name = "GridColumnNumber"
        Me.GridColumnNumber.Visible = True
        Me.GridColumnNumber.VisibleIndex = 0
        '
        'GridColumnDept
        '
        Me.GridColumnDept.Caption = "Department"
        Me.GridColumnDept.FieldName = "departement"
        Me.GridColumnDept.Name = "GridColumnDept"
        Me.GridColumnDept.Visible = True
        Me.GridColumnDept.VisibleIndex = 1
        '
        'GridColumnCreatedDate
        '
        Me.GridColumnCreatedDate.Caption = "Created Date"
        Me.GridColumnCreatedDate.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm"
        Me.GridColumnCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnCreatedDate.FieldName = "created_date"
        Me.GridColumnCreatedDate.Name = "GridColumnCreatedDate"
        Me.GridColumnCreatedDate.Visible = True
        Me.GridColumnCreatedDate.VisibleIndex = 2
        '
        'GridColumnCreatedByName
        '
        Me.GridColumnCreatedByName.Caption = "Created By"
        Me.GridColumnCreatedByName.FieldName = "created_by_name"
        Me.GridColumnCreatedByName.Name = "GridColumnCreatedByName"
        Me.GridColumnCreatedByName.Visible = True
        Me.GridColumnCreatedByName.VisibleIndex = 3
        '
        'GridColumnStt
        '
        Me.GridColumnStt.Caption = "Status"
        Me.GridColumnStt.FieldName = "report_status"
        Me.GridColumnStt.Name = "GridColumnStt"
        Me.GridColumnStt.Visible = True
        Me.GridColumnStt.VisibleIndex = 4
        '
        'GridColumnAction
        '
        Me.GridColumnAction.Caption = "  "
        Me.GridColumnAction.ColumnEdit = Me.BtnDetail
        Me.GridColumnAction.FieldName = "btn_detail"
        Me.GridColumnAction.Name = "GridColumnAction"
        Me.GridColumnAction.Visible = True
        Me.GridColumnAction.VisibleIndex = 4
        '
        'BtnDetail
        '
        Me.BtnDetail.AutoHeight = False
        SerializableAppearanceObject1.BackColor = System.Drawing.SystemColors.Highlight
        SerializableAppearanceObject1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SerializableAppearanceObject1.ForeColor = System.Drawing.Color.White
        SerializableAppearanceObject1.Options.UseBackColor = True
        SerializableAppearanceObject1.Options.UseFont = True
        SerializableAppearanceObject1.Options.UseForeColor = True
        Me.BtnDetail.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Detail", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.BtnDetail.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.BtnDetail.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnDetail.Name = "BtnDetail"
        Me.BtnDetail.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'FormItemDel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(711, 438)
        Me.Controls.Add(Me.XTCDel)
        Me.MinimizeBox = False
        Me.Name = "FormItemDel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Delivery"
        CType(Me.XTCDel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCDel.ResumeLayout(False)
        Me.XTPRequest.ResumeLayout(False)
        CType(Me.GCRequest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GVRequest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLEPackingStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPDel.ResumeLayout(False)
        CType(Me.GCDelivery, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDelivery, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCDel As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPRequest As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPDel As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCRequest As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRequest As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCDelivery As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDelivery As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ViewDetailToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GridColumnIdReq As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRecNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDeptReq As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreateddateReq As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedByReq As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolTipController1 As DevExpress.Utils.ToolTipController
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEPackingStatus As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdPrepareStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrepareStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDept As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedByName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAction As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnDetail As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
End Class
