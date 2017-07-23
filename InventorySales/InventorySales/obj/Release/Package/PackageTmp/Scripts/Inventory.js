/// <reference path="jquery-1.9.1.js" />
/// <reference path="InventorySalesScripts.js" />

function ConfirmEditInventory() {
     var heading = "Editing Inventory";
     var category = $(':input[name="CategoryId"] option:selected').text();
     var productName = $(':input[name="ProductId"] option:selected').text();
     var measure = $(':input[name="Measure"] option:selected').text();
     var unit = $(':input[name="UnitId"] option:selected').text();
     var unitsBought = $(':input[name="UnitsBought"]').val();
     var unitsSold = $(':input[name="UnitsSold"]').val();
     var pricePaidPerUnit = $(':input[name="PricePaidPerUnit"]').val();
     var crlf = "<br>";
     var message = "Category: " + category + crlf;
     message += "Product Name: " + productName + crlf;
     message += "Description: " + measure + " " + unit + crlf;
     message += "Units Bought: " + unitsBought + crlf;
     message += "Units Sold: " + unitsSold + crlf;
     message += "Price Paid Per Unit: " + pricePaidPerUnit + crlf;
     UseModal(heading, message);
}

function ConfirmAddInventory() {
     var heading = "Adding Inventory";
     var brand = $(':input[name="BrandId"] option:selected').text();
     var description = $(':input[name="Description"] option:selected').text();
     var unitsPurchased = $(':input[name="UnitsPurchased"]').val();
     var PricePaidPerUnit = $(':input[name="PricePaidPerUnit"]').val();
     var crlf = "<br>";
     var message = "Brand: " + brand + crlf;
     message += "Description: " + description + crlf;
     message += "Units Purchased: " + unitsPurchased + crlf;
     message += "Price Per Unit: " + PricePaidPerUnit + crlf;
     UseModal(heading, message);
}

function ConfirmUpdateInventory() {
     var heading = "Updating Inventory";
     var category = $(':input[name="Category"]').val();
     var productName = $(':input[name="ProductName"]').val();
     var description = $(':input[name="Description"]').val();
     var unitsBought = $(':input[name="UnitsBought"]').val();
     var unitsSold = $(':input[name="UnitsSold"]').val();
     var crlf = "<br>";
     var message = "Category: " + category + crlf;
     message += "Product Name: " + productName + crlf;
     message += "Description: " + description + crlf;
     message += "Units Bought: " + unitsBought + crlf;
     message += "Units Sold: " + unitsSold + crlf;
   
     UseModal(heading, message);

    
}


function SetUpAddNewInventory() {
     var num = '5';
     var category = '<select>';
     category += '<option>Soft Drink</option>';
     category += '<option>Grocery</option>';
     category += '</select>';
     var name = '<input type="text"></input>'
     var desc = '<select>';
     desc += '<option>16 oz</option>';
     desc += '<option>20 oz</option>';
     desc += '<option>32 oz</option>';
     desc += '</select>';
     var amount = '<input type="text"></input>'
     AddNewRow(num, category, name, desc, amount);
}

