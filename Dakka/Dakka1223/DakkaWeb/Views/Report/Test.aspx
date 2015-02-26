<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
    CodeBehind="Test.aspx.cs" Inherits="DakkaWeb.Views.Report.Test" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="HeadContend" runat="server">

    <script src="../../Scripts/Report/Test.js" type="text/javascript"></script>

    <script src="../../Scripts/Shared/EmployeeRefField.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <div id="formMain">
    </div>
    <div>
        <asp:Chart ID="MainChart" runat="server" Width="800px" Height="400px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)"
            ImageType="Png" BackColor="WhiteSmoke" Palette="BrightPastel" BorderColor="26, 59, 105"
            BorderDashStyle="Solid" BackSecondaryColor="White" BackGradientStyle="TopBottom"
            BorderWidth="2">
            <Legends>
                <asp:Legend Enabled="True" IsTextAutoFit="False" Name="Default" BackColor="Transparent"
                    Font="Trebuchet MS, 8.25pt, style=Bold">
                </asp:Legend>
            </Legends>
            <BorderSkin SkinStyle="Emboss"></BorderSkin>
            <ChartAreas>
                <asp:ChartArea Name="MainChartArea" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"
                    BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="Transparent" BackGradientStyle="TopBottom">
                    <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False"
                        WallWidth="0" IsClustered="False" />
                    <AxisY LineColor="64, 64, 64, 64">
                        <LabelStyle Font="Trebuchet MS, 6pt, style=Bold" />
                        <MajorGrid LineColor="64, 64, 64, 64" />
                    </AxisY>
                    <AxisX LineColor="64, 64, 64, 64">
                        <LabelStyle Font="Trebuchet MS, 6pt, style=Bold" />
                        <MajorGrid LineColor="64, 64, 64, 64" />
                    </AxisX>
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </div>
</asp:Content>
