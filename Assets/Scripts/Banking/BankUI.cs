using UnityEngine;

public class BankUI : MonoBehaviour
{
    [SerializeField] public GameObject inputDeposit;
    [SerializeField] public GameObject inputWithdraw;
    [SerializeField] public GameObject inputLoan;
    [SerializeField] public GameObject add;
    [SerializeField] public GameObject get;
    [SerializeField] public GameObject getLoan;
    [SerializeField] public GameObject closeLoan;
    [SerializeField] public GameObject currentBalance;
    [SerializeField] public GameObject currentLoanAmount;
    [SerializeField] public GameObject installment;
    [SerializeField] public GameObject weeklyProfit;
    [SerializeField] public GameObject text1Deposit;
    [SerializeField] public GameObject text2Deposit;
    [SerializeField] public GameObject canvasOffice;
    [SerializeField] public GameObject bankPanel;
    [SerializeField] public GameObject maxLoanAmount;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void deposit()
    {
        inputDeposit.SetActive(true);
        inputWithdraw.SetActive(false);
        inputLoan.SetActive(false);
        add.SetActive(true);
        get.SetActive(false);
        getLoan.SetActive(false);
        closeLoan.SetActive(false);
        currentBalance.SetActive(true);
        currentLoanAmount.SetActive(false);
        installment.SetActive(false);
        weeklyProfit.SetActive(true);
        text1Deposit.SetActive(true);
        text2Deposit.SetActive(true);
        maxLoanAmount.SetActive(false);
    }


    public void withdraw()
    {
        inputDeposit.SetActive(false);
        inputWithdraw.SetActive(true);
        inputLoan.SetActive(false);
        add.SetActive(false);
        get.SetActive(true);
        getLoan.SetActive(false);
        closeLoan.SetActive(false);
        currentBalance.SetActive(true);
        currentLoanAmount.SetActive(false);
        installment.SetActive(false);
        weeklyProfit.SetActive(false);
        text1Deposit.SetActive(false);
        text2Deposit.SetActive(false);
        maxLoanAmount.SetActive(false);
    }


    public void loan()
    {
        inputDeposit.SetActive(false);
        inputWithdraw.SetActive(false);
        inputLoan.SetActive(true);
        add.SetActive(false);
        get.SetActive(false);
        getLoan.SetActive(true);
        closeLoan.SetActive(true);
        currentBalance.SetActive(false);
        currentLoanAmount.SetActive(true);
        installment.SetActive(true);
        weeklyProfit.SetActive(false);
        text1Deposit.SetActive(false);
        text2Deposit.SetActive(false);
        maxLoanAmount.SetActive(true);
    }

    public void close()
    {
        bankPanel.SetActive(false);
        canvasOffice.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
