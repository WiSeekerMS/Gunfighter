using InstantGamesBridge;
using InstantGamesBridge.Modules.Platform;
using UnityEngine;
using UnityEngine.UI;

namespace Examples
{
    public class PlatformPanel : MonoBehaviour
    {
        [SerializeField] private Text _id;

        [SerializeField] private Text _language;

        [SerializeField] private Text _payload;

        [SerializeField] private Button _sendGameLoadingStartedMessageButton;
        
        [SerializeField] private Button _sendGameLoadingStoppedMessageButton;
        
        [SerializeField] private Button _sendGameplayStartedMessageButton;
        
        [SerializeField] private Button _sendGameplayStoppedMessageButton;
        
        [SerializeField] private Button _sendPlayerGotAchievementMessageButton;

        private void Start()
        {
            _id.text = $"ID: { Bridge.platform.id }";
            _language.text = $"Language: { Bridge.platform.language }";
            _payload.text = $"Payload: { Bridge.platform.payload }";
            
            _sendGameLoadingStartedMessageButton.onClick.AddListener(OnSendGameLoadingStartedMessageButtonClicked);
            _sendGameLoadingStoppedMessageButton.onClick.AddListener(OnSendGameLoadingStoppedMessageButtonClicked);
            _sendGameplayStartedMessageButton.onClick.AddListener(OnSendGameplayStartedMessageButtonClicked);
            _sendGameplayStoppedMessageButton.onClick.AddListener(OnSendGameplayStoppedMessageButtonClicked);
            _sendPlayerGotAchievementMessageButton.onClick.AddListener(OnSendPlayerGotAchievementMessageButtonClicked);
        }

        private void OnSendGameLoadingStartedMessageButtonClicked()
        {
            Bridge.platform.SendMessage(PlatformMessage.GameLoadingStarted);
        }
        
        private void OnSendGameLoadingStoppedMessageButtonClicked()
        {
            Bridge.platform.SendMessage(PlatformMessage.GameLoadingStopped);
        }
        
        private void OnSendGameplayStartedMessageButtonClicked()
        {
            Bridge.platform.SendMessage(PlatformMessage.GameplayStarted);
        }
        
        private void OnSendGameplayStoppedMessageButtonClicked()
        {
            Bridge.platform.SendMessage(PlatformMessage.GameplayStopped);
        }
        
        private void OnSendPlayerGotAchievementMessageButtonClicked()
        {
            Bridge.platform.SendMessage(PlatformMessage.PlayerGotAchievement);
        }
    }
}