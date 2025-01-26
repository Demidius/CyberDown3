using System;
using _2_NewBaseCode.Level1.Entites.Player;
using _2_NewBaseCode.Level1.Entites.Player.PlayerBaseCode;
using UnityEngine;

namespace _2_NewBaseCode.BaseSceneCode.PlayerPrefabManeger
{
    public class PlayerPrefabsDate : MonoBehaviour, IPlayerPrefabsDate
    {
        [SerializeField] private PlayerComponent basePlayerPrefab;
       
        [SerializeField] private PlayerComponent playersBodyBasePrefab;
        
        [SerializeField] private PlayerComponent playersLegsBasePrefab;
        
        
        private PlayerComponent _currentPlayerBase;
        private PlayerComponent _currentBody;
        private PlayerComponent _currentLegs;

        private void Start()
        {
            SetCurrentElement(basePlayerPrefab);
            SetCurrentElement(playersBodyBasePrefab);
            SetCurrentElement(playersLegsBasePrefab);
            if (_currentPlayerBase == null || _currentBody == null || _currentLegs == null )
            {
                Debug.Log("Player is not Set");
            }
        }

        public void SetCurrentElement(PlayerComponent currentElement)
        {
            
            if (currentElement == null)
            {
                Debug.LogError("SetCurrentElement: Provided currentElement is null.");
                return;
            }
            
            var playerBase = currentElement.GetComponent<IPlayerBase>();
            var bodyBase = currentElement.GetComponent<IPlayersBodyBase>();
            var legsBase = currentElement.GetComponent<IPlayersLegsBase>();

            if (playerBase != null)
            {
                _currentPlayerBase = currentElement;
            }
            else if (bodyBase != null)
            {
                _currentBody = currentElement;
            }
            else if (legsBase != null)
            {
                _currentLegs = currentElement;
            }
            else
            {
                Debug.Log($"Element {currentElement.name} is incorrect.");
            }
        }

        public PlayerComponent GetCurrentPlayerBase()
        {
            return _currentPlayerBase;
        }
        
        public PlayerComponent GetCurrentPlayerBody()
        {
            return _currentBody;
        }
        
        public PlayerComponent GetCurrentPlayerLegs()
        {
            return _currentLegs;
        }
        
        
        
    }

    public interface IPlayerPrefabsDate
    {
        void SetCurrentElement(PlayerComponent currentElement);
        PlayerComponent GetCurrentPlayerBase();
        PlayerComponent GetCurrentPlayerBody();
        PlayerComponent GetCurrentPlayerLegs();
    }
}