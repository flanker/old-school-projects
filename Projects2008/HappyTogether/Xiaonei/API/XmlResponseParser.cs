using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Xiaonei.RESTful;
using Xiaonei.XmlSchema;

namespace Xiaonei.API
{
    /// <summary>
    /// XML响应处理器
    /// </summary>
    internal class XmlResponseParser : IResponseParser
    {
        const string API_VERSION = "1.0";
        const string API_SERVER = "http://api.xiaonei.com/restserver.do";
        const string API_SECURITY_SERVER = "https://api.xiaonei.com/restserver.do";

        RESTRequest client;
        RESTResponse response;
        Dictionary<string, string> parameters = new Dictionary<string, string>();

        public XmlResponseParser() { }

        #region IResponseParser Members

        public ResponseFormat Format { get { return ResponseFormat.XML; } }

        public string RawResponse
        {
            get
            {
                if (this.response != null) return this.response.RawResponse;
                return string.Empty;
            }
        }

        public string Auth_CreateToken()
        {
            throw new NotImplementedException();
        }

        public session_info Auth_GetSession()
        {
            throw new NotImplementedException();
        }

        public users_getInfo_response Users_GetInfo(string api_key, string method, string session_key, float call_id, string sig, string v, string uids, string fields)
        {
            if (string.IsNullOrEmpty(uids)) throw new ArgumentNullException("uids", "必须指定用户id");

            AssignRequiredParameters(api_key, session_key, method);
            parameters.Add("uids", uids);
            parameters.Add("fields", fields);

            //client = new RESTRequest(API_SERVER, parameters);
            client = new RESTRequest(API_SERVER, HttpMethod.POST, parameters);
            response = client.GetResponse();

            var root = XElement.Parse(response.RawResponse);
            CheckErrorResponse(root);

            var ns = root.Name.Namespace;
            var userElements = from node in root.Elements(ns + "user")
                               select node;

            var userEntities = new List<user>();
            foreach (var usernode in userElements)
            {
                user u = new user();
                u.uid = (int)usernode.Element(ns + "uid");

                if (fields.Contains("name")) u.name = (string)usernode.Element(ns + "name");

                if (fields.Contains("sex"))
                {
                    u.sex = (int)usernode.Element(ns + "sex");
                    u.sexSpecified = true;
                }
                else
                {
                    u.sex = -1;
                    u.sexSpecified = false;
                }

                if (fields.Contains("birthday")) u.birthday = (string)usernode.Element(ns + "birthday");
                if (fields.Contains("headurl")) u.headurl = (string)usernode.Element(ns + "headurl");
                if (fields.Contains("mainurl")) u.mainurl = (string)usernode.Element(ns + "mainurl");
                if (fields.Contains("tinyurl")) u.tinyurl = (string)usernode.Element(ns + "tinyurl");

                if (fields.Contains("hometown_location") && usernode.Element(ns + "hometown_location") != null)
                {
                    u.hometown_location = new hometown_location()
                    {
                        country = (string)usernode.Element(ns + "hometown_location").Element(ns + "country"),
                        province = (string)usernode.Element(ns + "hometown_location").Element(ns + "province"),
                        city = (string)usernode.Element(ns + "hometown_location").Element(ns + "city")
                    };
                }

                if (fields.Contains("work_history") && usernode.Element(ns + "work_history") != null)
                {
                    u.work_history = new work_history()
                    {
                        list = (bool)usernode.Element(ns + "work_history").Attribute("list"),
                        listSpecified = true,
                        work_info = (from wel in usernode.Element(ns + "work_history").Elements(ns + "work_info")
                                     select new work_info()
                                     {
                                         company_name = (string)wel.Element(ns + "company_name"),
                                         description = (string)wel.Element(ns + "description"),
                                         start_date = (string)wel.Element(ns + "start_date"),
                                         end_date = (string)wel.Element(ns + "end_date"),
                                     }).ToArray(),
                    };
                }

                if (fields.Contains("university_history") && usernode.Element(ns + "university_history") != null)
                {
                    u.university_history = new university_history()
                    {
                        list = (bool)usernode.Element(ns + "university_history").Attribute("list"),
                        listSpecified = true,
                        university_info = (from uel in usernode.Element(ns + "university_history").Elements(ns + "university_info")
                                           select new university_info()
                                           {
                                               name = (string)uel.Element(ns + "name"),
                                               year = (int)uel.Element(ns + "year"),
                                               department = (string)uel.Element(ns + "department"),
                                               yearSpecified = uel.Element(ns + "year") != null,
                                           }).ToArray(),
                    };
                }

                if (fields.Contains("hs_history") && usernode.Element(ns + "hs_history") != null)
                {
                    u.hs_history = new hs_history()
                    {
                        list = (bool)usernode.Element(ns + "hs_history").Attribute("list"),
                        listSpecified = true,
                        hs_info = (from hel in usernode.Element(ns + "hs_history").Elements(ns + "hs_info")
                                   select new hs_info()
                                   {
                                       name = (string)hel.Element(ns + "name"),
                                       grad_year = (int)hel.Element(ns + "grad_year"),
                                       grad_yearSpecified = hel.Element(ns + "grad_year") != null,
                                   }).ToArray(),
                    };
                }

                userEntities.Add(u);
            }

            var usersinfo = new users_getInfo_response()
            {
                list = (bool)root.Attribute("list"),
                user = userEntities.ToArray()
            };

            return usersinfo;
        }

