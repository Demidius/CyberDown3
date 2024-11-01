using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace BsseCode.Weapons.Bullet
{
    public class PoolBullet : MonoBehaviour, IPoolBullet
    {
 
   [FormerlySerializedAs("bullet2Prefab")] [SerializeField] private BsseCode.Weapons.Bullet.Bullet bulletPrefab;

    private PoolComponent<BsseCode.Weapons.Bullet.Bullet> _poolComponent;
 
    [Inject]
    public void Construct(PoolComponent<BsseCode.Weapons.Bullet.Bullet> poolComponent)
    {
        _poolComponent = poolComponent;
    }
  
    public void GetBullet(Vector3 direction, float speed )
    {
        var bullet = _poolComponent.GetElement();
    }

    }
}