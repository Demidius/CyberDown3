using BsseCode.Hero;
using BsseCode.Services;

namespace BsseCode.Enemes
{
    public interface IEnemy
    {
        public void SetParameters(float speed, Player player, IPoolEnemy1 poolEnemy1, MoveService moveService);
    }
}