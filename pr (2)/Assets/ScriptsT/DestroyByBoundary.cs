using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            other.gameObject.SetActive(false);
        }

      else  if (other.gameObject.tag == "Enemy")
        {
            return;
        }
      else  if (other.gameObject.tag == "Player")
        {
            return;
        }
        else
        {
            Destroy(other.gameObject);
        }

    }


}
