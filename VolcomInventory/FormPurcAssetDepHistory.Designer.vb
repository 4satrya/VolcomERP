<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPurcAssetDepHistory
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
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.GCHistory = New DevExpress.XtraGrid.GridControl()
        Me.GVHistory = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdasset = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnassetNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnassetName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPeriod = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDepNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBtnViewJournal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BtnViewJournal = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        CType(Me.GCHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnViewJournal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCHistory
        '
        Me.GCHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCHistory.Location = New System.Drawing.Point(0, 0)
        Me.GCHistory.MainView = Me.GVHistory
        Me.GCHistory.Name = "GCHistory"
        Me.GCHistory.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.BtnViewJournal})
        Me.GCHistory.Size = New System.Drawing.Size(779, 418)
        Me.GCHistory.TabIndex = 0
        Me.GCHistory.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVHistory})
        '
        'GVHistory
        '
        Me.GVHistory.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnId, Me.GridColumnIdasset, Me.GridColumnassetNumber, Me.GridColumnassetName, Me.GridColumnPeriod, Me.GridColumnAmount, Me.GridColumnCreatedDate, Me.GridColumnDepNo, Me.GridColumnBtnViewJournal})
        Me.GVHistory.GridControl = Me.GCHistory
        Me.GVHistory.Name = "GVHistory"
        Me.GVHistory.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVHistory.OptionsFind.AlwaysVisible = True
        Me.GVHistory.OptionsView.ShowFooter = True
        Me.GVHistory.OptionsView.ShowGroupPanel = False
        '
        'GridColumnId
        '
        Me.GridColumnId.Caption = "Id"
        Me.GridColumnId.FieldName = "id_purc_rec_asset_dep"
        Me.GridColumnId.Name = "GridColumnId"
        Me.GridColumnId.OptionsColumn.AllowEdit = False
        '
        'GridColumnIdasset
        '
        Me.GridColumnIdasset.Caption = "Id Asset"
        Me.GridColumnIdasset.FieldName = "id_purc_rec_asset"
        Me.GridColumnIdasset.Name = "GridColumnIdasset"
        Me.GridColumnIdasset.OptionsColumn.AllowEdit = False
        '
        'GridColumnassetNumber
        '
        Me.GridColumnassetNumber.Caption = "Asset Number"
        Me.GridColumnassetNumber.FieldName = "asset_number"
        Me.GridColumnassetNumber.Name = "GridColumnassetNumber"
        Me.GridColumnassetNumber.OptionsColumn.AllowEdit = False
        Me.GridColumnassetNumber.Visible = True
        Me.GridColumnassetNumber.VisibleIndex = 1
        '
        'GridColumnassetName
        '
        Me.GridColumnassetName.Caption = "Asset Name"
        Me.GridColumnassetName.FieldName = "asset_name"
        Me.GridColumnassetName.Name = "GridColumnassetName"
        Me.GridColumnassetName.OptionsColumn.AllowEdit = False
        Me.GridColumnassetName.Visible = True
        Me.GridColumnassetName.VisibleIndex = 2
        '
        'GridColumnPeriod
        '
        Me.GridColumnPeriod.Caption = "Period"
        Me.GridColumnPeriod.DisplayFormat.FormatString = "MMMM yyyy"
        Me.GridColumnPeriod.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnPeriod.FieldName = "period"
        Me.GridColumnPeriod.Name = "GridColumnPeriod"
        Me.GridColumnPeriod.OptionsColumn.AllowEdit = False
        Me.GridColumnPeriod.Visible = True
        Me.GridColumnPeriod.VisibleIndex = 3
        '
        'GridColumnAmount
        '
        Me.GridColumnAmount.Caption = "Amount"
        Me.GridColumnAmount.DisplayFormat.FormatString = "N2"
        Me.GridColumnAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnAmount.FieldName = "amount"
        Me.GridColumnAmount.Name = "GridColumnAmount"
        Me.GridColumnAmount.OptionsColumn.AllowEdit = False
        Me.GridColumnAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:N2}")})
        Me.GridColumnAmount.Visible = True
        Me.GridColumnAmount.VisibleIndex = 4
        '
        'GridColumnCreatedDate
        '
        Me.GridColumnCreatedDate.Caption = "Created Date"
        Me.GridColumnCreatedDate.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm"
        Me.GridColumnCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnCreatedDate.FieldName = "created_date"
        Me.GridColumnCreatedDate.Name = "GridColumnCreatedDate"
        Me.GridColumnCreatedDate.OptionsColumn.AllowEdit = False
        Me.GridColumnCreatedDate.Visible = True
        Me.GridColumnCreatedDate.VisibleIndex = 5
        '
        'GridColumnDepNo
        '
        Me.GridColumnDepNo.Caption = "Depereciation Number"
        Me.GridColumnDepNo.FieldName = "number"
        Me.GridColumnDepNo.Name = "GridColumnDepNo"
        Me.GridColumnDepNo.OptionsColumn.AllowEdit = False
        Me.GridColumnDepNo.Visible = True
        Me.GridColumnDepNo.VisibleIndex = 0
        '
        'GridColumnBtnViewJournal
        '
        Me.GridColumnBtnViewJournal.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnBtnViewJournal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnBtnViewJournal.Caption = "Action"
        Me.GridColumnBtnViewJournal.ColumnEdit = Me.BtnViewJournal
        Me.GridColumnBtnViewJournal.FieldName = "btn_view_journal"
        Me.GridColumnBtnViewJournal.Name = "GridColumnBtnViewJournal"
        Me.GridColumnBtnViewJournal.Visible = True
        Me.GridColumnBtnViewJournal.VisibleIndex = 6
        '
        'BtnViewJournal
        '
        Me.BtnViewJournal.AutoHeight = False
        SerializableAppearanceObject1.BackColor = System.Drawing.SystemColors.Highlight
        SerializableAppearanceObject1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SerializableAppearanceObject1.ForeColor = System.Drawing.Color.White
        SerializableAppearanceObject1.Options.UseBackColor = True
        SerializableAppearanceObject1.Options.UseFont = True
        SerializableAppearanceObject1.Options.UseForeColor = True
        Me.BtnViewJournal.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "view journal", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.BtnViewJournal.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnViewJournal.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnViewJournal.Name = "BtnViewJournal"
        Me.BtnViewJournal.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'FormPurcAssetDepHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(779, 418)
        Me.Controls.Add(Me.GCHistory)
        Me.MinimizeBox = False
        Me.Name = "FormPurcAssetDepHistory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Depreciation History"
        CType(Me.GCHistory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVHistory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnViewJournal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCHistory As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVHistory As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdasset As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnassetNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnassetName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPeriod As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDepNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBtnViewJournal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnViewJournal As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
End Class
