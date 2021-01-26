$(document).ready(function(){
    addCopyListener($('#copy1'), 'api/actionbenefit');
    addCopyListener($('#copy2'), 'api/api');
    addCopyListener($('#copy3'), 'api/api/{id}');
    addCopyListener($('#copy4'), 'api/api/save');
    addCopyListener($('#copy5'), 'api/http/env');
    addCopyListener($('#copy6'), 'api/httpfile/{file}');
    addCopyListener($('#copy7'), 'api/medicine/availability');
    addCopyListener($('#copy8'), 'api/spec/{name}');
    addCopyListener($('#copy9'), 'api/spec/getspechttp');
    addCopyListener($('#copy10'), 'api/prescription/generate');
    addCopyListener($('#copy11'), 'api/report/ftp/{name}');
    addCopyListener($('#copy12'), 'api/report/ftp/{name}');
    addCopyListener($('#copy13'), 'api/report/ftp');
    addCopyListener($('#copy14'), 'api/tender/publish');
    addCopyListener($('#copy15'), 'api/tender');
    addCopyListener($('#copy16'), 'api/tender/{id}');
    
    //addCopyListener($('#copy2'), '');




})

function addCopyListener(button, text) {

    button.click(function(){

        const el = document.createElement('textarea');
        el.value = text;
        el.setAttribute('readonly', '');
        el.style.position = 'absolute';
        el.style.left = '-9999px';
        document.body.appendChild(el);
        el.select();
        document.execCommand('copy');
        document.body.removeChild(el);


    });


}