var SubCommentBuilder = function () {
    debugger
    var comment = null;
    var span = null;
    var img = null;
    var div = null;
    var authorDiv = null;
    var a = null;
    var textDiv = null;
    var subComAfterEdit = null;
    var subCommBtnDiv = null;
    var divBtns = null;
    var hiddenInputOne = null;

    return {
        createComment: function (classList) {
            comment = document.createElement("div")
            if (classList === undefined)
                classList = [];

            for (var i = 0; i < classList.length; i++) {
                comment.classList.add(classList[i])
            }

            comment.classList.add('comment-body-div')
            return this;
        },
        withUser: function (data) {debugger
            span = document.createElement("span");
            img = document.createElement("img");
            if (data.profileImageName === undefined) {
                if (data.gender === 1) {
                    img.src = "/Tools/Images/ProfileImageFemaleTemplate.png";
                }
                else {
                    img.src = "/Tools/Images/ProfileImageMaleTemplate.png";
                }
            }
            else {
                img.src = "/Tools/ProfileImages/"+data.profileImageName;
            }
            img.classList.add("rounded-circle");
            img.classList.add("sm-prof-img");
            span.appendChild(img)
            return this;
        },
        withCommentText: function (data) {
            div = document.createElement("div")

            div.classList.add("group-comment-div")

            authorDiv = document.createElement("div")
            authorDiv.classList.add("comment-author")

            a = document.createElement("a")
            a.appendChild(document.createTextNode(data.firstName + " " + data.lastName))
            a.classList.add("fullname")

            a.href = "/User/UserProfileView/" + data.userId;

            authorDiv.appendChild(a)
            div.appendChild(authorDiv)

            textDiv = document.createElement("div")
            textDiv.classList.add("comment-text-div")

            subComAfterEdit = document.createElement("div")
            subComAfterEdit.classList.add("sub-comment-after-edit")
            subComAfterEdit.id = data.subCommentId;

            subComAfterEdit.appendChild(document.createTextNode(data.text))

            divBtns = document.createElement("div")
            divBtns.classList.add("comment-time-div")

            subCommBtnDiv = document.createElement("div")
            subCommBtnDiv.classList.add("subCommBtnDiv")
            subCommBtnDiv.id = data.subCommentId;

            hiddenInputOne = document.querySelector(".leaveSubCommentDiv input[name=SubCommentId]")
            hiddenInputOne.value = data.subCommentId;

            textDiv.appendChild(subComAfterEdit);
            divBtns.appendChild(subCommBtnDiv);
            textDiv.appendChild(divBtns);
            div.appendChild(textDiv);

            comment.id = data.subCommentId;
            return this;
        },
        build: function () {
            comment.appendChild(span);
            comment.appendChild(div);
            return comment;
        }
    }
}