<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_companyproduct.ascx.cs"
    Inherits="TREC.Web.aspx.ascx._shopproduct" %>
    <%@ Import Namespace="TREC.ECommerce" %>
    <style type="text/css">
     .cont-r-t{background:url(/resource/content/img/seller/a2.jpg) repeat-x 0 0;color:#939393;line-height:34px;height:34px;margin-bottom:1px;font-size:14px;font-weight:bold;}
    </style>
     <div class="cont-r-t"><center>一共<%=Procount%>个产品</center>
 </div>
<div class="homebraRight1">
    <div class="homebraRight11" style="height:auto;">
        <p class="bra-xz">
            <select name="pi_brand" id="pi_brand" onchange="ProductListChange()">
            </select>
        </p>
        <p class="bra-xz">
            <select name="pi_brands" id="pi_brands" onchange="ProductListChange()">
            </select>
        </p>
        <p class="bra-xz">
            <select name="pi_pcategory" id="pi_pcategory" onchange="ProductListChange()">
            </select>
        </p>
        <p class="bra-xz">
            <input name="" type="text" id="s_post_value" />
        </p>
        <div class="homebraLi23">
            <a href="#" id="s_post_id">搜索产品</a></div>

            <ul class="homebraRight12" id="pi_categorylist" ></ul>
    </div>
    
</div>
<script type="text/javascript">
    function ProductListChange()
    {
         var brandid=$("#pi_brand").val();
         var brandids=$("#pi_brands").val();
         var pcategory=$("#pi_pcategory").val();

         window.location="/shop/<%=ECommon.QuerySId %>/product-"+brandid+"--------1--"+pcategory+"---"+brandids+".aspx";
    }
    var brandid = '<%=brandid %>';
    categoryChange();
    
    function categoryChange() {
        if (($("#pi_brand").val() == "" || $("#pi_brand").val() == null) && ($("#pi_brands").val() == "" || $("#pi_brands").val() == null) && ($("#pi_pcategory").val() == "" || $("#pi_pcategory").val() == null)) {
            $("#pi_brand,#pi_brands,#pi_pcategory").html("");
            $("#pi_brand").append("<option value=>----所有品牌----</option>");
            $("#pi_brands").append("<option value=>----所有系列----</option>");
            $("#pi_pcategory").append("<option value=>----所有分类----</option>");
            $("#pi_categorylist").html("").hide().show().html("");
        }

        $.ajax({
            url: "<%=TREC.ECommerce.ECommon.WebUrl %>/ajax/ajaxproduct.ashx",
            data: "type=getshopproductsearchitem&v=" + $("#pi_brand").val() + "&v2=" + $("#pi_brands").val() + "&v3=" + $("#pi_pcategory").val() + "&c=<%=TREC.ECommerce.ShopPageBase.shopInfo.id %>",
            dataType: "json",
            success: function (data) {
                if (data != "") 
                {
                    var bo = true;
                    if (($("#pi_brand").val() == "" || $("#pi_brand").val() == null) && ($("#pi_brands").val() == "" || $("#pi_brands").val() == null) && ($("#pi_pcategory").val() == "" || $("#pi_pcategory").val() == null)) 
                    {
                        $.each(data, function (i) {
                            if (data[i].type == "brand") {
                                $("#pi_brand").append("<option value=\"" + data[i].v + "\">" + data[i].n + "</option>");
                            }
                            if (data[i].type == "brands") {
                                $("#pi_brands").append("<option value=\"" + data[i].v + "\">" + data[i].n + "</option>");
                            }
                            if (data[i].type == "pcategory") {
                                $("#pi_pcategory").append("<option value=\"" + data[i].v + "\">" + data[i].n + "</option>");
                            }
                        });
                        if ("<%=TREC.ECommerce.ECommon.QuerySearchPCategory %>" != "") {
                            $("#pi_pcategory").val("<%=TREC.ECommerce.ECommon.QuerySearchPCategory %>");
                        }
                        if ("<%=TREC.ECommerce.ECommon.QuerySearchBrand %>" != "") {
                        var sb='<%=TREC.ECommerce.ECommon.QuerySearchBrand.ToLower()%>';
                        if(sb.indexOf("_a")>=0)
                        {
                            sb=sb.replace("_a", "");
                        }
                        else if(sb.indexOf("_b")>=0)
                        {
                            sb=sb.replace("_b", "");
                        }
                        else
                        {
                            sb='<%=TREC.ECommerce.ECommon.QuerySearchBrand %>';
                        }
                            $("#pi_brand").val(sb);
                        }
                        if ("<%=TREC.ECommerce.ECommon.QuerySearchBrands %>" != "") {
                            $("#pi_brands").val("<%=TREC.ECommerce.ECommon.QuerySearchBrands %>");
                        }

                        $.ajax({
                            url: "<%=TREC.ECommerce.ECommon.WebUrl %>/ajax/ajaxproduct.ashx",
                            data: "type=getshopproductsearchitem&v=" + $("#pi_brand").val() + "&v2=" + $("#pi_brands").val() + "&v3=" + $("#pi_pcategory").val() + "&c=<%=TREC.ECommerce.ShopPageBase.shopInfo.id %>",
                            dataType: "json",
                            success: function (data) 
                            {
                                if (data != "")
                                {
                                    var bo = true;
                                    $.each(data, function (i) 
                                    {
                                        if (data[i].type == "category") 
                                        {
                                            if(bo){
                                                if("<%=TREC.ECommerce.ShopPageBase.setvalue %>"=="-1"){
                                                    $("#pi_categorylist").append("<li><a style=\"color:Red;font-weight:bold;\" href=\"<%=TREC.ECommerce.ECommon.WebUrl %>shop/" + <%=TREC.ECommerce.ShopPageBase.shopInfo.id %> + "/product.aspx\">所有类型</a></li>");
                                                }
                                                else{
                                                    $("#pi_categorylist").append("<li><a href=\"<%=TREC.ECommerce.ECommon.WebUrl %>shop/" + <%=TREC.ECommerce.ShopPageBase.shopInfo.id %> + "/product.aspx\">所有类型</a></li>");
                                                }
                                                bo=false;

                                                $("#pi_categorylist").append("<li><a  href=\"<%=TREC.ECommerce.ECommon.WebUrl %>shop/" + <%=TREC.ECommerce.ShopPageBase.shopInfo.id %> + "/producttzh.aspx\">套组合</a></li>");
                                            }
                                            
                                            if("<%=TREC.ECommerce.ShopPageBase.setvalue %>"==data[i].v){
                                                $("#pi_categorylist").append("<li><a style=\"color:Red;font-weight:bold;\" href=\"<%=TREC.ECommerce.ECommon.WebUrl %>shop/" + <%=TREC.ECommerce.ShopPageBase.shopInfo.id %> + "/product---------1--" + data[i].pc + "-"+data[i].v+"--"+$("#pi_brands").val()+".aspx\">" + data[i].n + "(" + data[i].count + ")</a></li>");
                                             }
                                            else{
                                                $("#pi_categorylist").append("<li><a href=\"<%=TREC.ECommerce.ECommon.WebUrl %>shop/" + <%=TREC.ECommerce.ShopPageBase.shopInfo.id %> + "/product---------1--" + data[i].pc + "-"+data[i].v+"--"+$("#pi_brands").val()+".aspx\">" + data[i].n + "(" + data[i].count + ")</a></li>");
                                            }
                                        }
                                    });
                                }
                            }
                        });
                    } else {
                        $("#pi_categorylist").html("").hide().show().html("");
                        $.each(data, function (i) {
                            if (data[i].type == "category") {

 
                                if(bo)
                                {
                                    if("<%=TREC.ECommerce.ShopPageBase.setvalue %>"=="-1")
                                    {
                                        $("#pi_categorylist").append("<li><a style=\"color:Red;font-weight:bold;\" href=\"<%=TREC.ECommerce.ECommon.WebUrl %>shop/" + <%=TREC.ECommerce.ShopPageBase.shopInfo.id %> + "/product.aspx\">所有类型</a></li>");
                                    }
                                    else
                                    {
                                        $("#pi_categorylist").append("<li><a href=\"<%=TREC.ECommerce.ECommon.WebUrl %>shop/" + <%=TREC.ECommerce.ShopPageBase.shopInfo.id %> + "/product.aspx\">所有类型</a></li>");
                                    }
                                    bo=false;

                                     $("#pi_categorylist").append("<li><a  href=\"<%=TREC.ECommerce.ECommon.WebUrl %>shop/" + <%=TREC.ECommerce.ShopPageBase.shopInfo.id %> + "/producttzh.aspx\">套组合</a></li>");
                                }
                               
                               if("<%=TREC.ECommerce.ShopPageBase.setvalue %>"==data[i].v)
                                {
                                    $("#pi_categorylist").append("<li><a style=\"color:Red;font-weight:bold;\" href=\"<%=TREC.ECommerce.ECommon.WebUrl %>shop/" + <%=TREC.ECommerce.ShopPageBase.shopInfo.id %> + "/product---------1--" + data[i].pc + "-"+data[i].v+".aspx\">" + data[i].n + "(" + data[i].count + ")</a></li>");
                                }
                                else
                                {
                                    $("#pi_categorylist").append("<li><a href=\"<%=TREC.ECommerce.ECommon.WebUrl %>shop/" + <%=TREC.ECommerce.ShopPageBase.shopInfo.id %> + "/product---------1--" + data[i].pc + "-"+data[i].v+".aspx\">" + data[i].n + "(" + data[i].count + ")</a></li>");
                                }
                            }
                        });
                    }
                }
            }
        });
    }
    $(document).ready(function () {
        $("#s_post_id").bind("click",function(){
            var postvalue =$.trim($("#s_post_value").val());
            if(postvalue=="")
            {
                $("#s_post_value").focus();
                alert("对不起，请先输入要搜索的内容！");

            }
            else
            {
                postvalue = postvalue.replace(/[ ]/g, "_");
                window.location="product---------1----"+postvalue+".aspx";
            }
        });
    });
    
</script>
