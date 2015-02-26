<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HappyTogether.Models.Together>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
    活动已删除
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <h2>活动已删除</h2>
    <div>
        <p>你的活动已经成功删除。</p>
    </div>
    <div>
        <p><a href="/Together">转到活动列表</a></p>
    </div>
</asp:Content>
