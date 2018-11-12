using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;

    Base_UIPanel _currentPanel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else { Destroy(this); }
    }

    private void Update()
    {
        if (_currentPanel) _currentPanel.UpdateBehavior();
    }

    public void TriggerPanelTransition(Base_UIPanel panel)
    {
        TriggerOpenPanel(panel);
    }

    void TriggerOpenPanel(Base_UIPanel panel)
    {
        if (_currentPanel != null) TriggerClosePanel(_currentPanel);
        _currentPanel = panel;
        _currentPanel.OpenBehavior();

    }

    void TriggerClosePanel(Base_UIPanel panel)
    {
        panel.CloseBehavior();
    }

}
