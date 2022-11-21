using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

namespace Script
{
    public class GunController : MonoBehaviour
    {
        private XRIDefaultInputActions vrInputActions;
        [SerializeField] private List<GunComponent> gunComponents;

        // Start is called before the first frame update
        private void Start()
        {
            vrInputActions = new XRIDefaultInputActions();
            vrInputActions.Enable();
            vrInputActions.XRILeftHandInteraction.Activate.started += context => ADC();
            vrInputActions.XRIRightHandInteraction.Activate.started += context => ADC();
        }

        private void OnValidate()
        {
            // foreach (var gunComponent in gunComponents)
            // {
            //     var startPosition = gunComponent.startPositionLine.position;
            //     gunComponent.gunLineRenderer.SetPosition(0, startPosition);
            //     gunComponent.gunLineRenderer.SetPosition(0, startPosition + 
            //                                                 (gunComponent.startPositionLine.forward * 5));
            // }
        }

        // Update is called once per frame
        private void Update()
        {
            foreach (var gunComponent in gunComponents)
            {
                var startPosition = gunComponent.gunLineRenderer.transform.position;
                gunComponent.gunLineRenderer.SetPosition(0, startPosition);
                gunComponent.gunLineRenderer.SetPosition(0, startPosition + 
                                                            (gunComponent.startPositionLine.forward * 5));
            }
        }

        [Button]
        public void Kay()
        {
            
        }

        private void ADC()
        {
            Debug.Log("adx");
        }
    }

    [Serializable]
    public struct GunComponent
    {
        public LineRenderer gunLineRenderer;
        public Transform startPositionLine;
    }
}
