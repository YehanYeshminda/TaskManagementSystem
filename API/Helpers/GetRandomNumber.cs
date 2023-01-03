namespace API.Helpers
{
    public static class GetRandomNumber
    {
        private static Random rnd = new Random();
        public static int GetRandom()
        {
            return rnd.Next(10, 100);
        }
    }
}