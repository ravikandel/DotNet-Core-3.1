using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp.Common.Common
{
    public class DbResponse
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }

        public void SetError(int errorCode, string msg)
        {
            ErrorCode = errorCode;
            Message = msg;
        }
    }
}
