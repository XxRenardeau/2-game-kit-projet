using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;
using UnityEngine.Events;

public class PresurePadComboCtrl : MonoBehaviour
{
    [SerializeField]
    List<PressurePad> _pressurePadsList;

    public UnityEvent _event;
    bool _eventFired = false;

    // Start is called before the first frame update
    void Start()
    {
        SetEventOnPressedEvent();
    }

    void SetEventOnPressedEvent()
    {
        foreach (var _pad in _pressurePadsList)
        {
            _pad.OnPressed.AddListener(OnPadPressed);
        }
    }

    public void OnPadPressed()
    {
        if (!_allPadsPressed) return;
        if (_eventFired) return;
        _event.Invoke();
        _eventFired = true;
    }

    bool _allPadsPressed
    {
        get
        {
            foreach (var _pad in _pressurePadsList)
            {
                if (!_pad._isPressed) return false;
            }

            return true;
        }
    }

}
