using System;
using UnityEngine;

namespace Sources.Settings
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/Game Settings", order = 1)]
    public class GameSettings : ScriptableObject
    {
        public Player player;
        public Monster monster;

        [Serializable]
        public class Player
        {
            public float speed;
            public float detectionDistance;
            public float rotationSpeed;
            public float detectionInterval;
            public int baseHealth;
            public float attackInterval;
            public float attackRange;
            public float attackDelay;
            public GunSettings gun;

            [Serializable]
            public class GunSettings
            {
                public GameObject bulletPrefab;
            }
        }

        [Serializable]
        public class Monster
        {
            public GameObject prefab;
            public float speed;
            public float spawnInterval;
            public float velocityLimit;
            public float detectionInterval;
            public float attackRange;
            public float attackInterval;
            public float attackDelay;
        }
    }
}