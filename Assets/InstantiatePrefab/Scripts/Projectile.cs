using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float m_Speed = 10.0f;

    void Update()
    {
        // Every frame move forward by speed scaled by delta time (so every second we move by m_Speed amount of units)
        transform.Translate(transform.forward * m_Speed * Time.deltaTime);    
    }
}
