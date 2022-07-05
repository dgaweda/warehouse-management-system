namespace WarehouseManagementSystem.ApplicationServices.API.Validation
{
    public static class ErrorType
    {
        public const string NotFound = "Doesn't exist.";
        public const string MustBeUnique = "Must be unique.";
        public const string NotEmpty = "Can't be empty.";
        public const string BadFormat = "Bad format.";
        public const string GreaterThanZero = "Must be greater than 0.";
        public const string AlreadyExist = "Already exists.";
    }
}