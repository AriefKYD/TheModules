using UnityEngine;
using TMPro;
using FallenWing.Core;
namespace FallenWing.Example.Singleton
{
    public class GameManager : BaseSingleton<GameManager>   
    {
        [SerializeField] private PlayerDatas playerData;

        public PlayerDatas PlayerData { get => playerData; private set => playerData = value; }

        public void IncreasePlayerLevel()
        {
            PlayerData.playerLevel++;
            //Notify UIManager via its Singleton
            UIManager.Instance.UpdatePlayerLevel(PlayerData);

        }
    }
}
