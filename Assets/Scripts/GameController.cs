using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;


public class GameController : MonoBehaviour
{

    [SerializeField] private List<CropItem> cropItems;
    [SerializeField] private CropRequirementsHolder cropRequirementsHolder;
    [SerializeField] private GameAchivements gameAchivements;
     private readonly string _gameAchivementsFileName = "GAMECHIVEMENTS";


    private void Start()
    {

        ScoreManager.Instance.CleanScore();
        
        LoadAchivements();

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
       
    }

    private void SaveAchivements()
    {
       FileSaver.Save( _gameAchivementsFileName, gameAchivements);
    }

    private void LoadAchivements()
    {
        gameAchivements = FileSaver.Load<GameAchivements>(_gameAchivementsFileName);

        if (gameAchivements == null)
        {
            gameAchivements = new GameAchivements();
        }
    }
}
