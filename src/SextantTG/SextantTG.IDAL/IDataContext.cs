﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SextantTG.IDAL
{
    public interface IDataContext : IBaseDAL
    {
        DbConnection GetConnection();
    }
}
