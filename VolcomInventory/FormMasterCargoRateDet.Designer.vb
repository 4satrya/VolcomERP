<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMasterCargoRateDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMasterCargoRateDet))
        Me.SPC = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GCCargo = New DevExpress.XtraGrid.GridControl()
        Me.GVCargo = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTCInOut = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPInbound = New DevExpress.XtraTab.XtraTabPage()
        Me.GCInbound = New DevExpress.XtraGrid.GridControl()
        Me.GVInbound = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIDCargoDetIN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCargoRateIN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCargoMinWeightIN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCargoLeadTimeIN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCargoDatetimeIN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPOutbound = New DevExpress.XtraTab.XtraTabPage()
        Me.GCOutbound = New DevExpress.XtraGrid.GridControl()
        Me.GVOutbound = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.GridColumnIDCargoDetOut = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCargoRateOut = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnMinWeightOut = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLeadTimeOut = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDateInputOut = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.SPC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SPC.SuspendLayout()
        CType(Me.GCCargo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVCargo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCInOut, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCInOut.SuspendLayout()
        Me.XTPInbound.SuspendLayout()
        CType(Me.GCInbound, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVInbound, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPOutbound.SuspendLayout()
        CType(Me.GCOutbound, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVOutbound, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SPC
        '
        Me.SPC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SPC.Horizontal = False
        Me.SPC.Location = New System.Drawing.Point(0, 0)
        Me.SPC.Name = "SPC"
        Me.SPC.Panel1.Controls.Add(Me.GCCargo)
        Me.SPC.Panel1.Text = "Panel1"
        Me.SPC.Panel2.Controls.Add(Me.XTCInOut)
        Me.SPC.Panel2.Controls.Add(Me.PanelControl1)
        Me.SPC.Panel2.Text = "Panel2"
        Me.SPC.Size = New System.Drawing.Size(791, 397)
        Me.SPC.SplitterPosition = 148
        Me.SPC.TabIndex = 0
        Me.SPC.Text = "SplitContainerControl1"
        '
        'GCCargo
        '
        Me.GCCargo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCCargo.Location = New System.Drawing.Point(0, 0)
        Me.GCCargo.MainView = Me.GVCargo
        Me.GCCargo.Name = "GCCargo"
        Me.GCCargo.Size = New System.Drawing.Size(791, 148)
        Me.GCCargo.TabIndex = 0
        Me.GCCargo.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVCargo})
        '
        'GVCargo
        '
        Me.GVCargo.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn3, Me.GridColumn1, Me.GridColumn2})
        Me.GVCargo.GridControl = Me.GCCargo
        Me.GVCargo.Name = "GVCargo"
        Me.GVCargo.OptionsBehavior.Editable = False
        Me.GVCargo.OptionsView.ShowGroupPanel = False
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "ID Comp"
        Me.GridColumn3.FieldName = "id_comp"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Code"
        Me.GridColumn1.FieldName = "comp_number"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Description"
        Me.GridColumn2.FieldName = "comp_name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'XTCInOut
        '
        Me.XTCInOut.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCInOut.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCInOut.Location = New System.Drawing.Point(0, 40)
        Me.XTCInOut.Name = "XTCInOut"
        Me.XTCInOut.SelectedTabPage = Me.XTPInbound
        Me.XTCInOut.Size = New System.Drawing.Size(791, 204)
        Me.XTCInOut.TabIndex = 2
        Me.XTCInOut.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPInbound, Me.XTPOutbound})
        '
        'XTPInbound
        '
        Me.XTPInbound.Controls.Add(Me.GCInbound)
        Me.XTPInbound.Name = "XTPInbound"
        Me.XTPInbound.Size = New System.Drawing.Size(785, 176)
        Me.XTPInbound.Text = "Inbound"
        '
        'GCInbound
        '
        Me.GCInbound.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCInbound.Location = New System.Drawing.Point(0, 0)
        Me.GCInbound.MainView = Me.GVInbound
        Me.GCInbound.Name = "GCInbound"
        Me.GCInbound.Size = New System.Drawing.Size(785, 176)
        Me.GCInbound.TabIndex = 1
        Me.GCInbound.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVInbound})
        '
        'GVInbound
        '
        Me.GVInbound.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIDCargoDetIN, Me.GridColumnCargoRateIN, Me.GridColumnCargoMinWeightIN, Me.GridColumnCargoLeadTimeIN, Me.GridColumnCargoDatetimeIN})
        Me.GVInbound.GridControl = Me.GCInbound
        Me.GVInbound.Name = "GVInbound"
        Me.GVInbound.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIDCargoDetIN
        '
        Me.GridColumnIDCargoDetIN.Caption = "ID"
        Me.GridColumnIDCargoDetIN.FieldName = "id_cargo_rate_det"
        Me.GridColumnIDCargoDetIN.Name = "GridColumnIDCargoDetIN"
        '
        'GridColumnCargoRateIN
        '
        Me.GridColumnCargoRateIN.Caption = "Rate (Rp)"
        Me.GridColumnCargoRateIN.FieldName = "cargo_rate"
        Me.GridColumnCargoRateIN.Name = "GridColumnCargoRateIN"
        Me.GridColumnCargoRateIN.Visible = True
        Me.GridColumnCargoRateIN.VisibleIndex = 0
        '
        'GridColumnCargoMinWeightIN
        '
        Me.GridColumnCargoMinWeightIN.Caption = "Minimum Weight (Kg)"
        Me.GridColumnCargoMinWeightIN.FieldName = "cargo_min_weight"
        Me.GridColumnCargoMinWeightIN.Name = "GridColumnCargoMinWeightIN"
        Me.GridColumnCargoMinWeightIN.Visible = True
        Me.GridColumnCargoMinWeightIN.VisibleIndex = 1
        '
        'GridColumnCargoLeadTimeIN
        '
        Me.GridColumnCargoLeadTimeIN.Caption = "Lead Time (days)"
        Me.GridColumnCargoLeadTimeIN.FieldName = "cargo_lead_time"
        Me.GridColumnCargoLeadTimeIN.Name = "GridColumnCargoLeadTimeIN"
        Me.GridColumnCargoLeadTimeIN.Visible = True
        Me.GridColumnCargoLeadTimeIN.VisibleIndex = 2
        '
        'GridColumnCargoDatetimeIN
        '
        Me.GridColumnCargoDatetimeIN.Caption = "Date Input"
        Me.GridColumnCargoDatetimeIN.FieldName = "cargo_datetime"
        Me.GridColumnCargoDatetimeIN.Name = "GridColumnCargoDatetimeIN"
        Me.GridColumnCargoDatetimeIN.Visible = True
        Me.GridColumnCargoDatetimeIN.VisibleIndex = 3
        '
        'XTPOutbound
        '
        Me.XTPOutbound.Controls.Add(Me.GCOutbound)
        Me.XTPOutbound.Name = "XTPOutbound"
        Me.XTPOutbound.Size = New System.Drawing.Size(785, 176)
        Me.XTPOutbound.Text = "Outbound"
        '
        'GCOutbound
        '
        Me.GCOutbound.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCOutbound.Location = New System.Drawing.Point(0, 0)
        Me.GCOutbound.MainView = Me.GVOutbound
        Me.GCOutbound.Name = "GCOutbound"
        Me.GCOutbound.Size = New System.Drawing.Size(785, 176)
        Me.GCOutbound.TabIndex = 1
        Me.GCOutbound.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVOutbound})
        '
        'GVOutbound
        '
        Me.GVOutbound.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIDCargoDetOut, Me.GridColumnCargoRateOut, Me.GridColumnMinWeightOut, Me.GridColumnLeadTimeOut, Me.GridColumnDateInputOut})
        Me.GVOutbound.GridControl = Me.GCOutbound
        Me.GVOutbound.Name = "GVOutbound"
        Me.GVOutbound.OptionsView.ShowGroupPanel = False
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BAdd)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(791, 40)
        Me.PanelControl1.TabIndex = 1
        '
        'BAdd
        '
        Me.BAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BAdd.ImageIndex = 0
        Me.BAdd.ImageList = Me.LargeImageCollection
        Me.BAdd.Location = New System.Drawing.Point(673, 2)
        Me.BAdd.Name = "BAdd"
        Me.BAdd.Size = New System.Drawing.Size(116, 36)
        Me.BAdd.TabIndex = 0
        Me.BAdd.Text = "Update Rate"
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
        Me.LargeImageCollection.Images.SetKeyName(10, "attachment-icon.png")
        Me.LargeImageCollection.Images.SetKeyName(11, "30-Text_32x32.png")
        '
        'GridColumnIDCargoDetOut
        '
        Me.GridColumnIDCargoDetOut.Caption = "ID"
        Me.GridColumnIDCargoDetOut.FieldName = "id_cargo_rate_det"
        Me.GridColumnIDCargoDetOut.Name = "GridColumnIDCargoDetOut"
        '
        'GridColumnCargoRateOut
        '
        Me.GridColumnCargoRateOut.Caption = "Rate (Rp)"
        Me.GridColumnCargoRateOut.FieldName = "cargo_rate"
        Me.GridColumnCargoRateOut.Name = "GridColumnCargoRateOut"
        Me.GridColumnCargoRateOut.Visible = True
        Me.GridColumnCargoRateOut.VisibleIndex = 0
        '
        'GridColumnMinWeightOut
        '
        Me.GridColumnMinWeightOut.Caption = "Minimum Weight (Kg)"
        Me.GridColumnMinWeightOut.FieldName = "cargo_min_weight"
        Me.GridColumnMinWeightOut.Name = "GridColumnMinWeightOut"
        Me.GridColumnMinWeightOut.Visible = True
        Me.GridColumnMinWeightOut.VisibleIndex = 1
        '
        'GridColumnLeadTimeOut
        '
        Me.GridColumnLeadTimeOut.Caption = "Lead Time (days)"
        Me.GridColumnLeadTimeOut.FieldName = "cargo_lead_time"
        Me.GridColumnLeadTimeOut.Name = "GridColumnLeadTimeOut"
        Me.GridColumnLeadTimeOut.Visible = True
        Me.GridColumnLeadTimeOut.VisibleIndex = 2
        '
        'GridColumnDateInputOut
        '
        Me.GridColumnDateInputOut.Caption = "Date Input"
        Me.GridColumnDateInputOut.FieldName = "cargo_datetime"
        Me.GridColumnDateInputOut.Name = "GridColumnDateInputOut"
        Me.GridColumnDateInputOut.Visible = True
        Me.GridColumnDateInputOut.VisibleIndex = 3
        '
        'FormMasterCargoRateDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(791, 397)
        Me.Controls.Add(Me.SPC)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterCargoRateDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cargo Rate"
        CType(Me.SPC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SPC.ResumeLayout(False)
        CType(Me.GCCargo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVCargo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCInOut, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCInOut.ResumeLayout(False)
        Me.XTPInbound.ResumeLayout(False)
        CType(Me.GCInbound, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVInbound, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPOutbound.ResumeLayout(False)
        CType(Me.GCOutbound, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVOutbound, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SPC As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCCargo As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVCargo As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents XTCInOut As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPInbound As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPOutbound As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCInbound As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVInbound As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCOutbound As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVOutbound As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BAdd As DevExpress.XtraEditors.SimpleButton
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIDCargoDetIN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCargoRateIN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCargoMinWeightIN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCargoLeadTimeIN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCargoDatetimeIN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIDCargoDetOut As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCargoRateOut As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMinWeightOut As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLeadTimeOut As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDateInputOut As DevExpress.XtraGrid.Columns.GridColumn
End Class
