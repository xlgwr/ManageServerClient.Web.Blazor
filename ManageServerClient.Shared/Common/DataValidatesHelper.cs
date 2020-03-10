using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ManageServerClient.Shared.Common.Common
{
    /// <summary>
    /// 数据验证
    /// </summary>
    public class DataValidatesHelper
    {
        #region 公用方法
        /// <summary>
        /// 界面输入端  数据验证
        /// </summary>
        /// <param name="filedDesc">字段描述</param>
        /// <param name="filedValue">字段值</param>
        /// <param name="validatesType">验证的数据类型  多个以 | 隔开 如:ValidatesType.Empty | ValidatesType.English</param>
        /// <param name="minLength">最小长度</param>
        /// <param name="maxLength">最大长度</param>
        /// <returns>验证成功 返回空字符串，失败返回错误信息</returns>
        public static string ValidatesData(string filedDesc, string filedValue, ValidatesType validatesType, int minLength = 0, int maxLength = 30)
        {
            var msgInfo = string.Empty;
            //验证非空
            if ((validatesType & ValidatesType.Empty) == ValidatesType.Empty)
            {
                if (ValidatesEmpty(filedDesc, filedValue, out msgInfo) == false)
                {
                    return msgInfo;
                }
            }

            //验证非中文
            if ((validatesType & ValidatesType.English) == ValidatesType.English)
            {
                if (ValidatesEnglish(filedDesc, filedValue, out msgInfo) == false)
                {
                    return msgInfo;
                }
            }

            //验证只能输入数字 --正数
            if ((validatesType & ValidatesType.Digital) == ValidatesType.Digital)
            {
                if (ValidatesPlusDigital(filedDesc, filedValue, out msgInfo) == false)
                {
                    return msgInfo;
                }
            }

            //验证只能输入数字 --正负数
            if ((validatesType & ValidatesType.PlusDigital) == ValidatesType.PlusDigital)
            {
                if (ValidatesDigital(filedDesc, filedValue, out msgInfo) == false)
                {
                    return msgInfo;
                }
            }

            //验证输入的数据长度
            if ((validatesType & ValidatesType.Length) == ValidatesType.Length)
            {
                if (ValidatesLength(filedDesc, filedValue, out msgInfo, minLength, maxLength) == false)
                {
                    return msgInfo;
                }
            }

            return msgInfo;
        }
        #endregion


        /// <summary>
        /// 验证是否可为空
        /// </summary>
        /// <param name="filedDesc">字段描述</param>
        /// <param name="filedValue">字段值</param>
        /// <returns></returns>
        private static bool ValidatesEmpty(string filedDesc, string filedValue, out string msgInfo)
        {
            msgInfo = string.Empty;
            if (string.IsNullOrWhiteSpace(filedValue))
            {
                msgInfo = $"{filedDesc}{"不能为空"}";
                return false;
            }
            return true;
        }

        /// <summary>
        /// 验证只能输入英文字符
        /// </summary>
        /// <param name="filedDesc">字段描述</param>
        /// <param name="filedValue">字段值</param>
        /// <returns></returns>
        private static bool ValidatesEnglish(string filedDesc, string filedValue, out string msgInfo)
        {
            msgInfo = string.Empty;
            if (Regex.IsMatch(filedValue, @"[\u4e00-\u9fa5]"))
            {
                msgInfo = $"{filedDesc}{"只能输入英文"}";
                return false;
            }
            return true;
        }

        /// <summary>
        /// 验证只能输入数字 --正负数
        /// </summary>
        /// <param name="filedDesc">字段描述</param>
        /// <param name="filedValue">字段值</param>
        /// <returns></returns>
        private static bool ValidatesDigital(string filedDesc, string filedValue, out string msgInfo)
        {
            msgInfo = string.Empty; //
            var strValidRealPattern = @"^(0|[1-9][0-9]*)(\.\d+)?$|^-(0|[1-9][0-9]*)(\.\d+)?$";
            Regex reg = new Regex(strValidRealPattern);
            Match ma = reg.Match(filedValue);
            if (ma.Success == false)
            {
                msgInfo = $"{filedDesc}{"只能输入数字"}";
                return false;
            }
            return true;
        }


        /// <summary>
        /// 验证只能输入数字 --正数
        /// </summary>
        /// <param name="filedDesc">字段描述</param>
        /// <param name="filedValue">字段值</param>
        /// <returns></returns>
        private static bool ValidatesPlusDigital(string filedDesc, string filedValue, out string msgInfo)
        {
            msgInfo = string.Empty; //
            var strValidRealPattern = @"^(0|[1-9][0-9]*)(\.\d+)?$";
            Regex reg = new Regex(strValidRealPattern);
            Match ma = reg.Match(filedValue);
            if (ma.Success == false)
            {
                msgInfo = $"{filedDesc}{"只能输入数字"}";
                return false;
            }
            return true;
        }


        /// <summary>
        /// 验证数据长度
        /// </summary>
        /// <param name="filedDesc">字段描述</param>
        /// <param name="filedValue">字段值</param>
        /// <param name="msgInfo">返回值</param>
        /// <param name="minLength">最小长度</param>
        /// <param name="maxLength">最大长度</param>
        /// <returns></returns>
        private static bool ValidatesLength(string filedDesc, string filedValue, out string msgInfo, int minLength, int maxLength)
        {
            msgInfo = string.Empty;
            if (filedValue.Length < minLength || filedValue.Length > maxLength)
            {
                msgInfo = $"{filedDesc}长度只能在{minLength}到{maxLength}之间";
                return false;
            }
            return true;
        }

    }

    /// <summary>
    /// 数据验证的类型
    /// </summary>
    [Flags]
    public enum ValidatesType
    {
        /// <summary>
        /// 无验证
        /// </summary>
        None = 0,
        /// <summary>
        /// 是否为空
        /// </summary>
        Empty = 1,
        /// <summary>
        /// 只能输入英文
        /// </summary>
        English = 2,
        /// <summary>
        /// 数字
        /// </summary>
        Digital = 4,
        /// <summary>
        /// 正数
        /// </summary>
        PlusDigital = 8,
        /// <summary>
        /// 长度验证
        /// </summary>
        Length = 16,
        // 后续继续添加验证 32 64 128 512 .....

    }
}
