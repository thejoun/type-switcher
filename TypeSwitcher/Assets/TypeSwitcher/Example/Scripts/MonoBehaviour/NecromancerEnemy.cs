using UnityEngine;

namespace TypeSwitcher.Example
{
    [TypeCategory("Mage")]
    public class NecromancerEnemy : Enemy
    {
        [Header("Necromancer")]
        [SerializeField] private int skeletonCount;
    }
}