using System.Collections.Immutable;
using System.Text;

namespace MyEventsWatcher.Services;

public class JsonSerializer : IJsonSerializer
{
    public void CreateJsonFile(in string json, in string filePath)
    {
        try
        {
            using var sourceStream = File.Open(filePath, FileMode.OpenOrCreate);
            sourceStream.Dispose();
            using var outputWriter = File.AppendText(filePath);
            outputWriter.Write(json);
            outputWriter.Dispose();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void CreateJsonFile<T>(in T obj, in string filePath)
    {
        try
        {
            var json = Serialize<T>(obj);
            using var sourceStream = File.Create(filePath);
            var content = new UTF8Encoding(true).GetBytes(json);
            sourceStream.Write(content);
            sourceStream.Dispose();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task CreateFileAsync<T>(T obj, string filePath)
    {
        try
        {
            var json = await SerializeAsync<T>(obj);
            await using var sourceStream = File.Create(filePath);
            var content = new UTF8Encoding(true).GetBytes(json);
            await sourceStream.WriteAsync(content);
            await sourceStream.DisposeAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task CreateFileAsync(string json, string filePath)
    {
        try
        {
            await using var sourceStream = File.Open(filePath, FileMode.OpenOrCreate);
            await sourceStream.DisposeAsync();

            await using var outputWriter = File.AppendText(filePath);
            await outputWriter.WriteAsync(json);
            await outputWriter.DisposeAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<T?> DeserializeAsync<T>(string str)
    {
        try
        {
            T? result;
            if (File.Exists(str))
            {
                var jsonString = await File.ReadAllTextAsync(str);
                var mStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
                result = (await System.Text.Json.JsonSerializer.DeserializeAsync<T>(mStream))!;
                await mStream.DisposeAsync();
            }
            else
            {
                var mStream = new MemoryStream(Encoding.UTF8.GetBytes(str));
                result = (await System.Text.Json.JsonSerializer.DeserializeAsync<T>(mStream))!;
                await mStream.DisposeAsync();
            }


            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public T Deserialize<T>(string str)
    {
        try
        {
            T? result;
            if (File.Exists(str))
            {
                var jsonString = File.ReadAllText(str);
                var mStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
                result = System.Text.Json.JsonSerializer.Deserialize<T>(mStream)!;
                mStream.Dispose();
            }
            else
            {
                var mStream = new MemoryStream(Encoding.UTF8.GetBytes(str));
                result = System.Text.Json.JsonSerializer.Deserialize<T>(mStream)!;
                mStream.Dispose();
            }


            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public string Serialize<T>(T obj)
    {
        string result;
        try
        {
            result = Serialize(obj);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return result;
    }

    public ImmutableArray<string> MediaTypes { get; set; }

    public async Task<string> SerializeAsync<T>(T obj)
    {
        string result;
        try
        {
            await using var stream = new MemoryStream();
            if (obj != null) await System.Text.Json.JsonSerializer.SerializeAsync(stream, obj, obj.GetType());
            stream.Position = 0;
            using var reader = new StreamReader(stream);
            result = await reader.ReadToEndAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return result;
    }
}