using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;


public class GameController : MonoBehaviour
{

    [SerializeField] private List<CropItem> cropItems;
     private GameAchivements _gameAchivements;
     private readonly string _gameAchivementsFileName = "GAMECHIVEMENTS";


    private void Start()
    {
        LoadAchivements();

        if (_gameAchivements == null)
        {
            _gameAchivements = new GameAchivements();
        }
        //_gameAchivements = _gameAchivements ?? new GameAchivements();

        foreach (var cropItem in cropItems)
        {
            cropItem.SetActive(true);
            cropItem.OnClick += OnCropsButton;
        }
    }

    private void OnDestroy()
    {
        SaveAchivements();
    }

    private void OnCropsButton(CropItem cropItem)
    {
        ScoreManager.Instance.AddScore(cropItem.GetPrice());
       print(ScoreManager.Instance.GetScore());
       // moneyText = (ScoreManager.Instance.GetScore());
    }

    private void SaveAchivements()
    {
       FileSaver.Save( _gameAchivementsFileName, _gameAchivements);
    }

    private void LoadAchivements()
    {
       _gameAchivements =  FileSaver.Load<GameAchivements>(_gameAchivementsFileName );
       
    }
}
