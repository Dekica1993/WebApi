namespace MovieApp.Helpers
{
    public static class ValidationHelper
    {
        public static bool CheckLength(string word)
        {
            return word.Length <= 255;
        }
    }
}
