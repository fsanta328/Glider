using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject glider;
    public Transform startPosition;

    public LevelManager()
    {

    }

    public void ResetGlider()
    {
    }

    public void StartLevel()
    {
        // spawn/release glider?
        glider.SetActive(true);
    }
}
