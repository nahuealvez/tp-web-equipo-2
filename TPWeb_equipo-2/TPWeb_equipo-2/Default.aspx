<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPWeb_equipo_2.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container d-flex flex-column pt-3 gap-3">
    <h2>Carrito de compras</h2>
    <div class="d-flex flex-row gap-3">
       <%
            foreach (dominio.Articulo articulo in ListaArticulo)
            {
                string imageUrl = articulo.UrlImagen;
                bool isValidUrl = imagenNegocio.ImagenURLValida(imageUrl);

                if (isValidUrl)
                {
                    %>
                    <div class="row g-4">
                        <div class="col">
                            <div class="card h-100">
                                <img src="<%: imageUrl %>" class="card-img-top" alt="...">
                                <div class="card-body">
                                    <h5 class="card-title"><%: articulo.Nombre %></h5>
                                    <p class="card-text"><%: articulo.Descripcion %></p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%
                }
                else
                {
                    string defaultImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fstatic.vecteezy.com%2Fsystem%2Fresources%2Fpreviews%2F005%2F337%2F799%2Fnon_2x%2Ficon-image-not-found-free-vector.jpg&f=1&nofb=1&ipt=b1f6177c0dea54678b440945501a9969e721a2f91f76b8c9e18d8b30885fab8a&ipo=images";
                    %>
                    <div class="row g-4">
                        <div class="col">
                            <div class="card h-100">
                                <img src="<%: defaultImageUrl %>" class="card-img-top" alt="Imagen por defecto">
                                <div class="card-body">
                                    <h5 class="card-title"><%: articulo.Nombre %></h5>
                                    <p class="card-text"><%: articulo.Descripcion %></p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%
                }
            }
        %>
    </div>

    </div>
</asp:Content>
