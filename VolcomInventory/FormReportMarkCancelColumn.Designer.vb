<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormReportMarkCancelColumn
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormReportMarkCancelColumn))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BAddColumn = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TEColumnName = New DevExpress.XtraEditors.TextEdit()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.GCAddColumn = New DevExpress.XtraGrid.GridControl()
        Me.GVAddColumn = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BDelColumn = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TEColumnName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCAddColumn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVAddColumn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BDelColumn)
        Me.PanelControl1.Controls.Add(Me.BAddColumn)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.TEColumnName)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(641, 41)
        Me.PanelControl1.TabIndex = 0
        '
        'BAddColumn
        '
        Me.BAddColumn.Location = New System.Drawing.Point(260, 10)
        Me.BAddColumn.Name = "BAddColumn"
        Me.BAddColumn.Size = New System.Drawing.Size(75, 23)
        Me.BAddColumn.TabIndex = 2
        Me.BAddColumn.Text = "Add Column"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Column Name"
        '
        'TEColumnName
        '
        Me.TEColumnName.Location = New System.Drawing.Point(83, 12)
        Me.TEColumnName.Name = "TEColumnName"
        Me.TEColumnName.Size = New System.Drawing.Size(171, 20)
        Me.TEColumnName.TabIndex = 0
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
        'GCAddColumn
        '
        Me.GCAddColumn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCAddColumn.Location = New System.Drawing.Point(0, 41)
        Me.GCAddColumn.MainView = Me.GVAddColumn
        Me.GCAddColumn.Name = "GCAddColumn"
        Me.GCAddColumn.Size = New System.Drawing.Size(641, 258)
        Me.GCAddColumn.TabIndex = 1
        Me.GCAddColumn.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAddColumn})
        '
        'GVAddColumn
        '
        Me.GVAddColumn.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2})
        Me.GVAddColumn.GridControl = Me.GCAddColumn
        Me.GVAddColumn.Name = "GVAddColumn"
        Me.GVAddColumn.OptionsBehavior.ReadOnly = True
        Me.GVAddColumn.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Column Name"
        Me.GridColumn2.FieldName = "column_name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'BDelColumn
        '
        Me.BDelColumn.Location = New System.Drawing.Point(341, 10)
        Me.BDelColumn.Name = "BDelColumn"
        Me.BDelColumn.Size = New System.Drawing.Size(78, 23)
        Me.BDelColumn.TabIndex = 3
        Me.BDelColumn.Text = "Delete Column"
        '
        'FormReportMarkCancelColumn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(641, 299)
        Me.Controls.Add(Me.GCAddColumn)
        Me.Controls.Add(Me.PanelControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormReportMarkCancelColumn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Additional Column"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.TEColumnName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCAddColumn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVAddColumn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents BAddColumn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEColumnName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GCAddColumn As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVAddColumn As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BDelColumn As DevExpress.XtraEditors.SimpleButton
End Class
