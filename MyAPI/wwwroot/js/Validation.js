// Function to validate user information
function ValidateInfo() {

    var fname = document.myForm.firstName.value;
    var lname = document.myForm.lastName.value;
    var age = parseInt(document.myForm.age.value);
    var email = document.myForm.email.value;


    if (fname.length >= 3) {
        if (lname.length >= 3) {
            if (age >= 12) {
                if (email.length >= 8) {

                    document.getElementById('first-register-div').style.display = 'none';
                    document.getElementById('second-register-div').style.display = 'block';

                } else {
                    alert("Email is too short!")
                }

            } else {
                alert("Age Must not be < 12!")
            }

        } else {
            alert("Invalid LastName!")
        }

    } else {
        alert('Invalid FirstName!')
    }
}

// Function to validate user account settings;

function ValidadeAccount() {

    var uname = document.myForm.userName.value;
    var pword1 = document.myForm.password.value;
    var pword2 = document.myForm.pword2.value;

    if (uname == "" || pword1 == "") {
        alert("Empty fields!")
        return false;

    } else if (uname.length < 3) {
        alert("Invalid Username!")
        return false;

    } else if (pword1 != pword2) {
        alert("Passwords must match!")
        return false;

    } else if (pword1.length < 5) {
        alert("Password must have at least 5 chacteres!")
        return false;
    }

}