        public users_getLoggedInUser_response Users_GetLoggedInUser(string api_key, string method, string session_key, float call_id, string sig, string v)
        {
            AssignRequiredParameters(api_key, session_key, method);

            client = new RESTRequest(API_SERVER, parameters);
            response = client.GetResponse();

            var root = XElement.Parse(response.RawResponse);
            CheckErrorResponse(root);

            var uservalue = new users_getLoggedInUser_response()
            {
                Value = Int32.Parse(root.Value)
            };

            return uservalue;
        }

        public bool Users_IsAppAdded(string api_key, string method, float call_id, string sig, string v, string session_key, int uid)
        {
            AssignRequiredParameters(api_key, session_key, method);
            if (uid != 0) parameters.Add("uid", uid.ToString());

            client = new RESTRequest(API_SERVER, parameters);
            response = client.GetResponse();

            var root = XElement.Parse(response.RawResponse);
            CheckErrorResponse(root);

            return root.Value == "1";
        }

        public string Profile_GetXNML(string api_key, string method, float call_id, string sig, string v, string session_key, int uid)
        {
            AssignRequiredParameters(api_key, session_key, method);
            if (uid != 0) parameters.Add("uid", uid.ToString());

            client = new RESTRequest(API_SERVER, parameters);
            response = client.GetResponse();

            var root = XElement.Parse(response.RawResponse);
            CheckErrorResponse(root);

            return root.Value;
        }

        public bool Profile_SetXNML(string api_key, string method, float call_id, string sig, string v, string session_key, int uid, string profile, string profile_action)
        {
            AssignRequiredParameters(api_key, session_key, method);
            if (uid != 0) parameters.Add("uid", uid.ToString());
            if (!string.IsNullOrEmpty(profile)) parameters.Add("profile", profile);
            if (!string.IsNullOrEmpty(profile_action)) parameters.Add("profile_action", profile_action);

            client = new RESTRequest(API_SERVER, parameters);
            response = client.GetResponse();

            var root = XElement.Parse(response.RawResponse);
            CheckErrorResponse(root);

            return root.Value == "1";
        }

        public friends_get_response Friends_Get(string api_key, string method, string session_key, float call_id, string sig, string v)
        {
            AssignRequiredParameters(api_key, session_key, method);
            client = new RESTRequest(API_SERVER, parameters);
            response = client.GetResponse();

            var root = XElement.Parse(response.RawResponse);
            CheckErrorResponse(root);

            var ns=root.Name.Namespace;
            var fidsget = new friends_get_response()
            {
                list = (bool)root.Attribute("list"),
                uid = (from idel in root.Elements(ns + "uid")
                       select Int32.Parse(idel.Value)).ToArray()
            };

            return fidsget;
        }

        public friends_getFriends_response Friends_GetFriends(string api_key, string method, string session_key, float call_id, string sig, string v)
        {
            AssignRequiredParameters(api_key, session_key, method);
            client = new RESTRequest(API_SERVER, parameters);
            response = client.GetResponse();

            var root = XElement.Parse(response.RawResponse);
            CheckErrorResponse(root);
            var ns = root.Name.Namespace;

            var fgf = new friends_getFriends_response()
            {
                list = (bool)root.Attribute("list"),
                friend = (from fel in root.Elements(ns + "friend")
                          select new friend()
                          {
                              id = (int)fel.Element(ns + "id"),
                              name = (string)fel.Element(ns + "name"),
                              headurl = (string)fel.Element(ns + "headurl"),
                          }).ToArray(),
            };

            return fgf;
        }

        public friends_areFriends_response Friends_AreFriends(string api_key, string method, string session_key, float call_id, string sig, string v, string uids1, string uids2)
        {
            if (string.IsNullOrEmpty(uids1)) throw new ArgumentNullException("uids1", "必须指定第一组进行比较的用户id");
            if (string.IsNullOrEmpty(uids2)) throw new ArgumentNullException("uids2", "必须指定第二组进行比较的用户id");

            var ids1 = uids1.Split(',');
            var ids2 = uids2.Split(',');
            if (ids1.Length != ids2.Length) throw new ArgumentException("两组进行比较的用户id数量必须相同", "uids1 or uids2");

            AssignRequiredParameters(api_key, session_key, method);
            parameters.Add("uids1", uids1);
            parameters.Add("uids2", uids2);

            client = new RESTRequest(API_SERVER, parameters);
            response = client.GetResponse();

            var root = XElement.Parse(response.RawResponse);
            CheckErrorResponse(root);
            var ns = root.Name.Namespace;

            var faf = new friends_areFriends_response()
            {
                //list = (bool)root.Attribute("list"),
                list = true,
                friend_info = (from fel in root.Elements(ns + "friend_info")
                               select new friend_info()
                               {
                                   uid1 = (int)fel.Element(ns + "uid1"),
                                   uid2 = (int)fel.Element(ns + "uid2"),
                                   are_friends = fel.Element(ns + "are_friends").Value == "1",
                               }).ToArray(),
            };

            return faf;
        }

