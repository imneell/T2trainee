
function DisplayCustomer() {
    $.ajax({
        type: 'GET', //HTTP GET Method
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        url: 'https://localhost:44303/Employee/LoginAuth',
        success: Display

    });
}

function Display(response) {
    var customer = response;
    var x = document.getElementById('name');
    var x1 = document.getElementById('id');
    var x2 = document.getElementById('age');
    x.innerHTML = (customer.customerName);
    x1.innerHTML = (customer.customerId);
    x2.innerHTML = (customer.customerAge);

}
