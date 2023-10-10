<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="TPWeb_equipo_2.Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container d-flex flex-column pt-3 gap-3">
        <h2>Detalle Producto</h2>
    <%--<div class="d-flex flex-row gap-3">--%>
        <div class="row row-cols-1 row-cols-md-3 g-4">
           <%
                   string imageUrl = ArticuloDetalle.UrlImagen;
                   string precio = ArticuloDetalle.Precio.ToString();
                   //bool isValidUrl = imagenNegocio.ImagenURLValida(imageUrl);
                        %>

                            <div class="col">
                                <div class="card">
                                    <img src="<%: ArticuloDetalle.UrlImagen %>" class="card-img-top" alt="...">
                                    <div class="card-body">
                                        <h5 class="card-title"><%: ArticuloDetalle.Nombre %></h5>
                                        <h6 class="h5"><%: precio%></h6>
                                        <p class="card-text"><%: ArticuloDetalle.Descripcion %></p>
                                        <div class="d-flex justify-content-xl-between">
                                            <asp:Button Text="Agregar al carrito" CssClass="btn btn-dark" runat="server" OnClick="AgregarAlCarritoButton_Click"/>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        <%
            %>
        </div>
    <%--</div>--%>
    </div>

</asp:Content>
