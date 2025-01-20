using Zenject;

namespace _2_NewBaseCode.BaseSceneCode.Entites.Hero
{
    public class PlayerModule : IPlayerModule
    {
        public Player PlayerObject { get; set; }

        [Inject]
        void Construct(Player player)
        {
            PlayerObject = player;
        }
        
        
    }

    public interface IPlayerModule
    {
        public Player PlayerObject { get; }
    }
}