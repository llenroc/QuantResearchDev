﻿using Microsoft.WindowsAzure.Storage.Table;
using Moon.Data.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moon.Data.Model
{
    public interface IPair 
    {
        string Name { get; set; }
        string Exchanger { get; set; }
        DateTime CollectedDate { get; set; }
        Dictionary<string, dynamic> Properties { get; set; }
        Trady.Core.Candle Candle { get;set; }
    }
    public class BinanceCandle : TableEntity,IPair,IRoot
    {
        
        public BinanceCandle(Trady.Core.Candle source)
        {
            this.PartitionKey = Guid.NewGuid().ToString().Replace("-", "");
            this.RowKey = Guid.NewGuid().ToString().Replace("-", "");
            this.Timestamp = DateTime.Now;
            this.Pivot = source.Dpivot();
        }
        public BinanceCandle()
        {
            this.PartitionKey = Guid.NewGuid().ToString().Replace("-", "");
            this.RowKey = Guid.NewGuid().ToString().Replace("-", "");
            this.Timestamp = DateTime.Now;

        }
        public void UpdateContainer()
        {
            Update();
        }

        public void Update()
        {
            Console.WriteLine("Core - Candle container updating for : {0}", this.UID);
            this.Jscontainer = Newtonsoft.Json.JsonConvert.SerializeObject(this);

        }
        public override string ToString()
        {
            string Return = string.Empty;
            foreach(var prop in this.Properties)
            {
                Return += string.Format("Candle Properties Name : {0} - Value {1}" + Environment.NewLine, prop.Key, prop.Value);
            }
            return Return;
        }
        public string TypeOfData { get; set; } = "BinanceCandle";
        public double Pivot { get; set; }
        public string UID { get; set; } = Guid.NewGuid().ToString();
        public Trady.Core.Candle Candle { get; set; }
        public FactorDefintion Factor { get; set; }
        public string Name { get; set; }
        public string Exchanger { get; set; } = "Binance";
        public DateTime CollectedDate { get; set; } = DateTime.Now;
        public Dictionary<string, dynamic> Properties { get; set; } = new Dictionary<string, dynamic>();
        public string Jscontainer { get; set; }
        public string ModelDomain { get; set; } = "Provider";
        public string ModelId { get; set; } = "59bf4213-e145-4ead-b0f5-ba237b786965";
        public DateTime ModelLastChange { get; set; } = DateTime.Parse("31/08/2018");
    }
}
