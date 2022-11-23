using System;
using System.Linq;
using Script.Singleton;
using UnityEngine;

namespace Script.Player
{
    public class Controller : Singleton<Controller>
    {
        [SerializeField]private ControllerData[] controllerDataSet;

        public void ChangeController(ControllerType type)
        {
            foreach (var data in controllerDataSet)
            {
                foreach (var controllerGameObject in data.controllerGameObjects)
                {
                    controllerGameObject.SetActive(false);
                }
            }
            var controllerData = controllerDataSet.FirstOrDefault(data => data.controllerType == type);

            if (controllerData != null)
            {
                foreach (var variable in controllerData.controllerGameObjects)
                {
                    variable.SetActive(true);
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