using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using CNEGOCIO;
using CENTIDAD;
using System.Collections.Generic;


namespace sistemaEXTERNO
{
    public partial class mTipogastoCliente : System.Web.UI.Page
    {

        private Int16 id_cliente;
        private string Codigo_Servicio;
        private string scriptsResult;
        protected void Page_Load(object sender, EventArgs e)
        {

            id_cliente = Convert.ToInt16(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id"]));
            Codigo_Servicio = (FuncionGlobal.FuctionDesEncriptar(Request.QueryString["codigo"]).ToString().Trim());

            if (!IsPostBack)
            {
             
                Cliente mcli = new ClienteBC().getcliente(id_cliente);
                this.lbl_cliente.Text = id_cliente.ToString();  
                this.lbl_nombre.Text = mcli.Persona.Nombre;

                getalltipogasto();
            }
        }





        public void getalltipogasto()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_tipogasto"));
            dt.Columns.Add(new DataColumn("nombre"));
            dt.Columns.Add(new DataColumn("valor"));
            DataColumn col1 = new DataColumn("check");
            DataColumn col = new DataColumn("editable");
            col1.DataType = System.Type.GetType("System.Boolean");
            col.DataType = System.Type.GetType("System.Boolean");

            dt.Columns.Add(col);
            dt.Columns.Add(col1);

            List<Tipogasto> lTipogasto = new TipogastoBC().getallTipogastoClienteServicio(id_cliente, Codigo_Servicio);

            if (lTipogasto.Count == 0)
            {
                this.Button1.Visible = false;
            }
            else
            {
                this.Button1.Visible = true;
            }

            foreach (Tipogasto mtipogasto in lTipogasto)
            {
                DataRow dr = dt.NewRow();

                dr["id_tipogasto"] = mtipogasto.Id_tipogasto;
                dr["nombre"] = mtipogasto.Descripcion;
                dr["valor"] = mtipogasto.Valor;
                dr["check"] = mtipogasto.Check;
                dr["editable"] = mtipogasto.editable;

                dt.Rows.Add(dr);
            }

            this.gr_dato.DataSource = dt;
            this.gr_dato.DataBind();

            ValidarBotonUrl();

        }
        protected void ValidarBotonUrl()
        {
            GridViewRow row;
            for (int i = 0; i < gr_dato.Rows.Count; i++)
            {

                row = gr_dato.Rows[i];
                CheckBox editable = (CheckBox)gr_dato.Rows[i].FindControl("chk_editable");

                if (editable.Checked == true)
                {
                    this.gr_dato.Rows[i].Cells[2].Enabled = true;

                }
                else
                {
                    this.gr_dato.Rows[i].Cells[2].Enabled = false;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            add();
        }

        private void add()
        {
            try
            {
                GridViewRow row;
                for (int i = 0; i < gr_dato.Rows.Count; i++)
                {
                    row = gr_dato.Rows[i];
                    Int16 id_tipogasto = Convert.ToInt16(this.gr_dato.Rows[i].Cells[0].Text);
                    string dl_cargo_aux = this.gr_dato.Rows[i].Cells[2].Text;
                    CheckBox chk_sel = (CheckBox)gr_dato.Rows[i].FindControl("chk");

                    if (chk_sel.Checked)
                    {
                        //if (dl_cargo_aux == "0")
                        //{
                        //    row.BackColor = System.Drawing.Color.IndianRed;
                        //    cuenta_existentes = cuenta_existentes + 1;
                        //}
                        string add = new TipogastoBC().add_TipogastoCliente(id_tipogasto, id_cliente, dl_cargo_aux.Trim(),
                                                            Codigo_Servicio);
                        if (add == "")
                        {
                            scriptsResult = string.Format("MsjSuccess('Exito', 'Se han guardado con exito las operaciones seleccionadas.');");
                        }
                    }
                    else
                    {
                        string del = new TipogastoBC().Del_TipogastoCliente(id_tipogasto, id_cliente, Codigo_Servicio);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "575", scriptsResult, true);
            }
            //if (cuenta_existentes != 0)
            //{
            //    UpdatePanel up2 = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            //    FuncionGlobal.alerta_updatepanel("Atencion, las filas marcadas en rojo no fueron ingresadas, seleccione cargo", Page, up2);
            //}
        }


        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                string cargo_servicio = this.gr_dato.DataKeys[e.Row.RowIndex].Values[0].ToString();

                //Find the DropDownList in the Row
                DropDownList dl_cargo_aux = (e.Row.FindControl("dl_cargo") as DropDownList);
                FuncionGlobal.comboparametro(dl_cargo_aux, "VALSER");

                dl_cargo_aux.SelectedValue = cargo_servicio.Trim();


            }

        }

      

    }
}
