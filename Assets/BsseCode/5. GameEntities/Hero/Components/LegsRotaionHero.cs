using BsseCode._5._GameEntities.UnivercialUtils;
using UnityEngine;

namespace BsseCode._5._GameEntities.Hero.Components
{
    public class LegsRotaionHero : MonoBehaviour
    {
       [SerializeField] private MoveHandler move;

        void Update()
        {
            // Получаем направление от PlayerController и поворачиваем объект
            var direction = move.movementHeroDirection;
            RotationUpdateService.RotateTowardsDirection(transform, direction);
        }
    }
}