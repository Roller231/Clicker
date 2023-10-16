using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimOnEnable : MonoBehaviour
{
    public void Play()
    {
        GetComponent<Animation>().Play();
    }
}
