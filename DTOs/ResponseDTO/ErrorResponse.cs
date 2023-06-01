using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTOs.ResponseDTO
{
    public class ErrorResponse
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        // public string ErrorCode { get; set; }
    }
}