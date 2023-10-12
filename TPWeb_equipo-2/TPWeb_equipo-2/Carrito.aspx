<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TPWeb_equipo_2.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container d-flex flex-column pt-3 gap-3">
        <h2>Carrito de Productos</h2>
        <div class="d-flex row row-cols-1 row-cols-md-3 g-4">
            <asp:Repeater runat="server" ID="repRepetidor">
                <ItemTemplate>
                    <div class="col">
                        <div class="card">
                            <img src="<%#Eval("urlimagen") %>" class="card-img-top" alt="ImagenProducto" onerror="handleImageError(this);">
                            <script>
                                function handleImageError(image) {
                                    image.src = 'https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fstatic.vecteezy.com%2Fsystem%2Fresources%2Fpreviews%2F005%2F337%2F799%2Fnon_2x%2Ficon-image-not-found-free-vector.jpg&f=1&nofb=1&ipt=b1f6177c0dea54678b440945501a9969e721a2f91f76b8c9e18d8b30885fab8a&ipo=images'; // Cargar una imagen de marcador de posición.
                                }
                            </script>
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                <h6 class="h5"><%#Eval("precio")%></h6>
                                <p class="card-text"><%#Eval("Descripcion")%></p>
                                <div class="d-flex justify-content-xl-between">
                                    <asp:Button ID="btnVerDetalle" Text="Ver detalle" CssClass="btn btn-dark" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="ProductoId" OnClick="VerDetalleButton_Click" />
                                    <asp:Button ID="btnEliminarCarrito" Text="Eliminar del carrito" CssClass="btn btn-dark" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="ProductoId" OnClick="EliminarDelCarritoButton_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
