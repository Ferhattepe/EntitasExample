//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public FireBulletComponent fireBullet { get { return (FireBulletComponent)GetComponent(GameComponentsLookup.FireBullet); } }
    public bool hasFireBullet { get { return HasComponent(GameComponentsLookup.FireBullet); } }

    public void AddFireBullet(UnityEngine.Vector3 newDirection) {
        var index = GameComponentsLookup.FireBullet;
        var component = (FireBulletComponent)CreateComponent(index, typeof(FireBulletComponent));
        component.Direction = newDirection;
        AddComponent(index, component);
    }

    public void ReplaceFireBullet(UnityEngine.Vector3 newDirection) {
        var index = GameComponentsLookup.FireBullet;
        var component = (FireBulletComponent)CreateComponent(index, typeof(FireBulletComponent));
        component.Direction = newDirection;
        ReplaceComponent(index, component);
    }

    public void RemoveFireBullet() {
        RemoveComponent(GameComponentsLookup.FireBullet);
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

    static Entitas.IMatcher<GameEntity> _matcherFireBullet;

    public static Entitas.IMatcher<GameEntity> FireBullet {
        get {
            if (_matcherFireBullet == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.FireBullet);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherFireBullet = matcher;
            }

            return _matcherFireBullet;
        }
    }
}
