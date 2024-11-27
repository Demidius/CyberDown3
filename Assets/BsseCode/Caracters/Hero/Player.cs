using System;
using BsseCode.Caracters.Hero.Components;
using BsseCode.Caracters.Hero.PlayerStateMachina;
using Cinemachine;
using UnityEngine;
using Zenject;

namespace BsseCode.Caracters.Hero
{
    public class Player : MonoBehaviour
    {
        public BulletSpawnPoint BulletSpawnPoint { get; private set; }
        public CharacterStateMachine StateMachine { get; private set; }
        public CollisionHandler CollisionHandler { get; private set; }
        public MoveHendler MoveHendler { get; private set; }
        public BodyHero BodyHero { get; private set; }
        public LegsHero LegsHero { get; private set; }
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
            StateMachine = new CharacterStateMachine();
            StateMachine.ChangeState(new IdleState());
            CollisionHandler = GetComponentInChildren<CollisionHandler>();
            BodyHero = GetComponentInChildren<BodyHero>();
            MoveHendler = GetComponentInChildren<MoveHendler>();
            LegsHero = GetComponentInChildren<LegsHero>();
            BulletSpawnPoint = GetComponentInChildren<BulletSpawnPoint>();
            HeroAudioController = GetComponentInChildren<HeroAudioController>();
        }
    }
}