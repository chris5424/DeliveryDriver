using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32 (1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32 (1,1,1,1);

    bool hasPackage = false;

    SpriteRenderer spriteRenderer;

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
            Debug.Log("Kolizja");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Zebrano paczkę.");
            hasPackage = true;
            Destroy(other.gameObject, 0);
            spriteRenderer.color = hasPackageColor;
        }
        else if (other.tag == "Finish" && hasPackage)
        {
            Debug.Log("Dostarczono paczkę.");
            spriteRenderer.color = noPackageColor;
            hasPackage = false;
        }
    }
}
