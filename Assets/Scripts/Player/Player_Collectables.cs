using System;
using UnityEngine;

public class Player_Collectables : MonoBehaviour
{
    private Player_EntityStats _playerEntityStats;
    
    private void Start()
    {
        _playerEntityStats = GetComponent<Player_EntityStats>();
        _playerEntityStats.PlayerCollectables = this;
    }

    public void AddLife()
    {
        if (_playerEntityStats.hp < 3)
        {
            Game_Manager.Instance.UI_HUD.AddHeart();
            _playerEntityStats.hp++;
        }
    }

    public void AddCoin(int value)
    {
        _playerEntityStats.coins += value;
        Game_Manager.Instance.UI_HUD.ChangeCoinValue(_playerEntityStats.coins);
    }
}
