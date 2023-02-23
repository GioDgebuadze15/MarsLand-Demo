var createRoomBtn = document.getElementById('create-room-btn')
var createRoomModal = document.getElementById('create-room-modal')

if (createRoomBtn != null) {
createRoomBtn.addEventListener('click', function () {
    createRoomModal.classList.add('active')
})
}

function closeModal() {
    createRoomModal.classList.remove('active')
    editRoomNameModal.classList.remove('active')
}


var editRoomNameBtn = document.getElementById('edit-room-name-btn')
var editRoomNameModal = document.getElementById('edit-room-name-modal')

if (editRoomNameBtn != null) {
    editRoomNameBtn.addEventListener('click', function () {
        editRoomNameModal.classList.add('active')
    })
}





