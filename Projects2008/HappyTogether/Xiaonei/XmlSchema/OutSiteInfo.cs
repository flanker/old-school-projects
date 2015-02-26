using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xiaonei.XmlSchema
{
    /// <summary>
    /// 站外邀请API响应
    /// </summary>
    public class invitations_getOsInfo_response
    {
        /// <summary>
        /// 外部邀请信息集合
        /// </summary>
        public os_invitation_info[] os_invitation_infos { get; set; }
    }

    /// <summary>
    /// 外部邀请信息
    /// </summary>
    public class os_invitation_info
    {
        /// <summary>
        /// 邀请者用户Id
        /// </summary>
        public int inviter_uid { get; set; }

        /// <summary>
        /// 邀请者邀请时间
        /// </summary>
        public string invite_time { get; set; }

        /// <summary>
        /// 被邀请者注册校内后的用户Id
        /// </summary>
        public int invitee_uid { get; set; }

        /// <summary>
        /// 被邀请者安装此App的时间
        /// </summary>
        public string install_time { get; set; }
    }
}
