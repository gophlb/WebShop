var defaultErrorMessage = "Ups, something went wrong !";


function loadPage(url, urlParams, whereToLoad) {
    $.get(
        url,
        urlParams,
        function (data) {
            $(whereToLoad).html(data);
        }
    ).error(function () { alertify.alert(defaultErrorMessage); });
}

function closeModal() {
    $("#modal").modal("hide");
}


function showProductInformation(reference) {
    $.get(
        "/Product/GetProductInformation",
        { reference: reference },
        function (data) {
            $("#modalContent").html(data);
            $("#modal").modal();
        }
    ).error(function () { alertify.alert(defaultErrorMessage); });
}


function addProduct(url) {
    $.post(
        url,
        {},
        function (data) {
            $("#totalProducts").text(data);
        }
    ).error(function () { alertify.alert(defaultErrorMessage); });
}


function removeProduct(reference, quantity) {
    $.post(
        "/ShopCart/RemoveProduct",
        {reference: reference, quantity: quantity},
        function (data) {
            if (data.Message !== "") {
                alertify.alert(data.Message);
            }
            else {
                //Should update the Total price too
                //$("#productLine_" + reference).remove();
                //getProductsCount();
                loadPage(data.RedirectTo, {}, "#mainContent");
            }
        }
    );
}



function getProductsCount() {
    loadPage("/ShopCart/GetProductsCount", {}, "#totalProducts");
}




function showCartMiniDetail() {
    $.get("/ShopCart/MiniDetail",
        {},
        function (data) {
            $("#modalContent").html(data);
            $("#modal").modal();
        }
    ).error(function () { alertify.alert(defaultErrorMessage); });
}


function hideCartMiniDetail(source) {
    $(source).popover("destroy");
}

function viewDetail() {
    closeModal();
    loadPage("/ShopCart/Detail", {}, "#mainContent");
}


function checkout() {
    loadPage("/ShopCart/ShippingDetails", {}, "#mainContent");
}





var autocompleteAddress;

var addressGMapsToShippingModel = {
    route: "#Street",
    street_number: "#HouseNumber",
    locality: "#CityName",
    postal_code: "#ZipCode"
};


function fillAddressShippingDetails() {
    var place = autocompleteAddress.getPlace();
    var address_components = place.address_components;

    for (var i = 0; i < address_components.length; i++) {
        var addressType = address_components[i].types[0];
        var addressGeolocalizable = addressGMapsToShippingModel[addressType];
        if (addressGeolocalizable) {
            $(addressGeolocalizable).val(address_components[i]["long_name"]);
        }
    }
}


function setupShippingDetailsForm() {
    autocompleteAddress = new google.maps.places.Autocomplete(document.getElementById('AutocompleteAddress'), { types: ['geocode'] });
    google.maps.event.addListener(autocompleteAddress, 'place_changed', function () { fillAddressShippingDetails(); });
    
    /*
        * jquery.validate doesn't work fine with emails and accepts xxxxx@xxxx
            http://stackoverflow.com/questions/23368961/jquery-validation-plugin-not-working-with-email-type-right
        * stop validating email addresses with regex
            http://davidcel.is/posts/stop-validating-email-addresses-with-regex/
    */
    $("#shippingDetailsForm").validate({
        ignore: [],
        rules: {
            'Title': { required: true },
            'FirstName': { required: true, minlength: 3, maxlength: 100 },
            'LastName': { required: true, minlength: 3, maxlength: 100 },
            'Address': { required: true, minlength: 20, maxlength: 500 },
            'Street': { required: true, minlength: 20, maxlength: 250 },
            'HouseNumber': { required: true, minlength: 1, maxlength: 10 },
            'ZipCode': { required: true, minlength: 2, maxlength: 20 },
            'CityName': { required: true, minlength: 2, maxlength: 250 },
            'Email': { required: true, minlength: 5, maxlength: 200 }
        },
        messages: {
            'Title': { required: 'We need your title, so we can treat you as you deserve :)' },
            'FirstName': {
                required: 'We need your name, if we have to contact you any time'
                , minlength: 'Tell us your name, at least 3 characters'
                , maxlength: 'Are you sure your name is more than 100 characters long?'
            },
            'LastName': {
                required: 'We need your last name, as a legal requirement :('
                , minlength: 'Tell us your last name, at least 3 characters'
                , maxlength: 'Are you sure your last name is more than 100 characters long?'
            },
            'Address': {
                required: 'Your complete address, so we can deliver your shopping :D'
                , minlength: 'Tell us your complete address, at least 20 characters'
                , maxlength: 'Are you sure your address is more than 500 characters long?'
            },
            'Street': {
                required: 'Are you sure you filled correctly the street?'
                , minlength: 'Tell us your street, at least 3 characters'
                , maxlength: 'Are you sure your street is more than 250 characters long?'
            },
            'HouseNumber': {
                required: 'Are you sure you filled correctly the house number?'
                , minlength: 'Tell us your house number, at least 1 characters'
                , maxlength: 'Are you sure your house number is more than 10 characters long?'
            },
            'ZipCode': {
                required: 'Are you sure you filled correctly the zip code?'
                , minlength: 'Tell us your zip code, at least 3 characters'
                , maxlength: 'Are you sure your zip code is more than 20 characters long?'
            },
            'CityName': {
                required: 'Are you sure you filled correctly the city?'
                , minlength: 'Tell us your zip code, at least 2 characters'
                , maxlength: 'Are you sure your zip code is more than 250 characters long?'
            },
            'Email': {
                required: 'We need your email, for further information about tracking'
                , minlength: 'Tell us your email, at least 5 characters'
                , maxlength: 'Are you sure your email is more than 200 characters long?'
            }
        },
        debug: true,
        showErrors: showFormErrors,
        submitHandler: function (form) {
            if ($(form).valid()) {
                $.post(
                    "/ShopCart/Checkout",
                    $(form).serialize(),
                    function (data) {
                        if (data.Message !== "") {
                            alertify.alert(data.Message);
                        }
                        else {
                            loadPage(data.RedirectTo, {}, "#mainContent");
                        }
                    }
                );
            }
        }
    });
}



// Show only first error in the attr "title" of the div, colors the border in red
function showFormErrors(errorMap, errorList) {
    $("div[id^='section_']").attr("title", "");
    $("div[id^='section_']").css("border", "1px solid #888");

    for (var e in errorMap) {
        $("#section_" + e).attr("title", errorMap[e]);
        $("#section_" + e).css("border", "2px solid #f00");

        break;
    }
}


// Show errors in a popover over the button
//function showFormErrors(errorMap, errorList) {
//    var errorMessage = "<ul class='errorListForm'>";
//    for (var e in errorMap) {
//        errorMessage += "<li><span class='fa fa-exclamation-circle spanErrorListForm'></span><span>" + errorMap[e] + "</span></li>";
//    }
//    errorMessage += "</ul>";

//    if (errorMessage !== "<ul class='errorListForm'></ul>") {
//        setTimeout(function () {
//            $("#submitButton").popover({ content: errorMessage, html: true, placement: "top" });
//            $("#submitButton").popover("show");
//        }, 250);

//        setTimeout(function () { $("#submitButton").popover("destroy"); }, 3500);
//    }
//}