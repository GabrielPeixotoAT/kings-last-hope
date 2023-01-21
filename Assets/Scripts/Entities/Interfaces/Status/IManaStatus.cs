using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities.Interfaces.Status
{
    public interface IManaStatus
    {
        void UseMana(float used);
        void StealMana(float used);
    }
}
