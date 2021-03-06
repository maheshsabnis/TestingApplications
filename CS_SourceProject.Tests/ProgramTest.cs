// <copyright file="ProgramTest.cs">Copyright ©  2020</copyright>
using System;
using CS_SourceProject;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CS_SourceProject.Tests
{
    /// <summary>This class contains parameterized unit tests for Program</summary>
    [PexClass(typeof(Program))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class ProgramTest
    {
        /// <summary>Test stub for Sub(Int32, Int32)</summary>
        [PexMethod]
        public int SubTest(int x, int y)
        {
            int result = Program.Sub(x, y);
            return result;
            // TODO: add assertions to method ProgramTest.SubTest(Int32, Int32)
        }
    }
}
