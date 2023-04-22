using System;
using System.Collections;
using DG.Tweening;
using Gameplay.ShotSystem.Presenters;
using UniRx;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

namespace Gameplay.ShotSystem.Views
{
    public class RevolverShotEffectView : MonoBehaviour
    {
        [SerializeField] private Transform _drumTransform;
        [SerializeField] private Transform _hammerTransform;
        [SerializeField] private ParticleSystem _effectPS;
        [SerializeField] private Animator _recoilAnimator;
        [SerializeField] private float _drumRotateSpeed;
        [SerializeField] private float _effectTime;
        [Inject] private ShotPresenter _shotPresenter;
        private IDisposable _timerObservable;
        private IDisposable _delayObservable;
        private IDisposable _animationObservable;
        private Sequence _loadGunSequence;
        private float _drumRotateAngle;
        private float _hammerRotateAngle;
        private Vector3 _drumEuler;
        private TimeSpan _effectDelay;
        private Vector3 _startPosition;
        private AnimationEvent _stopEvent;

        public event Action AnimationStop;

        private void Start()
        {
            _drumRotateAngle = 360f / 7;
            _hammerRotateAngle = 32f;
            _startPosition = transform.localPosition;
            _effectDelay = TimeSpan.FromSeconds(_effectTime);
            
            /*_stopEvent = new AnimationEvent();
            _stopEvent.functionName = "Test";
            
            var clip = _recoilAnimator.runtimeAnimatorController.animationClips[0];
            clip.AddEvent(_stopEvent);*/

            CockTrigger(null);
        }

        public void OnShot()
        {
            ReleaseBullet();
        }

        private void ReleaseBullet()
        {
            if (_shotPresenter.BulletAmount <= 0)
            {
                AnimationStop?.Invoke();
                //_hammerTransform.localEulerAngles = Vector3.zero;
                //CockTrigger(() => AnimationStop?.Invoke());
                return;
            }

            //_hammerTransform.localEulerAngles = Vector3.zero;
            ReleaseFlash();
        }

        private void ReleaseFlash()
        {
            if (_effectPS.isPlaying)
                _effectPS.Stop();
            
            _timerObservable?.Dispose();
            _effectPS.Play();
            
            _timerObservable = Observable
                .Timer(_effectDelay)
                .Subscribe(_ =>
                {
                    _effectPS.Stop();
                    AnimationStop?.Invoke();
                    //CockTrigger(() => AnimationStop?.Invoke());
                })
                .AddTo(this);
        }

        private IEnumerator RotateDrum()
        {
            _drumEuler += Vector3.back * _drumRotateAngle;
            if (_drumEuler.z < -360f)
            {
                var z = _drumEuler.z + 360f;
                _drumEuler = Vector3.forward * z;
            }

            var t = 0f;
            var to = Quaternion.Euler(_drumEuler);
            
            while (t < 1f)
            {
                t += _drumRotateSpeed * Time.deltaTime;
                _drumTransform.localRotation = Quaternion
                    .LerpUnclamped(_drumTransform.localRotation, to, t);
                
                yield return null;
            }
        }

        private IEnumerator RotateHummer()
        {
            var t = 0f;
            var clockEuler = Vector3.left * _hammerRotateAngle;
            var to = Quaternion.Euler(clockEuler);

            while (t < 1f)
            {
                t += _drumRotateSpeed * Time.deltaTime;
                _hammerTransform.localRotation = Quaternion
                    .LerpUnclamped(_hammerTransform.localRotation, to, t);

                yield return null;
            }
        }

        /*private bool[] _testArray;

        private bool Check()
        {
            if (_testArray == null)
            {
                return false;
            }

            for (int i = 0; i < _testArray.Length; i++)
            {
                if (!_testArray[i])
                    return false;
            }

            return true;
        }
        
        private void Test(int index)
        {
            _testArray[index] = true;
            if (!Check()) return;
            print("Complite!");
        }*/

        private void LoadGun(Action action)
        {
            /*_testArray = new bool[2];
            Observable.FromCoroutine(RotateDrum).Subscribe(_ => Test(0));
            Observable.FromCoroutine(RotateDrum).Subscribe(_ => Test(1));*/
            
            /*if (_loadGunSequence == null)
            {
                _loadGunSequence = DOTween.Sequence();
            }

            if (_loadGunSequence.active)
            {
                _loadGunSequence.Kill();
            }*/

            /*var clockEuler = Vector3.left * _hammerRotateAngle;*/

            /*_loadGunSequence
                .Join(_drumTransform
                    .DOLocalRotate(_drumEuler, _drumRotateSpeed)
                    .SetEase(Ease.Linear))
                .Join(_hammerTransform
                    .DOLocalRotate(clockEuler, _drumRotateSpeed)
                    .SetEase(Ease.Linear))
                .OnComplete(() =>
                {
                    action?.Invoke();
                    print("WWWW");
                });*/
            
            action?.Invoke();
        }

        private void CockTrigger(Action action)
        {
            _delayObservable?.Dispose();
            _delayObservable = Observable
                .Timer(TimeSpan.FromSeconds(0.3f))
                .Subscribe(_ => LoadGun(action))
                .AddTo(this);
        }

        /*private IEnumerator AnimationCor()
        {
            _recoilAnimator.SetBool("IsRecoil", true);
            _recoilAnimator.GetCurrentAnimatorClipInfo()
            /*_recoilAnimator.pl
            anim.Play();
            while (anim.isPlaying)
                yield return null;#1#
        }*/

        private void ResetRecoilPosition()
        {
            /*transform.localEulerAngles = Vector3.zero;
            transform.localPosition = _startPosition;*/
        }

        public void StartRecoil()
        {
            /*_animationObservable?.Dispose();
            _animationObservable = Observable
                .FromCoroutine(_ => AnimationCor())
                .Subscribe(_ => ResetRecoilPosition())
                .AddTo(this);*/
        }
    }
}