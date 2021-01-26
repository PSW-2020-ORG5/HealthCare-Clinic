var counter = 0;
var openItems = false;
var shouldRender = true;
var name = "";
var amount = "";
var reqs = new Array();
map = {}
var allKeys = new Array();

$(document).ready(function() {
    getAllKeys();
    $("#alertIdSuccess").css("display", "none");
    $("#alertIdError").css("display", "none");
    // #addItem
    addClickListener($('#addItem'));
    $('#table').hide();

    $('#publishTender').click(function() {

        var a = $('#closingDate').val();
        var b = $('#tenderName').val();
        //console.log(map);
        //console.log(a);
        //console.log(b);
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

        var tender = {
            Name : b,
            ClosingDate : a,
            RequiredMedicine : reqs
        };
        var stringy = JSON.stringify(tender);
        console.log(stringy);

        $.ajax({
            type : 'POST',
            url : '/api/tender/publish',  
            contentType : 'application/json',
            data : stringy,                   
            success : function() {   
                //alert("Successfully uploaded file");
                console.log("USAO OVDEE");
                var message =  "HealthClinic-added-a-new-Tender"
                $("#alertIdSuccess").css("display", "block");
                
                allKeys.forEach(function(oneKey){

                    $.ajax({
                        type:'POST',
                        crossDomain: true,
                        url: oneKey.baseUrl + '/notification/add',
                        contentType : 'application/json',
        
                        data : JSON.stringify({
                            message : message
                        })
            
                    })
    
                    $.ajax({
                        type:'POST',
                        url: '/api/tender/sendemail',
                        contentType : 'application/json',
        
                        data : JSON.stringify({
                            email : oneKey.email
                        })
            
                    })



                })
                


            },
            error: function(error){
                $("#alertIdError").css("display", "block");
    
            }
    
        });


    });
})

function getAllKeys(){
    var retList = undefined;

    $.ajax({
        type: "GET",
        url: "/api/api",

        success : function(data) {
            console.log(data);

            data.forEach(function(oneData){
                if(oneData.baseUrl!=null)
                    allKeys.push(oneData);
            })



        }
    })


}

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
            ('Invalid field value');
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
        
        //map[name] = amount;
        console.log('herere')
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