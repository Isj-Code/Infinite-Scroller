using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float upForce;

    private float yInput;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Obtencion de datos de inputs
        yInput = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        // -- Físicas -- 
        // Añadir fuerza vertical con el imput (-1, 0, 1)
        // Si le damos al boton de arriba se multiplica por 1, sin darle
        // se multiplica por 0 y abajo por -1
        // rb.AddForce(new Vector2(0f, upForce * yInput));
        // La forma de arriba y abajo son iguales.
        rb.AddForce(Vector2.up * upForce * yInput);
    }
}
