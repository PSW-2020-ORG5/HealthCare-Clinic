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
                //alert("There is no available specification for given Medicine!");

                $.ajax({
                    type: "GET",
                    url: "/api/http/env",
            
                    success : function(data) {
                        console.log(data);
            
                        if(String(data) === "Development"){                            
                            getSpecSftp(name);
                        } else {
                            getSpecHttp(name);
                        }
                    }
                })
    
            } else {
                //alert("Opened the specification file for you!");
            }
        }
    });
}

function getAvailability() {

    $.ajax({
        type: "GET",
        url: "/api/http/env",

        success : function(data) {
            console.log(data);

            if(String(data) === "Development"){
                checkGRPC();
            } else {
                checkHTTP();
            }
        }
    })

}

function sendPrescription(entry){
    var patient = $("#patientName").val();
    var name = $("#medID").val();
    var amount = $("#amount").val();
    var pharmacy = entry.pharmacy;
    var location = entry.location;

    $.ajax({
        type: 'POST',
        url: 'api/prescription/generate',

        data : JSON.stringify({
            Patient : patient, 
            Medicine : name,
            Amount : parseInt(amount),
            Pharmacy : pharmacy,
            Location : location
        }),
        contentType : 'application/json',

        success : function(data) { 
            console.log(data);  
            var flag = false;
            //alert("Succesfully generated prescription!");
            
            var message1 = data;
            
            $.ajax({
                type: "GET",
                url: "/api/http/env",
        
                success : function(data2) {
                    console.log(data2);
        
                    if(String(data2) === "Development"){
                        sendPrescSftp(data);
                        //message1 = data;
                        console.log(message1);
                    } else {
                        sendPrescHttp(data);
                        //message1 = data;
                        console.log(message1);
                    }
                }
            })

            $.ajax({
                type:'POST',
                crossDomain: true,
                url: 'http://localhost:8080/notification/add',
                contentType : 'application/json',

                data : JSON.stringify({
                    message : message1
                })
    
            })
            
        }
    });


}

function checkGRPC() {

    var name = $("#medID").val();
    var amount = $("#amount").val();

    amount1 = parseInt(amount);

    $.ajax({
        type: 'POST',
        url: '/api/medicine/availability',

        data : JSON.stringify({
            Name : name,
            Amount : amount1
        }),

        contentType : 'application/json',

        success : function(data) {                
            //alert(data);

            var divi = $("#orderTable"); 
            divi.empty();

            var myhtml = "";            

            myhtml += '<div class="visible" id="tableDiv"><div class="container"><div class="row"><div class="col-lg-1"></div>';
            myhtml += '<div class="col-lg-10"><table class="table"><thead>';
            myhtml += '<tr><th scope="col">Pharmacy</th><th scope="col">Address</th><th scope="col">Medicine</th><th scope="col">Amount required</th><th scope="col">Available for order</th><th scope="col"></th> </tr>';
            myhtml += '</thead><tbody><tr>';

            data.forEach(function(entry) {
                myhtml += '<tr>';
                myhtml += '<td>';
                myhtml += entry.pharmacy;   
                myhtml += '</td>';

                myhtml += '<td>';
                myhtml += entry.location;   
                myhtml += '</td>';
    
                myhtml += '<td>';
                myhtml += name;   
                myhtml += '</td>';
    
                myhtml += '<td>';
                myhtml += amount;   
                myhtml += '</td>';
    
                myhtml += '<td>';

                if(entry.isAvab){
                    myhtml += '<button disabled class="btn btn-success">Yes</button>';  
                    myhtml += '</td>';
    
                    myhtml += '<td>';
                    myhtml += "<button id = 'orderButton" + entry.pharmacy + "' class='btn btn-warning'>Send prescription</button>";
                    myhtml += '</td>';
    
                } else {
                    myhtml += '<button disabled class="btn btn-danger">No</button>'; 
                    myhtml += '</td>';
                }

                myhtml += '</tr>';
            });
           
            myhtml += '</tr></tbody></table></div></div></div></div>';

            divi.append(myhtml);

            data.forEach(function(entry){
 
                $("#orderButton" + entry.pharmacy).click(function() {
                    console.log(entry);
                    $("#orderButton" + entry.pharmacy).text("SENT");
                    $("#orderButton" + entry.pharmacy).prop('disabled', true);
                    $("#orderButton" + entry.pharmacy).removeClass("btn-warning").addClass("btn-primary");
    
                    data.forEach(function(entry){
                        $("#orderButton" + entry.pharmacy).prop('disabled', true);
                    });

                    sendPrescription(entry);
                });
            });

           }
    });

}

