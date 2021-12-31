namespace UnitTest.Domain.Extentions
{
    public static class FunctionStringFormatExtention
    {
        public static string FormatMessage(this string message, params object[] args)
        {
            return string.Format(message, args);
        }
    }
}
