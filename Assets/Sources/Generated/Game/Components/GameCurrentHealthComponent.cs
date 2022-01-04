//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public CurrentHealthComponent currentHealth { get { return (CurrentHealthComponent)GetComponent(GameComponentsLookup.CurrentHealth); } }
    public bool hasCurrentHealth { get { return HasComponent(GameComponentsLookup.CurrentHealth); } }

    public void AddCurrentHealth(int newValue) {
        var index = GameComponentsLookup.CurrentHealth;
        var component = (CurrentHealthComponent)CreateComponent(index, typeof(CurrentHealthComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCurrentHealth(int newValue) {
        var index = GameComponentsLookup.CurrentHealth;
        var component = (CurrentHealthComponent)CreateComponent(index, typeof(CurrentHealthComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCurrentHealth() {
        RemoveComponent(GameComponentsLookup.CurrentHealth);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherCurrentHealth;

    public static Entitas.IMatcher<GameEntity> CurrentHealth {
        get {
            if (_matcherCurrentHealth == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CurrentHealth);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCurrentHealth = matcher;
            }

            return _matcherCurrentHealth;
        }
    }
}
