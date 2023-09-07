namespace CollectionManager.Tests;

public class ToStringType
{
    [Fact]
    public void ShouldConvertToStringType()
    {
        // Arrange
        var rand = new Random();
        var source = new List<List<int>>();
        var target = new List<List<string>>();
        for (int i = 0; i < 5; i++)
        {
            var sList = new List<int>();
            var tList = new List<string>();
            for (int j = 0; j < 5; j++)
            {
                var value = rand.Next(-10, 10);
                sList.Add(value);
                tList.Add(value.ToString());
            }
            source.Add(sList);
            target.Add(tList);
        }

        // Act
        var result = List2d<int>.ToStringType(source);

        // Assert
        Assert.Equal(target, result);
    }
}