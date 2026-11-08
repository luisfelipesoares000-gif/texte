using UnityEngine;

public class ControleDoOri : MonoBehaviour
{
    // Variáveis configuráveis no painel da Unity
    public float velocidade = 8f;
    public float forcaDoPulo = 12f;
    
    private Rigidbody2D rb;
    private float movimentoHorizontal;
    private bool estaNoChao;

    void Start()
    {
        // Pega o componente de física do personagem
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Detecta comandos do teclado ou controle (A/D ou Setas)
        movimentoHorizontal = Input.GetAxisRaw("Horizontal");

        // Se pressionar o botão de pulo e estiver no chão, pula
        if (Input.GetButtonDown("Jump") && estaNoChao)
        {
            rb.velocity = new Vector2(rb.velocity.x, forcaDoPulo);
            estaNoChao = false; 
        }
    }

    void FixedUpdate()
    {
        // Aplica o movimento físico de andar para a esquerda ou direita
        rb.velocity = new Vector2(movimentoHorizontal * velocidade, rb.velocity.y);
    }

    // Detecta se o Ori colidiu de volta com o chão
    private void OnCollisionEnter2D(Collision2D colissao)
    {
        if (colissao.gameObject.CompareTag("Chao"))
        {
            estaNoChao = true;
        }
    }
}
