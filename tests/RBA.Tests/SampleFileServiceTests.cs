namespace RBA.Tests;

public class SampleFileServiceTests
{
    [Fact]
    public async Task CreateSampleFileAsync_Should_CreateSampleFiles()
    {
        // Arrange
        var sut = new SampleFileService();

        // Act + Assert
        await sut.CreateSampleFileAsync();
    }

    [Fact]
    public async Task ReadSampleFileAsync_Should_CreateSampleFiles()
    {
        // Arrange
        var sut = new SampleFileService();

        // Act
        var results = await sut.ReadAllSampleFilesAsync();

        // Assert
        Assert.NotNull(results);
    }
}
