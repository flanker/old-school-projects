using System;
using System.Collections.Generic;
using Xiaonei.XmlSchema;

namespace Xiaonei.API
{
    /// <summary>
    /// 校内网开放平台API封装类
    /// </summary>
    public class APIClient
    {
        const string API_VERSION = "1.0";

        string apiKey;
        string secret;
        string encodedSessionKey;

        float callId = 0f;
        string signature = string.Empty;
        
        IResponseParser responseParser;

        /// <summary>
        /// 获取最后响应的原始文本
        /// </summary>
        public string RawResponse
        {
            get
            {
                if (responseParser != null) return responseParser.RawResponse;
                return string.Empty;
            }
        }

        /// <summary>
        /// 指定校内应用的api_key,secret和经过UrlEncode的session_key实例化一个APIClient对象
        /// </summary>
        /// <param name="api_key">登记应用时分配到的api_key</param>
        /// <param name="secret">校内应用的secret</param>
        /// <param name="encoded_session_key">经过UrlEncode的当前登录用户的session key</param>
        public APIClient(string api_key, string secret, string encoded_session_key)
            : this(api_key, secret, encoded_session_key, new XmlResponseParser())
        { }

        /// <summary>
        /// 指定校内应用的api_key,secret,经过UrlEncode的session_key和响应处理器实例化一个APIClient对象
        /// </summary>
        /// <param name="api_key">登记应用时分配到的api_key</param>
        /// <param name="secret">校内应用的secret</param>
        /// <param name="encoded_session_key">经过UrlEncode的当前登录用户的session key</param>
        /// <param name="parser">响应处理器</param>
        private APIClient(string api_key, string secret, string encoded_session_key, IResponseParser parser)
        {
            if (string.IsNullOrEmpty(api_key)) throw new ArgumentNullException("api_key", "APIClient初始化失败.必须指定登记应用时分配到的api_key.");
            if (string.IsNullOrEmpty(secret)) throw new ArgumentNullException("secret", "APIClient初始化失败.必须指定当前应用的secret");
            if (string.IsNullOrEmpty(encoded_session_key)) throw new ArgumentNullException("encoded_session_key", "APIClient初始化失败.必须指定经过UrlEncode的当前登录用户的session_key");

            this.apiKey = api_key;
            this.secret = secret;
            this.encodedSessionKey = encoded_session_key;

            this.responseParser = parser;
        }

        #region API方法

        /// <summary>
        /// 指定用户id获得用户的名字和头像图片地址headurl
        /// </summary>
        /// <param name="uids">用户id的列表，单个或多个，可以是逗号分隔的用户id列表</param>
        /// <returns>校内网用户集合</returns>
        public IEnumerable<user> UsersGetInfo(string uids)
        {
            return UsersGetInfo(uids, "name,headurl");
        }

        /// <summary>
        /// 指定用户id及返回的字段获得用户信息
        /// </summary>
        /// <param name="uids">用户id的列表，单个或多个，可以是逗号分隔的用户id列表</param>
        /// <param name="fields">返回的字段列表，可以指定返回那些字段，用逗号分隔</param>
        /// <returns></returns>
        public IEnumerable<user> UsersGetInfo(string uids, string fields)
        {
            return responseParser.Users_GetInfo(apiKey, APIMethod.Users_GetInfo, encodedSessionKey, callId, signature, API_VERSION, uids, fields).user;
        }

        /// <summary>
        /// 得到当前session的用户ID，返回的ID值应该在session有效期内被存储，从而避免重复地调用该方法。
        /// </summary>
        /// <returns></returns>
        public int UsersGetLoggedInUserId()
        {
            return responseParser.Users_GetLoggedInUser(apiKey, APIMethod.Users_GetLoggedInUser, encodedSessionKey, callId, signature, API_VERSION).Value;
        }

        /// <summary>
        /// 判断当前会话用户是否已经添加了该应用
        /// </summary>
        /// <returns></returns>
        public bool UsersIsAppAdded()
        {
            return UsersIsAppAdded(0);
        }

