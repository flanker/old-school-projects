<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">首页</asp:Content>
<asp:Content ID="InHead" ContentPlaceHolderID="InHeadContent" runat="server">
    <script type="text/javascript">
        var setCurrentViewPage = function(pageIndex) {
            $('#content .viewport').css('left', getLeftPixer(pageIndex));
            setDotLinkHover(pageIndex);
        }

        var setDotLinkHover = function(pageIndex) {
            $('#content a.dot-link').removeClass('dot-link-hover');
            $('#content a.dot-link:eq(' + pageIndex + ')').addClass('dot-link-hover');
        }

        var getLeftPixer = function(pageIndex) {
            return 80 - (640 * pageIndex);
        }

        var getCurrentIndexByHash = function() {
            var result = 0;
            if (location.hash && location.hash.length > 3) {
                var hash_id = '#' + location.hash.substring(3);
                if ($(hash_id).length > 0) {
                    result = parseInt($(hash_id).attr('data-index'));
                }
            }
            return result;
        }

        var getCurrentIndexByDotlink = function() {
            return parseInt($('#content a.dot-link-hover').attr('data-index'));
        }

        var getViewpageCount = function() {
            return $('#content .viewpart').length;
        }

        var moveToViewport = function(pageIndex, speed) {
            if (pageIndex == 0) {
                location.hash = '';
            }
            else {
                location.hash = '!/' + $('#content .viewpart')[pageIndex].id;
            }
            setDotLinkHover(pageIndex);
            $('#content .viewport').animate({ 'left': getLeftPixer(pageIndex) }, speed, function() {  });
        }

        var viewportNextHandler = function() {
            var curr = getCurrentIndexByDotlink();
            if (curr < getViewpageCount() - 1) {
                moveToViewport(curr + 1, 1000);
            }
            return false;
        }

        var viewportPrevHandler = function() {
            var curr = getCurrentIndexByDotlink();
            if (curr > 0) {
                moveToViewport(curr - 1, 1000);
            }
            return false;
        }

        var dotlinkClickHandler = function() {
            var target = parseInt($(this).attr('data-index'));
            if (target != getCurrentIndexByDotlink()) {
                moveToViewport(target, 1000);
            }
            return false;
        }

        // start here
        $(function() {

            setCurrentViewPage(getCurrentIndexByHash());

            $('#viewport-next').click(viewportNextHandler);
            $('#viewport-prev').click(viewportPrevHandler);

            $(document).keydown(function(event) {
                switch (event.keyCode) {
                    case 13: //回车
                    case 32: //空格
                    case 39: //右方向键
                        viewportNextHandler;
                        break;
                    case 37: //左方向键
                        viewportPrevHandler;
                        break;
                }
            });

            $('#content a.dot-link').click(dotlinkClickHandler);
        });
    </script>
</asp:Content>
<asp:Content ID="InPage" ContentPlaceHolderID="InPageContent" runat="server">
    <div class="large-page">
        <div class="large-page-part">
            <div class="view">
                <div class="viewport">
                    <div class="viewpart" id="starter">
                        <div class="viewpart-title" style="margin-top: 226px; margin-left: 73px;">我是冯智超，这是我的故事。 >>></div>
                    </div>
                    <div class="viewpart" id="1986-birth" data-index="1">
                        <div class="viewpart-title" style="margin-top: 82px; margin-left: 164px;">1986.8</div>
                        <div class="viewpart-content" style="margin-top: 26px; margin-left: 73px;">冯智超睁开眼睛，来到了这个世界。男，属虎，处女座。</div>
                    </div>
                    <div class="viewpart" id="1992-first-blood" data-index="2">
                        <div class="viewpart-title" style="margin-top: 138px; margin-left: 90px;">1992</div>
                        <div class="viewpart-content" style="margin-top: 26px; margin-left: 73px;">小学一年级，冯智超在同学家，第一次见到了计算机。那是一个俄罗斯方块游戏，不同于红白机上的俄罗斯方块的是，每消除一层方块，屏幕右侧的“美女”就会多显示出一部分...</div>
                    </div>
                    <div class="viewpart" id="1996-1998-learning-computer" data-index="3">
                        <div class="viewpart-title" style="margin-top: 99px; margin-left: 144px;">1996 ~ 1998</div>
                        <div class="viewpart-content" style="margin-top: 26px; margin-left: 73px;">小学五年级，冯智超多了一门叫《计算机》的课。冯智超接触了 DOS 命令、打字、LOGO 和 Basic 程序，机房、软盘、小海龟是那段日子的记忆。</div>
                    </div>
                    <div class="viewpart" id="1998-2004-high-school" data-index="4">
                        <div class="viewpart-title" style="margin-top: 130px; margin-left: 202px;">1998 ~ 2004</div>
                        <div class="viewpart-content" style="margin-top: 26px; margin-left: 73px;">中学。冯智超进入了应试教育，住校、晚自习、练习题、背书、考试一大堆事儿。偶尔，冯智超会在政治课上用同桌“文曲星”的 Basic 写一个《冯智超大战班主任》。</div>
                    </div>
                    <div class="viewpart" id="2004-college-entrance" data-index="5">
                        <div class="viewpart-title" style="margin-top: 126px; margin-left: 137px;">2004.6</div>
                        <div class="viewpart-content" style="margin-top: 26px; margin-left: 73px;">高考。冯智超终于在高考志愿书上填写了那个专业——《软件工程》。还好，没有落榜。</div>
                    </div>
                    <div class="viewpart" id="2004-2008-university" data-index="6">
                        <div class="viewpart-title" style="margin-top: 68px; margin-left: 65px;">2004 ~ 2008</div>
                        <div class="viewpart-content" style="margin-top: 26px; margin-left: 73px;">大学四年，很快，一闪而过。冯智超都干嘛了？学习，玩儿，睡觉，打豆豆。</div>
                    </div>
                    <div class="viewpart" id="2008-now-and-future" data-index="7">
                        <div class="viewpart-title" style="margin-top: 108px; margin-left: 292px;">2008 ~ </div>
                        <div class="viewpart-content" style="margin-top: 26px; margin-left: 73px;">未来在哪里？冯智超 Google 不出来，也在问自己。</div>
                    </div>
                    <div class="clear"></div>
                </div>
                <a class="viewport-nav" id="viewport-prev" href="#" title="上一张幻灯片 使用键盘左箭头也可以操作">&lt;</a> <a class="viewport-nav" id="viewport-next" href="#" title="下一张幻灯片 使用键盘右箭头也可以操作">&gt;</a> 
            </div>
        </div>
        <div>
            <ul class="dots">
                <li><a class="dot-link dot-link-hover" href="#" data-index="0"></a></li>
                <li><a class="dot-link" href="#!/1986-birth" data-index="1"></a></li>
                <li><a class="dot-link" href="#!/1992-first-blood" data-index="2"></a></li>
                <li><a class="dot-link" href="#!/1996-1998-learning-compute" data-index="3"></a></li>
                <li><a class="dot-link" href="#!/1998-2004-high-school" data-index="4"></a></li>
                <li><a class="dot-link" href="#!/2004-college-entrance" data-index="5"></a></li>
                <li><a class="dot-link" href="#!/2004-2008-university" data-index="6"></a></li>
                <li><a class="dot-link" href="#!/2008-now-and-future" data-index="7"></a></li>
            </ul>
        </div>
    </div>
</asp:Content>
