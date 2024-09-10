using UnityEngine;

public class uiManager : MonoBehaviour
{
   [SerializeField] public GameObject store;
    [SerializeField] public GameObject soilCoal;
    [SerializeField] public GameObject canvasPlayer;
    [SerializeField] public GameObject canvasList;
    [SerializeField] public GameObject soilList;
    [SerializeField] public GameObject coalList;
    [SerializeField] public GameObject allTruck;
    [SerializeField] public GameObject canvasOffice;
    [SerializeField] public GameObject officePanel;
    [SerializeField] public GameObject dtPanel;
    [SerializeField] public GameObject truckPanel;
    [SerializeField] public GameObject vanPanel;
    [SerializeField] public GameObject createBricks;
    [SerializeField] public GameObject orderList;
    [SerializeField] public GameObject settingsPanel;
    [SerializeField] public GameObject menuPanel;


    public void openStore()
    {

    store.SetActive(true); }

    public void closeStore()
    {
        store.SetActive(false);
    }

    public void openSoilCoal()
    { soilCoal.SetActive(true);
    
    }

    public void closeSoilCoal()
    {
        soilCoal.SetActive(false);

    }
    // Soil list
    public void openSoilList() { 
        canvasList.SetActive(true);
        soilList.SetActive(true);
    }

    public void closeSoilList() { 
        
        soilList.SetActive(false);
        canvasList.SetActive(false);
    }

    public void openCoalList()
    {
        canvasList.SetActive(true);
        coalList.SetActive(true);
    }

    public void closeCoalList()
    {

        coalList.SetActive(false);
        canvasList.SetActive(false);


    }

    public void openAllTruck()
    {
        canvasList.SetActive(true);
        allTruck.SetActive(true);
    }

    public void closeAllTruck()
    {

        allTruck.SetActive(false);
        canvasList.SetActive(false);


    }

    public void openOffice()
    {
        canvasOffice.SetActive(true);
        officePanel.SetActive(true);
    }

    public void openOrderList()
    {
        
        orderList.SetActive(true);
    }

    public void closeOrderList()
    {
        orderList.SetActive(false);
    }


    public void closeOffice()
    {

        officePanel.SetActive(false);
        canvasOffice.SetActive(false);


    }

    public void closeDt()
    {
        dtPanel.SetActive(false);
        canvasOffice.SetActive(false);
    }

    public void closeTruck()
    {
        truckPanel.SetActive(false);
        canvasOffice.SetActive(false);
    }

    public void closeVan()
    {
        vanPanel.SetActive(false);
        canvasOffice.SetActive(false);
    }

    public void openCreateBricks()
    {
        canvasOffice.SetActive(true);
        createBricks.SetActive(true);
    }

    public void closeCreateBricks()
    {
        createBricks.SetActive(false);
        canvasOffice.SetActive(false);
    }

    public void openMenu()
    {
        canvasOffice.SetActive(true);
        menuPanel.SetActive(true);
    }

    public void openSettings()
    {
        canvasOffice.SetActive(true);
        settingsPanel.SetActive(true);
    }

    public void closeMenu()
    {
        menuPanel.SetActive(false);
        canvasOffice.SetActive(false);
    }

    public void closeSettings()
    {
        settingsPanel.SetActive(false);
        canvasOffice.SetActive(false);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
