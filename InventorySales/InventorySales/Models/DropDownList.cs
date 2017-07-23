using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventorySales.Models
{
     public class DropDownList
     {
          public string OnChangeEventHandler { get; set; }
          public string SelectedValue { get; set; }
          public string Name { get; set; }
          public string DefaultMessage { get; set; }
          public List<DropDownlistItem> Items { get; set; }
          public DropDownList(string name, string defaultMessage, string selected, string onChangeEventHandler = "")
          {
               Name = name;
               DefaultMessage = defaultMessage;
               SelectedValue = selected;
               OnChangeEventHandler = onChangeEventHandler;
               Items = new List<DropDownlistItem>();
          }

          public void setSelected()
          {
               if (SelectedValue != "")
                    foreach (var item in Items)
                    {
                         if (item.Value == SelectedValue)
                              item.Selected = true;
                         else
                              item.Selected = false;
                    }
          }
     }
     public class DropDownlistItem
     {
          public string Value { get; set; }
          public string Text { get; set; }
          public bool Selected { get; set; }
          public DropDownlistItem(string value, string text)
          {
               Value = value;
               Text = text;
          }
     }
}