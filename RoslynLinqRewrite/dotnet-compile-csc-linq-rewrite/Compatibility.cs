using System;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Collections.Immutable;
using System.Collections.Generic;

internal static class Compatibility
{

    
    [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    internal static extern IntPtr GetCommandLine();
    public const int WRN_FileAlreadyIncluded = 2002;
    public const int ERR_CantReadConfigFile = 7093;
    public static void SetCurrentUICulture(CultureInfo c)
    {
        //Thread.CurrentThread.CurrentUICulture = c;        
    }

    public static ImmutableArray<T> AsImmutableOrNull<T>(this IEnumerable<T> items)
    {
        if (items == null) return default;
        return ImmutableArray.CreateRange(items);
    }

}
