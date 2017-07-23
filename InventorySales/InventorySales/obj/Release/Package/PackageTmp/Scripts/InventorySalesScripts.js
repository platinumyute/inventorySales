/// <reference path="jquery-1.9.1.js" />
/// <reference path="jquery.tablesorter.js" />
$(document).ready(function ()
{
     WireEvents();
})


function ConfirmDeleteInventory()
{
     $("#toggleModal").click();
}

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

     $("#tblInventoryDisplay thead").on('mouseenter mouseleave', function () {
          $(this).css('cursor', 'pointer');
     })

     $("#tblInventoryDisplay").on('click', "th", function () {
          sortTable(this.cellIndex);
     })

     $("#tblCategoryDisplay").on('click', "tbody tr td span", function () {
          var tr = $(this).parent("td");
          var label = tr.children("label");
          var textBox = newTextBox(label.text());
          var out = textBox;
          var btn = newButton("Update");
          out += btn;
          label.html(out);
          
     })

     $("#tblCategoryDisplay").on('click', "tbody tr td label input", function () {
          if ($(this).val() == "Update") {
               var label = $(this).parent("label");

               var txtbox = label.children('input[type="text"]');
               var out = $(txtbox).val();
               label.remove("input");
               label.text(out);
          }
     })


     $("#searchProduct").keypress(function (e) {
          if (e.which == 13) {
               SearchProduct();
          }
     });

     $("#tblInventoryDisplay").on("click", "tbody tr .glyphicon-edit", function () {
          var header = $("#tblInventoryDisplay thead th");
          var tds = $(this).parent().parent("tr").find("td");
          var query = "";
          tds.each(function (ix) {
               if (ix < tds.length - 1) {
                    var colName = $(header[ix]).text();
                    var value = tds[ix].innerHTML;
                    query += colName + "=" + value + "&";
               }
          })
          window.location.href = "edit-inventory.html?" + query;
     });
}

function getQueryValue(name) {
     var query = location.toString().split('?');
     query = query[1];
     var all = query.split("&");

     $(all).each(function () {
          var keyVal = query.split("=");
          var key = keyVal[0];
          var val = keyVal[1];
          
     })
}

function newButton(text) {
     var tag = '<input type="button" value=' + text + '>';
     return tag;
}

function newLabel(text) {
     var tag = '<label>' + text + '</label>';
     return tag
}

function newTextBox(text) {
     var tag = '<input type="text" value=' + text + ">";
     return tag;
}


function UseModal(heading, message) {
     var modal = $("#modalConfirm");
     var modalHeader = modal.find(".modal-header label");
     var modalBody = modal.find(".modal-body p");
     
     modalHeader.html(heading);
     modalBody.html(message);

     $("#toggleModal").click();
}

function AddNewRow(num, category, name, desc, amount) {
     var table = $("#tblInventoryDisplay");
     var row = '<tr><td>' + num + '</td><td>' + category + '</td><td>' + name + '</td><td>' + desc + '</td><td>' + amount + '</td></tr>'
     table.append(row)
}

function sortTable(n) {
  var table, rows, switching, i, x, y, shouldSwitch, dir, switchcount = 0;
  table = document.getElementById("tblInventoryDisplay");
  switching = true;
  //Set the sorting direction to ascending:
  dir = "asc"; 
  /*Make a loop that will continue until
  no switching has been done:*/
  while (switching) {
    //start by saying: no switching is done:
    switching = false;
    rows = table.getElementsByTagName("TR");
    /*Loop through all table rows (except the
    first, which contains table headers):*/
    for (i = 1; i < (rows.length - 1); i++) {
      //start by saying there should be no switching:
      shouldSwitch = false;
      /*Get the two elements you want to compare,
      one from current row and one from the next:*/
      x = rows[i].getElementsByTagName("TD")[n];
      y = rows[i + 1].getElementsByTagName("TD")[n];
      /*check if the two rows should switch place,
      based on the direction, asc or desc:*/
      if (dir == "asc") {
        if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
          //if so, mark as a switch and break the loop:
          shouldSwitch= true;
          break;
        }
      } else if (dir == "desc") {
        if (x.innerHTML.toLowerCase() < y.innerHTML.toLowerCase()) {
          //if so, mark as a switch and break the loop:
          shouldSwitch= true;
          break;
        }
      }
    }
    if (shouldSwitch) {
      /*If a switch has been marked, make the switch
      and mark that a switch has been done:*/
      rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
      switching = true;
      //Each time a switch is done, increase this count by 1:
      switchcount ++; 
    } else {
      /*If no switching has been done AND the direction is "asc",
      set the direction to "desc" and run the while loop again.*/
      if (switchcount == 0 && dir == "asc") {
        dir = "desc";
        switching = true;
      }
    }
  }
}

function AddNewNode(element) {
     alert($(element).val());
}

function reload() {
     location.reload();
}

function submitForm() {
     $('form').submit();
}

function PaginateInventory() {
     var tbody = $('#tblInventoryDisplay tbody');
     var trs = tbody.find("tr");
     var newTbody = "";
     var trBegin = '<tr>';
     var trEnd = '</tr>';

     var num = $(trs[trs.length-1]).find("td")[0].innerHTML;
     for (var i = trs.length - 1; i >= 0; i--) {
          var tr = trs[i];
          var tds = $(tr).find("td");
          var td = tds[0];
          $(td).html(num);
          num++;
          newTbody += trBegin + tr.innerHTML + trEnd;
     }
     tbody.html(newTbody);

}

function close()
{
     $("#successMessage").toggleClass("hide");
}




function GetQueryString(name) {
     var urlParams = new URLSearchParams(window.location.search);
     return urlParams.get(name);
}

function SetQueryString(name, value) {
     var urlParams = new URLSearchParams(window.location.search);
     urlParams.append(name, value);
}

function updateView(from, to)
{
     $("#" + from).hide();
     $("#" + to).show();
}

function setFieldValues() {
     getQueryValue("ca");
}