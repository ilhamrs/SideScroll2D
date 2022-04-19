using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private float ammoTotal;
    private float currentAmmo;
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = ammoTotal;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getAmmoCrate()
    {
        currentAmmo = Mathf.Clamp(currentAmmo + 25, 0, ammoTotal);
    }

    public void fireAmmo()
    {
        currentAmmo = Mathf.Clamp(currentAmmo - 1, 0, ammoTotal);
    }
    public float getCurrentAmmo()
    {
        return currentAmmo;
    }

    public float getAmmoTotal()
    {
        return ammoTotal;
    }
}
