using UnityEngine;

public class Player_Sound : MonoBehaviour
{
    private Player_EntityStats _EntityStats;

    public AudioSource Jump;
    public AudioSource JumpLanding;
    public AudioSource Roll;
    public AudioSource Swipe;
    public AudioSource CoinBonus;
    public AudioSource Hit;

    private void Start()
    {
        _EntityStats = GetComponent<Player_EntityStats>();
        _EntityStats.PlayerSound = this;
    }

    public void JumpSound()
    {
        Jump.Play();
    }

    public void JumpLandingSound()
    {
        JumpLanding.Play();
    }

    public void RollSound()
    {
        Roll.Play(); 
    }

    public void SwipeSound()
    {
        Swipe.Play();
    }

    public void HitSoundPlay()
    {
        Hit.Play();
    }

    public void CoinBonusSoundPlay()
    {
        CoinBonus.Play();
    }
    public void CoinBonusSoundStop()
    {
        CoinBonus.Stop();
    }

    public void ChangeCoinBonusVolume(float value)
    {
        CoinBonus.volume = value * 0.4f;
    }
}
