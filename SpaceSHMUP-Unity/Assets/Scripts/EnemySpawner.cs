/**** 
 * Created by: Kameron Eaton
 * Date Created: April 5, 2022
 * 
 * Last Edited by: NA
 * Last Edited: April 6, 2022
 * 
 * Description: Spawns enemies within boundary
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    /*** VARIABLES ***/
    [Header("Enemy settings")]
    public GameObject[] prefabEnemies; //array of all enemy prefabs
    public float enemySpawnPerSecond; //enemy count to spawn per second
    public float enemyDefaultPadding; //padding position of each enemy

    private BoundsCheck bndCheck; //reference to the bounds check component

    void Start()
    {
        bndCheck = GetComponent<BoundsCheck>(); //reference to BoundsCheck component
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond); //call SpawnEnemy method after time delay
    }//end Start

    void SpawnEnemy()
    {
        //pick a random enemy to instantiate
        int ndx = Random.Range(0, prefabEnemies.Length);

        GameObject go = Instantiate<GameObject>(prefabEnemies[ndx]);

        //position enemy above the screen with random x position
        float enemyPadding = enemyDefaultPadding;

        if(go.GetComponent<BoundsCheck>() != null)
        {
            enemyPadding = Mathf.Abs(go.GetComponent<BoundsCheck>().radius);
        }

        //set the initial position
        Vector3 pos = Vector3.zero;
        float xMin = -bndCheck.camWidth + enemyPadding;
        float xMax = bndCheck.camWidth - enemyPadding;

        pos.x = Random.Range(xMin, xMax); //range between the xmin and xmax
        pos.y = bndCheck.camHeight + enemyPadding; //height plus padding, off
        go.transform.position = pos;

        //invoke again
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
    }//end SpawnEnemy
}//end EnemySpawner
