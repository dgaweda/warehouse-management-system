namespace WarehouseManagementSystem.ApplicationServices.API.ErrorHandling
{
    public static class ErrorType
    {
        public const string InternalServerError = "INTERNAL_SERVER_ERROR";

        public const string ValidationError = "VALIDATION_ERROR";

        public const string NotAuthenticated = "NOT_AUTHENTICATED";

        public const string Unauthorized = "UNAUTHORIZED";

        public const string MethodNotAllowed = "METHOD_NOT_ALLOWED";

        public const string NotFound = "NOT_FOUND";

        public const string UnsupportedMediaType = "UNSUPPORTED_MEDIA_TYPE";

        public const string TooLargeData = "TOO_LARGE_DATA";

        public const string TooManyRequests = "TOO_MANY_REQUESTS";

        public const string Forbidden = "FORBIDDEN";

        public const string NoContent = "NO_CONTENT";

        public const string AlreadyExist = "ALREADY_EXIST";

        public const string BadFormat = "BAD_FORMAT";
    }
}
