namespace Olih.Api.Models.Request
{
    public class BaseQueryRequestModel
    {
        public string? SearchText { get; set; } // if null, return all data
        public string? SortByColumn { get; set; }
        public bool IsDesc { get; set; } // 0 is ASC, 1 is DESC
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
