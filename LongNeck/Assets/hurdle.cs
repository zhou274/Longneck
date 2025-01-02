


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurdle : MonoBehaviour
{
    // Start is called before the first frame update
     bool isAdshow=false;
void Start()
{
 
isAdshow=false;
}
        public void OnTriggerEnter(Collider other)
    {
          if( other.tag=="head" || other.tag=="ring")
         {
            RingPicUp._RingPicUp.WrongRingPicUp();
             StartCoroutine(LevelFail());
         }
    }
     public  IEnumerator LevelFail()
    { if(!isAdshow)
        {
isAdshow=true;
 Debug.Log("ads");
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(uicontrol._uicontrol.LosePanel());
    }
    }
}
