namespace TVTransformerTests.Extensions
{
    public static class Pluralizer
    {
        public static string ChanelPlural(int count)
        {
            return count % 100 < 15 && count % 100 > 10 ? "каналов" :
                count % 10 == 1 ? "канал" : 
                count % 10 > 1 && count % 10 < 5 ? "канала" : "каналов";
        }
    }
}
