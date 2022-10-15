using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoMagazine
{
    int ammoNumber = 0;

    public bool IsAmmo()
    {
        return ammoNumber > 0;
    }

    public int GetAmmoNumber()
    {
        return ammoNumber;
    }

    public void UseAmmo()
    {
        ammoNumber--;
    }

    public void AddAmmo(int ammoNumber)
    {
        this.ammoNumber += ammoNumber;
    }

}
