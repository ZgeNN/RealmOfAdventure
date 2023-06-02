using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatValue : ScriptableObject,ISerializationCallbackReceiver
{
    public float initialValue;
    public float RuntimeValue;

    public void OnAfterDeserialize()
    {
        RuntimeValue = initialValue;
    }

    public void OnBeforeSerialize(){}//oyunda öldükten sonra can 0 da kalıyordu çözümü chatgptden buldum
}
