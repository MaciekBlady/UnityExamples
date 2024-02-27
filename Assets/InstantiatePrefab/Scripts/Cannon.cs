using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    // This is a reference to an asset, not necessarily an object in the scene!
    // To fill out just drag and drop a prefab with "Projectile" component
    [SerializeField]
    private Projectile m_Projectile;
    
    // Queue is a collection (just like List) - you can put elements at the end of the queue with Enqueue method, and remove first element with Dequeue
    private Queue<Projectile> m_InstantiatedProjectiles = new Queue<Projectile>();

    private void Start()
    {
        StartCoroutine(ShootRepeating(1.0f));
    }

    // Shoot every 'delay' seconds
    private IEnumerator ShootRepeating(float delay)
    {
        // This will go on forever! 
        while (true) 
        {
            // Wait for 'delay' amount of seconds
            yield return new WaitForSeconds(delay);

            // Shoot!
            Shoot();

            //... Repeat!
        }
    }

    void Shoot()
    {
        Vector3 positionToSpawnPrefabIn = transform.position;
        Quaternion rotationOfTheSpawnedPrefab = transform.rotation;

        // 'Instantiate' creates an instance of the prefab in the scene
        Projectile projectileInstance = Instantiate<Projectile>(m_Projectile, positionToSpawnPrefabIn, rotationOfTheSpawnedPrefab);

        // If you pass transform as parameter, instantiated prefab will become parent of the Cannon
        //Projectile projectileInstance = Instantiate<Projectile>(m_Projectile, transform);

        m_InstantiatedProjectiles.Enqueue(projectileInstance);

        // If we have more than 3 projectiles, destroy the last one that was shot!
        if (m_InstantiatedProjectiles.Count > 3)
        {
            Projectile projectileOverTheLimit = m_InstantiatedProjectiles.Dequeue();
            Destroy(projectileOverTheLimit.gameObject);
        }
    }
}
