var _connectionId = '';
var _connection = null;

var _mainComId = null;

var ListOfPosts;
function ShowPostComments(e) {
    debugger
    var _postId = String(e);
    let PostId = parseInt(e);
    let IsOpen = true;
    let NeedToOpen = true;
    var singleObj = { PostId, IsOpen };


    if (ListOfPosts === undefined) {
        ListOfPosts = [];
        ListOfPosts.push(singleObj);
    }
    else {
        let AlreadyExists = false;
        for (var i = 0; i < ListOfPosts.length; i++) {
            if (ListOfPosts[i].PostId == PostId) {
                if (ListOfPosts[i].IsOpen == true) {
                    ListOfPosts[i].IsOpen = false;
                    NeedToOpen = false;
                }
                else {
                    ListOfPosts[i].IsOpen = true;
                }
                AlreadyExists = true;
                break;
            }
        }
        if (!AlreadyExists) {
            ListOfPosts.push(singleObj);
        }
    }
    if (NeedToOpen) {

        "use strict";
        debugger
        _connection = new signalR.HubConnectionBuilder()
            .withUrl("/postHub")
            .build();

        _connection.on("ReceiveComment", function (data) {
            debugger
            console.log("Connection is on");
            console.log(data.text);

            var comment = CommentBuilder()
                .createComment()
                .withUser(data)
                .withCommentText(data)
                .build();
            prependMainComment(_postId, comment);
            updateNumOfComs(_postId, data.numOfComments);

            _mainComId = data.mainCommentId;
            
        })
        _connection.on("DeleteComment", function (data) {
            debugger
            console.log("Connection is on");

            var divs = document.querySelectorAll('.comment-body-div');
            var div;

            for (var i = 0; i < divs.length; i++) {
                if (data.mainCommentId == divs[i].id) {
                    div = divs[i];
                    break;
                }
            }

            if (div !== undefined && div !== null) {
                div.remove();

            }
            updateNumOfComs(PostId, data.numOfComments);
        })
        _connection.on("EditComment", function (data) {
            debugger
            console.log("Connection is on");

            var divs = document.querySelectorAll('.comment-after-edit');
            var div;

            for (var i = 0; i < divs.length; i++) {
                if (data.mainCommentId == divs[i].id) {
                    div = divs[i];
                    break;
                }
            }

            if (div !== undefined && div !== null) {
                div.innerHTML = data.text;

            }
        })


        _connection.on("ReceiveSubComment", function (data) {
            debugger
            console.log("Connection is on");
            console.log(data.text);

            var comment = SubCommentBuilder()
                .createComment()
                .withUser(data)
                .withCommentText(data)
                .build();
            appendSubComment(data.mainCommentId, comment);
            updateNumOfComs(PostId, data.numOfComments);

        })
        _connection.on("DeleteSubComment", function (data) {
            debugger
            console.log("Connection is on");

            var divs = document.querySelectorAll('.sub-comment-body-div');
            var div;

            for (var i = 0; i < divs.length; i++) {
                if (data.subCommentId == divs[i].id) {
                    div = divs[i];
                    break;
                }
            }

            if (div !== undefined && div !== null) {
                div.remove();

            }
            updateNumOfComs(PostId, data.numOfComments);
        })
        _connection.on("EditSubComment", function (data) {
            debugger
            console.log("Connection is on");

            var divs = document.querySelectorAll('.sub-comment-after-edit');
            var div;

            for (var i = 0; i < divs.length; i++) {
                if (data.subCommentId == divs[i].id) {
                    div = divs[i];
                    break;
                }
            }

            if (div !== undefined && div !== null) {
                div.innerHTML = data.text;

            }
        })



        _connection.start()
            .then(function () {
                _connection.invoke('joinPost', _postId);
                showHideMainCommentsDiv(_postId);
            })
            .catch(function (err) {
                console.log(err)
            })
    }
    else {
        _connection.invoke('leavePost', _postId);
        showHideMainCommentsDiv(_postId);
    }
}

function showHideMainCommentsDiv(_postId) {
    var leaveComDivs = document.querySelectorAll(".leaveCommentDiv");

    var leaveComDiv;

    for (var i = 0; i < leaveComDivs.length; i++) {
        if (leaveComDivs[i].id == parseInt(_postId)) {
            leaveComDiv = leaveComDivs[i];
            break;
        }
    }
    if (leaveComDiv.style.display === "none" || leaveComDiv.style.display === "") {
        leaveComDiv.style.display = "block";
    }
    else {
        leaveComDiv.style.display = "none";
    }
}

var sendComment = function (event) {
    debugger
    var postId = event.target[1].value;
    event.preventDefault();
    var data = new FormData(event.target);


    axios.post('/Forum/CommentOnPost', data)
        .then(response => {
            console.log("Comment Sent!")
            try {debugger
                clearMainCommentInput(postId);
                updateCommentButtons(_mainComId, response);

            }
            catch (error) {
                console.error(error);
            }
        })
        .catch(err => {
            console.log("Failed to comment!")
        })

}

