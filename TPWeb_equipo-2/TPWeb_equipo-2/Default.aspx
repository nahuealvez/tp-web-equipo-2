<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPWeb_equipo_2.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container d-flex flex-column pt-3 gap-3">
    <h2>Lista de productos</h2>
    <%--<div class="d-flex flex-row gap-3">--%>
        <div class="row row-cols-1 row-cols-md-3 g-4">
           <%
               foreach (dominio.Articulo articulo in ListaArticulo)
               {
                   string imageUrl = articulo.UrlImagen;

                   string precio = articulo.Precio.ToString("N2", idioma);

                   //bool isValidUrl = imagenNegocio.ImagenURLValida(imageUrl);
                        %>
                    
                            <div class="col">
                                <div class="card">
                                    <img src="<%: imagenNegocio.cargarImagen(imageUrl) %>" class="card-img-top" alt="...">
                                    <div class="card-body">
                                        <h5 class="card-title"><%: articulo.Nombre %></h5>
                                        <h6 class="h5"><%: precio%></h6>
                                        <p class="card-text"><%: articulo.Descripcion %></p>
                                        <div class="d-flex justify-content-xl-between">
                                            <asp:Button Text="Ver detalle" CssClass="btn btn-dark" runat="server" />
                                            <asp:Button Text="Agregar al carrito" CssClass="btn btn-dark" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                    
                        <%
                }
            %>
        </div>
    <%--</div>--%>
    </div>
</asp:Content>
