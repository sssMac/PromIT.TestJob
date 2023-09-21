using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromIT.TestJob.Application.Common
{
    public class BaseResponse
    {

        public bool Success { get; private set; }
        public string Error { get; private set; }

        private BaseResponse(bool success = true, string error = null)
        {
            Success = success;
            Error = error;
        }


        public static BaseResponse Succeed() => new BaseResponse(true);
        public static BaseResponse Failed(string error) => new BaseResponse(false, error);
    }
}
