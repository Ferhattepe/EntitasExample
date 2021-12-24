using Sources.Systems;
using UnityEngine;

public class MovementSystems : Feature
{
    public MovementSystems(Contexts contexts, FloatingJoystick floatingJoystick, GameObject player) : base(
        "Movement_System")
    {
        base.Add(new ListenJoystickSystem(contexts, floatingJoystick));
        base.Add(new CreatePlayerSystem(contexts, player));
        base.Add(new UpdateViewPositionSystem(contexts));
        base.Add(new MoveSystem(contexts));
    }
}