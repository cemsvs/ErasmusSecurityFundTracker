using System;
using System.Collections.Generic;
using SaveSystemFramework.Core;

namespace ErasmusBudgetTracker
{
    [Serializable]
    public class ErasmusData : SaveData
    {
        public decimal TargetBudget { get; set; } = 3000;
        public decimal CurrentBalance { get; set; } = 0;

        public List<string> TransactionHistory { get; set; }

        public ErasmusData() : base() // Framework'ün temel ayarlarını (Tarih vs.) yükle
        {
            TransactionHistory = new List<string>();

            // Senin Framework'ünde "GameVersion" var, biz bunu "AppVersion" gibi kullanalım.
            this.GameVersion = "1.0.0";
        }
    }
}