using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common
{
    public class CacheHelper
    {
        /// <summary>
        /// 从缓存中获取数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object Get(string key)
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            return cache.Get(key);
        }

        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Set(string key,object value)
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            cache[key] = value;
        }

        /// <summary>
        /// 写入缓存，带过期时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="time"></param>
        public static void Set(string key,object value,DateTime time)
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            cache.Insert(key, value, null, time,TimeSpan.Zero);
        }

        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key"></param>
        public static void Remove(string key)
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            cache.Remove(key);
        }
    }
}
