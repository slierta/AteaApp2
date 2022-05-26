namespace Atea.Helpers
{
    /// <summary>
    /// Extensions to help with the process
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Returns the sum of all the values passed 
        /// </summary>
        /// <param name="args">The list of integer numbers</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">When all the values are not integers</exception>
        public static int Add(this string[] args)
        {
            if (!ValidateIntegerValues(args))
                throw new ArgumentOutOfRangeException(nameof(args), "All the values must be integer");
            return args.Sum(int.Parse);
        }
        /// <summary>
        /// Check if all the values are integer in an array of strings
        /// </summary>
        /// <param name="args">The list of string</param>
        /// <returns></returns>
        public static bool ValidateIntegerValues(string[] args) => args is { Length: > 0 } && args.All(s => int.TryParse(s, out _));
    }
}