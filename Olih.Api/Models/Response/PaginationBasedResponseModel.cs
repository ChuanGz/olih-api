using System;
using Olih.Api.Models.Request;

namespace Olih.Api.Models.Response
{
    public record PaginationBasedResponseModel : PaginationBasedRequestModel
    {
        public int PageCount { get; set; }
        public int PageTotal { get; set; }
    }
}
