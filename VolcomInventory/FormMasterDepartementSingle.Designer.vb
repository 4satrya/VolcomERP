<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterDepartementSingle
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
        Me.EPDepartement = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.MEDescription = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TEDepartementCode = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.TEDepartement = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEHeadDept = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SLEViewEmp = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdUser = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNIK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEAsstHeadDept = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.EPDepartement, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEDepartementCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEDepartement.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEHeadDept.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEViewEmp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEAsstHeadDept.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EPDepartement
        '
        Me.EPDepartement.ContainerControl = Me
        '
        'MEDescription
        '
        Me.MEDescription.Location = New System.Drawing.Point(14, 131)
        Me.MEDescription.Name = "MEDescription"
        Me.MEDescription.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MEDescription.Properties.Appearance.Options.UseFont = True
        Me.MEDescription.Size = New System.Drawing.Size(337, 74)
        Me.MEDescription.TabIndex = 2
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LabelControl3.Location = New System.Drawing.Point(14, 113)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(64, 15)
        Me.LabelControl3.TabIndex = 33
        Me.LabelControl3.Text = "Description"
        '
        'TEDepartementCode
        '
        Me.TEDepartementCode.Location = New System.Drawing.Point(14, 81)
        Me.TEDepartementCode.Name = "TEDepartementCode"
        Me.TEDepartementCode.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TEDepartementCode.Properties.Appearance.Options.UseFont = True
        Me.TEDepartementCode.Size = New System.Drawing.Size(337, 22)
        Me.TEDepartementCode.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LabelControl2.Location = New System.Drawing.Point(14, 64)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(100, 15)
        Me.LabelControl2.TabIndex = 32
        Me.LabelControl2.Text = "Departement Code"
        '
        'BCancel
        '
        Me.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancel.Location = New System.Drawing.Point(197, 322)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(74, 28)
        Me.BCancel.TabIndex = 4
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Location = New System.Drawing.Point(277, 322)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(74, 28)
        Me.BSave.TabIndex = 3
        Me.BSave.Text = "Save"
        '
        'TEDepartement
        '
        Me.TEDepartement.Location = New System.Drawing.Point(14, 33)
        Me.TEDepartement.Name = "TEDepartement"
        Me.TEDepartement.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TEDepartement.Properties.Appearance.Options.UseFont = True
        Me.TEDepartement.Size = New System.Drawing.Size(337, 22)
        Me.TEDepartement.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LabelControl1.Location = New System.Drawing.Point(14, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(70, 15)
        Me.LabelControl1.TabIndex = 31
        Me.LabelControl1.Text = "Departement"
        '
        'SLEHeadDept
        '
        Me.SLEHeadDept.Location = New System.Drawing.Point(14, 237)
        Me.SLEHeadDept.Name = "SLEHeadDept"
        Me.SLEHeadDept.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEHeadDept.Properties.View = Me.SLEViewEmp
        Me.SLEHeadDept.Size = New System.Drawing.Size(337, 20)
        Me.SLEHeadDept.TabIndex = 34
        '
        'SLEViewEmp
        '
        Me.SLEViewEmp.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdUser, Me.GridColumn1, Me.GridColumn2, Me.GridColumnNIK, Me.GridColumnName})
        Me.SLEViewEmp.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SLEViewEmp.Name = "SLEViewEmp"
        Me.SLEViewEmp.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SLEViewEmp.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdUser
        '
        Me.GridColumnIdUser.Caption = "Id User"
        Me.GridColumnIdUser.FieldName = "id_user"
        Me.GridColumnIdUser.Name = "GridColumnIdUser"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID Departement"
        Me.GridColumn1.FieldName = "id_departement"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Departement"
        Me.GridColumn2.FieldName = "departement"
        Me.GridColumn2.FieldNameSortGroup = "id_departement"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumnNIK
        '
        Me.GridColumnNIK.Caption = "NIK"
        Me.GridColumnNIK.FieldName = "employee_code"
        Me.GridColumnNIK.Name = "GridColumnNIK"
        Me.GridColumnNIK.Visible = True
        Me.GridColumnNIK.VisibleIndex = 0
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Name"
        Me.GridColumnName.FieldName = "employee_name"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 2
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LabelControl4.Location = New System.Drawing.Point(14, 216)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(101, 15)
        Me.LabelControl4.TabIndex = 35
        Me.LabelControl4.Text = "Head Departement"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LabelControl5.Location = New System.Drawing.Point(14, 263)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(127, 15)
        Me.LabelControl5.TabIndex = 37
        Me.LabelControl5.Text = "Asst Head Departement"
        '
        'SLEAsstHeadDept
        '
        Me.SLEAsstHeadDept.Location = New System.Drawing.Point(14, 284)
        Me.SLEAsstHeadDept.Name = "SLEAsstHeadDept"
        Me.SLEAsstHeadDept.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEAsstHeadDept.Properties.View = Me.GridView1
        Me.SLEAsstHeadDept.Size = New System.Drawing.Size(337, 20)
        Me.SLEAsstHeadDept.TabIndex = 36
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Id User"
        Me.GridColumn3.FieldName = "id_user"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "ID Departement"
        Me.GridColumn4.FieldName = "id_departement"
        Me.GridColumn4.Name = "GridColumn4"
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Departement"
        Me.GridColumn5.FieldName = "departement"
        Me.GridColumn5.FieldNameSortGroup = "id_departement"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 1
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "NIK"
        Me.GridColumn6.FieldName = "employee_code"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 0
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Name"
        Me.GridColumn7.FieldName = "employee_name"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 2
        '
        'FormMasterDepartementSingle
        '
        Me.AcceptButton = Me.BSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BCancel
        Me.ClientSize = New System.Drawing.Size(363, 362)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.SLEAsstHeadDept)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.SLEHeadDept)
        Me.Controls.Add(Me.MEDescription)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.TEDepartementCode)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.BCancel)
        Me.Controls.Add(Me.BSave)
        Me.Controls.Add(Me.TEDepartement)
        Me.Controls.Add(Me.LabelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterDepartementSingle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Departement"
        CType(Me.EPDepartement, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEDepartementCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEDepartement.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEHeadDept.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEViewEmp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEAsstHeadDept.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EPDepartement As System.Windows.Forms.ErrorProvider
    Friend WithEvents MEDescription As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEDepartementCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEDepartement As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEHeadDept As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SLEViewEmp As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdUser As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNIK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEAsstHeadDept As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
End Class
