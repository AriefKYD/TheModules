using UnityEngine;
using TMPro;
using FallenWing.Core;
namespace FallenWing.Example.Singleton
{
    public class UIManager : BaseSingleton<UIManager>
    {
        [SerializeField] private TextMeshProUGUI t_playerLevel;

        private void Start()
        {
            UpdatePlayerLevel(GameManager.Instance.PlayerData);
        }
        public void UpdatePlayerLevel(PlayerDatas _playerData)
        {
            t_playerLevel.SetText($"Player {_playerData.playerName}\nLevel {_playerData.playerLevel}");
        }
    }
}
