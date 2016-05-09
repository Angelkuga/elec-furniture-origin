<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_companyproduct.ascx.cs"
    Inherits="TREC.Web.aspx.ascx._companyproduct" %>
<div class="homebraRight1">
    <div class="homebraRight11">
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
        <ul class="homebraRight12" id="pi_categorylist"></ul>
        <p class="bra-xz">
            <input name="" id="post_value" type="text" />
            <a href="#" id="post_id">搜索</a>
        </p>
       </div>
    
</div>
<script type="text/javascript">
    function ProductListChange()
    {
         var brandid=$("#pi_brand").val();
         var brandids=$("#pi_brands").val();
         var pcategory=$("#pi_pcategory").val();

         window.location="product-"+brandid+"--------1--"+pcategory+"---"+brandids+".aspx";
    }
    categoryChange();
    function categoryChange() {
        if (($("#pi_brand").val() == "" || $("#pi_brand").val() == null) && ($("#pi_brands").val() == "" || $("#pi_brands").val() == null) && ($("#pi_pcategory").val() == "" || $("#pi_pcategory").val() == null)) 
        {
            $("#pi_brand,#pi_brands,#pi_pcategory").html("");
            $("#pi_brand").append("<option value=>----所有品牌----</option>");
            $("#pi_brands").append("<option value=>----所有系列----</option>");
            $("#pi_pcategory").append("<option value=>----所有分类----</option>");
            $("#pi_categorylist").html("").hide().show().html("");
        }

       

        $.ajax({
            url: "<%=TREC.ECommerce.ECommon.WebUrl %>/ajax/ajaxproduct.ashx",
            data: "type=getcompanyproductsearchitem&v=" + $("#pi_brand").val() + "&v2=" + $("#pi_brands").val() + "&v3=" + $("#pi_pcategory").val() + "&c=<%=companyInfo.id %>",
            dataType: "json",
            success: function (data) {
                
                if (data != "{}" || data!="") {
                var bo = true;
                    if (($("#pi_brand").val() == "" || $("#pi_brand").val() == null) && ($("#pi_brands").val() == "" || $("#pi_brands").val() == null) && ($("#pi_pcategory").val() == "" || $("#pi_pcategory").val() == null)) {
                        $.each(data, function (i) {
                            if (data[i].type == "brand") {
                                $("#pi_brand").append("<option value=\"" + data[i].v + "\">" + data[i].n + "</option>");
                            }
                            if (data[i].type == "pcategory") {
                                $("#pi_pcategory").append("<option value=\"" + data[i].v + "\">" + data[i].n + "</option>");
                            }
                        });
                        if ("<%=TREC.ECommerce.ECommon.QuerySearchPCategory %>" != "") {
                            $("#pi_pcategory").val("<%=TREC.ECommerce.ECommon.QuerySearchPCategory %>");
                        }
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

                        if (sb != "") {
                            $("#pi_brand").val(sb);
                        }
                        if ("<%=TREC.ECommerce.ECommon.QuerySearchBrands %>" != "") {
                            $("#pi_brands").val("<%=TREC.ECommerce.ECommon.QuerySearchBrands %>");
                        }
                       
                        $.ajax({
                           url: "<%=TREC.ECommerce.ECommon.WebUrl %>/ajax/ajaxproduct.ashx",
                           data: "type=getcompanyproductsearchitem&v=" + $("#pi_brand").val() + "&v2=" + $("#pi_brands").val() + "&v3=" + $("#pi_pcategory").val() + "&c=<%=companyInfo.id %>",
                           dataType: "json",
                           success: function (data) 
                           {
                               if (data != "{}" || data!="") 
                               {
                                   $.each(data, function (i) {
                                    if (data[i].type == "brands") 
                                       {
                                           $("#pi_brands").html("").hide().show().html("");
                                           $("#pi_brands").append("<option value=>----所有系列----</option>");

                                        }
                                    });

                                   $.each(data, function (i) {
                                   if (data[i].type == "brands" && data[i].v!=null && data[i].v!="") 
                                   {
                                      $("#pi_brands").append("<option value=\"" + data[i].v + "\">" + data[i].n + "</option>");
                                   }

                                   if (data[i].type == "category") 
                                   {
                                       if(bo)
                                       {
                                           if("<%=TREC.ECommerce.CompanyPageBase.setvalue %>"=="-1")
                                           {
                                               $("#pi_categorylist").append("<li><a style=\"color:Red;font-weight:bold;\" href=\"<%=TREC.ECommerce.ECommon.WebUrl %>company/" + <%=companyInfo.id %> + "/product.aspx\">所有类型</a></li>");
                                           }
                                           else
                                           {
                                               $("#pi_categorylist").append("<li><a href=\"<%=TREC.ECommerce.ECommon.WebUrl %>company/" + <%=companyInfo.id %> + "/product.aspx\">所有类型</a></li>");
                                           }
                                           bo=false;
                                            $("#pi_categorylist").append("<li><a  href=\"<%=TREC.ECommerce.ECommon.WebUrl %>shop/" + <%=companyInfo.id%> + "/producttzh.aspx\">套组合</a></li>");
                                       }
                                       if("<%=TREC.ECommerce.CompanyPageBase.setvalue %>"==data[i].v)
                                       {
                                           $("#pi_categorylist").append("<li><a style=\"color:Red;font-weight:bold;\" href=\"<%=TREC.ECommerce.ECommon.WebUrl %>company/" + <%=companyInfo.id %> + "/product-"+$("#pi_brand").val()+"--------1--" + data[i].pc + "-"+data[i].v+"--"+$("#pi_brands").val()+".aspx\">" + data[i].n + "(" + data[i].count + ")</a></li>");
                                        }
                                       else
                                       {
                                           $("#pi_categorylist").append("<li><a href=\"<%=TREC.ECommerce.ECommon.WebUrl %>company/" + <%=companyInfo.id %> + "/product-"+$("#pi_brand").val()+"--------1--" + data[i].pc + "-"+data[i].v+"--"+$("#pi_brands").val()+".aspx\">" + data[i].n + "(" + data[i].count + ")</a></li>");
                                       }
                                   }
                                   });

                                   if ("<%=TREC.ECommerce.ECommon.QuerySearchBrands %>" != "") {
                                        $("#pi_brands").val("<%=TREC.ECommerce.ECommon.QuerySearchBrands %>");
                                    }
                               }
                            }
                        });
                    } else {
                        $("#pi_categorylist").html("").hide().show().html("");
                        $.each(data, function (i) {
                            if (data[i].type == "category") 
                            {
                                if(bo)
                                {
                                    if("<%=TREC.ECommerce.CompanyPageBase.setvalue %>"=="-1")
                                    {
                                        $("#pi_categorylist").append("<li><a style=\"color:Red;font-weight:bold;\" href=\"<%=TREC.ECommerce.ECommon.WebUrl %>company/" + <%=companyInfo.id %> + "/product.aspx\">所有类型</a></li>");
                                    }
                                    else
                                    {
                                        $("#pi_categorylist").append("<li><a href=\"<%=TREC.ECommerce.ECommon.WebUrl %>company/" + <%=companyInfo.id %> + "/product.aspx\">所有类型</a></li>");
                                    }
                                    bo=false;
                                    $("#pi_categorylist").append("<li><a  href=\"<%=TREC.ECommerce.ECommon.WebUrl %>shop/" + <%=companyInfo.id  %> + "/producttzh.aspx\">套组合</a></li>");
                                }
                                if("<%=TREC.ECommerce.CompanyPageBase.setvalue %>"==data[i].v)
                                {
                                    $("#pi_categorylist").append("<li><a style=\"color:Red;font-weight:bold;\" href=\"<%=TREC.ECommerce.ECommon.WebUrl %>company/" + <%=companyInfo.id %> + "/product---------1--" + data[i].pc + "-"+data[i].v+".aspx\">" + data[i].n + "(" + data[i].count + ")</a></li>");
                                }
                                else
                                {
                                    $("#pi_categorylist").append("<li><a href=\"<%=TREC.ECommerce.ECommon.WebUrl %>company/" + <%=companyInfo.id %> + "/product---------1--" + data[i].pc + "-"+data[i].v+".aspx\">" + data[i].n + "(" + data[i].count + ")</a></li>");
                                }
                            }
                        });
                    }

                   
                }
            }
        });
    }

    $(document).ready(function () 
    {
        $("#post_id").bind("click",function(){
            var postvalue =$.trim($("#post_value").val());
            if(postvalue=="")
            {
                $("#post_value").focus();
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
