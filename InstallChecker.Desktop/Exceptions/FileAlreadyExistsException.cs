using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Install_Checker.Exceptions
{
    [Serializable]
    public class FileAlreadyExistsException : Exception, ISerializable
    {
        public FileAlreadyExistsException(string message)
            : base (message)
        {

        }

        public FileAlreadyExistsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
