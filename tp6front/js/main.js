function validateForm()
{
    var fname = document.forms["myForm"]["_fname"].value;
    var lname = document.forms["myForm"]["_lname"].value;
    if (fname == "" || lname == "")
    {
        alert("Please enter your name and last name!");
        return false;
    }
    else
    {
        alert("Your message has been sent");
    }
}

function clearFields()
{
    var radioCheck = document.getElementById("other").checked=true;
    var fields = document.getElementsByClassName("form-control");
    for (let index = 0; index < fields.length; index++) 
    {
        fields[index].value = "";
    }
}