using Entitas;
using Entitas.CodeGeneration.Attributes;
using Entitas.Unity;
using UnityEngine;

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