﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesReportTracking
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSalesReportTracking))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.GCListDesign = New DevExpress.XtraGrid.GridControl()
        Me.GVListDesign = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDelQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRTSQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSalQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSOHQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnpercentSaas = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPercentSaasDel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCListDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVListDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BSearch)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1080, 42)
        Me.PanelControl1.TabIndex = 0
        '
        'BSearch
        '
        Me.BSearch.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSearch.ImageIndex = 15
        Me.BSearch.ImageList = Me.LargeImageCollection
        Me.BSearch.Location = New System.Drawing.Point(933, 2)
        Me.BSearch.Name = "BSearch"
        Me.BSearch.Size = New System.Drawing.Size(145, 38)
        Me.BSearch.TabIndex = 16
        Me.BSearch.Text = "Search Parameter"
        '
        'LargeImageCollection
        '
        Me.LargeImageCollection.ImageSize = New System.Drawing.Size(24, 24)
        Me.LargeImageCollection.ImageStream = CType(resources.GetObject("LargeImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.LargeImageCollection.Images.SetKeyName(0, "20_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(1, "8_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(2, "23_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(3, "arrow_refresh.png")
        Me.LargeImageCollection.Images.SetKeyName(4, "check_mark.png")
        Me.LargeImageCollection.Images.SetKeyName(5, "gnome_application_exit (1).png")
        Me.LargeImageCollection.Images.SetKeyName(6, "printer_3.png")
        Me.LargeImageCollection.Images.SetKeyName(7, "save.png")
        Me.LargeImageCollection.Images.SetKeyName(8, "31_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(9, "18_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(10, "1415351112474759854-32.png")
        Me.LargeImageCollection.Images.SetKeyName(11, "icon_merchandise_clothes32.png")
        Me.LargeImageCollection.Images.SetKeyName(12, "t_shirtgreen.png")
        Me.LargeImageCollection.Images.SetKeyName(13, "lock red.png")
        Me.LargeImageCollection.Images.SetKeyName(14, "ordering32.png")
        Me.LargeImageCollection.Images.SetKeyName(15, "kghostview.png")
        Me.LargeImageCollection.Images.SetKeyName(16, "MetroUI-Folder-OS-Configure-icon.png")
        Me.LargeImageCollection.Images.SetKeyName(17, "Setting(32).png")
        Me.LargeImageCollection.Images.SetKeyName(18, "estimate_icon32.png")
        Me.LargeImageCollection.Images.SetKeyName(19, "copy_icon.png")
        '
        'GCListDesign
        '
        Me.GCListDesign.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCListDesign.Location = New System.Drawing.Point(0, 42)
        Me.GCListDesign.MainView = Me.GVListDesign
        Me.GCListDesign.Name = "GCListDesign"
        Me.GCListDesign.Size = New System.Drawing.Size(1080, 521)
        Me.GCListDesign.TabIndex = 1
        Me.GCListDesign.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVListDesign})
        '
        'GVListDesign
        '
        Me.GVListDesign.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn15, Me.GridColumn14, Me.GridColumn13, Me.GridColumn12, Me.GridColumn7, Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumnDelQty, Me.GridColumnRTSQty, Me.GridColumnSalQty, Me.GridColumnSOHQty, Me.GridColumnpercentSaas, Me.GridColumnPercentSaasDel})
        Me.GVListDesign.GridControl = Me.GCListDesign
        Me.GVListDesign.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "del_qty", Me.GridColumnDelQty, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ret_qty", Me.GridColumnRTSQty, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sal_qty", Me.GridColumnSalQty, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "soh_qty", Me.GridColumnSOHQty, "{0:N0}")})
        Me.GVListDesign.Name = "GVListDesign"
        Me.GVListDesign.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVListDesign.OptionsView.ShowFooter = True
        Me.GVListDesign.OptionsView.ShowGroupPanel = False
        '
        'GridColumn15
        '
        Me.GridColumn15.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn15.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn15.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn15.Caption = "Division"
        Me.GridColumn15.FieldName = "division"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 0
        '
        'GridColumn14
        '
        Me.GridColumn14.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn14.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn14.Caption = "Sub Category"
        Me.GridColumn14.FieldName = "sub_cat"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 1
        '
        'GridColumn13
        '
        Me.GridColumn13.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn13.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn13.Caption = "Category"
        Me.GridColumn13.FieldName = "kat"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 2
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Group"
        Me.GridColumn12.Name = "GridColumn12"
        '
        'GridColumn1
        '
        Me.GridColumn1.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn1.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn1.Caption = "Class"
        Me.GridColumn1.FieldName = "class"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 4
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.Caption = "Code"
        Me.GridColumn2.FieldName = "design_code"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 5
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Description"
        Me.GridColumn3.FieldName = "design_display_name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 6
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Price"
        Me.GridColumn4.Name = "GridColumn4"
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Delivery"
        Me.GridColumn5.Name = "GridColumn5"
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Season"
        Me.GridColumn6.Name = "GridColumn6"
        '
        'GridColumnDelQty
        '
        Me.GridColumnDelQty.Caption = "DEL"
        Me.GridColumnDelQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnDelQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnDelQty.FieldName = "del_qty"
        Me.GridColumnDelQty.Name = "GridColumnDelQty"
        Me.GridColumnDelQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "del_qty", "{0:N0}")})
        Me.GridColumnDelQty.Visible = True
        Me.GridColumnDelQty.VisibleIndex = 7
        '
        'GridColumnRTSQty
        '
        Me.GridColumnRTSQty.Caption = "RTS"
        Me.GridColumnRTSQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnRTSQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnRTSQty.FieldName = "ret_qty"
        Me.GridColumnRTSQty.Name = "GridColumnRTSQty"
        Me.GridColumnRTSQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ret_qty", "{0:N0}")})
        Me.GridColumnRTSQty.Visible = True
        Me.GridColumnRTSQty.VisibleIndex = 8
        '
        'GridColumnSalQty
        '
        Me.GridColumnSalQty.Caption = "SAL"
        Me.GridColumnSalQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnSalQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnSalQty.FieldName = "sal_qty"
        Me.GridColumnSalQty.Name = "GridColumnSalQty"
        Me.GridColumnSalQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sal_qty", "{0:N0}")})
        Me.GridColumnSalQty.Visible = True
        Me.GridColumnSalQty.VisibleIndex = 9
        '
        'GridColumnSOHQty
        '
        Me.GridColumnSOHQty.Caption = "SOH"
        Me.GridColumnSOHQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnSOHQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnSOHQty.FieldName = "soh_qty"
        Me.GridColumnSOHQty.Name = "GridColumnSOHQty"
        Me.GridColumnSOHQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "soh_qty", "{0:N0}")})
        Me.GridColumnSOHQty.Visible = True
        Me.GridColumnSOHQty.VisibleIndex = 10
        '
        'GridColumnpercentSaas
        '
        Me.GridColumnpercentSaas.Caption = "% SAS"
        Me.GridColumnpercentSaas.DisplayFormat.FormatString = "{0:N2}%"
        Me.GridColumnpercentSaas.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnpercentSaas.FieldName = "percent_sas"
        Me.GridColumnpercentSaas.Name = "GridColumnpercentSaas"
        Me.GridColumnpercentSaas.Visible = True
        Me.GridColumnpercentSaas.VisibleIndex = 11
        '
        'GridColumnPercentSaasDel
        '
        Me.GridColumnPercentSaasDel.Caption = "% SAS SAL/DEL"
        Me.GridColumnPercentSaasDel.DisplayFormat.FormatString = "{0:N2}%"
        Me.GridColumnPercentSaasDel.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPercentSaasDel.FieldName = "percent_sas_sal_del"
        Me.GridColumnPercentSaasDel.Name = "GridColumnPercentSaasDel"
        Me.GridColumnPercentSaasDel.Visible = True
        Me.GridColumnPercentSaasDel.VisibleIndex = 12
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Group Class"
        Me.GridColumn7.FieldName = "group_class"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 3
        '
        'FormSalesReportTracking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1080, 563)
        Me.Controls.Add(Me.GCListDesign)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSalesReportTracking"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Sales Report"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCListDesign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVListDesign, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCListDesign As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVListDesign As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDelQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRTSQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSalQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSOHQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnpercentSaas As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BSearch As DevExpress.XtraEditors.SimpleButton
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPercentSaasDel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
End Class
