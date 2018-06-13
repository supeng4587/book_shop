using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book_shop.BLL
{
    public partial class SettingsBLL
    {
        /// <summary>
        /// 根据配置项的名称，获取具体的配置值，先判断缓存是否有记录
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetValue(string key)
        {
            if (Common.CacheHelper.Get("Setting_"+key) == null)
            {
                string value = dal.GetModel(key).Value;
                Common.CacheHelper.Set("Setting_" + key, value);
                return value;
            }
            else
            {
                return Common.CacheHelper.Get("Setting_" + key).ToString();

            }
        }
    }
}
