<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCardView
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
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.CardView1 = New DevExpress.XtraGrid.Views.Card.CardView()
        Me.GridColumnRepo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemPictureEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        Me.GridColumnUniformNoCard = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCodeCard = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNameCard = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSiCard = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPointCard = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CardView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemPictureEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.CardView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemPictureEdit1})
        Me.GridControl1.Size = New System.Drawing.Size(890, 459)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.CardView1})
        '
        'CardView1
        '
        Me.CardView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnRepo, Me.GridColumnUniformNoCard, Me.GridColumnCodeCard, Me.GridColumnNameCard, Me.GridColumnSiCard, Me.GridColumnPointCard})
        Me.CardView1.FocusedCardTopFieldIndex = 0
        Me.CardView1.GridControl = Me.GridControl1
        Me.CardView1.Name = "CardView1"
        Me.CardView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.[Auto]
        '
        'GridColumnRepo
        '
        Me.GridColumnRepo.Caption = "Picture"
        Me.GridColumnRepo.ColumnEdit = Me.RepositoryItemPictureEdit1
        Me.GridColumnRepo.Name = "GridColumnRepo"
        Me.GridColumnRepo.Visible = True
        Me.GridColumnRepo.VisibleIndex = 0
        '
        'RepositoryItemPictureEdit1
        '
        Me.RepositoryItemPictureEdit1.Name = "RepositoryItemPictureEdit1"
        Me.RepositoryItemPictureEdit1.NullText = "No Image"
        '
        'GridColumnUniformNoCard
        '
        Me.GridColumnUniformNoCard.Caption = "Uniform No"
        Me.GridColumnUniformNoCard.FieldName = "no"
        Me.GridColumnUniformNoCard.Name = "GridColumnUniformNoCard"
        Me.GridColumnUniformNoCard.Visible = True
        Me.GridColumnUniformNoCard.VisibleIndex = 1
        '
        'GridColumnCodeCard
        '
        Me.GridColumnCodeCard.Caption = "Code"
        Me.GridColumnCodeCard.FieldName = "code"
        Me.GridColumnCodeCard.Name = "GridColumnCodeCard"
        Me.GridColumnCodeCard.Visible = True
        Me.GridColumnCodeCard.VisibleIndex = 2
        '
        'GridColumnNameCard
        '
        Me.GridColumnNameCard.Caption = "Style"
        Me.GridColumnNameCard.FieldName = "name"
        Me.GridColumnNameCard.Name = "GridColumnNameCard"
        Me.GridColumnNameCard.Visible = True
        Me.GridColumnNameCard.VisibleIndex = 3
        '
        'GridColumnSiCard
        '
        Me.GridColumnSiCard.Caption = "Size Chart"
        Me.GridColumnSiCard.FieldName = "size_chart"
        Me.GridColumnSiCard.Name = "GridColumnSiCard"
        Me.GridColumnSiCard.Visible = True
        Me.GridColumnSiCard.VisibleIndex = 4
        '
        'GridColumnPointCard
        '
        Me.GridColumnPointCard.Caption = "Point"
        Me.GridColumnPointCard.DisplayFormat.FormatString = "n2"
        Me.GridColumnPointCard.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPointCard.FieldName = "point"
        Me.GridColumnPointCard.Name = "GridColumnPointCard"
        Me.GridColumnPointCard.Visible = True
        Me.GridColumnPointCard.VisibleIndex = 5
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SimpleButton1.Location = New System.Drawing.Point(0, 459)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(890, 23)
        Me.SimpleButton1.TabIndex = 1
        Me.SimpleButton1.Text = "SimpleButton1"
        '
        'FormCardView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(890, 482)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Name = "FormCardView"
        Me.Text = "FormCardView"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CardView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemPictureEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents CardView1 As DevExpress.XtraGrid.Views.Card.CardView
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnRepo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemPictureEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
    Friend WithEvents GridColumnUniformNoCard As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCodeCard As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNameCard As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSiCard As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPointCard As DevExpress.XtraGrid.Columns.GridColumn
End Class
