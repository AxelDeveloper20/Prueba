<%@ Page Language="C#" MasterPageFile="~/Modal.Master" AutoEventWireup="true" CodeBehind="mTipogastoCliente.aspx.cs" Inherits="sistemaEXTERNO.mTipogastoCliente" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script>
        function sampleFunction() {
            var flag = false; // maintain a flag
            alertify.confirm("¿Esta seguro de actualizar costos?", function () {
                flag = true; // set it true here
                __doPostBack("<%=Button1.UniqueID %>", "");
              }, function () { });
            return flag; // return the flag
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
	
		

        <div class="container col-12 shadow p-3 mb-5 rounded" style="background-color:gray; font-weight:bold; color:#000000;" >
    <div class="col-12 d-flex justify-content-center font-weight-bold">
        <asp:Label ID="lbl_cliente" runat="server"  Visible="false"></asp:Label>
         <asp:Label ID="lbl_nombre" runat="server" CssClass="input_largo" ></asp:Label>
    </div>
        </div>
				
			<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
					Class="dataTables-example table table-striped table-bordered table-hover dataTable no-footer table-fluid">
						<Columns>
							<asp:BoundField  DataField="id_tipogasto" HeaderText="ID" HeaderStyle-ForeColor="Black" HeaderStyle-BackColor="gray"/>
							<asp:BoundField  DataField="nombre" HeaderText="Tramite" HeaderStyle-ForeColor="Black" HeaderStyle-BackColor="gray"/>
							<asp:TemplateField HeaderText="Costo" HeaderStyle-ForeColor="black" HeaderStyle-BackColor="Gray">
                                <ItemTemplate>
                                <asp:TextBox ID="txt_costo" MaxLength="6" CssClass="input" runat="server" Text='<%# Bind("valor") %>' >
                                </asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="txt_valor_gasto_FilteredTextBoxExtender" runat="server" TargetControlID="txt_costo" FilterType="Custom, Numbers" ValidChars="0123456789">
                                </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>

							<asp:TemplateField HeaderText="Seleccionar" HeaderStyle-ForeColor="Black" HeaderStyle-BackColor="gray" ItemStyle-HorizontalAlign="Center">
							<ItemTemplate>
								<asp:CheckBox ID="chk" runat="server" EnableViewState="true" Checked='<%# Bind("check")%>' />
							</ItemTemplate>
							</asp:TemplateField>

                            <asp:TemplateField HeaderText="Facturable" HeaderStyle-ForeColor="Black" HeaderStyle-BackColor="gray" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chk_factura" runat="server" EnableViewState="true" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Editable" HeaderStyle-ForeColor="Black" HeaderStyle-BackColor="gray" Visible="false">
                            <ItemTemplate>
                                <asp:CheckBox ID="chk_editable" runat="server" EnableViewState="true" Checked='<%# Bind("editable")%>' />
                            </ItemTemplate>
                            </asp:TemplateField>
			
						</Columns>
					</asp:GridView>
	
		<asp:Button ID="Button1" runat="server" Text="Guardar" OnClick="Button1_Click" OnClientClick="return sampleFunction();" TabIndex="16" CssClass="btn btn-primary lift" />

	<br />

</asp:Content>