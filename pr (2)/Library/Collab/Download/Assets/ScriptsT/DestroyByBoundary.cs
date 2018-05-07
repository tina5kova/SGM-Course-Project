using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

    
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag=="Bullet")
        {
            gameObject.SetActive(false);
        }
        else{
 Destroy(other.gameObject);
        }
        
    }
    

}
