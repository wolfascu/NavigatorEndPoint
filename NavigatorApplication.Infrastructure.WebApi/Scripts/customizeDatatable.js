/* Table initialisation */
$(document).ready(function() {
    var response;
    $.ajax({
        type: "GET",
        url: "/API/FeedManagement/Get",
        success: function (res) {
            
            response = res;

            $('#feed').dataTable({
                "sDom": "<'row'<'span6'l><'span6'f>r>t<'row'<'span6'i><'span6'p>>",
                "sPaginationType": "bootstrap",
                "bProcessing": true,
                "bServerSide": false,
                "aaData": response,
                "aoColumns": [
                    {
                        "mData": "Photos", "sTitle": "Photos", "fnRender": function (oObj) {
                            console.log(oObj);
                            return '<a href=/Feed/' + oObj.aData["Id"] + '/Photos' + '>' + 'Photos' + '</a>';
                        }
                    },
                    { "mData": "Operation", "sTitle": "Operation", "sWidth": "100px" },
                    { "mData": "Id", "sTitle": "Feed Id" },
                        
                        { "mData": "Title", "sTitle": "Title" },
                        { "mData": "Entries", "sTitle": "Entries", "sClass": "center" },
                        { "mData": "Date", "sTitle": "Date", "sClass": "center" }
                        
                ],
                //"sAjaxSource": "/API/FeedManagement/Get",
                "oLanguage": {
                    "sLengthMenu": "_MENU_ records per page"
                }

            });
        }
    });
});

function wrapResponse() {
    
    return response;
}