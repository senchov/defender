using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Models
{
    public interface IDamageProvider
    {
        int GetDamage(string id);
    }
}
