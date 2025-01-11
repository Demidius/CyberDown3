
using BsseCode._2._Services.GlobalServices.Pools;
using BsseCode._5._GameEntities.Objects.AfterDeathMarks;
using BsseCode._5._GameEntities.Objects.EnergyLoot;
using BsseCode._5._GameEntities.Objects.Explosion;
using UnityEngine;

namespace BsseCode._2._Services.GlobalServices.Handlers
{
    public interface IDeathEffectsHandler
    {
        void CreateExplosion(Vector2 position);
        void CreateResidue(Vector2 position);
        void CreateLoot(Vector2 position);
    }

    public class DeathEffectsHandler : IDeathEffectsHandler
{
    private IPoolController _poolController;

    public DeathEffectsHandler(IPoolController poolController)
    {
        _poolController = poolController;
    }

    public void CreateExplosion(Vector2 position)
    {
        var element = _poolController.GetPool<Explosion>().GetElement();
        element.transform.position = position;
    }

    public void CreateResidue(Vector2 position)
    {
        var element = _poolController.GetPool<AfterDeathMarks>().GetElement();
        element.transform.position = position;
    }

    public void CreateLoot(Vector2 position)
    {
        var element = _poolController.GetPool<EnergyLoot>().GetElement();
        element.transform.position = position;
    }
}
}