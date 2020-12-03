$(document).ready(function() {

    getAB();

})

function getAB() {
    $.ajax({
        type : 'GET',
        url : '/api/actionbenefit', 
        contentType : 'application/json',                   
        success : function(data) {   
            console.log(data);
            var divi = $("#start"); 
            var myhtml = "";            
            data.forEach(
                function(entry) {

                    myhtml += '<div  class = "innerActionForm"><form> <div class= "form-group" ><h5 id = "pharmacyName">';
                    myhtml += entry.pharmacy;
                    myhtml += '</h5><textarea readonly class="form-control actionInput" type="text" id="actionDescription">';
                    myhtml += entry.message;
                    myhtml += '</textarea></div><div class= "form-inline"><label class="visibilityQuestion">Change visibility of this action and benefit: </label>';
                    myhtml += '<select class="form-control visibilityOption"><option>Private</option><option>Public</option></select></div>';
                    myhtml += '</form></div>';
                }
            );
            divi.append(myhtml);
        }

    });
}

