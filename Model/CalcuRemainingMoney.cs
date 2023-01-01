using System;

namespace DrinkMachine.Model
{
    public class CalcuRemainingMoney
    {
        private int remmainingMoney;

        public int AddRemainingMoney(int inMoney)
        {
            return this.remmainingMoney += inMoney;
        }

        public int ResetRemainingMoney()
        {
            this.remmainingMoney = 0;
            return this.remmainingMoney;
        }

        public int RemoveRemainingMoney(int removeMoney)
        {
            if (this.remmainingMoney < removeMoney) throw new Exception("残高不足");
            return this.remmainingMoney -= removeMoney;
        }
    }
}