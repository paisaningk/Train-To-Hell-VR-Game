using System;
using Dreamteck.Splines;
using Script.Player;
using Script.Sound;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace Script.GameLoop
{
    public class GameLoop : MonoBehaviour
    {
        public GameObject mainManu;
        public GameObject[] npcGameObjects;
        public Button startGameButton;
        public Button quitGameButton;
        public SplineFollower splineFollower;

        public void Start()
        {
            startGameButton.onClick.AddListener(StartGame);
            quitGameButton.onClick.AddListener(QuitGame);
            SoundManager.Instance.Play("Main");
            Controller.Instance.ChangeController(ControllerType.UI);
        }

        public void Update()
        {
            if (mainManu.activeInHierarchy)
            {
                var position = splineFollower.transform.position;
                var newPosition = new Vector3(position.x,mainManu.transform.position.y,position.z);
                mainManu.transform.LookAt(newPosition);
                mainManu.transform.forward *= -1;

                foreach (var variable in npcGameObjects)
                {
                    var transformPosition = splineFollower.transform.position;
                    var worldPosition = new Vector3(transformPosition.x,variable.transform.position.y,transformPosition.z);
                    mainManu.transform.LookAt(worldPosition);
                }
            }
        }

        public void StartGame()
        {
            Controller.Instance.ChangeController(ControllerType.GamePlay);
            Debug.Log("adc");
            SoundManager.Instance.Stop("Main");
            SoundManager.Instance.Play("Song");
            SoundManager.Instance.Play("Train");
            mainManu.SetActive(false);
            splineFollower.follow = true;
        }

        public void EndRound()
        {
            Controller.Instance.ChangeController(ControllerType.UI);
            SoundManager.Instance.Play("Main");
            SoundManager.Instance.Stop("Song");
            SoundManager.Instance.Stop("Train");
            mainManu.SetActive(true);
            splineFollower.follow = false;
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}