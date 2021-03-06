﻿using System;

namespace SkyEditor.IO.Binary
{
    public interface IBinaryDataAccessor : IReadOnlyBinaryDataAccessor, IWriteOnlyBinaryDataAccessor, IDisposable
    {
        new IBinaryDataAccessor Slice(long offset, long length)
        {
            return this switch
            {
                BinaryDataAccessorReference reference => new BinaryDataAccessorReference(reference, offset, length),
                _ => new BinaryDataAccessorReference(this, offset, length),
            };
        }

        void IDisposable.Dispose()
        {
            return;
        }
    }
}
