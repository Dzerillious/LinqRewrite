﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.IO;
using System.Text;

namespace LinqRewrite.CompileCsc
{
    internal static class ConsoleUtil
    {
        private static readonly Encoding Utf8Encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);

        /// <summary>
        /// This will update the <see cref="Console.Out"/> value to have UTF8 encoding for the duration of the 
        /// provided call back.  The newly created <see cref="TextWriter"/> will be passed down to the callback.
        /// </summary>
        internal static T RunWithUtf8Output<T>(Func<TextWriter, T> func)
        {
            var savedOut = Console.Out;
            try
            {
                using var streamWriterOut = new StreamWriter(Console.OpenStandardOutput(), Utf8Encoding);
                Console.SetOut(streamWriterOut);
                return func(streamWriterOut);
            }
            finally
            {
                try
                {
                    Console.SetOut(savedOut);
                }
                catch
                {
                    // Nothing to do if we can't reset the console. 
                }
            }
        }

        internal static T RunWithUtf8Output<T>(bool utf8Output, TextWriter textWriter, Func<TextWriter, T> func)
        {
            if (!utf8Output) return func(textWriter);
            if (textWriter != Console.Out)
                throw new InvalidOperationException("Utf8Output is only supported when writing to Console.Out");

            return RunWithUtf8Output(func);

        }
    }
}
