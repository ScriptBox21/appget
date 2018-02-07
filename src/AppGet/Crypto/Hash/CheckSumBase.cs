﻿using System;
using System.IO;
using System.Security.Cryptography;
using AppGet.Manifests;

namespace AppGet.Crypto.Hash
{
    public abstract class CheckSumBase : ICheckSum
    {
        public abstract HashType HashType { get; }

        protected abstract HashAlgorithm GetHashAlgorithm();

        public string GetChecksum(string file)
        {
            using (var stream = File.OpenRead(file))
            {
                using (var algorithm = GetHashAlgorithm())
                {
                    var checksum = algorithm.ComputeHash(stream);
                    return BitConverter.ToString(checksum).Replace("-", string.Empty);
                }
            }
        }
    }
}