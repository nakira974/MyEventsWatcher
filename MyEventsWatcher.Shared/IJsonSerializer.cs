namespace MyEventsWatcher.Shared;

public interface IJsonSerializer : ISerializer<IJsonSerializer>
{
    /// <summary>
    /// Serialize asynchronously an object to json string.
    /// </summary>
    /// <param name="obj">Object to serialize</param>
    /// <typeparam name="T">Target type</typeparam>
    /// <returns>Serialized object's json string</returns>
    public new Task<string>SerializeAsync<T>(T obj);
    
    /// <summary>
    /// Serialize an object to json string.
    /// </summary>
    /// <param name="obj"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns>Serialized object's json string</returns>
    public new string Serialize<T>(T obj);
    
    /// <summary>
    /// Deserialize a json string to an object's target type.
    /// </summary>
    /// <param name="str">Serialized object</param>
    /// <typeparam name="T">Target type</typeparam>
    /// <returns>Deserialized T json object</returns>
    public new T Deserialize<T>(string str);

    /// <summary>
    /// Deserialize asynchronously a json string to an object's target type.
    /// </summary>
    /// <param name="str">Serialized object</param>
    /// <typeparam name="T">Target type</typeparam>
    /// <returns>Deserialized T json object</returns>
    public new Task<T?> DeserializeAsync<T>(string str);

    /// <summary>
    /// Create a .json file asynchronously from a json string object.
    /// </summary>
    /// <param name="json">Serialized object</param>
    /// <param name="filePath">Destination path</param>
    /// <returns></returns>
    public new Task CreateFileAsync(string json, string filePath);

    /// <summary>
    /// Create a .json file asynchronously from an object.
    /// </summary>
    /// <param name="obj">Object to serialize</param>
    /// <param name="filePath">Destination path</param>
    /// <typeparam name="T">Target type</typeparam>
    /// <returns></returns>
    public new Task CreateFileAsync<T>(T obj, string filePath);

    /// <summary>
    /// Create a json file from an object (readonly reference is optional).
    /// </summary>
    /// <param name="obj">Object to serialize</param>
    /// <param name="filePath">Destination path</param>
    /// <typeparam name="T">Target type</typeparam>
    public new void CreateJsonFile<T>(in T obj, in string filePath);

    /// <summary>
    /// Create a json file from a json string (readonly reference is optional).
    /// </summary>
    /// <param name="json">Serialized object</param>
    /// <param name="filePath">Destination path</param>
    public new void CreateJsonFile(in string json, in string filePath);
}