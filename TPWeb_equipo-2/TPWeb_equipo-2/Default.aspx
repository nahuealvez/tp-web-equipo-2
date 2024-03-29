﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPWeb_equipo_2.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container d-flex flex-column pt-3 gap-3">
        <h2>Lista de productos</h2>
        <div class="d-flex" role="search">
            <asp:TextBox ID="txtBusqueda" CssClass="form-control me-2" runat="server" />
            <asp:Button ID="btnBuscar" Text="Buscar" CssClass="btn btn-outline-dark" runat="server" OnClick="btnBuscar_Click"/>
        </div>
        <div class="d-flex row row-cols-1 row-cols-md-3 g-4">
            <asp:Repeater runat="server" id="repRepetidor" >
                <ItemTemplate>
                    <div class="col">
                        <div class="card h-100">
                            <img id="imgProducto" src="<%#Eval("urlimagen") %>" class="card-img-top img-fluid"  alt="..." onerror="handleImageError(this);" />

                            <script>
                                function handleImageError(image) {
                                    image.src = 'https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fstatic.vecteezy.com%2Fsystem%2Fresources%2Fpreviews%2F005%2F337%2F799%2Fnon_2x%2Ficon-image-not-found-free-vector.jpg&f=1&nofb=1&ipt=b1f6177c0dea54678b440945501a9969e721a2f91f76b8c9e18d8b30885fab8a&ipo=images'; // Cargar una imagen de marcador de posición.
                                }
                            </script>

                            <div class="card-body d-flex flex-column justify-content-between gap-3">
                                <div>
                                    <h5 class="card-title" ID="h6Precio"><%#Eval("Nombre") %></h5>
                                    <h6 class="h5" id="precio"><%# string.Format("${0:N2}", Eval("precio")) %></h6>
                                </div>
                                <%--<p class="card-text"><%#Eval("Descripcion")%></p>--%>
                                <div class="d-flex justify-content-xl-between">
                                    <asp:Button ID="btnVerDetalle" Text="Ver detalle" CssClass="btn btn-dark" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="ProductoId" OnClick="VerDetalleButton_Click"/>
                                    <asp:Button ID="btnAgregarAlCarrito" Text="Agregar al carrito" CssClass="btn btn-dark" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="ProductoId" OnClick="AgregarAlCarritoButton_Click" Visible="true"/>
                                    <asp:Button ID="btnEliminarDelCarrito" Text="Eliminar del carrito" CssClass="btn btn-danger" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="ProductoId" OnClick="EliminarDelCarritoButton_Click" Visible="false"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
