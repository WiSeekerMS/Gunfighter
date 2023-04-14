using System.Collections.Generic;
using Gameplay.ShootSystem;
using UnityEngine;

namespace Gameplay.ShotSystem.Configs
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "Configs/WeaponConfig")]
    public class WeaponConfig : ScriptableObject
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private string _weaponName;
        [SerializeField] private FlyingBullet _bulletPrefab;
        [SerializeField] private int _bulletAmount;
        [SerializeField] private int _bulletAmountPerShot;
        [SerializeField] private float _bobbingSmoothTime;
        [SerializeField] private float _bobbingDeltaShift;
        [SerializeField] private float _scoringRatio;
        [SerializeField] private float _bulletSpeed;
        [SerializeField] private AudioClip _rechargeClip;
        [SerializeField] private List<AudioClip> _shotAudioClips;
        [SerializeField] private List<AudioClip> _noAmoClips;

        public Sprite Icon => _icon;
        public string WeaponName => _weaponName;
        public FlyingBullet BulletPrefab => _bulletPrefab;
        public int BulletAmount => _bulletAmount;
        public int BulletAmountPerShot => _bulletAmountPerShot;
        public float BobbingSmoothTime => _bobbingSmoothTime;
        public float BobbingDeltaShift => _bobbingDeltaShift;
        public float ScoringRatio => _scoringRatio;
        public float BulletSpeed => _bulletSpeed;
        public AudioClip RechargeClip => _rechargeClip;
        public List<AudioClip> ShotAudioClips => _shotAudioClips;
        public List<AudioClip> NoAmoClips => _noAmoClips;
    }
}