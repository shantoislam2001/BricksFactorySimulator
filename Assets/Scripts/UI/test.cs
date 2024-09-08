using UnityEngine;
using UI.Dialogs;

public class test : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShowSimpleDialog();
    }

    public void ShowSimpleDialog()
    {
        uDialog.NewDialog()
        .SetTitleText("Simple Message Dialog")
        .SetContentText("This is a simple Message Dialog")
        .SetIcon(eIconType.Warning)
        .AddButton("Close", (dialog) => dialog.Close());
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
