﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NetArchTest.Rules
{
    /// <summary>
    /// Assembly wrapper.
    /// </summary>
    public interface IAssembly
    {
        /// <summary>
        /// FullName of the assembly
        /// </summary>       
        string FullName { get; }
    }
}
