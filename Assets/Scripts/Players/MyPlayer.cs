using Interactions;
using UnityEngine;

namespace Players
{
    public class MyPlayer : MonoBehaviour
    {
        [SerializeField] private float _distance;
        [SerializeField] private Transform _gizmos;
        [SerializeField] private SphereCollider _sphereCollider;

        // private SphereCollider _sphereCollider;

    
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        
            // Ray ray;

            // _sphereCollider.Raycast(ray, out RaycastHit hit, _distance);
        
            // _gizmos = Gizmos.DrawSphere(_gizmos.transform.position, 2);
            // Physics.OverlapSphere()

        
        
            if (_sphereCollider.TryGetComponent(out IInteractible interaction))
            {
                Debug.Log("Интерактивное столкновение");
            }
            
        }

        private void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out IInteractible interactible))
            {
                Debug.Log("Интерактивное столкновение");

            }
        }
    }
}
