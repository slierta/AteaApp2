namespace App.Atea.Data;

public class ExecutionItem
{
    /// <summary>
    /// Contains the source values sent
    /// </summary>
    public string[] Source { get; set; }
    /// <summary>
    /// Contains the result of the operation
    /// </summary>
    public int Result { get; set; }
    /// <summary>
    /// Default constructor
    /// </summary>
    public ExecutionItem(string[] src, int result)
    {
        Source = src;
        Result = result;
    }
}