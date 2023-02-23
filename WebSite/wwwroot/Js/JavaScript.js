$(document).ready(function () {

    $('#register').click(function () {
        var Username = $('input[name=Username]').val().trim();
        var Email = $('input[name=Email]').val().trim();
        var regPassword = $('input[name=regPassword]').val().trim();
        var confirmPassword = $('input[name=confirmPassword]').val().trim();

        var phoneNumber = $('input[name=phoneNumber]').val();

        var firstName = $('input[name=firstName]').val().trim();
        var lastName = $('input[name=lastName]').val().trim();

        var dateOfBirth = $('input[name=dateOfBirth]').val().trim();
        var Gender = $('select[name=Gender]').val();
        var Country = $('select[name=Country]').val();

        if (Username == "" || Email == "" || regPassword == "" || confirmPassword == ""
            || firstName == "" || lastName == "") {
            alert("Please Fill All empty Fields!");
        }
        else if (regPassword != confirmPassword) {
            alert("Passwords must match!");
        } else {
            $.ajax({
                url: "/Home/Registration",
                method: "post",
                data: {
                    "Username": Username, "Email": Email, "regPassword": regPassword, "confirmPassword": confirmPassword,
                    "phoneNumber": phoneNumber, "firstName": firstName, "lastName": lastName, "dateOfBirth": dateOfBirth,
                    "Gender": Gender, "Country": Country
                },
                success: function (response) {
                    if (response.isRedirect) {
                        window.location.href = response.redirectUrl;
                    } else if (response == "") {
                        cleanRegistrationFields();
                        alert("Invalid input!");
                    }
                    else if (response == "Successful") {
                        cleanRegistrationFields();
                        alert("You registered successfully!")
                    }
                    else if (response == "Error") {
                        cleanRegistrationFields();
                        alert("Some error occured!")
                    }
                    else {
                        $('input[name=regPassword]').val('');
                        $('input[name=confirmPassword]').val('');
                        $('#displayErrors').html("");
                        printErrors(response);
                    }
                },
                error: function () {
                    alert("Please contact system administrator!");
                }
            });
        }


    });
    $('#logInButton').click(function () {
        var UsernameOrEmail = $('[name=UsernameOrEmail]').val().trim();
        var logPassword = $('[name=logPassword]').val().trim();

        if (UsernameOrEmail == "" || logPassword == "") {
            alert("Please fill in all fields!");
        } else {
            $.ajax({
                url: "/Login/LogIn",
                method: "post",
                data: {
                    "UsernameOrEmail": UsernameOrEmail, "logPassword": logPassword
                },
                success: function (response) {debugger
                    if (response.isRedirect) {
                        window.location.href = response.redirectUrl;
                    }
                    else if (response == "") {
                        alert("Email couldn't found!")
                    }
                    else {
                        alert(response);
                    }
                },
                error: function () {
                    alert("Please contact system administrator!");
                }
            });
        }
    });

    $('#recoverPassword').click(function () {
        debugger
        var Email = $('[name=Email]').val().trim();

        if (Email == "") {
            alert("Please fill in all fields!");
        } else {
            $.ajax({
                url: "/Login/ForgotPassword",
                method: "post",
                data: {
                    "Email": Email
                },
                success: function (response) {
                    debugger
                    if (response.isRedirect) {
                        window.location.href = response.redirectUrl;
                    }
                    else if (response == "EmailError") {

                        alert("Could not send email!");

                    }
                    else if (response == "UserError") {

                        alert("User with this email does not exist!");

                    }
                    else {
                    }
                },
                error: function () {
                    alert("Please contact system administrator!");
                }
            });
        }


    });

    $('#recPasswordButton').click(function () {
        debugger
        var email = $('input[name=Email]').val().trim();;
        var newPassword = $('input[name=newPassword]').val().trim();
        var confirmPassword = $('input[name=confirmPassword]').val().trim();

        if (email == "") {
            alert("Please contact system administrator!");
        }
        else if (newPassword == "" || confirmPassword == "") {
            alert("Please Fill All empty Fields!");
        }
        else if (newPassword != confirmPassword) {
            alert("Passwords must match!");
        }
        else {
            $.ajax({
                url: "/Login/RecoverPassword",
                method: "post",
                data: {
                    "email": email, "newPassword": newPassword, "confirmPassword": confirmPassword
                },
                success: function (response) {
                    debugger
                    if (response.isRedirect) {
                        window.location.href = response.redirectUrl;
                    }
                    else if (response == "") {
                        cleanRegistrationFields();
                        alert("Invalid input!");
                    }
                    else if (response == "Successful") {
                        cleanRegistrationFields();
                        alert("You Recovered successfully!")
                    }
                    else if (response == "Error") {
                        cleanRegistrationFields();
                        alert("Some error occured!")
                    }
                    else {
                        $('#displayErrors').html("");
                        printErrors(response);
                        $('input[name=newPassword]').val('');
                        $('input[name=confirmPassword]').val('');
                    }
                },
                error: function () {
                    alert("Please contact system administrator!");
                }
            });
        }
    });




    $('#SendFeedback').click(function () {
        var feedbackName = $('[name=feedbackName]').val().trim();
        var feedbackText = $('[name=feedbackText]').val();
        var starLevel = ""; debugger
        if (document.querySelector('input[name="rating"]:checked')) {
            starLevel = document.querySelector('input[name="rating"]:checked').value;
        }

        if (feedbackName == "") {

            feedbackName = "Anonymous";
        }
        if (feedbackText == "" || starLevel == "") {
            alert("Please Fill All empty Fields!");
        } else {
            $.ajax({
                url: "/Home/CreateFeedback",
                method: "post",
                data: {
                    "feedbackName": feedbackName, "feedbackText": feedbackText, "starLevel": starLevel
                },
                success: function (response) {
                    if (response.isRedirect) {
                        window.location.href = response.redirectUrl;
                    } else if (response == "") {
                        alert("Invalid input!");
                    }
                    else if (response == "Successful") {
                        alert("Submited Successfully!")
                    }
                    else if (response == "Error") {
                        alert("Some error occured!")
                    }

                },
                error: function () {
                    alert("Please contact system administrator!");
                }
            });
        }
    });
    

});

