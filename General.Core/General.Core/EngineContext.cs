using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime;
using System.Runtime.CompilerServices;

namespace General.Core
{
    /// <summary>
    /// 引擎上下文
    /// </summary> 
    public class EngineContext
    {
        /// <summary>
        /// 加锁访问
        /// </summary>
        /// <param name="_engine"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IEngine Initialize(IEngine _engine)
        {
            if (null == current)
                current = _engine;
            return current;
        }
        /// <summary>
        /// 当前引擎
        /// </summary>
        public static IEngine current { get; private set; }
    }
}
