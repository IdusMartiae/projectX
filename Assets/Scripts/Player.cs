using UnityEngine;

public class Player : MonoBehaviour
{
    
    private void Update()
    {

    }
    
    /*private void GetDirectionFromPlane()
   {
       
           var forwardDirection = (hitPoint - transform.position).normalized;
           forwardDirection.y = 0;
           //Debug.Log($"Mouse position:{Input.mousePosition}; Current forward {transform.forward}; New forward {forwardDirection}");
           transform.forward = Vector3.RotateTowards(transform.forward,
               forwardDirection,
               Time.deltaTime * playerSpeed,
               0);
       }
   }*/

}