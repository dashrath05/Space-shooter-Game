using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]private AudioSource explosionSound;
    [SerializeField]private AudioSource powerupSound;
    public bool isExplosion = false;
    public bool isPowerup = false;

    private void Update()
    {
        ExplosionSoundOn();
        PowerupSoundOn();
    }
    private void ExplosionSoundOn()
    {
        if(isExplosion==true)
        {
            explosionSound.Play();
            isExplosion = false;
        }
    }

    private void PowerupSoundOn()
    {
        if (isPowerup == true)
        {
            powerupSound.Play();
            isPowerup = false;
        }
    }

}
