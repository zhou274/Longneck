


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         
    }
   public void PlayBtn()
   {
      SceneManager.LoadScene(2);
   }
}
