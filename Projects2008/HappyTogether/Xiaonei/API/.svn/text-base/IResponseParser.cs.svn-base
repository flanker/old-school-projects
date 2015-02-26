using Xiaonei.XmlSchema;

namespace Xiaonei.API
{
    /// <summary>
    /// API响应处理器接口，请完整实现此接口定义您自己的响应处理器
    /// </summary>
    internal interface IResponseParser
    {
        /// <summary>
        /// 获取一个表示响应格式的ResponseFormat枚举值，一个处理器只处理一种格式
        /// </summary>
        ResponseFormat Format { get; }

        /// <summary>
        /// 获取一个表示响应文本的字符串
        /// </summary>
        string RawResponse { get; }

        #region Xiaonei API definitions

        string Auth_CreateToken();
        session_info Auth_GetSession();

        users_getInfo_response Users_GetInfo(string api_key, string method, string session_key, float call_id, string sig, string v, string uids, string fields);
        users_getLoggedInUser_response Users_GetLoggedInUser(string api_key, string method, string session_key, float call_id, string sig, string v);
        bool Users_IsAppAdded(string api_key, string method, float call_id, string sig, string v, string session_key, int uid);

        string Profile_GetXNML(string api_key, string method, float call_id, string sig, string v, string session_key, int uid);
        bool Profile_SetXNML(string api_key, string method, float call_id, string sig, string v, string session_key, int uid, string profile, string profile_action);

        friends_get_response Friends_Get(string api_key, string method, string session_key, float call_id, string sig, string v);
        friends_getFriends_response Friends_GetFriends(string api_key, string method, string session_key, float call_id, string sig, string v);
        friends_areFriends_response Friends_AreFriends(string api_key, string method, string session_key, float call_id, string sig, string v, string uids1, string uids2);
        friends_getAppUsers_response Friends_GetAppUsers(string api_key, string method, string session_key, float call_id, string sig, string v);

        bool Feed_PublishTemplatizedAction(string api_key, string method, string session_key, float call_id, string sig, string v, int template_id, string title_data, string body_data, int resource_id);

        void Notifications_Send(string api_key, string method, string session_key, float call_id, string sig, string v, string to_ids, string notification);

        invitations_getOsInfo_response Invitations_GetOsInfo(string api_key, string session_key, string method, float call_id, string sig, string v, string invite_ids);

        #endregion
    }
}