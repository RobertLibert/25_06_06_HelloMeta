using Eloi.Draw;
using UnityEngine;

public class MAPremiereLigne : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
 
    public Vector3 m_direction;
    public Color m_color;
    public float m_duration = 3;
    public Transform m_canonDirection;
    public Transform m_canonToMove;
    public Transform m_canonToMove2;
    public float m_leftRightAngle;
    public float m_downTopAngle;
    public float m_maxVerticalAngle;
    // Update is called once per frame
    void Update()
    {
        if (m_downTopAngle < 0) m_downTopAngle = 0;
        if(m_downTopAngle< m_maxVerticalAngle) m_downTopAngle = m_maxVerticalAngle;
        Debug.DrawLine(Vector3.zero, m_direction,m_color, m_duration);    
        Debug.DrawRay(Vector3.zero, new Vector3(1,0,0), Color.red, Time.deltaTime);
        Debug.DrawRay(Vector3.zero, new Vector3(1, 0, 0), Color.green, Time.deltaTime);
        Debug.DrawRay(Vector3.zero, new Vector3(1, 0, 0), Color.blue, Time.deltaTime);
        Vector3 startOfTheCanon = m_canonDirection.position;
        Vector3 endOfTheCanon = startOfTheCanon + m_direction;
        Debug.DrawLine(startOfTheCanon, endOfTheCanon, m_color, Time.deltaTime);
        Quaternion horizontalRotation = Quaternion.Euler(0f,m_leftRightAngle,0f);
        Quaternion verticalRotation = Quaternion.Euler(-m_downTopAngle,0f,0f);
        Quaternion finalRotation =( m_canonDirection.rotation * horizontalRotation) * verticalRotation;
        
        m_canonToMove.rotation = finalRotation;
        
        
    }

    
}
