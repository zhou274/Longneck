


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    // Start is called before the first frame update
         bool isAdshow=false;
void Start()
{
 
isAdshow=false;
}
  public void OnTriggerEnter(Collider other)
    {
         if(other.tag=="stickmanbody" || other.tag=="head" || other.tag=="ring")
         {
             StartCoroutine(PlayerRotate());
                if(!isAdshow)
         {
             isAdshow=true;

             StartCoroutine(uicontrol._uicontrol.WinPanel());
         }
         }
    }
      public  IEnumerator PlayerRotate()
    {
          playerMove._playerMove.PlayerAnim.SetBool("isRotate",true);
       yield return new WaitForSeconds(1.0f);
       playerMove._playerMove.PlayerAnim.enabled=false;
        // Time.timeScale=0;
    }
}
