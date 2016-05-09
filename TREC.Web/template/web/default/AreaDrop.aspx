<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AreaDrop.aspx.cs" Inherits="TREC.Web.template.web.AreaDrop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" type="text/javascript" src="/resource/script/jquery-1.7.1.min.js"></script>
</head>
<body style="margin-left:0px;margin-top:0px;padding-left:0px;padding-top:0px;">
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0"><tr>
    <td> <asp:DropDownList ID="ddlPro" runat="server" CssClass="select" Width="75">
                </asp:DropDownList></td>
                <td style="padding-left:3px;"> 
                 <asp:DropDownList ID="ddlregcity" runat="server" CssClass="select selectNone" Width="75">
                </asp:DropDownList>
                </td><td style="padding-left:3px;">
                 <select name="ddlareacode_district"  id="ddlareacode_district" style="width:75px;">
                           <option value="0">--区--</option>
                            </select>
                </td> </tr> </table>
    </form>

    <script language="javascript" type="text/javascript">
        $("#ddlPro").live("change", function () {
            if ($(this).val() != "" && $(this).val() != "0") {
                $("#ddlregcity").html("<option selected='selected' value='0'>--城市--</option>");
                $.ajax({
                    url: "/ajaxtools/ajaxarea.ashx",
                    data: "type=c&p=" + $(this).val(),
                    success: function (data) {
                        $("#ddlregcity").html(data);
                        $("#ddlareacode_district").html("<option selected='selected' value='0'>--区--</option>");
                    },
                    error: function (d, m) {
                        alert(m);
                    }
                });
            }
        })

        $("#ddlregcity").live("change", function () {
            if ($(this).val() != "" && $(this).val() != "0") {
                $("#ddlareacode_district").html("<option selected='selected' value='0'>--区--</option>");
                $.ajax({
                    url: "/ajaxtools/ajaxarea.ashx",
                    data: "type=c&p=" + $(this).val(),
                    success: function (data) {
                        $("#ddlareacode_district").html(data);
                    },
                    error: function (d, m) {
                        alert(m);
                    }
                });
            }
        })


        $("#ddlareacode_district").live("change", function () {
            if ($(this).val() != "" && $(this).val() != "0") {
                window.parent.document.getElementById("<%=txtname %>").value = $("#ddlPro").val() + ',' + $("#ddlregcity").val() + "," + $(this).val();
            }
        })


        function getArea(pcode, checkcode, title, id) {
            $.get("/ajax/GetArea.aspx?pcode=" + pcode + "&checkcode=" + checkcode, '', function (data, textStatus) {
                $("#" + id).html(title + data);
            }, null);
        }

        function selPArea() {
            var pid = $("#ddlregcity").val();
            if (pid != '') {
                getArea(pid, '', '', 'ddlareacode_district');
            }
            else {
                $("#ddlareacode_district").html("<option selected=\"selected\" value=\"0\">--区--</option>")
            }
        }

        var chi = 0;
        $(document).ready(function () {
            if (chi == 0) {
                var v = window.parent.document.getElementById("<%=txtname %>").value;
                if (v != '') {
                    getArea("0", v.split(',')[0], "", "ddlPro");
                    getArea(v.split(',')[0], v.split(',')[1], "", "ddlregcity");
                    getArea(v.split(',')[1], v.split(',')[2], "", "ddlareacode_district");
                    chi = 1;
                }
                //  alert(v.split(',')[0]);
            }
        });
      
    </script>

</body>
</html>
