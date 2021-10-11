using System;
using UnityEngine;
using UnityEngine.UI;

namespace Manager
{
    public class ScoreManager : MonoBehaviour
    {
        #region Singleton
        private static ScoreManager _instance = null;
        public static ScoreManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<ScoreManager>();

                    if (_instance == null)
                    {
                        Debug.LogError("ScoreManager not found!");
                    }
                }

                return _instance;
            }
        }
        #endregion

        public Text scoreText;
        public EnemyManager enemyManager;

        public int boxProgressCheckpoint = 5;
        public int boxProgressIncrement = 1;
        public int enemyProgressCheckpoint = 15;
        public int enemyProgressIncrement = 1;

        private int _currentScore;

        private void Start()
        {
            _currentScore = 0;
            
            enemyManager = EnemyManager.Instance;
        }

        public void AddScore(int amount)
        {
            _currentScore += amount;
            scoreText.text = _currentScore.ToString();

            if (!BoxManager.Instance.progressEnabled)
            {
                return;
            }

            if (_currentScore % boxProgressCheckpoint == 0)
            {
                BoxManager.Instance.IncreaseMax(boxProgressIncrement);
            }

            if (enemyManager == null)
            {
                return;
            }

            if (_currentScore % enemyProgressCheckpoint == 0)
            {
                EnemyManager.Instance.IncreaseMax(enemyProgressIncrement);
            }
        }
    }
}