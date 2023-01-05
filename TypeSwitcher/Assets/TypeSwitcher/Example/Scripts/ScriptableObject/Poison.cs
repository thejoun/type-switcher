using UnityEngine;

namespace TypeSwitcher.Example
{
    [TypeCategory("Poison")]
    public abstract class Poison : Potion
    {
        [SerializeField] private float poisonDuration;
    }
}