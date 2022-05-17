#pragma warning disable CS0693
namespace MyEventsWatcher.Services;

/// <summary>
/// Base contract to create serialization operations on a target format.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface ISerializer<out T>
{
    /// <summary>
    /// Contains all targeted media types.
    /// <remarks>"application/json, application/octet-stream..."</remarks>
    /// </summary>
    public const IEnumerable<string> MediaTypes = null!;
    /// <summary>
    /// Serialize asynchronously an object.
    /// </summary>
    /// <param name="obj">Object to serialize</param>
    /// <typeparam name="T">Target type</typeparam>
    /// <returns>Serialized object's string</returns>
    public Task<string>SerializeAsync<T>(T obj);
    
    /// <summary>
    /// Serialize an object.
    /// </summary>
    /// <param name="obj"></param>
    /// <typeparam name="T">Target type</typeparam>
    /// <returns>Serialized object's string</returns>
    public string Serialize<T>(T obj);
    
    /// <summary>
    /// Deserialize a string to an object's target type.
    /// </summary>
    /// <param name="str">Serialized object</param>
    /// <typeparam name="T">Target type</typeparam>
    /// <returns>Deserialized T object</returns>
    public T Deserialize<T>(string str);

    /// <summary>
    /// Deserialize asynchronously a string to an object's target type.
    /// </summary>
    /// <param name="str">Serialized object</param>
    /// <typeparam name="T">Target type</typeparam>
    /// <returns>Deserialized T object</returns>
    public Task<T?> DeserializeAsync<T>(string str);

    /// <summary>
    /// Create a .json file asynchronously from a json string object.
    /// </summary>
    /// <param name="json">Serialized object</param>
    /// <param name="filePath">Destination path</param>
    /// <returns></returns>
    public Task CreateFileAsync(string json, string filePath);

    /// <summary>
    /// Create a .json file asynchronously from an object.
    /// </summary>
    /// <param name="obj">Object to serialize</param>
    /// <param name="filePath">Destination path</param>
    /// <typeparam name="T">Target type</typeparam>
    /// <returns></returns>
    public Task CreateFileAsync<T>(T obj, string filePath);

    /// <summary>
    /// Create a json file from an object (readonly reference is optional).
    /// </summary>
    /// <param name="obj">Object to serialize</param>
    /// <param name="filePath">Destination path</param>
    /// <typeparam name="T">Target type</typeparam>
    public void CreateJsonFile<T>(in T obj, in string filePath);

    /// <summary>
    /// Create a json file from a json string (readonly reference is optional).
    /// </summary>
    /// <param name="json">Serialized object</param>
    /// <param name="filePath">Destination path</param>
    public void CreateJsonFile(in string json, in string filePath);
}