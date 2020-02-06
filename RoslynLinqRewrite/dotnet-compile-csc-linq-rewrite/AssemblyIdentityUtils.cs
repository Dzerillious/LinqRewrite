// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.IO;

namespace Microsoft.CodeAnalysis
{
    internal static class AssemblyIdentityUtils
    {
        public static AssemblyIdentity TryGetAssemblyIdentity(string filePath)
        {
            try
            {
                using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete);
                using var peReader = new PEReader(stream);
                
                var metadataReader = peReader.GetMetadataReader();

                var assemblyDefinition = metadataReader.GetAssemblyDefinition();

                var name = metadataReader.GetString(assemblyDefinition.Name);
                var version = assemblyDefinition.Version;

                var cultureHandle = assemblyDefinition.Culture;
                var cultureName = !cultureHandle.IsNil ? metadataReader.GetString(cultureHandle) : null;
                var flags = assemblyDefinition.Flags;

                var hasPublicKey = (flags & AssemblyFlags.PublicKey) != 0;
                var publicKeyHandle = assemblyDefinition.PublicKey;
                var publicKeyOrToken = !publicKeyHandle.IsNil
                    ? metadataReader.GetBlobBytes(publicKeyHandle).AsImmutableOrNull()
                    : default;
                return new AssemblyIdentity(name, version, cultureName, publicKeyOrToken, hasPublicKey);
            }
            catch (Exception)
            {
                // ignored
            }
            return null;
        }


    }
}
