using System;
using AutoFixture;
using FluentAssertions;
using Xunit;

namespace Wizkisoft.AutoFixture.Extension.Test
{
    public class CreateIntExtensionTests
    {
        public class CreateIntShould : IDisposable
        {
            public CreateIntShould() =>
                _fixture = new Fixture();

            [Fact]
            public void ReturnIntAtOrAboveMin()
            {
                var min = _fixture.Create<int>();

                var result = CreateIntExtension.CreateInt(_fixture, min, min + _fixture.Create<int>());

                result.Should()
                    .BeGreaterOrEqualTo(min,
                    because: "CreateInt returns a number equal to, or greater than, the min parameter.");
            }

            [Fact]
            public void ReturnIntAtOrBelowMax()
            {
                var min = _fixture.Create<int>();
                var max = min + _fixture.Create<int>();

                var result = CreateIntExtension.CreateInt(_fixture, min, max);

                result.Should()
                    .BeLessOrEqualTo(max,
                    because: "CreateInt returns a number equal to, or less than, the max parameter.");
            }

            [Fact]
            public void ReturnZero_WhenInRange()
            {
                var zero = 0;

                var result = CreateIntExtension.CreateInt(_fixture, zero, zero);

                result.Should()
                    .Be(zero,
                    because: "the function is capable of returning zero.");
            }

            [Fact]
            public void ReturnANegativeNumber_WhenInRange()
            {
                var negative = _fixture.Create<int>() * -1;

                var result = CreateIntExtension.CreateInt(_fixture, negative, negative);

                result.Should()
                    .Be(negative,
                    because: "the function is capable of returning a negative number.");
            }

            [Fact]
            public void ThrowException_WhenMaxIsLessThanMin()
            {
                var smallerNum = _fixture.Create<int>();
                var biggerNum = smallerNum + _fixture.Create<int>();

                Action action = () => CreateIntExtension.CreateInt(_fixture, biggerNum, smallerNum);

                action.Should()
                    .Throw<ArgumentException>(because: "providing inputs in the wrong order could produce unexpected results.");
            }

            public void Dispose() =>
                _fixture = null;

            private Fixture _fixture;
        }
    }
}
