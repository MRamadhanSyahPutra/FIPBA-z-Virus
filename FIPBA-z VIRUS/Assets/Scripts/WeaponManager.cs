using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Weapon;

public class WeaponManager : MonoBehaviour
{

    public static WeaponManager Instance { get; private set; }

    public List<GameObject> weaponSlots;

    public GameObject activeWeaponSlot;

    [Header("Ammo")]
    public int totalAK47Ammo = 0;
    public int totalPistolAmmo = 0;

    private Weapon currentWeapon;

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


    private void Start()
    {
        activeWeaponSlot = weaponSlots[0];
    }

    private void Update()
    {
        foreach (GameObject weaponslot in weaponSlots)
        {
            if (weaponslot == activeWeaponSlot)
            {
                weaponslot.SetActive(true);
            }
            else
            {
                weaponslot.SetActive(false);

            }
        }
    }

    public void PickupWeapon(GameObject pickupWeapon)
    {
        AddWeaponIntoActiveSlot(pickupWeapon);
    }

    private void AddWeaponIntoActiveSlot(GameObject pickupWeapon)
    {
        DropCurrentWeapon(pickupWeapon);

        pickupWeapon.transform.SetParent(activeWeaponSlot.transform, false);

        Weapon weapon = pickupWeapon.GetComponent<Weapon>();

        pickupWeapon.transform.localPosition = new Vector3(weapon.spawnPosition.x, weapon.spawnPosition.y, weapon.spawnPosition.z);
        pickupWeapon.transform.localRotation = Quaternion.Euler(weapon.spawnRotation.x, weapon.spawnRotation.y, weapon.spawnRotation.z);

        weapon.isActiveWeapon = true;
        weapon.animator.enabled = true;

        currentWeapon = weapon;
    }

    private void DropCurrentWeapon(GameObject pickupWeapon)
    {
        if (activeWeaponSlot.transform.childCount > 0)
        {
            var weaponDrop = activeWeaponSlot.transform.GetChild(0).gameObject;

            weaponDrop.GetComponent<Weapon>().isActiveWeapon = false;
            weaponDrop.GetComponent<Weapon>().animator.enabled = false;


            weaponDrop.transform.SetParent(pickupWeapon.transform.parent);
            weaponDrop.transform.localPosition = pickupWeapon.transform.localPosition;
            weaponDrop.transform.localRotation = pickupWeapon.transform.localRotation;

            currentWeapon = null;
        }
    }

    internal void PickupAmmo(AmmoBox ammo)
    {
        switch (ammo.ammoType)
        {
            case AmmoBox.AmmoType.PistolAmmo:
                totalPistolAmmo += ammo.ammoAmount;
                break;
            case AmmoBox.AmmoType.Ak47Ammo:
                totalAK47Ammo += ammo.ammoAmount;
                break;

        }
    }

    internal void DecreaseTotalAmmo(int bulletsToDecrease, Weapon.WeaponModel thisWeaponModel)
    {
        switch (thisWeaponModel)
        {
            case Weapon.WeaponModel.Ak47:
                totalAK47Ammo -= bulletsToDecrease;
                break;
            case Weapon.WeaponModel.Pistol:
                totalPistolAmmo -= bulletsToDecrease;
                break;
        }
    }

    public int CheckAmmoLeftFor(Weapon.WeaponModel thisWeaponModel)
    {
        switch (thisWeaponModel)
        {
            case Weapon.WeaponModel.Ak47:
                return totalAK47Ammo;
            case Weapon.WeaponModel.Pistol:
                return totalPistolAmmo;
            default:
                return 0;
        }
    }

    // New method to get the current weapon
    public Weapon GetCurrentWeapon()
    {
        return currentWeapon;
    }
}