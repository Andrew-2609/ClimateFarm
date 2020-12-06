using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Velocidade movendo no WASD ou aproximando o mouse das bordas da tela
    public float panSpeed = 10f;
    //Velocidade de arrastar
    public float dragSpeed;
    //Distância da borda para que seja ativado o movimento da câmera
    public float panBorderThickness = 5f;
    //Variável que recebe os valores dos limites das bordas para a câmera
    public Vector2 panLimit;

    void Update()
    {
        Vector3 pos = transform.position;

        //Código responsável por mover a câmera com WASD e se aproximando das bordas da tela
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.y += panSpeed * Time.deltaTime;
        }
        if(Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            pos.y -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if(Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }
        //

        //Código responsável por mover a câmera clicando e arrastando
        if(Input.GetMouseButton(0))
        {
            pos.x -= Input.GetAxis("Mouse X") * dragSpeed * Time.deltaTime;
            pos.y -= Input.GetAxis("Mouse Y") * dragSpeed * Time.deltaTime;
        }
        //

        //Código responsável pelos limites da câmera
        pos.x = Mathf.Clamp(pos.x, 0, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, 0, panLimit.y);
        //

        //Atualização do valor da posição após sua mudança
        transform.position = pos;
    }
}
