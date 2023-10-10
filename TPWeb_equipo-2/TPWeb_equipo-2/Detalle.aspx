<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="TPWeb_equipo_2.Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container d-flex flex-column pt-3 gap-3">
        <h2>Detalle del producto</h2>
        <div class="card mb-3" style="max-width: 900px;">
           <%
                   string imageUrl = ArticuloDetalle.UrlImagen;
                   string precio = ArticuloDetalle.Precio.ToString("N2", idioma);
                   //bool isValidUrl = imagenNegocio.ImagenURLValida(imageUrl);
                        %>

                            <div class="row g-0">
                                <div class="col-md-8">
                                    <div class="card-body">
                                        <h3 class="card-title"><%: ArticuloDetalle.Nombre %></h3>
                                        <h3 class="h3"><%: "$" + precio%></h3>
                                        <p class="card-text"><%: ArticuloDetalle.Descripcion %></p>
                                        <div class="d-flex justify-content-xl-between">
                                            <asp:Button Text="Agregar al carrito" CssClass="btn btn-dark" runat="server" OnClick="AgregarAlCarritoButton_Click" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <img src="<%: ArticuloDetalle.UrlImagen %>" class="card-img-top" alt="ImagenProducto">
                                </div>
                            </div>
                        <%
            %>
        </div>
        <asp:Button Text="Volver al catálogo" Width="170px" CssClass="btn btn-outline-dark" runat="server" OnClientClick="window.history.back(); return false;"/>
    </div>

</asp:Content>
