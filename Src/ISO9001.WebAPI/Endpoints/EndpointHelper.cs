namespace ISO9001.WebAPI.Endpoints
{
    internal static class EndpointHelper
    {
        public static string CreateEndpoint(this string name, string entryPoint) => $"{entryPoint}{name}";
    }
}
