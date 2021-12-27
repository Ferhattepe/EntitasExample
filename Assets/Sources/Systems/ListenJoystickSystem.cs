using Entitas;
using UnityEngine;

namespace Sources.Systems
{
    public class ListenJoystickSystem : IExecuteSystem, IInitializeSystem
    {
        private readonly InputContext _inputContext;
        private readonly FloatingJoystick _floatingJoystick;

        public ListenJoystickSystem(Contexts contexts, FloatingJoystick floatingJoystick)
        {
            _inputContext = contexts.input;
            _floatingJoystick = floatingJoystick;
        }

        public void Initialize()
        {
            _inputContext.SetJoystickInput(Vector3.zero);
        }

        public void Execute()
        {
            if (Input.GetMouseButton(0))
            {
                var value = new Vector3(_floatingJoystick.Horizontal, 0,
                    _floatingJoystick.Vertical);
                _inputContext.ReplaceJoystickInput(value);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _inputContext.ReplaceJoystickInput(Vector3.zero);
            }
        }
    }
}