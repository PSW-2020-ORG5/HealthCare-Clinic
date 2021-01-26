$(document).ready(function() {

    $("#generateButton").click(function() {
        generate();
    });

})

function generate() {
    var startdate = $("#dateStart").val();
    var enddate = $("#dateEnd").val();
    console.log(startdate);
    console.log(enddate);
    $.ajax({
        type : 'POST',
        url : '/api/report/ftp',
        data : JSON.stringify({
            startDate : startdate,
            endDate : enddate
        }),  
        contentType : 'application/json',                   
        success : function() {   
            alert("Successfully generated and uploaded file");
        }

    });
}