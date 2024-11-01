using System.Collections;
using UnityEngine;

namespace BsseCode.Weapons.Bullet
{
    public class Bullet : MonoBehaviour, IBullet
    {
        [SerializeField] private float lifetime = 2f;
   
        private PoolComponent<Bullet> _poolComponent;

        public void SetParameters(float speed, PoolComponent<Bullet> poolComponent)
        {
            _poolComponent = poolComponent;
        }

        private void OnEnable()
        {
            StartCoroutine(LifeRoutine());
        }

        private void OnDisable()
        {
            StopCoroutine(LifeRoutine());
        }

        private IEnumerator LifeRoutine()
        {
            yield return new WaitForSeconds(lifetime);
            Deactivate();
        }

        private void Deactivate()
        {
            _poolComponent?.ReturnToPool(this);
        }
    }
}