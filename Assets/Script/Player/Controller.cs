using System;
using System.Collections.Generic;
using System.Linq;
using Script.Singleton;
using UnityEngine;

namespace Script.Player
{
    public class Controller : MonoBehaviour
    {
        [SerializeField]private ControllerData[] controllerDataSet;
        public List<GameObject> controller;
        public Transform spawnPoint;

        public void ChangeController(ControllerType type)
        {
            switch (type)
            {
                case ControllerType.UI:
                    IsTypeUI();
                    break;
                case ControllerType.GamePlay:
                    IsTypeGamePlay();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private void IsTypeUI()
        {
            foreach (var controllerData in controllerDataSet)
            {
                if (controllerData.controllerType == ControllerType.GamePlay)
                {
                    foreach (var variable in controllerData.controllerGameObjects)
                    {
                        variable.SetActive(false);
                    }
                }
            }

            var ui = controllerDataSet.FirstOrDefault(data => data.controllerType == ControllerType.UI);

            if (ui == null) return;
            {
                foreach (var variable in ui.controllerGameObjects)
                {
                    var instantiate = Instantiate(variable, spawnPoint);
                    instantiate.SetActive(true);
                    controller.Add(instantiate);
                }
            }
        }

        private void IsTypeGamePlay()
        {
            foreach (var variable in controller)
            {
                DestroyImmediate(variable);
            }
            controller.Clear();
            
            foreach (var controllerData in controllerDataSet)
            {
                if (controllerData.controllerType == ControllerType.GamePlay)
                {
                    foreach (var variable in controllerData.controllerGameObjects)
                    {
                        variable.SetActive(true);
                    }
                }
            }
        }
    }

    [Serializable]
    public class ControllerData
    {
        public GameObject[] controllerGameObjects;
        public ControllerType controllerType;
    }

    public enum ControllerType
    {
        UI,
        GamePlay
    }
}