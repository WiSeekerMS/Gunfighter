using Gameplay.ShootSystem.Presenters;
using Gameplay.ShotSystem.Presenters;
using UnityEngine;
using Zenject;

namespace Gameplay.ShootSystem.Views
{
    public class ShotView : MonoBehaviour
    {
        [SerializeField] private Transform _muzzleTransform;
        [Inject] private ShotPresenter _shotPresenter;

        private void Start()
        {
            _shotPresenter.SetMuzzleTransform(_muzzleTransform);
        }
    }
}