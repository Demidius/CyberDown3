using System;
using BsseCode.Audio;
using BsseCode.Caracters.Hero.Components;
using BsseCode.Pools.Pools;
using BsseCode.Pools.Pools.SourceSours;
using BsseCode.Services.InputFol;
using FMODUnity;
using UnityEngine;
using Zenject;

namespace BsseCode.Caracters.Hero
{
    public class HeroAudioController : MonoBehaviour
    {
        private Player _player;

       
        private IPoolController _poolController;
       
       


        [Inject]
        public void Construct(Player player, IPoolController poolController)
        {
            _poolController = poolController;
            _player = player;
        }

      

        public void PlayStep()
        {
            // _audioExplorer.PlayOneSound(_audioTracksDate.stepEvent,this._player.transform.position, _poolController);
        }

       

       
    }
}