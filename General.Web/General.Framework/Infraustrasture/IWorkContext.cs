using General.Domian.Dto;
using General.Domian.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace General.Framework.Infraustrasture
{
    public interface IWorkContext
    {
        SessionUser currentUser { get; }
    }
}
