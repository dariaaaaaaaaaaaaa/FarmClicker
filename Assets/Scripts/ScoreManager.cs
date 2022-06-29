using System.Collections;
using System;
using UnityEngine;

using TMPro;



    public class ScoreManager : MonoBehaviour, IScore
    {
        public static ScoreManager Instance { get; private set;}

        private const string SaveScoreKey = "HIGHT_SCORE_SAVE_NUMBER";

        private int number;
        


        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            LoadScore();
        }

        public void AddScore(int add)
        {
            number += add;
            SaveScore();
        }


        public void RemoveScore(int remove)
        {
            number -= remove;
            SaveScore();
        }

        public int GetScore()
        {
            return number;
        }


        private void SaveScore()
        {
            PlayerPrefs.SetInt(SaveScoreKey, number);
        }

        private void LoadScore()
        {
            number = PlayerPrefs.GetInt(SaveScoreKey);
        }

        public void CleanScore()
        {
            number = 0;
            SaveScore();
        }


    }


