using System;
using System.Collections.Generic;
using Script.Enemy;
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
        [SerializeField] private GunComponent leftGunComponents;
        [SerializeField] private GunComponent rightGunComponents;
        [SerializeField] private LayerMask shootLayerMask;

        // Start is called before the first frame update
        private void Start()
        {
            vrInputActions = new XRIDefaultInputActions();
            vrInputActions.Enable();
            vrInputActions.XRILeftHandInteraction.Activate.started += context => Shoot(leftGunComponents);
            vrInputActions.XRIRightHandInteraction.Activate.started += context => Shoot(rightGunComponents);
        }

        private void OnValidate()
        {
            DrawLineBothHand();
        }

        private void Update()
        {
            DrawLineBothHand();
        }

        private void Shoot(GunComponent gunComponent)
        {
            Debug.Log("Shoot");
            
            gunComponent.shootSource.Play();
            
            Ray ray = new Ray(gunComponent.startPositionLine.position,gunComponent.startPositionLine.forward);
                
            if (Physics.Raycast(ray, out RaycastHit raycastHit, 15, shootLayerMask))
            {
                if (raycastHit.collider.TryGetComponent(out EnemyData enemyData ))
                {
                    enemyData.DoDamage();
                    Debug.Log(enemyData.name);
                }
            }
        }

        private void DrawLineBothHand()
        {
            DrawLine(leftGunComponents);
            DrawLine(rightGunComponents);
        }

        private void DrawLine(GunComponent gunComponent)
        {
            var startPosition = gunComponent.gunLineRenderer.transform.position;
            gunComponent.gunLineRenderer.SetPosition(0, startPosition);
            gunComponent.gunLineRenderer.SetPosition(1, startPosition + (gunComponent.startPositionLine.forward * 15));
        }
    }

    [Serializable]
    public struct GunComponent
    {
        public LineRenderer gunLineRenderer;
        public Transform startPositionLine;
        public AudioSource shootSource;
    }
}
