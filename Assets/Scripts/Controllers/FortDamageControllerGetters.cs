using UnityEngine;
using Assets.Scripts.Models;

namespace Assets.Scripts.Controllers
{   
    partial class FortDamageController
    {
        private IDamageProvider _DamageProvider;
        private IDamageProvider DamageProviderGetter
        {
            get
            {
                if (_DamageProvider == null)
                    _DamageProvider = DamageProviderModel as IDamageProvider;
                return _DamageProvider;
            }
        }

        private IFortStatebleItem _FortStatebleItem;
        private IFortStatebleItem StatebleItemGetter
        {
            get
            {
                if (_FortStatebleItem == null)
                    _FortStatebleItem = Fort as IFortStatebleItem;
                return _FortStatebleItem;
            }
        }

        private IDamageble _Damageble;
        private IDamageble DamagebleGetter
        {
            get
            {
                if (_Damageble == null)
                    _Damageble = Fort as IDamageble;
                return _Damageble;
            }
        }
    }
}
