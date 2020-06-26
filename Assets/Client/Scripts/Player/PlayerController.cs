using Client.Scripts.Managers;
using Client.Scripts.Bullet;
using UnityEngine;

namespace Client.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Transform bulletStartPos;
        [SerializeField] private GameObject bulletPrefab;

        private void Awake()
        {
            Bus.OnFingerDown.AddListener(Fire);
            Bus.BulletStartTransform = bulletStartPos;
        }

        private void Fire(Vector3 targetPos)
        {
            var targetDir = bulletStartPos.position - targetPos;
            
            var dir = Vector3.RotateTowards(transform.forward, targetDir, 0, 0);
            var lookRot = Quaternion.LookRotation(dir);

            var bullet = Instantiate(bulletPrefab, bulletStartPos.position, lookRot).GetComponent<BaseBullet>();
            bullet.BulletSettings = Bus.BulletSettings;
            
            var force = -targetDir.normalized * (bullet.BulletSettings.Speed * (1 / Time.timeScale));
            bullet.GetComponent<Rigidbody>().AddForce(force);
        }
    }
}
