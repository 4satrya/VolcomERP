<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CobaFormBanded
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
        Me.GCView = New DevExpress.XtraGrid.GridControl()
        Me.BGVList = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        CType(Me.GCView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BGVList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCView
        '
        Me.GCView.Location = New System.Drawing.Point(12, 12)
        Me.GCView.MainView = Me.BGVList
        Me.GCView.Name = "GCView"
        Me.GCView.Size = New System.Drawing.Size(1111, 404)
        Me.GCView.TabIndex = 0
        Me.GCView.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.BGVList})
        '
        'BGVList
        '
        Me.BGVList.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1})
        Me.BGVList.GridControl = Me.GCView
        Me.BGVList.Name = "BGVList"
        Me.BGVList.OptionsBehavior.Editable = False
        '
        'GridBand1
        '
        Me.GridBand1.Caption = "GridBand1"
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        '
        'CobaFormBanded
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1135, 428)
        Me.Controls.Add(Me.GCView)
        Me.Name = "CobaFormBanded"
        Me.Text = "CobaFormBanded"
        CType(Me.GCView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BGVList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCView As DevExpress.XtraGrid.GridControl
    Friend WithEvents BGVList As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
End Class
