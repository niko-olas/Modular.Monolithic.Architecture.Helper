namespace Modular.Monolithic.Architecture.Helper.Domain.Errors;

public class DomainErrors
{
    public static class General
    {
        public static Error ValueMaxLenght(string field = "", int max = 0)
        {
            return new Error("General.ValueMaxLenght", $"{field} has max lenght to {max}");
        }

        public static Error ValueMinLenght(string field = "", int max = 0)
        {
            return new Error("General.ValueMaxLenght", $"{field} has max lenght to {max}");
        }

        public static Error ListNullOrEmpty(string field = "")
        {
            return new Error("General.ListNullOrEmpty", $"{field} is  null or empty.");
        }

        public static Error ValueNullOrEmpty(string field = "")
        {
            return new Error("General.ValueNullOrEmpty", $"{field} is  null or empty.");
        }

        public static Error ItemNotFound(string itemname = "")
        {
            return new Error("General.ItemNotFound", $"{itemname} not found.");
        }

        public static Error UnProcessableRequest => new("General.UnProcessableRequest", "The server could not process the request.");

        public static Error ServerError => new("General.ServerError", "The server encountered an unrecoverable error.");

        public static Error ErrorDecriptData(string datafild)
        {
            return new Error("General.DecriptData", $"Error on decript data filed {datafild}.");
        }

        public static Error ErrorEncryptData(string datafild)
        {
            return new Error("General.DecriptData", $"Error on encrypt data filed {datafild}.");
        }
    }
}
