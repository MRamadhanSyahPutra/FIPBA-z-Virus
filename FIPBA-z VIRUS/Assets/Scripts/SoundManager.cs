using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Weapon;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; set; }

    //Shooting
    [Header("Shooting")]
    public AudioSource ShootingChannel;
    public AudioClip PistolShot;
    public AudioClip Ak47Shot;


    //Reloading
    [Header("Reloading")]
    public AudioSource reloadingSoundAk47;
    public AudioSource reloadingSoundPistol;

    [Header("Empty Magazine")]
    public AudioSource emptyMagazineSoundAk47;

    [Header("Zombie")]
    public AudioClip zombieWalking;
    public AudioClip zombieChese;
    public AudioClip zombieAttack;
    public AudioClip zombieHurt;
    public AudioClip zombieDeath;

    public AudioSource zombieChannel1;
    public AudioSource zombieChannel2;

    [Header("Player")]
    public AudioClip playerHurt;
    public AudioClip playerDie;
    public AudioSource playerChannel;

    public AudioClip gameOverMusic;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void PlayShootingSound(WeaponModel weapon)
    {
        switch (weapon)
        {
            case WeaponModel.Pistol:
                ShootingChannel.PlayOneShot(PistolShot);
                break;
            case WeaponModel.Ak47:
                ShootingChannel.PlayOneShot(Ak47Shot);
                break;
        }
    }
    public void PlayReloadSound(WeaponModel weapon)
    {
        switch (weapon)
        {
            case WeaponModel.Pistol:
                reloadingSoundPistol.Play();
                break;
            case WeaponModel.Ak47:
                reloadingSoundAk47.Play();
                break;
        }
    }
}
