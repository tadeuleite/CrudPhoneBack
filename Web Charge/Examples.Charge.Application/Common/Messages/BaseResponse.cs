using System.Collections.Generic;

namespace Examples.Charge.Application.Common.Messages
{
    public abstract class BaseResponse
    {
        public bool Success { get; set; } = true;

        public List<object> Errors { get; set; } = null;

        public BaseResponse()
        {
            Errors = new List<object>();
        }
    }
}
