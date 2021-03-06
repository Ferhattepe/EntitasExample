//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity monsterSpawnEntity { get { return GetGroup(GameMatcher.MonsterSpawn).GetSingleEntity(); } }
    public MonsterSpawnComponent monsterSpawn { get { return monsterSpawnEntity.monsterSpawn; } }
    public bool hasMonsterSpawn { get { return monsterSpawnEntity != null; } }

    public GameEntity SetMonsterSpawn(float newNextSpawnTime) {
        if (hasMonsterSpawn) {
            throw new Entitas.EntitasException("Could not set MonsterSpawn!\n" + this + " already has an entity with MonsterSpawnComponent!",
                "You should check if the context already has a monsterSpawnEntity before setting it or use context.ReplaceMonsterSpawn().");
        }
        var entity = CreateEntity();
        entity.AddMonsterSpawn(newNextSpawnTime);
        return entity;
    }

    public void ReplaceMonsterSpawn(float newNextSpawnTime) {
        var entity = monsterSpawnEntity;
        if (entity == null) {
            entity = SetMonsterSpawn(newNextSpawnTime);
        } else {
            entity.ReplaceMonsterSpawn(newNextSpawnTime);
        }
    }

    public void RemoveMonsterSpawn() {
        monsterSpawnEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MonsterSpawnComponent monsterSpawn { get { return (MonsterSpawnComponent)GetComponent(GameComponentsLookup.MonsterSpawn); } }
    public bool hasMonsterSpawn { get { return HasComponent(GameComponentsLookup.MonsterSpawn); } }

    public void AddMonsterSpawn(float newNextSpawnTime) {
        var index = GameComponentsLookup.MonsterSpawn;
        var component = (MonsterSpawnComponent)CreateComponent(index, typeof(MonsterSpawnComponent));
        component.NextSpawnTime = newNextSpawnTime;
        AddComponent(index, component);
    }

    public void ReplaceMonsterSpawn(float newNextSpawnTime) {
        var index = GameComponentsLookup.MonsterSpawn;
        var component = (MonsterSpawnComponent)CreateComponent(index, typeof(MonsterSpawnComponent));
        component.NextSpawnTime = newNextSpawnTime;
        ReplaceComponent(index, component);
    }

    public void RemoveMonsterSpawn() {
        RemoveComponent(GameComponentsLookup.MonsterSpawn);
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

    static Entitas.IMatcher<GameEntity> _matcherMonsterSpawn;

    public static Entitas.IMatcher<GameEntity> MonsterSpawn {
        get {
            if (_matcherMonsterSpawn == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MonsterSpawn);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMonsterSpawn = matcher;
            }

            return _matcherMonsterSpawn;
        }
    }
}
