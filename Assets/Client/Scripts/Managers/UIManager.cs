using UnityEngine;
using UnityEngine.UI;

namespace Client.Scripts.Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private Button bulletSettingsChange;
        
        private void Awake()
        {
            restartButton.onClick.AddListener(Bus.OnRestartRequested.Invoke);
            bulletSettingsChange.onClick.AddListener(Bus.OnBulletSettingsChangeRequest.Invoke);
                
            Bus.OnBulletSettingsChangeRequest.AddListener(OnBulletSettingsChangeRequest);
        }

        private void OnBulletSettingsChangeRequest()
        {
            bulletSettingsChange.GetComponentInChildren<Text>().text = Bus.BulletSettings.Name;
        }
    }
}