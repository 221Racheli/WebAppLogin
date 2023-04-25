
function drawProducts(data) {
    data.forEach(product => {
        var temp = document.getElementById("temp-card");
        var clon = temp.content.cloneNode(true);
        clon.querySelector("h1").innerText = product.name;
        clon.querySelector("img").src = `../pictures${product.img}`;
        clon.querySelector(".price").innerText = `${product.price} $`;
        clon.querySelector(".description").innerText = product.description;
        document.body.appendChild(clon);
    })
}

function drawCategories(data) {
    data.forEach(category => {
        var temp = document.getElementById("temp-category");
        var clon = temp.content.cloneNode(true);
        //clon.querySelector("h1").innerText = product.name;
        //clon.querySelector("img").src = `../pictures${product.img}`;
        //clon.querySelector(".price").innerText = `${product.price} $`;
        //clon.querySelector(".description").innerText = product.description;
        document.body.appendChild(clon);
    })
}


async function getProducts() {
    const response = await fetch(
        `/api/products`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json ; charest=utf-8'
        }
    }
    );
    if (!response.ok) {
        alert("products are not exists");
    }
    else {
        const data = await response.json();
        drawProducts(data);
    }
}

async function getCategories() {
    const response = await fetch(
        `/api/categories`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json ; charest=utf-8'
        }
    }
    );
    if (!response.ok) {
        alert("categories are not exists");
    }
    else {
        const data = await response.json();
        drawCategories(data);
    }
}

document.addEventListener("load", getProducts);








