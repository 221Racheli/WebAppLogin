

const name = async () => {
    console.log("In func")
    let m_body = document.getElementsByTagName("body")[0];
    let h_3 = document.createElement("h3");
    h_3.innerHTML = `Hello ${sessionStorage.getItem("firstName")}`;
    m_body.appendChild(h_3);
}

name();

async function Update() {
    const email = document.getElementById("registEmail").value;
    const password = document.getElementById("registPassword").value;
    const firstName = document.getElementById("firstName").value;
    const lastName = document.getElementById("lastName").value;
    const user = JSON.stringify({ password: password, email: email, firstName: firstName, lastName: lastName });
    console.log(sessionStorage.getItem("id"));
    const response = await fetch(
        `https://localhost:44390/api/users/${sessionStorage.getItem("id")}`, {
        method: 'PUT',
        body: user,
        headers: {
            'Content-Type': 'application/json ; charest=utf-8'
        }
    }
    );
}
