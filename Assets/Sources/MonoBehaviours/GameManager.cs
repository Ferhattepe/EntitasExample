using Entitas;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Systems _systems;
    [SerializeField] private FloatingJoystick floatingJoystick;
    [SerializeField] private GameObject playerObject;


    private void Awake()
    {
        var contexts = Contexts.sharedInstance;
        _systems = new Feature("Game_Systems")
            .Add(new MovementSystems(contexts, floatingJoystick, playerObject));
        _systems.Initialize();
    }

    private void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
    }
}