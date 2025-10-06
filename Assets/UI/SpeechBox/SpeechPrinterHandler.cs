using UnityEngine;
using UnityEngine.InputSystem;

public class SpeechPrinterHandler : MonoBehaviour
{
    public SpeechPrinter a;

    void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            a.PrintText();
        }
    }
}
