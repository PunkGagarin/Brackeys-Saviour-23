using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    public void Load(int index) {
        SceneManager.LoadScene(index);
    }
}