function printErrors(list) {
    debugger
    for (var i = 0; i < list.response.length; i++) {
        $('#displayErrors').append("<p>" + list.response[i].description + "</p>");
    }
}

function cleanRegistrationFields() {
    $('input[name=firstName]').val('');
    $('input[name=lastName]').val('');
    $('input[name=Username]').val('');
    $('input[name=Email]').val('');
    $('input[name=regPassword]').val('');
    $('input[name=confirmPassword]').val('');
    $('input[name=phoneNumber]').val('');
    $('input[name=dateOfBirth]').val('');
    $('select[name=Gender]').val('');
    $('select[name=Country]').val('');
}

/*function ValidateEmail(mail) {
    if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(myForm.emailAddr.value)) {
        return (true)
    }
    alert("You have entered an invalid email address!")
    return (false)
}*/


function setCookie(cname, cvalue, exdays) {
    const d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    let expires = "expires=" + d.toGMTString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}

function getCookie(cname) {
    let name = cname + "=";
    let decodedCookie = decodeURIComponent(document.cookie);
    let ca = decodedCookie.split(';');
    for (let i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

function checkCookie() {
    let user = getCookie("username");
    if (user != "") {
        $('#footerCookies').hide();
    } else {
        $('#footerCookies').show();
        const dateTimeNow = new Date();
        let user = dateTimeNow.toString();
        if (user != "" && user != null) {
            setCookie("username", user, 30);
        }
    }
}



$(function () {
    var radios = document.forms[0];
    var i;
    var j;
    var starLevelToDisplay = document.querySelector('input[name="starLevelToDisplay"]').value;
    var radio = document.getElementsByName("rating");
    if (starLevelToDisplay != 0) {
        for (i = 1; i < radios.length; i++) {
            if (radios[i].value == starLevelToDisplay) {
                radios[i].checked = true;
                for (j = 0; j < radio.length; j++) {
                    radio[j].disabled = true;
                    if (radio[j].value == starLevelToDisplay) {
                        radio[j].disabled = false;
                    }
                }

                break;
            }
        }
    }

});







