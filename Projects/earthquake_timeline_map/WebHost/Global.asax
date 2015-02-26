<%@ Application Language="C#" %>

<script RunAt="server">
    
    void Application_Start(object sender, EventArgs e)
    {
        //在应用程序启动时运行的代码

        EarthquakeService.DataCacheManager.Instance.Add("day",@"http://earthquake.usgs.gov/eqcenter/catalogs/1day-M2.5.xml");
        EarthquakeService.DataCacheManager.Instance.Add("week",@"http://earthquake.usgs.gov/eqcenter/catalogs/7day-M2.5.xml");

        EarthquakeService.DataCacheManager.Instance.Refresh();


        Timer timer = new Timer();//建立定时器，每隔一段时间刷新一次数据

        timer.Interval = 1000 * 60 * 10;
        timer.Tick += new EventHandler<EventArgs>(timer_Tick);
        timer.Enabled = true;

    }

    void timer_Tick(object sender, EventArgs e)
    {
        EarthquakeService.DataCacheManager.Instance.Refresh();
    }

    void Application_End(object sender, EventArgs e)
    {
        //在应用程序关闭时运行的代码

    }

    void Application_Error(object sender, EventArgs e)
    {
        //在出现未处理的错误时运行的代码

    }

    void Session_Start(object sender, EventArgs e)
    {
        //在新会话启动时运行的代码

    }

    void Session_End(object sender, EventArgs e)
    {
        //在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式 
        //设置为 StateServer 或 SQLServer，则不会引发该事件。

    }
       
</script>

