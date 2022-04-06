/**** 
 * Created by: Kameron Eaton
 * Date Created: April 6, 2022
 * 
 * Last Edited by: NA
 * Last Edited: April 6, 2022
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
