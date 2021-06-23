using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipScript : MonoBehaviour {

    public List<WeaponStats> weaponStats = new List<WeaponStats>();
    
    public WeaponBehaviour weaponBehaviour;
    private int weaponIndex = 0;

    void Start () {
        weaponBehaviour = FindObjectOfType<WeaponBehaviour>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("p"))
        {
            SetWeapon();
            weaponIndex++;
        }
	}

    void SetWeapon()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = weaponStats[weaponIndex].weaponVisual;
        weaponStats[weaponIndex].LinkProjectileVisuals(weaponStats[weaponIndex].myattackType);
        weaponBehaviour.animator.speed = weaponStats[weaponIndex].fireRate;
    }
}
