using UnityEngine;

namespace TypeSwitcher.Example
{
    [CreateAssetMenu(fileName = "Potion", menuName = "TypeSwitcher/Potion")]
    public class Potion : SwitchableScriptableObject<Potion>
    {
        protected enum Size
        {
            Small,
            Medium,
            Big
        }

        [SerializeField] private Size size;
    }
}