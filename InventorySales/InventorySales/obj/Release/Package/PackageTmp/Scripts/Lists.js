function RenderBrands(id) {
     $.ajax({
          url: "/lists/categories/", 
          success: function (result) {
               $("#" + id).html(result);
          }
     });
});