var tenders = new Array();
var counter = 0;
var allOffers = new Array();
var currentId = "";
var currentOffer = undefined;
var offerCounter = 0;
$(document).ready(function() {

    getAllTenderOffers();
    getAllTenders();
    

})

function getAllTenderOffers() {

    $.ajax({
        type : 'GET',
        url : 'api/tender/offers',
        success: function(data) {
            allOffers = data;
            console.log('offers are');
            console.log(allOffers);
            //console.log(allOffers[0]);
        }
    })
}

function getAllTenders() {

    var rowId = '';
    var detailId = '';
    var offerId = '';


    $.ajax({
        type: 'GET',
        url: 'api/tender',
        
        success: function(data) {
            var myHTML = "";
            var rowwy = $('#tbodyTender');
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
                $('#offerTable').hide();
                $('#singleOfferTable').hide();
                console.log(entry)
                rowId = 'row' + counter;
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
                rowwyHTML += '<button class="btn btn-info" id="' + offerId + '">Check Offers</button>';
                rowwyHTML += "</td>";   

                rowwyHTML +="</tr>";
                counter = counter + 1;
                
                console.log('tender added');


            });

            rowwy.append(rowwyHTML);
            //addListenersToDetails();  
            addListenersToOffers();  
            console.log('tenders are');
            console.log(tenders);
        }
    })

}

function addListenersToOffers() {

    for(i = 0; i < tenders.length; i++) {
        offerId = 'offer-' + i;
        var currentOfferDetails = "";

        $('#' + offerId).click(function(){
            //console.log('hello details');
            var splitty = this.id.split('-');
            var tb = $('#tbodyOffer');
            tb.empty();
            medHTML = "";
            var currentTender = tenders[splitty[1]];
            currentId = tenders[splitty[1]].id;
            offerCounter = 0;
            allOffers.forEach(function(offer) {

                if (offer.id != currentId) {
                    console.log('where am I');
                    return;
                }
                var detailsId = 'details-' + offerCounter;
                var acceptId = 'accept-' + offerCounter;
                offerCounter += 1;
                console.log('i am here');
                medHTML += '<tr>';
                medHTML += '<td>';
                medHTML += currentTender.name;
                medHTML += '</td>';

                medHTML += '<td>';
                medHTML += offer.pharmacyName;
                medHTML += '</td>';
                
                medHTML += '<td>';
                medHTML += '<button class="btn btn-info" id="' + detailsId + '"> Details </button>';
                medHTML += '</td>';

                medHTML += '<td>';
                medHTML += '<button class="btn btn-light" id="' + acceptId + '"> Accept </button>';
                medHTML += '</td>';



                medHTML += '</tr>';
            });

            tb.append(medHTML);       
            $('#offerLabel').empty();
            $('#offerLabel').append('<h6 class="text-center">List of offers for ' + currentTender.name + '</h6>'); 
            $('#offerTable').show();
            addListenersToDetails(currentTender);
            addListenersToAccepts(currentTender);
        });

    }


}

function addListenersToDetails(currentTender) {

    var table = $('#offerTable');
    var val1 = table.find('tr:eq(2) td:eq(4)').text();

    for (i = 0; i < offerCounter; i++) {
        console.log('i is ' + i);
        currentOfferDetails = 'details-' + i;
        console.log(currentOfferDetails + ' outside listener');
        $('#' + currentOfferDetails).click(function(){
            console.log(currentOfferDetails + ' inside listener');
            var q = parseInt(this.id.split("-")[1]) + 1;
            console.log(q);
            var pharm = table.find('tr:eq(' + q + ') td:eq(1)').text();
            var tender = table.find('tr:eq(' + q + ') td:eq(0)').text();
            //console.log(i);
            console.log('pharm / tender is ' + pharm + '/' + tender);

            var tb = $('#tbodySingleOffer');
            tb.empty();

            var showOffer = undefined;
            allOffers.forEach(function(offer) {
                console.log('comparing ' + offer.pharmacyName + ' to ' + pharm);
                console.log('comparing ' + offer.id + ' to ' + currentId);
                if (offer.pharmacyName == pharm && offer.id == currentId) {
                    showOffer = offer;
                    console.log(offer);
                    return;
                }
            })

            detailHTML = "";
            
            showOffer.offeredMedicine.forEach(function(med){

                var curMed = undefined;

                currentTender.requiredMedicine.forEach(function(rm){

                    if (med.name == rm.name) {
                        curMed = rm;
                        return;
                    }

                })


                detailHTML +='<tr>';

                detailHTML += "<td>";
                detailHTML += med.name;
                detailHTML += "</td>";

                detailHTML += "<td>";
                detailHTML += curMed.amount;
                detailHTML += "</td>";

                detailHTML += "<td>";
                detailHTML += med.amount;
                detailHTML += "</td>";
                
                detailHTML += "<td>";
                detailHTML += med.pricePerUnit;
                detailHTML += "</td>";   

                detailHTML +="</tr>";

            });

            tb.append(detailHTML);
            $('#singleOfferTable').show();

        });



    }

}

