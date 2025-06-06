using UnityEngine;

using System.Collections.Generic;

using UnityEngine.Events;
[System.Serializable]
public class RangeToCreatePrefab
{
    public float m_minRange;  
    public float m_maxRange;
    public GameObject m_prefab;
    
}
public class LoadPrefabFromDistance : MonoBehaviour
{
    [SerializeField] private float m_distance;
    public List<RangeToCreatePrefab> m_listOfPrefabs;
    public UnityEvent<GameObject>m_onPrefabRangeFound;
    public GameObject m_lastPush;
    public void SetDistance(float distance)
    {
        m_distance = distance;  
        
    }
    [ContextMenu("TryToCreatePrefab")]
    public void tryToCreateInRange()
    {
        foreach (var item in m_listOfPrefabs)
        {
            if (item == null) continue;
            if (m_distance <item.m_minRange ) continue;
            if (m_distance > item.m_maxRange ) continue;
            m_onPrefabRangeFound.Invoke(item.m_prefab);
            m_lastPush =item.m_prefab;
            
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
