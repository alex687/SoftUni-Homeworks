function removeField(ev) {
    var button = ev.target;
    if (button.name == 'remove') {
        var parent = button.parentNode;
        var wrapper = parent.parentNode;
        wrapper.removeChild(parent);
    }
}

function addFieldProgrammingLang() {
    var div = document.createElement('div');
    div.innerHTML = '<input type="text" name="Computer Skills[Programming Languages][Language][]" pattern="[A-Za-zА-яа-я]{2,20}">' +
        '<select name="Computer Skills[Programming Languages][Skill Level][]">' +
        '<option value="beginner">Beginner</option>' +
        '<option value="average">Average</option>' +
        '<option value="excellent">Excellent</option>' +
        '</select>' +
        '<input type="button" name="remove" value="X">';

    div.querySelector("input[name=remove]").addEventListener('click', removeField);
    document.getElementById('programmingLang').appendChild(div);
}


function addFieldLang() {
    var div = document.createElement('div');
    div.innerHTML = '<input type="text" name="Other Skills[Languages][Language][]" pattern="[A-Za-zА-яа-я]{2,20}">' +
        '<select name="Other Skills[Languages][Comprehension][]">' +
        '<option value="comprehension">-Comprehension-</option>' +
        '<option value="beginner">Beginner</option>' +
        '<option value="average">Average</option>' +
        '<option value="excellent">Excellent</option>' +
        '</select>' +
        '<select name="Other Skills[Languages][Reading][]">' +
        '<option value="reading">-Reading-</option>' +
        '<option value="beginner">Beginner</option>' +
        '<option value="average">Average</option>' +
        '<option value="excellent">Excellent</option>' +
        '</select>' +
        '<select name="Other Skills[Languages][Writing][]">' +
        '<option value="writing">-Writing-</option>' +
        '<option value="beginner">Beginner</option>' +
        '<option value="average">Average</option>' +
        '<option value="excellent">Excellent</option>' +
        '</select>' +
        '<input type="button" name="remove" value="X">';

    div.querySelector("input[name=remove]").addEventListener('click', removeField);
    document.getElementById('Lang').appendChild(div);
}

window.onload = function () {

    document.getElementById('AddProgramLang').addEventListener('click', addFieldProgrammingLang);
    document.getElementById('AddLang').addEventListener('click', addFieldLang);

    var removeButtons = document.getElementsByName("remove");
    for (removeId in removeButtons) {
        removeButtons[removeId].addEventListener('click', removeField)
    }
}