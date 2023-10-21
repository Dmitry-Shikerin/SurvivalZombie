using Interactions;
using TMPro;
using UnityEngine;

namespace Players.PlayerInteractions
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private GameObject _interactionUI;
        [SerializeField] private TMP_Text _interactionText;

        private bool _isTrigger;
    
        void Start()
        {
            _isTrigger = false;
        }

        void Update()
        {
        
        }
        private void OnTriggerStay(Collider collider)
        {
            _isTrigger = false;
            // _interactionUI.SetActive(_isTrigger);
        
            Debug.Log("столкновение");
        
            if (collider.TryGetComponent(out IInteractible interaction))
            {
                Debug.Log("Интерактивное столкновение");
            
                _isTrigger = true;
                _interactionText.text = interaction.GetDescription();
                // _interactionUI.SetActive(_isTrigger);
    
                if (Input.GetKeyDown(KeyCode.F))
                {
                    interaction.Interact();
                    Debug.Log("Интерактивное действие");
                }
            }
        
            _interactionUI.SetActive(_isTrigger);
        }
    
        private void OnTriggerExit(Collider collider)
        {
            _interactionUI.SetActive(false);
        }
    }
}
