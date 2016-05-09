<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_AreaSelect.ascx.cs" Inherits="TREC.Web.aspx.ascx._AreaSelect" %>
<%@ Import Namespace="TRECommon" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<input type="text" value=" " runat="server" id="SelectedValue" name="SelectedValue" style="display:none" /><input type="hidden" value="<%=selectedAreaName%>" id="SelectedText" name="SelectedText" />
<input type="hidden" value="" id="Selectedvalue" name="Selectedvalue" />
<span id="<%=ClientID%>Panel"></span>
<%if (Page.Items["AreaSelectScriptKey"] == null)
  {
      Page.Items["AreaSelectScriptKey"] = true;
      %>
<script>
    function SelectElement(AreaPanel) {
        var select;
        var selectIndex = -1;
        this.createSelect = function () {
            select = document.createElement("select");
            select.onchange = this.onChange;
            AreaPanel.appendChild(select);
            select.options.add(new Option("加载中", ""));
            selectIndex++;
        }
        this.fillOption = function (splitString) {
            var selectedValue = null;
            var pathArray = this.selectedPath.split('|');
            var areaArray = splitString.split('|');
            if (areaArray.length > 0 && select.options.length > 0)
                select.options[0].text = "请选择";

            for (var i = 0; i < areaArray.length; i += 2) {
                select.options.add(new Option(areaArray[i], areaArray[i + 1]));
                if (areaArray[i + 1].split('$')[0] == pathArray[selectIndex] && selectedValue == null) {
                    selectedValue = areaArray[i + 1];
                }
            }

            if (selectedValue != null) {
                $(select).val(selectedValue).trigger('change');
            }
        }
        this.getSelectedItem = function () {
            var $selects = $(AreaPanel).find('select[value!=""]');
            if ($selects.length > 0) {
                var el = $selects.last()[0];
                return el.options[el.selectedIndex];
            }
        }
        this.deleteSelect = function (e) {
            var nodes = AreaPanel.childNodes;
            for (var i = nodes.length - 1; i > -1; i--) {
                if (e == nodes[i]) {
                    selectIndex = i;
                    return;
                }
                AreaPanel.removeChild(AreaPanel.childNodes[i]);
                selectIndex--;
            }
        }
    }
</script>
<%}%>
<script>
    $(function () {
        var self = {
            select: new SelectElement(document.getElementById("<%=ClientID%>Panel")),
            valueField: document.getElementById("<%=SelectedValue.ClientID%>"),
            textField: document.getElementById("SelectedText"),
            oneList: '',
            load: function (path) {
                self.select.deleteSelect();
                self.select.selectedPath = path;
                self.select.createSelect();
                self.select.fillOption(self.oneList);
            },
            loadOptions: function (e) {
                self.select.deleteSelect(e);
                if (e.value == "") return;
                var valueArray = e.value.split('$');
                if (valueArray[1] == "0") return;
                self.select.createSelect();
                $.get('/ajax/search.ashx?type=getarealist&areaId=' + valueArray[0], null, function (result) {
                    if (result != "") {
                        self.select.fillOption(result);
                    }
                    else {
                        self.select.deleteSelect(e);
                    }
                });
            },
            init: function () {
                self.select.onChange = function () {
                    var el = this;
                    if (el.value == '') {
                        var $prev = $(el).prev();
                        el = $prev.length > 0 ? $prev[0] : null;
                    }
                    if (el) {
                        var item = el.options[el.selectedIndex];
                        self.valueField.value = item.value.split('$')[0];
                        self.textField.value = item.text;
                        document.getElementById("Selectedvalue").value = item.value;
                    } else {
                        self.valueField.value = '0';
                        self.textField.value = '';
                    }
                    self.loadOptions(this);
                }
                self.oneList = '<%=getAreaSplit("0")%>';
                self.load("<%=selectedPath%>");
            }
        };

        self.init();

        window["<%=ClientID%>"] = self;
    });
</script>
<asp:RequiredFieldValidator ID="RV1" runat="server" ControlToValidate="SelectedValue" ErrorMessage="请选择地区" SetFocusOnError="true" Display="None" Visible="false"></asp:RequiredFieldValidator>