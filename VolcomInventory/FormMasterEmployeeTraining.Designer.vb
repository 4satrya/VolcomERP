<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMasterEmployeeTraining
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMasterEmployeeTraining))
        Me.TxtCourse = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.TxtDateFrom = New DevExpress.XtraEditors.DateEdit()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtInstitution = New DevExpress.XtraEditors.TextEdit()
        Me.LabelDocument = New DevExpress.XtraEditors.LabelControl()
        Me.GCDocument = New DevExpress.XtraGrid.GridControl()
        Me.GVDocument = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCDescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCExt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCOption = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICE = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.BtnAddDocument = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnDelDocument = New DevExpress.XtraEditors.SimpleButton()
        Me.TxtDateUntil = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.TxtCourse.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TxtDateFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDateFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtInstitution.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCDocument, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDocument, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDateUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDateUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtCourse
        '
        Me.TxtCourse.EditValue = ""
        Me.TxtCourse.Location = New System.Drawing.Point(12, 31)
        Me.TxtCourse.Name = "TxtCourse"
        Me.TxtCourse.Size = New System.Drawing.Size(462, 20)
        Me.TxtCourse.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Course"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 102)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "From"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 421)
        Me.PanelControl1.LookAndFeel.SkinName = "Blue"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(490, 38)
        Me.PanelControl1.TabIndex = 101
        '
        'BtnSave
        '
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSave.Location = New System.Drawing.Point(413, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 34)
        Me.BtnSave.TabIndex = 6
        Me.BtnSave.Text = "Save"
        '
        'TxtDateFrom
        '
        Me.TxtDateFrom.EditValue = Nothing
        Me.TxtDateFrom.Location = New System.Drawing.Point(12, 121)
        Me.TxtDateFrom.Name = "TxtDateFrom"
        Me.TxtDateFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtDateFrom.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.TxtDateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TxtDateFrom.Size = New System.Drawing.Size(462, 20)
        Me.TxtDateFrom.TabIndex = 102
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(12, 57)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(49, 13)
        Me.LabelControl3.TabIndex = 104
        Me.LabelControl3.Text = "Institution"
        '
        'TxtInstitution
        '
        Me.TxtInstitution.EditValue = ""
        Me.TxtInstitution.Location = New System.Drawing.Point(12, 76)
        Me.TxtInstitution.Name = "TxtInstitution"
        Me.TxtInstitution.Size = New System.Drawing.Size(462, 20)
        Me.TxtInstitution.TabIndex = 103
        '
        'LabelDocument
        '
        Me.LabelDocument.Location = New System.Drawing.Point(12, 192)
        Me.LabelDocument.Name = "LabelDocument"
        Me.LabelDocument.Size = New System.Drawing.Size(48, 13)
        Me.LabelDocument.TabIndex = 105
        Me.LabelDocument.Text = "Document"
        '
        'GCDocument
        '
        Me.GCDocument.Location = New System.Drawing.Point(12, 221)
        Me.GCDocument.MainView = Me.GVDocument
        Me.GCDocument.Name = "GCDocument"
        Me.GCDocument.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICE})
        Me.GCDocument.Size = New System.Drawing.Size(462, 183)
        Me.GCDocument.TabIndex = 106
        Me.GCDocument.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDocument})
        '
        'GVDocument
        '
        Me.GVDocument.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCId, Me.GCDescription, Me.GCExt, Me.GCOption})
        Me.GVDocument.GridControl = Me.GCDocument
        Me.GVDocument.Name = "GVDocument"
        Me.GVDocument.OptionsView.ShowGroupPanel = False
        '
        'GCId
        '
        Me.GCId.Caption = "Id"
        Me.GCId.FieldName = "id_employee_training_doc"
        Me.GCId.Name = "GCId"
        '
        'GCDescription
        '
        Me.GCDescription.Caption = "Description"
        Me.GCDescription.FieldName = "description"
        Me.GCDescription.Name = "GCDescription"
        Me.GCDescription.OptionsColumn.AllowEdit = False
        Me.GCDescription.Visible = True
        Me.GCDescription.VisibleIndex = 0
        Me.GCDescription.Width = 326
        '
        'GCExt
        '
        Me.GCExt.Caption = "Ext"
        Me.GCExt.FieldName = "ext"
        Me.GCExt.Name = "GCExt"
        '
        'GCOption
        '
        Me.GCOption.AppearanceCell.Options.UseTextOptions = True
        Me.GCOption.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GCOption.AppearanceHeader.Options.UseTextOptions = True
        Me.GCOption.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GCOption.Caption = "Option"
        Me.GCOption.ColumnEdit = Me.RICE
        Me.GCOption.FieldName = "is_download"
        Me.GCOption.Name = "GCOption"
        Me.GCOption.Visible = True
        Me.GCOption.VisibleIndex = 1
        '
        'RICE
        '
        Me.RICE.AutoHeight = False
        Me.RICE.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined
        Me.RICE.ImageIndexChecked = 5
        Me.RICE.ImageIndexGrayed = 5
        Me.RICE.ImageIndexUnchecked = 5
        Me.RICE.Images = Me.LargeImageCollection
        Me.RICE.Name = "RICE"
        '
        'LargeImageCollection
        '
        Me.LargeImageCollection.ImageSize = New System.Drawing.Size(24, 24)
        Me.LargeImageCollection.ImageStream = CType(resources.GetObject("LargeImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.LargeImageCollection.Images.SetKeyName(0, "8_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(1, "18_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(2, "1415874002_download.png")
        Me.LargeImageCollection.Images.SetKeyName(3, "1415874519_arrow_up.png")
        Me.LargeImageCollection.Images.SetKeyName(4, "1415874551_bullet_deny.png")
        Me.LargeImageCollection.InsertGalleryImage("open2_32x32.png", "images/actions/open2_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/open2_32x32.png"), 5)
        Me.LargeImageCollection.Images.SetKeyName(5, "open2_32x32.png")
        '
        'BtnAddDocument
        '
        Me.BtnAddDocument.Image = CType(resources.GetObject("BtnAddDocument.Image"), System.Drawing.Image)
        Me.BtnAddDocument.Location = New System.Drawing.Point(413, 192)
        Me.BtnAddDocument.Name = "BtnAddDocument"
        Me.BtnAddDocument.Size = New System.Drawing.Size(61, 23)
        Me.BtnAddDocument.TabIndex = 107
        Me.BtnAddDocument.Text = "Add"
        '
        'BtnDelDocument
        '
        Me.BtnDelDocument.Image = CType(resources.GetObject("BtnDelDocument.Image"), System.Drawing.Image)
        Me.BtnDelDocument.Location = New System.Drawing.Point(340, 192)
        Me.BtnDelDocument.Name = "BtnDelDocument"
        Me.BtnDelDocument.Size = New System.Drawing.Size(67, 23)
        Me.BtnDelDocument.TabIndex = 108
        Me.BtnDelDocument.Text = "Delete"
        '
        'TxtDateUntil
        '
        Me.TxtDateUntil.EditValue = Nothing
        Me.TxtDateUntil.Location = New System.Drawing.Point(12, 166)
        Me.TxtDateUntil.Name = "TxtDateUntil"
        Me.TxtDateUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtDateUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtDateUntil.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.TxtDateUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TxtDateUntil.Size = New System.Drawing.Size(462, 20)
        Me.TxtDateUntil.TabIndex = 110
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(12, 147)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl4.TabIndex = 109
        Me.LabelControl4.Text = "Until"
        '
        'FormMasterEmployeeTraining
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(490, 459)
        Me.Controls.Add(Me.TxtDateUntil)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.BtnDelDocument)
        Me.Controls.Add(Me.BtnAddDocument)
        Me.Controls.Add(Me.GCDocument)
        Me.Controls.Add(Me.LabelDocument)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.TxtInstitution)
        Me.Controls.Add(Me.TxtDateFrom)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.TxtCourse)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterEmployeeTraining"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Training"
        CType(Me.TxtCourse.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.TxtDateFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDateFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtInstitution.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCDocument, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDocument, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDateUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDateUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtDateFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents GCDocument As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDocument As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelDocument As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtInstitution As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtCourse As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GCDescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnDelDocument As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAddDocument As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOption As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RICE As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents GCExt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TxtDateUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
End Class
