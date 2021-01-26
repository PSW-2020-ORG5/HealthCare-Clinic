var counter = 0;
var tenders = new Array();
var currentTenderId = "";
var map = {};
var offer = new Array();

$(document).ready(function() {

    $("#alertIdSuccess").css("display", "none");
    $("#alertIdError").css("display", "none");

    getAllTenders();


})

function getAllTenders() {

    var rowId = '';
    var detailId = '';
    var offerId = '';


    $.ajax({
        type: 'GET',
        url: 'api/tender',
        
        success: function(data) {
            var myHTML = "";
            var rowwy = $('#tbodyId');
            rowwyHTML = "";
            //rowId = 'row' + counter;
            //detailId = 'detail' + counter;
            //offerId = 'offer' + counter;
            
            //id , name, date, details, answer
            //myHTML +='<table class="table table-dark"><thead><tr><th scope="col">Tender id</th>';
            //myHTML +=' <th scope="col">Medicine name</th>'
            //myHTML +='<th scope="col"></th>'
            //myHTML +=' <th scope="col"></th>'
            //myHTML +='  <th scope="col"></th> '      
            //myHTML +=' </tr>'
            //myHTML +=' </thead>';

            

            data.forEach(function(entry) {
                tenders.push(entry);
                $('#medicineTable').hide();
                $('#offerTable').hide();
                console.log(entry)
                rowId = 'row' + counter;
                detailId = 'detail-' + counter;
                offerId = 'offer-' + counter;
                rowwyHTML +='<tr id="'+ rowId +'">';
                rowwyHTML += "<td>";
                rowwyHTML += entry.id;
                rowwyHTML += "</td>";
                rowwyHTML += "<td>";
                rowwyHTML += entry.name;
                rowwyHTML += "</td>";
                rowwyHTML += "<td>";
                rowwyHTML += entry.closingDate.split("T")[0];
                rowwyHTML += "</td>";
                rowwyHTML += "<td>";
                rowwyHTML += '<button class="btn btn-info" id="' + detailId + '">Details</button>';
                rowwyHTML += "</td>";
                rowwyHTML += "<td>";
                rowwyHTML += '<button class="btn btn-dark" id="' + offerId + '">Send Offer</button>';
                rowwyHTML += "</td>";    

                rowwyHTML +="</tr>";
                counter = counter + 1;
                
                console.log('tender added');


            });

            rowwy.append(rowwyHTML);
            addListenersToDetails();  
            addListenerToOffers();  
            console.log('tenders are');
            console.log(tenders);
        }
    })

}

function addListenersToDetails() {

    //$('#medicineTable').hide();
    $('#offerTable').hide();
    for(i = 0; i <= counter; i++) {

        detailId = 'detail-' + i;

        $('#' + detailId).click(function(){
            //console.log('hello details');
            var splitty = this.id.split('-');
            var tb = $('#tbodyMed');
            tb.empty();
            medHTML = "";
            tenders[splitty[1]].requiredMedicine.forEach(function(med) {

            medHTML += '<tr>';
            medHTML += '<td>';
            medHTML += med.name;
            medHTML += '</td>';

            medHTML += '<td>';
            medHTML += med.amount;
            medHTML += '</td>';
            medHTML += '</tr>';

            });

            tb.append(medHTML);        
            $('#medicineTable').show();
        });

    }
}

function addListenerToOffers() {
    // offerTable
    $('#medicineTable').hide();
    //$('#offerTable').hide();
    for(i = 0; i <= counter; i++) {

        offerId = 'offer-' + i;

        $('#' + offerId).click(function(){
            console.log('hello offers');
            
            var splitty = this.id.split('-');
            var tb = $('#tbodyOffer');
            tb.empty();
            offerHTML = "";
            currentTenderId = tenders[splitty[1]].id;
            console.log(currentTenderId);
            var medCounter = 0;
            tenders[splitty[1]].requiredMedicine.forEach(function(med) {

            offerHTML += '<tr>';
            offerHTML += '<td>';
            offerHTML += med.name;
            offerHTML += '</td>';

            offerHTML += '<td>';
            offerHTML += med.amount;
            offerHTML += '</td>';

            offerHTML += '<td>';
            offerHTML += '<input type="text" id="' + 'text-' + medCounter + '">';
            offerHTML += '</td>';
            offerHTML += '<td>';
            offerHTML += '<input type="text" id="' + 'price-' + medCounter + '">';
            offerHTML += '</td>';
            offerHTML += '</tr>';
            medCounter += 1;

            });

            tb.append(offerHTML);    
            addListenerToOfferButton();    
            $('#offerTable').show();

        });

    }


}

function addListenerToOfferButton() {
    map = {};
    var _name = "";
    var _amount = "";
    var _offer = "";
    var _priceper = "";

    $('#offerButton').click(function() {
        var table = $('#offerTable');
        var num = -2;
        table.find('tr').each(function (i, el) {
            num += 1;
            var $tds = $(this).find('td'),
                _name = $tds.eq(0).text(),
                _amount = $tds.eq(1).text();     
                _offer = $('#text-' + num).val();
                _priceper = $('#price-' + num).val();
                console.log(num + '. ' + _name + ' ' +  _amount + _offer + ' ' + _priceper); 
                         
            // the loop includes the header attributes which we don't need so we'll just add an if check
            if (_name != "" || _name == undefined)  {

                var object = {
                    PharmacyName : $('#name').val(),
                    Name : _name,
                    Amount : parseInt(_offer),
                    PricePerUnit : parseInt(_priceper)                   
                }   
                map[_name] = object;
                
            }
        });   
        
        console.log(map);
        console.log($('#endpoint').val());
        console.log($('#name').val());

        for (const [key, value] of Object.entries(map)) {
            //console.log(key, value);
            offer.push(value);
        }

        var tenderOffer = {

            Id : currentTenderId,
            PharmacyName : $('#name').val(),
            Endpoint : $('#endpoint').val(),
            OfferedMedicine : offer

        }

        var stringy = JSON.stringify(tenderOffer);
        console.log(stringy);

        $.ajax({
            type : 'POST',
            url : '/api/tender/offer',
            contentType : 'application/json',                   
            data : stringy,
            success : function() {   
                //alert("Successfully sent offer");
                document.body.scrollTop = document.documentElement.scrollTop = 0;
                $("#alertIdSuccess").css("display", "block");
            },
            error: function(error){
                document.body.scrollTop = document.documentElement.scrollTop = 0;
                $("#alertIdError").css("display", "block");
            }
        });

    })



}
