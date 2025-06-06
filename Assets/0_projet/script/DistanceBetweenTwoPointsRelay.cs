using UnityEngine;
using UnityEngine.Events;

namespace Robert

{
    public class DistanceBetweenTwoPointsRelay : MonoBehaviour
    {
        [SerializeField]  Transform m_leftHand;
        [SerializeField]  Transform m_rightHand;
        [SerializeField]  float m_distanceBetween;
        [SerializeField]  UnityEvent<float> m_onDistanceChanged;
        private void OnValidate()
        {
            updatePosition();
        }
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void updatePosition()
        {
            var distance = Vector3.Distance(m_leftHand.position, m_rightHand.position);
            if (distance != m_distanceBetween)
            {
                m_distanceBetween = distance;
                m_onDistanceChanged.Invoke(distance);
            }
            //ajouter les autres primitives
            
        }

        // Update is called once per frame
        void Update()
        {
            updatePosition();

        }
    }
}