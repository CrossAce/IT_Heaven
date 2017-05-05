
var myArray = [];
var selectedItem = "";
var previousSelectedItem = "";

$(function () {
    $('#mainDrop').change(function () {
        var element = document.getElementById('optionalForm');
        if ($(this).val() == "PC Components") {
            selectedItem = $(this).val();
            element.style.display = "block";
            getInfo("GetInfoJS?q=1");
            
        }
        else if ($(this).val() == "Computers") {
            selectedItem = $(this).val();
            element.style.display = "block";
            getInfo("GetInfoJS?q=0");

        }
        else if ($(this).val() == "Peripherals") {
            selectedItem = $(this).val();
            element.style.display = "block";
            getInfo("GetInfoJS?q=2");

        }
        else if ($(this).val() == "Smartphone Accessories" || $(this).val() == "Tablet Accessories") {
            selectedItem = $(this).val();
            element.style.display = "block";
            getInfo("GetInfoJS?q=3");

        }
        else if ($(this).val() == "TVs") {
            selectedItem = $(this).val();
            element.style.display = "block";
            getInfo("GetInfoJS?q=5");

        }
        else if ($(this).val() == "Audio systems") {
            selectedItem = $(this).val();
            element.style.display = "block";
            getInfo("GetInfoJS?q=6");

        }
        else if ($(this).val() == "Headphones") {
            selectedItem = $(this).val();
            element.style.display = "block";
            getInfo("GetInfoJS?q=7");

        }
        else if ($(this).val() == "Games") {
            selectedItem = $(this).val();
            element.style.display = "block";
            getInfo("GetInfoJS?q=8");

        }
        else {
            element.style.display = "none";
        }

        if (selectedItem != previousSelectedItem)
            setTimeout(addOptions, 500);
        previousSelectedItem = selectedItem;
    });
});

function removeOptions(selectbox) {
    var i;
    for (i = selectbox.options.length - 1 ; i >= 0 ; i--) {
        selectbox.remove(i);
    }
}
function addOptions() {

    
    var select = document.getElementById("selectAdditional");
    removeOptions(select);
    var item = 0;
    while (item < myArray.length) {
        var opt = myArray[item];
        var el = document.createElement("option");
        console.log(opt + " ");
        el.textContent = opt;
        el.value = opt;
        select.appendChild(el);
        item++;
    }
    
}
function getInfo(info) {

    myArray = [];
    if (selectedItem != previousSelectedItem) {
        $.ajax({
            type: "GET",
            url: "http://" +  location.hostname + ":"+location.port + "/Article/"+info,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {

                for (var i = 0; i < response.length; i++) {
                    myArray.push(response[i]);

                }
            }

        });
    }
}


$(function () {
    $('#AddToCart').click(function (e) {
        e.preventDefault();
        var id = location.pathname.split('/')[3];
        var host = location.hostname;
        var doc = document.getElementById("AddToCart");
        $.ajax({
            type: "GET",
            url: "AddToCartid=" + id,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response == "1") {
                    doc.innerHTML = "Added to Cart";
                }
                else {
                    doc.innerHTML = "Add to Cart";
                }
            }

        });
    });
});
function RemoveFromCart(id) {
              
        var doc = document.getElementById(id);
        $.ajax({
            type: "GET",
            url: "Remove/" + id,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response == "1") {
                    doc.remove();
                }              
            }

        });
   
}

function ChangeRole(id,name)
{
    var doc = document.getElementById(name);
    $.ajax({
        type: "POST",
        url: "ChangeRole/" + id,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {          
            doc.innerHTML = response;           
        }

    });
}
function DeleteUser(id) {

    var doc = document.getElementById(id);
    if (confirm("Do you really want to delete this user?"))
    {
        $.ajax({
            type: "POST",
            url: "Delete/" + id,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response == "1") {
                    doc.remove();
                }
            }

        });
    } 
}

    function openNav() {
        document.getElementById("deleteOverlay").style.height = "100%";
    }

    function closeNav() {
        document.getElementById("deleteOverlay").style.height = "0%";
    }
