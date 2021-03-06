﻿namespace Avdm.Core.Console
{
    /// <summary>
    /// Interface used to make a class available to be executed by the <see cref="AppRunner">AppRunner</see>
    /// </summary>
    public interface IRunnable
    {
        int Run( string[] args );
    }
}
