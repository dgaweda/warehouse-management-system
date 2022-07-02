namespace WarehouseManagementSystem.ApplicationServices.API.ErrorHandling
{
    public class ErrorModel
    {
        public string Property { get; set; }
        public object Value { get; set; }
        public string ErrorMessage { get; set; }

        public ErrorModel(string property, object value, string errorMessage)
        {
            Property = property;
            Value = value;
            ErrorMessage = errorMessage;
        }
    }
}