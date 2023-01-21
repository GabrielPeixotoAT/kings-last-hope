using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Entities.Interfaces.Status
{
    public interface ILifeStatus
    {
        void TakeDamage(float damage);
        void Die();
    }
}
