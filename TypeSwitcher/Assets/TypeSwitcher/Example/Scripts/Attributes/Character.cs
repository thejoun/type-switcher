namespace TypeSwitcher.Example.Attributes
{
    public class Character : SwitchableMonoBehaviour<Character> { }

    [TypeCategory(nameof(Human))]
    public abstract class Human : Character { }

    [TypeCategory("Monster")]
    public class Werewolf : Character { }

    [TypeCategory(nameof(Mage))] 
    public abstract class Mage : Human { }

    [TypeCategory(nameof(Necromancer))] 
    public class Necromancer : Mage { }

    public class Lich : Necromancer { }
    
    public class Warlock : Mage { }
}