﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="companyinfo.aspx.cs" Inherits="TREC.Web.Admin.company.companyinfo" EnableEventValidation="false" %>
<%@ Import Namespace="TREC.ECommerce" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/jquery.validate.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/additional-methods.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/messages_cn.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/jquery.area.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebAdminResourceUrl.TrimEnd('/') %>/editor/kindeditor/kindeditor-min.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/fileupload.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/functioni.js"></script>

    <style type="text/css">
        .formTable{border:1px solid #ccc;}
        .formTable tr th{background:#ededed; text-align:left;}
        .formTable tr td{border:none; padding-top:8px; padding-bottom:8px;}
    </style>
    <script type="text/javascript">
        $(function () {
        
            //表单验证JS
            $("#form1").validate({
                //出错时添加的标签
                errorElement: "span",
                showErrors: function (errorMap, errorList) {
                    if (errorList.length > 0) {
                        if ($("#" + errorList[0].element.id).next() != null) {
                            $("#" + errorList[0].element.id).next().remove();
                        }
                    }
                    this.defaultShowErrors();
                },
                success: function (label) {
                    //正确时的样式
                    label.text(" ").addClass("success");
                }
            });


            var editor;
            KindEditor.ready(function (K) {
                editor = K.create('#txtdescript', {
                    allowPreviewEmoticons: true,
                    allowImageUpload: true,
                    allowFileManager: true,
                    <%if (TREC.ECommerce.ECommon.QueryId != "" && TREC.ECommerce.ECommon.QueryEdit != "")
                    { %>
                     fileManagerJson:"<%=TREC.ECommerce.ECommon.WebAdminResourceUrl %>/editor/kindeditor/ashx/file_manager_json.ashx?m=company&id=<%=TREC.ECommerce.ECommon.QueryId %>",
                    <%} %>
                    allowMediaUpload: true,
                    items: [
						'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|', 'image', 'flash', 'media', 'link', 'fullscreen']
                });
            });


            $("#btnSearch").click(function () {
                $.ajax({
                    url: "<%=ECommon.WebAdminUrl %>/ajax/ajaxuser.ashx",
                    data: "type=getnoaddmember&v=" + $("#txtSearch").val(),
                    dataType: "json",
                    success: function (data) {
                        if (data != "") {
                            $("#ddlmember").html();
                            $("#ddlmember").html("<option value=\"\">请选择</option>");
                            $.each(data, function (i) {
                                $("#ddlmember").append("<option value=\"" + data[i].id + "\">" + data[i].name + "</option>");
                            });
                        }
                    }
                })
            })

            $("#ddlPro22").live("change", function () {
                if ($(this).val() != "" && $(this).val() != "0") {
                    $.ajax({
                        url: "<%=ECommon.WebAdminUrl %>/ajaxtools/ajaxarea.ashx",
                        data: "type=c&p=" + $(this).val(),
                        success: function (data) {
                         $("#ddlregcity").html(data)
                        },
                        error: function (d, m) {
                            alert(m);
                        }
                    });
                }
            })
        });
    </script>
</head>
<body style="padding:10px;">
<form id="form1" runat="server">
    <div class="navigation">
    
      <span class="back"><a href="companylist.aspx">返回列表</a></span><b>您当前的位置：首页 &gt; 成员管理 &gt; 登陆账号管理</b>
    </div>
    <div class="spClear"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="3" align="left">登陆账号信息</th>
        </tr>
        <tr>
            <td  width="390px" valign="top">
                <table class="formTable" width="380px">
                    <tr>
                        <th colspan="2">账号信息：</th>
                    </tr>
                    <%if (ECommon.QueryId != "" && ECommon.QueryEdit != "" && _memberInfo!=null)
                      { %>
                    <tr>
                        <td align="right" width="70">通&nbsp;行&nbsp;&nbsp;证：</td>
                        <td><%=_memberInfo.passport %></td>
                    </tr>
                    <%}
                      else
                      { %>
                      <tr>
                        <td align="right" width="70">会员查找：</td>
                        <td><asp:TextBox ID="txtSearch" runat="server" CssClass="w160 input"></asp:TextBox>&nbsp;<input type="button" class="submit" value="查找" id="btnSearch" /></td>
                    </tr>

                    <%} %>
                    <tr>
                        <td align="right">登陆账号：</td>
                        <td><asp:DropDownList ID="ddlmember" runat="server" CssClass="select selectNone" Width="160"></asp:DropDownList></td>
                    </tr>
                </table>
                <div class="spClear"></div>
                <table class="formTable" width="380px">
                    <tr>
                        <th colspan="2">企业信息：</th>
                    </tr>
                    <tr>
	                    <td  width="70px" align="right">
		                    推荐属性：
                        </td>
	                    <td >
		                    <asp:CheckBoxList runat="server" ID="chkattribute" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList>
	                    </td>
                    </tr>
                    <tr>
	                    <td align="right">
		                    企业名称：
                        </td>
	                    <td >
		                    <asp:TextBox id="txttitle" runat="server" CssClass="input required w160"></asp:TextBox>
	                    </td></tr>
                    <tr>
                        <td align="right">
                            企业组 ：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlcompanygroup" runat="server" CssClass="select selectNone" Width="160px"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            名称索引：
                        </td>
                        <td>
                            <asp:TextBox ID="txtletter" runat="server" CssClass="input required w160"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="76px" align="right">
                            是否vip ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtvip" runat="server" Width="45" CssClass="input required">0</asp:TextBox><label>(1-10值越大级别越高,0为不是vip)</label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            人员规格 ：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlstaffsize" runat="server" CssClass="select selectNone" Width="160"></asp:DropDownList>
                        </td>
                    </tr>
                    <%--<tr>
                        <td align="right">
                            注册年份：
                        </td>
                        <td>
                            <asp:TextBox ID="txtregyear" runat="server" CssClass="input w160 required digits"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            注册城市：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPro" runat="server"  CssClass="select"></asp:DropDownList>
                            <asp:DropDownList ID="ddlregcity" runat="server" CssClass="select selectNone"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            业务描述：
                        </td>
                        <td>
                            <asp:TextBox ID="txtbuy" runat="server" CssClass="w250 textarea" TextMode="MultiLine" Rows="4"></asp:TextBox><label>长度不超过250字符,生产/销售/租凭业务描述</label>
                        </td>
                    </tr>--%>
                    <tr>
                    <td align="right" >
                        营业执照：
                    </td>
                    <td>
                        <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Company, ECommon.QueryId, TREC.Entity.EnFilePath.License)%>">
                            <asp:HiddenField ID="hflicense" runat="server" />
                            <div class="fileTools" style="width:310px">
                                <input type="text" class="input w160 filedisplay" />
                                <a href="javascript:;" class="files">
                                    <input id="Fileone" type="file" class="upload" onchange="_upfile(this,'0')" runat="server" /></a>
                                <span class="uploading">上传中</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="right" >
                        税务登记证：
                    </td>
                    <td>
                        <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Company, ECommon.QueryId, TREC.Entity.EnFilePath.Registration)%>">
                            <asp:HiddenField ID="hfregistration" runat="server" />
                            <div class="fileTools" style="width:310px">
                                <input type="text" class="input w160 filedisplay" />
                                <a href="javascript:;" class="files">
                                    <input id="File1" type="file" class="upload" onchange="_upfile(this,'0')" runat="server" /></a>
                                <span class="uploading">上传中</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="right" >
                        组织机构代码证：
                    </td>
                    <td>
                        <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Company, ECommon.QueryId, TREC.Entity.EnFilePath.Organization)%>">
                            <asp:HiddenField ID="hforganization" runat="server" />
                            <div class="fileTools" style="width:310px">
                                <input type="text" class="input w160 filedisplay" />
                                <a href="javascript:;" class="files">
                                    <input id="File2" type="file" class="upload" onchange="_upfile(this,'0')" runat="server" /></a>
                                <span class="uploading">上传中</span>
                        </div>
                    </td>
                </tr>
                </table>
            </td>
            <td width="380px" valign="top">
                 <table class="formTable" width="380px">
                    <tr>
                        <th colspan="2">联系信息：</th>
                    </tr>
                    <tr>
                        <td align="right"  width="70px" >地区：</td>
                        <td>
                          <asp:DropDownList ID="ddlPro" Width="75" runat="server" CssClass="select">
                </asp:DropDownList>
                <asp:DropDownList ID="drop_city" Width="75" runat="server" >
                </asp:DropDownList>
                <select name="drop_areacode"  id="drop_areacode" style="width:75px;" class="select selectNone">
                             <%=ViewState["droploadcity"].ToString()%>
                            </select>
                           <%-- <div class="_droparea" id="ddlareacode" title="<%=areaCode %>"></div>--%>
                        </td>
                    </tr>
                    <tr>
	                    <td align="right">地址：</td>
	                    <td ><asp:TextBox id="txtaddress" runat="server" CssClass="input w250 required"></asp:TextBox></td>
                    </tr>
	                <tr >
	                    <td  align="right">联系人：</td>
	                    <td ><asp:TextBox id="txtlinkman" runat="server" CssClass="input w160"></asp:TextBox></td>
                    </tr>
                     <tr>
                         <td align="right">
                             手机 ：
                         </td>
                         <td>
                             <asp:TextBox ID="txtmphone" runat="server" CssClass="input w160"></asp:TextBox>
                         </td>
                     </tr>
                     <tr>
                         <td align="right">
                             电话 ：
                         </td>
                         <td>
                             <asp:TextBox ID="txtphone" runat="server" CssClass="input w160"></asp:TextBox>
                         </td>
                     </tr>
                     <tr>
                         <td align="right">
                             传真 ：
                         </td>
                         <td>
                             <asp:TextBox ID="txtfax" runat="server" CssClass="input w160"></asp:TextBox>
                         </td>
                     </tr>
                     <tr>
                         <td align="right">
                             邮箱 ：
                         </td>
                         <td>
                             <asp:TextBox ID="txtemail" runat="server" CssClass="input w160"></asp:TextBox>
                         </td>
                     </tr>
                     <tr>
                         <td align="right">
                             邮编 ：
                         </td>
                         <td>
                             <asp:TextBox ID="txtpostcode" runat="server" CssClass="input w160"></asp:TextBox>
                         </td>
                     </tr>
                     <tr>
                         <td align="right">
                             主页 ：
                         </td>
                         <td>
                             <asp:TextBox ID="txthomepage" runat="server" CssClass="input w160"></asp:TextBox>
                         </td>
                     </tr>
                </table>
                <div class="spClear"></div>

                 <table class="formTable" width="380">
                    <tr>
                        <th colspan="2">图片信息:</th>
                    </tr>
                   <%-- <tr>
                        <td align="right" valign="top">形&nbsp;象&nbsp;&nbsp;图：</td>
                        <td>
                            <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Company, ECommon.QueryId, TREC.Entity.EnFilePath.Surface)%>">
                                <asp:HiddenField ID="hfsurface" runat="server" />
                                <div class="fileTools">
                                    <input type="text" class="input w160 filedisplay"  />
                                    <a href="javascript:;" class="files"><input type="file" class="upload" onchange="_upfile(this)"  runat="server" /></a>
                                    <span class="uploading">正在上传，请稍后……</span>
                                </div>
                            </div>
                        </td>
                    </tr>--%>
                    <tr>
                        <td width="70px" align="right">企业标志：</td>
                        <td>
                            <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Company, ECommon.QueryId, TREC.Entity.EnFilePath.Logo)%>">
                                <asp:HiddenField ID="hflogo" runat="server"  />
                                <div class="fileTools">
                                    <input type="text" class="input w160 filedisplay" />
                                    <a href="javascript:;" class="files"><input  type="file" class="upload" onchange="_upfile(this,'0')"  runat="server" /></a>
                                    <span class="uploading">正在上传，请稍后……</span>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">缩&nbsp;略&nbsp;&nbsp;图：</td>
                        <td>
                            <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Company, ECommon.QueryId, TREC.Entity.EnFilePath.Thumb)%>">
                                <asp:HiddenField ID="hfthumb" runat="server" />
                                <div class="fileTools">
                                    <input type="text" class="input w160 filedisplay" />
                                    <a href="javascript:;" class="files"><input type="file" class="upload" onchange="_upfile(this,'0')"  runat="server" /></a>
                                    <span class="uploading">正在上传，请稍后……</span>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">形象展示：</td>
                        <td>
                            <div class="fileUpload m" path="<%=string.Format(TREC.Entity.EnFilePath.Company, ECommon.QueryId, TREC.Entity.EnFilePath.Banner)%>">
                                <asp:HiddenField ID="hfbannel" runat="server" />
                                <div class="fileTools">
                                    <input type="text" class="input w160 filedisplay" />
                                    <a href="javascript:;" class="files"><input type="file" class="upload" onchange="_upfile(this)"  runat="server" /></a>
                                    <span class="uploading">正在上传，请稍后……</span>
                                </div>
                            </div>
                        </td>
                    </tr>
                   <%-- <tr>
                        <td align="right">企业展示：</td>
                        <td>
                            <div class="fileUpload m" path="<%=string.Format(TREC.Entity.EnFilePath.Company, ECommon.QueryId, TREC.Entity.EnFilePath.DesImage)%>">
                                <asp:HiddenField ID="hfdesimage" runat="server" />
                                <div class="fileTools">
                                    <input type="text" class="input w160 filedisplay" />
                                    <a href="javascript:;" class="files"><input type="file" class="upload" onchange="_upfile(this)"  runat="server" /></a>
                                    <span class="uploading">正在上传，请稍后……</span>
                                </div>
                            </div>
                        </td>
                    </tr>--%>
                </table>
            </td>
            <td valign="top">
                 <table class="formTable" width="380">
                    <tr>
                        <th colspan="2">优化及配置：</th>
                    </tr>
                    <tr>
                        <td width="70px" align="right">关&nbsp;键&nbsp;&nbsp;字：</td>
                        <td><asp:TextBox id="txtkeywords" TextMode="MultiLine" Width="250px" Height="200px" runat="server" CssClass="input w160"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td></td>
                    <td ><span style="color:red;">↑ 格式：title | keywords | description</span></td>
                     </tr>
                    <tr>
                        <td align="right">配置域名：</td>
                        <td><asp:TextBox id="txtdomain" runat="server" CssClass="input w160"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td align="right">配置IP：</td>
                        <td><asp:TextBox id="txtdomainip" runat="server" CssClass="input w160"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td align="right">ICP备案：</td>
                        <td><asp:TextBox id="txticp" runat="server" CssClass="input w160"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">企业风格：</td>
                        <td><asp:DropDownList ID="ddltemplate" runat="server"></asp:DropDownList></td>
                    </tr>
                </table>
                <div class="spClear"></div>
                <table class="formTable" width="380">
                    <tr>
                        <th colspan="2">企业描述:</th>
                    </tr>
                    <tr>
                        <td colspan="2"><asp:TextBox id="txtdescript" runat="server" CssClass="textarea required" TextMode="MultiLine" Rows="5" Width="360"></asp:TextBox></td>
                    </tr>
                </table>
                
                
                <div class="spClear"></div>
                <table class="formTable" width="380">
                    <tr>
                        <th colspan="2">企业状态:</th>
                    </tr>
                    <tr>
                        <td  width="90px" align="right">审核：</td>
                        <td><asp:DropDownList ID="ddlauditstatus" runat="server" CssClass="select selectNone" Width="160"></asp:DropDownList></td>
                    </tr>
                    
                    <tr>
                        <td align="right">上/下线：</td>
                        <td><asp:DropDownList ID="ddllinestatus" runat="server" CssClass="select selectNone" Width="160"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="right">
                            排序 ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtsort" runat="server" CssClass="input w160 required digits">0</asp:TextBox>
                        </td>
                    </tr>
                    <%if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
                  { %>
                    <tr>
                        <td align="right">
                            点击量 ：
                        </td>
                        <td>
                            <asp:TextBox ID="txthits" runat="server" CssClass="input w160 required digits">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            最后修改 ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtlastedittime" runat="server" CssClass="input Wdate w160 required" onfocus="WdatePicker()"></asp:TextBox>
                        </td>
                    </tr>
                <%} %>
                </table>
            </td>
        </tr>
    </table>
    
    <div style="margin-top:10px; margin-left:180px">
  <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" 
            onclick="btnSave_Click" /><input name="重置" type="reset" class="submit" value="重置" />
