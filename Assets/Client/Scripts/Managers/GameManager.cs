using Client.Scripts.Bullet;
using Client.Scripts.Enemy;
using UnityEngine;

namespace Client.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private BulletSettings[] bulletSettings;
        [SerializeField] private LayerMask bulletLayer;
        
        private int bulletSettingsIndex;

        private void Awake()
        {
            Bus.BulletLayer = bulletLayer;
            Bus.BulletSettings = bulletSettings[bulletSettingsIndex];
            
            Bus.OnHit.AddListener(OnHit);
            Bus.OnRestartRequested.AddListener(OnRestartRequested);
            Bus.OnBulletSettingsChangeRequest.AddListener(OnBulletSettingsChangeRequest);
        }

        private void OnHit(EnemyController enemy)
        {
            Time.timeScale = 0.25f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }

        private void OnRestartRequested()
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02f;
        }

        private void OnBulletSettingsChangeRequest()
        {
            bulletSettingsIndex++;
            if (bulletSettingsIndex > bulletSettings.Length - 1)
                bulletSettingsIndex = 0;
            Bus.BulletSettings = bulletSettings[bulletSettingsIndex];
        }
    }
}