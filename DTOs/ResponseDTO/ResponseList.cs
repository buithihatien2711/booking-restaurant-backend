using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTOs.ResponseDTO
{
    public class ResponseList<T>
    {
        public List<T> Data { get; set; }
        
        public int TotalPage { get; set; }
    }
}