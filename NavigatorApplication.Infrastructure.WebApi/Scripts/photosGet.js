$(document).ready(function () {
    $.get('/api/FeedPhoto/FeedId', function (data) {
        console.log(data);
        var photoRows = new Array();
        $(data).each(function () {

            var currItem = this;
            var img = $("<div/>", {
                "class": "span2",
                html: $("<img/>", {
                    src: currItem.PhotoURL
                })
            });

            var photoInfo = $("<div/>", {
                "class": "span4"
            }).append('<div><span style="padding-right: 10px;">Title</span><span>' + currItem.Title + '</span></div>' +
                      '<div><span style="padding-right: 10px;">Photo Id</span><span>' + currItem.Id + '</span></div>' +
                      '<div><span style="padding-right: 10px;">Updated</span><span>' + currItem.Updated + '</span></div>' +
                      '<div><span style="padding-right: 10px;">Date Taken</span><span>' + currItem.DateTaken + '</span></div>');

            var photoWeb = $("<div/>", {
                "class": "span4"
            }).append('<div><span>Name</span><span>' + currItem.AuthorName + '</span></div>' +
            '<div><span>Author URL</span><span>' + currItem.AuthorURL + '</span></div>' +
            '<div><span>Photo URL</span><span>' + currItem.PhotoURL + '</span></div>');

            var photoAdds = $("<div/>", {
                "class": "span12"
            }).append($("<div/>").append("<span>Update Type:</span><span>" + currItem.UpdateTypes + "</span> ")).append($("<div/>").append(
                                 "<span>Category:</span><span>" + getCategoriesArray(currItem.Categories) + "</span> "));

            photoRows.push($("<div/>", {
                "class": "photo row"
            }).append(img).append(photoInfo).append(photoWeb).append(photoAdds));

        });
        

        $("#content-holder").append(photoRows);
    });
});

function getCategoriesArray(categories) {
    var resArray = new Array();
    $(categories).each(function() {
        resArray.push(this.Value);
    });
    return resArray;
}