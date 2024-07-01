using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] Transform player;

    public Vector3 offset;
    private void Start()
    {
        offset = transform.position - player.position; 

    }
    
    private void Update()
    {
        Vector3 targetPos = player.position + offset;
        targetPos.x = 0;
        transform.position = targetPos;

    }
}
