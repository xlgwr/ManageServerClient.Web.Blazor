using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageServerClient.Shared.Common;

namespace System
{
    public static class Exts
    {
        /// <summary>
        ///  类型映射,默认字段名字一一对应
        /// </summary>
        /// <typeparam name="TDestination">转化之后的model，可以理解为viewmodel</typeparam>
        /// <typeparam name="TSource">要被转化的实体，Entity</typeparam>
        /// <param name="source">可以使用这个扩展方法的类型，任何引用类型</param>
        /// <returns>转化之后的实体</returns>
        public static TDestination MapTo<TDestination, TSource>(this TSource source, MapperConfiguration config)
            where TDestination : class
            where TSource : class
        {
            if (source == null) return default(TDestination);
            //var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>());
            var mapper = config.CreateMapper();
            return mapper.Map<TDestination>(source);
        }
        /// <summary>
        /// 转为字符
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        public static string AsString(this byte[] st)
        {
            if (!st.Any())
            {
                return "";
            }
            var res = Encoding.UTF8.GetString(st,0,st.Length);
            return res;
        }

        /// <summary>
        /// 字符转为Memory<byte>
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        public static Memory<byte> AsMemoryBuffer(this string st)
        {
            Memory<byte> buffer = st.AsBuffer().AsMemory();
            return buffer;
        }
        /// <summary>
        /// 字符转为byte[]
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        public static byte[] AsBuffer(this string st)
        {
            if (st.IsNullOrWhiteSpace())
            {
                return new byte[0];
            }
            byte[] buffer = Encoding.UTF8.GetBytes(st);
            return buffer;
        }
        /// <summary>
        /// 字符转为ArraySegment<byte>
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        public static ArraySegment<byte> AsArraySegmentBuffer(this string st)
        {
            var seg = new ArraySegment<byte>(st.AsBuffer());
            return seg;
        }
    }
}
