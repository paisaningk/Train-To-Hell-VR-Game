using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

namespace Script
{
    public class Gun : MonoBehaviour
    {
        public XRIDefaultInputActions vrInputActions;

        public TMP_Text text;
        // Start is called before the first frame update
        private void Start()
        {
            vrInputActions = new XRIDefaultInputActions();
            vrInputActions.Enable();
            vrInputActions.XRILeftHandInteraction.Activate.started += context => ADC();
            vrInputActions.XRIRightHandInteraction.Activate.started += context => ADC();
        }

        // Update is called once per frame
        private void Update()
        {
        
        }

        private void ADC()
        {
            Debug.Log("adx");
        }
    }
}