        /// <summary>
        /// 判断一个指定ID的用户是否已经添加了该应用
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public bool UsersIsAppAdded(int uid)
        {
            return responseParser.Users_IsAppAdded(apiKey, APIMethod.Users_IsAppAdded, callId, signature, API_VERSION, encodedSessionKey, uid);
        }

        /// <summary>
        /// 得到当前会话用户Profile中一个应用的XNML设置
        /// </summary>
        /// <returns></returns>
        public string ProfileGetXNML()
        {
            return ProfileGetXNML(0);
        }

        /// <summary>
        /// 得到一个指定ID的用户Profile中一个应用的XNML设置
        /// </summary>
        /// <param name="uid">得到XNML文本操作的用户的id</param>
        /// <returns></returns>
        public string ProfileGetXNML(int uid)
        {
            return responseParser.Profile_GetXNML(apiKey, APIMethod.Profile_GetXNML, callId, signature, API_VERSION, encodedSessionKey, uid);
        }

        /// <summary>
        /// 设置、更新当前会话用户的profile中一个应用的XNML片段
        /// </summary>
        /// <param name="profile">在Profile一个应用的box中要设置的XNML文本</param>
        /// <param name="profile_action">Profile的头像下面一个链接，方便用户操作应用</param>
        /// <returns></returns>
        public bool ProfileSetXNML(string profile, string profile_action)
        {
            return ProfileSetXNML(0, profile, profile_action);
        }

        /// <summary>
        /// 设置、更新一个指定ID的用户的profile中一个应用的XNML片段
        /// </summary>
        /// <param name="uid">发生更新XNML文本操作的用户的ID</param>
        /// <param name="profile">在Profile一个应用的box中要设置的XNML文本</param>
        /// <param name="profile_action">Profile的头像下面一个链接，方便用户操作应用</param>
        /// <returns></returns>
        public bool ProfileSetXNML(int uid, string profile, string profile_action)
        {
            return responseParser.Profile_SetXNML(apiKey, APIMethod.Profile_SetXNML, callId, signature, API_VERSION, encodedSessionKey, uid, profile, profile_action);
        }

        /// <summary>
        /// 得到当前登录用户的好友id列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> FriendsGet()
        {
            return responseParser.Friends_Get(apiKey, APIMethod.Friends_Get, encodedSessionKey, callId, signature, API_VERSION).uid;
        }

        /// <summary>
        /// 得到当前登录用户的好友列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<friend> FriendsGetFriends()
        {
            return responseParser.Friends_GetFriends(apiKey, APIMethod.Friends_GetFriends, encodedSessionKey, callId, signature, API_VERSION).friend;
        }

        /// <summary>
        /// 判断两组用户是否互为好友关系，比较的两组用户数必须相等
        /// </summary>
        /// <param name="uids1">第一组用户的ID，每个ID之间以逗号分隔</param>
        /// <param name="uids2">第二用组户的ID，每个ID之间以逗号分隔</param>
        /// <returns></returns>
        public IEnumerable<friend_info> FriendsAreFriends(string uids1, string uids2)
        {
            return responseParser.Friends_AreFriends(apiKey, APIMethod.Friends_AreFriends, encodedSessionKey, callId, signature, API_VERSION, uids1, uids2).friend_info;
        }

        /// <summary>
        /// 返回已经添加了一个应用的好友的用户Id列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> FriendsGetAppUsers()
        {
            return responseParser.Friends_GetAppUsers(apiKey, APIMethod.Friends_GetAppUsers, encodedSessionKey, callId, signature, API_VERSION).uid;
        }

        /// <summary>
        /// 给当前登录者的好友且安装了同样应用的用户发送自定义格式的新鲜事（news-feed、mini-feed），48小时之内最多可以调用10次
        /// </summary>
        /// <param name="template_id">注册的Feed模板Id，必须是真正注册的Feed模板</param>
        /// <param name="title_data">此项为JSON格式的数组，如果你在定义新鲜事模板的“Feed标题”时，自定义了一些变量（如Feed标题：{actor}完成了问卷{title}得分{mark}），那么你必须在此项中为这些变量（{actor}是系统变量，不需要赋值）赋值，例如此项值为：{"title":"语文课","mark":"90"}，此项也支持XNML语法，目前仅支持&lt;xn:name&gt;和&lt;a&gt;标签</param>
        /// <param name="body_data">此项为JSON格式的数组，规则同title_data项</param>
        /// <returns></returns>
        public bool FeedPublishTemplatizedAction(int template_id, string title_data, string body_data)
        {
            return responseParser.Feed_PublishTemplatizedAction(apiKey, APIMethod.Feed_PublishTemplatizedAction, encodedSessionKey, callId, signature, API_VERSION, template_id, title_data, body_data, 0);
        }

