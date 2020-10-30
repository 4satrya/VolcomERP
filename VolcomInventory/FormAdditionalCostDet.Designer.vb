<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAdditionalCostDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAdditionalCostDet))
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.BAttachment = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnViewJournal = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.BMark = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.BPickArticle = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.GCDesignList = New DevExpress.XtraGrid.GridControl()
        Me.GVDesignList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCCostList = New DevExpress.XtraGrid.GridControl()
        Me.GVCostList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BDel = New DevExpress.XtraEditors.SimpleButton()
        Me.BAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.BCalculateSampleCOP = New DevExpress.XtraEditors.SimpleButton()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GCDesignList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDesignList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCCostList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVCostList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.GCDesignList)
        Me.GroupControl1.Controls.Add(Me.BPickArticle)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(995, 197)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Design List"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.GCCostList)
        Me.GroupControl2.Controls.Add(Me.PanelControl2)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(0, 197)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(995, 352)
        Me.GroupControl2.TabIndex = 1
        Me.GroupControl2.Text = "Cost List"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BAttachment)
        Me.PanelControl1.Controls.Add(Me.BtnViewJournal)
        Me.PanelControl1.Controls.Add(Me.BtnPrint)
        Me.PanelControl1.Controls.Add(Me.BMark)
        Me.PanelControl1.Controls.Add(Me.BtnCancel)
        Me.PanelControl1.Controls.Add(Me.BtnSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 503)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(995, 46)
        Me.PanelControl1.TabIndex = 2
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
        Me.LargeImageCollection.Images.SetKeyName(10, "10_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(11, "18_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(12, "31_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(13, "folder-documents-icon.png")
        Me.LargeImageCollection.Images.SetKeyName(14, "mail_attachment.png")
        Me.LargeImageCollection.Images.SetKeyName(15, "attachment-icon.png")
        '
        'BAttachment
        '
        Me.BAttachment.Dock = System.Windows.Forms.DockStyle.Right
        Me.BAttachment.Image = CType(resources.GetObject("BAttachment.Image"), System.Drawing.Image)
        Me.BAttachment.Location = New System.Drawing.Point(558, 2)
        Me.BAttachment.Name = "BAttachment"
        Me.BAttachment.Size = New System.Drawing.Size(105, 42)
        Me.BAttachment.TabIndex = 27
        Me.BAttachment.Text = "Attachment"
        Me.BAttachment.Visible = False
        '
        'BtnViewJournal
        '
        Me.BtnViewJournal.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnViewJournal.Image = CType(resources.GetObject("BtnViewJournal.Image"), System.Drawing.Image)
        Me.BtnViewJournal.Location = New System.Drawing.Point(663, 2)
        Me.BtnViewJournal.Name = "BtnViewJournal"
        Me.BtnViewJournal.Size = New System.Drawing.Size(105, 42)
        Me.BtnViewJournal.TabIndex = 26
        Me.BtnViewJournal.Text = "View Journal"
        Me.BtnViewJournal.Visible = False
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.ImageIndex = 6
        Me.BtnPrint.ImageList = Me.LargeImageCollection
        Me.BtnPrint.Location = New System.Drawing.Point(768, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(75, 42)
        Me.BtnPrint.TabIndex = 23
        Me.BtnPrint.TabStop = False
        Me.BtnPrint.Text = "Print"
        '
        'BMark
        '
        Me.BMark.Dock = System.Windows.Forms.DockStyle.Left
        Me.BMark.ImageIndex = 4
        Me.BMark.ImageList = Me.LargeImageCollection
        Me.BMark.Location = New System.Drawing.Point(2, 2)
        Me.BMark.Name = "BMark"
        Me.BMark.Size = New System.Drawing.Size(75, 42)
        Me.BMark.TabIndex = 25
        Me.BMark.TabStop = False
        Me.BMark.Text = "Mark"
        '
        'BtnCancel
        '
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.ImageIndex = 5
        Me.BtnCancel.ImageList = Me.LargeImageCollection
        Me.BtnCancel.Location = New System.Drawing.Point(843, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 42)
        Me.BtnCancel.TabIndex = 24
        Me.BtnCancel.TabStop = False
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnSave
        '
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSave.ImageIndex = 7
        Me.BtnSave.ImageList = Me.LargeImageCollection
        Me.BtnSave.Location = New System.Drawing.Point(918, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 42)
        Me.BtnSave.TabIndex = 22
        Me.BtnSave.TabStop = False
        Me.BtnSave.Text = "Save"
        '
        'BPickArticle
        '
        Me.BPickArticle.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BPickArticle.Location = New System.Drawing.Point(2, 169)
        Me.BPickArticle.Name = "BPickArticle"
        Me.BPickArticle.Size = New System.Drawing.Size(991, 26)
        Me.BPickArticle.TabIndex = 0
        Me.BPickArticle.Text = "Pick Design"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BCalculateSampleCOP)
        Me.PanelControl2.Controls.Add(Me.BDel)
        Me.PanelControl2.Controls.Add(Me.BAdd)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(2, 20)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(991, 41)
        Me.PanelControl2.TabIndex = 0
        '
        'GCDesignList
        '
        Me.GCDesignList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDesignList.Location = New System.Drawing.Point(2, 20)
        Me.GCDesignList.MainView = Me.GVDesignList
        Me.GCDesignList.Name = "GCDesignList"
        Me.GCDesignList.Size = New System.Drawing.Size(991, 149)
        Me.GCDesignList.TabIndex = 1
        Me.GCDesignList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDesignList})
        '
        'GVDesignList
        '
        Me.GVDesignList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn7, Me.GridColumn5, Me.GridColumn6})
        Me.GVDesignList.GridControl = Me.GCDesignList
        Me.GVDesignList.Name = "GVDesignList"
        Me.GVDesignList.OptionsView.ShowGroupPanel = False
        '
        'GCCostList
        '
        Me.GCCostList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCCostList.Location = New System.Drawing.Point(2, 61)
        Me.GCCostList.MainView = Me.GVCostList
        Me.GCCostList.Name = "GCCostList"
        Me.GCCostList.Size = New System.Drawing.Size(991, 289)
        Me.GCCostList.TabIndex = 1
        Me.GCCostList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVCostList})
        '
        'GVCostList
        '
        Me.GVCostList.GridControl = Me.GCCostList
        Me.GVCostList.Name = "GVCostList"
        '
        'BDel
        '
        Me.BDel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BDel.Image = CType(resources.GetObject("BDel.Image"), System.Drawing.Image)
        Me.BDel.Location = New System.Drawing.Point(779, 2)
        Me.BDel.Name = "BDel"
        Me.BDel.Size = New System.Drawing.Size(95, 37)
        Me.BDel.TabIndex = 5
        Me.BDel.Text = "Delete"
        '
        'BAdd
        '
        Me.BAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BAdd.Image = CType(resources.GetObject("BAdd.Image"), System.Drawing.Image)
        Me.BAdd.Location = New System.Drawing.Point(874, 2)
        Me.BAdd.Name = "BAdd"
        Me.BAdd.Size = New System.Drawing.Size(115, 37)
        Me.BAdd.TabIndex = 4
        Me.BAdd.Text = "Add"
        '
        'BCalculateSampleCOP
        '
        Me.BCalculateSampleCOP.Dock = System.Windows.Forms.DockStyle.Left
        Me.BCalculateSampleCOP.Image = CType(resources.GetObject("BCalculateSampleCOP.Image"), System.Drawing.Image)
        Me.BCalculateSampleCOP.Location = New System.Drawing.Point(2, 2)
        Me.BCalculateSampleCOP.Name = "BCalculateSampleCOP"
        Me.BCalculateSampleCOP.Size = New System.Drawing.Size(144, 37)
        Me.BCalculateSampleCOP.TabIndex = 6
        Me.BCalculateSampleCOP.Text = "Cost From Sampling"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID Design"
        Me.GridColumn1.FieldName = "id_design"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Design Code"
        Me.GridColumn2.FieldName = "design_code"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 254
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Design Display Name"
        Me.GridColumn3.FieldName = "design_display_name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 547
        '
        'GridColumn4
        '
        Me.GridColumn4.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn4.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn4.Caption = "ECOP"
        Me.GridColumn4.DisplayFormat.FormatString = "N2"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn4.FieldName = "prod_order_cop_pd"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 4
        Me.GridColumn4.Width = 205
        '
        'GridColumn5
        '
        Me.GridColumn5.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn5.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn5.Caption = "Qty Sampling"
        Me.GridColumn5.DisplayFormat.FormatString = "N0"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn5.FieldName = "qty_sampling"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        Me.GridColumn5.Width = 205
        '
        'GridColumn6
        '
        Me.GridColumn6.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn6.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn6.Caption = "Amount Cost Sampling"
        Me.GridColumn6.DisplayFormat.FormatString = "N2"
        Me.GridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn6.FieldName = "amount_sampling"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 5
        Me.GridColumn6.Width = 216
        '
        'GridColumn7
        '
        Me.GridColumn7.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn7.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn7.Caption = "Qty Order"
        Me.GridColumn7.DisplayFormat.FormatString = "N0"
        Me.GridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn7.FieldName = "qty_order"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 2
        Me.GridColumn7.Width = 205
        '
        'FormAdditionalCostDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(995, 549)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAdditionalCostDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Additional Cost Detail"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.GCDesignList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDesignList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCCostList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVCostList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents GCDesignList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDesignList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BPickArticle As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCCostList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVCostList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BAttachment As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnViewJournal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BDel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BCalculateSampleCOP As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
End Class
