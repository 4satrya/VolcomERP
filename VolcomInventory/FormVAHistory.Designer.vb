<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormVAHistory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormVAHistory))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.GCVA = New DevExpress.XtraGrid.GridControl()
        Me.GVVA = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_virtual_acc_trans = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntransaction_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnbank = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumngenerate_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnamountva = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCVA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVVA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LabelControl4)
        Me.PanelControl1.Controls.Add(Me.PanelControl2)
        Me.PanelControl1.Controls.Add(Me.BtnPrint)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(546, 53)
        Me.PanelControl1.TabIndex = 1
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(444, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(100, 49)
        Me.BtnPrint.TabIndex = 0
        Me.BtnPrint.Text = "Print List"
        '
        'GCVA
        '
        Me.GCVA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCVA.Location = New System.Drawing.Point(0, 53)
        Me.GCVA.MainView = Me.GVVA
        Me.GCVA.Name = "GCVA"
        Me.GCVA.Size = New System.Drawing.Size(546, 308)
        Me.GCVA.TabIndex = 23
        Me.GCVA.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVVA})
        '
        'GVVA
        '
        Me.GVVA.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_virtual_acc_trans, Me.GridColumntransaction_date, Me.GridColumnbank, Me.GridColumngenerate_date, Me.GridColumnamountva, Me.GridColumnnumber})
        Me.GVVA.GridControl = Me.GCVA
        Me.GVVA.Name = "GVVA"
        Me.GVVA.OptionsBehavior.ReadOnly = True
        Me.GVVA.OptionsFind.AlwaysVisible = True
        Me.GVVA.OptionsView.ShowFooter = True
        Me.GVVA.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_virtual_acc_trans
        '
        Me.GridColumnid_virtual_acc_trans.Caption = "id_virtual_acc_trans"
        Me.GridColumnid_virtual_acc_trans.FieldName = "id_virtual_acc_trans"
        Me.GridColumnid_virtual_acc_trans.Name = "GridColumnid_virtual_acc_trans"
        '
        'GridColumntransaction_date
        '
        Me.GridColumntransaction_date.Caption = "Transaction Date"
        Me.GridColumntransaction_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumntransaction_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumntransaction_date.FieldName = "transaction_date"
        Me.GridColumntransaction_date.Name = "GridColumntransaction_date"
        Me.GridColumntransaction_date.Visible = True
        Me.GridColumntransaction_date.VisibleIndex = 1
        '
        'GridColumnbank
        '
        Me.GridColumnbank.Caption = "Bank"
        Me.GridColumnbank.FieldName = "bank"
        Me.GridColumnbank.Name = "GridColumnbank"
        Me.GridColumnbank.Visible = True
        Me.GridColumnbank.VisibleIndex = 2
        '
        'GridColumngenerate_date
        '
        Me.GridColumngenerate_date.Caption = "Input Date"
        Me.GridColumngenerate_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumngenerate_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumngenerate_date.FieldName = "generate_date"
        Me.GridColumngenerate_date.Name = "GridColumngenerate_date"
        '
        'GridColumnamountva
        '
        Me.GridColumnamountva.Caption = "Amount"
        Me.GridColumnamountva.DisplayFormat.FormatString = "N2"
        Me.GridColumnamountva.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnamountva.FieldName = "amount"
        Me.GridColumnamountva.Name = "GridColumnamountva"
        Me.GridColumnamountva.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:N2}")})
        Me.GridColumnamountva.Visible = True
        Me.GridColumnamountva.VisibleIndex = 3
        '
        'GridColumnnumber
        '
        Me.GridColumnnumber.Caption = "Number"
        Me.GridColumnnumber.FieldName = "number"
        Me.GridColumnnumber.Name = "GridColumnnumber"
        Me.GridColumnnumber.Visible = True
        Me.GridColumnnumber.VisibleIndex = 0
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Segoe UI", 6.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl4.Location = New System.Drawing.Point(40, 21)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(18, 12)
        Me.LabelControl4.TabIndex = 148
        Me.LabelControl4.Text = "BAP"
        '
        'PanelControl2
        '
        Me.PanelControl2.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.PanelControl2.Appearance.BorderColor = System.Drawing.Color.White
        Me.PanelControl2.Appearance.Options.UseBackColor = True
        Me.PanelControl2.Appearance.Options.UseBorderColor = True
        Me.PanelControl2.Location = New System.Drawing.Point(14, 21)
        Me.PanelControl2.LookAndFeel.SkinMaskColor = System.Drawing.Color.Yellow
        Me.PanelControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.PanelControl2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(24, 13)
        Me.PanelControl2.TabIndex = 147
        '
        'FormVAHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(546, 361)
        Me.Controls.Add(Me.GCVA)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormVAHistory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import History"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.GCVA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVVA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCVA As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVVA As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_virtual_acc_trans As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntransaction_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnbank As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumngenerate_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnamountva As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
End Class
