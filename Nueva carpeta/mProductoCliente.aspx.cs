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
    public partial class mProductoCliente : System.Web.UI.Page
    {

        private Int16 id_cliente;

        protected void Page_Load(object sender, EventArgs e)
        {

            id_cliente = Convert.ToInt16(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id"]));

            if (!IsPostBack)
            {
             
                Cliente mcli = new ClienteBC().getcliente(id_cliente);
                this.lbl_cliente.Text = id_cliente.ToString();  
                this.lbl_nombre.Text = mcli.Persona.Nombre;
                GetServicio();

            }
        }





        public void GetServicio()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("codigo"));
            dt.Columns.Add(new DataColumn("nombre"));
            dt.Columns.Add(new DataColumn("url_gastos"));
            DataColumn col = new DataColumn("check");
            col.DataType = System.Type.GetType("System.Boolean");
            dt.Columns.Add(col);


            List<TipoOperacion> ltipoOperacion = new TipooperacionBC().getTipo_OperacionByCliente(id_cliente);



            foreach (TipoOperacion mtipogasto in ltipoOperacion)
            {
                DataRow dr = dt.NewRow();

                dr["codigo"] = mtipogasto.Codigo;
                dr["nombre"] = mtipogasto.Operacion;
                dr["check"] = mtipogasto.Check;
                

                dt.Rows.Add(dr);
            }

            this.gr_dato.DataSource = dt;
            this.gr_dato.DataBind();

        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    add();
        //}

        private void add()
        {
            GridViewRow row;
            
            for (int i = 0; i < gr_dato.Rows.Count; i++)
            {
                row = gr_dato.Rows[i];
                TextBox txt_valor = (TextBox)gr_dato.Rows[i].FindControl("txt_valor_servicio");
                string codigo = this.gr_dato.Rows[i].Cells[0].Text.Trim();
                CheckBox chk_sel = (CheckBox)gr_dato.Rows[i].FindControl("chk_seleccion");

                if (chk_sel.Checked)
                {
                    string add = new TipooperacionBC().add_tipo_operacion_cliente(codigo, id_cliente,Convert.ToInt32(txt_valor.Text),0);
                }
                else
                {
                    string del = new TipooperacionBC().add_tipo_operacion_cliente(codigo, id_cliente, Convert.ToInt32(txt_valor.Text), 1);
                }
                 
            }

                UpdatePanel up2 = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
                FuncionGlobal.alerta_updatepanel("Informacion Actualizada con Exito", Page, up2);
            
        }

        protected void gr_dato_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
                return;

            LinkButton lnkBtn = (LinkButton)e.CommandSource;    // the button
            GridViewRow myRow = (GridViewRow)lnkBtn.Parent.Parent;  // the row
            GridView myGrid = (GridView)sender; // the gridview

            string CODIGO = myGrid.DataKeys[myRow.RowIndex].Values[0].ToString();

            if (e.CommandName == "tramite")
            {
                this.modalextero.Attributes["src"] = "mTipogastoCliente.aspx?id=" + FuncionGlobal.FuctionEncriptar(id_cliente.ToString().Trim()) + "&codigo=" +
                                FuncionGlobal.FuctionEncriptar(CODIGO.Trim());
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            }
        }
    }
}

