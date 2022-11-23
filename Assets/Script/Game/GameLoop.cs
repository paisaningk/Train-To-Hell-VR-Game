using System;
using Dreamteck.Splines;
using Script.Game;
using Script.Player;
using Script.Sound;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Script.GameLoop
{
    public class GameLoop : MonoBehaviour
    {
        public GameObject mainManu;
        public GameObject endManu;
        public TMP_Text scoreText;
        public Button startGameButton;
        public Button[] quitGameButton;
        public Button restartButton;
        public SplineFollower splineFollower;
        public ScoreCount scoreCount;
        public Controller controller;

        public void Start()
        {
            mainManu.SetActive(true);
            endManu.SetActive(false);
            startGameButton.onClick.AddListener(StartGame);
            restartButton.onClick.AddListener(RestartGame);
            foreach (var variable in quitGameButton)
            {
                variable.onClick.AddListener(QuitGame);
            }

            splineFollower.onEndReached += EndRound;
            
            SoundManager.Instance.Play("Main");
            controller.ChangeController(ControllerType.UI);
        }

        public void Update()
        {
            if (mainManu.activeInHierarchy)
            {
                LookAtPlayer(mainManu);
            }
        }

        private void LookAtPlayer(GameObject gameObject)
        {
            var position = splineFollower.transform.position;
            var newPosition = new Vector3(position.x, gameObject.transform.position.y, position.z);
            gameObject.transform.LookAt(newPosition);
            gameObject.transform.forward *= -1;
        }

        private void StartGame()
        {
            controller.ChangeController(ControllerType.GamePlay);
            SoundManager.Instance.Stop("Main");
            SoundManager.Instance.Play("Song");
            SoundManager.Instance.Play("Train");
            mainManu.SetActive(false);
            splineFollower.follow = true;
        }

        private void EndRound(double obj)
        {
            controller.ChangeController(ControllerType.UI);
            SoundManager.Instance.Play("Main");
            SoundManager.Instance.Stop("Song");
            SoundManager.Instance.Stop("Train");
            endManu.SetActive(true);
            scoreText.text = $"<rainb>Your Score : {scoreCount.score} / {scoreCount.allEnemy.Length}</rainb>";
            splineFollower.follow = false;
        }

        private void RestartGame()
        {
            SceneManager.LoadScene("Scenes/SampleScene");
        }

        private void QuitGame()
        {
            Application.Quit();
        }
    }
}