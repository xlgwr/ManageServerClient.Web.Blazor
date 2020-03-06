using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageServerClient
{
    public class AutoMapService
    {
        public MapperConfiguration _mapper;
        public AutoMapService(MapperConfiguration mapper)
        {
            _mapper = mapper;
        }
        /// <summary>
        /// 获取对应源copy
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <returns></returns>
        public T2 GetDest<T, T2>(T source)
            where T : class
            where T2 : class
        {
            return source.MapTo<T2, T>(_mapper);
        }
    }
}
