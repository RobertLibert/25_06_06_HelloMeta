using UnityEngine;
using UnityEngine.Events;

namespace Robert
{
    public class PrimitiToString : MonoBehaviour
    {
        [SerializeField] UnityEvent<string> m_onRelay;
        [SerializeField] string m_format = "{0}";
        public void Relay(string relay)
        {
            m_onRelay.Invoke(relay);
        }
        public void Relay(float toRelay)
        {
            m_onRelay.Invoke(string.Format(m_format, toRelay));
        }

        
    }
}