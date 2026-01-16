using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public void ChangeColor(Renderer renderer)
    {
        var newColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        renderer.material.color = newColor;
    }
}
