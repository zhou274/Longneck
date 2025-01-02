


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diamondCollect : MonoBehaviour
{
    public GameObject ringCountAnim;
        public void OnTriggerEnter(Collider other)
    {
         if(other.tag=="stickmanbody")
         {
             PlayerPrefs.SetInt("Diamond",PlayerPrefs.GetInt("Diamond")+1);
            StartCoroutine(ringCountAni());
        //   Gamemanager._Gamemanager.DiamondTxt.text=Gamemanager._Gamemanager.diamond.ToString("");
         
         }
    }
     public IEnumerator ringCountAni()
     {

        ringCountAnim.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        ringCountAnim.SetActive(false);
          this.gameObject.SetActive(false);
     }
}
