Public Class FormPurcItemDet
    Public id_item As String = "-1"

    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub

    Private Sub FormPurcItemDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_uom()
        load_item_type()
        load_cat()
        '
        If Not id_item = "-1" Then 'edit
            Dim query As String = "SELECT * FROM tb_item WHERE id_item='" & id_item & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TECode.Text = data.Rows(0)("id_item").ToString
            TEDesc.Text = data.Rows(0)("item_desc").ToString
            SLECat.EditValue = data.Rows(0)("id_item_cat").ToString
            SLEUOM.EditValue = data.Rows(0)("id_uom").ToString
            SLEItemType.EditValue = data.Rows(0)("id_item_type").ToString
            '
            load_price()
            load_doc()
            '
            XTPAttachment.PageVisible = True
            XTPPriceList.PageVisible = True
        Else
            TECode.Text = "[Auto Generate]"
            '
            XTPAttachment.PageVisible = False
            XTPPriceList.PageVisible = False
        End If
    End Sub

    Sub load_price()
        Dim query As String = "SELECT emp.`employee_name`,itp.`id_item`,itp.`create_date`,itp.`price` FROM `tb_item_price` itp
INNER JOIN tb_m_user usr ON usr.`id_user`=itp.`create_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
WHERE itp.`id_item`='" & id_item & "' ORDER BY itp.id_item_price DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPriceList.DataSource = data
        GVPriceList.BestFitColumns()
    End Sub

    Sub load_doc()
        Dim query As String = "SELECT doc.id_doc,doc.doc_desc,doc.datetime,'yes' as is_download,CONCAT(doc.id_doc,'_149_" & id_item & "',doc.ext) AS filename,emp.employee_name 
                               FROM tb_doc doc
                               LEFT JOIN tb_m_user usr ON usr.id_user=doc.id_user_upload
                               LEFT JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
                               WHERE report_mark_type='149' AND id_report='" & id_item & "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFileList.DataSource = data
        GVFileList.BestFitColumns()
    End Sub

    Sub load_uom()
        Dim query As String = "SELECT id_uom,uom FROM tb_m_uom WHERE is_active='1'"
        viewSearchLookupQuery(SLEUOM, query, "id_uom", "uom", "id_uom")
    End Sub

    Sub load_cat()
        Dim query As String = "SELECT cat.id_item_cat,cat.item_cat FROM `tb_item_cat` cat
INNER JOIN `tb_item_coa` coa ON cat.`id_item_cat`=coa.`id_item_cat`
WHERE coa.`is_request`='1' AND cat.is_active='1'
GROUP BY cat.`id_item_cat`"
        viewSearchLookupQuery(SLECat, query, "id_item_cat", "item_cat", "id_item_cat")
    End Sub

    Sub load_item_type()
        Dim query As String = "SELECT id_item_type,item_type FROM tb_lookup_purc_item_type WHERE is_active='1'"
        viewSearchLookupQuery(SLEItemType, query, "id_item_type", "item_type", "id_item_type")
    End Sub

    Private Sub FormPurcItemDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        If id_item = "-1" Then 'new
            Dim query As String = "INSERT INTO tb_item(item_desc,id_item_cat,id_item_type,id_uom,date_created,id_user_created,is_active) VALUES('" & TEDesc.Text & "','" & SLECat.EditValue.ToString & "','" & SLEItemType.EditValue.ToString & "','" & SLEUOM.EditValue.ToString & "',NOW(),'" & id_user & "','1'); SELECT LAST_INSERT_ID();"
            id_item = execute_query(query, 0, True, "", "", "", "")
            'insert price
            query = "INSERT INTO tb_item_price(id_item,create_by,create_date,price) VALUES('" & id_item & "','" & id_user & "',NOW(),0.00)"
            execute_non_query(query, True, "", "", "", "")

            FormPurcItem.load_item()
            FormPurcItem.GVItem.FocusedRowHandle = find_row(FormPurcItem.GVItem, "id_item", id_item)
            Close()
        Else 'edit
            Dim query As String = "UPDATE tb_item SET item_desc='" & TEDesc.Text & "',id_item_cat='" & SLECat.EditValue.ToString & "',id_item_type='" & SLEItemType.EditValue.ToString & "',id_uom='" & SLEUOM.EditValue.ToString & "',is_active='1',date_updated=NOW(),id_user_updated='" & id_user & "' WHERE id_item='" & id_item & "'"
            execute_non_query(query, True, "", "", "", "")
            FormPurcItem.load_item()
            FormPurcItem.GVItem.FocusedRowHandle = find_row(FormPurcItem.GVItem, "id_item", id_item)
            Close()
        End If
    End Sub

    Private Sub BUploadDoc_Click(sender As Object, e As EventArgs) Handles BUploadDoc.Click
        FormDocumentUploadDet.is_only_pdf = "1"
        FormDocumentUploadDet.id_report = id_item
        FormDocumentUploadDet.report_mark_type = "149"
        FormDocumentUploadDet.ShowDialog()
    End Sub

    Private Sub BAddPrice_Click(sender As Object, e As EventArgs) Handles BAddPrice.Click
        If TEPrice.EditValue = 0 Then
            warningCustom("Please input the price first")
        Else
            Dim query As String = "INSERT INTO tb_item_price(id_item,create_by,create_date,price) VALUES('" & id_item & "','" & id_user & "',NOW(),'" & decimalSQL(TEPrice.EditValue.ToString) & "'); UPDATE tb_item SET latest_price='" & decimalSQL(TEPrice.EditValue.ToString) & "',date_updated=NOW(),id_user_updated='" & id_user & "' WHERE id_item='" & id_item & "'; "
            execute_non_query(query, True, "", "", "", "")
            load_price()
        End If
    End Sub
    Private Sub GVFileList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVFileList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class