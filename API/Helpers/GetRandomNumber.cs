namespace API.Helpers
{
    public static class GetRandomNumber
    {
        private static Random rnd = new Random();
        public static int GetRandom()
        {
            return rnd.Next(10, 100);
        }

        public static int GetRandomZeroOne()
        {
            return rnd.Next(0, 2);
        }

        public static int GetRandomMaxTen()
        {
            return rnd.Next(0, 10);
        }
    }
}