function checkHTTP() {

    var name = $("#medID").val();
    var amount = $("#amount").val();

    $.ajax({
        type: 'POST',
        crossDomain: true,
        url: 'http://localhost:8080/med/getAvailabilities',

        data : JSON.stringify({
            name : name,
            amount : amount
        }),

        contentType : 'application/json',

        success : function(data) {                
            //alert(data);

            var divi = $("#orderTable"); 
            divi.empty();

            var myhtml = "";            

            myhtml += '<div class="visible" id="tableDiv"><div class="container"><div class="row"><div class="col-lg-1"></div>';
            myhtml += '<div class="col-lg-10"><table class="table"><thead>';
            myhtml += '<tr><th scope="col">Pharmacy</th><th scope="col">Address</th><th scope="col">Medicine</th><th scope="col">Amount required</th><th scope="col">Available for order</th><th scope="col"></th> </tr>';
            myhtml += '</thead><tbody><tr>';

            data.forEach(function(entry) {
                myhtml += '<tr>';
                myhtml += '<td>';
                myhtml += entry.pharmacy;   
                myhtml += '</td>';

                myhtml += '<td>';
                myhtml += entry.location;   
                myhtml += '</td>';
    
                myhtml += '<td>';
                myhtml += name;   
                myhtml += '</td>';
    
                myhtml += '<td>';
                myhtml += amount;   
                myhtml += '</td>';
    
                myhtml += '<td>';

                if(entry.isAvab){
                    myhtml += '<button disabled class="btn btn-success">Yes</button>';  
                    myhtml += '</td>';
    
                    myhtml += '<td>';
                    myhtml += "<button id = 'orderButton" + entry.pharmacy + "' class='btn btn-warning'>Send prescription</button>";
                    myhtml += '</td>';
    
                } else {
                    myhtml += '<button disabled class="btn btn-danger">No</button>'; 
                    myhtml += '</td>';
                }

                myhtml += '</tr>';
            });
           
            myhtml += '</tr></tbody></table></div></div></div></div>';

            divi.append(myhtml);

            data.forEach(function(entry){
 
                $("#orderButton" + entry.pharmacy).click(function() {
                    console.log(entry);
                    $("#orderButton" + entry.pharmacy).text("SENT");
                    $("#orderButton" + entry.pharmacy).prop('disabled', true);
                    $("#orderButton" + entry.pharmacy).removeClass("btn-warning").addClass("btn-primary");
    
                    data.forEach(function(entry){
                        $("#orderButton" + entry.pharmacy).prop('disabled', true);
                    });

                    sendPrescription(entry);
                });
            });

           }
    });

}

function getSpecSftp(name){

    var name = $("#medID").val();

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
}


function getSpecHttp(name){

    $.ajax({
        type: 'POST',
        crossDomain: true,
        url: 'http://localhost:8080/medspec/uploadhttp',

        contentType : 'text/plain',

        data : name,
        
        success : function() {
             getSpec();
        }
    })
}

function sendPrescSftp(data) {

    var message1;

    $.ajax({
        type:'GET',
        crossDomain: true,
        url: 'http://localhost:8080/sftp/download/' + String(data),
        
        success : function(data1) {
             message1 = String(data1);
             console.log(message1);
        }

    });
    return message1;
}

function sendPrescHttp(data) {

    var message1;

    $.ajax({
        type:'GET',
        crossDomain: true,
        url: 'api/http/httpfile/' + String(data),
        
        success : function(data1) {
             message1 = String(data1);
             console.log(message1);
        }

    });
    return message1;
}


