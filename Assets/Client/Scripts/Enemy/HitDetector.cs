using Client.Scripts.Bullet;
using Client.Scripts.Managers;
using UnityEngine;

namespace Client.Scripts.Enemy
{
    public class HitDetector : MonoBehaviour
    {
        private Rigidbody rigidbody;

        private EnemyController parentEnemyController;
        
        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
            parentEnemyController = gameObject.GetComponentInParent<EnemyController>();
            Bus.OnRestartRequested.AddListener(OnRestartRequested);
        }

        private void OnRestartRequested()
        {
            rigidbody.velocity = Vector3.zero;
        }
        
        private void OnCollisionEnter(Collision other)
        {
            // Check to prevent reactions to anything except bullets
            if (Bus.BulletLayer != (Bus.BulletLayer | (1 << other.gameObject.layer)))
                return;
            
            Bus.OnHit.Invoke(parentEnemyController);
                    
            var bullet = other.gameObject.GetComponent<BaseBullet>();
            if (bullet == null || bullet.IsSmashed) 
                return;
            bullet.SetAsSmashed();
            
            float force = bullet.BulletSettings.Force * (1 / Time.timeScale);
            Vector3 dir = transform.position - Bus.BulletStartTransform.position;
        
            GetComponent<Rigidbody>().AddForce(dir.normalized * force);
        }
    }
}