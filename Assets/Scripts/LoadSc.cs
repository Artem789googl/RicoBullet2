using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSc : MonoBehaviour
{
    public void Load(int s)
    {
        SceneManager.LoadScene(s);
    }
}
