<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="TPWeb_equipo_2.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container d-flex flex-column pt-3 gap-3">
        <h2>Detalle del producto</h2>
        <%if (ArticuloDetalle == null)
            { %>
        <h2>No Ingreso ningún producto</h2>
        <%}
            else
            { %>
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
                    <img src="<%: ArticuloDetalle.UrlImagen %>" class="card-img-top" alt="ImagenProducto" onerror="handleImageError(this);">
                    <script>
                        function handleImageError(image) {
                            image.src = 'https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fstatic.vecteezy.com%2Fsystem%2Fresources%2Fpreviews%2F005%2F337%2F799%2Fnon_2x%2Ficon-image-not-found-free-vector.jpg&f=1&nofb=1&ipt=b1f6177c0dea54678b440945501a9969e721a2f91f76b8c9e18d8b30885fab8a&ipo=images'; // Cargar una imagen de marcador de posición.
                        }
                    </script>
                </div>
            </div>
            <%
            %>
        </div>
        <%} %>
        <asp:Button Text="Volver al catálogo" Width="155px" CssClass="btn btn-outline-dark" runat="server" OnClientClick="window.history.back(); return false;" />
    </div>

</asp:Content>
