
namespace Xiaonei.XmlSchema
{
    public partial class friend
    {
        /// <summary>
        /// 返回用户的名字
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.name;
        }
    }

    public partial class user
    {
        /// <summary>
        /// 返回用户的名字
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.name;
        }
    }

    public partial class hs_info
    {
        /// <summary>
        /// 返回学校的名字
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.name;
        }
    }

    public partial class university_info
    {
        /// <summary>
        /// 返回大学的名字
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.name;
        }
    }

    public partial class work_info
    {
        /// <summary>
        /// 返回公司名称
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.company_name;
        }
    }
}