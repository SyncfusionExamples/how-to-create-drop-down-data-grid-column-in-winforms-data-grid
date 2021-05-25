using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComboBoxColumn
{
    public class CountryInfoRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public CountryInfoRepository()
        {
            this.PopulateData();
            _shipCities = CountryDetailsRepository.GetShipCities();
            CountryList = new List<string>(ShipCities.Keys);

            Cities = new ObservableCollection<ShipCityDetails>();
            Cities.Add(new ShipCityDetails() { ShipCityName = "Bergamo", ShipCityID = 101 });
            Cities.Add(new ShipCityDetails() { ShipCityName = "Graz", ShipCityID = 102 });
            Cities.Add(new ShipCityDetails() { ShipCityName = "Campinas", ShipCityID = 103 });
            Cities.Add(new ShipCityDetails() { ShipCityName = "Montréal", ShipCityID = 104 });
            Cities.Add(new ShipCityDetails() { ShipCityName = "Buenos Aires", ShipCityID = 105 });


            Cities.Add(new ShipCityDetails() { ShipCityName = "austriaAachen", ShipCityID = 106 });
            Cities.Add(new ShipCityDetails() { ShipCityName = "Cork", ShipCityID = 107 });
            Cities.Add(new ShipCityDetails() { ShipCityName = "Århus", ShipCityID = 108 });
            Cities.Add(new ShipCityDetails() { ShipCityName = "Montréal", ShipCityID = 109 });
            Cities.Add(new ShipCityDetails() { ShipCityName = "Graz", ShipCityID = 110 });

        }
        public ObservableCollection<ShipCityDetails> Cities { get; set;}

        private ObservableCollection<OrderDetails> _orderDatails;
        /// <summary>
        /// Gets or sets the orders details.
        /// </summary>
        /// <value>The orders details.</value>
        public ObservableCollection<OrderDetails> OrderDetails
        {
            get
            {
                return _orderDatails;
            }
            set
            {
                _orderDatails = value;
            }
        }

        Dictionary<string, ObservableCollection<ShipCityDetails>> _shipCities;
        /// <summary>
        /// Gets or sets the ship cities.
        /// </summary>
        /// <value>The ship cities.</value>
        public Dictionary<string, ObservableCollection<ShipCityDetails>> ShipCities
        {
            get
            {
                return _shipCities;
            }
            set
            {
                _shipCities = value;
            }
        }

        public List<string> CountryList { get; set; }

        Random r = new Random();
        public void PopulateData()
        {
            _orderDatails = new ObservableCollection<OrderDetails>();
            _orderDatails.Add(new OrderDetails(1000, CustomerID[r.Next(15)], ProductName[r.Next(6)], 10, "Argentina", 101));
            _orderDatails.Add(new OrderDetails(1001, CustomerID[r.Next(15)], ProductName[r.Next(6)], 15, "Austria", 106));
            _orderDatails.Add(new OrderDetails(1002, CustomerID[r.Next(15)], ProductName[r.Next(6)], 20, "Belgium", 110));
            _orderDatails.Add(new OrderDetails(1003, CustomerID[r.Next(15)], ProductName[r.Next(6)], 25, "Brazil", 109));
            _orderDatails.Add(new OrderDetails(1004, CustomerID[r.Next(15)], ProductName[r.Next(6)], 20, "Canada", 106));
            _orderDatails.Add(new OrderDetails(1005, CustomerID[r.Next(15)], ProductName[r.Next(6)], 17, "Denmark", 105));
            _orderDatails.Add(new OrderDetails(1006, CustomerID[r.Next(15)], ProductName[r.Next(6)], 14, "Finland", 103));
            _orderDatails.Add(new OrderDetails(1007, CustomerID[r.Next(15)], ProductName[r.Next(6)], 11, "Italy", 108));
            _orderDatails.Add(new OrderDetails(1008, CustomerID[r.Next(15)], ProductName[r.Next(6)], 7, "US", 101));
            _orderDatails.Add(new OrderDetails(1009, CustomerID[r.Next(15)], ProductName[r.Next(6)], 5, "Belgium", 104));
            _orderDatails.Add(new OrderDetails(1010, CustomerID[r.Next(15)], ProductName[r.Next(6)], 3, "Brazil", 109));
            _orderDatails.Add(new OrderDetails(1011, CustomerID[r.Next(15)], ProductName[r.Next(6)], 7, "Denmark", 110));
            _orderDatails.Add(new OrderDetails(1012, CustomerID[r.Next(15)], ProductName[r.Next(6)], 13, "Argentina", 101));
            _orderDatails.Add(new OrderDetails(1013, CustomerID[r.Next(15)], ProductName[r.Next(6)], 12, "Canada", 103));
            _orderDatails.Add(new OrderDetails(1014, CustomerID[r.Next(15)], ProductName[r.Next(6)], 5, "Finland", 105));
        }
        string[] ProductName = new string[]
       {
            "Alice Mutton",
            "NuNuCa Nub-Nougat-Creme",
            "Boston Crab Meat",
            "Raclette Courdavault",
            "Wimmers gute Semmelknodel",
            "Konbu"
       };
        string[] CustomerID = new string[]
      {
            "ALFKI",
            "FRANS",
            "MEREP",
            "FOLKO",
            "SIMOB",
            "WARTH",
            "VAFFE",
            "FURIB",
            "SEVES",
            "LINOD",
            "RISCU",
            "PICCO",
            "BLONP",
            "WELLI",
            "FOLIG"
      };
    }
}
