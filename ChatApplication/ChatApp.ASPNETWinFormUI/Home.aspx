<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ChatApp.ASPNETWinFormUI.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


        <section class="py-5 text-center container">
            <div class="row py-lg-5">
                <div class="col-lg-6 col-md-8 mx-auto">
                    <h1 class="fw-light">Album example</h1>
                    <p class="lead text-muted">Something short and leading about the collection below—its contents, the creator, etc. Make it short and sweet, but not too short so folks don’t simply skip over it entirely.</p>
                    <p>
                        <a href="#" class="btn btn-primary my-2">Main call to action</a>
                        <a href="#" class="btn btn-secondary my-2">Secondary action</a>
                    </p>
                </div>
            </div>
        </section>

        <div class="album py-5 bg-light">
            <div class="container">

                <div class="row row-cols-1 row-cols-sm-2 row-cols-md-3 g-3">

                    <%--               tekra eden card' ım--%>
                   
                    <asp:Repeater id="rptRoles" runat="server">
                        <ItemTemplate>
                            <div class="col">
                                <div class="card shadow-sm">
                                    <svg class="bd-placeholder-img card-img-top" width="100%" height="225" xmlns="http://www.w3.org/2000/svg" role="img" aria-label="Placeholder: Thumbnail" preserveAspectRatio="xMidYMid slice" focusable="false">
                                        <title>Placeholder</title>
                                        <rect width="100%" height="100%" fill="#55595c" />
                                        <text x="50%" y="50%" fill="#eceeef" dy=".3em">Thumbnail</text></svg>

                                    <div class="card-body">
                                        <p class="card-text"><%#Eval("Name")%></p>
                                        <input type="hidden" id="ID" />
                                        <div class="d-flex justify-content-between align-items-center">
                                            <div class="btn-group">
                                                <button onclick="joinChat()" type="button" class="btn btn-sm btn-outline-secondary">Sohbete Katıl</button>
                                            </div>
                                            <small class="text-muted">9 Kişi Aktif</small>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <%--               tekra eden card' ım--%>
                </div>
            </div>
        </div>

   
</asp:Content>
