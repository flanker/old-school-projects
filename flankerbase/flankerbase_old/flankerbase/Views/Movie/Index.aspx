<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Head" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="/Content/Movie/movie.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="BodyContent" runat="server">
    <div id="main">
        <ul>
            <li>
                <img src="/Content/Movie/Images/SavingPrivateRyan.jpg" alt="���ȴ�����" />
                <span class="Name_zh">���ȴ�����</span><span class="Name_en">Saving Private Ryan</span>
            </li>
            <li>
                <img src="/Content/Movie/Images/BandofBrothers.jpg" alt="�ֵ���" />
                <span class="Name_zh">�ֵ���</span><span class="Name_en">Band of Brothers</span>
            </li>
            <li>
                <img src="/Content/Movie/Images/ThePursuitofHappyness.jpg" alt="���Ҹ�������" />
                <span class="Name_zh">���Ҹ�������</span><span class="Name_en">The Pursuit of Happyness</span>
            </li>
            <li>
                <img src="/Content/Movie/Images/Friends.jpg" alt="���Ѽ�" />
                <span class="Name_zh">���Ѽ�</span><span class="Name_en">Friends</span>
            </li>
            <li>
                <img src="/Content/Movie/Images/HowIMetYourMother.jpg" alt="�ϰ����������ʷ" />
                <span class="Name_zh">�ϰ����������ʷ</span><span class="Name_en">How I Met Your Mother</span>
            </li>
            <li>
                <img src="/Content/Movie/Images/TheBigBangTheory.jpg" alt="�����ը" />
                <span class="Name_zh">�����ը</span><span class="Name_en">The Big Bang Theory</span>
            </li>
        </ul>
    </div>
</asp:Content>
