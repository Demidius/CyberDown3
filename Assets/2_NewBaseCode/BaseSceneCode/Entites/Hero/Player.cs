using _2_NewBaseCode.BaseSceneCode._2._Sevices.CameraHandler;
using _2_NewBaseCode.BaseSceneCode.Entites.Hero.Components;
using Cinemachine;
using UnityEngine;
using Zenject;

namespace _2_NewBaseCode.BaseSceneCode.Entites.Hero
{
    public class Player : MonoBehaviour
    {
        public BulletSpawnPoint BulletSpawnPoint { get; private set; }
        
        public CollisionHandler CollisionHandler { get; private set; }
        public MoveHandler MoveHandler { get; private set; }
        public BodyRotaionHero BodyRotaionHero { get; private set; }
        public LegsRotaionHero LegsRotaionHero { get; private set; }
        public HeroAudioController HeroAudioController { get; private set; }

        private ICameraHandler _virtualCamera;

        [Inject]
        public void Construct(ICameraHandler virtualCamera)
        {
            _virtualCamera = virtualCamera;
        }

        private void Awake()
        {
            CollisionHandler = GetComponentInChildren<CollisionHandler>();
            BodyRotaionHero = GetComponentInChildren<BodyRotaionHero>();
            MoveHandler = GetComponentInChildren<MoveHandler>();
            LegsRotaionHero = GetComponentInChildren<LegsRotaionHero>();
            BulletSpawnPoint = GetComponentInChildren<BulletSpawnPoint>();
            HeroAudioController = GetComponentInChildren<HeroAudioController>();
        }
    }
}