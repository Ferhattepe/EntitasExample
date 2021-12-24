using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game]
public class PositionComponent : IComponent
{
    public Vector3 value;
}

[Game]
public class ViewComponent : IComponent
{
    public GameObject value;
}

[Game]
public class SpeedComponent : IComponent
{
    public float value;
}

[Game, Unique]
public class MovementDirectionComponent : IComponent
{
    public Vector3 value;
}