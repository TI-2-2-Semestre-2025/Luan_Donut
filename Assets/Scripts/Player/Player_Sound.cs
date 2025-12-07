using UnityEngine;

public class Player_Sound : MonoBehaviour
{
    private Player_EntityStats _EntityStats;

    //Music
    public AudioSource MainMusic;

    // Sound Effects
    public AudioSource Footsteps;
    public AudioSource Jump;
    public AudioSource JumpLanding;
    public AudioSource Roll;
    public AudioSource Swipe;
    public AudioSource CoinBonus;
    public AudioSource Hit;
    public AudioSource Coin;

    private void Start()
    {
        _EntityStats = GetComponent<Player_EntityStats>();
        _EntityStats.PlayerSound = this;
    }

    public void ResumeConstantsMusic()
    {
        MainMusic.Play();
        Footsteps.Play();
    }

    public void PauseConstantsSounds()
    {
        MainMusic.Pause();
        Footsteps.Pause();
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

    public void CoinSound()
    {
        Coin.Play();
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
