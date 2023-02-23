$(document).ready(function () {

    $("#sendFriendRequestButton").click(function () {
        var SenderUserName = $('input[name=SenderUserName]').val().trim();
        var ReceiverUserId = $('input[name=ReceiverUserId]').val().trim();

        if (SenderUserName == "" || ReceiverUserId == "") {
            alert("Couldn't Send Friend Request!");
        }
        else {
            $.ajax({
                url: "/Friends/SendFriendRequest",
                method: "post",
                data: {
                    "SenderUserName": SenderUserName, "ReceiverUserId": ReceiverUserId
                },
                success: function (response) {
                    if (response.isRedirect) {
                        window.location.href = response.redirectUrl;
                    }
                    else if (response == "Successful") {
                        alert("Friend Request Successfully Sent");
                    }
                },
                error: function () {
                    alert("Please contact system administrator!");
                }
            });
        }


    });

});








