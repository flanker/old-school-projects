<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Head" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="/Content/Music/music.css" rel="stylesheet" type="text/css" />
    <script src="/Content/Music/slider.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="BodyContent" runat="server">
    <div id="wrapper">
        <div id="slider">
            <img class="scrollButtons left" src="/Content/Music/images/leftarrow.png" alt="向左走" />
            <div style="overflow: hidden;" class="scroll">
                <div class="scrollContainer">
                    <div class="panel" id="panel_1">
                        <div class="inside">
                            <img src="/Content/Music/Images/cover_old.jpg" alt="经典老歌" />
                            <h2>经典老歌</h2>
                            <p>自己喜欢的一些老歌 >>>play</p>
                        </div>
                    </div>
                    <div class="panel" id="panel_2">
                        <div class="inside">
                            <img src="/Content/Music/Images/cover_jay.jpg" alt="周杰伦" />
                            <h2>周杰伦</h2>
                            <p>周杰伦的一些歌, 主要是老歌 >>><a title="周杰伦" href="Playlist/Jay">play</a></p>
                        </div>
                    </div>
                    <div class="panel" id="panel_3">
                        <div class="inside">
                            <img src="/Content/Music/Images/cover_8mile.jpg" alt="8mile" />
                            <h2>8mile</h2>
                            <p>8mile 八英里 >>><a title="8mile" href="Playlist/8mile">play</a></p>
                        </div>
                    </div>
                    <div class="panel" id="panel_4">
                        <div class="inside">
                            <img src="/Content/Music/Images/cover_world_pop.jpg" alt="欧美流行" />
                            <h2>欧美流行</h2>
                            <p>欧美的流行歌曲, 网上找的 >>><a title="欧美流行" href="Playlist/Pop">play</a></p>
                        </div>
                    </div>
                    <div class="panel" id="panel_5">
                        <div class="inside">
                            <img src="/Content/Music/Images/cover_poponline.jpg" alt="Pop online" />
                            <h2>Pop radio online</h2>
                            <p>在线收听流行音乐电台 >>><a title="Pop online" href="Playlist/PopOnline">play</a></p>
                        </div>
                    </div>
                    <div class="panel" id="panel_6">
                        <div class="inside">
                            <img src="/Content/Music/Images/cover_hiphoponline.jpg" alt="Hip-Hop online" />
                            <h2>Hip-Hop radio online</h2>
                            <p>在线收听希普霍普音乐电台 >>><a title="Hip-Hop online" href="Playlist/HiphopOnline">play</a></p>
                        </div>
                    </div>
                </div>
                <div id="left-shadow">
                </div>
                <div id="right-shadow">
                </div>
            </div>
            <img class="scrollButtons right" src="/Content/Music/images/rightarrow.png" alt="向右走" />
        </div>
    </div>
</asp:Content>
