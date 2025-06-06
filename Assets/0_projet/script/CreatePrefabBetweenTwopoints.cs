
using UnityEngine;
using UnityEngine.Events;



public class CreatePrefabBetweenTwopoints : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    [SerializeField] Transform m_startPoint;
    [SerializeField] Transform m_endPoint;
    [SerializeField] GameObject m_prefab;
    [SerializeField] UnityEvent <GameObject>m_onInstantiated;
    public void SetPrefabToCreate(GameObject whatToCreate)
    {
        m_prefab = whatToCreate;
    }
    [ContextMenu("Create")]    
    public void InstantiatePrefabInspector()
    {
      
        if (m_prefab == null) return;
        var created = Instantiate(m_prefab);
        Vector3 midPosition = (m_startPoint.position + m_endPoint.position) / 2f;
        created.transform.position = midPosition;
        m_onInstantiated.Invoke(created.gameObject);
        Vector3 up = Vector3.up;
        Vector3 directionX = m_endPoint.position - m_startPoint.position;
        Vector3 forward = Vector3.Cross(directionX, up);
        Quaternion rotation = Quaternion.LookRotation(forward, up);
    }

    public void SetPrefabAndCreate(GameObject prefab)
    {
        SetPrefabToCreate(prefab);
        InstantiatePrefabInspector();
    }
    // Update is called once per frame
    public void killQuickInTenSec(GameObject target)
    {
        if (Application.isPlaying)
        {
            Destroy(target,10);
        }
        else
        {
            DestroyImmediate(target);
        }
    }
    
        
    
}
