﻿Public Class ClassPurcAsset
    Public Function queryMain(ByVal condition As String, ByVal order_type As String, ByVal find_accum_value As Boolean) As String
        If order_type = "1" Then
            order_type = "ASC "
        ElseIf order_type = "2" Then
            order_type = "DESC "
        End If

        If condition <> "-1" Then
            condition = condition
        Else
            condition = ""
        End If

        'find accum value
        Dim col_add As String = ""
        Dim query_add As String = ""
        If find_accum_value Then
            col_add = ",IFNULL(av.amount,0) AS `accum_value` "
            query_add = "LEFT JOIN (
                SELECT d.id_purc_rec_asset, SUM(d.amount) AS `amount` 
                FROM tb_purc_rec_asset_dep d
                GROUP BY d.id_purc_rec_asset
            ) av ON av.id_purc_rec_asset = a.id_purc_rec_asset "
        End If



        Dim query As String = "SELECT a.id_purc_rec_asset, a.id_item, a.id_purc_rec_det, r.id_purc_rec, r.purc_rec_number, 
        po.id_purc_order, po.purc_order_number,
        a.id_departement, d.departement, a.id_acc_fa, fa.acc_name AS `acc_fa`,fa.acc_description AS `acc_fa_name`, 
        a.asset_number, a.asset_name, a.asset_note, a.acq_date, 
        a.acq_cost, a.is_non_depresiasi, a.useful_life, 
        IFNULL(a.id_acc_dep,0) AS id_acc_dep, dep.acc_name AS `dep_acc`, dep.acc_description AS `dep_acc_name`,
        IFNULL(a.id_acc_dep_accum,0) AS id_acc_dep_accum,adep.acc_name AS `accum_dep_acc`, adep.acc_description AS `accum_dep_acc_name`, a.accum_dep, a.is_active, IFNULL(a.id_report_status,0) AS `id_report_status`, a.is_confirm
        " + col_add + "
        FROM tb_purc_rec_asset a
        INNER JOIN tb_purc_rec_det rd ON rd.id_purc_rec_det = a.id_purc_rec_det
        INNER JOIN tb_purc_rec r ON r.id_purc_rec = rd.id_purc_rec
        INNER JOIN tb_purc_order po ON po.id_purc_order = r.id_purc_order
        INNER JOIN tb_m_departement d ON d.id_departement = a.id_departement
        INNER JOIN tb_item i ON i.id_item = a.id_item
        INNER JOIN tb_item_cat cat ON cat.id_item_cat = i.id_item_cat
        INNER JOIN tb_a_acc fa ON fa.id_acc = a.id_acc_fa
        LEFT JOIN tb_a_acc dep ON dep.id_acc = a.id_acc_dep
        LEFT JOIN tb_a_acc adep ON adep.id_acc = a.id_acc_dep_accum
        " + query_add + "
        WHERE a.id_purc_rec_asset>0 "
        query += condition + " "
        query += "ORDER BY a.id_purc_rec_asset " + order_type
        Return query
    End Function


    Public Sub cancellPropose(ByVal id As String, ByVal id_purc_rec As String)
        If id_purc_rec = "-1" Then
            'asset non receive by sistem
            Dim query As String = "UPDATE tb_purc_rec_asset SET id_report_status=5 WHERE id_purc_rec='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", 160, id, "5")
            execute_non_query(queryrm, True, "", "", "", "")
        Else
            'asset  receive by sistem
            'delete report mark
            Dim query_del_rm As String = "DELETE FROM tb_report_mark WHERE report_mark_type=160 AND id_report=" + id + " "
            execute_non_query(query_del_rm, True, "", "", "", "")

            'update to unconfirm
            Dim query As String = "UPDATE tb_purc_rec_asset SET id_report_status=1,is_active=NULL, is_confirm='2' WHERE id_purc_rec_asset='" + id + "'"
            execute_non_query(query, True, "", "", "", "")
        End If
        FormPurcAssetDet.actionLoad()
    End Sub
End Class