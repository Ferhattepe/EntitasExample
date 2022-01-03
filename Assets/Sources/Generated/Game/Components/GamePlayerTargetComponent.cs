//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public PlayerTargetComponent playerTarget { get { return (PlayerTargetComponent)GetComponent(GameComponentsLookup.PlayerTarget); } }
    public bool hasPlayerTarget { get { return HasComponent(GameComponentsLookup.PlayerTarget); } }

    public void AddPlayerTarget(UnityEngine.Transform newValue) {
        var index = GameComponentsLookup.PlayerTarget;
        var component = (PlayerTargetComponent)CreateComponent(index, typeof(PlayerTargetComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplacePlayerTarget(UnityEngine.Transform newValue) {
        var index = GameComponentsLookup.PlayerTarget;
        var component = (PlayerTargetComponent)CreateComponent(index, typeof(PlayerTargetComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemovePlayerTarget() {
        RemoveComponent(GameComponentsLookup.PlayerTarget);
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

    static Entitas.IMatcher<GameEntity> _matcherPlayerTarget;

    public static Entitas.IMatcher<GameEntity> PlayerTarget {
        get {
            if (_matcherPlayerTarget == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PlayerTarget);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPlayerTarget = matcher;
            }

            return _matcherPlayerTarget;
        }
    }
}
