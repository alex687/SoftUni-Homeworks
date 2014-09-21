<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>CV Generator</title>
    <script src="scripts/cv-script.js" defer></script>
</head>
<body>
<form action="generator.php" method="post">
    <fieldset>
        <legend>Personal Information</legend>
        <input type="text" name="Personal Information[First Name]" placeholder="First Name" pattern="[A-Za-zА-яа-я]{2,20}"></br>
        <input type="text" name="Personal Information[Last Name]" placeholder="Last Name" pattern="[A-Za-zА-яа-я]{2,20}"></br>
        <input type="email" name="Personal Information[Email]" placeholder="Email" pattern="[\w]+@[\w]+\.[\w]+"></br>
        <input type="text" name="Personal Information[Phone Number]" placeholder="Phone Number" pattern="[\d+-]+">

        <div>
            <label for="female">Female</label><input id="female" type="radio" name="Personal Information[Gender]"
                                                     value="Female">
            <label for="male">Male</label><input id="male" type="radio" name="Personal Information[Gender]"
                                                 value="Male">
        </div>
        <div>
            <label for="birthDay">Birth Day</label></br>
            <input id="birthDay" type="text" name="Personal Information[Birth Date]" placeholder="dd-mm-yyyy">
        </div>
        <div>
            <label>Nationality</label></br>
            <select name="Personal Information[Nationality]">
                <option value="Bulgarian">Bulgarian</option>
                <option value="England">England</option>
                <option value="Other">Other</option>
            </select>
        </div>
    </fieldset>

    <fieldset>
        <legend>Last Work Position</legend>
        <div>
            <label for="company">Company Name</label>
            <input id="company" type="text" name="Last Work Position[Company Name]" pattern="[\w]{2,20}">
        </div>
        <div>
            <label for="from">From</label>
            <input id="from" type="text" name="Last Work Position[From]" placeholder="dd-mm-yyyy">
        </div>
        <div>
            <label for="to">To</label>
            <input id="to" type="text" name="Last Work Position[To]" placeholder="dd-mm-yyyy">
        </div>
    </fieldset>

    <fieldset>
        <legend>Computer Skills</legend>
        <div id="programmingLang">
            <div>
                <input type="text" name="Computer Skills[Programming Languages][Language][]" pattern="[A-Za-zА-яа-я]{2,20}">
                <select name="Computer Skills[Programming Languages][Skill Level][]">
                    <option value="beginner">Beginner</option>
                    <option value="average">Average</option>
                    <option value="excellent">Excellent</option>
                </select>
                <input type="button" name="remove" value="X">
            </div>
        </div>
        <input type="button" id="AddProgramLang" value="Add Language">
    </fieldset>

    <fieldset>
        <legend>Other Skills</legend>
        <div id="Lang">
            <div>
                <input type="text" name="Other Skills[Languages][Language][]" pattern="[A-Za-zА-яа-я]{2,20}">
                <select name="Other Skills[Languages][Comprehension][]">
                    <option value="comprehension">-Comprehension-</option>
                    <option value="beginner">Beginner</option>
                    <option value="average">Average</option>
                    <option value="excellent">Excellent</option>
                </select>
                <select name="Other Skills[Languages][Reading][]">
                    <option value="reading">-Reading-</option>
                    <option value="beginner">Beginner</option>
                    <option value="average">Average</option>
                    <option value="excellent">Excellent</option>
                </select>
                <select name="Other Skills[Languages][Writing][]">
                    <option value="writing">-Writing-</option>
                    <option value="beginner">Beginner</option>
                    <option value="average">Average</option>
                    <option value="excellent">Excellent</option>
                </select>
                <input type="button" name="remove" value="X">
            </div>
        </div>
        <div>
            <input type="button" id="AddLang" value="Add Language">
        </div>
        <div>
            <div>Driver's License</div>
            <label for="b">B</label><input id="b" type="checkbox" name="Other Skills[Driver's License][]" value="B">
            <label for="a">A</label><input id="a" type="checkbox" name="Other Skills[Driver's License][]" value="A">
            <label for="c">C</label><input id="c" type="checkbox" name="Other Skills[Driver's License][]" value="C">
        </div>
    </fieldset>
    <input type="submit" name="submit" value="Generate CV">
</form>
</body>
</html>