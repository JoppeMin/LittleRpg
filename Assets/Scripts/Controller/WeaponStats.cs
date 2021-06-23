using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponStats{

    public int itemID;

    public string itemName;
    public Sprite weaponVisual;

    public float damage;
    public float fireRate;
    public float range;
    public float projectileSpeed;

    public enum attackType
    {
        Sword,
        Recoil,
        Heavy,
        Thump,
        Beam
    }
    public attackType myattackType;

    public void LinkProjectileVisuals(attackType myAttackType)
    {
        //je moet de prefab editen en de player animation aanpassen
        //GameObject.FindObjectOfType<WeaponBehaviour>().animator.s = (Animation)Resources.Load("Animation/Animations" + myAttackType.ToString() + "Attack")
        //Slash = Resources.Load("Art/" + myAttackType.ToString());
        //Animation attackAnimation = Resources.Load("Animation/Animations" + myAttackType.ToString() + "Attack");
    }
}


