var defaultErrorMessage = "Ups, something went wrong !";


function loadPage(url) {
    $.get(
        url,
        {},
        function (data) {
            $("#mainContent").html(data);
        }
    ).error(function () { alertify.alert(defaultErrorMessage); });
}




function addProduct(url) {
    $.get(
        url,
        {},
        function (data) {
            updateShopCart();
        }
    ).error(function () { alertify.alert(defaultErrorMessage); });
}


function updateShopCart() {
    $.get("ShopCart/MiniShopCart",
        {},
        function (data) {
            $("#miniShopCart").html(data);
        }
    ).error(function () { alertify.alert(defaultErrorMessage); });
}


function showCartMiniDetail(source) {
    $.get("ShopCart/MiniDetail",
        {},
        function (data) {
            $(source).popover({
                content: data,
                html: "true",
                placement: "bottom",
                container: "body"
            });
            $(source).popover("show");
        }
    ).error(function () { alertify.alert(defaultErrorMessage); });
}


function hideCartMiniDetail(source) {
    $(source).popover("destroy");
}

function viewDetail() {
    $.get("ShopCart/Detail",
        {},
        function (data) {
            $("#mainContent").html(data);
        }
    ).error(function () { alertify.alert(defaultErrorMessage); });
}

function checkout() {
    $.post("ShopCart/ShippingDetails",
        {},
        function (data) {
            $("#mainContent").html(data);
        }
    ).error(function () { alertify.alert(defaultErrorMessage); });
}





var autocompleteAddress;

var addressGMapsToShippingModel = {
    route: "#Street",
    street_number: "#HouseNumber",
    locality: "#CityName",
    postal_code: "#ZipCode"
};


function fillInAddressShippingDetails() {
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


