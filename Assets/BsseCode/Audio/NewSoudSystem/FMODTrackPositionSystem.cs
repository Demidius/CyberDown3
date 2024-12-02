using FMODUnity;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace BsseCode.Audio.NewSoudSystem
{
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public partial class FMODTrackPositionSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((ref FMODSound sound, in TrackPosition trackPosition) =>
            {
                if (SystemAPI.HasComponent<LocalToWorld>(trackPosition.Target))
                {
                    var position = SystemAPI.GetComponent<LocalToWorld>(trackPosition.Target).Position;
                    sound.Event.set3DAttributes(RuntimeUtils.To3DAttributes((Vector3)position));
                }
            }).WithoutBurst().Run();
        }
    }
}