using System.Collections;
using UnityEngine;

public class MoveTurrets : MonoBehaviour
{
    private Camera mainCamera;

    private bool isEnabled = true;

    private void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        StartCoroutine(ScriptEnable());
    }

    private void OnMouseDrag()
    {
        if (isEnabled) 
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = mainCamera.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }
    }

    private IEnumerator ScriptEnable() 
    {
        while (true) 
        {
            yield return new WaitForSeconds(10f);
            isEnabled = false;
            yield break;
        }
    }
}
