namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Responses
{
    public class ErrorModel
    {
        public string Error { get; set; }
        public ErrorModel(string error)
        {
            Error = error;
        }
    }
}