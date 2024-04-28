using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Service.DTOs
{
    public class ResponseDTO<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public int StatusCode { get; set; }
        public string? ErrorMessage { get; set; }
        public ResponseDTO()
        {
            Success = true;
        }
    }
}
