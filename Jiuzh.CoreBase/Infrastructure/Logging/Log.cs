using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jiuzh.CoreBase.Infrastructure
{
    using System.Runtime.CompilerServices;
    using System.Diagnostics;

    public static class Log
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        [DebuggerStepThrough]
        public static void Info(string message)
        {
            Check.Argument.IsNotEmpty(message, "message");

            GetLog().Info(message);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [DebuggerStepThrough]
        public static void Info(string format, params object[] args)
        {
            Check.Argument.IsNotEmpty(format, "format");

            GetLog().Info(Format(format, args));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [DebuggerStepThrough]
        public static void Warning(string message)
        {
            Check.Argument.IsNotEmpty(message, "message");

            GetLog().Warning(message);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [DebuggerStepThrough]
        public static void Warning(string format, params object[] args)
        {
            Check.Argument.IsNotEmpty(format, "format");

            GetLog().Warning(Format(format, args));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [DebuggerStepThrough]
        public static void Error(string message)
        {
            Check.Argument.IsNotEmpty(message, "message");

            GetLog().Error(message);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [DebuggerStepThrough]
        public static void Error(string format, params object[] args)
        {
            Check.Argument.IsNotEmpty(format, "format");

            GetLog().Error(Format(format, args));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [DebuggerStepThrough]
        public static void Exception(Exception exception)
        {
            Check.Argument.IsNotNull(exception, "exception");

            GetLog().Exception(exception);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static ILog GetLog()
        {
            return IoC.Resolve<ILog>();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static string Format(string format, params object[] args)
        {
            Check.Argument.IsNotEmpty(format, "format");

            return format.FormatWith(args);
        }
    }
}
