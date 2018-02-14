﻿using DBreeze.Utils;
using Stratis.SmartContracts.State.AccountAbstractionLayer;

namespace Stratis.SmartContracts.State
{
    /// <summary>
    /// When we store contract data and their UTXO balances, we are serializing those data types to bytes and storing them
    /// in a byte[]/byte[] K/V store.
    /// This class provides access to serializers used during this process.
    /// </summary>
    public static class Serializers
    {
        public static AccountStateSerializer AccountSerializer { get; } = new AccountStateSerializer();
        public static StoredVinSerializer VinSerializer { get; } = new StoredVinSerializer();

        public class AccountStateSerializer : ISerializer<AccountState, byte[]>
        {
            public byte[] Serialize(AccountState obj)
            {
                return obj.ToBytes();
            }

            public AccountState Deserialize(byte[] stream)
            {
                return stream == null || stream.Length == 0 ? null : new AccountState(stream);
            }
        }

        public class StoredVinSerializer : ISerializer<StoredVin, byte[]>
        {
            public byte[] Serialize(StoredVin obj)
            {
                return obj.ToBytes();
            }

            public StoredVin Deserialize(byte[] stream)
            {
                return stream == null || stream.Length == 0 ? null : new StoredVin(stream);
            }
        }

        public class NoSerializer<T> : ISerializer<T, T>
        {
            public T Serialize(T obj)
            {
                return obj;
            }

            public T Deserialize(T stream)
            {
                return stream;
            }
        }
    }
}
