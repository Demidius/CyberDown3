using BsseCode._5._GameEntities.PlayerModule.Components;
using Cinemachine;
using UnityEngine;
using Zenject;

namespace BsseCode._5._GameEntities.PlayerModule
{
    public class Player : MonoBehaviour, IPlayer
    {
    public CollisionHandler CollisionHandler { get; private set; }
    public MoveHandler MoveHandler { get; private set; }
    public BodyRotaionHero BodyRotaionHero { get; private set; }
    public LegsRotaionHero LegsRotaionHero { get; private set; }
    public AudioStepBech AudioStepBech { get; private set; }

    private CinemachineVirtualCamera _virtualCamera;

    [Inject]
    public void Construct(CinemachineVirtualCamera virtualCamera)
    {
        _virtualCamera = virtualCamera;
    }

    private void OnValidate()
    {
        _virtualCamera.Follow = this.transform;

        CollisionHandler = GetComponentInChildren<CollisionHandler>();
        BodyRotaionHero = GetComponentInChildren<BodyRotaionHero>();
        MoveHandler = GetComponentInChildren<MoveHandler>();
        LegsRotaionHero = GetComponentInChildren<LegsRotaionHero>();
        AudioStepBech = GetComponentInChildren<AudioStepBech>();
    }
    }

    public interface IPlayer
    {
    }
}