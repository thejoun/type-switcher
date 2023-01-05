using UnityEngine;

namespace TypeSwitcher.Example
{
    [TypeCategory("Mage")]
    public abstract class MageEnemy : Enemy
    {
        [Header("Mage")]
        [SerializeField] private float mana;
    }
}