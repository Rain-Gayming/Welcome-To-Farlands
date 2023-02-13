using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MagazineItemBase : ItemBase
{
    public int maxAmmo;
    public EItemType allowedType;
}

public class MagazineItem : Container
{
    public MagazineItemBase baseMagazine;
    public List<AmmoItem> ammoInMag;

    public MagazineItem(MagazineItemBase basicItem, AmmoItem amount)
    {
        baseMagazine = basicItem;
    }
}