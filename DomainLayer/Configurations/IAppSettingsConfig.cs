﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Configurations
{
    public interface IAppSettingsConfig
    {
        public CustomAuthenticate CustomAuthenticate { get; set; }

    }
}
