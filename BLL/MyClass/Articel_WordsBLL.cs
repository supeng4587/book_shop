﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace book_shop.BLL
{
    public partial class Articel_WordsBLL
    {
        /// <summary>
        /// 判断用户的评论中是否有禁用词
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool CheckForbid(string msg)
        {
            List<string> list = dal.GetForbidWord();
            string regex = string.Join("|", list.ToArray());//使用"|"组合成正则表达式“或者”格式
            regex = regex.Replace(@"\", @"\\").Replace(@"{2}", @".{0,2}");
            return Regex.IsMatch(msg, regex);
        }

        /// <summary>
        /// 判断用户的评论中是否有审查词
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool CheckMod(string msg)
        {
            List<string> list = dal.GetModWord();
            string regex = string.Join("|", list.ToArray());//使用"|"组合成正则表达式“或者”格式
            regex = regex.Replace(@"\", @"\\").Replace(@"{2}",@".{0,2}");
            return Regex.IsMatch(msg, regex);
        }

        /// <summary>
        /// 替换词过滤
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public string CheckReplace(string msg)
        {
            List<Model.Articel_WordsModel> list = dal.GetReplaseWord();
            foreach (var item in list)
            {
                msg = msg.Replace(item.WordPattern, item.ReplaceWord);
            }
            return msg;
        }

    }
}
