Public Class FormPurcItemDet
    Public id_item As String = "-1"
    Public is_view As String = "-1"

    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub

    Sub load_form()
        load_vendor_type()
        load_uom()
        load_item_type()
        load_purc_cat()
        load_cat()
        '
        If Not id_item = "-1" Then 'edit
            TEStatus.Visible = True
            LStatus.Visible = True

            Dim query As String = "SELECT it.*,icd.`id_vendor_type` FROM tb_item it
INNER JOIN tb_item_cat_detail icd ON icd.id_item_cat_detail=it.id_item_cat_detail 
WHERE it.id_item='" & id_item & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            If data.Rows(0)("is_active").ToString = "1" Then
                TEStatus.Text = "Active"
                BNonActive.Visible = True
            Else
                TEStatus.Text = "Not Active"
                BNonActive.Visible = False
            End If

            TECode.Text = data.Rows(0)("id_item").ToString
            TEDesc.Text = data.Rows(0)("item_desc").ToString

            SLEUOM.EditValue = data.Rows(0)("id_uom").ToString
            SLEItemType.EditValue = data.Rows(0)("id_item_type").ToString
            '
            SLEPurchaseCategory.EditValue = data.Rows(0)("id_item_cat_detail").ToString
            SLECat.EditValue = data.Rows(0)("id_item_cat").ToString
            SLEVendorType.EditValue = data.Rows(0)("id_vendor_type").ToString
            '
            load_price()
            load_doc()
            load_history()
            '
            XTPAttachment.PageVisible = True
            XTPPriceList.PageVisible = True
            XTPHistory.PageVisible = True

            'check if item already PR
            query = "SELECT * FROM tb_purc_req_det prd 
INNER JOIN tb_purc_req pr ON pr.id_purc_req=prd.id_purc_req
WHERE pr.id_report_status!=5"
            data = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                BSave.Visible = False
            Else
                BSave.Visible = True
            End If
            '
            If is_view = "1" Then
                XTCDetail.SelectedTabPageIndex = 1
                PCSetPrice.Visible = True
            End If
        Else
            TEStatus.Visible = False
            LStatus.Visible = False

            TECode.Text = "[Auto Generate]"
            '
            XTPAttachment.PageVisible = False
            XTPPriceList.PageVisible = False
            XTPHistory.PageVisible = False
            '
            SLEPurchaseCategory.EditValue = Nothing
        End If
    End Sub

    Private Sub FormPurcItemDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_form()
    End Sub

    Sub load_vendor_type()
        Dim query As String = "SELECT id_vendor_type,vendor_type FROM tb_vendor_type"
        viewSearchLookupQuery(SLEVendorType, query, "id_vendor_type", "vendor_type", "id_vendor_type")
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

    Sub load_purc_cat()
        Dim query As String = "SELECT icd.`id_item_cat_detail`,ic.`item_cat`,vt.`vendor_type`,icd.`item_cat_detail`,icd.id_item_cat,icd.id_vendor_type
FROM `tb_item_cat_detail` icd
INNER JOIN `tb_item_cat` ic ON ic.`id_item_cat`=icd.`id_item_cat`
INNER JOIN tb_vendor_type vt ON vt.`id_vendor_type`=icd.`id_vendor_type`
WHERE id_status='2'"
        viewSearchLookupQuery(SLEPurchaseCategory, query, "id_item_cat_detail", "item_cat_detail", "id_item_cat_detail")
    End Sub

    Sub load_item_type()
        Dim query As String = "SELECT id_item_type,item_type FROM tb_lookup_purc_item_type WHERE is_active='1'"
        viewSearchLookupQuery(SLEItemType, query, "id_item_type", "item_type", "id_item_type")
    End Sub

    Sub load_history()
        Dim query As String = "
            SELECT o.id_purc_order,o.purc_order_number,rd.item_detail, CONCAT(comp.comp_number, ' - ', comp.comp_name) AS vendor, DATE_FORMAT(o.date_created, '%d %M %Y') AS `date`, odet.qty, odet.value
            FROM tb_purc_order_det AS odet
            LEFT JOIN tb_purc_req_det rd ON rd.id_purc_req_det=odet.id_purc_req_det
            LEFT JOIN tb_purc_order AS o ON odet.id_purc_order = o.id_purc_order
            LEFT JOIN tb_m_comp_contact AS compc ON o.id_comp_contact = compc.id_comp_contact
            LEFT JOIN tb_m_comp AS comp ON compc.id_comp = comp.id_comp
            WHERE o.id_report_status <> 5 AND odet.id_item = " + id_item + "
        "

        GCHistory.DataSource = execute_query(query, -1, True, "", "", "", "")

        GVHistory.BestFitColumns()
    End Sub

    Private Sub FormPurcItemDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        If Not SLEPurchaseCategory.EditValue = Nothing Then
            If id_item = "-1" Then 'new
                Dim query As String = "INSERT INTO tb_item(item_desc,id_item_cat_detail,id_item_cat,id_item_type,id_uom,date_created,id_user_created,is_active) VALUES('" & TEDesc.Text & "','" & SLEPurchaseCategory.EditValue.ToString & "','" & SLECat.EditValue.ToString & "','" & SLEItemType.EditValue.ToString & "','" & SLEUOM.EditValue.ToString & "',NOW(),'" & id_user & "','1'); SELECT LAST_INSERT_ID();"
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

    Private Sub SLEPurchaseCategory_EditValueChanged(sender As Object, e As EventArgs) Handles SLEPurchaseCategory.EditValueChanged
        Try
            SLECat.EditValue = SLEPurchaseCategory.Properties.View.GetFocusedRowCellValue("id_item_cat").ToString
            SLEVendorType.EditValue = SLEPurchaseCategory.Properties.View.GetFocusedRowCellValue("id_vendor_type").ToString
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles BSetSameItemPrice.Click
        If GVPriceList.RowCount > 0 Then
            FormPurcOrderDet.set_price(id_item, Decimal.Parse(GVPriceList.GetFocusedRowCellValue("price").ToString))
            Close()
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BSetSameSpecPrice.Click
        If GVPriceList.RowCount > 0 Then
            FormPurcOrderDet.set_same_detail_price(Decimal.Parse(GVPriceList.GetFocusedRowCellValue("price").ToString))
            Close()
        End If
    End Sub

    Private Sub BNonActive_Click(sender As Object, e As EventArgs) Handles BNonActive.Click
        Dim query As String = "UPDATE tb_item SET is_active='2' WHERE id_item='" & id_item & "'"
        execute_non_query(query, True, "", "", "", "")
        infoCustom("Item non active")
        load_form()
        FormPurcItem.load_item()
    End Sub

    Private Sub VDItemList_Click(sender As Object, e As EventArgs) Handles VDItemList.Click
        If GVHistory.RowCount > 0 Then
            FormPurcOrderDet.id_po = GVHistory.GetFocusedRowCellValue("id_purc_order").ToString
            FormPurcOrderDet.is_view = "1"
            FormPurcOrderDet.ShowDialog()
        End If
    End Sub
End Class