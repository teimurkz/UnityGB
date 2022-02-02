using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChanger : MonoBehaviour
{
    [SerializeField] private Texture2D cursorDefult;
    [SerializeField] private Texture2D cursorChange;
    void Start()
    {
        Cursor.SetCursor(cursorDefult, Vector2.zero, CursorMode.ForceSoftware);            
    }

    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursorChange, Vector2.zero, CursorMode.ForceSoftware);            
    }

    private  void OnMouseExit()
    {
        Cursor.SetCursor(cursorDefult, Vector2.zero, CursorMode.ForceSoftware);            
    }
}
