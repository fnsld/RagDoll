using UnityEngine;

namespace Client.Scripts.Bullet
{
    public class BaseBullet : MonoBehaviour
    {
        [SerializeField] private Collider _collider;
        [SerializeField] private float destroyDelay = 3;
        
        public BulletSettings BulletSettings;
        
        public bool IsSmashed => !_collider.enabled;

        private void Awake()
        {
            Destroy(gameObject, destroyDelay);
        }

        public void SetAsSmashed()
        {
            _collider.enabled = false;
        }
        
    }
}