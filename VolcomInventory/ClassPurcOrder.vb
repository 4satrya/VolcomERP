Public Class ClassPurcOrder
    Public Function queryMain(ByVal condition As String, ByVal order_type As String, is_for_receive As Boolean) As String
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

        Dim query As String = "SELECT po.id_purc_order, c.id_comp,c.comp_number,c.comp_name,cc.contact_person,cc.contact_number,po.purc_order_number,po.date_created,emp_cre.employee_name as emp_created,po.last_update,emp_upd.employee_name AS emp_updated 
        FROM tb_purc_order po
        INNER JOIN tb_m_user usr_cre ON usr_cre.id_user=po.created_by
        INNER JOIN tb_m_employee emp_cre ON emp_cre.id_employee=usr_cre.id_employee
        INNER JOIN tb_m_user usr_upd ON usr_upd.id_user=po.last_update_by
        INNER JOIN tb_m_employee emp_upd ON emp_upd.id_employee=usr_upd.id_employee
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=po.id_comp_contact
        INNER JOIN tb_m_comp c ON c.id_comp=cc.id_comp "
        If is_for_receive Then
            query += "LEFT JOIN (
	            SELECT po.id_purc_order, po.purc_order_number, SUM(pod.qty-IFNULL(rd.qty,0)+IFNULL(retd.qty,0)) AS `qty_remaining`
	            FROM tb_purc_order_det pod
	            INNER JOIN tb_purc_order po ON po.id_purc_order = pod.id_purc_order
	            LEFT JOIN (
		            SELECT rd.id_purc_order_det, SUM(rd.qty) AS `qty` 
		            FROM tb_purc_rec_det rd
		            INNER JOIN tb_purc_rec r ON r.id_purc_rec = rd.id_purc_rec
		            INNER JOIN tb_purc_order po ON po.id_purc_order = r.id_purc_order
		            WHERE po.id_report_status=6 AND r.id_report_status!=5
		            GROUP BY rd.id_purc_order_det
	            ) rd ON rd.id_purc_order_det = pod.id_purc_order_det
	            LEFT JOIN (
		            SELECT retd.id_purc_order_det, SUM(retd.qty) AS `qty`
		            FROM tb_purc_return_det retd
		            INNER JOIN tb_purc_return ret ON ret.id_purc_return = retd.id_purc_return
		            INNER JOIN tb_purc_order po ON po.id_purc_order = ret.id_purc_order
		            WHERE  po.id_report_status=6  AND ret.id_report_status=6
		            GROUP BY retd.id_purc_order_det
	            ) retd ON  retd.id_purc_order_det =  pod.id_purc_order_det
	            WHERE po.id_report_status=6
	            GROUP BY po.id_purc_order 
	            HAVING qty_remaining>0
            ) rmg ON rmg.id_purc_order = po.id_purc_order "
        End If
        query += "WHERE po.id_purc_order>0 "
        query += condition + " "
        If is_for_receive Then
            query += "AND !ISNULL(rmg.id_purc_order) "
        End If
        query += "ORDER BY po.id_purc_order " + order_type
        Return query
    End Function

    Public Function queryOrderDetails(ByVal id_purc_order As String, ByVal condition As String)
        Dim query = "SELECT pod.id_purc_order_det,req.purc_req_number,d.departement, pod.id_item, i.item_desc, i.id_uom, u.uom, pod.`value`, 
        reqd.qty AS `qty_req`, pod.qty AS `qty_order`, IFNULL(rd.qty,0) AS `qty_rec`, IFNULL(retd.qty,0) AS `qty_ret`, (pod.qty-IFNULL(rd.qty,0)+IFNULL(retd.qty,0)) AS `qty_remaining`, 0 AS `qty`
        FROM tb_purc_order_det pod
        LEFT JOIN (
          SELECT rd.id_purc_order_det, SUM(rd.qty) AS `qty` 
          FROM tb_purc_rec_det rd
          INNER JOIN tb_purc_rec r ON r.id_purc_rec = rd.id_purc_rec
          WHERE r.id_purc_order=" + id_purc_order + " AND r.id_report_status!=5 
          GROUP BY rd.id_purc_order_det
        ) rd ON rd.id_purc_order_det = pod.id_purc_order_det
        LEFT JOIN (
	        SELECT retd.id_purc_order_det, SUM(retd.qty) AS `qty`
	        FROM tb_purc_return_det retd
	        INNER JOIN tb_purc_return ret ON ret.id_purc_return = retd.id_purc_return
	        WHERE ret.id_purc_order=" + id_purc_order + " AND ret.id_report_status=6
	        GROUP BY retd.id_purc_order_det
        ) retd ON  retd.id_purc_order_det =  pod.id_purc_order_det
        INNER JOIN tb_item i ON i.id_item = pod.id_item
        INNER JOIN tb_m_uom u ON u.id_uom = i.id_uom
        INNER JOIN tb_purc_req_det reqd ON reqd.id_purc_req_det = pod.id_purc_req_det
        INNER JOIN tb_purc_req req ON req.id_purc_req = reqd.id_purc_req
        INNER JOIN tb_m_departement d ON d.id_departement = req.id_departement
        WHERE pod.id_purc_order=" + id_purc_order + "
        " + condition + "
        ORDER BY req.id_purc_req ASC "
        Return query
    End Function
End Class