        /// <summary>
        /// 给当前登录者的好友且安装了同样应用的用户发送自定义格式的新鲜事（news-feed、mini-feed）
        /// </summary>
        /// <param name="template_id">注册的Feed模板Id，必须是真正注册的Feed模板</param>
        /// <param name="title_data">此项为JSON格式的数组，如果你在定义新鲜事模板的“Feed标题”时，自定义了一些变量（如Feed标题：{actor}完成了问卷{title}得分{mark}），那么你必须在此项中为这些变量（{actor}是系统变量，不需要赋值）赋值，例如此项值为：{"title":"语文课","mark":"90"}，此项也支持XNML语法，目前仅支持&lt;xn:name&gt;和&lt;a&gt;标签</param>
        /// <param name="body_data">此项为JSON格式的数组，规则同title_data项</param>
        /// <param name="resource_id">比如：发表Blog时要分发Feed，则此参数可以传入此Blog的id。此参数在展示Feed时会用到，用于去掉重复的Feed</param>
        /// <returns></returns>
        public bool FeedPublishTemplatizedAction(int template_id, string title_data, string body_data, int resource_id)
        {
            return responseParser.Feed_PublishTemplatizedAction(apiKey, APIMethod.Feed_PublishTemplatizedAction, encodedSessionKey, callId, signature, API_VERSION, template_id, title_data, body_data, resource_id);
        }

        /// <summary>
        /// 给自己发一个通知
        /// </summary>
        /// <param name="notification">通知的内容，可以是XNML类型的文本信息，支持的XNML有&lt;xn:name&gt;和&lt;a&gt;，请注意：使用&lt;xn:name&gt;标签的时候，其uid属性值只能是真实的用户id</param>
        public void NotificationsSend(string notification)
        {
            responseParser.Notifications_Send(apiKey, APIMethod.Notifications_Send, encodedSessionKey, callId, signature, API_VERSION, string.Empty, notification);
        }

        /// <summary>
        /// 给当前登录者的好友或也安装了同样应用的用户发送通知
        /// </summary>
        /// <param name="uids">用户id的列表，单个或多个，可以是逗号分隔，如 8055,8066,8077 。这些用户必须是当前登录者的好友或也安装了此应用。请确保一次传入的用户id数少于20个。</param>
        /// <param name="notification">通知的内容，可以是XNML类型的文本信息，支持的XNML有&lt;xn:name&gt;和&lt;a&gt;，请注意：使用&lt;xn:name&gt;标签的时候，其uid属性值只能是真实的用户id</param>
        public void NotificationsSend(string uids, string notification)
        {
            responseParser.Notifications_Send(apiKey, APIMethod.Notifications_Send, encodedSessionKey, callId, signature, API_VERSION, uids, notification);
        }

        /// <summary>
        /// 根据站外邀请id得到此次邀请的详细信息（邀请人、邀请时间、被邀请人、安装app时间等）
        /// </summary>
        /// <param name="invite_ids">站外邀请id，可以是一个或多个邀请id，多个邀请id之间用逗号分隔</param>
        /// <returns></returns>
        public IEnumerable<os_invitation_info> InvitationsGetOsInfo(string invite_ids)
        {
            return responseParser.Invitations_GetOsInfo(apiKey, encodedSessionKey, APIMethod.Invitations_GetOsInfo, callId, signature, API_VERSION, invite_ids).os_invitation_infos;
        }

        #endregion

        private float GenerateCallId()
        {
            return 0f;
        }

        private string GenerateSignature(IDictionary<string, string> parameters)
        {
            return string.Empty;
        }
    }
}