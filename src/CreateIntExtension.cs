using System;
using AutoFixture;

namespace Wizkisoft.AutoFixture.Extension
{
    /// <summary>
    /// Creates a random integer within the range provided.
    /// </summary>
    /// <returns>
    /// An integer inclusively between min and max.
    /// </returns>
    /// <param name="min">The minimum number.</param>
    /// <param name="max">The maximum number.</param>
    /// <example>
    /// <code>
    /// var fixture = new AutoFixture();
    /// var num = fixture.CreateInt(0, 3);
    ///
    /// Console.WriteLine(num) // 0, 1, 2, or 3
    /// </code>
    /// </example>
    /// <exception cref="ArgumentException">
    /// Thrown when the max parameter is smaller than the min parameter.
    /// </exception>
    public static class CreateIntExtension
    {
        public static int CreateInt(this IFixture @this, int min, int max)
        {
            if (max < min)
                throw new ArgumentException("Providing inputs in the wrong order could produce unexpected results.");

            return @this.Create<int>() % (max - min + 1) + min;
        }
    }
}
