
function myFunction() {
    if (document.getElementById('wrapper').style.display === 'none') {
        document.getElementById('wrapper').style.display = 'block';
    } else {
        document.getElementById('wrapper').style.display = 'none';
    }
}
function rotate() {
    document.getElementById('formContainer').style.transform = 'rotateY( 180deg )';
}

function revRotate() {
    document.getElementById('formContainer').style.transform = 'rotateY( 0 )';
}

function dropdown() {
    var acc = document.getElementsByClassName("accordion");
    var i;

    for (i = 0; i < acc.length; i++) {
        acc[i].addEventListener("click", function () {
            this.classList.toggle("active");
            var panel = this.nextElementSibling;
            if (panel.style.display === "block") {
                panel.style.display = "none";
            } else {
                panel.style.display = "block";
            }
        });
    }
}

function details() {
    var agent = document.getElementsByClassName("agents");
    var i;

    for (i = 0; i < agent.length; i++) {
        agent[i].addEventListener("click", function () {
            var tab = document.getElementById("agdetails");
            tab.classList.toggle("transform-active");
            tab.textContent = this.textContent;
        });

    }

}
function login() {

    var email = document.getElementById("Lemail").value;
    var pass = document.getElementById("Lpass").value;
    if (email == "" && pass == "") {
        alert("Email and Password Field Can't Be Empty")
    }
    else {
        $.ajax({
            type: 'GET',
            url: 'https://localhost:5001/api/owner/' + email,
            contentType: 'application/json',
            dataType: 'json',
            crossDomain: true,
            success: function (data) {
                var dbpass = "";
                $.each(data, function (index, val) {
                    if (index == "ownerpass")
                        dbpass = val;
                });

                if (dbpass == pass) {
                    alert("Login Successful");
                    //window.location.href = "http://localhost:6001/Home/Index";
                    document.getElementById("loging").style.visibility = "hidden";
                    document.getElementById("logout").style.visibility = "visible";
                    document.getElementById('wrapper').style.display = 'none';
                }
                else
                    alert("Wrong Password");
            },
            error: function (request, message, error) {
                var msg = "";
                msg += "Code: " + request.status + "\n";
                msg += "Text: " + request.statusText + "\n";
                if (request.responseJSON != null) {
                    msg += "Message" +
                        request.responseJSON.Message + "\n";
                }
                alert(msg);
            }
        });
    }
}

function logout() {
    window.location.href = "http://localhost:6001/Home/Index";
}
function registration() {

    var OwnerData = new Object();
    OwnerData.OwnerName = $('#OwnerName').val();
    OwnerData.OwnerContact = $('#OwnerContact').val();
    OwnerData.OwnerEmail = $('#OwnerEmail').val();
    OwnerData.Ownerpass = $('#Ownerpass').val();

    $.ajax({
        url: 'https://localhost:5001/api/owner',
        type: 'POST',
        contentType: "application/json",
        dataType: 'json',
        crossDomain: true,
        data: JSON.stringify(OwnerData),
        success: function (data, textStatus, xhr) {
            if (data != undefined) {
                alert("Registration succssful")
                window.location.href = "http://localhost:6001/Home/Index";
            }
            else {
                alert("Something is WRONG. Please try again later")
            }
            //console.log(data);
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log('Error in Operation !!!');
        }
    });
}


function addfleet() {
    var e = document.getElementById("soflow");
    var strUser = e.options[e.selectedIndex].text;
    var FleetData = new Object();
    FleetData.FleetRCNo = $('#rcno').val();
    FleetData.FleetType = strUser;
    FleetData.CompanyName = $('#Cname').val();
    FleetData.OwnerId = 101;
    $.ajax({
        url: 'http://localhost:5002/api/fleet',
        type: 'POST',
        contentType: "application/json",
        dataType: 'json',
        crossDomain: true,
        data: JSON.stringify(FleetData),
        success: function (data) {
            if (data != undefined) {
                alert("Fleet added succssfully")
                window.location.href = "http://localhost:6001/Home/Index";
            }
            else {
                alert("Error something wrong !!!")
            }
            //console.log(data);
        },
        error: function (xhr, textStatus, errorThrown) {
            alert("Error in Operation !!!");
        }
    });
}

function allfleet() {
    var e = document.getElementById("soflow");
    var strUser = e.options[e.selectedIndex].text;
    var FleetData = new Object();
    FleetData.FleetRCNo = $('#rcno').val();
    FleetData.FleetType = strUser;
    FleetData.CompanyName = $('#Cname').val();
    FleetData.OwnerId = 101;
    $.ajax({
        url: 'http://localhost:5002/api/fleet',
        type: 'GET',
        contentType: "application/json",
        dataType: 'json',
        crossDomain: true,
        data: JSON.stringify(FleetData),
        success: function (data) {
            if (data != undefined) {
                alert("Click ok to see a fleet list")
                window.location.href = "http://localhost:6001/Home/Agents";
            }
            else {
                alert("Error something wrong !!!")
            }
            //console.log(data);
        },
        error: function (xhr, textStatus, errorThrown) {
            alert("Error in Operation !!!");
        }
    });
}

function btndisabled() {
    var bt = document.getElementById('Button');
        bt.disabled = true;
}