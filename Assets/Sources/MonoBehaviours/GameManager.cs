using Sources.Settings;
using Sources.Systems;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.MonoBehaviours
{
    public class GameManager : MonoBehaviour
    {
        private Entitas.Systems _systems;
        private Entitas.Systems _inputSystems;
        private Entitas.Systems _physicsSystems;
        [SerializeField] private FloatingJoystick floatingJoystick;
        [SerializeField] private GameObject playerObject;
        [SerializeField] private Slider playerHealthSlider;
        [SerializeField] private GameSettings gameSettings;
        [SerializeField] private Transform monsterSpawnPosition;


        private void Awake()
        {
            var contexts = Contexts.sharedInstance;

            _inputSystems = new Feature("Input_Systems")
                .Add(new ListenJoystickSystem(contexts, floatingJoystick))
                .Add(new ProgressCollisionSystem(contexts));

            _physicsSystems = new Feature("Physics_Systems")
                .Add(new PhysicsMoveSystem(contexts))
                .Add(new PhysicsVelocityLimitSystem(contexts));

            _systems = new Feature("Game_Systems")
                .Add(new CreatePlayerSystem(contexts, playerObject, playerHealthSlider, gameSettings))
                .Add(new MonsterSpawnSystem(contexts, monsterSpawnPosition, gameSettings))
                .Add(new PlayerJoystickControlSystem(contexts))
                .Add(new UpdateViewPositionSystem(contexts))
                .Add(new MoveSystem(contexts))
                .Add(new MovementAnimationSystem(contexts))
                .Add(new MonsterFindTargetSystem(contexts, gameSettings))
                .Add(new MonsterNavmeshSystem(contexts))
                .Add(new FindNearliestMonsterSystem(contexts, gameSettings))
                .Add(new PlayerAimAnimationSystem(contexts))
                .Add(new AttackStateSystem(contexts))
                .Add(new AttackCheckSystem(contexts, gameSettings))
                .Add(new UpdateHealthViewComponent(contexts))
                .Add(new CalculatePlayerForwardSystem(contexts, gameSettings));


            _inputSystems.Initialize();
            _physicsSystems.Initialize();
            _systems.Initialize();
        }

        private void Update()
        {
            _inputSystems.Execute();
            _systems.Execute();

            _inputSystems.Cleanup();
            _systems.Cleanup();
        }

        private void FixedUpdate()
        {
            _physicsSystems.Execute();
            _physicsSystems.Cleanup();
        }
    }
}