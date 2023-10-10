<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPWeb_equipo_2.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container d-flex flex-column pt-3 gap-3">
        <h2>Lista de productos</h2>
        <div class="d-flex row row-cols-1 row-cols-md-3 g-4">
            <asp:Repeater runat="server" id="repRepetidor" OnItemDataBound="repRepetidor_ItemDataBound">
                <ItemTemplate>
                    <div class="col">
                        <div class="card">
                            <%--<img runat="server" id="imgProducto" src="<%#Eval("urlimagen") %>" class="card-img-top" alt="...">--%>
                            <asp:Image runat="server" ID="imgProducto" ImageUrl='<%#Eval("urlimagen") %>' AlternateText="Texto alternativo" CssClass="card-img-top" />

                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                <h6 class="h5"><%#Eval("precio")%></h6>
                                <p class="card-text"><%#Eval("Descripcion")%></p>
                                <div class="d-flex justify-content-xl-between">
                                    <asp:Button ID="btnVerDetalle" Text="Ver detalle" CssClass="btn btn-dark" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="ProductoId" OnClick="VerDetalleButton_Click"/>
                                    <asp:Button ID="btnAgregarAlCarrito" Text="Agregar al carrito" CssClass="btn btn-dark" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="ProductoId" OnClick="AgregarAlCarritoButton_Click"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
