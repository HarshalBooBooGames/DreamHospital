using UnityEngine;

public class HandMove : MonoBehaviour
{
    Animation anim;
    [SerializeField] GameObject normalHand, downHand;

    private void Start()
    {
        anim = GetComponent<Animation>();
    }

    public void Update()
    { 
        if(Input.GetMouseButtonDown(0))
        {
            normalHand.SetActive(false);
            downHand.SetActive(true);
            transform.localScale = Vector3.one * 0.9f;
        }
        Vector3 mousePos = Input.mousePosition;
        transform.position = mousePos;
        if(Input.GetMouseButtonUp(0)) 
        {
            normalHand.SetActive(true);
            downHand.SetActive(false);
            transform.localScale = Vector3.one;
        }
    }
}
