using System.Collections;
using TMPro;
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
        if (_playerEntityStats.hp < _playerEntityStats.maxHp)
        {
            Game_Manager.Instance.UI_HUD.AddHeart();
            _playerEntityStats.hp++;
        }
    }

    public void AddCoin(int value)
    {
        _playerEntityStats.coins += value;
        Game_Manager.Instance.UI_HUD.ChangeCoinValue((float)_playerEntityStats.coins / _playerEntityStats.coinsToBonus);

        float percentage = ((float)_playerEntityStats.coins / (float)_playerEntityStats.coinsToBonus);
        if (_playerEntityStats.coins == _playerEntityStats.coinsToBonus) CoinBonus();
    }

    private void CoinBonus()
    {
        int sec = _playerEntityStats.coinsBonusSeconds;
        
        Game_Manager.Instance.UI_HUD.ChangeCoinValue(1, true, _playerEntityStats.coinsBonusSeconds);
        Immortal(sec);
        StartCoroutine(I_CoinBonus(sec));
    }

    private IEnumerator I_CoinBonus(int sec)
    {
        Camera cam = Camera.main.GetComponent<Camera>();
        float defSpeed = _playerEntityStats.speed;
        float defFOV = 60;
        float speedGainMultiplier = 4;
        float FOVGainMultiplier = 2;
        float secElapsed = 0;
        float gainSpeedTime = 2;
        float looseSpeedTime = 2;

        _playerEntityStats.PlayerSound.CoinBonusSoundPlay();
        while (secElapsed <= gainSpeedTime)
        {
            _playerEntityStats.speed += (defSpeed * (speedGainMultiplier-1) * (Time.deltaTime/gainSpeedTime));
            cam.fieldOfView += (defFOV * (FOVGainMultiplier-1) * (Time.deltaTime/gainSpeedTime));
            secElapsed += Time.deltaTime;
            _playerEntityStats.PlayerSound.ChangeCoinBonusVolume(secElapsed/gainSpeedTime);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(sec - gainSpeedTime - looseSpeedTime);
        secElapsed = 0f;
        while (secElapsed <= looseSpeedTime)
        {
            _playerEntityStats.speed -= (defSpeed * (speedGainMultiplier-1) * (Time.deltaTime/looseSpeedTime));
            cam.fieldOfView -= (defFOV * (FOVGainMultiplier-1) * (Time.deltaTime/looseSpeedTime));
            secElapsed += Time.deltaTime;
            _playerEntityStats.PlayerSound.ChangeCoinBonusVolume(1 - (secElapsed / looseSpeedTime));
            yield return new WaitForEndOfFrame();
        }

        _playerEntityStats.speed = defSpeed;
        cam.fieldOfView = defFOV;
        _playerEntityStats.coins = 0;
        Game_Manager.Instance.UI_HUD.ChangeCoinValue(0);

        _playerEntityStats.PlayerSound.ChangeCoinBonusVolume(0);
        _playerEntityStats.PlayerSound.CoinBonusSoundStop();

    }

    public void Immortal(int sec)
    {
        StartCoroutine(I_Immortal(sec));
    }

    IEnumerator I_Immortal(int sec)
    {
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Obstacles"), true);
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Collectables"), true);
        yield return new WaitForSeconds(sec);
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Obstacles"), false);
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Collectables"), false);
    }

}
