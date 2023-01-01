using System;
using System.Windows;
using DrinkMachine.Model;
using Prism.Mvvm;
using Reactive.Bindings;

namespace DrinkMachine.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        #region タイトル

        private string _title = "Prism Application";
        public string Title
        {
            get { return this._title; }
            set { this.SetProperty(ref this._title, value); }
        }

        #endregion　タイトル

        #region 定数

        private static readonly string upperRowImagePath = "C:\\Users\\user\\Desktop\\MyProject\\DrinkMachine\\Resources\\UpperRowImage.png";
        private static readonly string lowerRowImagePath = "C:\\Users\\user\\Desktop\\MyProject\\DrinkMachine\\Resources\\LowerRowImage.png";
        private static readonly string cocaColaImagePath = "C:\\Users\\user\\Desktop\\MyProject\\DrinkMachine\\Resources\\CocaCola.png";

        #endregion

        #region フィールド・プロパティ

        public CalcuRemainingMoney calcuRemainingMoney;

        public ReactiveProperty<string> InputAmount { get; set; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> RemainingMoney { get; set; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> Change { get; set; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> UpperRowImagePath { get; set; } = new ReactiveProperty<string>(upperRowImagePath);
        public ReactiveProperty<string> LowerRowImagePath { get; set; } = new ReactiveProperty<string>(lowerRowImagePath);
        public ReactiveProperty<string> CocaColaImagePath { get; set; } = new ReactiveProperty<string>(cocaColaImagePath);
        
        public ReactiveCommand InMoneyCommand { get; } = new ReactiveCommand();
        public ReactiveCommand ResetMoneyCommand { get; } = new ReactiveCommand();
        public ReactiveCommand BuyCommand { get; } = new ReactiveCommand();

        # endregion フィールド・プロパティ

        #region コンストラクタ

        public MainWindowViewModel()
        {
            this.calcuRemainingMoney = new CalcuRemainingMoney();
            this.RemainingMoney.Value = "0";

            this.InMoneyCommand.Subscribe(this.InMoneyCommandClicked);
            this.ResetMoneyCommand.Subscribe(this.ResetMoneyCommandClicked);
            this.BuyCommand.Subscribe(this.BuyCommandClicked);
        }

        #endregion　コンストラクタ

        #region メソッド

        /// <summary>金額決定ボタン押下時の処理</summary>
        private void InMoneyCommandClicked()
        {
            if (this.InputAmount.Value == null)
            {
                MessageBox.Show("金額を設定して下さい");
                return;
            }
            
            // 残高を計算して返却するクラスメソッドを呼び出す
            var culcResult = this.calcuRemainingMoney.AddRemainingMoney(int.Parse(this.InputAmount.Value));

            // 残高が決まったら、残高表示ラベルに表示する
            this.RemainingMoney.Value = culcResult.ToString();
        }

        /// <summary>お釣り取出ボタン押下時の処理</summary>
        private void ResetMoneyCommandClicked()
        {
            var culcResult = this.calcuRemainingMoney.ResetRemainingMoney();

            this.Change.Value = this.RemainingMoney.Value;
            this.RemainingMoney.Value = culcResult.ToString();
        }

        /// <summary>お釣り取出ボタン押下時の処理</summary>
        private void BuyCommandClicked(object drinkPrice)
        {
            try
            {
                var culcResult = this.calcuRemainingMoney.RemoveRemainingMoney(int.Parse((string)drinkPrice));

                this.RemainingMoney.Value = culcResult.ToString();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        #endregion　メソッド
    }
}
