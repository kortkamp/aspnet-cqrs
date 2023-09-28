using System.Text.Json;

using Microsoft.AspNetCore.Mvc;

namespace Syslog.Api.Contracts
{
    public class Error
    {
        public bool Success { get; } = false;

        public int? StatusCode { get; set; }

        public string? Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

        public JsonResult ToJsonResult()
        {
            return new JsonResult(this) { StatusCode = StatusCode };
        }
    }
}