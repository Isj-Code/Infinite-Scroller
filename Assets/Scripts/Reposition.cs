using UnityEngine;

public class Reposition : MonoBehaviour
{
    private float spriteWidth;
    void Start()
    {
        // Obtencion del ancho del sprite
        spriteWidth = GetComponent<SpriteRenderer>().size.x;
    }

    void Update()
    {
        // Cuando la position es menor de -20 se reposiciona
        if(transform.position.x < -spriteWidth)
        {
            // Movemos el componente a la derecha del otro
            transform.Translate(2 * spriteWidth * Vector2.right);
        }
    }
}
