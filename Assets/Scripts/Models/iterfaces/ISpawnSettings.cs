﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Models
{
    public interface ISpawnSettings
    {
        List<float> GetTimeToSpawn();
        List<string> GetEntitiesToSpawn();
    }
}
