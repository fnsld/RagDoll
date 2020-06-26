using Client.Scripts.Managers;
using UnityEngine;

namespace Client.Scripts.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Transform pelvis;

        private Vector3 initialPos;
        
        private void Awake()
        {
            initialPos = pelvis.position;
            Bus.OnHit.AddListener(OnHit);
            Bus.OnRestartRequested.AddListener(OnRestartRequested);
        }

        private void OnHit(EnemyController enemy)
        {
            if (enemy == this)
                animator.enabled = false;
        }

        private void OnRestartRequested()
        {
            animator.enabled = true;
            pelvis.position = initialPos;
        }
    }
}