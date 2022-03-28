using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP
{
    public class GameAllInfo
    {
        private static RoleLogic selfRole;
        public static RoleLogic SelfRole
        {
            set
            {
                selfRole = value;
                GameUtils.ShowLog(string.Format("系统:现在已经设置了主角了，他的ID是：{0}", selfRole.id));
            }
            get
            {
                return selfRole;
            }
        }
    }
}
