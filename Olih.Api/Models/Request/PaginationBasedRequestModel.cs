namespace Olih.Api.Models.Request
{
    public record PaginationBasedRequestModel
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}
