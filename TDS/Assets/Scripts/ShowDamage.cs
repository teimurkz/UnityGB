using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDamage : MonoBehaviour
{
    [HideInInspector] public float damage;
    private TextMesh textMesh;
    void Start()
    {
     textMesh = GetComponent<TextMesh>();
     textMesh.text = "-" + damage;
    }

    public void OnAnimationOver()
    {
        Destroy(gameObject);
    }

}
