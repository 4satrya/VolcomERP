<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormOutboundManifest
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
        Me.BAccept = New DevExpress.XtraEditors.SimpleButton()
        Me.GCManifest = New DevExpress.XtraGrid.GridControl()
        Me.GVManifest = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCManifest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVManifest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BAccept
        '
        Me.BAccept.Appearance.BackColor = System.Drawing.SystemColors.Highlight
        Me.BAccept.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BAccept.Appearance.ForeColor = System.Drawing.Color.White
        Me.BAccept.Appearance.Options.UseBackColor = True
        Me.BAccept.Appearance.Options.UseFont = True
        Me.BAccept.Appearance.Options.UseForeColor = True
        Me.BAccept.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BAccept.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.BAccept.Location = New System.Drawing.Point(0, 334)
        Me.BAccept.LookAndFeel.SkinName = "Metropolis"
        Me.BAccept.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BAccept.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BAccept.Name = "BAccept"
        Me.BAccept.Size = New System.Drawing.Size(784, 28)
        Me.BAccept.TabIndex = 139
        Me.BAccept.Text = "Print Delivery Manifest"
        '
        'GCManifest
        '
        Me.GCManifest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCManifest.Location = New System.Drawing.Point(0, 0)
        Me.GCManifest.LookAndFeel.SkinName = "Office 2013 Dark Gray"
        Me.GCManifest.MainView = Me.GVManifest
        Me.GCManifest.Name = "GCManifest"
        Me.GCManifest.Size = New System.Drawing.Size(784, 334)
        Me.GCManifest.TabIndex = 140
        Me.GCManifest.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVManifest})
        '
        'GVManifest
        '
        Me.GVManifest.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GVManifest.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GVManifest.Appearance.Row.Options.UseTextOptions = True
        Me.GVManifest.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GVManifest.ColumnPanelRowHeight = 50
        Me.GVManifest.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNo, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16, Me.GridColumn18})
        Me.GVManifest.GridControl = Me.GCManifest
        Me.GVManifest.IndicatorWidth = 50
        Me.GVManifest.Name = "GVManifest"
        Me.GVManifest.OptionsBehavior.Editable = False
        Me.GVManifest.OptionsPrint.AllowMultilineHeaders = True
        Me.GVManifest.OptionsView.AllowCellMerge = True
        Me.GVManifest.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVManifest.OptionsView.ShowGroupPanel = False
        Me.GVManifest.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn4, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnNo
        '
        Me.GridColumnNo.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnNo.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnNo.Caption = "NO"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.Width = 43
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "DELIVERY SLIP"
        Me.GridColumn2.FieldName = "do_no"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 55
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "SCANNED DATE"
        Me.GridColumn3.FieldName = "scan_date"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "STORE ACCOUNT"
        Me.GridColumn4.FieldName = "account"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 1
        Me.GridColumn4.Width = 60
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "REFF"
        Me.GridColumn5.FieldName = "reff"
        Me.GridColumn5.Name = "GridColumn5"
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "STORE NAME"
        Me.GridColumn6.FieldName = "account_name"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 2
        Me.GridColumn6.Width = 166
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "QTY"
        Me.GridColumn7.FieldName = "qty"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 3
        Me.GridColumn7.Width = 35
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "GROUP STORE"
        Me.GridColumn8.FieldName = "comp_group"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 4
        Me.GridColumn8.Width = 44
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "WEIGHT"
        Me.GridColumn9.DisplayFormat.FormatString = "N0"
        Me.GridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn9.FieldName = "weight"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 5
        Me.GridColumn9.Width = 35
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "P"
        Me.GridColumn10.DisplayFormat.FormatString = "N0"
        Me.GridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn10.FieldName = "length"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 6
        Me.GridColumn10.Width = 35
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "L"
        Me.GridColumn11.DisplayFormat.FormatString = "N0"
        Me.GridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn11.FieldName = "width"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 7
        Me.GridColumn11.Width = 35
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "T"
        Me.GridColumn12.DisplayFormat.FormatString = "N0"
        Me.GridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn12.FieldName = "height"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 8
        Me.GridColumn12.Width = 35
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "DIM"
        Me.GridColumn13.DisplayFormat.FormatString = "N2"
        Me.GridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn13.FieldName = "volume"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 9
        Me.GridColumn13.Width = 35
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "FINAL WEIGHT"
        Me.GridColumn14.FieldName = "c_weight"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 10
        Me.GridColumn14.Width = 35
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "3PL"
        Me.GridColumn15.FieldName = "cargo"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 11
        Me.GridColumn15.Width = 51
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "REMARK"
        Me.GridColumn16.FieldName = "rmk"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 12
        Me.GridColumn16.Width = 111
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "ID"
        Me.GridColumn18.FieldName = "id_awbill"
        Me.GridColumn18.Name = "GridColumn18"
        '
        'FormOutboundManifest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 362)
        Me.Controls.Add(Me.GCManifest)
        Me.Controls.Add(Me.BAccept)
        Me.LookAndFeel.SkinName = "Metropolis Dark"
        Me.MinimizeBox = False
        Me.Name = "FormOutboundManifest"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Outbound Delivery Manifest"
        CType(Me.GCManifest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVManifest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BAccept As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCManifest As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVManifest As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
End Class
