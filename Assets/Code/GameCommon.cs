namespace Code
{
    public static class GameCommon
    {
        public static int ConvertToHash(int x, int y) => x * 10 + y;
        public static (int x, int y) ConvertToPosiiton(int hash)
        {
            var y = hash % 10;
            var x = (hash - y) / 10;

            return (x, y);
        }
    }
}
