function ConfirmAddUnit() {
	var modal = $("#modalConfirm");
	var measureUnit = $(':input[name="measureUnit"]').val();

	var crlf = "<br>";
	var message = "<b>Adding a new Unit</b>" + crlf;
	message += "Unit: " + measureUnit + crlf;
	modal.find(".modal-body p").html(message);
	$("#toggleModal").click();
}