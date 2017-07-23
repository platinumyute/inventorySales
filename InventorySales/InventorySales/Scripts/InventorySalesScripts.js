/// <reference path="jquery.tablesorter.min.js" />
/// <reference path="jquery-1.9.1.js" />
$(document).ready(function ()
{
     WireEvents();
})

function UpdateDescription(currentDropId, dropToUpdateId)
{
     var url = "/lists/ProductDescription/";
     var ddl = $("#" + currentDropId);
     var brandId = ddl.val();
     var data = "brandId=" + brandId;
     var defaultMessage = "Select Description";
     UpdateData(url, data, dropToUpdateId, defaultMessage);
}

function UpdateBrand(currentDropId, dropToUpdateId) {
     var url = "/lists/ProductBrands/";
     var ddl = $("#" + currentDropId);
     var id = ddl.val();
     var data = "categoryId=" + id;
     var defaultMessage = "Select Brand";
     UpdateData(url, data, dropToUpdateId, defaultMessage);
}

function UpdateData(url, data, dropToUpdateId, defaultMessage)
{
     var ddl = $("#" + dropToUpdateId);
     ddl.empty();
     ddl.append("<option>"+ defaultMessage + "</option>")

     $.getJSON(url,
          data,
          function (result) {
               //loops thru each item in result
               $(result).each(function () {
                    var text = this["text"];
                    var value = this["value"];
                    var option = '<option value="' + value + '">' + text + '</option>';
                    ddl.append(option);
               })
          });
}


function WireEvents()
{

     $(".sortable thead th").on('mouseenter mouseleave', function () {
          $(this).css('cursor', 'pointer');
     })

     $(".sortable thead th").on('click', function () {

     })

     $(".sortable").on('click', function () {
          $(this).tablesorter();
          a
     })

}

function RenderBrands(id) {
     $.ajax({
          url: "/lists/categories/",
          success: function (result) {
               $("#" + id).html(result);
          }
     });
}

function reload() {
     location.reload();
}

function submitForm() {
     $('form').submit();
}
