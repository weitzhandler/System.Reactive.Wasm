// Copyright (c) 2019 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("System.Reactive.Wasm.Tests")]

namespace System.Reactive.PlatformServices
{
    /// <summary>
    /// Contains extension methods associated with registrations of platform enlightenment providers.
    /// </summary>
    public static class PlatformEnlightenmentProviderExtensions
    {
        /// <summary>
        /// Sets the <see cref="PlatformEnlightenmentProvider.Current"/> to the <see cref="WasmPlatformEnlightenmentProvider"/> one.
        /// </summary>
        /// <param name="provider">The provider. This parameter is ignored.</param>
        [SuppressMessage("Design", "CS0618", Justification = "Intentional")]
        public static void EnableWasm(this IPlatformEnlightenmentProvider provider)
        {
            if (!(PlatformEnlightenmentProvider.Current is WasmPlatformEnlightenmentProvider))
            {
                PlatformEnlightenmentProvider.Current = new WasmPlatformEnlightenmentProvider();
            }
        }
    }
}
