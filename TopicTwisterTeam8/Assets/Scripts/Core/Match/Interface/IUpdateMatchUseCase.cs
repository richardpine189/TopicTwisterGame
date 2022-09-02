﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Core.Match.Interface
{
    interface IUpdateMatchUseCase
    {
        Task<bool> Execute(global::Match match);
    }
}
