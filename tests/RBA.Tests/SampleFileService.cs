using RBA.Domain.Entities;
using RBA.Domain.Enums;
using System.Text;

namespace RBA.Tests;

public class SampleFileService
{
    private readonly Random _random = new();
    private readonly string[] _validInstructions = ["R", "L", "F"];
    private const string _folderName = @"solution items\test data\";
    private const string _fileName = "sample data [[0]].txt";
    private readonly string _directory = Path.Combine(Path.GetFullPath(@"..\..\..\..\.."), _folderName);

    public async Task CreateSampleFileAsync(int numberOfTestFiles = 10)
    {
        try
        {
            Directory.CreateDirectory(_directory);

            await ClearSampleFilesAsync();

            if (numberOfTestFiles > 10) numberOfTestFiles = 10;

            var indices = Enumerable.Range(0, numberOfTestFiles);

            await Parallel.ForEachAsync(indices, async (i, _) =>
            {
                var sampleData = GenerateValidTestData();
                var fileName = _fileName.Replace("[[0]]", $"{i:D2}");
                var filePathAndFileName = Path.Combine(_directory, fileName);

                await File.WriteAllTextAsync(filePathAndFileName, sampleData, CancellationToken.None).ConfigureAwait(false);
            });
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
        }
    }

    public async Task<Dictionary<string, string[]>> ReadAllSampleFilesAsync()
    {
        var results = new Dictionary<string, string[]>();

        try
        {
            if (!Directory.Exists(_directory))
            {
                return results;
            }

            var files = Directory.GetFiles(_directory, "sample data *.txt");

            await Parallel.ForEachAsync(files, async (file, _) =>
            {
                var lines = await File.ReadAllLinesAsync(file, CancellationToken.None).ConfigureAwait(false);
                var fileName = Path.GetFileName(file);
                lock (results)
                {
                    results[fileName] = lines;
                }
            });
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
        }

        return results;
    }

    private async Task ClearSampleFilesAsync()
    {
        if (!Directory.Exists(_directory)) return;

        var files = Directory.GetFiles(_directory, "sample data *.txt");
        await Parallel.ForEachAsync(files, async (file, _) =>
        {
            File.Delete(file);
            await Task.CompletedTask;
        });
    }

    private string GenerateValidTestData()
    {
        var stringBuilder = new StringBuilder();
        var grid = GenerateGridTestData();
        stringBuilder.AppendLine($"{grid.Coordinate.X} {grid.Coordinate.Y}");

        var numberOfRobots = _random.Next(2, 40);

        for (var i = 0; i < numberOfRobots; i++)
        {
            stringBuilder.AppendLine();

            var cardinalType = (CardinalType)_random.Next(1, 5);
            var startingBlock = GenerateRandomTestStartingBlock(0, Math.Max(grid.Coordinate.X, grid.Coordinate.Y), cardinalType);

            var instructionLength = _random.Next(2, 40);
            var instructions = GenerateTestInstructions(instructionLength);

            stringBuilder.AppendLine(startingBlock);
            stringBuilder.AppendLine(instructions);
        }

        return stringBuilder.ToString();
    }

    private Grid GenerateGridTestData(int min = 2, int max = 50)
    {
        var first = _random.Next(min, max);
        var second = _random.Next(min, max);

        while (first == second)
        {
            second = _random.Next(min, max);
        }

        var gridX = Math.Max(first, second);
        var gridY = Math.Min(first, second);

        return new Grid(new Coordinate(gridX, gridY));
    }

    private string GenerateRandomTestStartingBlock(int min, int max, CardinalType cardinalType)
    {
        var x = _random.Next(min, max);
        var y = _random.Next(min, max);

        return $"{x} {y} {cardinalType}";
    }

    private string GenerateTestInstructions(int length)
    {
        var instructions = new StringBuilder();

        for (var i = 0; i < length; i++)
        {
            var instructionIndex = _random.Next(0, _validInstructions.Length);
            instructions.Append(_validInstructions[instructionIndex]);
        }

        return instructions.ToString();
    }
}
