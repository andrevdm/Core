namespace Avdm.Core.Di
{
    /// <summary>
    /// Interface to make testing the Environment class possible
    /// </summary>
    public interface IEnvironment
    {
        string MachineName { get; }
    }
}
