using UnityEngine;

public class TutorialAC : MonoBehaviour
{
    [SerializeField] public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            Debug.Log("a clicked");
            animator.SetBool("walk", true);
        } else
        {
            animator.SetBool("walk", false);
        }
    }
}
