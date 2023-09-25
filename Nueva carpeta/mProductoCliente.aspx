<%@ Page Language="C#" MasterPageFile="~/Modal.Master" AutoEventWireup="true" CodeBehind="mProductoCliente.aspx.cs" Inherits="sistemaEXTERNO.mProductoCliente" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	    <%--<script>
            function sampleFunction() {
                var flag = false; // maintain a flag
                alertify.confirm("¿Esta seguro de actualizar costos?", function () {
                    flag = true; // set it true here
                    __doPostBack("<%=Button1.UniqueID %>", "");
            }, function () { });
                return flag; // return the flag
            }
        </script>--%>
	
	<script type="text/javascript">

        $(document).ready(function () {
            $('.fancybox').fancybox({
                closeClick: false, // prevents closing when clicking INSIDE fancybox 
                openEffect: 'none',
                closeEffect: 'none',
                padding: 2,
                width: '80%',
                height: '80%',
                beforeShow: function () {
                    var el, id = $(this.element).data('title-id');
                    if (id) {
                        el = $('#' + id);
                        if (el.length)
                            this.title = el.html();
                    }
                },
                helpers: {
                    overlay: { closeClick: false }, css: {
                        'background-color': 'Gray'
                    }  // prevents closing when clicking OUTSIDE fancybox 
                }
            });
        });

        $(document).ready(function () {
            $('.updates').fancybox({
                closeClick: false, // prevents closing when clicking INSIDE fancybox 
                openEffect: 'yes',
                closeEffect: 'none',
                padding: 2,
                autoSize: true,
                beforeShow: function () {
                    var el, id = $(this.element).data('title-id');
                    if (id) {
                        el = $('#' + id);
                        if (el.length)
                            this.title = el.html();
                    }
                },
                helpers: {
                    overlay: { closeClick: false }, css: {
                        'background-color': 'Gray'
                    }  // prevents closing when clicking OUTSIDE fancybox 
                }
            });
        });

    </script>  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
	
			
    <div id="title-gastos" style="display: none;">
				CONTROL DE GASTOS
			</div>

	    <div class="container col-12 shadow p-3 mb-5 rounded" style="background-color:gray; font-weight:bold; color:#000000;" >
    <div class="col-12 d-flex justify-content-center font-weight-bold">
        <asp:Label ID="lbl_cliente" runat="server"  Visible="false"></asp:Label>
         <asp:Label ID="lbl_nombre" runat="server" CssClass="input_largo" ></asp:Label>
    </div>
        </div>
	
			<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" OnRowCommand="gr_dato_RowCommand" DataKeyNames="codigo"
                CssClass="dataTables-example table table-striped table-bordered table-hover dataTable no-footer table-fluid">
			
			<Columns>
			<asp:BoundField  DataField="codigo" HeaderText="Codigo" HeaderStyle-ForeColor="black" HeaderStyle-BackColor="Gray" />
            <asp:BoundField  DataField="nombre" HeaderText="Servicio" HeaderStyle-ForeColor="black" HeaderStyle-BackColor="Gray" />
            			
                        	<asp:TemplateField ShowHeader="False" HeaderText="Tramites" HeaderStyle-ForeColor="black" HeaderStyle-BackColor="Gray" ItemStyle-HorizontalAlign="Center">
							<ItemTemplate>
                                <asp:LinkButton ID = "lnk_cargar" runat = "server" CommandArgument ="tramite" CommandName = "tramite" ><span class="fa fa-credit-card" aria-hidden="true" style="color:#4e73df"></asp:LinkButton>
							</ItemTemplate>
						</asp:TemplateField>
                    
             <asp:TemplateField HeaderText=".." HeaderStyle-ForeColor="black" HeaderStyle-BackColor="Gray">
            	<ItemTemplate>
					<asp:CheckBox ID="chk_seleccion" runat="server" EnableViewState="true" Enabled="true" Checked='<%# Bind("check") %>' />
				</ItemTemplate>
			</asp:TemplateField>


			</Columns>
			
            </asp:GridView>
	
		<%--<asp:Button ID="Button1" runat="server" Text="Guardar" OnClientClick="return sampleFunction();" OnClick="Button1_Click" TabIndex="16" CssClass="btn btn-primary lift" CausesValidation="false" ClientIDMode="Static" Visible="false" />--%>

	<br />


    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
    <ContentTemplate>

	 <!-- Modal EXTERNO -->
	<div class="modal fade" id="Div1" tabindex="-1" role="dialog" aria-labelledby="myExtraLargeModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-xl">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title">Gestion de Operacion</h5>
                <button class="btn-close" type="button" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <div class="ratio ratio-16x9">
					            <iframe  id="modalextero" runat="server" frameborder="0" width="100%"></iframe>
             </div>
            </div>
            <div class="modal-footer"><button class="btn btn-primary" type="button" data-bs-dismiss="modal">Cerrar</button></div>
        </div>
    </div>
</div>

    </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function openModal() {
            $('#Div1').modal('show');
        }
    </script>
    
</asp:Content>