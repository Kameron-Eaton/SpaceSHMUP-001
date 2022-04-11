/**** 
 * Created by: Kameron Eaton
 * Date Created: April 11, 2022
 * 
 * Last Edited by: NA
 * Last Edited: April 11, 2022
 * 
 * Description: Returns objects to the object pool
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolReturn : MonoBehaviour
{

    private ObjectPool pool;
    void Start()
    {
        pool = ObjectPool.POOL; //find the object pool
    }//end Start

    private void OnDisable()
    {
        //if the pool is not empty
        if(pool != null)
        {
            pool.ReturnObject(this.gameObject); //return to pool
        }//end if(pool != null)
    }//end OnDisable

}//end PoolReturn
