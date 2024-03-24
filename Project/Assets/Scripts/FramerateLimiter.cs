using UnityEngine;

public class FramerateLimiter : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 60;
    }
}
