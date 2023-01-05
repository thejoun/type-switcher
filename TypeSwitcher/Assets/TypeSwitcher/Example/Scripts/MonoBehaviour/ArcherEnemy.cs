using UnityEngine;

namespace TypeSwitcher.Example
{
    public class ArcherEnemy : Enemy
    {
        [Header("Archer")]
        [SerializeField] private float bowRange;
    }
}