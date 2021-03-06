﻿using Assets.Scripts.Models;

namespace Assets.Scripts.Controllers
{
    partial class SpawnController
    {       
        private ISpawnSettings SpawnSettingsGetter
        {
            get
            {               
                return SettingsList[Level];
            }           
        }

        private IPrefabProvider _PrefabProvide;
        private IPrefabProvider PrefabProvideGetter
        {
            get
            {
                if (_PrefabProvide == null)
                    _PrefabProvide = PrefabProvider as IPrefabProvider;
                return _PrefabProvide;
            }
        }

        private ISpawnPointModel _SpawnPointModel;
        private ISpawnPointModel SpawnPointProviderGetter
        {
            get
            {
                if (_SpawnPointModel == null)
                    _SpawnPointModel = SpawnPointProvider as ISpawnPointModel;
                return _SpawnPointModel;
            }
        }
    }
}