function updateCommentButtons(mainCommentId, response) {
    debugger
    var divs = document.querySelectorAll(".mainCommBtnDiv");
    var div;
    for (var i = 0; i < divs.length; i++) {
        if (divs[i].id == mainCommentId) {
            div = divs[i];
            break;
        }
    }
    if (div !== undefined && div !== null) {

        div.innerHTML = response.data;
    }
}
function updateSubCommentButtons(subCommentId, response) {
    debugger
    var divs = document.querySelectorAll(".subCommBtnDiv");
    var div;
    for (var i = 0; i < divs.length; i++) {
        if (divs[i].id == subCommentId) {
            div = divs[i];
            break;
        }
    }
    if (div !== undefined && div !== null) {

        div.innerHTML = response.data;
    }
}

function clearMainCommentInput(e) {
    debugger
    var inputs = document.querySelectorAll(".main-comment-input");
    var input;

    for (var i = 0; i < inputs.length; i++) {
        if (parseInt(e) == inputs[i].id) {
            input = inputs[i];
            break;
        }
    }

    if (input.value != '') {
        input.value = '';

    }
}

function prependMainComment(postId, comment) {
    debugger
    var divs = document.querySelectorAll('.main-comment-body');
    var div;

    for (var i = 0; i < divs.length; i++) {
        if (parseInt(postId) == divs[i].id) {
            div = divs[i];
            break;
        }
    }

    if (div !== undefined || div !== null) {
        div.prepend(comment);
        var viewComments = document.querySelectorAll(".main-comment-component");
        var viewComment;

        for (var i = 0; i < viewComments.length; i++) {
            if (viewComments[i].id == parseInt(postId)) {
                viewComment = viewComments[i];
                break;
            }
        }

        var btns = document.querySelectorAll(".view-comment-btn")
        var btn;

        for (var i = 0; i < btns.length; i++) {
            if (btns[i].id == parseInt(postId)) {
                btn = btns[i];
                break;
            }
        }


        viewComment.style.display = "block"
        $(btn).html("Hide Comments")
    }
}

function updateNumOfComs(postId, numOfComments) {
    debugger
    var spans = document.querySelectorAll(".numOfComsSpan");
    var span;

    for (var i = 0; i < spans.length; i++) {
        if (spans[i].id == postId) {
            span = spans[i];
            break;
        }
    }

    if (span !== undefined && span !== null) {
        $(span).html(numOfComments + ' Comments');

    }
}

function ShowMainComments(e) {
    debugger
    var postId = e;

    if (postId !== undefined || postId != 0) {
        var viewComments = document.querySelectorAll(".main-comment-component");
        var viewComment;

        for (var i = 0; i < viewComments.length; i++) {
            if (viewComments[i].id == postId) {
                viewComment = viewComments[i];
                break;
            }
        }

        var btns = document.querySelectorAll(".view-comment-btn")
        var btn;

        for (var i = 0; i < btns.length; i++) {
            if (btns[i].id == postId) {
                btn = btns[i];
                break;
            }
        }

        if (viewComment.style.display === "none" || viewComment.style.display === "") {

            viewComment.style.display = "block"
            $(btn).html("Hide Comments")

            axios.get('/Forum/GetMainCommentComponent', {
                params: {
                    PostId: postId
                }
            })
                .then(response => {
                    viewComment.innerHTML = response.data
                })
                .catch(err => {
                    console.log(err)
                })

        }
        else {
            viewComment.style.display = "none"
            $(btn).html("View Comments")
        }
    }
}

function DeleteComment(event) {
    debugger


    event.preventDefault();
    var data = new FormData(event.target);
    axios.post('/Forum/DeletePostComment', data)
        .then(response => {
            console.log("Comment deleted successfully!")



        })
        .catch(error => {
            console.log("Error occured!", error)
        })

}

function ShowEditMainCommentDiv(e) {
    var mainComId = e;

    if (mainComId !== undefined) {
        var divs = document.querySelectorAll('.editMainCommentDiv');
        var editDiv;

        for (var i = 0; i < divs.length; i++) {
            if (divs[i].id == mainComId) {
                editDiv = divs[i];
                break;
            }
        }

        if (editDiv.style.display === "none" || editDiv.style.display === "") {
            editDiv.style.display = "block";
        }
        else {
            editDiv.style.display = "none";
        }
    }
}

function EditComment(event) {
    debugger
    event.preventDefault();
    var data = new FormData(event.target);
    axios.post('/Forum/EditPostComment', data)
        .then(response => {
            console.log("Comment edited successfully!")
            if (response.data.subCommentId !== undefined && response.data.subCommentId !== null
                && response.data.subCommentId !== 0) {
                ShowEditSubCommentDiv(response.data.subCommentId);
            }
            else {
                ShowEditMainCommentDiv(response.data.mainCommentId);
            }
        })
        .catch(error => {
            console.log("Error occured!", error)
        })
}

