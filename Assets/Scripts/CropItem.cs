using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CropItem : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private CropsType type;
    [SerializeField] private int price;
    

    public event Action<CropItem> OnClick;

    private void Start()
    {
        button.onClick.AddListener(Click);
    }

    private void Click()
    {
        OnClick?.Invoke(this);
    }

    public void SetActive(bool isActive)
    {
       gameObject.SetActive(isActive);
    }

    public CropsType GetCropType()
    {
        return type;
    }

    public int GetPrice()
    {
        return price;
    }

}
