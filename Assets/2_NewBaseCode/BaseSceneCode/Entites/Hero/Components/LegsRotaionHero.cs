using BsseCode._5._GameEntities.UnivercialUtils;
using UnityEngine;

namespace _2_NewBaseCode.BaseSceneCode.Entites.Hero.Components
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