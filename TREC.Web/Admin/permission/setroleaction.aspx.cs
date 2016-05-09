using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.Entity;
using TREC.ECommerce;

namespace TREC.Web.Admin.permission
{
    public partial class setroleaction : System.Web.UI.Page
    {
        public List<EnModule> ModuleList = new List<EnModule>();
        public List<EnAction> ActionList = new List<EnAction>();
        public List<EnRoleActionDef> RoleActionDefList = new List<EnRoleActionDef>();
        public List<EnRole> RoleList = new List<EnRole>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                RoleList = ECRole.GetRoleList("");

                if (ECommon.QueryRoleId == "")
                {
                    Response.Redirect("setroleaction.aspx?rid=" + RoleList[0].id);
                }

                ModuleList = ECModule.GetModuleList("");
                ActionList = ECAction.GetActionList("");
                RoleActionDefList = ECRole.GetRoleActionDefList(" where roleid=" + ECommon.QueryRoleId);

                foreach (EnModule m in ModuleList)
                {
                    if (RoleActionDefList.Where(x => x.moduleid == m.id && x.actionid==0).Count() > 0)
                    {
                        m.isRoleHas = 1;

                        foreach (EnAction a in ActionList.Where(x => x.mid == m.id))
                        {
                            a.isActionHas = 1;
                        }
                    }
                }
                foreach (EnAction a in ActionList)
                {
                    if (RoleActionDefList.Where(x => x.actionid == a.id && x.moduleid == a.mid).Count() > 0)
                    {
                        a.isActionHas = 1;
                    }
                }


            }
        }

        protected void lbtnUpAction_Click(object sender, EventArgs e)
        {
            string actions = hfactionValue.Value;
            if (actions != "")
            {
                ECRole.DelRoleActionDef(TypeConverter.StrToInt(hfRoleId.Value));

                foreach (string s in actions.Split(','))
                {
                    if (s != "")
                    {
                        //s_2_4,m_4,
                        EnRoleActionDef m = new EnRoleActionDef();
                        m.roleid = TypeConverter.StrToInt(hfRoleId.Value);
                        if(s.Substring(0,2)=="m_")
                        {
                            m.moduleid = TypeConverter.StrToInt(s.Substring(s.IndexOf("_") + 1));
                            m.actionid = 0;
                        }
                        else
                        {
                            m.actionid = TypeConverter.StrToInt(s.Substring(s.IndexOf("_") + 1, s.LastIndexOf("_") - 2));
                            m.moduleid = TypeConverter.StrToInt(s.Substring(s.LastIndexOf("_") + 1));
                        }
                        ECRole.EditRoleActionDef(m);
                    }
                }
                UiCommon.JscriptPrint(this.Page, "权限设置成功!", Request.Url.AbsoluteUri, "Success");
            }
        }
    }
}