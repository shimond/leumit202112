using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_intro.Exceptions
{

    public enum ApiExceptionType
    {
        NotFound, Conflict
    }

    [Serializable]
    public class CourseApiException : Exception
    {
        public ApiExceptionType ApiExceptionType { get; set; }
        public CourseApiException(ApiExceptionType apiExceptionType) {
            this.ApiExceptionType = apiExceptionType;
        }
        public CourseApiException(string message) : base(message) { }
        public CourseApiException(string message, Exception inner) : base(message, inner) { }
        protected CourseApiException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
