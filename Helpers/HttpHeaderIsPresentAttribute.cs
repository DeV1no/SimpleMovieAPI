using System;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace MoviesAPI.Helpers
{
    public class HttpHeaderIsPresentAttribute : Attribute, IActionConstraint
    {
        private readonly string header;
        private readonly string value;

        public HttpHeaderIsPresentAttribute(string header, string value)
        {
            this.header = header;
            this.value = value;
        }

        public bool Accept(ActionConstraintContext context)
        {
            var headers = context.RouteContext.HttpContext.Request.Headers;
            if (!headers.ContainsKey(header))
            {
                return false;
            }

            return string.Equals(headers[header], value, StringComparison.OrdinalIgnoreCase);
        }

        public int Order { get; }
    }
}