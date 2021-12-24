using UnityEngine;
using Entitas;


public class ListenJoystickSystem : IExecuteSystem, IInitializeSystem
{
    private GameContext _gameContext;
    private FloatingJoystick _floatingJoystick;

    public ListenJoystickSystem(Contexts contexts, FloatingJoystick floatingJoystick)
    {
        _gameContext = contexts.game;
        _floatingJoystick = floatingJoystick;
    }

    public void Execute()
    {
        var value = new Vector3(_floatingJoystick.Horizontal, 0,
            _floatingJoystick.Vertical);
        _gameContext.ReplaceMovementDirection(value);
    }

    public void Initialize()
    {
        _gameContext.SetMovementDirection(Vector3.zero);
    }
}