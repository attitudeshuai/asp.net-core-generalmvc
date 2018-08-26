using System;
using System.Collections.Generic;
using System.Text;

namespace General.Core
{
    /// <summary>
    /// 构建一个实例
    /// </summary>
    public interface IEngine
    {
        T Resolve<T>() where T : class;
    }
}
