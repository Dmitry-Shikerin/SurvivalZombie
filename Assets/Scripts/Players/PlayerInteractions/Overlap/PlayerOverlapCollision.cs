using System;
using Interactions;
using UnityEngine;

namespace Players.PlayerInteractions.Overlap
{
    public class PlayerOverlapCollision : MonoBehaviour
    {
        [Header("Masks")] 
        [SerializeField] private LayerMask _searchLayerMask;
        [SerializeField] private LayerMask _obstacLayerMask;

        [Header("Overlap Area")] 
        [SerializeField] private Transform _overlapStartPoint;

        [SerializeField] private OverlapType _overlapType;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private Vector3 _boxSize = Vector3.one;
        [SerializeField, Min(0f)] private float _sphereRadius = 1f;

        [Header("Obstacles")]
        [SerializeField] private bool _considerObstacles;

        [Header("Gizmos")]
        [SerializeField] private DrawGizmosType _drawGizmosType;
        [SerializeField] private Color _gizmosColor = Color.cyan;

        public event Action<IInteractible> OnInteractibleChanged; 
    
        private readonly Collider[] _overlapResults = new Collider[32];
        private int _overlapResultsCount;

        void Start()
        {
        }

        void Update()
        {
            if (TryFindInteraction())
            {
                // TryInteracted();
                TryInteracted<IInteractible>();
            }
            else
            {
                OnInteractibleChanged?.Invoke(null);
            }
        }

        private bool TryFindInteraction()
        {
            Vector3 position = _overlapStartPoint.TransformPoint(_offset);

            _overlapResultsCount = _overlapType
                switch
                {
                    OverlapType.Box => OverlapBox(position),
                    OverlapType.Sphere => OverlapSphere(position),

                    _ => throw new ArgumentOutOfRangeException(nameof(_overlapType))
                };

            return _overlapResultsCount > 0;
        }

        private int OverlapBox(Vector3 position)
        {
            return Physics.OverlapBoxNonAlloc(position, _boxSize / 2, _overlapResults,
                _overlapStartPoint.rotation, _searchLayerMask.value);
        }

        private int OverlapSphere(Vector3 position)
        {
            return Physics.OverlapSphereNonAlloc(position, _sphereRadius, _overlapResults, _searchLayerMask);
        }

        // скорее всего нужно будет написать дженериковый метод
        // private void TryInteracted()
        // {
        //     for (int i = 0; i < _overlapResultsCount; i++)
        //     {
        //         if (_overlapResults[i].TryGetComponent(out IInteractible interactive) == false)
        //         {
        //             continue;
        //         }
        //
        //         if (_considerObstacles)
        //         {
        //             var startPointPosition = _overlapStartPoint.position;
        //             var colliderPosition = _overlapResults[i].transform.position;
        //             var hasObstacle = Physics.Linecast(startPointPosition, colliderPosition, _obstacLayerMask.value);
        //
        //             if (hasObstacle)
        //             {
        //                 continue;
        //             }
        //         }
        //         
        //         OnInteractibleChanged?.Invoke(interactive);
        //         
        //         //нужно поправить 
        //         if (Input.GetKeyDown(KeyCode.F))
        //             interactive.Interact();
        //     }
        // }
    
        private void TryInteracted<T>() where T : IInteractible
        {
            for (int i = 0; i < _overlapResultsCount; i++)
            {
                if (_overlapResults[i].TryGetComponent(out T interactive) == false)
                {
                    continue;
                }

                if (_considerObstacles)
                {
                    var startPointPosition = _overlapStartPoint.position;
                    var colliderPosition = _overlapResults[i].transform.position;
                    var hasObstacle = Physics.Linecast(startPointPosition, colliderPosition, _obstacLayerMask.value);

                    if (hasObstacle)
                    {
                        continue;
                    }
                }
            
                OnInteractibleChanged?.Invoke(interactive);
            
                //нужно поправить 
                if (Input.GetKeyDown(KeyCode.F))
                    interactive.Interact();
            }
        }


        #region DrawGizmos

        private void OnDrawGizmos()
        {
            TryDrawGizmos(DrawGizmosType.Always);
        }

        private void OnDrawGizmosSelected()
        {
            TryDrawGizmos(DrawGizmosType.OnSelected);
        }

        private void TryDrawGizmos(DrawGizmosType requiredType)
        {
            if (_drawGizmosType != requiredType)
                return;

            if (_overlapStartPoint == null)
                return;

            Gizmos.matrix = _overlapStartPoint.localToWorldMatrix;
            Gizmos.color = _gizmosColor;

            switch (_overlapType)
            {
                case OverlapType.Box:
                    Gizmos.DrawCube(_offset, _boxSize);
                    break;

                case OverlapType.Sphere:
                    Gizmos.DrawSphere(_offset, -_sphereRadius);
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(_overlapType));
            }
        }

        #endregion
    }
}