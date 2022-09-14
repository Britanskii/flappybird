using System;
using Bird;
using UnityEngine;
using UnityEngine.Events;

namespace Bird
{
    [RequireComponent(typeof(Mover))]
    public class Bird : MonoBehaviour
    {
        private Mover _mover;
        private int _score;

        public event UnityAction<int> ScoreChanged; 
        public event UnityAction GameOver; 

        public void IncreaseScore()
        {
            _score++;
            ScoreChanged?.Invoke(_score);
        }
        
        public void ResetPlayer()
        {
            _score = 0;
            ScoreChanged?.Invoke(_score);
            _mover.ResetBird();
        }

        public void Die()
        {
            GameOver?.Invoke();
        }
        
        private void Start()
        {
            _mover = GetComponent<Mover>();
        }
    }
}
