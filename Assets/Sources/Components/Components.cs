using BigRookGames.Weapons;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using Entitas.Unity;
using UnityEngine;
using UnityEngine.UI;

// Player flag
[Game]
public class Player : IComponent
{
}

// Monster flag
[Game]
public class Monster : IComponent
{
}

// Alive flag
[Game]
public class Alive : IComponent
{
}

[Game]
public class TargetComponent : IComponent
{
    public GameEntity Value;
}

[Game]
public class AttackStateComponent : IComponent
{
    public float ExecutionTime;
}


[Game]
public class NextAttackTimeComponent : IComponent
{
    public float Value;
}

[Game]
public class AttackDataComponent : IComponent
{
    public float Interval;
    public float Range;
    public float AttackDelay;
}

[Game]
public class FireBulletComponent : IComponent
{
    public Vector3 Direction;
}

[Game]
public class GunView : IComponent
{
    public GunfireController GunfireController;
}

[Game]
public class BulletSpawnPointComponent : IComponent
{
    public Transform Value;
}

// Player aim target flag
[Game]
public class Aim : IComponent
{
}

[Game]
public class RigidbodyComponent : IComponent
{
    public Rigidbody Value;
}

[Game, Unique]
public class MonsterSpawnComponent : IComponent
{
    public float NextSpawnTime;
}

[Game]
public class AnimationComponent : IComponent
{
    public Animator Value;
}

[Game]
public class PositionComponent : IComponent
{
    public Vector3 Value;
}

[Game]
public class ViewComponent : IComponent
{
    public GameObject Value;
}

[Game]
public class VelocityLimit : IComponent
{
    public float Value;
}

[Game]
public class SpeedComponent : IComponent
{
    public float Value;
}

[Input, Unique]
public class JoystickInputComponent : IComponent
{
    public Vector3 Value;
}

[Game]
public class MovementDirectionComponent : IComponent
{
    public Vector3 Value;
}

[Game]
public class CurrentHealthComponent : IComponent
{
    public int Value;
}

[Game]
public class BaseHealthComponent : IComponent
{
    public int Value;
}

[Game]
public class HealthViewComponent : IComponent
{
    public Slider Slider;
}

[Game]
public class LookDirectionComponent : IComponent
{
    public Vector3 Value;
}

[Input]
public class CollisionComponent : IComponent
{
    public EntityLink Self;
    public EntityLink Other;
}

[Game]
public class TriggerComponent : IComponent
{
    public GameEntity Self;
    public GameEntity Other;
}