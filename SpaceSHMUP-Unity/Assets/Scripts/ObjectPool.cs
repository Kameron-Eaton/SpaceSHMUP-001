/**** 
 * Created by: Kameron Eaton
 * Date Created: April 6, 2022
 * 
 * Last Edited by: NA
 * Last Edited: April 11, 2022
 * 
 * Description: Create a pool of objects for reuse
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    /***Variables***/
    static public ObjectPool POOL;

    #region Pool Singleton
    void CheckPoolIsInScene()
    {
        if(POOL == null)
        {
            POOL = this;
        }
        else
        {
            Debug.LogError("POOL.Awake() - Attempted to assign a second ObjectPool.POOL");
        }
    }//end CheckPoolIsInScene
    #endregion

    private Queue<GameObject> projectiles = new Queue<GameObject>(); //new queue of projectiles

    [Header("Pool Settings")]
    public GameObject projectilePrefab;
    public int poolStartSize = 5;

    /***Methods***/

    private void Awake()
    {
        CheckPoolIsInScene();
    }//end Awake()

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < poolStartSize; i++)
        {
            GameObject projectileGO = Instantiate(projectilePrefab); //create prefab instance
            projectiles.Enqueue(projectileGO); //add to queue
            projectileGO.SetActive(false); //hide projectile
        }//end for(int i = 0; i < poolStartSize; i++)
    }//end Start

    public GameObject GetObject()
    {
        if(projectiles.Count > 0)
        {
            GameObject gObject = projectiles.Dequeue(); //remove from queue
            gObject.SetActive(true); //enable
            return gObject; //return object
        }
        else
        {
            Debug.LogWarning("Out of objects, reloading...");
            return null; //return null
        }//end if (projectiles.Count > 0)
    }//end GetObject

    public void ReturnObject(GameObject gObject)
    {
        projectiles.Enqueue(gObject); //add back to queue
        gObject.SetActive(false); //disable
    }//end ReturnProjectile

    // Update is called once per frame
    void Update()
    {
        
    }//end Update
}
