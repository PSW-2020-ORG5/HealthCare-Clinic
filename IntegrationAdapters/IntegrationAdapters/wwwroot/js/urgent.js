var counter = 0;
var retCounter = 0;
var openItems = false;
var shouldRender = true;
var name = "";
var amount = "";
var map = {};

$(document).ready(function() {

    // #addItem
    addClickListener($('#addItem'));
    $('#table').hide();
    $('#retTable').hide();
    $('#sendOrder').click(function() {

        console.log(map);

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
            alert('Invalid field value');
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

        map[name] = amount;
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

    map[name] = amount;
    $('#table').show();
    $('#' + divId).hide();
    $('#' + addItemButtonId).hide();
    openItems = false;
    shouldRender = true;

}