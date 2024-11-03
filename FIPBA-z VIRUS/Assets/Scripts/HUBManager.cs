using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Weapon;

public class HUBManager : MonoBehaviour
{
    public static HUBManager Instance { get; set; }

    [Header("Ammo")]
    public TextMeshProUGUI magazineAmmoUI;
    public TextMeshProUGUI totalAmmoUI;
    public Image ammoTypeUI;

    [Header("Weapon")]
    public Image activeWeaponUI;
    public Image unActiveWeaponUI;

    // [Header("Throwables")]
    // public Image lethalUI;
    // public TextMeshProUGUI lethalAmountUI;

    // public Image tacticalUI;
    // public TextMeshProUGUI tacticalAmountUI;

    public Sprite emptySlot;

    public GameObject middleDot;

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

    private void Update()
    {
        Weapon activeWeapon = WeaponManager.Instance.activeWeaponSlot.GetComponentInChildren<Weapon>();
        // Weapon unActiveWeapon = GetUnActiveWeaponSlot().GetComponentInChildren<Weapon>();

        Weapon unActiveWeapon = null;
        GameObject unActiveWeaponSlot = GetUnActiveWeaponSlot();

        if (unActiveWeaponSlot != null)
        {
            unActiveWeapon = unActiveWeaponSlot.GetComponentInChildren<Weapon>();
        }

        if (activeWeapon)
        {
            magazineAmmoUI.text = $"{activeWeapon.bulletsLeft / activeWeapon.bulletsPerBurst}";
            totalAmmoUI.text = $"{WeaponManager.Instance.CheckAmmoLeftFor(activeWeapon.thisWeaponModel)}";

            Weapon.WeaponModel model = activeWeapon.thisWeaponModel;
            ammoTypeUI.sprite = GetAmmoSprite(model);

            activeWeaponUI.sprite = GetWeaponSprite(model);

            if (unActiveWeapon)
            {
                unActiveWeaponUI.sprite = GetWeaponSprite(unActiveWeapon.thisWeaponModel);
            }
        }
        else
        {
            magazineAmmoUI.text = "";
            totalAmmoUI.text = "";

            ammoTypeUI.sprite = emptySlot;

            activeWeaponUI.sprite = emptySlot;
            unActiveWeaponUI.sprite = emptySlot;
        }
    }

    private Sprite GetWeaponSprite(Weapon.WeaponModel model)
    {
        GameObject weaponPrefab = null;
        switch (model)
        {
            case Weapon.WeaponModel.Pistol:
                weaponPrefab = Resources.Load<GameObject>("Pistol_Weapon");
                break;

            case Weapon.WeaponModel.Ak47:
                weaponPrefab = Resources.Load<GameObject>("AK47_Weapon");
                break;
        }

        if (weaponPrefab != null)
        {
            // Ambil komponen SpriteRenderer dari prefab tanpa melakukan instantiate
            SpriteRenderer spriteRenderer = weaponPrefab.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                return spriteRenderer.sprite; // Mengambil sprite dari SpriteRenderer
            }
        }

        Debug.LogError("Weapon prefab or sprite not found.");
        return null;
    }

    private Sprite GetAmmoSprite(Weapon.WeaponModel model)
    {
        GameObject ammoPrefab = null;
        switch (model)
        {
            case Weapon.WeaponModel.Pistol:
                ammoPrefab = Resources.Load<GameObject>("Pistol_Ammo");
                break;

            case Weapon.WeaponModel.Ak47:
                ammoPrefab = Resources.Load<GameObject>("AK47_Ammo");
                break;
        }

        if (ammoPrefab != null)
        {
            // Ambil komponen SpriteRenderer dari prefab tanpa melakukan instantiate
            SpriteRenderer spriteRenderer = ammoPrefab.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                return spriteRenderer.sprite; // Mengambil sprite dari SpriteRenderer
            }
        }

        Debug.LogError("Ammo prefab or sprite not found.");
        return null;
    }

    private GameObject GetUnActiveWeaponSlot()
    {
        foreach (GameObject weaponSlot in WeaponManager.Instance.weaponSlots)
        {
            if (weaponSlot != WeaponManager.Instance.activeWeaponSlot)
            {
                return weaponSlot;
            }
        }

        return null;
    }
}
