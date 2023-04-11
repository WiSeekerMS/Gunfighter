using System;
using UniRx;
using UnityEngine;

namespace Common.Audio
{
    public class Sfx : MonoBehaviour
    {
        [SerializeField] 
        private AudioSource _audioSource;
        private Action _onStopAction;

        public void Init(AudioClip clip, Action action)
        {
            _onStopAction = action;
            _audioSource.PlayOneShot(clip);
            
            Observable
                .EveryUpdate()
                .Where(_ => !_audioSource.isPlaying)
                .Subscribe(_ => OnStopAudioClip())
                .AddTo(this);
        }

        private void OnStopAudioClip()
        {
            _onStopAction?.Invoke();
            Destroy(gameObject);
        }
    }
}