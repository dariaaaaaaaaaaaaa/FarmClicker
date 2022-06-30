using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class GameAchivements 
{
    [SerializeField] private List<CropAchivement> cropsAchivements;


    public CropAchivement GetCrop (CropsType cropsType)
    {
        foreach (CropAchivement crop in cropsAchivements)
        {
            if (crop.type == cropsType)
            {
                return crop;
            }
        }
        return null;
    }
}
