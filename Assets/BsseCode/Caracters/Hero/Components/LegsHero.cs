using BsseCode.Caracters.Elements;
using UnityEngine;
using UnityEngine.Serialization;

namespace BsseCode.Caracters.Hero.Components
{
    public class LegsHero : MonoBehaviour
    {
        [FormerlySerializedAs("heroMove")] [FormerlySerializedAs("heroBase")] [FormerlySerializedAs("player")] [SerializeField] private MoveHendler move;

        void Update()
        {
            // Получаем направление от PlayerController и поворачиваем объект
            var direction = move.movementHeroDirection;
            RotationUtils.RotateTowardsDirection(transform, direction);
        }
    }
}