var counter = 0;
var retCounter = 0;
var openItems = false;
var shouldRender = true;
var name = "";
var amount = "";
var map = {};
var reqs = new Array();
var pharmCounter = 0;
var currentCounter = 1;

$(document).ready(function() {

    // #addItem
    addClickListener($('#addItem'));
    $('#table').hide();
    $('#retTable').hide();
    $('#sendOrder').click(function() {

        var table = $('#table');
        var medName = "";
        var medAmount = "";
        table.find('tr').each(function (i, el) {
            var $tds = $(this).find('td'),
                medName = $tds.eq(0).text(),
                medAmount = $tds.eq(1).text();               
            // the loop includes the header attributes which we don't need so we'll just add an if check
            if (medName != "") 
                map[medName] = medAmount;    
        });      
        for (const [key, value] of Object.entries(map)) {
            //console.log(key, value);
            var obj = {
                name : key,
                amount : parseInt(value)
            };
            reqs.push(obj);
        }
        console.log(reqs);
        // poslati ajax call ka nama da proverimo da li je prod ili dev
        // prod - nista samo saljemo http call kako bi smo proverili da li su lekovi dostupni
        // dev - saljemo call ka psw-u kako bi preko grpc-a proverili dostupnost 
        // ovaj deo je slican kao i kod slanja prescription-a 
        // napraviti inmemoryrepo za lekove npr  ("Aspirin", 25)

        $.ajax({
            type: "GET",
            url: "/api/http/env",
    
            success : function(data) {
                console.log(data);
    
                if(String(data) === "Development"){
                    checkGRPC(reqs);
                } else {
                    checkHTTP(reqs);
                }
            }
        })

    });
})

function addClickListener(addItemButton) {

    addItemButton.click(function() {

        renderItemHTML();
        counter += 1;
    });

}



function renderItemHTML() {

    if (openItems)
        return;
    
    openItems = true;

    if (shouldRender) {

        var divvy = $('#dynamicDiv');
        divvy.empty();
        var amountId = "amount" + counter;
        var medicineNameId = "medicineName" + counter;
        //var addItemId = "addItem" + counter;
        var addItemButtonId = "addItemButton" + counter;
        var divId = "div" + counter;    
        var myhtml = '';
        myhtml = '<div id="' + divId + '">'
        myhtml += '<div class="row"><div class="col-lg-4"></div><div class="col-lg-2"><label>Medicine name</label></div><div class="col-lg-2">';
        myhtml += '<input type="text" id="' + medicineNameId + '"></div></div><br><div class="row"><div class="col-lg-4"></div><div class="col-lg-2"><label>Amount</label>';
        myhtml += '</div><div class="col-lg-2"><input type="number" id="' + amountId + '"></div></div><br></div><div class="row"><div class="col-lg-5"></div><div class=""><button id="' + addItemButtonId + '" class="btn-dark btn"> Add Item </button></div><div class="col-lg-2 my-1"></div></div>';
        myhtml += '</div> <br>';

        divvy.append(myhtml);
    }

    
    $('#' + addItemButtonId).click(function(){

        name = $('#' + medicineNameId).val();
        amount = $('#' + amountId).val();

        if (!validateFields()) {
            //alert('Invalid field value');
            shouldRender = false;
            openItems = false;
            return;
        }
        
        var buttonId = 'button-' + counter;
        var rowId = 'row' + counter;
        var rowwy = $('#tbodyId');
        rowwyHTML = "";
        rowwyHTML +='<tr id="'+ rowId +'">';
        rowwyHTML += "<td>";
        rowwyHTML += name;
        rowwyHTML += "</td>";
        rowwyHTML += "<td>";
        rowwyHTML += amount;
        rowwyHTML += "</td>";
        rowwyHTML += "<td>";
        rowwyHTML += '<button class="btn btn-dark" id="' + buttonId + '">Remove</button>';
        rowwyHTML += "</td>";
        rowwyHTML +="</tr>";
        rowwy.append(rowwyHTML);

        $('#' + buttonId).click(function(){

            var splitty = this.id.split('-');
            $('#' + 'row' + splitty[1]).remove();
            

        });

        
        $('#table').show();
        $('#' + divId).hide();
        $('#' + addItemButtonId).hide();
        openItems = false;
        shouldRender = true;
    });
};


function validateFields() {

    if (name == "") return false;
    if (amount == "") return false;
    if (amount < 1) return false;
    return true;
}

function renderReturnTable(data) {

    var rowwy = $('#tbodyIdUrgent');
    var buttonId = 'button-' + retCounter;
    var rowRetId = 'rowRet' + retCounter;
    var rowwy = $('#tbodyId');
    rowwyHTML = "";
    rowwyHTML +='<tr id="'+ rowRetId +'">';
    rowwyHTML += "<td>";
    rowwyHTML += data.x; // fix this
    rowwyHTML += "</td>";
    rowwyHTML += "<td>";
    rowwyHTML += data.y; // fix this
    rowwyHTML += "</td>";
    rowwyHTML += "<td>";
    rowwyHTML += '<button class="btn btn-dark" id="' + buttonId + '">Remove</button>';
    rowwyHTML += "</td>";
    rowwyHTML +="</tr>";
    rowwy.append(rowwyHTML);

    $('#' + buttonId).click(function(){

        var splitty = this.id.split('-');
        $('#' + 'row' + splitty[1]).remove();
    });

    
    $('#table').show();
    $('#' + divId).hide();
    $('#' + addItemButtonId).hide();
    openItems = false;
    shouldRender = true;

}

