namespace TVTransformerTests.Extensions
{
    public static class WidthExtensions
    {
        public static int GetIntegerPartOfWidth(double price)
        {
            const int quota = 22;
            const int maxWidthPX = 340;

            var percentage = price / quota * 100; // 34.045
            var width = maxWidthPX / 100.0 * percentage;
            return (int)width;
        }
    }
}
