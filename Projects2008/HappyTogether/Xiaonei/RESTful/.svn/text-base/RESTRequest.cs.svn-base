using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Xiaonei.Utilities;

namespace Xiaonei.RESTful
{
    /// <summary>
    /// REST方式的HTTP请求
    /// </summary>
    internal class RESTRequest
    {
        HttpWebRequest webRequest;
        Uri restServerUri;
        Encoding encoding = Encoding.UTF8;

        /// <summary>
        /// 获取当前HTTP请求的谓词
        /// </summary>
        public HttpMethod Method { get; private set; }

        /// <summary>
        /// 获取或设置当前HTTP请求的认证信息
        /// </summary>
        public ICredentials Credentials { get; set; }

        /// <summary>
        /// 获取一个表示超时时间以毫秒为单位的整数
        /// </summary>
        public int TimeOut { get; private set; }

        /// <summary>
        /// 获取当前HTTP请求的参数字典
        /// </summary>
        public IDictionary<string, string> Parameters { get; private set; }

        /// <summary>
        /// 指定请求地址和以GET方式创建一个请求实例
        /// </summary>
        /// <param name="server">完整URI格式的服务器地址</param>
        public RESTRequest(string server) :
            this(server, HttpMethod.GET, new Dictionary<string, string>())
        { }

        /// <summary>
        /// 指定请求地址和请求谓词创建一个请求实例
        /// </summary>
        /// <param name="server">完整URI格式的服务器地址</param>
        /// <param name="method">请求谓词</param>
        public RESTRequest(string server, HttpMethod method) :
            this(server, method, new Dictionary<string, string>())
        { }

        /// <summary>
        /// 指定请求地址和参数字典创建一个请求实例
        /// </summary>
        /// <param name="server">完整URI格式的服务器地址</param>
        /// <param name="queryParameters">参数字典</param>
        public RESTRequest(string server, IDictionary<string, string> queryParameters) :
            this(server, HttpMethod.GET, queryParameters)
        { }

        /// <summary>
        /// 指定请求地址、请求谓词及参数字典创建一个请求实例
        /// </summary>
        /// <param name="server">完整URI格式的服务器地址</param>
        /// <param name="method">请求谓词</param>
        /// <param name="queryParameters">参数字典</param>
        public RESTRequest(string server, HttpMethod method, IDictionary<string, string> queryParameters)
        {
            this.restServerUri = new Uri(server);
            this.Method = method;
            this.Parameters = queryParameters;
        }

        /// <summary>
        /// 执行请求并返回响应结果
        /// </summary>
        /// <returns></returns>
        public RESTResponse GetResponse()
        {
            PerformRequest();
            return new RESTResponse(webRequest.GetResponse());
        }

        private void PerformRequest()
        {
            var queryData = Parameters.ToQueryString();

            if (this.Method == HttpMethod.POST)
            {
                var data = encoding.GetBytes(queryData);

                webRequest = (HttpWebRequest)WebRequest.Create(restServerUri);
                webRequest.Method = "POST";
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.ContentLength = data.Length;

                using (Stream requestStream = webRequest.GetRequestStream())
                {
                    requestStream.Write(data, 0, data.Length);
                }
            }
            else
            {
                //GET is the default verb
                var server = restServerUri.AbsoluteUri;
                if (queryData.Length > 0) server = string.Format("{0}?{1}", server, queryData);
                webRequest = (HttpWebRequest)WebRequest.Create(server);
            }

            //Assign the http basic authentication credentials
            webRequest.Credentials = this.Credentials;
        }
    }
}