using BsseCode._5._GameEntities.Hero.Components;
using Cinemachine;
using UnityEngine;
using Zenject;

namespace BsseCode._5._GameEntities.Hero
{
    public class Player : MonoBehaviour
    {
        public BulletSpawnPoint BulletSpawnPoint { get; private set; }
        
        public CollisionHandler CollisionHandler { get; private set; }
        public MoveHandler MoveHandler { get; private set; }
        public BodyRotaionHero BodyRotaionHero { get; private set; }
        public LegsRotaionHero LegsRotaionHero { get; private set; }
        public HeroAudioController HeroAudioController { get; private set; }

        private CinemachineVirtualCamera _virtualCamera;

        [Inject]
        public void Construct(CinemachineVirtualCamera virtualCamera)
        {
            _virtualCamera = virtualCamera;
        }

        private void Awake()
        {
            _virtualCamera.Follow = this.transform;
            
            CollisionHandler = GetComponentInChildren<CollisionHandler>();
            BodyRotaionHero = GetComponentInChildren<BodyRotaionHero>();
            MoveHandler = GetComponentInChildren<MoveHandler>();
            LegsRotaionHero = GetComponentInChildren<LegsRotaionHero>();
            BulletSpawnPoint = GetComponentInChildren<BulletSpawnPoint>();
            HeroAudioController = GetComponentInChildren<HeroAudioController>();
        }
    }
}