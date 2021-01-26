// //name , key , save
$(document).ready(function() {
    $("#alertIdSuccess").css("display", "none");
    $("#alertIdError").css("display", "none");
    $("#save").click(saveKey);

})


function saveKey() {

    var key1 = $("#key").val();
    var name1 = $("#name").val();
    var grpcPort1 = $("#grpcId").val();
    var url = $("#urlId").val();
    var email1 = $("#emailId").val();
    var isUsingFtp1 = false;
    if ($('#ftpId').is(":checked"))
    {
        isUsingFtp1 = true;
    }


    console.log(key1);
    console.log(name1);
    console.log(email1);
    console.log(grpcPort1);
    console.log(isUsingFtp1);
    
    
    $.ajax({
        type : 'POST',
        url : '/api/api/save', 
        data : JSON.stringify({
                name : name1,
                api_key : key1,
                baseUrl : url,
                email : email1,
                grpcPort : grpcPort1,
                isUsingFtp : isUsingFtp1

        }),
        contentType : 'application/json',                   
        success : function(data) {                
            //alert("Successfully saved key to database");
            $("#alertIdSuccess").css("display", "block");
            console.log(data);
           },
        error: function(error){
            $("#alertIdError").css("display", "block");
            document.body.scrollTop = document.documentElement.scrollTop = 0;

        }
    });
}