async function checkHTTP(reqs) {

    var name = "";
    var amount = "";
    retList = new Array();
    var ajaxList = new Array();
    var tableBody = $("#tbodyIdUrgent");
    tableBody.empty();
    var myhtml = "";
    

    reqs.forEach(function(req){
        name = req.name
        console.log(name);
        amount = req.amount

        $.ajax({
            type: 'POST',
            crossDomain: true,
            url: 'http://localhost:8080/med/getAvailabilities',
    
            data : JSON.stringify({
                name : name,
                amount : amount
            }),

            contentType : 'application/json',


        }).then(function(data){

            ajaxList = data;

            retList = [];
            ajaxList.forEach(function(entry){
                console.log(entry);
                if(entry.isAvab) {
                    retList.push(entry);

                    console.log("///////////");
                    console.log(retList);
                }
            })

            myhtml = "";
            console.log('RETLIST: ');
            console.log(retList);

            
        
            retList.forEach(function(med){
                pharmCounter = pharmCounter + 1;
                console.log("*********USAOOOOOO**********");
                myhtml += '<tr>';
        
                myhtml += '<td>';
                myhtml += req.name;
                myhtml += '</td>';
        
                myhtml += '<td>';
                myhtml += req.amount;
                myhtml += '</td>';
        
                myhtml += '<td>';
                myhtml += med.pharmacy;
                myhtml += '</td>';
        
                myhtml += '<td>';
                myhtml += "<button id = 'order-" + pharmCounter + "'onClick='addListenerToOrder(this.id)' class='btn btn-warning'>Order med</button>";
                myhtml += '</td>';
        
                myhtml += '</tr>';
        
            });
    
        }).then(function(){

            tableBody.append(myhtml);
        });

    });
    $('#retTable').show();

}

async function checkGRPC(reqs) {

    var name = "";
    var amount = "";
    retList = new Array();
    var ajaxList = new Array();
    var tableBody = $("#tbodyIdUrgent");
    tableBody.empty();
    var myhtml = "";
    

    reqs.forEach(function(req){
        name = req.name
        console.log(name);
        amount = req.amount

        $.ajax({
            type: 'POST',
            url: '/api/medicine/availability',
    
            data : JSON.stringify({
                Name : name,
                Amount : amount
            }),

            contentType : 'application/json',


        }).then(function(data){

            ajaxList = data;

            retList = [];
            ajaxList.forEach(function(entry){
                console.log(entry);
                if(entry.isAvab) {
                    retList.push(entry);

                    console.log("///////////");
                    console.log(retList);
                }
            })

            myhtml = "";
            console.log('RETLIST: ');
            console.log(retList);

            
        
            retList.forEach(function(med){
                pharmCounter = pharmCounter + 1;
                console.log("*********USAOOOOOO**********");
                myhtml += '<tr>';
        
                myhtml += '<td>';
                myhtml += req.name;
                myhtml += '</td>';
        
                myhtml += '<td>';
                myhtml += req.amount;
                myhtml += '</td>';
        
                myhtml += '<td>';
                myhtml += med.pharmacy;
                myhtml += '</td>';
        
                myhtml += '<td>';
                myhtml += "<button id = 'order-" + pharmCounter + "'onClick='addListenerToOrder(this.id)' class='btn btn-warning'>Order med</button>";
                myhtml += '</td>';
        
                myhtml += '</tr>';
        
            });
    
        }).then(function(){

            tableBody.append(myhtml);
        });

    });
    $('#retTable').show();

}

async function addListenerToOrder(id){

    var splitty = id.split('-');
    var q = parseInt(splitty[1]);


    console.log(id + " " + q );

    var table = $('#retTable');

    var med = table.find('tr:eq(' + q + ') td:eq(0)').text();
    var amount = table.find('tr:eq(' + q + ') td:eq(1)').text();
    var pharm = table.find('tr:eq(' + q + ') td:eq(2)').text();

    console.log(med+  " " +amount +" " +pharm);

    var meds = new Array();
    var meds1 = new Array();
    var obj = {
        "pharmacyName" : pharm,
        "name" : med,
        "amount" : parseInt(amount),
        "pricePerUnit" : 2
    };

    var obj1 = {
        "PharmacyName" : pharm,
        "Name" : med,
        "Amount" : parseInt(amount),
        "PricePerUnit" : 2
    };

    meds.push(obj);
    meds1.push(obj1);

    $.ajax({
        type: 'POST',
        crossDomain: true,
        url: 'http://localhost:8080/tender/accepted',

        data : JSON.stringify({
            "id" : "idabcdefghiljk",
            "pharmacyName" : pharm,
            "endpoint" : "endpoint",
            "offeredMedicine" : meds
        }),

        contentType : 'application/json',

        success: function(){
            $.ajax({
                type : 'POST',
                url: 'api/tender/accept',

                data : JSON.stringify({
                    "Id" : "idabcdefghiljk",
                    "PharmacyName" : pharm,
                    "Endpoint" : "endpoint",
                    "OfferedMedicine" : meds1
                }),
                contentType : 'application/json',

                success: function(){
                    //alert('Succesfully updated both DBs');
                    location.reload();
                }


            })

        }
    });


}
