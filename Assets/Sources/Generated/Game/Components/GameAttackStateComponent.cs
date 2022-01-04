//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public AttackStateComponent attackState { get { return (AttackStateComponent)GetComponent(GameComponentsLookup.AttackState); } }
    public bool hasAttackState { get { return HasComponent(GameComponentsLookup.AttackState); } }

    public void AddAttackState(float newExecutionTime) {
        var index = GameComponentsLookup.AttackState;
        var component = (AttackStateComponent)CreateComponent(index, typeof(AttackStateComponent));
        component.ExecutionTime = newExecutionTime;
        AddComponent(index, component);
    }

    public void ReplaceAttackState(float newExecutionTime) {
        var index = GameComponentsLookup.AttackState;
        var component = (AttackStateComponent)CreateComponent(index, typeof(AttackStateComponent));
        component.ExecutionTime = newExecutionTime;
        ReplaceComponent(index, component);
    }

    public void RemoveAttackState() {
        RemoveComponent(GameComponentsLookup.AttackState);
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

    static Entitas.IMatcher<GameEntity> _matcherAttackState;

    public static Entitas.IMatcher<GameEntity> AttackState {
        get {
            if (_matcherAttackState == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AttackState);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAttackState = matcher;
            }

            return _matcherAttackState;
        }
    }
}
