/// <reference path="InventorySalesScripts.js" />

function ConfirmAddCategory() {
     var heading = "Adding new Category";
     var categoryName = $(':input[name="categoryName"]').val();
     var crlf = "<br>";
     var message = "Category Name: " + categoryName + crlf;
     UseModal(heading, message);
}