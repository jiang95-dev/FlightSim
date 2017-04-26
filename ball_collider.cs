using UnityEngine;
using System.Collections;

public class ball_collider : MonoBehaviour
{
    float start = 0;
    float end = 5;

    public void disappear()
    {
        gameObject.SetActive(false);
        Invoke("wakeup", 5f);
    }

    public void wakeup()
    {
        gameObject.SetActive(true);
    }
}