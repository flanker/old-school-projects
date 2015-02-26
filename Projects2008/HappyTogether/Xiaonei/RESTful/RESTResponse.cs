using System;
using System.IO;
using System.Net;

namespace Xiaonei.RESTful
{
    /// <summary>
    /// REST方式的响应类
    /// </summary>
    internal class RESTResponse
    {
        HttpWebResponse webResponse;

        /// <summary>
        /// 获取响应的原始文本
        /// </summary>
        public string RawResponse { get; private set; }

        /// <summary>
        /// 获取响应的状态代码
        /// </summary>
        public HttpStatusCode StatusCode { get; private set; }

        /// <summary>
        /// 创建响应实例，你应该配合RESTRequest使用该类
        /// </summary>
        /// <param name="response"></param>
        public RESTResponse(WebResponse response)
        {
            this.webResponse = (HttpWebResponse)response;
            ProcessResponse();
            this.StatusCode = webResponse.StatusCode;
        }

        private void ProcessResponse()
        {
            if (this.webResponse == null) throw new ArgumentNullException("response", "Response can not be null");

            using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
            {
                this.RawResponse = reader.ReadToEnd();
            }
        }
    }
}