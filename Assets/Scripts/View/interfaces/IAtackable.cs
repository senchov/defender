using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.View
{
    public interface IAtackable
    {
        void Atack();
        event Action<string> OnAtack;
    }
}
