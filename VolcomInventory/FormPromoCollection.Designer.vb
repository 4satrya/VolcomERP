﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPromoCollection
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPromoCollection))
        Me.GCFilter = New DevExpress.XtraEditors.GroupControl()
        Me.BtnViewList = New DevExpress.XtraEditors.SimpleButton()
        Me.BHide = New DevExpress.XtraEditors.SimpleButton()
        Me.BExpand = New DevExpress.XtraEditors.SimpleButton()
        Me.DEUntilList = New DevExpress.XtraEditors.DateEdit()
        Me.DEFromList = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_ol_promo_collection = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_promo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnpromo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncreated_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncreated_by_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnstart_period = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnend_period = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_report_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnreport_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTCPromo = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPPromoProposed = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPDiscountCodes = New DevExpress.XtraTab.XtraTabPage()
        Me.GCDC = New DevExpress.XtraGrid.GridControl()
        Me.GVDC = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnSync = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GCFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GCFilter.SuspendLayout()
        CType(Me.DEUntilList.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntilList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromList.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCPromo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCPromo.SuspendLayout()
        Me.XTPPromoProposed.SuspendLayout()
        Me.XTPDiscountCodes.SuspendLayout()
        CType(Me.GCDC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GCFilter
        '
        Me.GCFilter.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GCFilter.Controls.Add(Me.BtnViewList)
        Me.GCFilter.Controls.Add(Me.BHide)
        Me.GCFilter.Controls.Add(Me.BExpand)
        Me.GCFilter.Controls.Add(Me.DEUntilList)
        Me.GCFilter.Controls.Add(Me.DEFromList)
        Me.GCFilter.Controls.Add(Me.LabelControl3)
        Me.GCFilter.Controls.Add(Me.LabelControl5)
        Me.GCFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.GCFilter.Location = New System.Drawing.Point(0, 0)
        Me.GCFilter.Name = "GCFilter"
        Me.GCFilter.Size = New System.Drawing.Size(799, 45)
        Me.GCFilter.TabIndex = 8
        '
        'BtnViewList
        '
        Me.BtnViewList.Image = CType(resources.GetObject("BtnViewList.Image"), System.Drawing.Image)
        Me.BtnViewList.Location = New System.Drawing.Point(317, 14)
        Me.BtnViewList.LookAndFeel.SkinName = "Blue"
        Me.BtnViewList.Name = "BtnViewList"
        Me.BtnViewList.Size = New System.Drawing.Size(75, 20)
        Me.BtnViewList.TabIndex = 8896
        Me.BtnViewList.Text = "View"
        '
        'BHide
        '
        Me.BHide.ImageIndex = 9
        Me.BHide.Location = New System.Drawing.Point(938, 14)
        Me.BHide.Name = "BHide"
        Me.BHide.Size = New System.Drawing.Size(104, 20)
        Me.BHide.TabIndex = 8898
        Me.BHide.Text = "Hide All Detail"
        Me.BHide.Visible = False
        '
        'BExpand
        '
        Me.BExpand.ImageIndex = 8
        Me.BExpand.Location = New System.Drawing.Point(835, 14)
        Me.BExpand.Name = "BExpand"
        Me.BExpand.Size = New System.Drawing.Size(99, 20)
        Me.BExpand.TabIndex = 8897
        Me.BExpand.Text = "Expand All Detail"
        Me.BExpand.Visible = False
        '
        'DEUntilList
        '
        Me.DEUntilList.EditValue = Nothing
        Me.DEUntilList.Location = New System.Drawing.Point(202, 14)
        Me.DEUntilList.Name = "DEUntilList"
        Me.DEUntilList.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEUntilList.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntilList.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntilList.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntilList.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntilList.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntilList.Size = New System.Drawing.Size(111, 20)
        Me.DEUntilList.TabIndex = 8895
        '
        'DEFromList
        '
        Me.DEFromList.EditValue = Nothing
        Me.DEFromList.Location = New System.Drawing.Point(58, 14)
        Me.DEFromList.Name = "DEFromList"
        Me.DEFromList.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEFromList.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFromList.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFromList.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFromList.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFromList.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFromList.Size = New System.Drawing.Size(111, 20)
        Me.DEFromList.TabIndex = 8894
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(175, 17)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl3.TabIndex = 8893
        Me.LabelControl3.Text = "Until"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(28, 17)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl5.TabIndex = 8892
        Me.LabelControl5.Text = "From"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 45)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(799, 405)
        Me.GCData.TabIndex = 9
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_ol_promo_collection, Me.GridColumnid_promo, Me.GridColumnpromo, Me.GridColumnnumber, Me.GridColumncreated_date, Me.GridColumncreated_by_name, Me.GridColumnstart_period, Me.GridColumnend_period, Me.GridColumnid_report_status, Me.GridColumnreport_status, Me.GridColumnnote})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.ReadOnly = True
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_ol_promo_collection
        '
        Me.GridColumnid_ol_promo_collection.Caption = "id_ol_promo_collection"
        Me.GridColumnid_ol_promo_collection.FieldName = "id_ol_promo_collection"
        Me.GridColumnid_ol_promo_collection.Name = "GridColumnid_ol_promo_collection"
        '
        'GridColumnid_promo
        '
        Me.GridColumnid_promo.Caption = "id_promo"
        Me.GridColumnid_promo.FieldName = "id_promo"
        Me.GridColumnid_promo.Name = "GridColumnid_promo"
        '
        'GridColumnpromo
        '
        Me.GridColumnpromo.Caption = "Promo Name"
        Me.GridColumnpromo.FieldName = "promo_name"
        Me.GridColumnpromo.Name = "GridColumnpromo"
        Me.GridColumnpromo.Visible = True
        Me.GridColumnpromo.VisibleIndex = 1
        '
        'GridColumnnumber
        '
        Me.GridColumnnumber.Caption = "Number"
        Me.GridColumnnumber.FieldName = "number"
        Me.GridColumnnumber.Name = "GridColumnnumber"
        Me.GridColumnnumber.Visible = True
        Me.GridColumnnumber.VisibleIndex = 0
        '
        'GridColumncreated_date
        '
        Me.GridColumncreated_date.Caption = "Created Date"
        Me.GridColumncreated_date.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumncreated_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumncreated_date.FieldName = "created_date"
        Me.GridColumncreated_date.Name = "GridColumncreated_date"
        Me.GridColumncreated_date.Visible = True
        Me.GridColumncreated_date.VisibleIndex = 2
        '
        'GridColumncreated_by_name
        '
        Me.GridColumncreated_by_name.Caption = "Created By"
        Me.GridColumncreated_by_name.FieldName = "created_by_name"
        Me.GridColumncreated_by_name.Name = "GridColumncreated_by_name"
        Me.GridColumncreated_by_name.Visible = True
        Me.GridColumncreated_by_name.VisibleIndex = 3
        '
        'GridColumnstart_period
        '
        Me.GridColumnstart_period.Caption = "Start Period"
        Me.GridColumnstart_period.DisplayFormat.FormatString = "dd MMM yyyy HH:mm"
        Me.GridColumnstart_period.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnstart_period.FieldName = "start_period"
        Me.GridColumnstart_period.Name = "GridColumnstart_period"
        Me.GridColumnstart_period.Visible = True
        Me.GridColumnstart_period.VisibleIndex = 4
        '
        'GridColumnend_period
        '
        Me.GridColumnend_period.Caption = "End Period"
        Me.GridColumnend_period.DisplayFormat.FormatString = "dd MMM yyyy HH:mm"
        Me.GridColumnend_period.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnend_period.FieldName = "end_period"
        Me.GridColumnend_period.Name = "GridColumnend_period"
        Me.GridColumnend_period.Visible = True
        Me.GridColumnend_period.VisibleIndex = 5
        '
        'GridColumnid_report_status
        '
        Me.GridColumnid_report_status.Caption = "id_report_status"
        Me.GridColumnid_report_status.FieldName = "id_report_status"
        Me.GridColumnid_report_status.Name = "GridColumnid_report_status"
        '
        'GridColumnreport_status
        '
        Me.GridColumnreport_status.Caption = "Status"
        Me.GridColumnreport_status.FieldName = "report_status"
        Me.GridColumnreport_status.Name = "GridColumnreport_status"
        Me.GridColumnreport_status.Visible = True
        Me.GridColumnreport_status.VisibleIndex = 6
        '
        'GridColumnnote
        '
        Me.GridColumnnote.Caption = "Note"
        Me.GridColumnnote.FieldName = "note"
        Me.GridColumnnote.Name = "GridColumnnote"
        '
        'XTCPromo
        '
        Me.XTCPromo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCPromo.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCPromo.Location = New System.Drawing.Point(0, 0)
        Me.XTCPromo.Name = "XTCPromo"
        Me.XTCPromo.SelectedTabPage = Me.XTPPromoProposed
        Me.XTCPromo.Size = New System.Drawing.Size(805, 478)
        Me.XTCPromo.TabIndex = 10
        Me.XTCPromo.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPPromoProposed, Me.XTPDiscountCodes})
        '
        'XTPPromoProposed
        '
        Me.XTPPromoProposed.Controls.Add(Me.GCData)
        Me.XTPPromoProposed.Controls.Add(Me.GCFilter)
        Me.XTPPromoProposed.Name = "XTPPromoProposed"
        Me.XTPPromoProposed.Size = New System.Drawing.Size(799, 450)
        Me.XTPPromoProposed.Text = "Proposed List"
        '
        'XTPDiscountCodes
        '
        Me.XTPDiscountCodes.Controls.Add(Me.GCDC)
        Me.XTPDiscountCodes.Controls.Add(Me.PanelControl1)
        Me.XTPDiscountCodes.Name = "XTPDiscountCodes"
        Me.XTPDiscountCodes.Size = New System.Drawing.Size(799, 450)
        Me.XTPDiscountCodes.Text = "Discount Codes"
        '
        'GCDC
        '
        Me.GCDC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDC.Location = New System.Drawing.Point(0, 46)
        Me.GCDC.MainView = Me.GVDC
        Me.GCDC.Name = "GCDC"
        Me.GCDC.Size = New System.Drawing.Size(799, 404)
        Me.GCDC.TabIndex = 1
        Me.GCDC.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDC})
        '
        'GVDC
        '
        Me.GVDC.GridControl = Me.GCDC
        Me.GVDC.Name = "GVDC"
        Me.GVDC.OptionsBehavior.ReadOnly = True
        Me.GVDC.OptionsFind.AlwaysVisible = True
        Me.GVDC.OptionsView.ShowGroupPanel = False
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnSync)
        Me.PanelControl1.Controls.Add(Me.BtnRefresh)
        Me.PanelControl1.Controls.Add(Me.BtnPrint)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(799, 46)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnSync
        '
        Me.BtnSync.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnSync.Image = CType(resources.GetObject("BtnSync.Image"), System.Drawing.Image)
        Me.BtnSync.Location = New System.Drawing.Point(2, 2)
        Me.BtnSync.Name = "BtnSync"
        Me.BtnSync.Size = New System.Drawing.Size(97, 42)
        Me.BtnSync.TabIndex = 1
        Me.BtnSync.Text = "Sync"
        '
        'BtnRefresh
        '
        Me.BtnRefresh.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnRefresh.Image = CType(resources.GetObject("BtnRefresh.Image"), System.Drawing.Image)
        Me.BtnRefresh.Location = New System.Drawing.Point(616, 2)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(90, 42)
        Me.BtnRefresh.TabIndex = 0
        Me.BtnRefresh.Text = "View"
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(706, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(91, 42)
        Me.BtnPrint.TabIndex = 2
        Me.BtnPrint.Text = "Print"
        '
        'FormPromoCollection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(805, 478)
        Me.Controls.Add(Me.XTCPromo)
        Me.Name = "FormPromoCollection"
        Me.Text = "Propose Promo Collection"
        CType(Me.GCFilter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GCFilter.ResumeLayout(False)
        Me.GCFilter.PerformLayout()
        CType(Me.DEUntilList.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntilList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromList.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCPromo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCPromo.ResumeLayout(False)
        Me.XTPPromoProposed.ResumeLayout(False)
        Me.XTPDiscountCodes.ResumeLayout(False)
        CType(Me.GCDC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCFilter As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BtnViewList As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BHide As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BExpand As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEUntilList As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFromList As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_ol_promo_collection As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_promo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnpromo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncreated_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncreated_by_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnstart_period As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnend_period As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_report_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnreport_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTCPromo As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPPromoProposed As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPDiscountCodes As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCDC As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDC As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnSync As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
End Class
