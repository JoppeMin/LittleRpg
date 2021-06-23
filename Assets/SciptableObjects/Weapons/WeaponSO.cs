using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Weapon", menuName = "ScriptableObjects/Equipable/Weapon")]
public class WeaponSO : ScriptableObject
{
    [Range(1, 10)]
    public int attackSpeed;

    [Range(1, 10)]
    public int projectileSpeed;
    [Range(1, 10)]
    public int projectileDistance;
    [Range(1, 10)]
    public int projectileDamage;

    public Sprite idleSprite;
    public Sprite slashSprite;
    public GameObject projectile;
}
