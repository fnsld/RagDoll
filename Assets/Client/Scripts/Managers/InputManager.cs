using Lean.Touch;
using UnityEngine;

namespace Client.Scripts.Managers
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private LeanFingerDown leanFingerTap;

        private Camera mainCamera;
        
        private void Awake()
        {
            mainCamera = Camera.main;
            leanFingerTap.OnFinger.AddListener(OnFingerDown);
        }

        private void OnFingerDown(LeanFinger finger)
        {
            var worldPos = finger.GetWorldPosition(10, mainCamera);
            Bus.OnFingerDown.Invoke(worldPos);
        }
    }
}