        public friends_getAppUsers_response Friends_GetAppUsers(string api_key, string method, string session_key, float call_id, string sig, string v)
        {
            AssignRequiredParameters(api_key, session_key, method);
            client = new RESTRequest(API_SERVER, parameters);
            response = client.GetResponse();

            var root = XElement.Parse(response.RawResponse);
            CheckErrorResponse(root);
            var ns = root.Name.Namespace;

            var fappusers = new friends_getAppUsers_response()
            {
                //list = (bool)root.Attribute("list"),
                list = true,
                uid = (from idel in root.Elements(ns + "uid")
                       select Int32.Parse(idel.Value)).ToArray()
            };

            return fappusers;
        }

        public bool Feed_PublishTemplatizedAction(string api_key, string method, string session_key, float call_id, string sig, string v, int template_id, string title_data, string body_data, int resource_id)
        {
            if (string.IsNullOrEmpty(title_data)) throw new ArgumentNullException("title_data", "必须指定Feed的标题数据");
            if (string.IsNullOrEmpty(body_data)) throw new ArgumentNullException("body_data", "必须指定Feed的内容数据");

            AssignRequiredParameters(api_key, session_key, method);
            parameters.Add("template_id", template_id.ToString());
            parameters.Add("title_data", title_data);
            parameters.Add("body_data", body_data);
            parameters.Add("resource_id", resource_id.ToString());

            client = new RESTRequest(API_SERVER, parameters);
            response = client.GetResponse();

            var root = XElement.Parse(response.RawResponse);
            CheckErrorResponse(root);

            return root.Value == "1";
        }

        public void Notifications_Send(string api_key, string method, string session_key, float call_id, string sig, string v, string to_ids, string notification)
        {
            if (string.IsNullOrEmpty(notification)) throw new ArgumentNullException("notification", "必须指定通知内容");

            AssignRequiredParameters(api_key, session_key, method);
            parameters.Add("to_ids", to_ids);
            parameters.Add("notification", notification);

            client = new RESTRequest(API_SERVER, parameters);
            response = client.GetResponse();

            var root = XElement.Parse(response.RawResponse);
            CheckErrorResponse(root);
            //everything is ok if no error occured.
        }

        public invitations_getOsInfo_response Invitations_GetOsInfo(string api_key, string session_key, string method, float call_id, string sig, string v, string invite_ids)
        {
            if (string.IsNullOrEmpty(invite_ids)) throw new ArgumentNullException("invite_ids", "必须指定站外邀请id");

            AssignRequiredParameters(api_key, session_key, method);
            parameters.Add("invite_ids", invite_ids);

            client = new RESTRequest(API_SERVER, parameters);
            response = client.GetResponse();

            var root = XElement.Parse(response.RawResponse);
            CheckErrorResponse(root);
            var ns = root.Name.Namespace;

            var osinfo = new invitations_getOsInfo_response()
            {
                os_invitation_infos = (from infoel in root.Elements(ns + "os_invitation_info")
                                       select new os_invitation_info()
                                       {
                                           inviter_uid = (int)infoel.Element(ns + "inviter_uid"),
                                           invite_time = (string)infoel.Element(ns + "invite_time"),
                                           invitee_uid = (int)infoel.Element(ns + "invitee_uid"),
                                           install_time = (string)infoel.Element(ns + "install_time")
                                       }).ToArray()
            };

            return osinfo;
        }

        #endregion

        /// <summary>
        /// 检查响应XML是否包含错误信息，并抛出APIException
        /// </summary>
        /// <param name="xml">XElement</param>
        void CheckErrorResponse(XElement xml)
        {
            if (xml.Name == "error_response") throw new APIException((string)xml.Element("error_msg"), (int)xml.Element("error_code"));
        }

        /// <summary>
        /// 更新字典中的参数
        /// </summary>
        /// <param name="api_key"></param>
        /// <param name="session_key"></param>
        /// <param name="method"></param>
        void AssignRequiredParameters(string api_key, string session_key, string method)
        {
            parameters.Clear();

            parameters["api_key"] = api_key;
            parameters["session_key"] = session_key;
            parameters["method"] = method;
            parameters["call_id"] = string.Empty;
            parameters["sig"] = string.Empty;
            parameters["v"] = API_VERSION;
            parameters["format"] = this.Format.ToString();
        }
    }
}