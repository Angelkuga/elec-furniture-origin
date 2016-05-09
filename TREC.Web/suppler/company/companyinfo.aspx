<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Member.Master" CodeBehind="companyinfo.aspx.cs" Inherits="TREC.Web.Suppler.company.companyinfo" EnableEventValidation="false" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ MasterType VirtualPath="../Member.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="../script/formValidator-4.1.1.js" charset="UTF-8"></script>
    <script type="text/javascript" src="../script/formValidatorRegex.js" charset="UTF-8"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery.area.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/editor/kindeditor/kindeditor-min.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/fileupload.js"></script>
    <script type="text/javascript" language="javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery.poshytip.min.js"></script>
    <script type="text/javascript" src="../script/myPublic.js"></script>
    <script type="text/javascript" src="../script/pageValitator/company-setup1.js"></script>
    <script type="text/javascript">
        $(function () {        
            var editor;
            KindEditor.ready(function (K) {
                editor = K.create('#<%=txtdescript.ClientID %>', {
                    allowPreviewEmoticons: true,
                    allowImageUpload: true,
                    allowFileManager: true,
                    <%if (TREC.ECommerce.ECommon.QueryId != "" && TREC.ECommerce.ECommon.QueryEdit != "")
                    { %>
                     fileManagerJson:"<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/editor/kindeditor/ashx/file_manager_json.ashx?m=company&id=<%=TREC.ECommerce.ECommon.QueryId %>",
                    <%} %>
                    allowMediaUpload: true,
                    items: [
						'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|', 'image', 'flash', 'media', 'link', 'fullscreen']
                });
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="maintitle"><h1><u>基本信息</u></h1></div> 
<div class="maincon">
  <div class="maintabcor">
    <table width="100%" cellspacing="0" cellpadding="0" border="0">
      <tbody><tr>
        <td align="right" height="35"><%if (memberType == 103) { Response.Write("卖场"); } else { Response.Write("工厂"); } %>名称</td>
        <td class="textleft" colspan="3"><input type="text" size="50" maxlength="200" name="myName" value="<%=myName %>" /></td>
      </tr>      
      <tr>
        <td align="right" height="35" >
       <%if (memberType == 103) { Response.Write("卖场"); } else { Response.Write("工厂"); } %>地址
       </td>
       <td colspan="3">
        <div class=""  style="float:left;">
         <asp:DropDownList ID="ddlPro" runat="server" CssClass="select" Width="60">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlregcity" runat="server" CssClass="select selectNone"  Width="60">
                </asp:DropDownList>
                <select name="selArea"  id="selArea" style="width:60px;">
                             <%=droparea%>
                            </select>
        </div>
        <div style="float:left;padding-left:5px;">
        <input type="text" size="46" value="<%=address %>" maxlength="200" name="Address" />
       </div>
        </td>
      </tr>
      <tr>
        <td align="right" height="35">邮编</td>
        <td class="textleft" colspan="3"><input type="text" size="26" value="<%=postcode %>" maxlength="6" name="Post" /></td>
      </tr>
      
      <tr>
        <td align="right" height="35">员工规模</td>
        <td class="textleft" ><asp:DropDownList ID="ddlstaffsize" runat="server"></asp:DropDownList></td>
        <td align="right" height="35">品牌</td>
        <td class="textleft"><input type="text" size="26" maxlength="20" value="<%=BrandInfo %>" name="BrandInfo" /></td>
      </tr>
      <tr>
        <td align="right" height="35" colspan="4"><div class="bordtop"></div></td>
      </tr>
      <tr>
        <td width="130" align="right" height="35">联系人</td>
        <td width="241" class="textleft"><input type="text" size="26" maxlength="20" value="<%=linkman %>" name="Contact" /></td>
        <td width="94" align="right">职位</td>
        <td width="285" class="textleft"><input type="text" size="26" maxlength="50" value="<%=Duty %>" name="Duty"></td>
      </tr>
      <tr>
        <td align="right" height="35"> 手机</td>
        <td class="textleft"><input type="text" size="26" maxlength="20" value="<%=mphone %>" name="Mobile"></td>
        <td align="right">电话(对外公布)</td>
        <td class="textleft"><input type="text" size="26" maxlength="20" value="<%=phone %>" name="Tel"></td>
      </tr>
      <tr>
        <td align="right" height="35">QQ/微博</td>
        <td class="textleft"><input type="text" size="26" maxlength="100" value="<%=QQWeiBo %>" name="QQWeiBo"></td>
        <td align="right">传真</td>
        <td class="textleft"><input type="text" size="26" maxlength="30" value="<%=fax %>" name="Fax"></td>
      </tr>
      <tr>
        <td align="right" height="35">E-mail</td>
        <td class="textleft"><input type="text" size="26" maxlength="50" value="<%=email %>" name="Email"></td>
        <td align="right">网址</td>
        <td class="textleft"><input type="text" size="26" maxlength="200" value="<%=homepage %>" name="Website"></td>
      </tr>
      <tr>
        <td align="right" height="35"><%if (memberType == 103) { Response.Write("卖场"); } else { Response.Write("工厂"); } %>负责人</td>
        <td class="textleft"><input type="text" size="26" value="<%=cPerson %>" maxlength="20" name="cPerson"></td>
        <td align="right"></td>
        <td class="textleft">
        <div style="display:none;">
        <input type="text" size="26" value="<%=ContactType %>" maxlength="500" name="ContactType">
        </div>
        </td>
      </tr>
      <tr>
        <td align="right" height="35" colspan="4"><div class="bordtop"></div></td>
      </tr>
      <tr>
        <td align="right" height="35">营业执照</td>
        <td>
            <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Company, companyInfo.id, TREC.Entity.EnFilePath.License)%>">
                <asp:HiddenField ID="hflicense" runat="server" />
                <div class="fileTools">
                    <input type="text" class="input w160 filedisplay" />
                    <a href="javascript:;" class="files">
                        <input id="Fileone" type="file" class="upload" onchange="_upfile(this,'0')" runat="server" /></a>
                    <span class="uploading">上传中</span>
                </div><label></label>
            </div>
        </td>
        <td align="right">税务登记证</td>
        <td>
            <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Company, companyInfo.id, TREC.Entity.EnFilePath.Registration)%>">
                <asp:HiddenField ID="hfregistration" runat="server" />
                <div class="fileTools">
                    <input type="text" class="input w160 filedisplay" />
                    <a href="javascript:;" class="files">
                        <input id="File1" type="file" class="upload" onchange="_upfile(this,'0')" runat="server" /></a>
                    <span class="uploading">上传中</span>
                </div><label></label>
            </div>
        </td>
      </tr>
      <tr>
        <td align="right" height="35" valign="top">组织机构代码证</td>
        <td  valign="top">
            <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Company, companyInfo.id, TREC.Entity.EnFilePath.Organization)%>">
                <asp:HiddenField ID="hforganization" runat="server" />
                <div class="fileTools">
                    <input type="text" class="input w160 filedisplay" />
                    <a href="javascript:;" class="files">
                        <input id="File2" type="file" class="upload" onchange="_upfile(this,'0')" runat="server" /></a>
                    <span class="uploading">上传中</span>
                </div><label></label>
            </div>
        </td>
        <td align="right"  valign="top" style="width:120px;">厂商首页广告大图</td>
        <td>
            <%--<div class="fileUpload m" path="<%=string.Format(TREC.Entity.EnFilePath.Company, companyInfo.id, TREC.Entity.EnFilePath.Banner)%>">
                <asp:HiddenField ID="hfbannel" runat="server" />
                <div class="fileTools">
                    <input type="text" class="input w160 filedisplay" />
                    <a href="javascript:;" class="files">
                        <input id="File4" type="file" class="upload" onchange="_upfile(this)" runat="server" /></a>
                    <span class="uploading">上传中</span>
                </div><label></label>
            </div>--%>
            <div class="fileUpload m" path="<%=string.Format(TREC.Entity.EnFilePath.Company, companyInfo.id, TREC.Entity.EnFilePath.Banner)%>">
                            <asp:HiddenField ID="hfbannel" runat="server" />
                            <div class="fileTools" style="width:210px">
                                <input type="text" class="input w160 filedisplay" />
                                <a href="javascript:;" class="files">
                                    <input id="File4" type="file" class="upload" onchange="_upfile(this)" runat="server" /></a>
                                <span class="uploading">上传中</span>
                            </div>
                        </div><label>请传多张体现产品风格的图，宽947×高449像素</label>
        </td>
      </tr>
      <tr>
        <td align="right" height="35">&nbsp;</td>
        <td colspan="3"><span class="nortip" style="display:none;">（注：以上证件也可将盖有公章的复印件传真至021-66240323）</span></td>
      </tr>   
      <tr>
        <td align="right"><%if (memberType == 103) { Response.Write("卖场"); } else { Response.Write("工厂"); } %>介绍 ：</td>
        <td colspan="3"><asp:TextBox ID="txtdescript" runat="server" CssClass="textarea required" TextMode="MultiLine" Rows="5" Width="600" Height="200"></asp:TextBox></td>
    </tr>
    <tr><td colspan="4"><div class="btnone"><asp:Button ID="Button1" runat="server" CssClass="btnl" OnClientClick="return checkBasicInformation();" Text="提 交" onclick="btnSave_Click" /><input type="reset" value="重 填" class="btnr" /></div></td></tr>
    </tbody></table>
  </div>
</div>

<script language="javascript" type="text/javascript">
    $("#ctl00_ContentPlaceHolder1_ddlPro").live("change", function () {
        if ($(this).val() != "" && $(this).val() != "0") {
            $("#ctl00_ContentPlaceHolder1_ddlregcity").html("<option selected='selected' value='0'>--区--</option>");
            $.ajax({
                url: "/ajaxtools/ajaxarea.ashx",
                data: "type=c&p=" + $(this).val(),
                success: function (data) {
                    $("#ctl00_ContentPlaceHolder1_ddlregcity").html(data);
                    $("#selArea").html("<option selected='selected' value='0'>--区--</option>");
                },
                error: function (d, m) {
                    alert(m);
                }
            });
        }
    })

    $("#ctl00_ContentPlaceHolder1_ddlregcity").live("change", function () {
        if ($(this).val() != "" && $(this).val() != "0") {
            $.ajax({
                url: "/ajaxtools/ajaxarea.ashx",
                data: "type=c&p=" + $(this).val(),
                success: function (data) {
                    $("#selArea").html(data);
                },
                error: function (d, m) {
                    alert(m);
                }
            });
        }
    })

    function getArea(pcode, checkcode, title, id) {
        $.get("/ajax/GetArea.aspx?pcode=" + pcode + "&checkcode=" + checkcode, '', function (data, textStatus) {
            $("#" + id).html(title + data);
        }, null);
    }

    function selPArea() {
        var pid = $("#ctl00_ContentPlaceHolder1_ddlregcity").val();
        if (pid != '') {
            getArea(pid, '', '', 'selArea');
        }
        else {
            $("#selArea").html("<option selected=\"selected\" value=\"0\">--区--</option>")
        }
    }
</script>
</asp:Content>