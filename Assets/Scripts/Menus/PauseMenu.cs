using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void Unpause()
    {
        InGameManager.instance.paused = false;
    }
}
