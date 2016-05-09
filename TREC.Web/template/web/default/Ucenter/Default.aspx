<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TREC.Web.template.web.Ucenter.Default" %>
<%@ Register Src="../ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="../ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register Src="../ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>
<%@ Register src="../ascx/Ucenter.ascx" tagname="Ucenter" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/resource/content/css/ucerter.css" rel="stylesheet" type="text/css">
    <link href="/resource/content/css/supplier.css" rel="stylesheet" type="text/css">
   <script src="/resource/content/indexnav/jquery.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:header ID="header1" runat="server" />
    <div class="site"><a href="#">首页</a> &gt; <a href="#">购物车</a> &gt; 用户中心</div>
   
   <div class="contentInner">
  <div class="inner">
    <div class="supplier">
                            
<uc2:Ucenter ID="Ucenter1" runat="server" />
        

                            <div class="spR">
                                <div class="spBox1">
                                    <div class="sphd">
                                        <span class="s1">送货信息管理 </span><span class="sbtn">
                                           <a style="" href="/user/myAdd.aspx" class="i2"><img  src="/resource/content/images/ucenter/user10.jpg"></a> 
                                        </span>
                                    </div>
                                    <div class="spbd">
                                        <div class="myDoc myDocTrim1">
                                            <div class="myDocInner">
                                                <div class="bd">
                                                    <div class="item">
                                                        <table width="960px" id="tdaddress">
                                                                   <tr><th width="10%" scope="col">收货人</th>
                                                                        <th width="30%" scope="col">地址</th>
                                                                        <th width="30%" scope="col">电话/手机</th>
                                                                        <th width="10%" scope="col">&nbsp; </th>
                                                                        <th width="15%" scope="col"> 操作 </th>
                                                                    </tr>

                                                      </table>
                                                    </div>
                                                </div>
                                                <h5>
                                                    <span id="Label1">新增</span>收货信息</h5>
                                                <input type="hidden" id="id" name="id">
                                                <div style="margin-top:10px;" class="d2">
                                                    <table width="700px">
                                                        <tbody><tr>
                                                            <td>
                                                                收货人：
                                                            </td>
                                                            <td>
                                                                <input type="text" class="i1 inputcss" id="Consignee" name="Consignee" maxlength="10">
                                                                
                                                            </td>
                                                            <td class="">
                                                                请确认您的邮箱地址填写正确，并尽快激活您的Email
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                电话：
                                                            </td>
                                                            <td>
                                                                <input type="text" class="i1 inputcss" id="Phone" name="Phone" maxlength="15">
                                                              
                     
                                                            </td>
                                                            <td class="">
                                                            手机及电话请选填一项
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                手机号：
                                                            </td>
                                                            <td>
                                                                <input type="text" class="i1 inputcss" id="Mobile" name="Mobile" onblur="JudgeTelephone('Mobile')" maxlength="15">
                                                              
                                                            </td>
                                                            <td class="">
                                                                手机及电话请选填一项
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                所属地区：
                                                            </td>
                                                            <td>
                                                                
                                                                <div id="UpdatePanel1">
                                                                 <select name="SelProvince" onchange="SelPCity()" id="SelProvince" style="width:75px;">
                            </select>
                            <select name="SelCity" onchange="selPArea()" id="SelCity" style="width:75px;">
                              <option selected="selected" value="0">--城市--</option>
                            </select>
                            <select name="selArea"  id="selArea" style="width:75px;">
                              <option selected="selected" value="0">--区--</option>
                            </select>
                                                                </div>
                                                            </td>
                                                            <td class="">
                                                               如没有区/县可以不用选择
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                收货地址：
                                                            </td>
                                                            <td>
                                                                <input type="text" class="i1 inputcss" id="Address" name="Address" maxlength="100">
                                                                
                                                            </td>
                                                            <td class="">
                                                               请输入您的收货地址
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                邮编：
                                                            </td>
                                                            <td>
                                                                <input type="text" class="i1 inputcss" id="Zipcode" name="Zipcode" maxlength="6">
                                                               
                                                            </td>
                                                            <td class="">
                                                             正确填写邮编将加快发货速度
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                邮箱：
                                                            </td>
                                                            <td>
                                                                <input type="text" class="i1 inputcss" id="Email" name="Email" onblur="JudgeMail('Email')"  maxlength="30">
                                                               
                                                            </td>
                                                            <td class="">
                                                             正确填写邮箱将加快发货速度
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                传真：
                                                            </td>
                                                            <td>
                                                                <input type="text" class="i1 inputcss" id="Fax" name="Fax" maxlength="30">
                                                               
                                                            </td>
                                                            <td class="">
                                                             正确填写传真将加快发货速度
                                                            </td>
                                                        </tr>
                                                        <tr id="trmsg" style="display:none;">
                                                            <td  >
                                                                &nbsp;
                                                            </td>
                                                            <td id="tdmsgshow" style="color:Red;padding-left:30px;" align="left">
                                                                保存成功
                                                            </td>
                                                            <td class="">
                                                            &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;
                                                                
                                                            </td>
                                                            <td>
                                                             <img src="/resource/content/images/wait.gif"  id="imgwait" style="display:none;"/>
                                                            <img src="/resource/content/images/ucenter/user6.jpg" id="imgsubmit"  style="cursor:pointer;" onclick="addsubmit()"/>

                                                            <img src="/resource/content/images/ucenter/supplier7.jpg" style="cursor:pointer;" onclick="funtest()"/>
                                                                <input type="image" style="border-width:0px;display:none;" src="/resource/content/images/ucenter/user6.jpg" id="tiJiao" name="tiJiao" >
                                                                
                                                                <input type="image" style="border-width:0px;display:none;" src="/resource/content/images/ucenter/supplier7.jpg" id="chongzhi" name="chongzhi">
                                                                
                                                            </td>
                                                            <td>&nbsp;
                                                                
                                                            </td>
                                                        </tr>
                                                    </tbody></table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="clearfix">
                            </div>
                        </div>
  </div>

