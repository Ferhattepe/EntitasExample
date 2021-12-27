using System;
using UnityEngine;

namespace Sources.Settings
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/Game Settings", order = 1)]
    public class GameSettings : ScriptableObject
    {
        public Player playerSettings;
        public Monster monster;

        [Serializable]
        public class Player
        {
            public float speed;
        }

        [Serializable]
        public class Monster
        {
            public GameObject prefab;
            public float speed;
            public float spawnInterval;
            public float velocityLimit;
        }
    }
}