using Script.Singleton;
using UnityEngine;

namespace Script.Game
{
    public class ScoreCount : MonoBehaviour
    {
        public int score = 0;
        public GameObject[] allEnemy;

        public void AddScore()
        {
            score++;
        }
    }
}