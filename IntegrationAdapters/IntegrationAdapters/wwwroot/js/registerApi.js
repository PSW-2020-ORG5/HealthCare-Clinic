// //name , key , save
$(document).ready(function() {

    $("#save").click(saveKey);

})


function saveKey() {

    var key1 = $("#key").val();
    var name1 = $("#name").val();

    console.log(key1)
    console.log(name1)

    $.ajax({
        type : 'POST',
        url : '/api/api/save', 
        data : JSON.stringify({
                name : name1,
                api_key : key1
        }),
        contentType : 'application/json',                   
        success : function(data) {                
            //alert("Successfully saved key to database");
           }
    });
}