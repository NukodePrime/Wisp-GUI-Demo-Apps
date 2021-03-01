using UnityEngine;

public class WispTabViewDemo : MonoBehaviour
{
    [Header("Pages")]
    [SerializeField] WispScrollView welcomeScrollView;
    [SerializeField] WispScrollView componentScrollView;

    [Header("Styles")]
    [SerializeField] WispGuiStyle style1;
    [SerializeField] WispGuiStyle style2;
    [SerializeField] WispGuiStyle style3;
    [SerializeField] WispGuiStyle style4;
    [SerializeField] WispGuiStyle style5;
    [SerializeField] WispGuiStyle style6;
    [SerializeField] WispGuiStyle style7;
    [SerializeField] WispGuiStyle style8;
    [SerializeField] WispGuiStyle style9;
    [SerializeField] WispGuiStyle style10;

    private WispTabView tabView;
    private WispMessageBox messageBox;
    
    // Start is called before the first frame update
    void Start()
    {
        tabView = GetComponent<WispTabView>();

        // Welcome Page
        WispPage welcomePage = tabView.AddPage("welcome", "Welcome !", false);
        welcomeScrollView.gameObject.SetActive(true);
        welcomeScrollView.SetParent(welcomePage, true, true);
        welcomeScrollView.AnchorStyleExpanded(true);

        // Component preview page
        WispPage componentPage = tabView.AddPage("component", "Components preview", false);
        componentScrollView.gameObject.SetActive(true);
        componentScrollView.SetParent(componentPage, true, true);
        componentScrollView.AnchorStyleExpanded(true);
        
        WispAnimationGlow anim = componentPage.TabButton.gameObject.AddComponent<WispAnimationGlow>();
        anim.Duration = 2f;
        componentPage.TabButton.Button.AddOnClickAction(delegate{Destroy(anim);});

        tabView.ShowPage(welcomePage.PageID);

        tabView.AddCornerButtonClickEvent
        (
            delegate 
            { 
                messageBox = WispMessageBox.OpenTwoButtonsDialog("Would you like to quit this demo ?", "Yes", Quit, "No", CloseMsgBox);
            }
        );
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
            SetGuiStyle(style1);
        else if (Input.GetKeyDown(KeyCode.F2))
            SetGuiStyle(style2);
        else if (Input.GetKeyDown(KeyCode.F3))
            SetGuiStyle(style3);
        else if (Input.GetKeyDown(KeyCode.F4))
            SetGuiStyle(style4);
        else if (Input.GetKeyDown(KeyCode.F5))
            SetGuiStyle(style5);
        else if (Input.GetKeyDown(KeyCode.F6))
            SetGuiStyle(style6);
        else if (Input.GetKeyDown(KeyCode.F7))
            SetGuiStyle(style7);
        else if (Input.GetKeyDown(KeyCode.F8))
            SetGuiStyle(style8);
        else if (Input.GetKeyDown(KeyCode.F9))
            SetGuiStyle(style9);
        else if (Input.GetKeyDown(KeyCode.F10))
            SetGuiStyle(style10);
    }

    private void Quit()
    {
        #if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false;
         #else
         Application.Quit();
         #endif
    }

    private void CloseMsgBox()
    {
        messageBox.Close();
    }

    private void SetGuiStyle(WispGuiStyle ParamStyle)
    {
        tabView.Style = ParamStyle;
    }
}