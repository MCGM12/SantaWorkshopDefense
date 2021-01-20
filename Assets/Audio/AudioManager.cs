using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource Click;
    public AudioSource Shoot;
    public AudioSource Die;

    public void PlayClick()
    {
        Click.Play();
    } 
    public void PlayShoot()
    {
        Shoot.Play();
    } 
    public void PlayDie()
    {
        Die.Play();
    }
}
