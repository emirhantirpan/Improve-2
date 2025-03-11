using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Renderer ren;
    private void OnMouseEnter()
    {
        ren.material.color = Color.red;
    }
    private void OnMouseExit()
    {
        ren.material.color = Color.white;
    }
}
