using DG.Tweening;
using System;
using System.Linq;
using UnityEngine;

namespace Assets._Project.Scripts.Levels.Controllers
{
    public class MergeAnimator : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _mergeParticlesPrefab;

        public void PlayMergeAnimation(ItemWeaponView source, ItemWeaponView target, Action onComplete)
        {
            Sequence mergeSequence = DOTween.Sequence();

            mergeSequence.Append(source.transform.DOScale(0.3f, 0.3f).SetEase(Ease.InBack));
            mergeSequence.Join(target.transform.DOScale(0.3f, 0.3f).SetEase(Ease.InBack));

            mergeSequence.OnComplete(() =>
            {
                PlayParticles(target.transform.position);

                Destroy(source.gameObject);
                Destroy(target.gameObject);

                onComplete?.Invoke();
            });
        }

        private void PlayParticles(Vector3 position)
        {
            if (_mergeParticlesPrefab != null)
            {
                ParticleSystem particles = Instantiate(_mergeParticlesPrefab, position, Quaternion.identity);
                particles.Play();
                Destroy(particles.gameObject, particles.main.duration + particles.main.startLifetime.constantMax);
            }
        }
    }
}