</div>

<script language="javascript" type="text/javascript">
    $("#ddlPro").live("change", function () {
        if ($(this).val() != "" && $(this).val() != "0") {
            $("#drop_city").html("<option selected='selected' value='0'>--城市--</option>");
            $.ajax({
                url: "/ajaxtools/ajaxarea.ashx",
                data: "type=c&p=" + $(this).val(),
                success: function (data) {
                    $("#drop_city").html(data);
                    $("#drop_areacode").html("<option selected='selected' value='0'>--区--</option>");
                },
                error: function (d, m) {
                    alert(m);
                }
            });
        }
    })

    $("#drop_city").live("change", function () {
        if ($(this).val() != "" && $(this).val() != "0") {
            $("#drop_areacode").html("<option selected='selected' value='0'>--区--</option>");
            $.ajax({
                url: "/ajaxtools/ajaxarea.ashx",
                data: "type=c&p=" + $(this).val(),
                success: function (data) {
                    $("#drop_areacode").html(data);
                },
                error: function (d, m) {
                    alert(m);
                }
            });
        }
    })


    $("#drop_areacode").live("change", function () {
        if ($(this).val() != "" && $(this).val() != "0") {
            $("#ddlareacode_value").val($(this).val());
            loadDdlMarket();
        }
    })


    function getArea(pcode, checkcode, title, id) {
        $.get("/ajax/GetArea.aspx?pcode=" + pcode + "&checkcode=" + checkcode, '', function (data, textStatus) {
            $("#" + id).html(title + data);
        }, null);
    }

    function selPArea() {
        var pid = $("#drop_city").val();
        if (pid != '') {
            getArea(pid, '', '', 'drop_areacode');
        }
        else {
            $("#drop_areacode").html("<option selected=\"selected\" value=\"0\">--区--</option>")
        }
    }

    </script>

</form>
</body>
</html>
