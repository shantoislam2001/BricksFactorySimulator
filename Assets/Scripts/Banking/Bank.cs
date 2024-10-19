using System.Linq.Expressions;
using TMPro;
using UI.Dialogs;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class Bank : MonoBehaviour
{
    [SerializeField] public InputField inputDeposit;
    [SerializeField] public InputField inputWithdraw;
    [SerializeField] public InputField inputLoan;

    [SerializeField] public TextMeshProUGUI currentBalanseText;
    [SerializeField] public TextMeshProUGUI currentWeeklyProfitText;
    [SerializeField] public TextMeshProUGUI maxLoanAmountText;
    [SerializeField] public TextMeshProUGUI currentLoanAmountText;
    [SerializeField] public TextMeshProUGUI installmentText;
    [SerializeField] public GameObject payIteam;
    [SerializeField] public Text payIteamText;


    public int balance = 0;
    public int withdrawBalance = 0;
    public static int weeklyProfit = 0;
    public int depositInputValue = 0;
    public int maxLoanAmount = 0;
    public static int currentLoanAmount = 0;
    public int loanInput = 0;
    public int installment = 0;
    public static int installmentPendingDay = 0;
    public int pendingInstallment = 0;
    public static int day = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputDeposit.onValueChanged.AddListener(OnInputChangeDeposit);
        inputWithdraw.onValueChanged.AddListener(OnInputChangeWithdraw);
        inputLoan.onValueChanged.AddListener(OnInputChangeLoan);
    }

    private void OnInputChangeDeposit(string text)
    {
        if (IsInteger(text))
        {
            depositInputValue = int.Parse(text);
        }
        else
        {
            warning("Please enter number");
        }
    }

    private void OnInputChangeWithdraw(string text)
    {
        if (IsInteger(text))
        {
            withdrawBalance = int.Parse(text);
        }
        else
        {
            warning("Please enter number");
        }
    }

    private void OnInputChangeLoan(string text)
    {
        if (IsInteger(text))
        {
            loanInput = int.Parse(text);
            installment = (loanInput / 100) * 9; 
            installmentText.text = "Installment per day : $"+ FormatCurrency(installment);
        }
        else
        {
            warning("Please enter number");
        }
    }



    #region Deposit

    public void add()
    {
        if (depositInputValue > 5000)
        {
            if (currency.money >= depositInputValue)
            {
                currency.money -= depositInputValue;
                balance += depositInputValue;
                weeklyProfit = (balance / 100) * 6;
                currentBalanseText.text = "Current balance: $" + FormatCurrency(balance);
                currentWeeklyProfitText.text = "Weekly profit: $"+FormatCurrency(weeklyProfit);
                done("You are success");
            }else
            {
                warning("Not enough money");
            }
        }else
        {
            warning("Minimum deposit amount 5000");
        }
    }
    #endregion Deposit



    #region Loan 

    public void loan()
    {
        if(currentLoanAmount == 0)
        {
            if(maxLoanAmount >= loanInput)
            {
                currency.money += loanInput;
                currentLoanAmount = loanInput;
                done("You are success");
                currentLoanAmountText.text ="Current loan amount: $"+ FormatCurrency(currentLoanAmount);
            }
            else
            {
                warning("Please follow the max loan amount");
            }

        }else
        {
            warning("You have already a loan");
        }
    }

    public void closeLoan()
    {
        if(currentLoanAmount > 0)
        {
            if(currency.money >= currentLoanAmount)
            {
                currency.money -= currentLoanAmount;
                currentLoanAmount = 0;
                done("You are success");
                currentLoanAmountText.text = "Current loan amount: $" + FormatCurrency(currentLoanAmount);
            }
            else
            {
                warning("Not enough money");
            }
        }else
        {
            warning("You have no bank loan");
        }
    }

    public void postInstallment()
    {
        if(currentLoanAmount > 0)
        {
            installmentPendingDay++;
            payIteam.SetActive(true);
            pendingInstallment += installment;
            payIteamText.text = "$"+ FormatCurrency(pendingInstallment);

            if(installmentPendingDay > 3)
            {

            }
            
        }   
    }

    public void payInstallment()
    {
        if(currency.money >= pendingInstallment)
        {
            currency.money -= pendingInstallment;
            currentLoanAmount -= pendingInstallment;
            pendingInstallment = 0;
            payIteam.SetActive(false);
            installmentPendingDay = 0;
        }else
        {
            warning("Not enough money");
        }
    }

    public void refreshWithdraw()
    {
        maxLoanAmount = getMaxLoanAmount(levelSystem.level);
        maxLoanAmountText.text = "Max loan amout: $"+ FormatCurrency(maxLoanAmount);
        currentLoanAmountText.text = "Current loan amount: $"+ FormatCurrency(currentLoanAmount);
    }
   

    public int getMaxLoanAmount(int level)
    {
        if(level == 1)
        {
            return 15000;
        }else if(level == 2)
        {
            return 25000;
        }
        else if (level == 3)
        {
            return 35000;
        }
        else if (level == 4)
        {
            return 40000;
        }
        else if (level == 5)
        {
            return 50000;
        }
        else if (level == 6)
        {
            return 70000;
        }
        else if (level == 7)
        {
            return 90000;
        }
        else if (level == 8)
        {
            return 100000;
        }
        else if (level == 9)
        {
            return 120000;
        }
        else if (level == 10)
        {
            return 150000;
        }
        else if (level > 10)
        {
            return 200000;
        }
        return 200000;
    }

    #endregion loan


    #region Withdraw

    public void withdraw()
    {
        if(balance >= withdrawBalance)
        {
            balance -= withdrawBalance;
            currency.money += withdrawBalance;
            weeklyProfit = (balance / 100) * 6;
            currentBalanseText.text = "Current balance: $" + FormatCurrency(balance);
            currentWeeklyProfitText.text = "Weekly profit: $" + FormatCurrency(weeklyProfit);
            done("You are success");
        }
        else
        {
            warning("Not enough money");
        }
    }

    #endregion Withdraw

    public static void sendProfit()
    {
        if (currentLoanAmount > 0)
        {
            installmentPendingDay++;
        }
        if (weeklyProfit > 0)
        {
            day++;
            if(day > 6)
            {
                currency.money += weeklyProfit;
                day = 1;
            }
        }
    }

        // Update is called once per frame
        void Update()
        {

        }

    private bool IsInteger(string input)
    {
        int result;
        return int.TryParse(input, out result);  // Try to parse input as an integer
    }

    public void warning(string s)
    {
        uDialog.NewDialog()
        .SetTitleText("Warning")
        .SetContentText(s)
        .SetIcon(eIconType.Warning)
        .AddButton("Close", (dialog) => dialog.Close());
    }

    public void done(string s)
    {
        uDialog.NewDialog()
        .SetTitleText("Success")
        .SetContentText(s)
        .SetIcon(eIconType.None)
        .AddButton("Close", (dialog) => dialog.Close());
    }

    private string FormatCurrency(int value)
        {
            if (value >= 1000000)
            {
                return (value / 1000000f).ToString("0.0") + "M";
            }
            else if (value >= 1000)
            {
                return (value / 1000f).ToString("0.0") + "k";
            }
            else
            {
                return value.ToString();
            }
        }

    
}
