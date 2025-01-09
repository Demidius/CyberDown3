using Zenject;

namespace BsseCode._5._GameEntities.Hero
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