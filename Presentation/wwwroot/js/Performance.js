$(function () {
    $("#btnSubmit").click(function () {
        $("input[name='GridHtml']").val($(".Grid").html());
    });
});
var strValue = "@((string)ViewBag.SaveAndCloseManage)";
if (strValue !== null && strValue !== "") {
    swal({
        icon: "success",
        text: "Të dhënat janë ndryshuan me sukses!",
        timer: 2000,
        buttons: false,
    })
}
$(document).ready(function () {
    $('#exampleTest2').DataTable();

});

function ExportToExcel(type, fn, dl) {
    var elt = document.getElementById('exampleTest2');
    var wb = XLSX.utils.table_to_book(elt, { sheet: "sheet1" });
    return dl ?
        XLSX.write(wb, { bookType: type, bookSST: true, type: 'base64' }) :
        XLSX.writeFile(wb, fn || ('MySheetName.' + (type || 'xlsx')));
}
