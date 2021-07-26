
function Login() {
    debugger
    $.ajax({
        type: 'GET', //HTTP GET Method
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        url: 'https://localhost:44303/Employee/LoginAuth',
        success: Display

    });
}

function Display(response) {
    //redirecting to another page
        if (response == true) {
            alert("You will now be redirected.");
            window.location = "https://localhost:44303/Employee/First";
        }

}