function addListenersToAccepts(currentTender) {

    var table = $('#offerTable');

    for (i = 0; i < offerCounter; i++) {

        var acceptId = '#accept-' + i;

        $(acceptId).click(function(){

            var q = parseInt(this.id.split("-")[1]) + 1 ; // + 1 to skip header row
            var pharm = table.find('tr:eq(' + q + ') td:eq(1)').text();
            var tender = table.find('tr:eq(' + q + ') td:eq(0)').text();
            var offerForAccept = undefined;
        

            console.log('You want to accept offer from pharm ' + pharm + ' for tender ' + tender);
            // koja ponuda je prihvacena mozete pronaci iz kombinacije pharm + tender
            // posalji ajax call na endpoint prihvacenog tendera       
            // mozda neka labela da je tender prihvacen
            // posalji notifikaciju svima koji su ucestvovali na tenderu (iskoristi endpoint pa samo modifikuj string na notification uri)
            // endpoint : localhost:8080/api/medicine/take 
            // endpoint za notifikacije : localhost:8080/api/notification/add
            // var splitty = endpoint.split("/");
            // endpointNote = splitty[0] + / + splitty[1] + /notification/add;
            // onaj ko je dobio tender dobija notifikaciju da je dobio, ostali da je zatvoren
            // posalji ajax call na PSW stranu i obrisi tender koji je prihvacen, kao i sve ponude na njega

            allOffers.forEach(function(offer) {
                console.log('comparing ' + offer.pharmacyName + ' to ' + pharm);
                console.log('comparing ' + offer.id + ' to ' + currentTender.id);
                if (offer.pharmacyName == pharm && offer.id == currentTender.id) {
                    offerForAccept = offer;
                    console.log(offerForAccept);
                    return;
                }
            })
            
            $.ajax({
                type:'POST',
                crossDomain: true,
                url: offerForAccept.endpoint,
                contentType : 'application/json',

                data : JSON.stringify(offerForAccept),

                success: function(){
                    //alert("SUCCESS POSLAT ZAHTEV NA ISI");
                    var customUrl = "";
                    var splitted = offerForAccept.endpoint.split("/");
                    console.log(splitted);
                    
                    customUrl = splitted[0] + "//" + splitted[2] + "/" + "notification/add" ;
            
                    $.ajax({
                        type:'POST',
                        crossDomain: true,                        
                        url: customUrl,
                        contentType : 'application/json',
        
                        data : JSON.stringify({
                            message : "Congratulations-You-have-won-the-tender-" + currentTender.name
                        })

                    })

                    // We need to create new object, because of the conventions
                    var offers = [];
                    map = {};
                    offerForAccept.offeredMedicine.forEach(function(medOffer){
                        var object = {
                            PharmacyName : medOffer.pharmacyName,
                            Name : medOffer.name,
                            Amount : medOffer.amount,
                            PricePerUnit : medOffer.pricePerUnit                   
                        }     
                        map[medOffer.name] = object;
                    })

                    for (const [key, value] of Object.entries(map)) {
                        offers.push(value);
                    }
                    console.log("OFFEEEEEEEEEEEEEEEEEEEEEEEEEEEEEER:")
                    console.log(offers)
                
                    
                    $.ajax({
                        type : 'POST',
                        url : 'api/tender/accept',

                        data : JSON.stringify({
                            "Id" : offerForAccept.id,
                            "PharmacyName" : offerForAccept.pharmacyName,
                            "Endpoint" : offerForAccept.endpoint,
                            "OfferedMedicine" : offers

                        }),
                        contentType : "application/JSON",

                        success: function(data) {
                            //alert("DA LI SI PROSAO");
                        }
                    })
                }
            
            })
            
        });



    }


}