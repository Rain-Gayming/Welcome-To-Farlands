using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIToggle : MonoBehaviour
{
    public void ToggleUI(GameObject uiToToggle)
    {
        uiToToggle.SetActive(!uiToToggle.activeInHierarchy);
    }
}
