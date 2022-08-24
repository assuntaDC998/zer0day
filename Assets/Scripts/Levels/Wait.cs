using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wait : MonoBehaviour
{

    public float time = 5f;

    void Start()
    {
        StartCoroutine(WaitForIntro());
    }

    IEnumerator WaitForIntro() {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene((int)ScenesIndex.MAIN_MENU);
      }

}
