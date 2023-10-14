<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="TPWeb_equipo_2.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container d-flex flex-column pt-3 gap-3">
        <h2>Detalle del producto</h2>
        <%if (ArticuloDetalle == null)
            { %>
        <h2>Carrito sin productos</h2>
        <%}
            else
            { %>
        <div class="card mb-3" style="max-width: 900px;">
            <%
                string imageUrl = ArticuloDetalle.UrlImagen;
                string precio = ArticuloDetalle.Precio.ToString("N2", idioma);
            %>

            <div class="row g-0">
                <div class="col-md-8">
                    <div class="card-body">
                        <h3 class="card-title"><%: ArticuloDetalle.Nombre %></h3>
                        <h3 class="h3"><%: "$" + precio%></h3>
                        <p class="card-text"><%: ArticuloDetalle.Descripcion %></p>
                        <div class="d-flex justify-content-xl-between">
                            <%if (ListaCarrito.Exists(x => x.Id == int.Parse(Request.QueryString["ID"])))
                                { %>
                            <asp:Button Text="Eliminar del carrito" CssClass="btn btn-danger" runat="server" OnClick="EliminarDelCarritoButton_Click" />
                            <%}
                                else
                                { %>
                            <asp:Button Text="Agregar al carrito" CssClass="btn btn-dark" runat="server" OnClick="AgregarAlCarritoButton_Click" />
                            <%} %>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <%--<img src="<%: ArticuloDetalle.UrlImagen %>" class="card-img-top" alt="ImagenProducto" onerror="handleImageError(this);">
                    <script>
                        function handleImageError(image) {
                            image.src = 'https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fstatic.vecteezy.com%2Fsystem%2Fresources%2Fpreviews%2F005%2F337%2F799%2Fnon_2x%2Ficon-image-not-found-free-vector.jpg&f=1&nofb=1&ipt=b1f6177c0dea54678b440945501a9969e721a2f91f76b8c9e18d8b30885fab8a&ipo=images'; // Cargar una imagen de marcador de posición.
                        }
                    </script>--%>

                    <div id="carouselExampleIndicators" class="carousel slide">
                        <div class="carousel-inner">
                            <%foreach (var imagen in UrlImagenes)
                                {%>
                            <div class="carousel-item active">
                                <img src="<%:imagen %>" class="card-img-top" alt="ImagenProducto" onerror="handleImageError(this);">
                                <script>
                                    function handleImageError(image) {
                                        image.src = 'https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fstatic.vecteezy.com%2Fsystem%2Fresources%2Fpreviews%2F005%2F337%2F799%2Fnon_2x%2Ficon-image-not-found-free-vector.jpg&f=1&nofb=1&ipt=b1f6177c0dea54678b440945501a9969e721a2f91f76b8c9e18d8b30885fab8a&ipo=images'; // Cargar una imagen de marcador de posición.
                                    }
                                </script>
                            </div>
                            <%}%>
                        </div>
                        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Previous</span>
                        </button>
                        <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Next</span>
                        </button>
                    </div>
                </div>
            </div>
            <%
            %>
        </div>
        <%} %>
        <asp:Button Text="Volver" Width="120px" CssClass="btn btn-outline-dark" runat="server" OnClientClick="window.history.back(); return false;" />
    </div>

</asp:Content>
