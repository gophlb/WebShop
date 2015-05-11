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