namespace ISO9001.WebAPI.Helpers;

public static class EndpointHelper
{
    public static string CreateEndpoint(this string name, string entryPoint)
    {
        string cleanEntryPoint = RemoveEndpointSuffix(entryPoint);
        string raw = $"{cleanEntryPoint}/{name}";
        string[] segments = raw.Split('/', StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < segments.Length; i++)
        {
            string segment = segments[i];
            if (ShouldConvertToKebab(segment))
                segments[i] = segment.PascalCaseToKebabCase();
        }
        return string.Join("/", segments);
    }

    private static string RemoveEndpointSuffix(string entryPoint)
    {
        string[] suffixes = new[] { "endpoints", "endpoint" }; // orden importa: más largo primero
        int index = 0;
        int suffixLength = 0;
        while (index < suffixes.Length)
        {
            string suffix = suffixes[index];
            bool match = entryPoint.EndsWith(suffix, StringComparison.OrdinalIgnoreCase);
            suffixLength = match ? suffix.Length : 0;
            index = match ? suffixes.Length : index + 1;
        }
        return suffixLength > 0
            ? entryPoint[..^suffixLength]
            : entryPoint;
    }

    private static bool ShouldConvertToKebab(string segment)
    {
        bool isRouteParameter = segment.StartsWith("{") && segment.EndsWith("}");
        bool containsHyphen = segment.Contains('-');
        bool isAllLower = segment.ToLowerInvariant() == segment;
        bool startsWithUpper = char.IsUpper(segment[0]);
        return !isRouteParameter && !containsHyphen && !isAllLower && startsWithUpper;
    }

    public static string PascalCaseToKebabCase(this string name)
    {
        string result = name;
        if (!string.IsNullOrWhiteSpace(name))
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < name.Length; i++)
            {
                char currentChar = name[i];
                if (char.IsUpper(currentChar))
                {
                    if (i > 0)
                        sb.Append('-');
                    sb.Append(char.ToLowerInvariant(currentChar));
                }
                else
                    sb.Append(currentChar);
            }
            result = sb.ToString();
        }
        return result;
    }
}
