// medID - textfield $("#medID").val()
// amount - number textfield $("#amount").val()
// select - dropdown    $("#select option:selected").text();  
// tableDiv - div where we print results $("#tableDiv")


// send AJAX on button press and create the table, when making table add IDs to buttons which should send request for order

// checkButton - dugme za slanje zahteva
// specButton - button for get specification of med

$(document).ready(function() {

    $("#specButton").click(function() {
        getSpec();
    });

    $("#checkButton").click(function() {
        getAvailability();
    });

})

function getSpec() {

    var name = $("#medID").val();

    console.log(name);

    $.ajax({
        type : 'GET',
        url : 'api/medspec/spec/' + name, 
               
        success: function(data, textStatus, xhr) {
            console.log(xhr.status);

            if(xhr.status == "204"){
                alert("There is no available specification for given Medicine!");

                $.ajax({
                    type: 'GET',
                    crossDomain: true,
                    url: 'http://localhost:8080/medspec/' + name,
                    
                    success: function() {
                        $.ajax({
                            type: 'GET',
                            url: 'api/report/ftp/' + name,
                            
                            success: function() {
                                getSpec();
                            }
                        })
                    }
                })
            } else {
                alert("Opened the specification file for you!");
            }
        }
    });
}

function getAvailability() {
    var name = $("#medID").val();
    var amount = $("#amount").val();

    $.ajax({
        type: 'POST',
        crossDomain: true,
        url: 'http://localhost:8080/med/availability',

        data : JSON.stringify({
            name : name,
            amount : amount
        }),

        contentType : 'application/json',

        success : function(data) {                
            alert(data);

            var divi = $("#orderTable"); 
            divi.empty();

            var myhtml = "";            

            myhtml += '<div class="visible" id="tableDiv"><div class="container"><div class="row"><div class="col-lg-1"></div>';
            myhtml += '<div class="col-lg-10"><table class="table"><thead>';
            myhtml += '<tr><th scope="col">Pharmacy</th><th scope="col">Medicine</th><th scope="col">Amount required</th><th scope="col">Available for order</th><th scope="col"></th> </tr>';
            myhtml += '</thead><tbody><tr>';

            myhtml += '<td>';
            myhtml += 'Benu';   
            myhtml += '</td>';

            myhtml += '<td>';
            myhtml += name;   
            myhtml += '</td>';

            myhtml += '<td>';
            myhtml += amount;   
            myhtml += '</td>';

            myhtml += '<td>';
            if(data){
                myhtml += '<button disabled class="btn btn-success">Yes</button>';  
                myhtml += '</td>';

                myhtml += '<td>';
                myhtml += '<button id = "orderButton" class="btn btn-warning">Send prescription</button>';
                myhtml += '</td>';

                
                

            } else {
                myhtml += '<button disabled class="btn btn-danger">No</button>'; 
                myhtml += '</td>';
            }
            
            myhtml += '</tr></tbody></table></div></div></div></div>';

            divi.append(myhtml);

            $("#orderButton").click(function() {
                sendPrescription();
            });

           }
    });
}

function sendPrescription(){
    var patient = $("#patientName").val();
    var name = $("#medID").val();
    var amount = $("#amount").val();
    var pharmacy = "Benu";

    $.ajax({
        type: 'POST',
        url: 'api/prescription/generate',

        data : JSON.stringify({
            Patient : patient, 
            Medicine : name,
            Amount : parseInt(amount),
            Pharmacy : pharmacy
        }),
        contentType : 'application/json',

        success : function(data) { 
            console.log(data);               
            alert("Succesfully generated prescription!");
            
            $.ajax({
                type:'GET',
                crossDomain: true,
                url: 'http://localhost:8080/sftp/download/' + String(data)
            });
        }
    });
}




