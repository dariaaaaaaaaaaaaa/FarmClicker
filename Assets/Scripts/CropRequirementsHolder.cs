using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CropRequirementsHolder 
{
   [SerializeField] private List<CropReqirement> cropReqirements;

    private CropReqirement FindCropsType(CropsType cropsType)
    {
        foreach (CropReqirement crop in cropReqirements)
        {
            if (cropsType == crop.cropsType)
            {
                return crop;
            }
        }
        return null;
    }


}
