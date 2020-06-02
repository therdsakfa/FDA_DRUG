<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_RESEARCH_SUM_DL.aspx.vb" Inherits="FDA_DRUG.POPUP_RESEARCH_SUM_DL" %>

<%@ Register Src="~/UC/UC_ATTACH_DRUG.ascx" TagPrefix="uc1" TagName="UC_ATTACH_DRUG" %>


<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            border-collapse: collapse;
            width: 79%;
            max-width: 100%;
            margin-bottom: 20px;
        }
        .auto-style3 {
            height: 20px;
        }

        #pj_sum {
            /*font-family: "Trebuchet MS", Arial, Helvetica, sans-serif;*/
            border-collapse: collapse;
            width: 100%;
        }

        #pj_sum td, #pj_sum th {
            border: 1px solid #ddd;
            padding: 8px;
        }

        #pj_sum tr:nth-child(even){background-color: #f2f2f2;}

        #pj_sum th {
            padding-top: 12px;
            padding-bottom: 12px;
            text-align: left;
            /*background-color: #4CAF50;*/
            /*color: white;*/
        }
        .con{
            width:200px;
            height:auto;
            border : 1px solid black;
            padding:5px;
            text-align:center;
            right:0;
            position:absolute;
            margin-top:-20px;
        }
    </style>
    <link href="../../../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../../../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../../../Scripts/jquery-1.8.2.js"></script>
    <script src="../../../Jsdate/ui.datepicker.js"></script>
    <script src="../../../Jsdate/ui.datepicker-th.js"></script>
    <script type="text/javascript">
        //function showdate(targetobject) {
        //    $(targetobject).datepicker({
        //        showOn: "button",
        //        buttonImage: "../../../jsdate/calendar.gif",
        //        buttonImageOnly: true
        //    });

        //}
        //$(document).ready(function () {
        //    showdate($("#ContentPlaceHolder1_txt_start_date"));
        //    showdate($("#ContentPlaceHolder1_txt_end_date"));
        //});
        $(function () {
            $("#ContentPlaceHolder1_txt_start_date").datepicker({
                changeMonth: true,
                changeYear: true,
                //format: 'mm/yyyy'
            });
        });
        $(function () {
            $("#ContentPlaceHolder1_txt_end_date").datepicker({
                changeMonth: true,
                changeYear: true,
                //format: 'mm/yyyy'
            });
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <script type="text/javascript" >
              $(document).ready(function () {
                  $(window).load(function () {
                      $.ajax({
                          type: 'POST',
                          data: { submit: true },
                          success: function (result) {
                              // $('#spinner').fadeOut('slow');
                          }
                      });
                  });

                  function CloseSpin() {
                      $('#spinner').toggle('slow');
                  }

                  $('#ContentPlaceHolder1_btn_upload').click(function () {

                      $('#spinner').toggle('slow');
                      Popups('POPUP_LCN_UPLOAD.aspx');
                      return false;
                  });

                  $('#ContentPlaceHolder1_btn_download').click(function () {
                      $('#spinner').fadeIn('slow');
                      Popups('POPUP_LCN_DOWNLOAD.aspx');
                      return false;
                  });

                  function Popups(url) { // สำหรับทำ Div Popup
                      $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                      var i = $('#f1'); // ID ของ iframe   
                      i.attr("src", url); //  url ของ form ที่จะเปิด
                  }

                  function close_modal() { // คำสั่งสั่งปิด PopUp
                      $('#myModal').modal('hide');
                      $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
                  }
              });

              function spin_space() { // คำสั่งสั่งปิด PopUp
                  //    alert('123456');
                  $('#spinner').toggle('slow');
                  //$('#myModal').modal('hide');
                  //$('#ContentPlaceHolder1_Button2').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click

              }
        </script> 
         <script type="text/javascript" >
              function closespinner() {
                  $('#spinner').fadeOut('slow');
                  alert('บันทึกสำเร็จ');
                  $('#ContentPlaceHolder1_Button1').click();
              }
              function closespinner2() {
                  $('#spinner').fadeOut('slow');
                  alert('บันทึกสำเร็จ');
              }
         </script>
  <div id="spinner" style=" background-color:transparent;display:none; " >
  <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
</div>
     <div style="width:100% ; text-align:left"  >
          <div style="width:auto ; float:left ;text-align:center;display:none">
              <h4>
         ยื่นข้อมูลที่&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:RadioButton ID="rbtn_bangkok" runat="server" Checked="True" GroupName="pvn" text="ศูนย์ อย."/>  &nbsp;&nbsp;&nbsp;&nbsp;  <asp:RadioButton ID="rbtn_other" runat="server" GroupName="pvn" Text="ต่างจังหวัด" />
      </h4>
    </div>

          <h3>
              <asp:ScriptManager ID="ScriptManager1" runat="server">
              </asp:ScriptManager>
          </h3>
         <center><h3>รายละเอียดโครงการวิจัย</h3>
         </center>
         <div class="con">
             อัพโหลดไฟล์เพื่อทำต่อจากเดิม<asp:FileUpload ID="FileUpload2" runat="server" /><asp:Button ID="Button2" runat="server" Text="โหลดข้อมูล" />
         </div>
         <br/><br/><br/>
         &nbsp;<table class="auto-style2" id="pj_sum"> 
             <%--<tr><td class="auto-style1">   เลขบัญชีรายการยาที่ใช้ในโครงการ</td><td>   
                 <asp:TextBox ID="txt_drug" runat="server" Width="150px"></asp:TextBox>
&nbsp;
                 <asp:Button ID="Button7" runat="server" Text="เพิ่ม" />
                 <asp:Label ID="lbl_drug_id1" runat="server" Visible="False"></asp:Label>
                 <br />
                 <asp:Label ID="lbl_error" runat="server" ForeColor="#CC0000" Text="ไม่พบบัญชีรายการยา" Visible="False"></asp:Label>
                 <br />
                 <asp:Label ID="lbl_drug" runat="server"></asp:Label>
                 <br />
                 </td></tr>--%>
             <tr>
                 <td>1.ชื่อโครงการวิจัย ภาษาไทย</td>
                 <td>
                     <asp:TextBox ID="txt_pjthanm" runat="server" Width="400px"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td>2.ชื่อโครงการวิจัย ภาษาอังกฤษ</td>
                 <td>
                     <asp:TextBox ID="txt_pjengnm" runat="server" Width="400px"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td>3.รหัสโครงการ ได้แก่ รหัสที่ตั้งโดยผู้สนับสนุนการวิจัย (sponsor) ควรเป็นรหัสที่ใช้เหมือนกันในทุกสถานที่วิจัยของโครงร่างการวิจัย เดียวกันนี้</td>
                 <td>
                     <asp:TextBox ID="txt_pjcode" runat="server" Width="400px"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td>4.ชื่อย่อของโครงการ หรือ ชื่อเรียกอื่น</td>
                 <td>
                     <asp:RadioButton ID="rb_shortnm1" runat="server" Text="มี ได้แก่" GroupName="rb_shortnm" />
&nbsp;
                     <asp:TextBox ID="txt_shortnm" runat="server" Width="300px"></asp:TextBox>
                     <br />
                     <asp:RadioButton ID="rb_shortnm2" runat="server" Text="ไม่มี" GroupName="rb_shortnm" />
                 </td>
             </tr>
             <tr>
                 <td>5.IND number ของ US FDA</td>
                 <td>
                     <asp:RadioButton ID="rb_ind1" runat="server" Text="มี ได้แก่" GroupName="rb_ind" />
&nbsp;
                     <asp:TextBox ID="txt_ind" runat="server" Width="300px"></asp:TextBox>
                     <br />
                     <asp:RadioButton ID="rb_ind2" runat="server" Text="ไม่มี" GroupName="rb_ind" />
                 </td>
             </tr>
             <tr>
                 <td>6.การลงทะเบียนงานวิจัย (Clinical Trials Registry) (อาจลงทะเบียนกับ Registry ของไทยหรือต่างประเทศก็ได้ มากกว่าหนึ่งแห่งก็ได้)</td>
                 <td>
                     <asp:TextBox ID="txt_ctr" runat="server" Width="400px"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td>7.ประเภทของโครงการวิจัย
                     <br />
                     (1-4 นิยามตาม ICH-E8 `General Consideration for Clinical Trials&#39;)</td>
                 <td>
                     <asp:RadioButton ID="pj_1sttimes1" runat="server" Text="1" GroupName="type" />
                     &nbsp;
                     <asp:RadioButton ID="pj_1sttimes2" runat="server" Text="2" GroupName="type" />
                     &nbsp;
                     <asp:RadioButton ID="pj_1sttimes3" runat="server" Text="3" GroupName="type" />
                     &nbsp;
                     <asp:RadioButton ID="pj_1sttimes4" runat="server" Text="4" GroupName="type" />
                     &nbsp;
                     <asp:RadioButton ID="pj_1sttimes5" runat="server" Text="ชีวสมมูล" GroupName="type" />
                     <br />
                     <br />
                     ( ทำวิจัยครั้งแรกในคนหรือไม่
                     <asp:RadioButton ID="rb_type1" runat="server" Text="ใช่" GroupName="rb_firsttime" />
                     &nbsp;
                     <asp:RadioButton ID="rb_type2" runat="server" Text="ไม่ใช่" GroupName="rb_firsttime" />
                     &nbsp;)</td>
             </tr>
             <tr>
                 <td>8.ประเภทของการสนับสนุนการวิจัย</td>
                 <td>
                     <asp:RadioButton ID="rb_support1" runat="server" Text="โครงการวิจัยที่ริเริ่มโดยบริษัทยา" GroupName="rb_supcountry" />
                     &nbsp;
                     <asp:TextBox ID="TextBox18" runat="server" Width="200px"></asp:TextBox>
                     <br />
                     <asp:RadioButton ID="rb_support2" runat="server" Text="โครงการวิจัยที่ริเริ่มโดยผู้วิจัยเอง" GroupName="rb_supcountry" />
                 </td>
             </tr>
             <tr>
                 <td>9.ประเทศที่ทำการวิจัย</td>
                 <td>
                     <asp:RadioButton ID="rb_country1" runat="server" Text="เฉพาะในประเทศไทย" GroupName="rb_country" />
&nbsp;
                     <asp:RadioButton ID="rb_country2" runat="server" Text="วิจัยในหลายประเทศ" GroupName="rb_country" />
                 </td>
             </tr>
             <tr>
                 <td>10.จำนวนสถาบันที่ร่วมวิจัยทั้งหมดทั่วโลก</td>
                 <td>
                     <asp:TextBox ID="txt_ins" runat="server"></asp:TextBox>
                 &nbsp; แห่ง</td>
             </tr>
             <tr>
                 <td class="auto-style3">11.จำนวนอาสาสมัครทั้งหมดทั่วโลกตามแผน</td>
                 <td class="auto-style3">
                     <asp:TextBox ID="txt_global_volun" runat="server"></asp:TextBox>
                 &nbsp; คน</td>
             </tr>
             <tr>
                 <td>12.จำนวนสถาบันที่ร่วมวิจัยในประเทศไทยตามแผน</td>
                 <td>
                     <asp:TextBox ID="th_intitute" runat="server"></asp:TextBox>
                 &nbsp; แห่ง</td>
             </tr>
             <tr>
                 <td>13.ข้อมูลของแต่ละสถานที่วิจัยในประเทศไทย</td>
                 <td>

                     <asp:Label ID="txt_fac" runat="server"></asp:Label>
                     <br />
                     <asp:Label ID="lbl_placnm" runat="server" Visible="False"></asp:Label>

                                    <br />
                     ชื่อสถานที่วิจัย :
                     <asp:TextBox ID="txt_placenm" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     <asp:Label ID="lbl_taxno" runat="server" Visible="False"></asp:Label>

                                    <br />
                     เลขนิติบุคคล :
                     <asp:TextBox ID="txt_taxno" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     <asp:Label ID="lbl_houseno" runat="server" Visible="False"></asp:Label>

                                    <br />
                     เลขที่บ้าน : <asp:TextBox ID="txt_houseno" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     <asp:Label ID="lbl_volunteer" runat="server" Visible="False"></asp:Label>
                     <br />
                     จำนวนอาสาสมัคร แต่ละสถานที่วิจัย :
                     <asp:TextBox ID="txt_volunteer_amount" runat="server" Width="300px"></asp:TextBox>
                     <br />
                     <asp:Label ID="lbl_main_research" runat="server" Visible="False"></asp:Label>
                     <br />
                     ชื่อผู้วิจัยหลัก :
                     <asp:TextBox ID="txt_main_research" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     <asp:Label ID="lbl_addr" runat="server" Visible="False"></asp:Label>
                     <br />
                     ที่อยู่ :
                     <asp:TextBox ID="txt_fac_addr" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     <asp:Label ID="lbl_chngwtcd" runat="server" Visible="False"></asp:Label>
                     <asp:Label ID="lbl_chngwtnm" runat="server" Visible="False"></asp:Label>
                     <br />
                     จังหวัด :
                     <asp:DropDownList ID="DropDownList1" runat="server">
                     </asp:DropDownList>
                     <br />
                     <asp:Label ID="lbl_latitude" runat="server" Visible="False"></asp:Label>

                                    <br />
                     ละติจูด :
                     <asp:TextBox ID="txt_latitude" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     <asp:Label ID="lbl_longtitude" runat="server" Visible="False"></asp:Label>

                                    <br />
                     ลองติจูด :
                     <asp:TextBox ID="txt_longtitude" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     <asp:Label ID="lbl_tel" runat="server" Visible="False"></asp:Label>
                     <br />
                     โทร. :
                     <asp:TextBox ID="txt_fac_tel" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     <asp:Label ID="lbl_email" runat="server" Visible="False"></asp:Label>
                     <br />
                     อีเมล์ :
                     <asp:TextBox ID="txt_fac_email" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     <br />
                     <asp:Button ID="btn_save_fac" runat="server" Text="บันทึกสถานที่วิจัย" />
                 </td>
             </tr>
             <tr>
                 <td>14.ผู้สนับสนุนการวิจัยในประเทศไทย (Thai Sponsor)</td>
                 <td>   
                     ชื่อหน่วยงาน : <asp:TextBox ID="th_spon_group" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     เลขนิติ : <asp:TextBox ID="thspons_taxno" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     ที่อยู่ :
                     <asp:TextBox ID="th_spon_addr" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     จังหวัด :
                     <asp:DropDownList ID="DropDownList2" runat="server">
                     </asp:DropDownList>
                     <br />
                     โทร. :
                     <asp:TextBox ID="th_spon_tel" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     อีเมล์/เว็บไซต์ :
                     <asp:TextBox ID="th_spon_email" runat="server" Width="400px"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td>15.ผู้สนับสนุนการวิจัยในต่างประเทศ (Foreign Sponsor)</td>
                 <td>   
                     ชื่อหน่วยงาน :
                     <asp:TextBox ID="for_spons_groupnm" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     ที่อยู่ :
                     <asp:TextBox ID="for_spons_addr" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     ประเทศ :
                     <asp:DropDownList ID="DropDownList3" runat="server">
                     </asp:DropDownList>
                     <br />
                     โทร. :
                     <asp:TextBox ID="for_spons_tel" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     อีเมล์/เว็บไซต์ :
                     <asp:TextBox ID="for_spons_email" runat="server" Width="400px"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td>16.บริษัทหรือหน่วยงานที่กำกับดูแล การวิจัย (Monitor)</td>
                 <td>   
                     <asp:RadioButton ID="rb_monitor_type1" runat="server" GroupName="monitor_type" Text="เป็นผู้ยื่นคำขอฯ" />
&nbsp;
                     <asp:RadioButton ID="rb_monitor_type2" runat="server" GroupName="monitor_type" Text="ไม่ใช่ผู้ยื่นคำขอฯ" />
                     <br />
                     ชื่อหน่วยงาน : <asp:TextBox ID="monitor_group" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     เลขนิติ : <asp:TextBox ID="monitor_taxno" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     ที่อยู่ :
                     <asp:TextBox ID="monitor_addr" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     ประเทศ :
                     <asp:DropDownList ID="DropDownList6" runat="server" AutoPostBack="True">
                     </asp:DropDownList>
&nbsp; <div id="chngwt1" runat="server" style="display:none">จังหวัด :
                     <asp:DropDownList ID="DropDownList7" runat="server">
                     </asp:DropDownList></div>
                     <br />
                     โทร. :
                     <asp:TextBox ID="monitor_tel" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     อีเมล์/เว็บไซต์ :
                     <asp:TextBox ID="monitor_email" runat="server" Width="400px"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td>17.บริษัทหรือหน่วยงานที่บริหาร จัดการโครงการวิจัย (Project Management)</td>
                 <td>   
                     <asp:RadioButton ID="rb_pm_type1" runat="server" GroupName="pm_type" Text="เป็นผู้ยื่นคำขอฯ" />
&nbsp;
                     <asp:RadioButton ID="rb_pm_type2" runat="server" GroupName="pm_type" Text="ไม่ใช่ผู้ยื่นคำขอฯ" />
                     <br />
                     ชื่อหน่วยงาน :
                     <asp:TextBox ID="pm_group" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     เลขนิติ : <asp:TextBox ID="pm_taxno" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     ที่อยู่ :
                     <asp:TextBox ID="pm_addr" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     ประเทศ :
                     <asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="True">
                     </asp:DropDownList>
&nbsp; <div id="chngwt2" runat="server" style="display:none">จังหวัด :
                     <asp:DropDownList ID="DropDownList8" runat="server">
                     </asp:DropDownList></div>
                     <br />
                     โทร. :
                     <asp:TextBox ID="pm_tel" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     อีเมล์/เว็บไซต์ :
                     <asp:TextBox ID="pm_email" runat="server" Width="400px"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td>18.บริษัทหรือหน่วยงานที่บริหาร จัดการข้อมูล (Data Management)</td>
                 <td>   
                     <asp:RadioButton ID="rb_dm_type1" runat="server" GroupName="dm_type" Text="เป็นผู้ยื่นคำขอฯ" />
&nbsp;
                     <asp:RadioButton ID="rb_dm_type2" runat="server" GroupName="dm_type" Text="ไม่ใช่ผู้ยื่นคำขอฯ" />
                     <br />
                     ชื่อหน่วยงาน :
                     <asp:TextBox ID="dm_group" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     เลขนิติ : <asp:TextBox ID="dm_taxno" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     ที่อยู่ :
                     <asp:TextBox ID="dm_addr" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     ประเทศ :
                     <asp:DropDownList ID="DropDownList5" runat="server" AutoPostBack="True">
                     </asp:DropDownList>
&nbsp; <div id="chngwt3" runat="server" style="display:none">จังหวัด :
                     <asp:DropDownList ID="DropDownList9" runat="server">
                     </asp:DropDownList></div>
                     <br />
                     โทร. :
                     <asp:TextBox ID="dm_tel" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     อีเมล์/เว็บไซต์ :
                     <asp:TextBox ID="dm_email" runat="server" Width="400px"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td>19.ห้องปฏิบัติการคลินิก (Clinical Laboratory)</td>
                 <td>
                     <asp:RadioButton ID="rb_lab1" runat="server" Text="ใช้ห้องปฏิบัติการคลินิกของแต่ละสถานที่วิจัย" GroupName="rb_lab" AutoPostBack="True" />
                     <br />
                     <asp:RadioButton ID="rb_lab2" runat="server" Text="ใช้ห้องปฏิบัติการคลินิกภายนอกสถานที่วิจัยในประเทศ/นอกประเทศ ได้แก่" GroupName="rb_lab" AutoPostBack="True" />
                     <br />
                     <div id="clinic_section" runat="server">

                     <asp:Label ID="lbl_lab" runat="server"></asp:Label>
                         <br />
                     <br />
                     ห้องปฏิบัติการคลินิก (Clinical Laboratory) :
                     <asp:TextBox ID="TextBox13" runat="server" Width="350px"></asp:TextBox>
                     <br />
                     <asp:Label ID="lbl_labnm" runat="server" Visible="False"></asp:Label>
                     <br />
                     ชื่อหน่วยงาน :
                     <asp:TextBox ID="TextBox14" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     <asp:Label ID="lbl_groupnm" runat="server" Visible="False"></asp:Label>
                     <br />
                     ที่อยู่ :
                     <asp:TextBox ID="TextBox15" runat="server" Width="400px"></asp:TextBox>
                         <br />
                     <asp:Label ID="lbl_lab_chngwtcd" runat="server" Visible="False"></asp:Label>
                     <asp:Label ID="lbl_lab_chngwtnm" runat="server" Visible="False"></asp:Label>
                     <asp:Label ID="lbl_lab_countrycd" runat="server" Visible="False"></asp:Label>
                     <asp:Label ID="lbl_lab_countrynm" runat="server" Visible="False"></asp:Label>
                         <br />
                         ประเทศ :
                         <asp:DropDownList ID="DropDownList10" runat="server" AutoPostBack="True">
                         </asp:DropDownList>
&nbsp; <div id="chngwt" runat="server" style="display:none">จังหวัด :
                         <asp:DropDownList ID="DropDownList11" runat="server">
                         </asp:DropDownList></div>
                     <br />
                     <asp:Label ID="lbl_lab_addr" runat="server" Visible="False"></asp:Label>
                     <br />
                     โทร. :
                     <asp:TextBox ID="TextBox16" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     <asp:Label ID="lbl_lab_tel" runat="server" Visible="False"></asp:Label>
                     <br />
                     อีเมล์/เว็บไซต์ :
                     <asp:TextBox ID="TextBox17" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     <asp:Label ID="lbl_lab_email" runat="server" Visible="False"></asp:Label>
                     <br />
                     <asp:Button ID="btn_save_lab" runat="server" Text="บันทึกห้องปฏิบัติการคลินิกภายนอก" />
                     </div>
                 </td>
             </tr>
             <tr>
                 <td>20.รายการยาที่ใช้ในโครงการ (ให้ระบุยาทุกตัวที่ใช้ในโครงการ รวมทั้ง ยาวิจัย ยาเปรียบเทียบ/ยาหลอก และยาที่ใช้ร่วม โดยไม่คำนึงว่าจะขออนุญาตในคำขอนี้หรือไม่)</td>
                 <td>

                   &nbsp;รหัสยาที่ใช้ในโครงการ :
                     <asp:TextBox ID="TextBox24" runat="server"></asp:TextBox>
&nbsp;
                     <asp:Button ID="btn_dr_search" runat="server" Text="ค้นหาผลิตภัณฑ์ยา" />
                     <br />

                   <telerik:RadGrid ID="RadGrid2" runat="server" GridLines="None" ShowFooter="true" AutoGenerateColumns="false">
                   <MasterTableView>
                        <Columns>
                            <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                                <ItemTemplate>
                                   <asp:CheckBox ID="checkColumn" runat="server" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                               SortExpression="IDA" UniqueName="IDA" Display="false">
                           </telerik:GridBoundColumn>
                           <telerik:GridBoundColumn DataField="CREATE_DATE" FilterControlAltText="Filter CREATE_DATE column"
                               HeaderText="วันเวลาที่เพิ่ม" HeaderStyle-width="150px" SortExpression="CREATE_DATE" UniqueName="CREATE_DATE">
                           </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="drug_code" FilterControlAltText="Filter drug_code column"
                               HeaderText="รหัสผลิตภัณฑ์ยา" SortExpression="drug_code" UniqueName="drug_code">
                           </telerik:GridBoundColumn>
                           <telerik:GridBoundColumn DataField="commonnm" FilterControlAltText="Filter commonnm column"
                               HeaderText="ชื่อสามัญ" SortExpression="commonnm" UniqueName="commonnm">
                           </telerik:GridBoundColumn>
                           <telerik:GridBoundColumn DataField="tradenm" FilterControlAltText="Filter tradenm column"
                               HeaderText="ชื่อการค้า" SortExpression="tradenm" UniqueName="tradenm">
                           </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="typenm" FilterControlAltText="Filter typenm column"
                               HeaderText="ประเภท" SortExpression="typenm" UniqueName="typenm">
                           </telerik:GridBoundColumn>
                           <telerik:GridBoundColumn DataField="imp_amount" FilterControlAltText="Filter imp_amount column"
                               HeaderText="จำนวนนำเข้า" SortExpression="imp_amount" UniqueName="imp_amount">
                               <HeaderStyle Width="80px" />
                           </telerik:GridBoundColumn>
                           <telerik:GridBoundColumn DataField="bunitnm" FilterControlAltText="Filter bunitnm column"
                               SortExpression="bunitnm" UniqueName="bunitnm">
                           </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                                        </telerik:RadGrid>

                                    </td>
             </tr>
             <tr>
                 <td>21.วันที่เริ่มการวิจัยในประเทศไทย (โดยประมาณ)</td>
                 <td>
                     <asp:TextBox ID="txt_start_date" runat="server" Visible="False"></asp:TextBox>
                     &nbsp;<asp:TextBox ID="TextBox22" runat="server"></asp:TextBox>
                     (กรอกเดือนและปี เช่น 01/2560)</td>
             </tr>
             <tr>
                 <td>22.วันที่สิ้นสุดการวิจัยในประเทศไทย (โดยประมาณ)</td>
                 <td>
                     <asp:TextBox ID="txt_end_date" runat="server" Visible="False"></asp:TextBox>
                     &nbsp;<asp:TextBox ID="TextBox23" runat="server"></asp:TextBox>
                     (กรอกเดือนและปี เช่น 01/2560)</td>
             </tr>
             <tr>
                 <td>23.วิธีการหาอาสาสมัคร</td>
                 <td>
                     <asp:RadioButton ID="rb_findvolun1" runat="server" Text="ติดประกาศโฆษณา" GroupName="rb_volunteer" />
                     <br />
                     <asp:RadioButton ID="rb_findvolun2" runat="server" Text="เชิญชวนด้วยวาจา" GroupName="rb_volunteer" />
                     <br />
                     <asp:RadioButton ID="rb_findvolun3" runat="server" Text="อื่นๆ โปรดอธิบาย" GroupName="rb_volunteer" />
&nbsp;
                     <asp:TextBox ID="txt_volundes" runat="server" Width="400px"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td>24.การสนับสนุนทางการเงินและ การประกัน (Financing and Insurance)</td>
                 <td>
                     <asp:RadioButton ID="rb_finace1" runat="server" Text="โครงร่างการวิจัย (โปรดระบุ ชื่อเอกสาร version วันที่ หน้า ข้อ)" GroupName="rb_finace" />
                     <br />
&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:TextBox ID="TextBox19" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     <asp:RadioButton ID="rb_finace2" runat="server" Text="เอกสารข้อมูลสำหรับอาสาสมัคร (โปรดระบุ ชื่อเอกสาร version วันที่ หน้า)" GroupName="rb_finace" />
                     <br />
&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:TextBox ID="TextBox20" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     <asp:RadioButton ID="rb_finace3" runat="server" Text="นอกเหนือจากข้อข้างบน ได้แก่ (โปรดระบุ ชื่อเอกสาร version วันที่ หน้า) พร้อมแนบสำเนาเอกสาร" GroupName="rb_finace" />
                     &nbsp;
                     <br />
&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:TextBox ID="TextBox21" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     <asp:RadioButton ID="rb_finace4" runat="server" Text="กรณีไม่ได้ระบุไว้ในเอกสารที่คณะกรรมการพิจารณาจริยธรรมอนุมัติหรือรับรอง ให้ผู้ยื่นคำขอมีหนังสือชี้แจงพร้อมแนบหลักฐานเช่น กรมธรรม์ประกันภัย เอกสารข้อตกลงที่เกี่ยวข้อง เป็นต้น" GroupName="rb_finace" Width="500px" />
                     <br />
                     <br />
                     <br />
                     
                     แนบสำเนาเอกสาร : <asp:FileUpload ID="FileUpload1" runat="server" />
                 </td>
             </tr>
             <tr>
                 <td></td>
                 <td></td>
             </tr>

             <tr><td colspan="2"> &nbsp;
                 <asp:Button ID="Button1" runat="server" Text="" style="display:none;"  />
                 <asp:Button ID="btn_save" CssClass="btn-lg" runat="server" Text="บันทึก" />
                 &nbsp;
                 <asp:Button ID="btn_save2" CssClass="btn-lg" runat="server" Text="บันทึกและอัพโหลด" />
                 &nbsp;
                 <asp:HiddenField ID="HiddenField1" runat="server" />
                 </td></tr>
         </table>

    </div>
</asp:Content>
