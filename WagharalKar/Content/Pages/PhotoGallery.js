
$(document).ready(function () {
    getPhotolist();

});
var savephoto = function () {

    var id = $("#hdnId").val();
    var title = $("#txtTitle").val();
    var image1 = $("#txtImage1").val();
    var image2 = $("#txtImage2").val();
    var type = $("#txtType").val();
    var createdate = $("#txtCreateDate").val();
    var updatedate = $("#txtUpdateDate").val();
    var createdby = $("#txtCreatedBy").val();
    var updatedby = $("#txtUpdatedBy").val();

    var model = { Id: id, Title: title, Image1: image1, Image2: image2, Type: type, CreateDate: createdate, UpdateDate: updatedate, CreatedBy: createdby, UpdatedBy: updatedby };

    $.ajax({
        url: "/PhotoGallery/SavePhoto",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (responce) {
            alert(responce.Message);
            getPhotolist();
        }
    });

}
var getPhotolist = function () {

    $.ajax(
        {
            url: "/PhotoGallery/getPhotolist",
            method: "Post",

            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            success: function (responce) {
                var html = "";
                $("#tblPhotoGallery tbody").empty();
                $.each(responce.model, function (Index, elementValue) {
                    html += "<tr><td>" + elementValue.Id +
                        "</td><td>" + elementValue.Title +
                        "</td><td>" + elementValue.Image1 +
                        "</td><td>" + elementValue.Image2 +
                        "</td><td>" + elementValue.Type +
                        "</td><td>" + elementValue.CreateDate +
                        "</td><td>" + elementValue.UpdateDate +
                        "</td><td>" + elementValue.CreatedBy +
                        "</td><td>" + elementValue.UpdatedBy +
                        "</td><td> <input type = 'button' value = 'Delete' onClick ='DeletePhotoGallery(" + elementValue.Id + ")'/></td><td><input type='button' value='Edit' onClick='EditPhotoGallery(" + elementValue.Id + ")' /></td></tr>";


                });
                $("#tblPhotoGallery tbody").append(html);
            }
        })

}

var DeletePhotoGallery = function (Id) {
    debugger;
    model = {
        Id:Id
    },
        $.ajax({
            url: "/PhotoGallery/DeletePhotoGallery",
            method: "post",
            data: JSON.stringify(model),
            dataType: "json",
            contentType: "application/json:charset=utf-8",
            success: function (response) {
                alert(response.model);
            }

        })
}
var EditPhotoGallery = function (Id) {
    debugger;
    var model = { Id: Id };
    $.ajax({
        url: "/PhotoGallery/EditPhotoGallery",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json:charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            $("#txthid").val(response.model.Id);
            $("#txtTitle").val(response.model.Title);
            $("#txtImage1").val(response.model.Image1);
            $("#txtImage2").val(response.model.Image2);
            $("#txtType").val(response.model.Type);
            $("#txtCreateDate").val(response.model.CreateDate);
            $("#txtUpdateDate").val(response.model.UpdateDate);
            $("#txtCreatedBy").val(response.model.CreatedBy);
            $("#txtUpdatedBy").val(response.model.UpdatedBy);
        }
    })

}