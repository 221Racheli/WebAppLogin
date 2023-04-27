
let products = [];
let checkedCategories = [];

function drawProducts(data) {
    data.forEach(product => {
        var temp = document.getElementById("temp-card");
        var clon = temp.content.cloneNode(true);
        clon.querySelector("h1").innerText = product.name;
        clon.querySelector("img").src = `../pictures${product.img}`;
        clon.querySelector(".price").innerText = `${product.price} $`;
        clon.querySelector(".description").innerText = product.description;
        document.getElementById("PoductList").appendChild(clon);
    })
}

function drawCategories(data) {
    data.forEach(category => {
        var temp = document.getElementById("temp-category");
        var clon = temp.content.cloneNode(true);
        clon.querySelector("input").id = category.id;
        clon.querySelector("input").addEventListener('click', (e) => {
            search(e.target.checked, e.target.id);
        });
        clon.querySelector("input").value = category.name;
        clon.querySelector("label").for = category.name;
        clon.querySelector(".OptionName").innerText = category.name;
        clon.querySelector(".Count").innerText = (products.filter(product => product.category.id == category.id)).length;
        document.getElementById("categoryList").appendChild(clon);
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
        products = data;
        drawProducts(data);
    }
}

async function getCategories() {
    console.log("getCategories");
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

async function atLoad() {
    await getProducts();
    await getCategories();
}

document.addEventListener("load", atLoad());

function cleanScreen() {
    document.getElementById("PoductList").innerHTML = '';
}

//function filterByCatrgory() {
    
//}

async function search(checked, id) {
    cleanScreen();
    const ind = checkedCategories.findIndex(category => category == id);
    if (ind > 0) {
        checkedCategories = checkedCategories.filter(category => category != id);
    }
    else {
        checkedCategories.push(id);
    }
    const categoryId = id;
    const desc = document.getElementById("nameSearch").innerText;
    const minPrice = document.getElementById("minPrice").innerText;
    const maxPrice = document.getElementById("maxPrice").innerText;

    const response = await fetch(
        `/api/products/search?desc=${desc}&minPrice=${minPrice}&maxPrice=${maxPrice}&categoryId=${categoryId}`, {
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
        products = data;
        drawProducts(data);
    }
}






