using System.Collections.Generic;
using UnityEngine;

namespace Common.Audio
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private Sfx _sfxPrefab;

        public void PlayClip(AudioClip clip, Vector3 position)
        {
            var sfx = Instantiate(_sfxPrefab);
            sfx.transform.position = position;
            sfx.Init(clip);
        }
        
        public AudioClip GetRandomAudioClip(List<AudioClip> clips)
        {
            return clips[Random.Range(0, clips.Count)];
        }

        public void PlayRandomAudioClip(List<AudioClip> clips, Vector3 position)
        {
            var clip = GetRandomAudioClip(clips);
            PlayClip(clip, position);
        }
    }
}