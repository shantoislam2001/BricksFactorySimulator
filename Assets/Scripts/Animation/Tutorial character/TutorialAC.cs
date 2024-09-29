using UI.Dialogs;
using UnityEngine;

public class TutorialAC : MonoBehaviour
{
    private aiCharacter ai;
    [SerializeField] public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        ai = GetComponent<aiCharacter>();
    }

    public void animate()
    {
        animator.SetBool("walk", true);
    }

    public void warning()
    {
        uDialog.NewDialog()
        .SetTitleText("Warning")
        .SetContentText("Not enough money")
        .SetIcon(eIconType.None)
        .AddButton("Close", (dialog) => dialog.Close());
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
