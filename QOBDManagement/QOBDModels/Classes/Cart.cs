﻿using QOBDCommon.Entities;
using QOBDModels.Interfaces;
using QOBDModels.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QOBDModels.Classes
{
    public class Cart : BindBase, ICart
    {
        private ObservableCollection<Cart_itemModel> _cart;
        private decimal _cartTotalPurchasePrice; // PAT
        private decimal _cartTotalSellingPrice; //PTT
        private ClientModel _client;

        public Cart()
        {
            _cart = new ObservableCollection<Cart_itemModel>();
            _client = new ClientModel();

            CartItemList.CollectionChanged += onCartItemsChange;
        }

        public ClientModel ClientModel
        {
            get { return _client; }
            set { setProperty(ref _client, value); }
        }

        public ObservableCollection<Cart_itemModel> CartItemList
        {
            get { return _cart; }
            set { setProperty(ref _cart,value); }
        }

        public string TxtCartTotalPurchasePrice
        {
            get { return _cartTotalPurchasePrice.ToString(); }
            set { setProperty(ref _cartTotalPurchasePrice,Convert.ToDecimal(value)); }
        }

        public string TxtCartTotalSellingPrice
        {
            get { return _cartTotalSellingPrice.ToString(); }
            set { setProperty(ref _cartTotalSellingPrice,Convert.ToDecimal(value)); }
        }

        private void onCartItemsChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            calculCartTotal();
        }

        private void calculCartTotal()
        {
            decimal cartTotalPurchase = 0.0m;
            decimal cartTotalSelling = 0.0m;
            foreach (Cart_itemModel cart_itemModel in CartItemList)
            {
                cartTotalPurchase += Convert.ToDecimal(cart_itemModel.TxtTotalPurchasePrice);
                cartTotalSelling += Convert.ToDecimal(cart_itemModel.TxtTotalSellingPrice);
            }
            TxtCartTotalPurchasePrice = cartTotalPurchase.ToString();
            TxtCartTotalSellingPrice = cartTotalSelling.ToString();
        }

        private void onTotalPurchaseOrSellingPriceChange(object sender, PropertyChangedEventArgs e)
        {
            if (string.Equals(e.PropertyName, "TxtTotalPurchasePrice") || string.Equals(e.PropertyName, "TxtTotalSellingPrice"))
                calculCartTotal();
        }

        public void AddItem(Cart_itemModel cart_itemModel)
        {
            cart_itemModel.PropertyChanged += onTotalPurchaseOrSellingPriceChange;
            CartItemList.Add(cart_itemModel);
            onPropertyChange("CartItemList");
        }

        public void RemoveItem(Cart_itemModel cart_itemModel)
        {
            CartItemList.Remove(cart_itemModel);
        }
        
    }
}
