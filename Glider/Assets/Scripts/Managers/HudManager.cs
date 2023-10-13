using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

public class HudManager
{
    public Button resetButton;
    public Button debugButton;

    public void Awake()
    {
        resetButton.onClick.AddListener(OnResetClick);
        debugButton.onClick.AddListener(OnDebugClick);
    }

    public void OnResetClick()
    {

    }

    public void OnDebugClick()
    {

    }
}

