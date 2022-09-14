using System;
using DefaultNamespace.UI;
using Pipe;
using UnityEngine;

namespace DefaultNamespace
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Bird.Bird _bird;
        [SerializeField] private PipeGenerator _pipeGenerator;
        [SerializeField] private StartScreen _startScreen;
        [SerializeField] private OverScreen _overScreen;

        private void OnEnable()
        {
            _startScreen.PlayButtonClick += OnPlayButtonClick;
            _overScreen.RestartButtonClick += OnRestartButtonClick;
            _bird.GameOver += OnGameOver;
        }

        private void OnDisable()
        {
            _startScreen.PlayButtonClick -= OnPlayButtonClick;
            _overScreen.RestartButtonClick -= OnRestartButtonClick;
            _bird.GameOver -= OnGameOver;
        }

        private void OnPlayButtonClick()
        {
            _startScreen.Close();
            StartGame();
        }

        private void OnRestartButtonClick()
        {
            _overScreen.Close();
            _pipeGenerator.ResetPool();
            StartGame();
        }

        private void StartGame()
        {
            Time.timeScale = 1;
            _bird.ResetPlayer();
        }

        private void OnGameOver()
        {
            Time.timeScale = 0;
            _overScreen.Open();
        }

        private void Start()
        {
            Time.timeScale = 0;
            _startScreen.Open();
        }
    }
}