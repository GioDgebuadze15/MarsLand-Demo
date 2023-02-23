var CommentBuilder = function () {
    debugger
    var comment = null;
    var span = null;
    var img = null;
    var div = null;
    var authorDiv = null;
    var a = null;
    var textDiv = null;
    var comAfterEdit = null;
    var divBtns = null;
    var replyBtn = null;
    var subComComponent = null;
    var mainCommBtnDiv = null;
    var leaveSubCommentDiv = null;
    var hiddenInputOne = null;
    var hiddenInputTwo = null;
    var hiddenInputThree = null;
    var subComBody = null;


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
            img.classList.add("com-prof-img");
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


            replyBtn = document.createElement("button")
            replyBtn.textContent = "Reply"
            replyBtn.setAttribute("onClick", "ShowSubCommentDiv("+data.mainCommentId+")")
            replyBtn.classList.add("leave-comment-btn")

            textDiv = document.createElement("div")
            textDiv.classList.add("comment-text-div")

            comAfterEdit = document.createElement("div")
            comAfterEdit.classList.add("comment-after-edit")
            comAfterEdit.id = data.mainCommentId;

            comAfterEdit.appendChild(document.createTextNode(data.text))

            divBtns = document.createElement("div")
            divBtns.classList.add("comment-time-div")

            mainCommBtnDiv = document.createElement("div")
            mainCommBtnDiv.classList.add("mainCommBtnDiv")
            mainCommBtnDiv.id = data.mainCommentId;

            subComComponent = document.createElement("div")
            subComComponent.classList.add("sub-comment-component")
            subComComponent.id = data.mainCommentId
            subComComponent.style.display = 'none'

            leaveSubCommentDiv = document.querySelector(".leaveSubCommentDiv")
            hiddenInputOne = document.querySelector(".leaveSubCommentDiv input[name=PostId]")
            hiddenInputTwo = document.querySelector(".leaveSubCommentDiv input[name=MainCommentId]")
            hiddenInputThree = document.querySelector(".leaveSubCommentDiv input[name=CommentText]")

            hiddenInputOne.value = data.postId;
            hiddenInputTwo.value = data.mainCommentId;
            hiddenInputThree.id = data.mainCommentId;

            subComBody = document.createElement("div")
            subComBody.classList.add("sub-comment-body")
            subComBody.id = data.mainCommentId;

            textDiv.appendChild(comAfterEdit);
            divBtns.appendChild(replyBtn);
            divBtns.appendChild(mainCommBtnDiv);
            textDiv.appendChild(divBtns);
            div.appendChild(textDiv);
            subComComponent.appendChild(subComBody);
            subComComponent.appendChild(leaveSubCommentDiv);
            divBtns.appendChild(subComComponent);

            comment.id = data.mainCommentId;
            return this;
        },
        build: function () {
            comment.appendChild(span);
            comment.appendChild(div);
            return comment;
        }
    }
}