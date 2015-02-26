using System;

namespace Xiaonei.API
{
    /// <summary>
    /// API异常信息
    /// </summary>
    [Serializable]
    internal class APIException : Exception
    {
        /// <summary>
        /// 获取一个表示异常代码的整数
        /// </summary>
        public int ErrorCode { get; private set; }

        /// <summary>
        /// 用指定异常描述和错误代码实例化一个异常类
        /// </summary>
        /// <param name="message">异常描述</param>
        /// <param name="code">异常代码</param>
        public APIException(string message, int code)
            : base(message)
        {
            this.ErrorCode = code;
        }
    }
}