/**** 
 * Created by: Kameron Eaton
 * Date Created: April 6, 2022
 * 
 * Last Edited by: NA
 * Last Edited: April 11, 2022
 * 
 * Description: Behavior for the projectiles
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    /***Variables***/
    private BoundsCheck bndCheck; //reference to the boundary

    void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();   
    }//end Awake

    void Update()
    {
        if (bndCheck.offUp)
        {
            gameObject.SetActive(false); //set the projectile to deactivate and return to pool
            bndCheck.offUp = false; //reset the BoundsCheck offUp boolean
        }//end if(bndCheck.offUp)
    }//end Update
}//end Projectile
