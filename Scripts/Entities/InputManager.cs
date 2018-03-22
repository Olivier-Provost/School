using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerController))]
public class InputManager : MonoBehaviour
{

    List<KeyToEventPair> keyEventList = new List<KeyToEventPair>();
    PlayerController pc;
    void Start()
    {
        pc = GetComponent<PlayerController>();
        keyEventList.Add(new KeyToEventPair("Horizontal", pc.HorizontalPressed));
        keyEventList.Add(new KeyToEventPair("Vertical", pc.VerticalPressed));
        keyEventList.Add(new KeyToEventPair("Rotation", pc.RotationPressed));
        keyEventList.Add(new KeyToEventPair("Thrusters", pc.Thrusters));
    }

    

    void Update()
    {
        foreach(KeyToEventPair kv in keyEventList)
        {
            try
            {
                float result = Input.GetAxis(kv.axisName);
                if (result != 0)
                    kv.floatEvent.Invoke(result);
            }
            catch
            {
                Debug.LogError("Error for key event pair axis: " + kv.axisName);
            }
        }
    }

    [System.Serializable]
    public class KeyToEventPair
    {
        public string axisName;
        public FloatEvent floatEvent;

        public KeyToEventPair(string _axisName, params UnityAction<float>[] _floatAction)
        {
            axisName = _axisName;
            floatEvent = new FloatEvent();
            foreach(UnityAction<float> ua in _floatAction)
                floatEvent.AddListener(ua);
        }

    }

    [System.Serializable]
    public class FloatEvent : UnityEvent<float>
    {

    }


}
