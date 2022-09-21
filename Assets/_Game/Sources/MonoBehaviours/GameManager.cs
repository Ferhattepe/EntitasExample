using BigRookGames.Weapons;
using Sources.Settings;
using Sources.Systems;
using Sources.Systems.Monster;
using Sources.Systems.Player;
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
        [SerializeField] private Transform bulletSpawnPoint;
        [SerializeField] private Slider playerHealthSlider;
        [SerializeField] private GameSettings gameSettings;
        [SerializeField] private Transform monsterSpawnPosition;
        [SerializeField] private GunfireController gunfireController;


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
                .Add(new CreatePlayerSystem(contexts, playerObject, playerHealthSlider, bulletSpawnPoint,
                    gunfireController, gameSettings))
                .Add(new MonsterSpawnSystem(contexts, monsterSpawnPosition, gameSettings))
                .Add(new PlayerJoystickControlSystem(contexts))
                .Add(new UpdateViewPositionSystem(contexts))
                .Add(new MoveSystem(contexts))
                .Add(new LookUpToDirectionSystem(contexts))
                .Add(new PlayerAnimationSystem(contexts))
                .Add(new MonsterFindTargetSystem(contexts, gameSettings))
                .Add(new MonsterAnimationSystem(contexts))
                .Add(new MonsterNavmeshSystem(contexts))
                .Add(new FindNearliestMonsterSystem(contexts, gameSettings))
                .Add(new PlayerAimAnimationSystem(contexts))
                .Add(new MonsterBeginAttackStateSystem(contexts))
                .Add(new MonsterAttackExecutionSystem(contexts))
                .Add(new AttackCheckSystem(contexts))
                .Add(new UpdateHealthViewComponent(contexts))
                .Add(new PlayerAttackExecutionSystem(contexts))
                .Add(new SpawnBulletSystem(contexts, gameSettings))
                .Add(new BulletHitSystem(contexts))
                .Add(new CheckDeathSystem(contexts))
                .Add(new MonsterDeathStateSystem(contexts))
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