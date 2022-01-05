//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public AttackDataComponent attackData { get { return (AttackDataComponent)GetComponent(GameComponentsLookup.AttackData); } }
    public bool hasAttackData { get { return HasComponent(GameComponentsLookup.AttackData); } }

    public void AddAttackData(float newInterval, float newRange, float newAttackDelay) {
        var index = GameComponentsLookup.AttackData;
        var component = (AttackDataComponent)CreateComponent(index, typeof(AttackDataComponent));
        component.Interval = newInterval;
        component.Range = newRange;
        component.AttackDelay = newAttackDelay;
        AddComponent(index, component);
    }

    public void ReplaceAttackData(float newInterval, float newRange, float newAttackDelay) {
        var index = GameComponentsLookup.AttackData;
        var component = (AttackDataComponent)CreateComponent(index, typeof(AttackDataComponent));
        component.Interval = newInterval;
        component.Range = newRange;
        component.AttackDelay = newAttackDelay;
        ReplaceComponent(index, component);
    }

    public void RemoveAttackData() {
        RemoveComponent(GameComponentsLookup.AttackData);
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

    static Entitas.IMatcher<GameEntity> _matcherAttackData;

    public static Entitas.IMatcher<GameEntity> AttackData {
        get {
            if (_matcherAttackData == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AttackData);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAttackData = matcher;
            }

            return _matcherAttackData;
        }
    }
}
