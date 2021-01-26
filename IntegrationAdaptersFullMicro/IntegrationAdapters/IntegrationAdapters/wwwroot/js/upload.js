//uploadButton
//myFile
$(document).ready(function () {
    $("#uploadButton").click(function() {
        upload();
    })

});

function upload() {

    var res = $("#myFile").val().split("\\");
    var file = res[res.length-1];
    alert(res[res.length-1]);
    $.ajax({
        type : 'POST',
        url : '/api/report/ftp/' + String(file),  
        contentType : 'application/json',                   
        success : function() {   
            alert("Successfully uploaded file");
        }

    });

}