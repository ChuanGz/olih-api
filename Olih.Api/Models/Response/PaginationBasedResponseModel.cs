using System;
using Olih.Api.Models.Request;

namespace Olih.Api.Models.Response
{
    public class PaginationBasedResponseModel : PaginationBasedRequestModel
    {
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
    }
}
