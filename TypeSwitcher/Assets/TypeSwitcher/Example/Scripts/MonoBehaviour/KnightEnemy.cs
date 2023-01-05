using UnityEngine;

namespace TypeSwitcher.Example
{
    public class KnightEnemy : Enemy
    {
        [Header("Knight")] 
        [SerializeField] private float swordDamage;
        [SerializeField] private float armorThickness;
    }
}