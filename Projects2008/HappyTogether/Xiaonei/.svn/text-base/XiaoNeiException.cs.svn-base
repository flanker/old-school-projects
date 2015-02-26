using System;
using System.Runtime.Serialization;

namespace Xiaonei
{
    /// <summary>
    /// 普通异常信息类
    /// </summary>
    [Serializable]
    public class XiaoNeiException : Exception
    {
        /// <summary>
        /// 实例化一个异常类
        /// </summary>
        public XiaoNeiException() : base() { }

        /// <summary>
        /// 用指定消息实例化一个异常类
        /// </summary>
        /// <param name="message"></param>
        public XiaoNeiException(string message) : base(message) { }

        /// <summary>
        /// 用指定异常描述和内部异常实例化一个异常类
        /// </summary>
        /// <param name="message">异常描述</param>
        /// <param name="innerException">内部异常</param>
        public XiaoNeiException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// 序列化一个普通异常类
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public XiaoNeiException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}