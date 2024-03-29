﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Jium.Web.piorecord
{
    public partial class Sale : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearchConsumer_Click(object sender, EventArgs e)
        {
            Jium.BLL.consumer bll = new Jium.BLL.consumer();
            StringBuilder strWhere = new StringBuilder();
            if (txtCphone.Text.Trim() != "")
            {
#warning 代码生成警告：请修改 keywordField 为需要匹配查询的真实字段名称
                strWhere.AppendFormat("cphone = '{0}'", txtCphone.Text.Trim());
            }
            else
            {
                /// new user?
                return;
            }
            var consumers= bll.GetModelList(strWhere.ToString());
            if(consumers.Count !=1)
            {
                return;
            }
            txtCcode.Text = consumers[0].ccode;
            txtCname.Text = consumers[0].cname;
        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
        }

        protected void btnConfirmSale_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            GetSelIDlist();

        }

        protected void btnSearchProduct_Click(object sender, EventArgs e)
        {
            BindProductData();
        }

        public void BindProductData()
        {            
            #region
            //if (!Context.User.Identity.IsAuthenticated)
            //{
            //    return;
            //}
            //AccountsPrincipal user = new AccountsPrincipal(Context.User.Identity.Name);
            //if (user.HasPermissionID(PermId_Modify))
            //{
            //    gridView.Columns[6].Visible = true;
            //}
            //if (user.HasPermissionID(PermId_Delete))
            //{
            //    gridView.Columns[7].Visible = true;
            //}
            #endregion

            DataSet ds = new DataSet();
            StringBuilder strWhere = new StringBuilder();
            if (txtKeyword.Text.Trim() != "")
            {
#warning 代码生成警告：请修改 keywordField 为需要匹配查询的真实字段名称
                strWhere.AppendFormat(" (pname like '%{0}%' or pcode like '%{0}%' or pdesc like '%{0}%' or pls1 like '%{0}%')", txtKeyword.Text.Trim());
            }
            Jium.BLL.plib bll = new Jium.BLL.plib();
            ds = bll.GetList(strWhere.ToString());
            gridViewLib.DataSource = ds;
            gridViewLib.DataBind();
        }

        private string GetSelIDlist()
        {
            var lst=new List<Jium.Model.piorecord>();
            string idlist = "";
            bool BxsChkd = false;
            var productBll = new Jium.BLL.product();
            for (int i = 0; i < gridViewLib.Rows.Count; i++)
            {
                CheckBox ChkBxItem = (CheckBox)gridViewLib.Rows[i].FindControl("SaleThis");
                if (ChkBxItem != null && ChkBxItem.Checked)
                {
                    BxsChkd = true;
                    //#warning 代码生成警告：请检查确认Cells的列索引是否正确
                    if (gridViewLib.DataKeys[i].Value != null)
                    {                       
                        var model = new Jium.Model.piorecord();
                        model.pcode = gridViewLib.Rows[i].Cells[1].Text;// i.ToString();
                        model.pios3 = gridViewLib.Rows[i].Cells[2].Text;// gridViewLib.Rows[i].Cells[3].ToString();                        
                        model.pzekou = 1;
                        model.pcnt = 1;
                        string where = string.Format("pcode='{0}'", model.pcode);
                        var lstProduct = productBll.GetModelList(where);
                        if (lstProduct.Count > 0)
                            model.psaleprice = lstProduct.FirstOrDefault().psaleprice;
                        lst.Add(model);
                        idlist += gridViewLib.DataKeys[i].Value.ToString() + ",";
                    }
                }
            }
            if (BxsChkd)
            {
                idlist = idlist.Substring(0, idlist.LastIndexOf(","));
            }

            decimal sum = 0;
            for(int i=0; i< gridViewBuy.Rows.Count; i++)
            {
                var model = new Jium.Model.piorecord();
                model.pcode = gridViewBuy.Rows[i].Cells[0].Text;
                model.pios3= gridViewBuy.Rows[i].Cells[1].Text;
                model.psaleprice = decimal.Parse(gridViewBuy.Rows[i].Cells[2].Text);
                model.pcnt = int.Parse(gridViewBuy.Rows[i].Cells[3].Text);
                model.pzekou = decimal.Parse(gridViewBuy.Rows[i].Cells[4].Text);
                lst.Add(model);
            }
            //if (gridViewBuy.DataSource == null)
            //{
                gridViewBuy.DataSource = lst;
                var sumTotal = lst.Sum(e => e.pcnt * e.psaleprice);
                var sumReal  = lst.Sum(e => e.pcnt * e.psaleprice*e.pzekou);
            var zekou = sumTotal == 0 ? 1 : sumReal / sumTotal;
            //}
            //else
            //{
            //    var lstBuy = (List<Jium.Model.piorecord>)gridViewBuy.DataSource;
            //    lstBuy.AddRange(lst);
            //    gridViewBuy.DataSource = lstBuy;
            //    sum = lstBuy.Sum(e => e.pcnt * e.psaleprice);
            //}
            txtSumTotal.Text = sumTotal.ToString();
            txtSumReal.Text = sumReal.ToString();
            txtZekou.Text = zekou.ToString();

            
            gridViewBuy.DataBind();
            return idlist;
        }


        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewLib.PageIndex = e.NewPageIndex;
            BindProductData();
        }
        protected void gridView_OnRowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //e.Row.Cells[0].Text = "<input id='Checkbox2' type='checkbox' onclick='CheckAll()'/><label></label>";
            }
        }
        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("style", "background:#FFF");
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton linkbtnDel = (LinkButton)e.Row.FindControl("LinkButton1");
                linkbtnDel.Attributes.Add("onclick", "return confirm(\"你确认要删除吗\")");

                //object obj1 = DataBinder.Eval(e.Row.DataItem, "Levels");
                //if ((obj1 != null) && ((obj1.ToString() != "")))
                //{
                //    e.Row.Cells[1].Text = obj1.ToString();
                //}

            }
        }

        protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //#warning 代码生成警告：请检查确认真实主键的名称和类型是否正确
            //int ID = (int)gridView.DataKeys[e.RowIndex].Value;
            //bll.Delete(ID);
            //gridView.OnBind();
        }

        protected void gridView_BuyDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //#warning 代码生成警告：请检查确认真实主键的名称和类型是否正确
            gridViewBuy.DeleteRow(e.RowIndex);
            //int ID = (int)gridView.DataKeys[e.RowIndex].Value;
            //bll.Delete(ID);
            //gridView.OnBind();
        }
        protected void gridView_BuyAdd(object sender, GridViewRowEventArgs e)
        {
            //#warning 代码生成警告：请检查确认真实主键的名称和类型是否正确
            var sNum = e.Row.Cells[2].Text;
            if (string.IsNullOrWhiteSpace(sNum))
                e.Row.Cells[2].Text = "1";
            else
            {
                int cnt = int.Parse(e.Row.Cells[2].Text)+1;
                e.Row.Cells[2].Text = cnt.ToString();
            }
        }
        protected void btnProductPlus_Click(object sender, EventArgs e)
        {
            //#warning 代码生成警告：请检查确认真实主键的名称和类型是否正确
            var btn = (Button)sender;

            var index = ((GridViewRow)btn.Parent.Parent).RowIndex;

            //var sNum = e.Row.Cells[2].Text;
            //if (string.IsNullOrWhiteSpace(sNum) || sNum.Trim() == "1")
               gridViewBuy.DeleteRow(index);
            //else
            //{
            //    int cnt = int.Parse(e.Row.Cells[2].Text) - 1;
            //    e.Row.Cells[2].Text = cnt.ToString();
            //}
        }
    }
}