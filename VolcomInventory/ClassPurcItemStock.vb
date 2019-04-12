Public Class ClassPurcItemStock
    Public Function queryGetStock(ByVal cond As String, ByVal date_until_selected As String) As String
        Dim query As String = "SELECT a.id_departement, dept.departement,a.id_item, im.item_desc, im.id_item_cat, cat.item_cat, SUM(a.qty) AS `qty`, 0 AS `qty_req`, IFNULL(cst.avg_cost,0) AS `value`, '' AS `remark`
        FROM (
	        SELECT i.id_departement,i.id_item,
	        SUM(IF(i.id_storage_category=2, CONCAT('-', i.storage_item_qty), i.storage_item_qty)) AS `qty`
	        FROM tb_storage_item i
	        WHERE DATE(i.storage_item_datetime)<='" + date_until_selected + "' " + cond + "
	        GROUP BY i.id_departement,i.id_item
        ) a 
        LEFT JOIN (
	        SELECT a.id_item, a.avg_cost 
	        FROM (
		        SELECT a.id_item, a.avg_cost 
		        FROM tb_item_avg_cost a
		        ORDER BY a.id_item_avg_cost DESC
	        ) a
	        GROUP BY a.id_item
        ) cst ON cst.id_item = a.id_item
        INNER JOIN tb_item im ON im.id_item = a.id_item
        INNER JOIN tb_item_cat cat ON cat.id_item_cat = im.id_item_cat
        INNER JOIN tb_m_departement dept ON dept.id_departement = a.id_departement
        GROUP BY a.id_item, a.id_departement HAVING qty>0 "
        Return query
    End Function
End Class
