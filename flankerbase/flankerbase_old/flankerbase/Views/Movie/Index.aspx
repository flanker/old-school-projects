<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Head" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="/Content/Movie/movie.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="BodyContent" runat="server">
    <div id="main">
        <ul>
            <li>
                <img src="/Content/Movie/Images/SavingPrivateRyan.jpg" alt="拯救大兵瑞恩" />
                <span class="Name_zh">拯救大兵瑞恩</span><span class="Name_en">Saving Private Ryan</span>
            </li>
            <li>
                <img src="/Content/Movie/Images/BandofBrothers.jpg" alt="兄弟连" />
                <span class="Name_zh">兄弟连</span><span class="Name_en">Band of Brothers</span>
            </li>
            <li>
                <img src="/Content/Movie/Images/ThePursuitofHappyness.jpg" alt="当幸福来敲门" />
                <span class="Name_zh">当幸福来敲门</span><span class="Name_en">The Pursuit of Happyness</span>
            </li>
            <li>
                <img src="/Content/Movie/Images/Friends.jpg" alt="老友记" />
                <span class="Name_zh">老友记</span><span class="Name_en">Friends</span>
            </li>
            <li>
                <img src="/Content/Movie/Images/HowIMetYourMother.jpg" alt="老爸老妈的浪漫史" />
                <span class="Name_zh">老爸老妈的浪漫史</span><span class="Name_en">How I Met Your Mother</span>
            </li>
            <li>
                <img src="/Content/Movie/Images/TheBigBangTheory.jpg" alt="生活大爆炸" />
                <span class="Name_zh">生活大爆炸</span><span class="Name_en">The Big Bang Theory</span>
            </li>
        </ul>
    </div>
</asp:Content>
