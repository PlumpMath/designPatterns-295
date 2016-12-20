using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoanLending.Observers;
using LoanLending.DataSets;

namespace LoanLending.Domain
{
    abstract class Loan
    {
        protected string loanId;
        protected decimal loanAmount;
        protected double interestRate;
        protected int term;
        protected decimal amountToPay;
        protected int monthsPayed = 0;
        protected List<ILoanObserver> observers = new List<ILoanObserver>();

        public string loanIdProperty { get { return loanId; } }
        public double interestRateProperty { get { return interestRate; } }

        public Loan(string loanId, decimal loanAmount, int term, double interestRate)
        {
            this.loanId = loanId;
            this.loanAmount = loanAmount;
            this.term = term;
            this.interestRate = interestRate;
            for(int i = 1; i <= term; i++)
            {
                amountToPay += getMonthPayment(i);
            }
        }

        public abstract decimal getMonthPayment(int month);

        public void ChangeInterestRate(double newInterestRate)
        {
            this.interestRate = newInterestRate;
            decimal oldAmountToPay = amountToPay;
            amountToPay = 0;
            for(int i = monthsPayed+1; i <= term; i++)
            {
                amountToPay += getMonthPayment(i);
            }
            NotifyObservers(oldAmountToPay - amountToPay);
        }

        public void AddObserver(ILoanObserver observer)
        {
            observers.Add(observer);
        }

        public void Pay()
        {
            decimal change = getMonthPayment(monthsPayed + 1);
            if (monthsPayed + 1 >= term)
                change = 0;
            else
            {
                amountToPay -= change;
                monthsPayed++;
            }
           
            NotifyObservers(change);
        }

        private void NotifyObservers(decimal change)
        {
            LoanValues values = GetValues();
            values.amountChange = change;

            foreach(ILoanObserver observer in observers)
            {
                observer.Notify(values);
            }
        }

        public void SetLoanValues(double interestRate, decimal amountToPay, int monthsPayed)
        {
            decimal oldAmountToPay = this.amountToPay;
            this.interestRate = interestRate;
            this.amountToPay = amountToPay;
            this.monthsPayed = monthsPayed;
            NotifyObservers(oldAmountToPay - amountToPay);
        }

        public LoanValues GetValues()
        {
            LoanValues values = new LoanValues();
            values.amountToPay = amountToPay;
            values.interestRate = interestRate;
            values.loanAmount = loanAmount;
            values.loanId = loanId;
            values.term = term;
            values.monthsPayed = monthsPayed;
            values.amountChange = -amountToPay;
            return values;
        }

    }
}
