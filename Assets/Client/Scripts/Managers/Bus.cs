using Client.Scripts.Bullet;
using Client.Scripts.Enemy;
using UnityEngine;
using UnityEngine.Events;

namespace Client.Scripts.Managers
{
    public class Vector3Event : UnityEvent<Vector3> {}
    public class EnemyHitEvent : UnityEvent<EnemyController> {}

    public static class Bus
    {
        // Input
        public static Vector3Event OnFingerDown = new Vector3Event();
        
        // Game
        public static EnemyHitEvent OnHit = new EnemyHitEvent();
        public static UnityEvent OnRestartRequested = new UnityEvent();
        public static UnityEvent OnBulletSettingsChangeRequest = new UnityEvent();
        public static UnityEvent SlowMotionChanged = new UnityEvent();

        // States
        public static Transform BulletStartTransform;
        public static BulletSettings BulletSettings;
        public static LayerMask BulletLayer;
    }
}