function ShowSubCommentDiv(e) {
    debugger
    var mainCommentId = e;



    if (mainCommentId !== undefined && mainCommentId != 0) {
        var viewComments = document.querySelectorAll(".sub-comment-component");
        var viewComment;

        for (var i = 0; i < viewComments.length; i++) {
            if (viewComments[i].id == mainCommentId) {
                viewComment = viewComments[i];
                break;
            }
        }



        if (viewComment.style.display === "none" || viewComment.style.display === "") {

            viewComment.style.display = "block"

            axios.get('/Forum/GetSubCommentComponent', {
                params: {
                    MainCommentId: mainCommentId
                }
            })
                .then(response => {
                    viewComment.innerHTML = response.data
                })
                .catch(err => {
                    console.log(err)
                })
        }
        else {
            viewComment.style.display = "none"
        }
    }
}

var sendSubComment = function (event) {
    debugger
    var mainCommentId = event.target[2].value;


    event.preventDefault();
    var data = new FormData(event.target);
    axios.post('/Forum/CommentOnPost', data)
        .then(response => {
            console.log("Sub comment Sent!")
            try {debugger
                clearSubCommentInput(mainCommentId);
                updateSubCommentButtons(_subComId, response);
            }
            catch (error) {
                console.error(error);
            }
        })
        .catch(err => {
            console.log("Failed to comment!")
        })

}


function clearSubCommentInput(e) {
    debugger
    var inputs = document.querySelectorAll(".sub-comment-input");
    var input;

    for (var i = 0; i < inputs.length; i++) {
        if (parseInt(e) == inputs[i].id) {
            input = inputs[i];
            break;
        }
    }

    if (input.value != '') {
        input.value = '';

    }
}

function appendSubComment(MainCommentId, comment) {
    debugger
    var divs = document.querySelectorAll('.sub-comment-body');
    var div;

    for (var i = 0; i < divs.length; i++) {
        if (MainCommentId == divs[i].id) {
            div = divs[i];
            break;
        }
    }

    if (div !== undefined && div !== null) {
        div.append(comment);

    }
}

function ShowEditSubCommentDiv(e) {
    var subComId = e;

    if (subComId !== undefined) {
        var divs = document.querySelectorAll('.editSubCommentDiv');
        var editDiv;

        for (var i = 0; i < divs.length; i++) {
            if (divs[i].id == subComId) {
                editDiv = divs[i];
                break;
            }
        }

        if (editDiv.style.display === "none" || editDiv.style.display === "") {
            editDiv.style.display = "block";
        }
        else {
            editDiv.style.display = "none";
        }
    }
}




function LikePost(event) {
    var postId = event.target[0].value;
    debugger
    "use strict";
    var postLikesConnection = new signalR.HubConnectionBuilder()
        .withUrl("/postHub")
        .build();

    postLikesConnection.on("ReceiveLike", function (data) {
        debugger
        console.log("Connection is on");
        console.log(data.numOfLikes);
        updateNumOfLikes(data.postId, data.numOfLikes);
    })

    postLikesConnection.start()
        .then(function () {
            postLikesConnection.invoke('joinPost', postId);
        })
        .catch(function (err) {
            console.log(err)
        })


    window.addEventListener('onunload', function () {
        postLikesConnection.invoke('leavePost', postId);
    })

    event.preventDefault();
    var data = new FormData(event.target);
    axios.post('/Forum/LikePost', data)
        .then(response => {
            console.log("Post liked successfully!")
            updateLikeUnlikeButton(postId, response);

        })
        .catch(error => {
            console.log("Error occured!", error)
        })
}


function UnlikePost(event) {
    var postId = event.target[0].value;
    debugger
    var postLikesConnection = new signalR.HubConnectionBuilder()
        .withUrl("/postHub")
        .build();


    postLikesConnection.on("ReceiveLike", function (data) {
        debugger
        console.log("Connection is on");
        console.log(data.numOfLikes);
        updateNumOfLikes(data.postId, data.numOfLikes);
    })

    postLikesConnection.start()
        .then(function () {
            postLikesConnection.invoke('joinPost', postId);
        })
        .catch(function (err) {
            console.log(err)
        })


    window.addEventListener('onunload', function () {
        postLikesConnection.invoke('leavePost', postId);
    })

    event.preventDefault();
    var data = new FormData(event.target);
    axios.post('/Forum/UnlikePost', data)
        .then(response => {
            debugger
            console.log("Post unliked successfully!")
            updateLikeUnlikeButton(postId, response);

        })
        .catch(error => {
            console.log("Error occured!", error)
        })

}

function updateNumOfLikes(postId, numOfLikes) {
    var spans = document.querySelectorAll(".numOfLikesSpan");
    var span;

    for (var i = 0; i < spans.length; i++) {
        if (spans[i].id == postId) {
            span = spans[i];
            break;
        }
    }


    if (span !== undefined && span !== null) {
        $(span).html(numOfLikes + ' Likes');

    }
}

function updateLikeUnlikeButton(postId, response) {
    debugger
    var divs = document.querySelectorAll(".likeBtnDiv");
    var div;
    for (var i = 0; i < divs.length; i++) {
        if (divs[i].id == postId) {
            div = divs[i];
            break;
        }
    }
    if (div !== undefined && div !== null) {

        div.innerHTML = response.data;
    }
}
