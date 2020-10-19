Public Class FormLetterOfStatement
    Private Sub FormLetterOfStatement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()
    End Sub

    Private Sub FormLetterOfStatement_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("1", "0", "1")
    End Sub

    Private Sub FormLetterOfStatement_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormLetterOfStatement_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub form_load()
        Dim query As String = "
            SELECT p.popup, IF(p.id_letter_of_statement_popup = 6, s.employee_name, e.employee_name) AS employee_name, s.number, s.date, s.id_letter_of_statement
            FROM tb_letter_of_statement AS s
            LEFT JOIN tb_letter_of_statement_popup AS p ON s.id_popup = p.id_letter_of_statement_popup
            LEFT JOIN tb_m_employee AS e ON s.id_employee = e.id_employee
            ORDER BY s.created_date DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCLetterOfStatement.DataSource = data

        GVLetterOfStatement.BestFitColumns()
    End Sub

    Sub form_print(ByVal id_letter_of_statement As String)
        Dim query As String = "
            SELECT s.id_letter_of_statement, s.id_popup, p.popup, s.number, s.date, s.id_employee, IF(s.id_popup = 6, s.employee_name, e.employee_name) AS employee_name, IF(s.id_popup = 6, NULL, e.employee_code) AS employee_code, IF(s.id_popup = 6, s.address_primary, e.address_primary) AS address_primary, IF(s.id_popup = 6, NULL, e.employee_pob) AS employee_pob, e.employee_dob, IF(s.id_popup = 6, s.employee_position, e.employee_position) AS employee_position, IF(s.id_popup = 6, s.id_departement, e.id_departement) AS id_departement, IF(s.id_popup = 6, r.departement, d.departement) AS departement, s.id_departement_sub, t.departement_sub, s.created_date, IF(s.id_popup = 6, NULL, e.employee_actual_join_date) AS employee_actual_join_date, IF(s.id_popup = 6, NULL, e.employee_last_date) AS employee_last_date, IF(s.id_popup = 6, NULL, e.id_sex) AS id_sex, s.address_primary, IF(s.id_popup = 6, r.is_store, d.is_store) AS is_store, IF(s.id_popup = 6, s.start_period, NULL) AS start_period, IF(s.id_popup = 6, s.end_period, NULL) AS end_period, IF(s.id_popup = 6, FLOOR((TIMESTAMPDIFF(DAY, s.start_period, s.end_period)) / 30), NULL) AS contract_length, ROUND(s.basic_salary) AS basic_salary, ROUND(s.allow_job) AS allow_job, ROUND(s.allow_meal) AS allow_meal, ROUND(s.allow_trans) AS allow_trans, ROUND(s.allow_house) AS allow_house, ROUND(s.allow_car) AS allow_car, ROUND((s.basic_salary + s.allow_job + s.allow_meal + s.allow_trans + s.allow_house + s.allow_car)) AS total_salary
            FROM tb_letter_of_statement AS s
            LEFT JOIN tb_letter_of_statement_popup AS p ON s.id_popup = p.id_letter_of_statement_popup
            LEFT JOIN tb_m_employee AS e ON s.id_employee = e.id_employee
            LEFT JOIN tb_m_departement AS d ON e.id_departement = d.id_departement
            LEFT JOIN tb_m_departement AS r ON s.id_departement = r.id_departement
            LEFT JOIN tb_m_departement_sub AS t ON s.id_departement_sub = t.id_departement_sub
            WHERE s.id_letter_of_statement = " + id_letter_of_statement + "
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        Dim director As DataTable = execute_query("
            SELECT tb_m_employee.id_employee, tb_m_employee.employee_name, tb_m_employee.employee_position
            FROM tb_m_employee 
            WHERE tb_m_employee.id_employee = (SELECT id_emp_director FROM tb_opt LIMIT 1)
        ", -1, True, "", "", "", "")

        Dim hrd_manager As DataTable = execute_query("
            SELECT tb_m_user.id_employee, tb_m_employee.employee_name, tb_m_employee.employee_position
            FROM tb_m_departement 
            LEFT JOIN tb_m_user ON tb_m_departement.id_user_head = tb_m_user.id_user 
            LEFT JOIN tb_m_employee ON tb_m_user.id_employee = tb_m_employee.id_employee
            WHERE tb_m_departement.id_departement = 8
        ", -1, True, "", "", "", "")

        If data.Rows(0)("id_popup").ToString = "1" Then
            Dim Report As New ReportMasterEmployeeSuratKeteranganPenangguhanBank()

            Report.XLNumber.Text = Report.XLNumber.Text.Replace("[number]", data.Rows(0)("number").ToString)

            If data.Rows(0)("id_employee").ToString = hrd_manager.Rows(0)("id_employee").ToString Then
                Report.L_hrd_employee_name1.Text = director.Rows(0)("employee_name").ToString
                Report.L_hrd_employee_position1.Text = director.Rows(0)("employee_position").ToString

                Report.L_hrd_employee_name2.Text = director.Rows(0)("employee_name").ToString
                Report.L_hrd_employee_position2.Text = director.Rows(0)("employee_position").ToString
            Else
                Report.L_hrd_employee_name1.Text = hrd_manager.Rows(0)("employee_name").ToString
                Report.L_hrd_employee_position1.Text = hrd_manager.Rows(0)("employee_position").ToString

                Report.L_hrd_employee_name2.Text = hrd_manager.Rows(0)("employee_name").ToString
                Report.L_hrd_employee_position2.Text = hrd_manager.Rows(0)("employee_position").ToString
            End If
            Report.L_employee_name.Text = data.Rows(0)("employee_name").ToString
            Report.L_employee_code.Text = data.Rows(0)("employee_code").ToString
            Report.L_address_primary.Text = data.Rows(0)("address_primary").ToString
            Report.L_date.Text = "Kuta, " + Date.Parse(data.Rows(0)("created_date").ToString).ToString("dd MMMM yyyy")

            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
        ElseIf data.Rows(0)("id_popup").ToString = "2" Then
            Dim depthead As String = execute_query("
                SELECT e_dh.employee_name
                FROM tb_m_employee AS e
                LEFT JOIN tb_m_departement AS d ON e.id_departement = d.id_departement
                LEFT JOIN tb_m_user AS u_dh ON d.id_user_head = u_dh.id_user
                LEFT JOIN tb_m_employee AS e_dh ON u_dh.id_employee = e_dh.id_employee
                WHERE e.id_employee = " + data.Rows(0)("id_employee").ToString + "
            ", 0, True, "", "", "", "")

            Dim Report As New ReportMasterEmployeeSuratKeputusanDirumahkan()

            Report.XLNumber.Text = Report.XLNumber.Text.Replace("[number]", data.Rows(0)("number").ToString)

            Report.L_employee_name.Text = data.Rows(0)("employee_name").ToString
            Report.L_employee_code.Text = data.Rows(0)("employee_code").ToString
            Report.L_address_primary.Text = data.Rows(0)("address_primary").ToString
            Report.L_employee_pob_dob.Text = data.Rows(0)("employee_pob").ToString + ", " + Date.Parse(data.Rows(0)("employee_dob").ToString).ToString("dd MMMM yyyy")
            Report.L_date.Text = "Kuta, " + Date.Parse(data.Rows(0)("created_date").ToString).ToString("dd MMMM yyyy")
            Report.L_text.Text = Report.L_text.Text.Replace("[date]", Date.Parse(data.Rows(0)("date").ToString).ToString("dd MMMM yyyy"))
            Report.L_depthead.Text = depthead
            Report.L_hrd_employee_name2.Text = hrd_manager.Rows(0)("employee_name").ToString
            Report.L_hrd_employee_position2.Text = hrd_manager.Rows(0)("employee_position").ToString

            If data.Rows(0)("id_departement").ToString = "8" Then
                Report.XrLabel6.Visible = False
                Report.L_depthead.Visible = False
                Report.XrLabel17.Visible = False
            End If

            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
        ElseIf data.Rows(0)("id_popup").ToString = "3" Then
            Dim Report As New ReportMasterEmployeeSuratTugas()

            Report.XLNumber.Text = Report.XLNumber.Text.Replace("[number]", data.Rows(0)("number").ToString)

            If data.Rows(0)("id_employee").ToString = hrd_manager.Rows(0)("id_employee").ToString Then
                Report.L_hrd_employee_name2.Text = director.Rows(0)("employee_name").ToString
                Report.L_hrd_employee_position2.Text = director.Rows(0)("employee_position").ToString
            Else
                Report.L_hrd_employee_name2.Text = hrd_manager.Rows(0)("employee_name").ToString
                Report.L_hrd_employee_position2.Text = hrd_manager.Rows(0)("employee_position").ToString
            End If

            Report.L_employee_name.Text = data.Rows(0)("employee_name").ToString
            Report.L_employee_code.Text = data.Rows(0)("employee_code").ToString
            Report.L_employee_position.Text = data.Rows(0)("employee_position").ToString
            Report.L_departement.Text = data.Rows(0)("departement").ToString
            Report.L_date.Text = "Kuta, " + Date.Parse(data.Rows(0)("created_date").ToString).ToString("dd MMMM yyyy")

            Dim depthead As String = execute_query("
                SELECT e_dh.id_employee
                FROM tb_m_employee AS e
                LEFT JOIN tb_m_departement AS d ON e.id_departement = d.id_departement
                LEFT JOIN tb_m_user AS u_dh ON d.id_user_head = u_dh.id_user
                LEFT JOIN tb_m_employee AS e_dh ON u_dh.id_employee = e_dh.id_employee
                WHERE e.id_employee = " + data.Rows(0)("id_employee").ToString + "
            ", 0, True, "", "", "", "")

            If depthead = data.Rows(0)("id_employee").ToString Then
                Report.L_cc.Text = "
cc.
- Direktur
- HRD 
                "
            Else
                Report.L_cc.Text = "
cc.
- Direktur
- Departemen Head terkait
- HRD 
                "
            End If

            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
        ElseIf data.Rows(0)("id_popup").ToString = "4" Then
            Dim Report As New ReportMasterEmployeeSuratKeteranganBansos()

            Report.XLNumber.Text = Report.XLNumber.Text.Replace("[number]", data.Rows(0)("number").ToString)

            Report.L_employee_name.Text = data.Rows(0)("employee_name").ToString
            Report.L_employee_code.Text = data.Rows(0)("employee_code").ToString
            Report.L_address_primary.Text = data.Rows(0)("address_primary").ToString
            Report.L_employee_pob_dob.Text = data.Rows(0)("employee_pob").ToString + ", " + Date.Parse(data.Rows(0)("employee_dob").ToString).ToString("dd MMMM yyyy")
            Report.L_date.Text = "Kuta, " + Date.Parse(data.Rows(0)("created_date").ToString).ToString("dd MMMM yyyy")
            Report.L_text.Text = Report.L_text.Text.Replace("[date]", Date.Parse(data.Rows(0)("date").ToString).ToString("dd MMMM yyyy"))
            If data.Rows(0)("id_employee").ToString = hrd_manager.Rows(0)("id_employee").ToString Then
                Report.L_hrd_employee_name2.Text = director.Rows(0)("employee_name").ToString
                Report.L_hrd_employee_position2.Text = director.Rows(0)("employee_position").ToString
            Else
                Report.L_hrd_employee_name2.Text = hrd_manager.Rows(0)("employee_name").ToString
                Report.L_hrd_employee_position2.Text = hrd_manager.Rows(0)("employee_position").ToString
            End If

            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
        ElseIf data.Rows(0)("id_popup").ToString = "5" Then
            Dim Report As New ReportMasterEmployeeSuratReferensi()

            Report.XLNumber.Text = Report.XLNumber.Text.Replace("[number]", data.Rows(0)("number").ToString)

            Report.L_text.Html = "
                <p style=""font-family: Calibri; text-align: justify;"">Has been employed by PT. Volcom Indonesia from " + Date.Parse(data.Rows(0)("employee_actual_join_date").ToString).ToString("MMMM d, yyyy") + " to " + Date.Parse(data.Rows(0)("employee_last_date").ToString).ToString("MMMM d, yyyy") + " with last function as <b>" + data.Rows(0)("employee_position").ToString + "</b>.</p>
                <p style=""font-family: Calibri; text-align: justify;"">During the time we find " + If(data.Rows(0)("id_sex").ToString = "1", "him", "her") + " to be loyal, diligent and responsible to " + If(data.Rows(0)("id_sex").ToString = "1", "his", "her") + " duties and capable in coordination with the others.</p>
                <p style=""font-family: Calibri; text-align: justify;"">We would like to express our thanks for the services rendered to PT. Volcom Indonesia and have no hesitation in recommending " + If(data.Rows(0)("id_sex").ToString = "1", "him", "her") + " for any job opportunity " + If(data.Rows(0)("id_sex").ToString = "1", "he", "she") + " may apply for. We hope " + If(data.Rows(0)("id_sex").ToString = "1", "he", "she") + " will reach success in the field that " + If(data.Rows(0)("id_sex").ToString = "1", "he", "she") + " takes in the future.</p>
            "

            If data.Rows(0)("id_employee").ToString = hrd_manager.Rows(0)("id_employee").ToString Then
                Report.L_hrd_employee_name2.Text = director.Rows(0)("employee_name").ToString
                Report.L_hrd_employee_position2.Text = director.Rows(0)("employee_position").ToString
            Else
                Report.L_hrd_employee_name2.Text = hrd_manager.Rows(0)("employee_name").ToString
                Report.L_hrd_employee_position2.Text = hrd_manager.Rows(0)("employee_position").ToString
            End If

            Report.L_employee_name.Text = data.Rows(0)("employee_name").ToString
            Report.L_address_primary.Text = data.Rows(0)("address_primary").ToString
            Report.L_date.Text = Date.Parse(data.Rows(0)("created_date").ToString).ToString("MMMM d, yyyy")

            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
        ElseIf data.Rows(0)("id_popup").ToString = "6" Then
            Dim Report As New ReportMasterEmployeeSuratPerjanjianKerja()

            Report.XLabelDate.Text = "Kuta, " + Date.Parse(data.Rows(0)("created_date").ToString).ToString("dd MMMM yyyy")

            Report.XLNumber.Text = Report.XLNumber.Text.Replace("[number]", data.Rows(0)("number").ToString)

            Report.L_hrd_employee_name2.Text = hrd_manager.Rows(0)("employee_name").ToString
            Report.L_hrd_employee_position2.Text = hrd_manager.Rows(0)("employee_position").ToString

            Report.L_employee_name.Text = data.Rows(0)("employee_name").ToString
            Report.L_employee_position.Text = data.Rows(0)("employee_position").ToString

            Dim t_basic_salary As String = If(data.Rows(0)("basic_salary") > 0, "Gaji pokok Rp. " + Format(data.Rows(0)("basic_salary"), "##,##0") + ",-, ", "")
            Dim t_allow_job As String = If(data.Rows(0)("allow_job") > 0, "Tunjangan jabatan Rp. " + Format(data.Rows(0)("allow_job"), "##,##0") + ",-, ", "")
            Dim t_allow_meal As String = If(data.Rows(0)("allow_meal") > 0, "Uang makan Rp. " + Format(data.Rows(0)("allow_meal"), "##,##0") + ",-, ", "")
            Dim t_allow_trans As String = If(data.Rows(0)("allow_trans") > 0, "Uang transport Rp. " + Format(data.Rows(0)("allow_trans"), "##,##0") + ",-, ", "")
            Dim t_allow_house As String = If(data.Rows(0)("allow_house") > 0, "Uang perumahan Rp. " + Format(data.Rows(0)("allow_house"), "##,##0") + ",-, ", "")
            Dim t_allow_car As String = If(data.Rows(0)("allow_car") > 0, "Uang kehadiran Rp. " + Format(data.Rows(0)("allow_car"), "##,##0") + ",-", "")

            Dim length_contract As String = ""

            If data.Rows(0)("contract_length") < 12 Then
                length_contract = data.Rows(0)("contract_length").ToString + " (" + execute_query("SELECT `string` FROM tb_lookup_number_to_string WHERE `number` = " + data.Rows(0)("contract_length").ToString, 0, True, "", "", "", "") + ") bulan"
            Else
                Dim yr As String = Math.Round(data.Rows(0)("contract_length") / 12, 0).ToString
                Dim mr As String = (data.Rows(0)("contract_length") Mod 12).ToString

                length_contract = yr + " (" + execute_query("SELECT `string` FROM tb_lookup_number_to_string WHERE `number` = " + yr, 0, True, "", "", "", "") + ") tahun"

                If mr > 0 Then
                    length_contract += " " + mr + " (" + execute_query("SELECT `string` FROM tb_lookup_number_to_string WHERE `number` = " + mr, 0, True, "", "", "", "") + ") bulan"
                End If
            End If

            Report.XrRichText.Html = "
                <ul style=""list-style-type: upper-roman;"">
                    <li>
                        <p style=""margin: 0; font-family: 'Times New Roman'; font-size: 12pt; text-align: justify;"">Yang bertanda tangan dibawah ini</p>
                        <ul style=""list-style-type: decimal;"">
                            <li>
                                <p style=""margin: 0; font-family: 'Times New Roman'; font-size: 12pt; text-align: justify;""><b>" + hrd_manager.Rows(0)("employee_name").ToString + "</b>, " + hrd_manager.Rows(0)("employee_position").ToString + " bertindak mewakili Direktur  dan atas nama PT. Volcom Indonesia, yang beralamat di Jl. Banjar Segara 18 V Tuban-Kuta, selanjutnya disebut pihak Perusahaan.</p>
                            </li>
                            <li>
                                <p style=""margin: 0; font-family: 'Times New Roman'; font-size: 12pt; text-align: justify;""><b>" + data.Rows(0)("employee_name").ToString + "</b>, dengan alamat " + data.Rows(0)("address_primary").ToString + ", dalam hal ini bertindak untuk dirinya sendiri, selanjutnya disebut pihak Karyawan.</p>
                            </li>
                        </ul>
                    </li>
                    <li>
                        <p style=""margin: 0;"">Kedua belah pihak setuju dan sepakat untuk mengadakan hubungan kerja berdasarkan ketentuan di bawah ini :</p>
                    </li>
                </ul>
                <p style=""font-family: 'Times New Roman'; font-size: 13pt; text-align: center;""><b>Pasal 1 – Maksud Perjanjian</b></p>
                <ul style=""list-style-type: decimal;"">
                    <li><p style=""margin: 0; font-family: 'Times New Roman'; font-size: 12pt; text-align: justify;"">Perjanjian ini adalah Perjanjian Kerja untuk Waktu Tertentu dimana Perusahaan menerima Karyawan bekerja pada Perusahaan sebagai karyawan dengan jabatan / posisi <b>" + data.Rows(0)("employee_position").ToString + "</b> pada " + If(data.Rows(0)("id_departement").ToString = "17", data.Rows(0)("departement_sub").ToString, data.Rows(0)("departement").ToString) + ".</p></li>
                    <li><p style=""margin: 0; font-family: 'Times New Roman'; font-size: 12pt; text-align: justify;"">Karyawan bersedia dan sanggup melaksanakan pekerjaan serta wajib mentaati semua perintah yang diberikan oleh Perusahaan, termasuk Peraturan Perusahaan dan Tata Tertib yang berlaku di lingkungan kerjanya dan tidak akan melakukan tuntutan di kemudian hari.</p></li>
                    <li><p style=""margin: 0; font-family: 'Times New Roman'; font-size: 12pt; text-align: justify;"">Karyawan tidak diperkenankan menerima uang dan / atau imbalan apapun dari pihak lain yang diberikan karena fungsi jabatan karyawan.</p></li>
                    <li><p style=""margin: 0; font-family: 'Times New Roman'; font-size: 12pt; text-align: justify;"">Perusahaan berhak untuk menetapkan tempat / lokasi kerja karyawan dan karyawan bersedia untuk setiap saat dimutasikan dan / atau diubah / diadakan perputaran tempat / lokasi atas perintah Perusahaan.</p></li>
                    <li>Karyawan bersedia menjaga kerahasiaan yang berhubungan dengan segala kegiatan dan keputusan Perusahaan.</li>
                    <li><p style=""margin: 0; font-family: 'Times New Roman'; font-size: 12pt; text-align: justify;"">Karyawan tidak diperkenankan melakukan hubungan kerja dengan pihak ketiga selama perjanjian ini berlangsung.</p></li>
                    <li><p style=""margin: 0; font-family: 'Times New Roman'; font-size: 12pt; text-align: justify;"">Perusahaan berhak mengambil tindakan sepihak atas pelanggaran yang dilakukan oleh karyawan terhadap pasal 1 ayat 3, 4 dan 5 perjanjian ini.</p></li>
                </ul>
                
                
            "

            Report.XrRichText1.Html = "
                <p style=""font-family: 'Times New Roman'; font-size: 13pt; text-align: center;""><b>Pasal 2 – Waktu Kerja</b></p>
                <ul style=""list-style-type: decimal;"">
                    <li><p style=""margin: 0; font-family: 'Times New Roman'; font-size: 12pt; text-align: justify;"">Karyawan wajib memenuhi waktu kerja yang telah ditetapkan dalam peraturan Perusahaan yaitu selama " + If(data.Rows(0)("is_store").ToString = "2", "8 (delapan) jam", "7 (tujuh) jam") + " sehari atau 40 (empat puluh) jam seminggu berturut-turut.</p></li>
                    <li><p style=""margin: 0; font-family: 'Times New Roman'; font-size: 12pt; text-align: justify;"">Apabila diperlukan, Karyawan wajib melaksanakan pekerjaan diluar pekerjaan diluar jam kerja dengan tunduk pada peraturan / ketentuan / hukum yang berlaku di Indonesia.</p></li>
                </ul>
                <p style=""font-family: 'Times New Roman'; font-size: 13pt; text-align: center;""><b>Pasal 3 – Imbalan Gaji</b></p>
                <p style=""margin: 0; font-family: 'Times New Roman'; font-size: 12pt; text-align: justify;"">Perusahaan wajib memberikan dan karyawan berhak memperoleh gaji dengan total pendapatan akhir sebesar <b>Rp. " + Format(data.Rows(0)("total_salary"), "##,##0") + ",-</b> per bulan/month (net take home pay), dengan perincian " + t_basic_salary + t_allow_job + t_allow_meal + t_allow_trans + t_allow_house + t_allow_car + " serta BPJS Ketenagakerjaan & BPJS Kesehatan setiap bulan dan Tunjangan Hari Raya (THR) pada saat jatuh temponya hari raya dimaksud.</p>
                <p style=""font-family: 'Times New Roman'; font-size: 13pt; text-align: center;""><b>Pasal 4 – Pemutusan Hubungan Kerja</b></p>
                <p style=""margin: 0; font-family: 'Times New Roman'; font-size: 12pt; text-align: justify;"">Perusahaan berhak memutuskan hubungan kerja sewaktu-waktu bila karyawan terbukti :</p>
                <ul style=""list-style-type: decimal;"">
                    <li><p style=""margin: 0; font-family: 'Times New Roman'; font-size: 12pt; text-align: justify;"">Pada saat perjanjian ini diadakan, memberikan keterangan palsu atau yang dipalsukan.</p></li>
                    <li><p style=""margin: 0; font-family: 'Times New Roman'; font-size: 12pt; text-align: justify;"">Mabuk, madat, judi, memakai dan atau memperjual belikan obat bius atau narkotika di tempat kerja.</p></li>
                    <li><p style=""margin: 0; font-family: 'Times New Roman'; font-size: 12pt; text-align: justify;"">Melakukan perbuatan asusila di tempat kerja.</p></li>
                    <li><p style=""margin: 0; font-family: 'Times New Roman'; font-size: 12pt; text-align: justify;"">Melakukan tindakan kejahatan, misalnya : mencuri, menggelapkan, menipu, memperdagangkan barang terlarang baik didalam maupun diluar lingkungan Perusahaan.</p></li>
                    <li><p style=""margin: 0; font-family: 'Times New Roman'; font-size: 12pt; text-align: justify;"">Menganiaya, berkelahi, menghina secara kasar, memfitnah rekan kerja dan / atau teman sekerja karyawan lainnya.</p></li>
                    <li><p style=""margin: 0; font-family: 'Times New Roman'; font-size: 12pt; text-align: justify;"">Membujuk managemen dan / teman sekerja untuk melaksanakan sesuatu yang bertentangan dengan hukum atau kesusilaan.</p></li>
                    <li><p style=""margin: 0; font-family: 'Times New Roman'; font-size: 12pt; text-align: justify;"">Dengan sengaja atau ceroboh merusak, menghilangkan asset perusahaan, merugikan atau membiarkannya dalam keadaan bahaya milik Perusahaan.</p></li>
                    <li><p style=""margin: 0; font-family: 'Times New Roman'; font-size: 12pt; text-align: justify;"">Membongkar rahasia Perusahaan atau rahasia rumah tangga manageman.</p></li>
                    <li><p style=""margin: 0; font-family: 'Times New Roman'; font-size: 12pt; text-align: justify;"">Melakukan kesalahan yang bobotnya sama setelah mendapatkan peringatan terakhir yang masih berlaku.</p></li>
                    <li><p style=""margin: 0; font-family: 'Times New Roman'; font-size: 12pt; text-align: justify;"">Melawan perintah atasan yang layak dan wajar serta tidak menyelesaikan tugas yang diberikan atasan sesuai dengan waktu yang telah ditetapkan.</p></li>
                    <li><p style=""margin: 0; font-family: 'Times New Roman'; font-size: 12pt; text-align: justify;"">Dalam waktu lima (5) hari berturut-turut  tidak masuk kerja dan telah dipanggil 2X secara tertulis tetapi tidak dapat memberikan keterangan tertulis dengan bukti yang syah.</p></li>
                    <li><p style=""margin: 0; font-family: 'Times New Roman'; font-size: 12pt; text-align: justify;"">Melanggar hal-hal yang diatur dalam perjanjian ini dan / atau Peraturan Perusahaan.</p></li>
                    <li><p style=""margin: 0; font-family: 'Times New Roman'; font-size: 12pt; text-align: justify;"">Karyawan bersedia mengundurkan diri secara sukarela jika terbukti melanggar pasal 4 ayat 12.</p></li>
                </ul>
            "

            Report.XrRichText2.Html = "
                <p style=""font-family: 'Times New Roman'; font-size: 13pt; text-align: center;""><b>Pasal 5 – Jangka Waktu Perjanjian Kerja</b></p>
                <ul style=""list-style-type: decimal;"">
                    <li><p style=""margin: 0; font-family: 'Times New Roman'; font-size: 12pt; text-align: justify;"">Perjanjian ini berlaku untuk masa selama <b>" + length_contract + "</b>, terhitung tanggal <b>" + Date.Parse(data.Rows(0)("start_period").ToString).ToString("dd MMMM yyyy") + " sampai dengan tanggal " + Date.Parse(data.Rows(0)("end_period").ToString).ToString("dd MMMM yyyy") + "</b>.</p></li>
                    <li><p style=""margin: 0; font-family: 'Times New Roman'; font-size: 12pt; text-align: justify;"">Karyawan tidak diperkenankan memutuskan kontrak selama masa kontrak kerja belum berakhir dan apabila memutuskan kontrak sebelum masa kontrak habis, maka karyawan harus membayar ganti rugi tunggakan/sisa kontrak yang masih berjalan</p></li>
                    <li><p style=""margin: 0; font-family: 'Times New Roman'; font-size: 12pt; text-align: justify;"">Karyawan wajib memberitahukan kepada Perusahaan secara tertulis 1 (satu) bulan sebelumnya jika Karyawan memutuskan hubungan kerja.</p></li>
                    <li><p style=""margin: 0; font-family: 'Times New Roman'; font-size: 12pt; text-align: justify;"">Dengan berakhirnya masa kerja yang telah disepakati bersama Perusahaan tidak memberikan Uang Pesangon dan Uang Penghargaan sesuai dengan Undang-Undang No. 13 Tahun 2003.</p></li>
                </ul>
                <p style=""font-family: 'Times New Roman'; font-size: 13pt; text-align: center;""><b>Pasal 6 – Lain-lain</b></p>
                <p style=""margin: 0; font-family: 'Times New Roman'; font-size: 12pt; text-align: justify;"">Perjanjian ini dibuat dalam rangkap dua (2) dan ditandatangani oleh kedua belah pihak serta masing-masing mempunyai kekuatan hukum yang sama dan setiap perubahan / penambahan terhadap ketentuan Perjanjian ini harus dilakukan secara tertulis dan disepakati oleh kedua belah pihak.</p>
            "

            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
        End If
    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
        form_print(GVLetterOfStatement.GetFocusedRowCellValue("id_letter_of_statement").ToString)
    End Sub
End Class