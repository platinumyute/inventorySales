/// <reference path="InventorySalesScripts.js" />

function ConfirmAddProduct() {
     var heading = "Adding Product";
     var category = $(':input[name="CategoryId"] option:selected').text();
     var brand = $(':input[name="BrandId"] option:selected').text()
     var description = $('input[name="Description"]').val();
     var crlf = "<br>";
     var message = "Category: " + category + crlf;
     message += "Brand: " + brand + crlf;
     message += "Description: " + description + crlf;
     UseModal(heading, message);
}

function ConfirmEditProduct() {
     var heading = "Editing Product";
     var category = $(':input[name="CategoryId"] option:selected').text();
     var brand = $(':input[name="BrandId"] option:selected').text()
     var description = $('input[name="Description"]').val();
     var crlf = "<br>";
     var message = "Category: " + category + crlf;
     message += "Brand: " + brand + crlf;
     message += "Description: " + description + crlf;
     UseModal(heading, message);
}
