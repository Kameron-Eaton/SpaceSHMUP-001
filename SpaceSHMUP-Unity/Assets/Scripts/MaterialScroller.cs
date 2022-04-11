/**** 
 * Created by: Kameron Eaton
 * Date Created: April 11, 2022
 * 
 * Last Edited by: NA
 * Last Edited: April 11, 2022
 * 
 * Description: Scrolls background material
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialScroller : MonoBehaviour
{
    public Vector2 scrollSpeed = new Vector2(0, 0f); //x and y speed for scroll

    private Renderer goRenderer; //game object renderer
    private Material goMat; //game object material

    private Vector2 offset; //offset of scroll

    private void Start()
    {
        goRenderer = GetComponent<Renderer>();
        goMat = goRenderer.material;
    }//end Start

    private void Update()
    {
        offset = (scrollSpeed * Time.deltaTime); //set offset value over time
        goMat.mainTextureOffset += offset; //set texture offset
    }//end Update
}
