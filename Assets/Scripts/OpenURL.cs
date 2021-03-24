using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURL : MonoBehaviour
{

    public void OpenBoidWebsite()
    {
        Application.OpenURL("https://www.boid.com/");
    }
    public void OpenBlockbaseWebsite()
    {
        Application.OpenURL("https://www.blockbase.network/");
    }

}
