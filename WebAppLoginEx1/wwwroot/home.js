

async function LogIn() {
    console.log("login");
    const email = document.getElementById("email").value;
    const password = document.getElementById("password").value;
    const user = JSON.stringify({ password: password, email: email });
    const response = await fetch(
        'https://localhost:44390/api/users', {
        method: 'POST',
        body: user,
        headers: {
            'Content-Type': 'application/json'
        }
    }
    );
    if (!response.ok) {
        alert("user name or email not exists");
    }
    else {
        if (response.status == '204') {
            alert("user name or email not exists");
        }
        else {
            const data = await response.json();
            if (data) {
                sessionStorage.setItem("userInfo", JSON.stringify({ firstName: data.firstName, lastName: data.lastName }));
                sessionStorage.setItem("firstName", data.firstName);
                sessionStorage.setItem("id", data.userId);
                window.location.href = "update.html";
            }
        }
    }
}


async function Regist() {
    const email = document.getElementById("registEmail").value;
    const password = document.getElementById("registPassword").value;
    const firstName = document.getElementById("firstName").value;
    const lastName = document.getElementById("lastName").value;
    const user = JSON.stringify({ password : password, email: email, firstName: firstName, lastName: lastName });
    console.log("hello");
    console.log(email);
    console.log(password);
    const response = await fetch(
        'https://localhost:44390/api/users/regist', {
        method: 'POST',
        body: user,
        headers: {
            'Content-Type': 'application/json'
        }
    }
    );
    if (!response.ok) {
        if (response.status == '400') {
            alert(`email already exists ${response.status}`);
        }  
    }
    else {
        if (response.status == '201') {
            alert("user created");
        }
        else {
            alert("all fields are require");
        }
    }
}

