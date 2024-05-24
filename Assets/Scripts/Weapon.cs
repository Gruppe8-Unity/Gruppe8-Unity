using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public void DetermineWeaponDestroy(float weaponLifeTime)
    {
        if (weaponLifeTime< 0)
        {
            Destroy(gameObject);
        }
    }

    public float DecrementWeaponLifeTime(float weaponLifeTime)
    {
        return weaponLifeTime -= Time.deltaTime;
    }
}
