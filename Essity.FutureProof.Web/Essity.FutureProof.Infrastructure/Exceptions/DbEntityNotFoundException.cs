﻿using System.Runtime.Serialization;

namespace Essity.FutureProof.Infrastructure.Exceptions
{
    [Serializable]
    internal class DbEntityNotFoundException : Exception
    {
        public DbEntityNotFoundException()
        {
        }

        public DbEntityNotFoundException(string message) : base(message)
        {
        }

        public DbEntityNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DbEntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}