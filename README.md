# AutoFixture Extensions

Extension methods to streamline AutoFixture workflows

## Extensions

---

### IFixture.CreateInt

Creates a random integer within the range provided.
Returns an integer inclusively between min and max.

#### Parameters

**min** - The minimum number.

**max** - The maximum number.

#### Example

```sh
var fixture = new AutoFixture();
var num = fixture.CreateInt(0, 3);

Console.WriteLine(num) // 0, 1, 2, or 3
```

#### Exceptions

Throws an ArgumentException when the max parameter is smaller than the min parameter.
