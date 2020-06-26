using UnityEngine;

namespace Client.Scripts.Bullet
{
    [CreateAssetMenu(fileName = "BulletSettings", menuName = "ScriptableObjects/BulletSettings")]
    public class BulletSettings : ScriptableObject
    {
        [SerializeField] private string settingsName = "SomeName";
        [SerializeField] private float force = 500;
        [SerializeField] private float speed = 15;

        public string Name => settingsName;
        public float Force => force;
        public float Speed => speed;
    }
}