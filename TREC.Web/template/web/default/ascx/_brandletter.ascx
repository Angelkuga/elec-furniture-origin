<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_brandletter.ascx.cs" Inherits="TREC.Web.aspx.ascx._brandletter" %>
<div class="prlifl1">
      <div class="pren">
      <ul>
      <%foreach (string s in letterIndex)
        { %>
            <li><a href="#" class="<%=dtBrandLetterIndex.Select("letter='" +s.ToLower()+"'").Length>0?"a1":"noprena" %>"><%=s %></a><div class="prentc" alphaid="<%=s %>">
        <ul id="brandletter">
            <%foreach (System.Data.DataRow dr in dtBrandLetterIndex.Select("letter='" +s.ToLower()+"'"))
              { %>
                <li><a href="javascript:;" onclick="javascript:window.open('/company/<%=dr["companyid"]%>/index.aspx');" ><%=dr["title"] != null && dr["title"].ToString() != "" && dr["title"].ToString().Length > 4 ? dr["title"].ToString(): dr["title"]%></a></li>
            <%} %>
        </ul>
      </div></li>
      <%} %>
      
      </ul>
   
      </div>
      <div class="prsq"><a href="#">收起</a></div>
    </div>