</div>
 <input type="hidden" id="addressIdsubmit" value="0"  name="addressIdsubmit"/>
<ucfooter:footer ID="header2" runat="server" />


    <script language="javascript" type="text/javascript">
        function getArea(pcode, checkcode, title, id) {
            $.get("/ajax/GetArea.aspx?pcode=" + pcode + "&checkcode=" + checkcode, '', function (data, textStatus) {
                $("#" + id).html(title + data);
            }, null);
        }
        //省份首次加载
        function funselload() {
            getArea('0', '', '<option value="0">--省份--</option>', 'SelProvince');
        }
        function SelPCity() {
            var pid = $("#SelProvince").val();
            getArea(pid, '', '<option value="0">--城市--</option>', 'SelCity');
        }
        function selPArea() {
            var pid = $("#SelCity").val();
            getArea(pid, '', '<option value="0">--地区--</option>', 'selArea');
        }
        funselload();

        function addresssubmit(id) {
            $.post("/ajax/DelStrolleyShopping.aspx", { "ids": ids }, function (data, textStatus) {
                $("#adelall").html('删除选中商品');
                var value = data;
                if (value == 'true') {

                }
                else if (value == 'false') {
                    alert('删除失败，请联系管理员');
                }
                else if (value == 'nologin') {

                }
            }, null);
        }

        //地址信息加载
        function addressload() {

            $.get("/ajax/UcAddressLoad.aspx", function (data, textStatus) {
//                if (data == '') {
//                    $("#divaddressup").show();
//                }
//                else {
//                    $("#divaddressup").hide();
//                }

                $("#tdaddress").html(data);
            }, null);
        }

        addressload();

        //数据提交
        function addsubmit() {

            var id = $("#addressIdsubmit").val();
            var Consignee = $.trim($("#Consignee").val());
            var ProvinceName = $("#SelProvince").find("option:selected").text();
            var ProvinceCode = $("#SelProvince").val();
            var CityName = $("#SelCity").find("option:selected").text();
            var CityCode = $("#SelCity").val();

            var AreaName = $("#selArea").find("option:selected").text();
            var AreaCode = $("#selArea").val();

            var Address = $.trim($("#Address").val());
            var Zipcode = $.trim($("#Zipcode").val());
            var Mobile = $.trim($("#Mobile").val());
            var Phone = $.trim($("#Phone").val());
            var Email = $.trim($("#Email").val());
            var Fax = $.trim($("#Fax").val());

            if (Consignee == '') {
                $("#Consignee").focus();
                alert("收货人不能为空");
                return;
            }
            if (AreaCode == '0') {
                $("#selArea").focus();
                alert("请选择省市区");
                return;
            }

            if (Address == '') {
                $("#Address").focus();
                alert("收货地址不能为空");
                return;
            }
            if (Mobile == '') {
                $("#Mobile").focus();
                alert("手机号码不能为空");
                return;
            }
            if (Email == '') {
                $("#Email").focus();
                alert("邮箱不能为空");
                return;
            }

            $("#imgwait").show();
            $("#imgsubmit").hide();
            $("#trmsg").hide();
            $.post("/ajax/AddressSubmit.aspx", { "id": id, "Consignee": Consignee, "ProvinceName": ProvinceName, "ProvinceCode": ProvinceCode, "CityName": CityName, "CityCode": CityCode, "AreaName": AreaName, "AreaCode": AreaCode, "Address": Address, "Zipcode": Zipcode, "Mobile": Mobile, "Phone": Phone, "Email": Email, "Fax": Fax }, function (data, textStatus) {
                $("#imgwait").hide();
                $("#imgsubmit").show();
                var value = data;
                addressload();
                clearadd();
                $("#addressIdsubmit").val("0");
                $("#trmsg").show();
                $("#tdmsgshow").html('保存成功');
            }, null);
        }
        //添加完成后清空数据
        function clearadd() {
            $("#Consignee").val('');
            $("#Phone").val('');
            $("#Mobile").val('');
            $("#Address").val('');
            $("#Zipcode").val('');
            $("#Email").val('');
            $("#Fax").val('');
        }
        //新增
        function Newsaddress() {
            $("#divaddressList").show();
            $("#submsg").html('新增操作');
            $("#addressIdsubmit").val('0');
            addressShow();
        }
        function addressShow() {
            $("#divaddressup").show();
        }

        function addresshide() {
            $("#divaddressup").hide();
        }

        function dataUpdate(id) {
            var jsontext = $("#updateId" + id).val();
            var contact = JSON.parse(jsontext);
            $("#addressIdsubmit").val(contact.Id);
            $("#Consignee").val(contact.Consignee);

            $("#Address").val(contact.Address);
            $("#Zipcode").val(contact.Zipcode);
            $("#Mobile").val(contact.Mobile);
            $("#Phone").val(contact.Phone);
            $("#Email").val(contact.Email);
            $("#Fax").val(contact.Fax);

            var ProvinceCode = contact.ProvinceCode;
            var CityCode = contact.CityCode;
            var AreaCode = contact.AreaCode;

            getArea('0', ProvinceCode, '', 'SelProvince');
            getArea(ProvinceCode, CityCode, '', 'SelCity');
            getArea(CityCode, AreaCode, '', 'selArea');
        }

        function addreshow() {
            if ($("#divaddressList")[0].style.display == 'none') {
                $("#addreoperA").html('收起');
                $("#divaddressList").show();
            }
            else {
                $("#addreoperA").html('展开');
                $("#divaddressList").hide();
            }
        }
        function DelOrDefault(id, t) {
            if (t == 'del') {
                if (!confirm('确定要删除吗？')) {
                    window.event.returnValue = false;
                    return;
                }
            }

            $.post("/ajax/DefaultOrdel.aspx", { "Id": id, "t": t }, function (data, textStatus) {
                addressload();
            }, null);
        }


        function JudgeTelephone(ButtonName) {

            var reg = new RegExp(/((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)/);
            var input = document.getElementById(ButtonName).value;
            if (!reg.test(input) & input != '') {
                alert('电话号码有误');
                window.event.returnValue = false;
            }
        }
        function JudgeMail(ButtonName) {
            var reg = new RegExp(/^[0-9a-zA-Z]+@[0-9a-zA-Z]+[\.]{1}[0-9a-zA-Z]+[\.]?[0-9a-zA-Z]+$/);
            var input = document.getElementById(ButtonName).value;
            if (!reg.test(input) & input != '') {
                alert('邮件格式有误');
                window.event.returnValue = false;
            }
        }

        function disFree(id) {
            //spanyf1 inputyf1
            var reg = new RegExp(/^[0-9]*$/);
            var input = document.getElementById('inputyf' + id).value;
            if (!reg.test(input) & input != '') {
                $("#inputyf" + id).val('0');
                alert('费用只能为整数');
                window.event.returnValue = false;
            }

            $("#spanyf" + id).html($("#inputyf" + id).val());
        }

        function funcheckAddress(id) {
            $("#checkAddressId").val(id);
            $("#divaddressList div[class='dizhi dizhixz']").prop('class', 'dizhi');
            $("#dizhi" + id).prop("class", "dizhi dizhixz");
        }
        function funsubmitdata() {
            if (typeof ($("#checkAddressId").val()) == "undefined") {
                alert('请选择收货人信息');
                return;
            }

            if ($("#checkAddressId").val() == '0') {
                alert('请选择收货人信息');
                return;
            }
            document.getElementById("form1").submit();
        }
        function funtest() {
            dataUpdate('1');
//             var jsontext = $("#updateId1").val();
//             var contact = JSON.parse(jsontext);
//             alert(contact.Phone);

           // var jsontext = $("#updateId1").val();
           // addressupdate('1');
            //alert(jsontext);
            
        }
    </script>

    </form>
</body>
</html>
