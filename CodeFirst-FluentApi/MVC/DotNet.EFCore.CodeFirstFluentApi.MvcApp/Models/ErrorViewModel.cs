namespace DotNet.EFCore.CodeFirstFluentApi.MvcApp.Models
{
    /// <summary>
    /// Error View Model class with Request Id and Show Request Id properties.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Show Request Identifier Property
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// Show Request Identifier Property
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}