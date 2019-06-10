function save_options() {
    var color = document.getElementById('color').value;
    alert(color);
}

function restore_options() {
    // load data from storage ...
    alert("Load Option State");
}

document.addEventListener('DOMContentLoaded', restore_options);
document.getElementById('save').addEventListener('click', save_options);